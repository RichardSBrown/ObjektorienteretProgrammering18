using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangTheMan
{
    public delegate void SomeDelegae();
    class Game : GlobalVariables
    {

        public void ReadyToStartGame()
        {
            StartMenu startmenu = new StartMenu(RunGame);
             
            Words word = new Words();
            Random nextWord = new Random();

            // Takes a word form the WordPool and get the length off that.
            WordToGuess = word.WordPool[nextWord.Next(0, word.WordPool.Length)];

            // I want it to be LowerCase so no matter how the user inputs the input it will check it, 
            // and uppercase is easier to work with
            WordToGuessToLowerCase = WordToGuess.ToLower();

            DisplayToPlayer = new StringBuilder(WordToGuess.Length);
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                DisplayToPlayer.Append('-');
            }
        }


        public void RunGame()
        {
            Thread timerThread = new Thread(Timer);
            timerThread.Start();


            while (GameRunning == true)
            {
                char guessedLetterUpperCase;

                Stats();

                string guessedLetter = Console.ReadLine().ToLower();
                if (guessedLetter.Length >= 2 || guessedLetter == " ")
                {
                    continue;
                }
                try
                {
                    guessedLetterUpperCase = guessedLetter[0];
                }
                catch
                {
                    continue;
                }

                if (UsedLettersPool.Contains(guessedLetter))
                {
                    Console.WriteLine("You guessed that already");
                    continue;
                }

                else if (WordToGuessToLowerCase.Contains(guessedLetter))
                {
                    Console.WriteLine("That's right!");

                    for (int i = 0; i < WordToGuess.Length; i++)
                    {
                        if (WordToGuess[i] == guessedLetterUpperCase)
                        {
                            DisplayToPlayer[i] = WordToGuess[i];
                            lettersRevealed++;
                        }
                    }
                }
                else if (!WordToGuessToLowerCase.Contains(guessedLetter))
                {
                    userLife++;
                }

                if (lettersRevealed == WordToGuess.Length)
                {
                    timerThread.Abort();
                    Console.WriteLine("You won!");
                    GameRunning = false;
                    Console.WriteLine("Your time was " + UserTimer + " sec");
                }
                if (userLife == maxLife)
                {
                    timerThread.Abort();
                    Console.WriteLine("You Lost!!");
                    GameRunning = false;
                    Console.WriteLine("Your time was " + UserTimer + " sec");
                    Console.WriteLine("The word was " + WordToGuess);
                }

                UsedLettersPool.Add(guessedLetter);

            }
        }
        public void Stats()
        {
            Console.Clear();
            // Displays the dots equals to the word 
            Console.WriteLine(DisplayToPlayer);

            Console.WriteLine("Life: '{0}' / '{1}'", userLife, maxLife);
            Console.Write("Used letters: ");
            foreach (string usedletter in UsedLettersPool)
            {
                Console.Write(usedletter + " ");
            }
            Console.WriteLine();

        }

        public void Timer()
        {
            while (GameRunning == true)
            {
                UserTimer++;
                Thread.Sleep(1000);
            }
        }

    }

    class Words
    {
        // You can add all the words you want in this array
        public string[] WordPool = 
        {
            "budge",
            "captain",
            "adopt",
            "dismissal",
            "jury",
            "produce",
            "shadow",
            "fire",
            "pitch",
            "government"
        };
    }
}
