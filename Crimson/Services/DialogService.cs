using Crimson.Views;
using System.Windows;

namespace Crimson.Services
{
    public class DialogService : IDialogService
    {
        private Window _mainWindow;
        private Window _editKeyBindingWindow;
        private Window _gameDetail;

        public void ShowMainWindow()
        {
            _mainWindow = new MainWindow();
            _mainWindow.ShowDialog();
        }

        public void CloseMainWindow()
        {
            Application.Current.Shutdown();
            _mainWindow.Close();
        }

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
