using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Sockets;

namespace Crimson.Models
{
    /// <summary>
    /// Представляет данные сдвига для Раста.
    /// </summary>
    public class RustShiftProvider : IShiftProvider, IRustShiftProvider
    {
        #region Static

        #region Points

        private static List<(double, double)> AK47Points = new List<(double X, double Y)> {
            (0.000000, -2.257792),
            (0.323242, -2.300758),
            (0.649593, -2.299759),
            (0.848786, -2.259034),
            (1.075408, -2.323947),

            (1.268491, -2.215956),
            (1.330963, -2.236556),
            (1.336833, -2.218203),
            (1.505516, -2.143454),
            (1.504423, -2.233091),

            (1.442116, -2.270194),
            (1.478543, -2.204318),
            (1.392874, -2.165817),
            (1.480824, -2.177887),
            (1.597069, -2.270915),

            (1.449996, -2.145893),
            (1.369179, -2.270450),
            (1.582363, -2.298334),
            (1.516872, -2.235066),
            (1.498249, -2.238401),

            (1.465769, -2.331642),
            (1.564812, -2.242621),
            (1.517519, -2.303052),
            (1.422433, -2.211946),
            (1.553195, -2.248043),

            (1.510463, -2.285327),
            (1.553878, -2.240047),
            (1.520380, -2.221839),
            (1.553878, -2.240047),
            (1.553195, -2.248043) };
        private static List<(double, double)> LR300Points = new List<(double X, double Y)> {
            (0.000000, -2.052616),
            (0.055584, -1.897695),
            (-0.247226, -1.863222),
            (-0.243871, -1.940010),
            (0.095727, -1.966751),

            (0.107707, -1.885520),
            (0.324888, -1.946722),
            (-0.181137, -1.880342),
            (0.162399, -1.820107),
            (-0.292076, -1.994940),

            (0.064575, -1.837156),
            (-0.126699, -1.887880),
            (-0.090568, -1.832799),
            (0.065338, -1.807480),
            (-0.197343, -1.705888),

            (-0.216561, -1.785949),
            (0.042567, -1.806371),
            (-0.065534, -1.757623),
            (0.086380, -1.904010),
            (-0.097326, -1.969296),

            (-0.213034, -1.850288),
            (-0.017790, -1.730867),
            (-0.045577, -1.783686),
            (-0.053309, -1.886260),
            (0.055072, -1.793076),

            (-0.091874, -1.921906),
            (-0.033719, -1.796160),
            (0.266464, -1.993952),
            (0.079090, -1.921165) };
        private static List<(double, double)> M249Points = new List<(double X, double Y)> { (0, -1.49), (0.39375, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.720, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900), (0.0, -1.4900) };
        private static List<(double, double)> HMLMGPoints = new List<(double X, double Y)> { (0, -1.4), (-0.39, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4), (-0.73, -1.4) };
        private static List<(double, double)> MP5Points = new List<(double X, double Y)> { (0.125361, -1.052446), (-0.099548, -0.931548), (0.027825, -0.954094), (-0.013715, -0.851504), (-0.007947, -1.070579), (0.096096, -1.018017), (-0.045937, -0.794216), (0.034316, -1.112618), (-0.003968, -0.930040), (-0.009403, -0.888503), (0.140813, -0.970807), (-0.015052, -1.046551), (0.095699, -0.860475), (-0.269643, -1.038896), (0.000285, -0.840478), (0.018413, -1.038126), (0.099191, -0.851701), (0.199659, -0.893041), (-0.082660, -1.069278), (0.006826, -0.881493), (0.091709, -1.150956), (-0.108677, -0.965513), (0.169612, -1.099499), (-0.038244, -1.120084), (-0.085513, -0.876956), (0.136279, -1.047589), (0.196392, -1.039977), (-0.152513, -1.209291), (-0.214510, -0.956648), (0.034276, -0.095177) };
        private static List<(double, double)> ThompsonPoints = new List<(double X, double Y)> { (-0.114413, -0.680635), (0.008686, -0.676598), (0.010312, -0.682837), (0.064825, -0.691345), (0.104075, -0.655618), (-0.088118, -0.660429), (0.089906, -0.675183), (0.037071, -0.632623), (0.178465, -0.634737), (0.034654, -0.669443), (-0.082658, -0.664826), (0.025550, -0.636631), (0.082414, -0.647118), (-0.123305, -0.662104), (0.028164, -0.662354), (-0.117346, -0.693475), (-0.268777, -0.661123), (-0.053086, -0.677493), (0.04238, -0.647038), (0.04238, -0.647038) };
        private static List<(double, double)> CustomPoints = new List<(double X, double Y)> { (-0.114414, -0.680635), (0.008685, -0.676597), (0.010312, -0.682837), (0.064825, -0.691344), (0.104075, -0.655617), (-0.088118, -0.660429), (0.089906, -0.675183), (0.037071, -0.632623), (0.178466, -0.634737), (0.034653, -0.669444), (-0.082658, -0.664827), (0.025551, -0.636631), (0.082413, -0.647118), (-0.123305, -0.662104), (0.028164, -0.662354), (-0.117345, -0.693474), (-0.268777, -0.661122), (-0.053086, -0.677493), (0.004238, -0.647037), (0.014169, -0.551440), (-0.009907, -0.552079), (0.044076, -0.577694), (-0.043187, -0.549581) };
        private static List<(double, double)> SemiPoints = new List<(double X, double Y)> { (0, -1.4) };
        private static List<(double, double)> PythonPoints = new List<(double X, double Y)> { (0, -5.8) };

        #endregion

        #region Weapon delays

