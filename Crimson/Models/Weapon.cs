namespace Crimson.Model
{



    public class Weapon
    {
        public string Name { get; set; }
        public MacroInfo MacroInfoForWeapon { get;set; }
    }
    public class MacroInfo
    {
        public CordsShift[] CordsShifts { get; set; }
    }
    public class CordsShift
    {
        private int _delay;

        public CordsShift(int dX, int dY, int delay)
        {
            _delay = 0;
            DX = dX;
            DY = dY;
            Delay = delay;
        }
        public int DX { get; set; }
        public int DY { get; set; }
        public int Delay
        {
            get => _delay;
            set
            {
                if (value >= 0)
                    _delay = value;
            }
        }
    }
}
