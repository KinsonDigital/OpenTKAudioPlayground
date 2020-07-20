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
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using OpenToolkit.Windowing.Common;

namespace OpenTKAudioPlayground
{
	public enum BitDepth
    {
		Bit8,
		Bit16,
    }

	public enum AudioType
    {
		wav,
		mp3,
		ogg,
    }

	public enum ChannelType
    {
		Mono,
		Stereo,
    }

    public class Program
    {
		private static Task _getTimeTask;
		private static CancellationTokenSource _taskTokenSource;
		private static string BASE_PATH = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{(Environment.OSVersion.Platform == PlatformID.Unix ? "/" : "\\")}";
		private static string CONTENT_PATH = Environment.OSVersion.Platform == PlatformID.Unix ? $@"{BASE_PATH}Content/Sounds/" : $@"{BASE_PATH}Content\Sounds\";
		private static Sound _sound;
		private static List<string> _soundNames = new List<string>();


		public static unsafe void Main(string[] args)
        {
			//var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.wav";//WORKS
			//var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}Where The Dead Ships Dwell.ogg";//WORKS
			//var fileName = $"{CONTENT_PATH}lazer.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}lazer.ogg";//WORKS
			//var fileName = $"{CONTENT_PATH}the-plan.ogg";//WORKS
			//var fileName = $"{CONTENT_PATH}ceramic-tube.wav";//WORKS
			//var fileName = $"{CONTENT_PATH}ceramic-tube.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}snare.wav";//WORKS
			//var fileName = $"{CONTENT_PATH}snare.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}tone.wav";//WORKS
			//var fileName = $"{CONTENT_PATH}tone.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}rick-drum.wav";//WORKS
			//var fileName = $"{CONTENT_PATH}rick-drum.mp3";//WORKS
			//var fileName = $"{CONTENT_PATH}rick-drum.ogg";//WORKS

			var command = string.Empty;

			_soundNames.AddRange(new [] {
				GetFilePath("dance", BitDepth.Bit16, AudioType.mp3, ChannelType.Mono),
				GetFilePath("deadships", BitDepth.Bit16, AudioType.mp3, ChannelType.Stereo),
				GetFilePath("stramloop", BitDepth.Bit16, AudioType.mp3, ChannelType.Stereo),
				GetFilePath("deadships", BitDepth.Bit16, AudioType.ogg, ChannelType.Stereo),
				GetFilePath("effectdrum", BitDepth.Bit16, AudioType.ogg, ChannelType.Stereo),
				GetFilePath("zap", BitDepth.Bit16, AudioType.ogg, ChannelType.Mono),
				GetFilePath("crash", BitDepth.Bit8, AudioType.wav, ChannelType.Mono),
				GetFilePath("deadships", BitDepth.Bit16, AudioType.wav, ChannelType.Stereo),
				GetFilePath("drum", BitDepth.Bit16, AudioType.wav, ChannelType.Mono),
				GetFilePath("snare", BitDepth.Bit16, AudioType.wav, ChannelType.Stereo),
				GetFilePath("whoosh", BitDepth.Bit8, AudioType.wav, ChannelType.Stereo),
			});

            Sound _sound = null;

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
						if (_sound is null)
                        {
							Console.WriteLine("You must load a song first.  Use 'get-names' to get a list of sound names.");
							break;
                        }

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
					case "get-names":
						Console.WriteLine("Names:");

						var names = GetNames(true);

						foreach (var name in names)
						{
							Console.WriteLine($"\t{Path.GetFileName(name)}");
						}
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
					case "run-tests":
						RunTests(_soundNames.ToArray());
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
						else if (command.StartsWith("load"))
                        {
							var loadSections = command.Split(' ');

							if (loadSections.Length < 2)
							{
								Console.WriteLine("The load command is not correct. Use the command 'load <name>:<type>'.  Types are wav, mp3 and ogg.");
								Console.WriteLine();
								break;
							}

							if (!loadSections[1].Contains(':'))
							{
								Console.WriteLine("The load command is not correct. Use the command 'load <name>:<type>'.  Types are wav, mp3 and ogg.");
								Console.WriteLine();
							}

							var songTypeSections = loadSections[1].Split(':');

							if (songTypeSections.Length < 2)
							{
								Console.WriteLine("The load command is not correct. Use the command 'load <name>:<type>'.  Types are wav, mp3 and ogg.");
								Console.WriteLine();
							}

							var fileName = GetFilePath(songTypeSections[0], songTypeSections[1]);

							Console.WriteLine($"Loading '{Path.GetFileName(fileName)}' . . .");

							_sound = new Sound(fileName);

							Console.WriteLine($"The sound file '{Path.GetFileName(fileName)}' loaded.");
							Console.WriteLine();
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

		private static void RunTests(string[] soundPaths)
        {
			var results = new Dictionary<string, bool>();

			Console.WriteLine();
			Console.WriteLine("Running sound tests . . .");
			Console.WriteLine("Use the answers 'y' or 'n'");
			Console.WriteLine();

            foreach (var soundPath in soundPaths)
            {
				var soundFileName = Path.GetFileName(soundPath);

				Sound sound = null;

                try
                {
					Console.WriteLine($"Loading sound data for '{soundFileName}'");

					sound = new Sound(soundPath);

					Console.WriteLine($"Playing sound '{soundFileName}'");
					sound.Play();

					Console.Write($"Did you hear the sound '{soundFileName}'?  Yes(y) or No(n)?");

					var answer = string.Empty;

					while(string.IsNullOrEmpty(answer) || !new[] { "y", "n" }.Contains(answer))
                    {
						answer = Console.ReadLine();

						//Interpret the answer
						if (answer == "n" || answer == "y")
                        {
							results.Add($"The sound named '{soundFileName}' {(answer == "y" ? "played" : "did not play")}.", answer == "y");
							break;
                        }
						else
                        {
							Console.WriteLine($"The answer '{answer}' is not recognized.  Please us 'y' or 'n'.");
							Console.WriteLine();
						}
                    }
                }
                catch (Exception ex)
                {
					results.Add($"Issue running sound '{soundFileName}'\r\n\t{ex.Message}", false);
                }

				sound?.Dispose();
            }

			//Print the results
			Console.WriteLine();

            foreach (var result in results)
            {
				Console.ForegroundColor = result.Value ? ConsoleColor.Green : ConsoleColor.Red;
				Console.Write($"{result.Key}\n");
            }

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
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

		private static string[] GetNames(bool withTypes = false)
        {
			var result = new List<string>();

			var currentFileList = new List<string>();

			string BuildName(string filePath)
            {
				var extension = Path.GetExtension(filePath).Replace(".", "");
				var name = Path.GetFileNameWithoutExtension(filePath).Split('-')[0];

                return $"{name}{(withTypes ? $" - ({extension})" : string.Empty)}";
            }

            foreach (var file in _soundNames)
            {
				result.Add(BuildName(file));
            }

			////Get wav names
			//currentFileList = Directory.GetFiles($@"{CONTENT_PATH}\wav\", "*.wav").ToList();
			//currentFileList.ForEach(f => result.Add(BuildName(f)));

			////Get mp3 names
			//currentFileList = Directory.GetFiles($@"{CONTENT_PATH}\mp3\", "*.mp3").ToList();
			//currentFileList.ForEach(f => result.Add(BuildName(f)));

			////Get ogg names
			//currentFileList = Directory.GetFiles($@"{CONTENT_PATH}\ogg\", "*.ogg").ToList();
			//currentFileList.ForEach(f => result.Add(BuildName(f)));

			return result.ToArray();
        }

		private static string GetFilePath(string name, BitDepth depth, AudioType audioType, ChannelType channelType)
        {
			var result = CONTENT_PATH;

			var channelName = Enum.GetName(typeof(ChannelType), channelType).ToLower();
			var folder = Enum.GetName(typeof(AudioType), audioType);
			var extension = $".{Enum.GetName(typeof(AudioType), audioType)}";
			var bitDepth = Enum.GetName(typeof(BitDepth), depth).Replace("Bit", "");

			result += $@"{folder}\{name}-{bitDepth}-{channelName}{extension}";


			return result;
        }

		private static string GetFilePath(string name, string type)
        {
			var files = Directory.GetFiles(CONTENT_PATH, "*.*", SearchOption.AllDirectories);

			var result = files.Where(f => f.Contains(name) && Path.GetExtension(f).Contains(type)).FirstOrDefault();

			return result;
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
	}
}
