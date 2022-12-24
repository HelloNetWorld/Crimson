using Crimson.Models;
using Crimson.Services;
using Crimson.Utility;
using Crimson.Utility.Messages;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace Crimson.ViewModels
{
    public class CalculatorVM : BindableBase
    {
        #region Private variables

        private readonly IDialogService _dialogService;
        private string _text;
        private bool _isShown;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of <see cref="CalculatorVM"/>.
        /// </summary>
        /// <param name="dialogService"></param>
        public CalculatorVM(IDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException(nameof(dialogService));

            _dialogService = dialogService;
            _text = string.Empty;

            LoadData();
            LoadCommands();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Инициализирует данные.
        /// </summary>
        private void Initialize()
        {

        }

        /// <summary>
        /// Загржует данные.
        /// </summary>
        private void LoadData()
        {
            IsShown = true;
            Messenger.Default.Register<object>(this, (o) => TurnOff(), MessengerToken.AppClose);
        }

        /// <summary>
        /// Загржует команды.
        /// </summary>
        private void LoadCommands()
        {
            CalculateCommand = new DelegateCommand(Calculate);
            DeleteCommand = new DelegateCommand(Clear);
            ButtonClickCommand = new DelegateCommand<object>(ButtonClick);
            BackspaceCommand = new DelegateCommand(Backspace);
            TurnOffCommand = new DelegateCommand(TurnOff);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Calculate()
        {
            var text = Text.Trim();
            if (text == "0753")
            {
                Messenger.Default.Send<string>(text, MessengerToken.CodeValid);
                IsShown = false;
                _dialogService.ShowMainWindow();
            }

            try
            {
                CalculateInternal();
            }
            catch
            {
               Text = "Error!";
            }
        }

        /// <summary>
        /// Расчитывает ответ по введённым данным на дисплее калькулятора.
        /// </summary>
        private void CalculateInternal()
        {
            String op;
            int iOp = 0;
            if (Text.Contains("+"))
            {
                iOp = Text.IndexOf("+");
            }
            else if (Text.Contains("-"))
            {
                iOp = Text.IndexOf("-");
            }
            else if (Text.Contains("*"))
            {
                iOp = Text.IndexOf("*");
            }
            else if (Text.Contains("/"))
            {
                iOp = Text.IndexOf("/");
            }
            else
            {
                //error    
            }

            op = Text.Substring(iOp, 1);
            double op1 = Convert.ToDouble(Text.Substring(0, iOp));
            double op2 = Convert.ToDouble(Text.Substring(iOp + 1, Text.Length - iOp - 1));

            if (op == "+")
            {
                Text += "=" + (op1 + op2);
            }
            else if (op == "-")
            {
                Text += "=" + (op1 - op2);
            }
            else if (op == "*")
            {
                Text += "=" + (op1 * op2);
            }
            else
            {
                Text += "=" + (op1 / op2);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Clear()
        {
            Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        private void TurnOff()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Основное нажатие на клавишу, добавляет символ нажатой клавиши на клавиатуре калькулятора.
        /// </summary>
        private void ButtonClick(object parameter)
        {
            Text += parameter.ToString();
        }

        /// <summary>
        /// Удалить последний символ.
        /// </summary>
        private void Backspace()
        {
            if (Text.Length > 0)
            {
                Text = Text.Substring(0, Text.Length - 1);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Задаёт или получает текст калькулятора.
        /// </summary>
        public bool IsShown
        {
            get => _isShown;
            set
            {
                _isShown = value;
                RaisePropertyChanged(nameof(IsShown));
            }
        }

        /// <summary>
        /// Задаёт или получает текст калькулятора.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// Задаёт или получает команду CalculateCommand.
        /// </summary>
        public DelegateCommand CalculateCommand { get; set; }

        /// <summary>
        /// Задаёт или получает команду ButtonClickCommand.
        /// </summary>
        public DelegateCommand<object> ButtonClickCommand { get; set; }

        /// <summary>
        /// Задаёт или получает команду BackspaceCommand.
        /// </summary>
        public DelegateCommand BackspaceCommand { get; set; }

        /// <summary>
        /// Задаёт или получает команду DeleteCommand.
        /// </summary>
        public DelegateCommand DeleteCommand { get; set; }

        /// <summary>
        /// Задаёт или получает команду TurnOffCommand.
        /// </summary>
        public DelegateCommand TurnOffCommand { get; set; }

        #endregion
    }
}
