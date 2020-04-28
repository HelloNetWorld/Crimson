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
        public List<Scope> Scopes { get; set; }
        public List<IInstruction> Instructions { get; set; }
        public List<IInstruction> InstructionsSingleFire { get; set; }
    }
}