        private static double AK47Delay = 133.33;
        private static double LR300Delay = 120.0;
        private static double M249Delay = 100.0;
        private static double HMLMGDelay = 100.0;
        private static double MP5Delay = 89.0;
        private static double ThompsonDelay = 113.0;
        private static double CustomDelay = 90.0;
        private static double PythonDelay = 125.0;
        private static double SemiDelay = 175.0;

        #endregion

        #region Weapon modification data

        private static double Scope8x = 4.76;
        private static double ScopeHolo = 1.2;
        private static double ScopeHand = 0.8;
        private static double ScopeNone = 1.0;

        #endregion

        #endregion

        #region Fields

        //private double _sensivity = 1;
        //private double _fov = 90;
        private int _index = 0;

        #endregion

        #region ctor

        /// <summary>
        /// Создаёт новый объект <see cref="RustMacro"/>.
        /// </summary>
        public RustShiftProvider()
        {
            SelectedWeapon = RustWeapon.AK47;
            WeaponMod = RustWeaponMod.None;
            Sensitivity = 1.0;
            Fov = 90;
            IsCrawling = false;
        }

        #endregion

        #region Properties

        public RustWeapon SelectedWeapon { get; set; }
        public RustWeaponMod WeaponMod { get; set; }

        // TODO: Добавить граничные значения для Sensivity и Fov.
        public double Sensitivity { get; set; }
        public int Fov { get; set; }
        public bool IsCrawling { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Возвращает следующее смещение для выбранного оружия.
        /// </summary>
        /// <returns></returns>
        public (double, double) GetNextShift()
        {
            AdjustIndex();

            var scopeKoeff = 0.0d;
            (double, double) shift;
            switch (SelectedWeapon)
            {
                case RustWeapon.AK47:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = AK47Points[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.LR300:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = LR300Points[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.M249:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = M249Points[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.HMLMG:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = HMLMGPoints[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.MP5:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = MP5Points[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.Thompson:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = ThompsonPoints[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.Custom:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = CustomPoints[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.Python:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = PythonPoints[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                case RustWeapon.Semi:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = SemiPoints[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
                default:
                    switch (WeaponMod)
                    {
                        case RustWeaponMod.X8:
                            scopeKoeff = Scope8x;
                            break;
                        case RustWeaponMod.Holo:
                            scopeKoeff = ScopeHolo;
                            break;
                        case RustWeaponMod.Hand:
                            scopeKoeff = ScopeHand;
                            break;
                        default:
                        case RustWeaponMod.None:
                            scopeKoeff = ScopeNone;
                            break;
                    }
                    shift = AK47Points[_index];
                    _index++;
                    return (CalculateShift(shift.Item1, scopeKoeff), CalculateShift(shift.Item2, scopeKoeff));
            }


        }

        /// <summary>
        /// Сбрасывает внутренний индекс следующего смещения.
        /// </summary>
        public void Reset()
        {
            _index = 0;
        }

        /// <summary>
        /// Возвращает задержку между выстрелами для текущего оружия.
        /// </summary>
        /// <returns></returns>
        public double GetDelay()
        {
            switch (SelectedWeapon)
            {
                case RustWeapon.LR300:
                    return LR300Delay;
                case RustWeapon.M249:
                    return M249Delay;
                case RustWeapon.HMLMG:
                    return HMLMGDelay;
                case RustWeapon.MP5:
                    return MP5Delay;
                case RustWeapon.Thompson:
                    return ThompsonDelay;
                case RustWeapon.Custom:
                    return CustomDelay;
                case RustWeapon.Python:
                    return PythonDelay;
                case RustWeapon.Semi:
                    return SemiDelay;
                default:
                case RustWeapon.AK47:
                    return AK47Delay;
            }
        }

        #endregion

        #region Private

        private void AdjustIndex()
        {
            if (_index < 0)
                _index = 0;

            switch (SelectedWeapon)
            {
                case RustWeapon.AK47:
                    if (_index >= AK47Points.Count)
                        _index = 0;
                    break;
                case RustWeapon.LR300:
                    if (_index >= LR300Points.Count)
                        _index = 0;
                    break;
                case RustWeapon.M249:
                    if (_index >= M249Points.Count)
                        _index = 0;
                    break;
                case RustWeapon.HMLMG:
                    if (_index >= HMLMGPoints.Count)
                        _index = 0;
                    break;
                case RustWeapon.MP5:
                    if (_index >= MP5Points.Count)
                        _index = 0;
                    break;
                case RustWeapon.Thompson:
                    if (_index >= ThompsonPoints.Count)
                        _index = 0;
                    break;
                case RustWeapon.Custom:
                    if (_index >= CustomPoints.Count)
                        _index = 0;
                    break;
                case RustWeapon.Python:
                    if (_index >= PythonPoints.Count)
                        _index = 0;
                    break;
                case RustWeapon.Semi:
                    if (_index >= SemiPoints.Count)
                        _index = 0;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Возвращает смещение после расчёта всех факторов.
        /// </summary>
        /// <param name="baseShift"></param>
        /// <param name="scopeKoef"></param>
        /// <param name=""></param>
        /// <returns></returns>
        private double CalculateShift(double baseShift, double scopeKoef)
        {
            return (baseShift * scopeKoef) / (-0.03 * Sensitivity * (IsCrawling ? 1.0 : 2.0) * 3.0 * (Fov / 100.0));
        }

        #endregion
    }
}

public enum RustWeapon
{
    AK47,
    LR300,
    M249,
    HMLMG, 
    MP5,
    Thompson, 
    Custom, 
    Python, 
    Semi
}

public enum RustWeaponMod
{
    None,
    Hand, 
    Holo, 
    X8,
}