using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangTheMan
{
    class GlobalVariables
    {
        // Prepare
        public string WordToGuess;
        public string WordToGuessToLowerCase;
        public StringBuilder DisplayToPlayer;
        public List<string> UsedLettersPool = new List<string>();
        // End of prepare

        // Game
        public int userLife = 0;
        public int maxLife = 8;
        public int lettersRevealed = 0;
        public int UserTimer = 0;
        public bool GameRunning = true;
        // End of Game
    }
}
