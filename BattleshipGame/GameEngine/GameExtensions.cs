using BattleshipGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.GameEngine
{
    public static class GameExtensions
    {
        public static void SetupFleetRandomly(this Board board)
        {
            Random rnd = new Random();

            int[] shipLengths = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            foreach (var length in shipLengths)
            {
                bool isPlaced = false;

                while (!isPlaced)
                {
                    int x = rnd.Next(0, 10);
                    int y = rnd.Next(0, 10);

                    bool isVertical = rnd.Next(0, 2) == 0;

                    Ship newShip = new Ship($"Ship_{length}", length);

                    isPlaced = board.PlaceShip(newShip, new Coordinate(x, y), isVertical);
                }
            }
        }
    }
}
