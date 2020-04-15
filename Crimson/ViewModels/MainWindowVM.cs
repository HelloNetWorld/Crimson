using Crimson.Model;
using Crimson.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace Crimson.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        private User _user;
        private MacroManager _manager = new MacroManager();
        public MainWindowVM()
        {
            _user = _manager.User;
            _user.PropertyChanged += (s, o) => { RaisePropertyChanged(nameof(ActivasionKey)); };
            _user.PropertyChanged += (s, o) => { RaisePropertyChanged(nameof(UserGames)); };

            _manager.PropertyChanged += (s, o) => { RaisePropertyChanged(nameof(ActivasionKey)); };

            UserGames = new ObservableCollection<GameVM>(_user.Games.Select(game => new GameVM(game,_manager)));
        }
        public DelegateCommand SetActivasionKey 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    
                    var w = new AddKeyBinding();
                    var vm = new AddKeyBindingVM()
                    {
                        Manager = _manager,
                        ActivasionKey = _manager.HotKey.ToString()
                    };
                    w.DataContext = vm;
                    w.Show();
                });
            }
        }
        public string ActivasionKey => _manager.HotKey.ToString();
        public ObservableCollection<GameVM> UserGames { get; }
    }
    public class GameVM : BindableBase
    {
        private readonly MacroManager _manager;
        private readonly Game _game;
        public GameVM(Game game, MacroManager manager = null)
        {
            // В случае добавления механизма редактирования скриптов,
            // нужно будет сделать подписку на коллекцию Games в Модели.
            if( game != null)
            { 
                Icon = game.IconPath;
                Name = game.Name;
            }

            if (manager != null)
                _manager = manager;

            if (game != null)
                _game = game;
        }
        public string Icon { get; }
        public string Name { get; }
        public DelegateCommand OpenGameWindow
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    var w = new GameWindow();
                    var vm = new GameWindowVM(_game,_manager);

                    w.DataContext = vm;
                    w.Show();
                });
            }
        }
    }
}
