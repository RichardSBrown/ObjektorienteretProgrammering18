using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangTheMan
{
    class StartMenu : GlobalVariables
    {
        public delegate void CallBackDelegate();
        CallBackDelegate callbackdel;

        public StartMenu(CallBackDelegate callbackdel)
        {
            this.callbackdel = callbackdel;
        }


        public void StartUp()
        {
            Main_Menu menu = new Main_Menu();
            bool GameNotRunning = true;
            Game game = new Game();



            while (GameNotRunning == true)
            {
                Console.Clear();
                menu.print(menu.Welcome);
                string input = Console.ReadLine().ToLower();

                if (input == "rules")
                {
                    menu.print(menu.Rules);
                }

                else if (input == "credits")
                {
                    menu.print(menu.Credits);
                }

                else if (input == "start")
                {
                    userLife = 0;
                    UsedLettersPool.Clear();
                    // Start the game
                    Thread ReadyTheGameThread = new Thread(game.ReadyToStartGame);
                    ReadyTheGameThread.Start();
                    callbackdel();
                    game.RunGame();
                }

                else if (input == "end")
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
