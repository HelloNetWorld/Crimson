using Prism.Mvvm;
using System.Collections.Generic;

namespace Crimson.Model
{
    public abstract class Game : BindableBase
    {
        public abstract string IconPath { get; }
        public abstract string Name { get; }
        public abstract IEnumerable<Weapon> Macros { get; }
    }
}
