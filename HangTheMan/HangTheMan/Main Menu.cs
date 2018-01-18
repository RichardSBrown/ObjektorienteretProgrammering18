using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangTheMan
{
    class Main_Menu : PrintStuff
    {
        public string Welcome = "Welcome to hang the man \n" +
            "> Start \n" +
            "> Rules \n" +
            "> Credits \n";


        public string Rules = "RULES: \n" +
            "You'll try to guess the word, one letter at a time \n" +
            "if the letter is not in the word you'll lose a life \n" +
            "if the letter is in the word you'll see where in the word it is \n" +
            "you can't use the same letter more then one time. \n" +
            "---------------------------------------------------------------------";

        public string Credits = "Credits: \n" +
            "The game was made by: Richard Brown Thomsen\n" +
            "---------------------------------------------------------------------";


        public string print(string input)
        {
            Console.WriteLine(input);
            return input;
        }

    }
}
