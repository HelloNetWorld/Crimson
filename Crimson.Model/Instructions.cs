using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crimson.Models
{
    /// <summary>
    /// Сдвиг указателя мышки относительно текущего положения на экране.
    /// </summary>
    public class MouseShiftInstruction : IInstruction
    {
        /// <summary>
        /// Инициализирует новый экземпляр MouseShiftInstruction-класс с нулевыми значениями.
        /// </summary>
        public MouseShiftInstruction()
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр MouseShiftInstruction-класс со смещением по X и Y.
        /// </summary>
        /// <param name="dx">Смещение по оси Х в px.</param>
        /// <param name="dy">Смещение по оси Y в px.</param>
        public MouseShiftInstruction(int dx, int dy)
        {
            DX = dx;
            DY = dy;
        }

        /// <summary>
        /// Смещение по оси Х в px.
        /// </summary>
        public int DX { get; set; }

        /// <summary>
        /// Смещение по оси Y в px.
        /// </summary>
        public int DY { get; set; }

        public InstructionType Type => InstructionType.MouseShiftInstruction;
    }

    /// <summary>
    /// Задержка.
    /// </summary>
    public class DelayInstruction : IInstruction
    {
        /// <summary>
        /// Инициализирует новый экземпляр DelayInstruction-класс с нулевыми значениями.
        /// </summary>
        public DelayInstruction()
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр DelayInstruction-класс выдержкой времени в мс.
        /// </summary>
        /// <param name="delay">Выдержка времени в мс.</param>
        public DelayInstruction(int delay)
        {
            if (delay < 0) throw new ArgumentOutOfRangeException(nameof(Delay));
            Delay = delay;
        }

        /// <summary>
        /// Задержка в мс.
        /// </summary>
        public int Delay { get; set; }

        public InstructionType Type => InstructionType.DelayInstruction;
    }

    /// <summary>
    /// Нажатие на клавишу клавиатуры.
    /// </summary>
    public class ButtonInstruction : IInstruction
    {
        /// <summary>
        /// Инициализирует новый экземпляр ButtonInstruction-класс с нулевым keyCode.
        /// </summary>
        public ButtonInstruction()
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр ButtonInstruction-класс с кодом кнопки.
        /// </summary>
        public ButtonInstruction(int keyCode)
        {
            KeyCode = keyCode;
        }

        /// <summary>
        /// Код кнопки которую необходимо нажать.
        /// </summary>
        public int KeyCode { get; set; }

        public InstructionType Type => InstructionType.ButtonInstruction;
    }
}