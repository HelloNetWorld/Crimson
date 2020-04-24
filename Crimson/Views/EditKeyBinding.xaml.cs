using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crimson.Views
{
    /// <summary>
    /// Логика взаимодействия для AddKeyBinding.xaml
    /// </summary>
    public partial class EditKeyBinding : MetroWindow
    {
        public EditKeyBinding()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tbCurrentKey.Focus();
        }
    }
}
