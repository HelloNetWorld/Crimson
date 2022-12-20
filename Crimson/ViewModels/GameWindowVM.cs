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
using System.Windows;

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
        private ObservableCollection<Macro> _macros;
        private ObservableCollection<Scope> _scopes;
        private int _selectedScopeIndex;
        private bool _autoChecked;

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
        /// Загружает данные.
        /// </summary>
        private void LoadData()
        {
            if (_game != null)
            {
                Macros = _game.Macros.ToObservableCollection();
                SelectedMacroIndex = 0;
            }
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
            if (_macros != null && _game != null && index >= 0 && index < _game.Macros.Count)
            {
                // if (index < 0 || index >= _game.Macros.Count)
                //     throw new IndexOutOfRangeException(nameof(index));

                _performer.Macro = _game
                    .Macros
                    .ElementAt(index);
            }
        }

        /// <summary>
        /// Загружает соответсвующий прицел по индексу в List<Macro>.
        /// </summary>
        /// <param name="index"></param>
        private void LoadScopeAt(int index)
        {
            if (_scopes != null)
            {
                if (index < 0 && index >= _scopes.Count)
                    throw new IndexOutOfRangeException(nameof(index));

                _performer.MultiplyerY = _scopes.ElementAt(index).Multiplier;
            }
        }

        /// <summary>
        /// Загружает коллекцию Scopes для выбранного индекса макроса из массва Macros.
        /// </summary>
        /// <param name="index">Индекс в массиве макросов.(_macros)</param>
        private void LoadScopesFor(int index)
        {
            if (_macros != null && _game != null)
            {
                if (index < 0 && index >= _game.Macros.Count)
                    throw new IndexOutOfRangeException(nameof(index));

                Scopes = _macros.ElementAt(index).Scopes?.ToObservableCollection();

                if (_scopes != null)
                    SelectedScopeIndex = 0;
            }
        }
        #endregion

        #region Public properties

        /// <summary>
        /// Задаёт и получает видимость элементов управления связанных с прицелами (Scopes).
        /// </summary>
        public Visibility ScopeVisibility
            => _game.Macros.ElementAt(SelectedMacroIndex).Scopes == null ?
            Visibility.Hidden : Visibility.Visible;

        /// <summary>
        /// Задаёт и получает видимость элементов управления связанных режимами стрельбы.
        /// </summary>
        public Visibility ShootingModeVisibility
            => _game.Macros.ElementAt(SelectedMacroIndex).InstructionsSingleFire == null ?
            Visibility.Hidden : Visibility.Visible;

        /// <summary>
        /// Получает первую вставку текста в textBlock (Инструкция к настройкам игры).
        /// </summary>
        public string FirstComment => _game.Commentary.Any() ? _game.Commentary[0] ?? String.Empty : String.Empty;

        /// <summary>
        /// Получает вторую вставку текста в textBlock (Инструкция к настройкам игры).
        /// </summary>
        public string SecondComment => _game.Commentary.Length > 1 ? _game.Commentary[1] ?? String.Empty : String.Empty;

        /// <summary>
        /// Получает третью вставку текста в textBlock (Инструкция к настройкам игры).
        /// </summary>
        public string ThirdComment => _game.Commentary.Length > 2 ? _game.Commentary[2] ?? String.Empty : String.Empty;

        /// <summary>
        /// Задаёт или получает коллекцию с прицелами у выбранного макроса.
        /// </summary>
        public ObservableCollection<Scope> Scopes
        {
            get => _scopes;
            set
            {
                _scopes = value;
                RaisePropertyChanged(nameof(Scopes));
            }
        }

        /// <summary>
        /// Задаёт или получает индекс выбранного прицела(Scopes).
        /// </summary>
        public int SelectedScopeIndex
        {
            get => _selectedScopeIndex;
            set
            {
                _selectedScopeIndex = value;
                LoadScopeAt(_selectedScopeIndex);
                RaisePropertyChanged(nameof(SelectedScopeIndex));
            }
        }

        public bool AutoChecked
        {
            get => _autoChecked;
            set
            {
                _autoChecked = value;
                _performer.LongInstruction = _autoChecked;
                RaisePropertyChanged(nameof(AutoChecked));
            }
        }

        /// <summary>
        /// Задаёт или получает коллекцию макросов.
        /// </summary>
        public ObservableCollection<Macro> Macros
        {
            get => _macros;
            set
            {
                _macros = value;
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
                LoadScopesFor(_selectedMacroIndex);
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
