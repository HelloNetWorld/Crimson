namespace Crimson.Models
{
    public interface IRustShiftProvider
    {
        int Fov { get; set; }
        bool IsCrawling { get; set; }
        RustWeapon SelectedWeapon { get; set; }
        double Sensitivity { get; set; }
        RustWeaponMod WeaponMod { get; set; }
    }
}