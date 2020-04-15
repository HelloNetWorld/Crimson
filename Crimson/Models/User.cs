using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace Crimson.Model
{
    public class User : BindableBase
    {
        // private string _activasionKey;
        private List<Game> _games = new List<Game>();
        public User()
        {
            // _activasionKey = "F12"; 
            // TODO: Пока одна игра, со временем можно надобавлять больше,
            // и сделать отдельную загрузку.
            _games.Add(new RustGame());
        }
        //public string ActivasionKey
        //{ 
        //    get => _activasionKey;
        //    set => _activasionKey = value;
        //}
        public IEnumerable<Game> Games
        {
            get
            {
                return _games;
            }
        }

        internal MacroInfo GetMacroOfGameAndWeapon(int indexOfGame, int indexOfMacro)
        {
            if (indexOfGame >= 0 && indexOfMacro >= 0)
            {
                return this?
                .Games?
                .ElementAt(indexOfGame)?
                .Macros?
                .ElementAt(indexOfMacro)?
                .MacroInfoForWeapon;
            }
            return null;
        }
    }
}