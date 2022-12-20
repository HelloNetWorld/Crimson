namespace Crimson.Services
{
    public interface IDialogService
    {
        void ShowMainWindow();
        void CloseMainWindow();
        void ShowGameDialog();
        void CloseGameDialog();
        void ShowEditKeyDialog();
        void CloseEditKeyDialog();
    }
}
