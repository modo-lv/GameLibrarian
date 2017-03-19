using CommandLine;
using GameLib.Main.Domain.Entities;

namespace GameLib.Cli.Ui
{
	public class Options
	{
		[Option(shortName: 'p', longName: "platform", Default = GamePlatform.Steam)]
		public GamePlatform Platform { get; set; }

		[Option(shortName: 'a', longName: "action", Default = ActionType.List)]
		public ActionType Action { get; set; }


		public enum ActionType
		{
			List,
		}
	}
}