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

        public bool PlaceShip(Ship ship, Coordinate start, bool isVertical)
        {
            List<Coordinate> tempCoords = new List<Coordinate>();


            for (int i = 0; i < ship.Length; i++)
            {
                int x = start.X;
                int y = start.Y;

                if (isVertical) y += i;
                else x += i;

                tempCoords.Add(new Coordinate(x, y));
            }


            foreach (var coord in tempCoords)
            {

                if (coord.X < 0 || coord.X > 9 || coord.Y < 0 || coord.Y > 9)
                    return false;

                if (!IsSpaceFree(coord.X, coord.Y))
                    return false;
            }

            foreach (var coord in tempCoords)
            {
                Map[coord.X, coord.Y] = CellState.Ship;
                ship.Сoordinates.Add(coord);
            }

            Fleet.Add(ship);
            return true;
        }

        private bool IsSpaceFree(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        if (Map[i, j] == CellState.Ship)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool IsLost()
        {
            return Fleet.All(s => s.IsSunk());
        }
    }
}
