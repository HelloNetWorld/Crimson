using Crimson.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crimson.Services
{
    public class DialogService : IDialogService
    {
        // Window coffeeDetailView = null;
        private Window _addKeyBindingWindow;

        public DialogService()
        {

        }

        public void ShowGameDialog()
        {
            _addKeyBindingWindow = new AddKeyBinding();
            _addKeyBindingWindow.ShowDialog();
        }

        public void CloseGameDialog()
        {
            _addKeyBindingWindow?.Close();
        }
    }
}
