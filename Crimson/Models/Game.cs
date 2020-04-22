using Crimson.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.Model
{
    public abstract class Game : BindableBase
    {
        public abstract string IconPath { get; }
        public abstract string Name { get; }
        public abstract IEnumerable<Weapon> Macros { get; }
    }
}
