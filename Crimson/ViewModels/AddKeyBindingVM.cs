using Crimson.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Crimson.ViewModels
{
    public class AddKeyBindingVM : BindableBase
    {
        public AddKeyBindingVM()
        {
            if (Manager != null)
            {
                Manager.PerformEnable = false;
            }
        }
        public string ActivasionKey
        {
            get;set;
        }

        public void SetActivasionKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ActivasionKey = e.Key.ToString();
            RaisePropertyChanged(nameof(ActivasionKey));
            // Converting 'System.Windows.Input.Key' to 'System.Windows.Forms.Keys'.
            // Сразу установка в Модель, если будет напрягать, можно будет перенести в отдельный метод для кнопки OK.
            Manager.HotKey = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
        }

        public MacroManager Manager { get; set; } = null;
    }
}
