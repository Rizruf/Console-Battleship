using BattleshipGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.GameEngine
{
    internal class HumanPlayer (string name): Player (name)
    {
        private readonly char[] _letter = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        public override Coordinate Shot()
        {
            Console.WriteLine($"{Name}, твой ход!");
            int x = -1;
            int y = -1;

            while (true) 
            {
                Console.Write("Буква (A-J): ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input)) continue;

                char letter = input[0];
                int index = Array.IndexOf(_letter, letter);

                if (index != -1)
                {
                    x = index; 
                    break;     
                }

                Console.WriteLine("Неверная буква! Давай по новой.");
            }

            while (true)
            {
                Console.Write("Цифра (1-10): ");

                if (int.TryParse(Console.ReadLine(), out int result))
                {

                    if (result >= 1 && result <= 10)
                    {
                        y = result - 1;
                        break;
                    }
                }
                Console.WriteLine("Нужна цифра от 1 до 10!");
            }

            return new Coordinate(x, y);
        }
    }
}
