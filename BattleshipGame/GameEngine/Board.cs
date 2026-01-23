using BattleshipGame.Entities;
using BattleshipGame.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.GameEngine
{
    public class Board
    {
        public CellState[,] Map { get; set; } = new CellState[10, 10];

        public List<Ship> Fleet { get; set; } = new List<Ship>();

        public void ResetBoard()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = CellState.Empty;
                }
            }
        }

        public Board()
        {
            ResetBoard();
        }

        public CellState Fire(Coordinate coordinate)
        {
            if (coordinate.X > 9 || coordinate.Y > 9 || coordinate.X < 0 || coordinate.Y < 0)
            {
                throw new Exception("Координаты за пределами поля!");
            }

            if (Map[coordinate.X, coordinate.Y] != CellState.Empty
                && Map[coordinate.X, coordinate.Y] != CellState.Ship)
            {
                return Map[coordinate.X, coordinate.Y];
            }

            if (Map[coordinate.X, coordinate.Y] != CellState.Empty
                && Map[coordinate.X, coordinate.Y] == CellState.Ship)
            {
                foreach (var ship in Fleet)
                {
                    if (ship.GotHit(coordinate))
                    {
                        CellState newState = ship.IsSunk() ? CellState.Sunk : CellState.Hit;

                        Map[coordinate.X, coordinate.Y] = newState;
                        return newState;
                    }
                }
            }

            Map[coordinate.X, coordinate.Y] = CellState.Miss;
            return CellState.Miss;
        }

        public bool PlaceShip (Ship ship, Coordinate start, bool isVertical)
        {
            List <Coordinate> tempCords = new List <Coordinate>();

            for (int i = 0; i < ship.Length; i++)
            {
                int currentX = start.X;
                int currentY = start.Y;

                if (isVertical) currentY = currentY + i;
                else currentX = currentX + i;

                tempCords.Add(new Coordinate (currentX, currentY));
            }

            foreach (Coordinate coordinate in tempCords)
            {
                if (coordinate.X > 9 || coordinate.Y > 9 || coordinate.X < 0 || coordinate.Y < 0)
                {
                    return false;
                }

                if (Map[coordinate.X, coordinate.Y] !=  CellState.Empty)
                {
                    return false;
                }

                
            }

            foreach (Coordinate coordinate in tempCords)
            {
                Map[coordinate.X, coordinate.Y] = CellState.Ship;

                ship.Сoordinates.Add(coordinate);
            }

            Fleet.Add(ship);

            return true;
        }
    }
}
