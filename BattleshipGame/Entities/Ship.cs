using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Entities
{
    public class Ship
    {
        public string Name {get;}
        public int Length { get;}
        public int Hit { get; private set; }

        public List <Coordinate> coordinates { get; set; } = new List <Coordinate> ();

        public Ship(string name, int lengthShip)
        {
            Name = name;
            Length = lengthShip;
        }

        public bool GotHit(Coordinate shot)
        {
            foreach (Coordinate position in coordinates)
            {
                if (shot.X == position.X && shot.Y == position.Y)
                {
                    Hit++;
                    return true;
                }
            }
            return false;
        }

        public bool IsSunk()
        {
            if (Hit >= Length)
            {
                return true;
            }
            return false;
        }

    }
}
