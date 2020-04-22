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
        public List<Instruction> Instructions { get; set; }
    }
}
