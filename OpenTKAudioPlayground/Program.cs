using System;
using System.Data;
using System.Net.Http.Headers;
using OpenToolkit.Audio.OpenAL;
using System.Media;
using System.IO;
using System.Reflection;
using NAudio.Wave;
using NLayer;
using System.Text;
using NVorbis;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave.SampleProviders;

namespace OpenTKAudioPlayground
{
    public class Program
    {
		private static Task _getTimeTask;
		private static CancellationTokenSource _taskTokenSource;
		private static string BASE_PATH = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{(Environment.OSVersion.Platform == PlatformID.Unix ? "/" : "\\")}";
		private static string CONTENT_PATH = Environment.OSVersion.Platform == PlatformID.Unix ? $@"{BASE_PATH}Content/Sounds/" : $@"{BASE_PATH}Content\Sounds\";
		private static Sound _sound;

        public static unsafe void Main(string[] args)
        {
            //var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.wav";//WORKS
            //var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.mp3";
            //var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.ogg";
            //var fileName = $"{CONTENT_PATH}lazer.mp3";
            //var fileName = $"{CONTENT_PATH}lazer.ogg";
            //var fileName = $"{CONTENT_PATH}the-plan.ogg";
            //var fileName = $"{CONTENT_PATH}ceramic-tube.wav";//WORKS
            //var fileName = $"{CONTENT_PATH}ceramic-tube.mp3";
            var fileName = $"{CONTENT_PATH}snare.wav";//WORKS
            //var fileName = $"{CONTENT_PATH}snare.mp3";
            //var fileName = $"{CONTENT_PATH}tone.wav";//WORKS
            //var fileName = $"{CONTENT_PATH}tone.mp3";
            //var fileName = $"{CONTENT_PATH}rick-drum.wav";//WORKS
            //var fileName = $"{CONTENT_PATH}rick-drum.mp3";
            //var fileName = $"{CONTENT_PATH}rick-drum.ogg";

            var command = string.Empty;
			_sound = new Sound(fileName);

			Console.WriteLine("Press 'play' to play sound and 'pause' to pause, and 'q' to quit");
			Console.WriteLine("To set the time in the sound to skip to, ust the 'set-time' command.\n\tTime value sound be mm:s");
			Console.WriteLine();

			while (command != "q")
            {
				command = Console.ReadLine();

                switch (command)
                {
					case "q":
						_sound.Dispose();
						break;
					case "play":
						_sound.Play();
						break;
					case "pause":
						_sound.Pause();
						break;
					case "stop":
						_sound.Stop();
						break;
					case "reset":
						_sound.Reset();
						break;
					case "get-setting volume":
						Console.WriteLine($"Volume: {_sound.Volume}");
						break;
					case "get-setting looping":
						Console.WriteLine(_sound.IsLooping);
						break;
					case "set-setting looping true":
						var loopingTrueSections = command.Split(' ');

						if (loopingTrueSections[2].ToLower() != "true")
                        {
							Console.WriteLine($"The looping value of {loopingTrueSections[2]} is not valid.");
							break;
                        }

						_sound.IsLooping = true;
						break;
					case "set-setting looping false":
						var loopingFalseSections = command.Split(' ');

						if (loopingFalseSections[2].ToLower() != "false")
						{
							Console.WriteLine($"The looping value of {loopingFalseSections[2]} is not valid.");
							break;
						}

						_sound.IsLooping = false;
						break;
					case "get-time":
						StartGetTimeTask();
						break;
					case "stop-time":
						_taskTokenSource.Cancel();
						break;
					default:
						if (command.StartsWith("set-time"))
						{
							var setTimeSections = command.Split(' ');

							if (setTimeSections.Length < 2 || !setTimeSections[1].Contains(':'))
							{
								Console.WriteLine("Time value not correct.  Express time value as 'mm:s'");
								Console.WriteLine();
							}

							var timeSections = setTimeSections[1].Split(':');

							if (timeSections.Length < 2)
                            {
								Console.WriteLine("Time value not correct.  Express time value as 'mm:s'");
								Console.WriteLine();
							}

							var parseMinuteSuccess = int.TryParse(timeSections[0], out int minutes);

							if (!parseMinuteSuccess)
                            {
								Console.WriteLine("Time value not correct.  Express time value as 'mm:s'");
								Console.WriteLine();
							}

							var parseSecondSuccess = int.TryParse(timeSections[1], out int seconds);

							if (!parseSecondSuccess)
							{
								Console.WriteLine("Time value not correct.  Express time value as 'mm:s'");
								Console.WriteLine();
							}

							_sound.SetTimePosition((minutes * 60f) + seconds);
						}
						else if (command.StartsWith("set-volume"))
                        {
							var setVolumeSections = command.Split(' ');

							if (setVolumeSections.Length < 2)
                            {
								Console.WriteLine("Volume value not correct.  Express as floating point number.");
								Console.WriteLine();
                            }
							else
                            {
								var volumeParseSuccess = float.TryParse(setVolumeSections[1], out float volume);

								if (volumeParseSuccess)
                                {
									_sound.Volume = volume;
                                }
								else
                                {
									Console.WriteLine("Volume value not correct.  Express as floating point number.");
									Console.WriteLine();
								}
                            }
                        }
						else
                        {
							Console.WriteLine("Command not recognized.");
                        }
						break;
                }
			}

			_sound.Dispose();
		}

		private static void StartGetTimeTask()
        {
			if (_getTimeTask != null)
            {
				_getTimeTask.Dispose();
				_getTimeTask = null;
            }

			_taskTokenSource = new CancellationTokenSource();
			_getTimeTask = new Task(() =>
			{
				while(!_taskTokenSource.IsCancellationRequested)
                {
					Thread.Sleep(800);

					var seconds = _sound.GetCurrentTimePosition();

					Console.Title = $"Time: {seconds}";
                }
			}, _taskTokenSource.Token);

			_getTimeTask.Start();
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

		private static void SaveDataAsCSV(float[] data)
        {
			var csvData = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				if (i % 2 == 0)
				{
					csvData.Append(data[i].ToString("0." + new string('#', 339)) + ",");
				}
				else
				{
					csvData.Append(data[i].ToString("0." + new string('#', 339)) + ",\r\n");
				}
			}

			File.WriteAllText(@"C:\temp\mp3sharp-data.csv", csvData.ToString());
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
