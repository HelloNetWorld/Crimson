using Crimson.DataAccessLayer;
using Crimson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Services
{
    public class GameDataService : IDataService
    {
        
        IRepository<Game> _repository;
        public GameDataService(IRepository<Game> repository)
        {
            _repository = repository;
        }

        public void DeleteGameAt(int index)
        {
            _repository.DeleteAt(index);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _repository.GetAll();
        }

        public Game GetGameMacroAt(int gameIndex)
        {
            return _repository.GetAt(gameIndex);
        }

        public void UpdateGame(Game game)
        {
            _repository.Update(game);
        }
    }
}
