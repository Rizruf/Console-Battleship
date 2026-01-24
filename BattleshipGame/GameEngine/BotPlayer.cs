using BattleshipGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.GameEngine
{
    internal class BotPlayer(string name = "Bot") : Player(name)
    {
        private readonly Random _random = new Random();

        public override Coordinate Shot()
        {
            int x = _random.Next(0, 10);
            int y = _random.Next(0, 10);

            System.Threading.Thread.Sleep(1000);

            return new Coordinate(x, y);
        }
    }
}
