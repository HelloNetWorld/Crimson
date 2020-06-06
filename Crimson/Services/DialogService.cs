using Crimson.Views;
using System.Windows;

namespace Crimson.Services
{
    public class DialogService : IDialogService
    {
        private Window _editKeyBindingWindow;
        private Window _gameDetail;

        public void ShowGameDialog()
        {
            _gameDetail = new GameWindow();
            _gameDetail.ShowDialog();
        }

        public void CloseGameDialog()
        {
            _gameDetail.Close();
        }

        public void ShowEditKeyDialog()
        {
            _editKeyBindingWindow = new EditKeyBinding();
            _editKeyBindingWindow.ShowDialog();
        }

        public void CloseEditKeyDialog()
        {
            _editKeyBindingWindow?.Close();
        }
    }
}
