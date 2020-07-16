using MP3Sharp;
using NAudio.Wave;
using NLayer;
using NVorbis;
using OpenToolkit.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using ARWaveReader = AudioReader.WaveFileReader;

namespace OpenTKAudioPlayground
{
	internal static class DecodeSound
    {
		private static string BASE_PATH = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\";
		private static string CONTENT_PATH = $@"{BASE_PATH}Content\Sounds\";

		public static SoundStats<float> LoadNVorbisData(string fileName)//WORKS - Cross Plat
		{
			var result = new SoundStats<float>();

			var reader = new VorbisReader(fileName);

			result.SampleRate = reader.SampleRate;
			result.TotalSeconds = (float)reader.TotalTime.TotalSeconds;

			var dataResult = new List<float>();

			float[] buffer = new float[reader.Channels * reader.SampleRate]; // 200ms

			while(reader.ReadSamples(buffer, 0, buffer.Length) > 0)
            {
				dataResult.AddRange(buffer);
            }

            switch (reader.Channels)
            {
				case 1:
					result.Format = AudioFormat.Mono32Float;
					break;
				case 2:
					result.Format = AudioFormat.StereoFloat32;
                    break;
            }

			result.BufferData = dataResult.ToArray();

			return result;
		}

        public static SoundStats<byte> LoadMP3SharpData(string fileName) // WORKS - Cross Plat
		{
			var result = new SoundStats<byte>();

			var reader = new MP3Stream(fileName);

			result.SampleRate = reader.Frequency;

			var dataResult = new List<byte>();

			byte[] buffer = new byte[reader.ChannelCount * reader.Frequency];

			while (reader.Read(buffer, 0, buffer.Length) > 0)
			{
				dataResult.AddRange(buffer);
			}

			//TODO: Need to test this out with 8 bit.
			//Will probably have to use the constant 4f for 16bit and 2f for 8bit
			result.TotalSeconds = dataResult.Count / 4f / reader.Frequency;

			if (reader.Format == SoundFormat.Pcm16BitMono)
            {
				result.Format = AudioFormat.Mono16;
            }
			else if (reader.Format == SoundFormat.Pcm16BitStereo)
            {
				result.Format = AudioFormat.Stereo16;
            }

			result.BufferData = dataResult.ToArray();

			return result;
		}

		public static SoundStats<byte> LoadNAudioData(string fileName) // WORKS - Windows Only
		{
			var reader = new Mp3FileReader(fileName);

			var dataResult = new List<byte>();

            var result = new SoundStats<byte>
            {
                SampleRate = reader.WaveFormat.SampleRate
            };

            byte[] buffer = new byte[reader.WaveFormat.Channels * reader.WaveFormat.SampleRate];

			while(reader.Read(buffer, 0, buffer.Length) > 0)
            {
				dataResult.AddRange(buffer);
            }

			if (reader.WaveFormat.Channels == 1)
			{
				if (reader.WaveFormat.BitsPerSample == 8)
				{
					result.Format = AudioFormat.Mono8;
				}
				else if (reader.WaveFormat.BitsPerSample == 16)
				{
					result.Format = AudioFormat.Mono16;
				}
			}
			else if (reader.WaveFormat.Channels == 2)
			{
				if (reader.WaveFormat.BitsPerSample == 8)
				{
					result.Format = AudioFormat.Stereo8;
				}
				else if (reader.WaveFormat.BitsPerSample == 16)
				{
					result.Format = AudioFormat.Stereo16;
				}
			}

			result.BufferData = dataResult.ToArray();


			return result;
		}
		
		public static SoundStats<byte> LoadWaveFile(string fileName) // WORKS - Cross Plat
        {
			var reader = new ARWaveReader(fileName);

            var result = new SoundStats<byte>
            {
                SampleRate = reader.WaveFormat.SampleRate,
				TotalSeconds = (float)reader.TotalTime.TotalSeconds
            };

            var dataResult = new List<byte>();

			byte[] buffer = new byte[reader.WaveFormat.Channels * reader.WaveFormat.SampleRate];

			while(reader.Read(buffer, 0, buffer.Length) > 0)
            {
				dataResult.AddRange(buffer);
            }

			if (reader.WaveFormat.Channels == 1)
            {
				if (reader.WaveFormat.BitsPerSample == 8)
                {
					result.Format = AudioFormat.Mono8;
                }
				else if (reader.WaveFormat.BitsPerSample == 16)
				{
					result.Format = AudioFormat.Mono16;
				}
				else if (reader.WaveFormat.BitsPerSample == 32)
				{
					result.Format = AudioFormat.Mono32Float;
				}
			}
			else if (reader.WaveFormat.Channels == 2)
            {
				if (reader.WaveFormat.BitsPerSample == 8)
				{
					result.Format = AudioFormat.Stereo8;
				}
				else if (reader.WaveFormat.BitsPerSample == 16)
				{
					result.Format = AudioFormat.Stereo16;
				}
				else if (reader.WaveFormat.BitsPerSample == 32)
				{
					result.Format = AudioFormat.StereoFloat32;
				}
			}

			result.BufferData = dataResult.ToArray();

			return result;
		}
	}
}
