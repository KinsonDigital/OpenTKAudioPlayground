using NAudio.Wave;
using OpenToolkit.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.Text;
using ARWaveFileReader = AudioReader.WaveFileReader;
using NAWaveFileReader = NAudio.Wave.WaveFileReader;

namespace OpenTKAudioPlayground
{
    public class Sound : IDisposable
    {
        private ALDevice _device;
        private ALContextAttributes _attributes;
        private ALContext _context;
        private int _bufferId;
        private int _sourceId;
        private const int SAMPLE_FEQ = 44100;
        private bool _isDisposed;

        public Sound(string fileName)
        {
            _device = ALC.OpenDevice(null);

            _attributes = new ALContextAttributes();
            _context = ALC.CreateContext(_device, _attributes);

            ALC.MakeContextCurrent(_context);


            _bufferId = AL.GenBuffers(1)[0];
            _sourceId = AL.GenSources(1)[0];

            var reader = new ARWaveFileReader(fileName);

            var bufferData = new byte[reader.Length];

            var readResult = reader.Read(bufferData, 0, (int)reader.Length);


            // Sends the buffer data to the sound card
            AL.BufferData(_bufferId, ALFormat.Stereo16, bufferData, bufferData.Length, SAMPLE_FEQ);

            // Bind the buffer to the source
            AL.Source(_sourceId, ALSourcei.Buffer, _bufferId);
            AL.Source(_sourceId, ALSourceb.Looping, true);
        }

        public void Play() => AL.SourcePlay(_sourceId);

        public void Pause() => AL.SourcePause(_sourceId);

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                }

                if (_context != ALContext.Null)
                {
                    ALC.MakeContextCurrent(ALContext.Null);
                    ALC.DestroyContext(_context);
                }

                _context = ALContext.Null;

                if (_device != IntPtr.Zero)
                    ALC.CloseDevice(_device);

                _device = ALDevice.Null;

                _isDisposed = true;
            }
        }

        ~Sound() => Dispose(disposing: false);

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
