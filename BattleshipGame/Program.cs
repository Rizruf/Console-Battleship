using BattleshipGame.Entities;
using BattleshipGame.GameEngine;
using BattleshipGame.UI;

namespace BattleshipGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board myBoard = new Board();

            Ship destroyer = new Ship("Destroyer", 2);

            myBoard.PlaceShip(destroyer, new Coordinate(1, 0), true);

            Console.WriteLine("Стреляем в A1...");
            myBoard.Fire(new Coordinate(0, 0));

            Console.WriteLine("Стреляем в B1...");
            myBoard.Fire(new Coordinate(1, 0));

            Console.WriteLine("Стреляем в B2...");
            myBoard.Fire(new Coordinate(1, 1));

            Console.Clear(); 
            ConsoleView.DrawBoard(myBoard);

            Console.ReadLine();
        }
    }
}
