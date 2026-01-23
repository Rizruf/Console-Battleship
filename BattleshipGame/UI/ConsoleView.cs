using BattleshipGame.Entities;
using BattleshipGame.Enums;
using BattleshipGame.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.UI
{
    internal static class ConsoleView
    {
        public static void DrawBoard(Board board)
        {
            Console.Write("   ");
            Console.WriteLine("A B C D E F G H I J");

            for (int y = 0; y < 10; y++)
            {
                if (y < 9) Console.Write($" {y + 1} ");
                else Console.Write($"{y + 1} ");

                for (int x = 0; x < 10; x++)
                {
                    CellState currentCell = board.Map[x, y];

                    switch (currentCell)
                    {
                        case CellState.Empty:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("~ ");
                            break;
                        case CellState.Ship:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("O ");
                            break;
                        case CellState.Miss:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("x ");
                            break;
                        case CellState.Hit:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Ж ");
                            break;
                        case CellState.Sunk:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("W ");
                            break;
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
