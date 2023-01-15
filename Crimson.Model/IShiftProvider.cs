namespace Crimson.Models
{
    public interface IShiftProvider
    {
        double GetDelay();
        (double, double) GetNextShift();
        void Reset();
    }
}