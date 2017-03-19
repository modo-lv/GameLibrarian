using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GameLib.Main.Domain.Entities;
using GameLib.Main.Domain.Inputs;

namespace GameLib.Main.Service.PlatformAccessors.Steam
{
	public class SteamAccessor : IPlatformAccessor
	{
		private readonly UserData _userData;

		public SteamAccessor(UserData userData) { this._userData = userData; }

		public async Task<GameList> GetGameList(GameListType listType = GameListType.All)
		{
			var client = new HttpClient();
			var xml = await client.GetStringAsync(
				$"http://steamcommunity.com/id/{this._userData.Username}/games?tab=all&xml=1");

			var ser = new XmlSerializer(typeof(SteamGamesList));
			var list = (SteamGamesList)ser.Deserialize(new StringReader(xml));

			var result = new GameList();
			result.AddRange(list.Games.Select(steam => new GameEntry {Name = steam.Name}));
			return result;
		}
	}
}