using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Services
{
    public interface IDialogService
    {
        void CloseGameDialog();
        void ShowGameDialog();
        void ShowEditKeyDialog();
        void CloseEditKeyDialog();
    }
}
