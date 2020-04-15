using Crimson.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.ViewModels
{
    public class GameWindowVM : BindableBase
    {
        private readonly Game _game;
        private int _selectedWeaponIndex;
        private bool _isMacroEnabled;
        private readonly MacroManager _manager;

        public GameWindowVM(Game game, MacroManager manager)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            if (manager == null) throw new ArgumentNullException(nameof(manager));

            _game = game;
            _manager = manager;
            _manager.PerformEnable = true;
            LoadSelectedMacros();

            _game.PropertyChanged += Game_PropertyChanged;
            _manager.PropertyChanged += Manager_PropertyChanged;

            Weapons = new ObservableCollection<WeaponVM>(game.Macros.Select(w => new WeaponVM(w)));

        }

        private void Manager_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsMacroEnabled = _manager.PerformAllowByKey;
        }

        private void LoadSelectedMacros()
        {
            _manager.MacroInfo = _game?
                .Macros?
                .ElementAt(SelectedWeaponIndex)?
                .MacroInfoForWeapon;
        }

        private void Game_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            RaisePropertyChanged(nameof(Weapons));

        public ObservableCollection<WeaponVM> Weapons { get; set; }
        public int SelectedWeaponIndex
        {
            get => _selectedWeaponIndex;
            set
            {
                _selectedWeaponIndex = value;
                LoadSelectedMacros();
                RaisePropertyChanged(nameof(SelectedWeaponIndex));
            }
        }
        public DelegateCommand ClearWeapon { get; }
        public DelegateCommand SetHotKeys { get; }
        public bool IsMacroEnabled
        {
            get => _isMacroEnabled;
            set
            {
                _isMacroEnabled = value;
                RaisePropertyChanged(nameof(IsMacroEnabled));
            }
        }
        public DelegateCommand<object> ActivateMacros
        {
            get
            {
                return new DelegateCommand<object>((obj) =>
                {
                    bool isChecked = (bool)obj;
                    if (!isChecked)
                    {
                        _manager.PerformAllowByKey = false;
                    }
                    else
                    {
                        _manager.PerformAllowByKey = true;
                        LoadSelectedMacros();
                    }
                });
            }
        }

    }
    // Смотри WeaponVM в AddKeyBindingVM.cs.
    //public class WeaponVM
    //{
    //    public string Name { get; }
    //}
}
