using System;
using System.Threading.Tasks;
using CommandLine;
using GameLib.Cli.Ui;
using GameLib.Main.Service.PlatformAccessors.Steam;

namespace GameLib.Cli
{
	internal class Program
	{
		public static Options Arguments;

		public static void Main(String[] args)
		{
			Parser.Default.ParseArguments<Options>(args).WithParsed(opts => Program.Arguments = opts);

			MainAsync().GetAwaiter().GetResult();
		}

		public static async Task MainAsync()
		{

			var list = await new SteamAccessor().ListGames();
			list.ForEach(i => Console.WriteLine(i.Name));
		}
	}
}