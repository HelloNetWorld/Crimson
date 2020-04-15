using Crimson.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.ViewModels
{
    public class KeyBindingsVM : BindableBase
    {
        public ObservableCollection<WeaponHotKeyVM> WeaponHotKeys { get; }
        public DelegateCommand SaveAndQuit { get; }
    }
    public class WeaponHotKeyVM : BindableBase
    {
        public string HotKey { get; }
        public ObservableCollection<WeaponVM> Weapons { get; }
        public DelegateCommand SetHotKey { get; }
    }
    public class WeaponVM : BindableBase
    {
        private readonly Weapon _weapon;
        public WeaponVM( Weapon weapon)
        {
            if (weapon != null)
                _weapon = weapon;
        }
        public string Name => _weapon.Name;
    }
}
