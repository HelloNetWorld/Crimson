using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Models
{
    public class Macro
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Scope> Scopes { get; set; }

        /// <summary>
        /// Инструкции во время ходьбы. Важно что бы количество данных инструкций было одинаковым с <see cref="InstructionsCrawling"/>.
        /// </summary>
        public List<IInstruction> Instructions { get; set; }

        /// <summary>
        /// Инструкции во время приседа. Важно что бы количество данных инструкций было одинаковым с <see cref="Instructions"/>.
        /// </summary>
        public List<IInstruction> InstructionsCrawling { get; set; }

        public List<IInstruction> InstructionsSingleFire { get; set; }
    }
}
