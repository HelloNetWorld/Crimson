using Crimson.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crimson.Services;
using Crimson.Utility;
using Crimson.Extensions;

namespace Crimson.ViewModels
{
    public class GameWindowVM : BindableBase
    {
        #region Private variables
        private readonly PerformService _performer;
        private readonly IDialogService _dialogService;
        private Game _game;
        private int _selectedMacroIndex;
        private bool _isMacroEnabled;
        private ObservableCollection<Macro> macros;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an instance of <see cref="GameWindowVM"/>.
        /// </summary>
        /// <param name="performer"></param>
        /// <param name="dialogService"></param>
        public GameWindowVM(PerformService performer, IDialogService dialogService)
        {
            if (performer == null) throw new ArgumentNullException(nameof(performer));
            if (dialogService == null) throw new ArgumentNullException(nameof(dialogService));

            _performer = performer;
            _dialogService = dialogService;

            Messenger.Default.Register<Game>(this, OnGameReceived);

            _performer.PropertyChanged += Performer_PropertyChanged;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Загружает команды.
        /// </summary>
        private void LoadCommands()
        {
            ActivateMacros = new DelegateCommand<object>((obj) =>
            {
                bool isChecked = (bool)obj;
                if (!isChecked)
                {
                    _performer.PerformAllowByKey = false;
                }
                else
                {
                    _performer.PerformAllowByKey = true;
                    LoadMacrosAt(SelectedMacroIndex);
                }
            });

            ClearMacros = new DelegateCommand(() => { SelectedMacroIndex = 0; });
        }

        /// <summary>
        /// Загружает макросы.
        /// </summary>
        private void LoadData()
        {
            Macros = _game.Macros.ToObservableCollection();
        }

        /// <summary>
        /// Срабатывает когда было передано соответсвющее собщение(<see cref="Messenger.Send{T}(T)"/>).
        /// </summary>
        /// <param name="game"></param>
        private void OnGameReceived(Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            _performer.PerformEnable = true;
            _game = game;

            LoadData();
            LoadCommands();

            SelectedMacroIndex = 0;
        }

        /// <summary>
        /// Срабатывает когда изменилось свойство у PerformService.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Performer_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            IsMacroEnabled = _performer.PerformAllowByKey;

        /// <summary>
        /// Загружает соответсвующий макрос по индексу в List<Macro>.
        /// </summary>
        /// <param name="index"></param>
        private void LoadMacrosAt(int index)
        {
            if (index < 0 && index >= _game.Macros.Count)
                throw new IndexOutOfRangeException(nameof(index));

            _performer.Macro = _game?
                .Macros?
                .ElementAt(index);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Задаёт или получает коллекцию макросов.
        /// </summary>
        public ObservableCollection<Macro> Macros 
        { 
            get => macros;

            set
            {
                macros = value;
                RaisePropertyChanged(nameof(Macros));
            }
        }

        /// <summary>
        /// Задаёт или получает индекс выбранного макроса.
        /// </summary>
        public int SelectedMacroIndex
        {
            get => _selectedMacroIndex;
            set
            {
                _selectedMacroIndex = value;
                LoadMacrosAt(_selectedMacroIndex);
                RaisePropertyChanged(nameof(SelectedMacroIndex));
            }
        }

        /// <summary>
        /// Устанавливает или получает флаг включённого/отключённного 
        /// состояния макроса <see cref="PerformService.PerformAllowByKey" />.
        /// </summary>
        public bool IsMacroEnabled
        {
            get => _isMacroEnabled;
            set
            {
                _isMacroEnabled = value;
                RaisePropertyChanged(nameof(IsMacroEnabled));
            }
        }

        /// <summary>
        /// Задаёт или получает команду сброса выбранного макроса.
        /// </summary>
        public DelegateCommand ClearMacros { get; set; }

        /// <summary>
        /// Задаёт или получает команду включения макроса.
        /// </summary>
        public DelegateCommand<object> ActivateMacros { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Обработчик срабатывает во время закрытия окна.
        /// </summary>
        public void MetroWindow_Closing()
        {
            _performer.PerformAllowByKey = false;
            _performer.PerformEnable = false;
        }
        #endregion
    }
}
