using OpenToolkit.Audio.OpenAL;
using System;
using NVorbis;
using System.IO;
using OpenToolkit.Graphics.ES11;
using NAudio.Wave;

namespace OpenTKAudioPlayground
{
    public class Sound : IDisposable
    {
        private ALDevice _device;
        private ALContextAttributes _attributes;
        private ALContext _context;
        private int _bufferId;
        private int _sourceId;
        private bool _isDisposed;
        private SoundStats<float> _oggSoundData;
        private string _fileName;
        private SoundStats<byte> _mp3SoundData;

        public Sound(string fileName)
        {
            _fileName = fileName;

            Init();
        }

        public void Init()
        {
            _device = ALC.OpenDevice(null);

            _attributes = new ALContextAttributes();
            _context = ALC.CreateContext(_device, _attributes);

            ALC.MakeContextCurrent(_context);

            _bufferId = AL.GenBuffers(1)[0];
            _sourceId = AL.GenSources(1)[0];

            //If data is byte, use ALFormat.Stereo16.  For float use ALFormat.StereoFloat32Ext
            switch (Path.GetExtension(_fileName))
            {
                case ".ogg":
                    _oggSoundData = DecodeSound.LoadNVorbisData(_fileName);

                    AL.BufferData(_bufferId,
                                  MapFormat(_oggSoundData.Format),
                                  _oggSoundData.BufferData,
                                  _oggSoundData.BufferData.Length * sizeof(float),
                                  _oggSoundData.SampleRate);

                    break;
                case ".mp3":
                    _mp3SoundData = DecodeSound.LoadMP3SharpData(_fileName);

                    AL.BufferData(_bufferId,
                                  MapFormat(_mp3SoundData.Format),
                                  _mp3SoundData.BufferData,
                                  _mp3SoundData.BufferData.Length,
                                  _mp3SoundData.SampleRate);
                    break;
                case ".wav":
                    var (wavBuffer, wavSampleRate, wavFormat) = DecodeSound.LoadWaveFile(_fileName);

                    var wavALFormat = MapFormat(wavFormat);

                    // Sends the buffer data to the sound card
                    AL.BufferData(_bufferId, wavALFormat, wavBuffer, wavBuffer.Length, wavSampleRate);
                    break;
            }

            // Bind the buffer to the source
            AL.Source(_sourceId, ALSourcei.Buffer, _bufferId);
        }

        public bool IsLooping
        {
            get
            {
                AL.GetSource(_sourceId, ALSourceb.Looping, out bool value);

                return value;
            }
            set
            {
                AL.Source(_sourceId, ALSourceb.Looping, value);
            }
        }

        public void Play() => AL.SourcePlay(_sourceId);

        public void Pause() => AL.SourcePause(_sourceId);

        public void Stop() => AL.SourceStop(_sourceId);

        public void Reset() => AL.SourceRewind(_sourceId);

        public void SetTimePosition(float seconds)
        {
            // Prevent negative number
            seconds = seconds < 0f ? 0.0f : seconds;

            var extension = Path.GetExtension(_fileName);

            // Do not go past the end of the total sound effect time
            switch (extension)
            {
                case ".ogg":
                    seconds = seconds > _oggSoundData.TotalSeconds ? _oggSoundData.TotalSeconds : seconds;
                    break;
                case ".mp3":
                    seconds = seconds > _mp3SoundData.TotalSeconds ? _mp3SoundData.TotalSeconds : seconds;
                    break;
                case ".wav":
                    throw new NotImplementedException();
                default:
                    throw new Exception($"Unsupported file type of '{Path.GetExtension(_fileName)}'");
            }

            AL.Source(_sourceId, ALSourcef.SecOffset, seconds);
        }

        public float GetSeconds()
        {
            AL.GetSource(_sourceId, ALSourcef.SecOffset, out float currentSeconds);
            
            return currentSeconds;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                // Delete the buffer
                AL.DeleteBuffer(_bufferId);
                AL.DeleteSource(_sourceId);

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

        private void UploadSoundData()
        {
            // Sends the buffer data to the sound card
            AL.BufferData(_bufferId, MapFormat(_oggSoundData.Format), _oggSoundData.BufferData, _oggSoundData.BufferData.Length * sizeof(float), _oggSoundData.SampleRate);
        }

        private ALFormat MapFormat(AudioFormat format)
        {
            switch (format)
            {
                case AudioFormat.Mono8:
                    return ALFormat.Mono8;
                case AudioFormat.Mono16:
                    return ALFormat.Mono16;
                case AudioFormat.Mono32Float:
                    return ALFormat.MonoFloat32Ext;
                case AudioFormat.Stereo8:
                    return ALFormat.Stereo8;
                case AudioFormat.Stereo16:
                    return ALFormat.Stereo16;
                case AudioFormat.StereoFloat32:
                    return ALFormat.StereoFloat32Ext;
                default:
                    return default;
            }
        }
    }
}
