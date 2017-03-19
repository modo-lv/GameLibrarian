using System;
using System.Threading.Tasks;
using CommandLine;
using GameLib.Cli.Ui;
using GameLib.Main.Domain.Entities;
using GameLib.Main.Service.PlatformAccessors;
using GameLib.Main.Service.PlatformAccessors.Steam;
using Microsoft.Extensions.DependencyInjection;

namespace GameLib.Cli
{
	internal class Program
	{
		public static void Main(String[] args)
		{
			IServiceCollection services = new ServiceCollection();

			Parser.Default.ParseArguments<Options>(args).WithParsed(
				opts =>
				{
					services.AddSingleton(opts);

					services.AddSingleton(
						new UserData
						{
							Username = opts.Username
						});
					services.AddSingleton<SteamAccessor>();

					IServiceProvider provider = services.BuildServiceProvider();

					MainAsync(provider).GetAwaiter().GetResult();
				});
		}

		public static async Task MainAsync(IServiceProvider serviceProvider)
		{
			IPlatformAccessor accessor = serviceProvider.GetRequiredService<SteamAccessor>();
			UserData user = serviceProvider.GetRequiredService<UserData>();

			Console.WriteLine($"Loading game list for {user.Username}...");
			GameList games = await accessor.GetGameList();

			games.ForEach(g => Console.WriteLine(g.Name));
		}
	}
}