using System.Collections.Generic;

namespace Crimson.Model
{
    internal static class RustWeapons
    {
        // Заметка: Продумать вопрос: 
        // надо ли давать пользователю возможность менять смещения?
        // Сейчас разрешено.
        private static IEnumerable<Weapon> _instance;
        internal static IEnumerable<Weapon> GetWeapons()
        {
            // Реализация синглтона для IEnumerable<Weapon>.
            if (_instance == null)
                _instance =  new Weapon[]
                {
                    Assault(),
                    Tomphson(),
                    SMG(),
                    LR300(),
                    MP5A4(),
                    P250(),
                    Python(),
                    M249(),
                    M39(),
                    M92(),
                    Revolver(),
                    SemiAutoRifle(),
                    NailGun(),
                    M249WithX8()
                };
            return _instance;
        }
        #region Weapon Init methods
        private static Weapon Assault()=>
            new Weapon()
            {
                Name = "AK Assault Rifle",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[146]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(  0,  0, 52),
                        new CordsShift(- 6,  9, 26),
                        new CordsShift(- 6,  9, 26),
                        new CordsShift(- 6,  9, 26),
                        new CordsShift(- 6,  8, 26),
                        new CordsShift(- 6,  8, 26),
                        new CordsShift(  3,  4, 26),
                        new CordsShift(  3,  4, 26),
                        new CordsShift(  3,  4, 26),
                        new CordsShift(  3,  4, 26),
                        // 10
                        new CordsShift( 2,  4, 26),
                        new CordsShift( -9, 4, 26),
                        new CordsShift( -9, 4, 26),
                        new CordsShift( -9, 4, 26),
                        new CordsShift( -8, 4, 26),
                        new CordsShift( -8, 4, 26),
                        new CordsShift( -5, 6, 26),
                        new CordsShift( -5, 6, 26),
                        new CordsShift( -5, 6, 26),
                        new CordsShift( -5, 6, 26),
                        // 20
                        new CordsShift( -6, 7, 26),
                        new CordsShift( 3,  1, 27),
                        new CordsShift( 3,  1, 27),
                        new CordsShift( 3,  2, 27),
                        new CordsShift( 4,  2, 27),
                        new CordsShift( 4,  2, 27),
                        new CordsShift( -1, 6, 27),
                        new CordsShift( -1, 6, 27),
                        new CordsShift( -1, 6, 27),
                        new CordsShift( -1, 6, 27),
                        // 30
                        new CordsShift( 0,  7, 27),
                        new CordsShift( 4,  1, 27),
                        new CordsShift( 4,  1, 27),
                        new CordsShift( 4,  1, 27),
                        new CordsShift( 4,  1, 27),
                        new CordsShift( 5,  2, 27),
                        new CordsShift( 5,  2, 27),
                        new CordsShift( 5,  2, 27),
                        new CordsShift( 5,  2, 27),
                        new CordsShift( 5,  2, 27),
                        // 40
                        new CordsShift( 4,  3, 27),
                        new CordsShift( 7,  2, 27),
                        new CordsShift( 7,  2, 27),
                        new CordsShift( 7,  2, 27),
                        new CordsShift( 6,  2, 27),
                        new CordsShift( 6,  1, 27),
                        new CordsShift( 6,  1, 27),
                        new CordsShift( 6,  1, 27),
                        new CordsShift( 5,  1, 27),
                        new CordsShift( 5,  1, 27),
                        //50
                        new CordsShift( 5,  2, 27),
                        new CordsShift( 5,  0, 27),
                        new CordsShift( 5,  0, 27),
                        new CordsShift( 5,  0, 27),
                        new CordsShift( 5,  0, 27),
                        new CordsShift( 5,  0, 27),
                        new CordsShift( 0,  5, 27),
                        new CordsShift( 0,  5, 27),
                        new CordsShift( 0,  5, 27),
                        new CordsShift( 0,  5, 27),
                        // 60
                        new CordsShift( 0,  5, 27),
                        new CordsShift( 3,  3, 27),
                        new CordsShift( 3,  3, 27),
                        new CordsShift( 3,  3, 27),
                        new CordsShift( 3,  3, 27),
                        new CordsShift( 4,  3, 27),
                        new CordsShift( 2,  3, 27),
                        new CordsShift( 2,  3, 27),
                        new CordsShift( 2,  3, 27),
                        new CordsShift( 2,  3, 27),
                        // 70
                        new CordsShift( 2,  3, 27),
                        new CordsShift( -5, 4, 27),
                        new CordsShift( -5, 4, 27),
                        new CordsShift( -4, 3, 27),
                        new CordsShift( -4, 3, 27),
                        new CordsShift( -4, 3, 27),
                        new CordsShift( -4, 5, 27),
                        new CordsShift( -4, 5, 27),
                        new CordsShift( -4, 4, 27),
                        new CordsShift( -3, 4, 27),
                        // 80
                        new CordsShift( -3, 4, 27),
                        new CordsShift( -5, 4, 27),
                        new CordsShift( -5, 4, 27),
                        new CordsShift( -5, 4, 27),
                        new CordsShift( -5, 3, 27),
                        new CordsShift( -4, 3, 27),
                        new CordsShift( -7, 5, 27),
                        new CordsShift( -7, 5, 27),
                        new CordsShift( -7, 5, 27),
                        new CordsShift( -7, 5, 27),
                        // 90
                        new CordsShift( -7, 5, 27),
                        new CordsShift( -3, 2, 27),
                        new CordsShift( -3, 2, 27),
                        new CordsShift( -3, 2, 27),
                        new CordsShift( -2, 1, 27),
                        new CordsShift( -2, 1, 27),
                        new CordsShift( -7, 1, 27),
                        new CordsShift( -7, 1, 27),
                        new CordsShift( -7, 0, 27),
                        new CordsShift( -7, 0, 27),
                        // 100
                        new CordsShift(-7, 0, 27),
                        new CordsShift(-6, 2, 27),
                        new CordsShift(-6, 2, 27),
                        new CordsShift(-6, 2, 27),
                        new CordsShift(-6, 2, 27),
                        new CordsShift(-6, 2, 27),
                        new CordsShift(-2, 0, 27),
                        new CordsShift(-2, 0, 27),
                        new CordsShift(-2, 0, 27),
                        new CordsShift(-3, 0, 27),
                        // 110
                        new CordsShift(-3, 0, 27),
                        new CordsShift(-5, 4, 27),
                        new CordsShift(-5, 4, 27),
                        new CordsShift(-5, 4, 27),
                        new CordsShift(-5, 4, 27),
                        new CordsShift(-4, 5, 27),
                        new CordsShift(1, 2, 27),
                        new CordsShift(1, 2, 27),
                        new CordsShift(1, 1, 27),
                        new CordsShift(0, 1, 27),
                        // 120
                        new CordsShift(0, 1, 27),
                        new CordsShift(3, 3, 27),
                        new CordsShift(3, 3, 27),
                        new CordsShift(3, 2, 27),
                        new CordsShift(3, 2, 27),
                        new CordsShift(3, 2, 27),
                        new CordsShift(5, 4, 27),
                        new CordsShift(5, 4, 27),
                        new CordsShift(5, 4, 27),
                        new CordsShift(5, 4, 27),
                        // 130
                        new CordsShift(5, 4, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 3, 27),
                        new CordsShift(6, 4, 27),
                        new CordsShift(6, 4, 27),
                        // 140
                        new CordsShift(6, 4, 27),
                        new CordsShift(6, 1, 27),
                        new CordsShift(6, 1, 27),
                        new CordsShift(6, 1, 27),
                        new CordsShift(6, 1, 27),
                        new CordsShift(6, 1, 27)
                        // 146
                        #endregion
                    }
                }
            };
        private static Weapon Tomphson() =>
            new Weapon()
            {
                Name = "Tomphson",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[96]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0, 44 ),
                        new CordsShift(-3, 4, 25),
                        new CordsShift(-3, 4, 25),
                        new CordsShift(-3, 5, 25),
                        new CordsShift(-3, 5, 25),
                        new CordsShift(-4, 5, 25),
                        new CordsShift(0, 3, 25 ),
                        new CordsShift(0, 3, 25 ),
                        new CordsShift(0, 3, 25 ),
                        new CordsShift(-1, 3, 25),
                        // 10
                        new CordsShift(-1, 3, 25),
                        new CordsShift(0, 5, 25 ),
                        new CordsShift(0, 5, 25 ),
                        new CordsShift(0, 5, 25 ),
                        new CordsShift(0, 5, 25 ),
                        new CordsShift(0, 5, 25 ),
                        new CordsShift(3, 3, 25 ),
                        new CordsShift(3, 3, 25 ),
                        new CordsShift(3, 3, 25 ),
                        new CordsShift(3, 3, 25 ),
                        // 20
                        new CordsShift(3, 3, 25  ),
                        new CordsShift(0, 3, 26  ),
                        new CordsShift(0, 3, 26  ),
                        new CordsShift(-1, 3, 26 ),
                        new CordsShift(-1, 3, 26 ),
                        new CordsShift(-1, 4, 26 ),
                        new CordsShift(2, 2, 26  ),
                        new CordsShift(2, 2, 26  ),
                        new CordsShift(3, 2, 26  ),
                        new CordsShift(3, 3, 26  ),
                        // 30
                        new CordsShift(3, 3, 26  ),
                        new CordsShift(1, 0, 26  ),
                        new CordsShift(1, 0, 26  ),
                        new CordsShift(1, 1, 26  ),
                        new CordsShift(2, 1, 26  ),
                        new CordsShift(2, 1, 26  ),
                        new CordsShift(-2, 3, 27 ),
                        new CordsShift(-2, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        // 40
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-1, 3, 27 ),
                        new CordsShift(-1, 3, 27 ),
                        new CordsShift(-1, 3, 27 ),
                        new CordsShift(-1, 3, 27 ),
                        new CordsShift(-1, 3, 27 ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        //50
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        new CordsShift(-4, 3, 27 ),
                        new CordsShift(1, 0, 27  ),
                        new CordsShift(1, 0, 27  ),
                        new CordsShift(1, 0, 27  ),
                        new CordsShift(1, 1, 27  ),
                        // 60
                        new CordsShift(1, 1, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(0, 0, 27  ),
                        new CordsShift(4, 2, 27  ),
                        new CordsShift(4, 2, 27  ),
                        new CordsShift(4, 2, 27  ),
                        new CordsShift(4, 2, 27  ),
                        // 70
                        new CordsShift(5, 3, 27  ),
                        new CordsShift(-1, 0, 27 ),
                        new CordsShift(-1, 0, 27 ),
                        new CordsShift(-1, 0, 27 ),
                        new CordsShift(-2, 0, 27 ),
                        new CordsShift(-2, -1, 27),
                        new CordsShift(0, 2, 27  ),
                        new CordsShift(0, 2, 27  ),
                        new CordsShift(0, 2, 27  ),
                        new CordsShift(0, 2, 27  ),
                        // 80
                        new CordsShift(1, 2, 27  ),
                        new CordsShift(1, -1, 27 ),
                        new CordsShift(2, -2, 27 ),
                        new CordsShift(2, -2, 27 ),
                        new CordsShift(2, -2, 27 ),
                        new CordsShift(2, -2, 27 ),
                        new CordsShift(-2, 3, 27 ),
                        new CordsShift(-2, 3, 27 ),
                        new CordsShift(-2, 3, 27 ),
                        new CordsShift(-3, 3, 27 ),
                        // 90
                        new CordsShift(-3, 3, 27),
                        new CordsShift(0, 0, 27 ),
                        new CordsShift(0, 0, 27 ),
                        new CordsShift(0, 0, 27 ),
                        new CordsShift(0, 0, 27 ),
                        new CordsShift(0, 0, 27 ),
                        // 96
                        #endregion
                    }
                }
            };
        private static Weapon SMG() =>
             new Weapon()
            {
                Name = "Custom SMG",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[70]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0, 50  ),
                        new CordsShift(-2, 6, 33 ),
                        new CordsShift(-2, 6, 33 ),
                        new CordsShift(-2, 6, 33 ),
                        new CordsShift(-3, 7, 33 ),
                        new CordsShift(-2, 7, 33 ),
                        new CordsShift(-2, 6, 33 ),
                        new CordsShift(2, 4, 33  ),
                        new CordsShift(2, 4, 33  ),
                        new CordsShift(1, 5, 33  ),
                        // 10
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 5, 33  ),
                        new CordsShift(2, 2, 33  ),
                        new CordsShift(2, 2, 33  ),
                        new CordsShift(1, 2, 33  ),
                        new CordsShift(3, 6, 33  ),
                        // 20
                        new CordsShift(2, 5, 33   ),
                        new CordsShift(2, 5, 33   ),
                        new CordsShift(1, 3, 33   ),
                        new CordsShift(0, 2, 33   ),
                        new CordsShift(0, 2, 33   ),
                        new CordsShift(-2, 1, 33  ),
                        new CordsShift(-3, 2, 33  ),
                        new CordsShift(-1, 2, 33  ),
                        new CordsShift(-2, 3, 33  ),
                        new CordsShift(-2, 3, 33  ),
                        // 30
                        new CordsShift(-2, 3, 33  ),
                        new CordsShift(-2, 5, 33  ),
                        new CordsShift(-2, 5, 33  ),
                        new CordsShift(-2, 5, 33  ),
                        new CordsShift(-1, 0, 33  ),
                        new CordsShift(-1, -1, 33 ),
                        new CordsShift(-1, 0, 33  ),
                        new CordsShift(-1, -1, 33 ),
                        new CordsShift(-1, -1, 33 ),
                        new CordsShift(-1, -1, 33 ),
                        // 40
                        new CordsShift(-2, 8, 33  ),
                        new CordsShift(-1, 4, 33  ),
                        new CordsShift(-1, 4, 33  ),
                        new CordsShift(5, 4, 33   ),
                        new CordsShift(5, 4, 33   ),
                        new CordsShift(4, 2, 33   ),
                        new CordsShift(1, 0, 33   ),
                        new CordsShift(1, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(-1, 0, 33  ),
                        //50
                        new CordsShift(-1, 0, 33  ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(6, 4, 33   ),
                        new CordsShift(5, 4, 33   ),
                        new CordsShift(4, 4, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        // 60
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(-2, 2, 33  ),
                        new CordsShift(-2, 2, 33  ),
                        new CordsShift(-2, 2, 33  ),
                        new CordsShift(-2, 1, 33  ),
                        new CordsShift(-2, 1, 33  ),
                        new CordsShift(-2, 1, 33  ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        new CordsShift(0, 0, 33   ),
                        // 70
                        #endregion
                    }
                }
            };
        private static Weapon LR300() =>
            new Weapon()
            {
                Name = "LR300 Assault Rifle",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[146]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0, 44 ),
                        new CordsShift(0, 4, 22 ),
                        new CordsShift(0, 4, 22 ),
                        new CordsShift(0, 4, 22 ),
                        new CordsShift(0, 5, 22 ),
                        new CordsShift(0, 5, 22 ),
                        new CordsShift(-1, 3, 22),
                        new CordsShift(-1, 3, 22),
                        new CordsShift(-1, 4, 22),
                        new CordsShift(-2, 4, 22),
                        // 10
                        new CordsShift(-2, 4, 22),
                        new CordsShift(0, 4, 23 ),
                        new CordsShift(0, 4, 23 ),
                        new CordsShift(0, 4, 23 ),
                        new CordsShift(0, 4, 23 ),
                        new CordsShift(-1, 4, 23),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(-3, 4, 24),
                        new CordsShift(-3, 4, 24),
                        new CordsShift(-3, 4, 24),
                        // 20
                        new CordsShift(-3, 4, 24),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(-3, 3, 24),
                        new CordsShift(0, 2, 24 ),
                        new CordsShift(0, 2, 24 ),
                        new CordsShift(0, 3, 24 ),
                        new CordsShift(0, 3, 24 ),
                        // 30
                        new CordsShift(0, 3, 24 ),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(-3, 2, 24),
                        new CordsShift(-3, 2, 24),
                        new CordsShift(1, 0, 24 ),
                        new CordsShift(1, 0, 24 ),
                        new CordsShift(2, 0, 24 ),
                        new CordsShift(2, 1, 24 ),
                        // 40
                        new CordsShift(2, 1, 24 ),
                        new CordsShift(0, 4, 24 ),
                        new CordsShift(0, 4, 24 ),
                        new CordsShift(0, 4, 24 ),
                        new CordsShift(0, 4, 24 ),
                        new CordsShift(0, 5, 24 ),
                        new CordsShift(3, 0, 24 ),
                        new CordsShift(4, 0, 24 ),
                        new CordsShift(4, 0, 24 ),
                        new CordsShift(4, 0, 24 ),
                        //50
                        new CordsShift(4, 0, 24 ),
                        new CordsShift(1, 0, 24 ),
                        new CordsShift(1, 0, 24 ),
                        new CordsShift(2, 0, 24 ),
                        new CordsShift(2, 1, 24 ),
                        new CordsShift(2, 1, 24 ),
                        new CordsShift(2, 0, 24 ),
                        new CordsShift(2, 0, 24 ),
                        new CordsShift(2, 0, 24 ),
                        new CordsShift(2, -1, 24),
                        // 60
                        new CordsShift(3, -1, 24),
                        new CordsShift(-1, 2, 24),
                        new CordsShift(-1, 2, 24),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(-2, 2, 24),
                        new CordsShift(2, 2, 24 ),
                        new CordsShift(3, 2, 24 ),
                        new CordsShift(3, 2, 24 ),
                        new CordsShift(3, 2, 24 ),
                        // 70
                        new CordsShift(3, 2, 24  ),
                        new CordsShift(-1, -1, 24),
                        new CordsShift(-1, -1, 24),
                        new CordsShift(-1, -1, 24),
                        new CordsShift(-1, -1, 24),
                        new CordsShift(-1, -2, 24),
                        new CordsShift(-2, 1, 24 ),
                        new CordsShift(-2, 1, 24 ),
                        new CordsShift(-2, 2, 24 ),
                        new CordsShift(-3, 2, 24 ),
                        // 80
                        new CordsShift(-3, 2, 24 ),
                        new CordsShift(-1, -1, 24),
                        new CordsShift(-1, -2, 24),
                        new CordsShift(-1, -2, 24),
                        new CordsShift(-2, -2, 24),
                        new CordsShift(-2, -2, 24),
                        new CordsShift(0, 2, 24  ),
                        new CordsShift(0, 3, 24  ),
                        new CordsShift(0, 3, 24  ),
                        new CordsShift(0, 3, 24  ),
                        // 90
                        new CordsShift(-1, 3, 24 ),
                        new CordsShift(-3, 0, 24 ),
                        new CordsShift(-3, 0, 24 ),
                        new CordsShift(-3, 0, 24 ),
                        new CordsShift(-3, 0, 24 ),
                        new CordsShift(-4, 0, 24 ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        // 100
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(-4, 0, 24 ),
                        new CordsShift(-4, 0, 24 ),
                        new CordsShift(-4, 0, 24 ),
                        new CordsShift(-4, 0, 24 ),
                        new CordsShift(-5, 0, 24 ),
                        new CordsShift(0, 1, 24  ),
                        new CordsShift(0, 1, 24  ),
                        new CordsShift(-1, 1, 24 ),
                        new CordsShift(-1, 1, 24 ),
                        // 110
                        new CordsShift(-1, 2, 24 ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(-2, 1, 24 ),
                        new CordsShift(-2, 1, 24 ),
                        new CordsShift(-2, 1, 24 ),
                        new CordsShift(-3, 2, 24 ),
                        // 120
                        new CordsShift(-3, 2, 24 ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(0, 0, 24  ),
                        new CordsShift(2, -1, 24 ),
                        new CordsShift(2, -1, 24 ),
                        new CordsShift(2, -1, 24 ),
                        new CordsShift(3, -1, 24 ),
                        // 130
                        new CordsShift(3, -2, 24 ),
                        new CordsShift(4, 0, 24  ),
                        new CordsShift(4, 1, 24  ),
                        new CordsShift(4, 1, 24  ),
                        new CordsShift(4, 1, 24  ),
                        new CordsShift(4, 1, 24  ),
                        new CordsShift(4, 0, 24  ),
                        new CordsShift(4, 0, 24  ),
                        new CordsShift(4, 0, 24  ),
                        new CordsShift(5, 0, 24  ),
                        // 140
                        new CordsShift(5, 0, 24  ),
                        new CordsShift(3, 2, 24  ),
                        new CordsShift(3, 2, 24  ),
                        new CordsShift(4, 2, 24  ),
                        new CordsShift(4, 2, 24  ),
                        new CordsShift(4, 3, 24  )
                        // 146
                        #endregion
                    }
                }
            };
        private static Weapon MP5A4() =>
            new Weapon()
            {
                Name = "MP5A4",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[146]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0, 42  ),
                        new CordsShift(0, 3, 21  ),
                        new CordsShift(0, 4, 21  ),
                        new CordsShift(0, 4, 21  ),
                        new CordsShift(0, 4, 21  ),
                        new CordsShift(-1, 4, 21 ),
                        new CordsShift(0, 3, 21  ),
                        new CordsShift(0, 4, 21  ),
                        new CordsShift(0, 4, 21  ),
                        new CordsShift(-1, 4, 21 ),
                        // 10          
                        new CordsShift(-1, 4, 21 ),
                        new CordsShift(1, 4, 21  ),
                        new CordsShift(1, 4, 21  ),
                        new CordsShift(1, 4, 21  ),
                        new CordsShift(1, 4, 21  ),
                        new CordsShift(1, 5, 21  ),
                        new CordsShift(3, 4, 21  ),
                        new CordsShift(3, 4, 21  ),
                        new CordsShift(3, 5, 21  ),
                        new CordsShift(3, 5, 21  ),
                        // 20          
                        new CordsShift(3, 5, 21  ),
                        new CordsShift(4, 2, 21  ),
                        new CordsShift(4, 2, 21  ),
                        new CordsShift(5, 3, 21  ),
                        new CordsShift(5, 3, 21  ),
                        new CordsShift(5, 3, 21  ),
                        new CordsShift(2, 2, 21  ),
                        new CordsShift(3, 2, 21  ),
                        new CordsShift(3, 2, 21  ),
                        new CordsShift(3, 3, 21  ),
                        // 30          
                        new CordsShift(3, 3, 21  ),
                        new CordsShift(0, 2, 21  ),
                        new CordsShift(0, 2, 21  ),
                        new CordsShift(0, 2, 21  ),
                        new CordsShift(0, 3, 21  ),
                        new CordsShift(0, 3, 21  ),
                        new CordsShift(2, 0, 21  ),
                        new CordsShift(2, 0, 21  ),
                        new CordsShift(3, 0, 21  ),
                        new CordsShift(3, 0, 21  ),
                        // 40          
                        new CordsShift(3, 0, 21  ),
                        new CordsShift(-7, 0, 21 ),
                        new CordsShift(-7, 0, 21 ),
                        new CordsShift(-7, 0, 21 ),
                        new CordsShift(-7, 0, 21 ),
                        new CordsShift(-7, 0, 21 ),
                        new CordsShift(0, 0, 21  ),
                        new CordsShift(0, 0, 21  ),
                        new CordsShift(0, 0, 21  ),
                        new CordsShift(0, 0, 21  ),
                        //50           
                        new CordsShift(0, 0, 21  ),
                        new CordsShift(-2, 3, 21 ),
                        new CordsShift(-2, 4, 21 ),
                        new CordsShift(-2, 4, 21 ),
                        new CordsShift(-2, 4, 21 ),
                        new CordsShift(-2, 4, 21 ),
                        new CordsShift(-2, 1, 21 ),
                        new CordsShift(-2, 1, 21 ),
                        new CordsShift(-3, 1, 21 ),
                        new CordsShift(-3, 1, 21 ),
                        // 60          
                        new CordsShift(-3, 1, 21 ),
                        new CordsShift(5, -1, 20 ),
                        new CordsShift(5, -1, 20 ),
                        new CordsShift(6, -2, 20 ),
                        new CordsShift(6, -2, 20 ),
                        new CordsShift(6, -2, 20 ),
                        new CordsShift(3, 1, 20  ),
                        new CordsShift(3, 1, 20  ),
                        new CordsShift(3, 1, 20  ),
                        new CordsShift(4, 2, 20  ),
                        // 70
                        new CordsShift(4, 2, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(-2, 1, 20 ),
                        new CordsShift(-3, 1, 20 ),
                        new CordsShift(-3, 1, 20 ),
                        new CordsShift(-3, 2, 20 ),
                        // 80
                        new CordsShift(-3, 2, 20 ),
                        new CordsShift(4, 0, 20  ),
                        new CordsShift(5, 0, 20  ),
                        new CordsShift(5, 0, 20  ),
                        new CordsShift(5, 0, 20  ),
                        new CordsShift(5, -1, 20 ),
                        new CordsShift(3, -1, 20 ),
                        new CordsShift(4, -1, 20 ),
                        new CordsShift(4, -2, 20 ),
                        new CordsShift(4, -2, 20 ),
                        // 90
                        new CordsShift(4, -2, 20 ),
                        new CordsShift(-5, 1, 20 ),
                        new CordsShift(-5, 1, 20 ),
                        new CordsShift(-5, 1, 20 ),
                        new CordsShift(-5, 1, 20 ),
                        new CordsShift(-6, 2, 20 ),
                        new CordsShift(1, 1, 20  ),
                        new CordsShift(2, 1, 20  ),
                        new CordsShift(2, 2, 20  ),
                        new CordsShift(2, 2, 20  ),
                        // 100
                        new CordsShift(2, 2, 20  ),
                        new CordsShift(-2, 0, 20 ),
                        new CordsShift(-3, -1, 20),
                        new CordsShift(-3, -1, 20),
                        new CordsShift(-3, -1, 20),
                        new CordsShift(-3, -1, 20),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        // 110
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(-1, 0, 20 ),
                        new CordsShift(-1, 0, 20 ),
                        new CordsShift(-1, 0, 20 ),
                        new CordsShift(-1, 0, 20 ),
                        // 120
                        new CordsShift(-1, 0, 20 ),
                        new CordsShift(-6, 0, 20 ),
                        new CordsShift(-6, 0, 20 ),
                        new CordsShift(-6, 0, 20 ),
                        new CordsShift(-6, 0, 20 ),
                        new CordsShift(-6, 0, 20 ),
                        new CordsShift(2, 0, 20  ),
                        new CordsShift(3, 0, 20  ),
                        new CordsShift(3, -1, 20 ),
                        new CordsShift(3, -1, 20 ),
                        // 130
                        new CordsShift(3, -1, 20 ),
                        new CordsShift(-3, 0, 20 ),
                        new CordsShift(-3, 0, 20 ),
                        new CordsShift(-4, 0, 20 ),
                        new CordsShift(-4, 0, 20 ),
                        new CordsShift(-4, 0, 20 ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        // 140
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  ),
                        new CordsShift(0, 0, 20  )
                        // 146
                        #endregion
                    }
                }
            };
        private static Weapon P250() =>
            new Weapon()
            {
                Name = "P250 Semi-automatic pistol",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0, 0 ),
                        new CordsShift(0, 7, 23 ),
                        new CordsShift(0, 7, 23 ),
                        new CordsShift(0, 7, 23 )
                        #endregion
                    }
                }
            };
        private static Weapon Python() => 
            new Weapon()
            {
                Name = "Python Revolver",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0,  0,  0),
                        new CordsShift(0, 12, 25),
                        new CordsShift(0, 12, 25),
                        new CordsShift(0, 12, 25)
                        #endregion
                    }
                }
            };
        private static Weapon M249()
        {
            CordsShift[] m249Shifts = new CordsShift[300];

            #region Инициализация смещениями и задержкой
            for (int index = 0; index < 90; index += 3)
            {
                m249Shifts[index]     = new CordsShift(0, 8, 43);
                m249Shifts[index + 1] = new CordsShift(0, 7, 43);
                m249Shifts[index + 2] = new CordsShift(0, 7, 43);
            }
            for (int index = 90; index < 150; index += 3)
            {
                m249Shifts[index]     = new CordsShift(0, 9, 43);
                m249Shifts[index + 1] = new CordsShift(0, 7, 43);
                m249Shifts[index + 2] = new CordsShift(0, 7, 43);
            }
            for (int index = 150; index < 210; index += 3)
            {
                m249Shifts[index]     = new CordsShift(0, 8, 43);
                m249Shifts[index + 1] = new CordsShift(0, 7, 43);
                m249Shifts[index + 2] = new CordsShift(0, 7, 43);
            }
            for (int index = 210; index < m249Shifts.Length; index += 3)
            {
                m249Shifts[index]     = new CordsShift(0, 9, 43);
                m249Shifts[index + 1] = new CordsShift(0, 7, 43);
                m249Shifts[index + 2] = new CordsShift(0, 7, 43);
            }
            #endregion

            return new Weapon()
            {
                Name = "M249 machine gun",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = m249Shifts
                }
            };
        }
        private static Weapon M39() =>
            new Weapon()
            {
                Name = "M39 Rifle",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[5]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 2, 12),
                        new CordsShift(0, 2, 12),
                        new CordsShift(0, 2, 12),
                        new CordsShift(0, 3, 12),
                        new CordsShift(0, 3, 12)
                        #endregion
                    }
                }
            };
        private static Weapon M92() =>
            new Weapon()
            {
                Name = "M92 Pistol",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0,  0),
                        new CordsShift(0, 7, 30),
                        new CordsShift(0, 7, 30),
                        new CordsShift(0, 6, 30)
                        #endregion
                    }
                }
            };
        private static Weapon Revolver() =>
            new Weapon()
            {
                Name = "Revolver",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0,  0),
                        new CordsShift(0, 4, 28),
                        new CordsShift(0, 3, 28),
                        new CordsShift(0, 4, 28)
                        #endregion
                    }
                }
            };
        private static Weapon SemiAutoRifle() =>
            new Weapon()
            {
                Name = "Semi-Automatic Rifle",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0,  0),
                        new CordsShift(0, 6, 6),
                        new CordsShift(0, 6, 6),
                        new CordsShift(0, 6, 6)
                        #endregion
                    }
                }
            };
        private static Weapon NailGun() =>
            new Weapon()
            {
                Name = "Nailgun",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = new CordsShift[4]
                    {
                        #region Инициализация смещениями и задержкой
                        // 0
                        new CordsShift(0, 0,  0),
                        new CordsShift(0, 5, 22),
                        new CordsShift(0, 5, 22),
                        new CordsShift(0, 5, 22)
                        #endregion
                    }
                }
            };
        private static Weapon M249WithX8()
        {
            CordsShift[] m249Shifts = new CordsShift[300];

            #region Инициализация смещениями и задержкой
            for (int index = 0; index < m249Shifts.Length; index += 3)
            {
                m249Shifts[index] = new CordsShift(0, 29, 43);
                m249Shifts[index + 1] = new CordsShift(0, 29, 43);
                m249Shifts[index + 2] = new CordsShift(0, 28, 43);
            }
            #endregion

            return new Weapon()
            {
                Name = "M249 With x8 scope",
                MacroInfoForWeapon = new MacroInfo()
                {
                    CordsShifts = m249Shifts
                }
            };
        }
        #endregion
    }
}
