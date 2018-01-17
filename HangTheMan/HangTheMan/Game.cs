using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangTheMan
{
    class Game
    {
        public string WordToGuess;
        public string WordToGuessToLowerCase;
        public StringBuilder DisplayToPlayer;
        public List<string> UsedLettersPool = new List<string>();


        public void ReadyToStartGame()
        {

            Words word = new Words();
            Random nextWord = new Random();

            // Takes a word form the WordPool and get the length off that.
            WordToGuess =  word.WordPool[nextWord.Next(0, word.WordPool.Length)];

            // I want it to be LowerCase so no matter how the user inputs the input it will check it, 
            // and uppercase is easier to work with
            WordToGuessToLowerCase = WordToGuess.ToLower();

            DisplayToPlayer = new StringBuilder(WordToGuess.Length);
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                DisplayToPlayer.Append('-');
            }

        }

        public int userLife = 0;
        public int maxLife = 8;
        public int lettersRevealed = 0;

        public void RunGame()
        {
            bool GameRunning = true;

            while (GameRunning == true)
            {
                char guessedLetterUpperCase;
                Stats();
                string guessedLetter = Console.ReadLine().ToLower();
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
            foreach(string usedletter in UsedLettersPool)
            {
                Console.Write(usedletter + " ");
            }
            Console.WriteLine();

        }

    }

    class Words
    {
        // You can add all the words you want in this array
        public string[] WordPool = 
        {
            "car",
            "guy",
            "yellow",
            "red",
            "kurt"
        };
    }
}
