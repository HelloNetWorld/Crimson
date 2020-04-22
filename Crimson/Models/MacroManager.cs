using gma.System.Windows;
using Prism.Mvvm;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;
using System.IO;

namespace Crimson.Model
{
    /// <summary>
    /// Этот класс получает у игры(IGame) макросы(MacroInfo) 
    /// и запустить их с помощью класса UserActivityHook.
    /// </summary>
    public class MacroManager : BindableBase
    {
        private readonly UserActivityHook _actHook;
        private bool _leftButtonPressed = false;
        private Keys _hotKey = Keys.F12;
        private bool _performAllowByKey;

        public User User { get; } = new User();

        [DllImport("User32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        public MacroManager()
        {
            _actHook = new UserActivityHook();

            _actHook.OnMouseUp += new MouseEventHandler(OnMouseUp);
            _actHook.OnMouseDown += new MouseEventHandler(OnMouseDown);
            _actHook.KeyDown += new KeyEventHandler(OnHotKeyDown);
        }

        private void OnHotKeyDown(object sender, KeyEventArgs e)
        {
            if (PerformEnable && e.KeyCode == HotKey)
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
                // TODO: Сделать mediaPlayer.Close(); - что бы высвободить ресурсы.
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
                string mp3Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + mp3filename;
                mediaPlayer.Volume = 0.125;
                mediaPlayer.Open(new System.Uri(mp3Path, System.UriKind.Relative));
                mediaPlayer.Play();
                // TODO: Сделать mediaPlayer.Close(); - что бы высвободить ресурсы.
                Thread.Sleep(1500);
                mediaPlayer.Close();
            });
        }
        /// <summary>
        /// Возвращает или задаёт макрос, выполненине которого будет по нажатию ЛКМ,
        /// если это разрешено свойствами PerformAllowByKey(нажатием на кнопку (HotKey) включения/отключения) и PerformEnable .
        /// </summary>
        public MacroInfo MacroInfo { get; set; }
        /// <summary>
        /// Возвращает или задаёт значение, указывающее, разрешено ли выполнять макрос, нажатием на кнопку (HotKey) включения/отключения.
        /// </summary>
        internal bool PerformAllowByKey
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
        internal bool PerformEnable { get; set; }
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

        /// <summary>
        /// Выполняет макрось, заданный свойством MacroInfo асинхронно, вызывая mouse_event,
        /// путём смещения указателя мыши на dX и dY с задержкой.
        /// </summary>
        /// <param name="indexOfGame">Индекс игры в списке у пользователя(свойствао User.Games)</param>
        /// <param name="indexOfMacro">Индекс игры в списке у пользователя(свойствао User.Games)</param>
        private async void PerformMacroAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                // Если не нажата ЛКМ и разрешено включать (активируется забинденной кнопкой на клавиатуре).
                if (!_leftButtonPressed && MacroInfo == null && !PerformAllowByKey && !PerformEnable)
                    return;

                // Выполняем смещение указателя мыши до тех пор,
                // пока нажата левая кнопка мышки,
                // либо до конца массива смещений.
                for (int index = 0; index < MacroInfo.CordsShifts.Length; ++index)
                {
                    mouse_event(1U, MacroInfo.CordsShifts[index].DX, MacroInfo.CordsShifts[index].DY, 0U, 0);
                    Thread.Sleep(MacroInfo.CordsShifts[index].Delay);
                    if (!_leftButtonPressed || index == MacroInfo.CordsShifts.Length - 1 || !PerformAllowByKey || !PerformEnable)
                        break;
                }
            });
        }
    }
}
