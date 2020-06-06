using Crimson.Models;
using System.Collections.Generic;

namespace Crimson.Services
{
    public interface IDataService
    {
        void DeleteGameAt(int index);
        IEnumerable<Game> GetAllGames();
        Game GetGameMacroAt(int gameIndex);
        void UpdateGame(Game game);
    }
}
