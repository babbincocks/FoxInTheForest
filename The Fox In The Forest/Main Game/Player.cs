using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Main_Game
{
    class Player
    {
        string playerName;
        int playerWins;
        int playerLosses;
        int tricksWon;
        int totalPoints;

        public Player()
        {

        }

        public Player(string name)
        {
            playerName = name;
            playerWins = 0;
            playerLosses = 0;
            tricksWon = 0;
            totalPoints = 0;
        }

        public Player(string name, int wins, int losses, int tWins, int tPoints)
        {
            playerName = name;
            playerWins = wins;
            playerLosses = losses;
            tricksWon = tWins;
            totalPoints = tPoints;
        }

        public string Name
        {
           get { return playerName; }
            set { playerName = value; }
        }

        public int TotalWins
        {
            get { return playerWins; }
            set { playerWins = value; }
        }

        public int TotalLosses
        {
            get { return playerLosses; }
            set { playerLosses = value; }
        }

        public int TotalTricks
        {
            get { return tricksWon; }
            set { tricksWon = value; }
        }

        public string PlayStats
        {
            get { return playerName + "," + playerWins + "," + playerLosses + "," + tricksWon + "," + totalPoints; }
        }




        //????? WILL THIS WORK????
        public List<Player> PlayerList (StreamReader path)
        {
            const string fileLocation = @"../../../Profiles/Profiles.csv";

            List<Player> players = new List<Player>();
            return players;
        }

    }
}
