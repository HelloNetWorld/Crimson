using gma.System.Windows;
using Prism.Mvvm;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;
using System.IO;
using Crimson.Models;
using System;
using System.Collections.Generic;

namespace Crimson.Services
{
    /// <summary>
    /// Этот класс связывает макрос(Macro) и его исполнение с помощью класса UserActivityHook.
    /// </summary>
    public class PerformService : BindableBase
    {
        #region Variables

        private readonly UserActivityHook _actHook;
        private bool _leftButtonPressed = false;
        private bool _crawlingKeyPressed = false;
        private Keys _hotKey = Keys.F12;
        private Keys _crawlingKey = Keys.LControlKey;
        private bool _performAllowByKey;
        private bool _longInstruction = true;

        #endregion

        #region User32.dll methods
        [DllImport("User32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        #endregion

        #region Constructors

        public PerformService()
        {
            _actHook = new UserActivityHook();

            _actHook.OnMouseUp += new MouseEventHandler(OnMouseUp);
            _actHook.OnMouseDown += new MouseEventHandler(OnMouseDown);
            _actHook.KeyDown += new KeyEventHandler(OnHotKeyDown);
            _actHook.KeyUp += new KeyEventHandler(OnHotKeyUp);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Возвращает или задаёт множитель перемещения курсора по Y.
        /// </summary>
        public double MultiplyerY { get; set; } = 1.00;

        /// <summary>
        /// Возвращает или задаёт макрос, выполненине которого будет по нажатию ЛКМ,
        /// если это разрешено свойствами PerformAllowByKey(нажатием на кнопку (HotKey) включения/отключения) и PerformEnable .
        /// </summary>
        public Macro Macro { get; set; }

        /// <summary>
        /// Возвращает или задаёт значение, указывающее, разрешено ли выполнять макрос, нажатием на кнопку (HotKey) включения/отключения.
        /// </summary>
        public bool PerformAllowByKey
        {
            get => _performAllowByKey;
            set
            {
                _performAllowByKey = value;
                RaisePropertyChanged(nameof(PerformAllowByKey));
            }
        }

        /// <summary>
        /// Возвращает или задает значение, указывающее, можно ли выполнять макрос.
        /// </summary>
        public bool PerformEnable { get; set; }

        /// <summary>
        /// Возвращает или задает ключ(Keys), который используется в качестве включения/отключения работы макроса (свойство PerformEnable).
        /// По умолчанию равен Keys.F12
        /// </summary>
        public Keys HotKey
        {
            get => _hotKey;
            set
            {
                _hotKey = value;
                RaisePropertyChanged(nameof(HotKey));
            }
        }

        /// <summary>
        /// Возвращает или задает ключ(Keys), который используется в качестве приседа/красться (свойство PerformEnable).
        /// По умолчанию равен Keys.LControlKey
        /// </summary>
        public Keys CrawlingKey
        {
            get => _crawlingKey;
            set
            {
                _crawlingKey = value;
                RaisePropertyChanged(nameof(CrawlingKey));
            }
        }

        /// <summary>
        /// Возвращает или задает какую инструкцию использовать (длинную или короткую).
        /// </summary>
        public bool LongInstruction 
        { 
            get => _longInstruction;
            set
            {
                if (value == false)
                {
                    if (Macro.InstructionsSingleFire == null)
                    {
                        throw new ArgumentException(nameof(_longInstruction));
                    }
                }
                else
                {
                    if (Macro.Instructions == null)
                    {
                        throw new ArgumentException(nameof(_longInstruction));
                    }
                }
                _longInstruction = value;
            }
        }

        #endregion

        #region Private Methods

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!_leftButtonPressed && e.Button == MouseButtons.Left && PerformAllowByKey)
            {
                _leftButtonPressed = true;
                // Выполняем задачу в другом потоке.
                PerformMacroAsync();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _leftButtonPressed = false;
        }

        private void OnHotKeyDown(object sender, KeyEventArgs e)
        {
            if (!PerformEnable)
            {
                return;
            }

            if (e.KeyCode == HotKey)
            {
                PerformAllowByKey = !PerformAllowByKey;
                if (PerformAllowByKey)
                {
                    PlayStartMusicAsync();
                }
                else
                {
                    PlayStopMusicAsync();
                }
            }

            if (e.KeyCode == CrawlingKey)
            {
                _crawlingKeyPressed = true;
            }
        }

        private void OnHotKeyUp(object sender, KeyEventArgs e)
        {
            if (!PerformEnable)
            {
                return;
            }

            if (e.KeyCode == CrawlingKey)
            {
                _crawlingKeyPressed = false;
            }
        }

        /// <summary>
        /// Выполняет макрось, заданный свойством MacroInfo асинхронно, вызывая mouse_event,
        /// путём смещения указателя мыши на dX и dY с задержкой.
        /// </summary>
        /// <param name="indexOfGame">Индекс игры в списке у пользователя(свойствао User.Games)</param>
        /// <param name="indexOfMacro">Индекс игры в списке у пользователя(свойствао User.Games)</param>
        private async Task PerformMacroAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                // Если не нажата ЛКМ и разрешено включать (активируется забинденной кнопкой на клавиатуре).
                if (!_leftButtonPressed && Macro == null && !PerformAllowByKey && !PerformEnable)
                    return;

                List<IInstruction> instructions;
                if (LongInstruction == true)
                {
                    instructions = Macro.Instructions;
                }
                else
                {
                    instructions = Macro.InstructionsSingleFire;
                }

                var hasCrawlingInstructions = Macro.InstructionsCrawling != null && Macro.InstructionsCrawling.Count == Macro.Instructions.Count;

                // Выполняем смещение указателя мыши до тех пор,
                // пока нажата левая кнопка мышки,
                // либо до конца массива смещений.
                for (int index = 0; index < instructions.Count; ++index)
                {
                    IInstruction currentInstruction = Macro.Instructions[index];

                    if (_crawlingKeyPressed && hasCrawlingInstructions)
                    {
                        currentInstruction = Macro.InstructionsCrawling[index];
                    }

                    switch (currentInstruction?.Type)
                    {
                        case (InstructionType.MouseShiftInstruction):
                            MouseShiftInstruction shift = currentInstruction as MouseShiftInstruction;
                            int dY = shift.DY;
                            if (MultiplyerY != 1.00)
                            {
                                dY = (int)Math.Round(MultiplyerY * dY);
                            }
                            mouse_event(1U, shift.DX, dY, 0U, 0);
                            break;

                        case (InstructionType.DelayInstruction):
                            DelayInstruction delay = currentInstruction as DelayInstruction;
                            Thread.Sleep(delay.Delay);
                            //Task.Delay(delay.Delay);
                            break;

                        case (InstructionType.ButtonInstruction):
                            ButtonInstruction button = currentInstruction as ButtonInstruction;
                            // TODO: пока не реализовано нажатие на клавишу клавиатуры.
                            break;

                        default:
                            // Вероятно нужна какая-то запись в лог о неизвестной инструкции.
                            break;

                    }

                    if (!_leftButtonPressed || index == Macro.Instructions.Count - 1 || !PerformAllowByKey || !PerformEnable)
                        break;
                }

            });
        }


        private async void PlayStartMusicAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var mediaPlayer = new MediaPlayer();
                var mp3filename = "\\Resources\\Sounds\\excellent.mp3";
                string mp3Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + mp3filename;
                mediaPlayer.Volume = 0.125;
                mediaPlayer.Open(new System.Uri(mp3Path, System.UriKind.Relative));
                mediaPlayer.Play();
                Thread.Sleep(1500);
                mediaPlayer.Close();
            });
        }

        private async void PlayStopMusicAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var mediaPlayer = new MediaPlayer();
                var mp3filename = "\\Resources\\Sounds\\denied.mp3";
                string mp3Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + mp3filename;
                mediaPlayer.Volume = 0.125;
                mediaPlayer.Open(new System.Uri(mp3Path, System.UriKind.Relative));
                mediaPlayer.Play();
                Thread.Sleep(1500);
                mediaPlayer.Close();
            });
        }
        #endregion
    }
}
