using Crimson.Models;
using System.Collections.Generic;

namespace Crimson.Models
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Путь к иконке.
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// Макросы.
        /// </summary>
        public List<Macro> Macros { get; set; }
        /// <summary>
        /// Флаг указывающий разрешено ли удалять данный Item из Repository.
        /// </summary>
        public bool Removable { get; set; }
    }
}
