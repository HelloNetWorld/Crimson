using Crimson.Services;
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
using System.Configuration;

namespace Crimson.ViewModels
{
    public class EditKeyBindingVM : BindableBase
    {
        #region Private variables
        private readonly PerformService _performer;
        private string keyBinding;
        private readonly KeysConverter _keysConverter = new KeysConverter();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an instance of <see cref="EditKeyBindingVM"/>.
        /// </summary>
        /// <param name="performService"></param>
        public EditKeyBindingVM(PerformService performService)
        {
            if (performService == null) throw new ArgumentNullException(nameof(performService));

            _performer = performService;
            _performer.PerformEnable = false;

            _performer.HotKey = (Keys) _keysConverter.ConvertFromString(Properties.Settings.Default["HotKey"].ToString());

            KeyBinding = _performer.HotKey.ToString();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Возвращает или задает кнопку.
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
        #endregion

        #region Public Methods

        /// <summary>
        /// Преобразует нажатую кнопку (System.Windows.Input.KeyEventArgs.Key) в 
        /// System.Windows.Forms.Keys и устанавливает её в качестве Bind для 
        /// запуска макроса в PerformService.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetKeyBinding(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyBinding = e.Key.ToString();
            RaisePropertyChanged(nameof(KeyBinding));

            // KeyInterop for converting 'System.Windows.Input.Key' to 'System.Windows.Forms.Keys'.
            _performer.HotKey = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);

            // Saving to settings.
            Properties.Settings.Default["HotKey"] = (object)_performer.HotKey;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
