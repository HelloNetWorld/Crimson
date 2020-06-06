using Crimson.DataAccessLayer;
using Crimson.Services;
using Crimson.ViewModels;

namespace Crimson
{
    public class ViewModelLocator
    {
        #region Private variables
        private static IDialogService _dialogService = new DialogService();
        private static IDataService _gameDataService = new GameDataService(new GameRepository());
        private static PerformService _performer = new PerformService();

        private static MainWindowVM _mainWindowVM = new MainWindowVM(_gameDataService, _performer, _dialogService);
        private static EditKeyBindingVM _editKeyBindingVM = new EditKeyBindingVM(_performer);
        private static GameWindowVM _gameWindow = new GameWindowVM(_performer, _dialogService);
        #endregion

        #region Public properties
        public static MainWindowVM MainWindowVM => _mainWindowVM;
        public static EditKeyBindingVM EditKeyBindingVM => _editKeyBindingVM;
        public static GameWindowVM GameWindowVM => _gameWindow;
        #endregion
    }
}
