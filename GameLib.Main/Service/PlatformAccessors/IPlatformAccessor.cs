using System.Threading.Tasks;
using GameLib.Main.Domain.Entities;

namespace GameLib.Main.Service.PlatformAccessors
{
    public interface IPlatformAccessor
    {
	    Task<GameList> GetGameList(GameListType listType = GameListType.All);
    }
}
