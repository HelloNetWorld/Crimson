using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Models
{
    /// <summary>
    /// Инстукция.
    /// </summary>
    public interface IInstruction
    {
        InstructionType Type { get; }
    }
}
