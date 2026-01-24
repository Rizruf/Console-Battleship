using BattleshipGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.GameEngine
{
    abstract class Player
    {
        public string Name { get; set; }
        public Board OwnBoard { get; set; }

        protected Player(string name)
        {
            Name = name;
            OwnBoard = new Board();
        }

        public abstract Coordinate Shot();
    }
}
