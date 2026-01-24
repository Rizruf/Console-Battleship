using BattleshipGame.Entities;
using BattleshipGame.GameEngine;
using BattleshipGame.UI;

namespace BattleshipGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BotPlayer bot = new BotPlayer();

            Console.Write("Введите имя - ");

            HumanPlayer human = new HumanPlayer(Console.ReadLine());

            human.OwnBoard.PlaceShip(new Ship("MyShip", 3), new Coordinate(0, 0), true);

            bot.OwnBoard.PlaceShip(new Ship("BotShip", 3), new Coordinate(9, 2), true);

            while (true)
            {
                Console.Clear();

                Console.WriteLine("--- КАРТА БОТА (Стреляй сюда) ---");
                ConsoleView.DrawBoard(bot.OwnBoard);

   
                Coordinate shot = human.Shot();


                var result = bot.OwnBoard.Fire(shot);
                Console.WriteLine($"Ты выстрелил в {shot.X},{shot.Y}. Результат: {result}");

                Console.WriteLine("Нажми Enter для хода бота...");
                Console.ReadLine();


                Console.WriteLine("--- БОТ АТАКУЕТ ---");
                Coordinate botShot = bot.Shot();
                var botResult = human.OwnBoard.Fire(botShot);

                Console.WriteLine($"Бот выстрелил в {botShot.X},{botShot.Y}. Результат: {botResult}");
                Console.WriteLine("Нажми Enter...");
                Console.ReadLine();
            }
        }
    }
}
