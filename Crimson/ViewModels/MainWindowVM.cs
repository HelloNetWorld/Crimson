using Crimson.Models;
using Crimson.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Configuration;
using Crimson.Services;
using System;
using Crimson.DataAccessLayer;
using Crimson.Extensions;
using Crimson.Utility;

namespace Crimson.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        #region Private variables
        private readonly IDataService _gameDataService;
        private readonly PerformService _performer;
        private readonly IDialogService _dialogService;
        private ObservableCollection<GameVM> _games;
        private string keyBinding;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an instance of <see cref="MainWindowVM"/>.
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="performer"></param>
        /// <param name="dialogService"></param>
        public MainWindowVM(IDataService dataService, PerformService performer, IDialogService dialogService)
        {
            if (dataService == null) throw new ArgumentNullException(nameof(dataService));
            if (performer == null) throw new ArgumentNullException(nameof(performer));
            if (dialogService == null) throw new ArgumentNullException(nameof(dialogService));

            _gameDataService = dataService;
            _performer = performer;
            _dialogService = dialogService;

            _performer.PropertyChanged += _performer_PropertyChanged;

            LoadData();

            LoadCommands();
        }


        #endregion

        #region Private Methods
        /// <summary>
        /// Срабатывает в случе когда меняется свойство PerformService.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _performer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            KeyBinding = _performer.HotKey.ToString();
        }

        /// <summary>
        /// Загружает команды.
        /// </summary>
        private void LoadCommands()
        {
            EditKeyBindingCommand = new DelegateCommand(EditKeyBinding);
        }

        /// <summary>
        /// Открывает редактор KeyBinding.
        /// </summary>
        private void EditKeyBinding()
        {
            _dialogService.ShowEditKeyDialog();
        }

        /// <summary>
        /// Загружает данные.
        /// </summary>
        private void LoadData()
        {
            Games = _gameDataService
                .GetAllGames()
                .Select(g => new GameVM(g, _dialogService))
                .ToObservableCollection<GameVM>();

            KeyBinding = _performer.HotKey.ToString();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Получает или задаёт команду редактирования KeyBinding.
        /// </summary>
        public DelegateCommand EditKeyBindingCommand { get; set; }

        /// <summary>
        /// Получает строку соответсвующему текущему Hotkey у объекта PerformService.
        /// </summary>
        public string KeyBinding 
        { 
            get => keyBinding;
            set
            {
                keyBinding = value;
                RaisePropertyChanged(nameof(KeyBinding));
            }
        }

        /// <summary>
        /// Получает или задаёт List of games.
        /// </summary>
        public ObservableCollection<GameVM> Games
        {
            get => _games;
            set
            {
                _games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }
        #endregion
    }

    public class GameVM : BindableBase
    {
        #region Private variables
        private readonly IDialogService _dialogService;
        private Game _game;
        private string _icon;
        private string _name;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an instance of <see cref="GameVM"/>.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="dialogService"></param>
        public GameVM(Game game, IDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException(nameof(dialogService));
            if (game == null) throw new ArgumentNullException(nameof(game));

            _dialogService = dialogService;
            _game = game;

            LoadData();
            LoadCommands();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Загржует данные.
        /// </summary>
        private void LoadData()
        {
            Icon = _game.IconPath;
            Name = _game.Name;
        }

        /// <summary>
        /// Загржует команды.
        /// </summary>
        private void LoadCommands()
        {
            GameDetailCommand = new DelegateCommand(GameDetail);
        }

        /// <summary>
        /// Посылает сообщение Game и открывает окно с этим объектом.
        /// </summary>
        private void GameDetail()
        {
            Messenger.Default.Send<Game>(_game);

            _dialogService.ShowGameDialog();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Задаёт или получает пусть к иконке Game.
        /// </summary>
        public string Icon 
        { 
            get => _icon;
            set
            {
                _icon = value;
                RaisePropertyChanged(nameof(Icon));
            }
        }

        /// <summary>
        /// Задаёт или получает назание Game.
        /// </summary>
        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Задаёт или получает команду GameDetailCommand.
        /// </summary>
        public DelegateCommand GameDetailCommand { get; set; }
        #endregion
    }
}
