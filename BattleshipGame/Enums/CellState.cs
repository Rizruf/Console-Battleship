using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Enums
{
    public enum CellState
    {
        Empty,      // Вода
        Ship,       // Корабль (невидимый для врага)
        Miss,       // Промах
        Hit,        // Попадание (ранен)
        Sunk        // Убит (весь корабль уничтожен)
    }
}
