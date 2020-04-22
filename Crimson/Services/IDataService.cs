using Crimson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Services
{
    interface IDataService
    {
        void DeleteGameAt(int index);
        IEnumerable<Game> GetAllGames();
        Game GetGameMacroAt(int gameIndex);
        void UpdateGame(Game game);
    }
}
