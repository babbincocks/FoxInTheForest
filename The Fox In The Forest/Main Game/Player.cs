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


        private static StreamReader playerRead;
        private static Player newPlayer;
        private static List<Player> players;
        private static Player currPlayer = new Player("Guest");


        public static List<Player> PlayerList (string path)
        {
            //const string fileLocation = @"../../../Profiles/Profiles.csv";

            players = new List<Player>();
            try
            {

                playerRead = new StreamReader(path);
                while (!playerRead.EndOfStream)
                {
                    string[] player = new string[5];
                    player = playerRead.ReadLine().Split(',');
                    int i = 0;
                    foreach (string cell in player)
                    {
                        if (cell == null)
                        {
                            player[i] = "0";
                        }
                        i++;
                    }
                    newPlayer = new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3]), int.Parse(player[4]));
                    players.Add(newPlayer);
                }
                playerRead.Close();
                return players;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Player SetCurrentPlayer(int playIndex)
        {

            //The default player is just a Guest account.

            //If a player has been chosen, their information is loaded, and turned into the 
            if (players.Count() > 0)
            {
                currPlayer = players[playIndex];
            }

            return currPlayer;
        }

        public static Player CurrentPlayer()
        {
            return currPlayer;
        }

    }
}
