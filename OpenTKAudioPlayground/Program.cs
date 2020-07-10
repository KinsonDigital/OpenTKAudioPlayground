using System;
using System.Data;
using System.Net.Http.Headers;
using OpenToolkit.Audio.OpenAL;
using System.Media;
using System.IO;
using System.Reflection;
using NAudio.Wave;

namespace OpenTKAudioPlayground
{
    public class Program
    {
		private static string BASE_PATH = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\";
		private static string CONTENT_PATH = $@"{BASE_PATH}Content\Sounds\";

        public static unsafe void Main(string[] args)
        {
			var waveFilePath = $"{CONTENT_PATH}cyberpunk-beat.wav";

			var command = string.Empty;
			var sound = new Sound(waveFilePath);

			while(command != "q")
            {
				Console.WriteLine("Press 'play' to play sound and 'pause' to pause, and 'q' to quit");

				command = Console.ReadLine();

                switch (command)
                {
					case "q":
						break;
					case "play":
						sound.Play();
						break;
					case "pause":
						sound.Pause();
						break;
					default:
						Console.WriteLine("Command not recognized.");
						break;
                }
			}

			sound.Dispose();
			//UseOpenAL();
		}


		private static void LoadWavWindowsOnly()
        {

        }

		private unsafe static void UseOpenAL()
        {
			//Initialize
			var device = ALC.OpenDevice(null);

			var attributes = new ALContextAttributes();
			var context = ALC.CreateContext(device, attributes);

			ALC.MakeContextCurrent(context);

			PrintVersion();

			Console.ReadKey();

			//Process
			int bufferId;
			int sourceId;

			bufferId = AL.GenBuffers(1)[0];

			sourceId = AL.GenSources(1)[0];

			int sampleFreq = 44100;

			// Generate sound data
			var sinData = CreateSoundData(sampleFreq);

			// Sends the buffer data to the sound card
			AL.BufferData(bufferId, ALFormat.Mono16, sinData, sinData.Length, sampleFreq);

			// Bind the buffer to the source
			AL.Source(sourceId, ALSourcei.Buffer, bufferId);

			AL.Source(sourceId, ALSourceb.Looping, true);



			//Play the source/sound
			AL.SourcePlay(sourceId);

			Console.ReadKey();

			///Dispose
			if (context != ALContext.Null)
			{
				ALC.MakeContextCurrent(ALContext.Null);
				ALC.DestroyContext(context);
			}
			context = ALContext.Null;

			if (device != IntPtr.Zero)
			{
				ALC.CloseDevice(device);
			}

			device = ALDevice.Null;
		}

		private static void PrintVersion()
        {
			var version = AL.Get(ALGetString.Version);
			var vendor = AL.Get(ALGetString.Vendor);
			var renderer = AL.Get(ALGetString.Renderer);
			Console.WriteLine(version);
			Console.WriteLine(vendor);
			Console.WriteLine(renderer);
		}

		public static short[] CreateSoundData(int sampleFreq)
        {
			double dt = 2 * Math.PI / sampleFreq;
			double amp = 0.5;

			int freq = 440;
			var dataCount = sampleFreq / freq;

			var sinData = new short[dataCount];

			for (int i = 0; i < sinData.Length; ++i)
			{
				sinData[i] = (short)(amp * short.MaxValue * Math.Sin(i * dt * freq));
			}


			return sinData;
		}
	}
}
