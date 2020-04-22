using Crimson.DataAccessLayer;
using Crimson.Services;
using Crimson.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson
{
    public class ViewModelLocator
    {
        private static IDialogService _dialogService = new DialogService();
        private static IDataService _gameDataService = new GameDataService(new GameRepository());

        private static MainWindowVM _mainWindowVM = new MainWindowVM();
        //private static GameVM gameVM = new GameVM();


        public static MainWindowVM MainWindowVM
        {
            get
            {
                return _mainWindowVM;
            }
        }

        //    public static SecondViewModel SecondViewModel
        //    {
        //        get
        //        {
        //            return _secondViewModel;
        //        }
        //    }
    }
}
