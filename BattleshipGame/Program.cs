using BattleshipGame.Entities;
using BattleshipGame.GameEngine;
using BattleshipGame.UI;

namespace BattleshipGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            HumanPlayer me = new HumanPlayer(Console.ReadLine());
            BotPlayer bot = new BotPlayer();

            me.OwnBoard.SetupFleetRandomly();
            bot.OwnBoard.SetupFleetRandomly();

            while (true)
            {
                Console.Clear();

                Console.WriteLine($"--- ТВОЕ ПОЛЕ ({me.Name}) ---");
                ConsoleView.DrawBoards(me.OwnBoard, hideShips: false);

                Console.WriteLine();

                
                Console.WriteLine("--- ПОЛЕ ВРАГА ---");
                ConsoleView.DrawBoards(bot.OwnBoard, hideShips: true);

                
                Coordinate shot = me.Shot();
                var result = bot.OwnBoard.Fire(shot);

               
                if (bot.OwnBoard.IsLost())
                {
                    Console.Clear();
                    Console.WriteLine("ПОБЕДА! Вражеский флот уничтожен!");
                    break;
                }

                
                Console.WriteLine($"Ты: {result}. Нажми Enter...");
                Console.ReadLine();

                
                Console.WriteLine("Ход Бота...");
                Coordinate botShot = bot.Shot();
                var botResult = me.OwnBoard.Fire(botShot);

                
                if (me.OwnBoard.IsLost())
                {
                    Console.Clear();
                    Console.WriteLine("ПОРАЖЕНИЕ! Твой флот пошел на дно.");
                    break;
                }

                Console.WriteLine($"Бот бил в {botShot.X},{botShot.Y}: {botResult}. Enter...");
                Console.ReadLine();
            }
        }
    }

}
