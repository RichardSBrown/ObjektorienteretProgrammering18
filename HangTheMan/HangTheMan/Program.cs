using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangTheMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Main_Menu menu = new Main_Menu();
            bool GameNotRunning = true;

            while (GameNotRunning == true)
            {
                Console.Clear();
                menu.print(menu.Welcome);
                string input = Console.ReadLine().ToLower();
                if (input == "!rules")
                {
                    menu.print(menu.Rules);
                }
                else if (input == "!credits")
                {
                    menu.print(menu.Credits);
                }
                else if  (input == "!start")
                {
                    // Start the game
                    Game game = new Game();
                    game.ReadyToStartGame();
                    game.RunGame();
                }
                else if (input == "!end")
                {
                    System.Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Sorry i dont have that command");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
        }
    }
}
