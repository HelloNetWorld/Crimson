using System.Collections.Generic;

namespace Crimson.Model
{
    public class RustGame : Game
    {
        public override string IconPath => "pack://application:,,,/Resources/RustIcon_2.png";

        public override string Name =>"Макросы";

        public override IEnumerable<Weapon> Macros => RustWeapons.GetWeapons();
    }
}
