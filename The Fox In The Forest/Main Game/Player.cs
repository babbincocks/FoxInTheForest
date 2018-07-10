using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Main_Game
{
    class Player
    {       //The Player class, which will handle all interaction with different player aspects (i.e. stats, and who's currently playing.)

        //Variables to hold the different stats being kept track of.
        
            string playerName;
            int playerWins;
            int playerLosses;
            int tricksWon;
            int totalPoints;
        


        //Constructor for when a player is being created, setting the name, and then setting all stats to 0.
        public Player(string name)
        {
            playerName = name;
            playerWins = 0;
            playerLosses = 0;
            tricksWon = 0;
            totalPoints = 0;
        }

        //Constructor for updating player stats or retrieving player stats.
        public Player(string name, int wins, int losses, int tWins, int tPoints)
        {
            playerName = name;
            playerWins = wins;
            playerLosses = losses;
            tricksWon = tWins;
            totalPoints = tPoints;
        }

        //Bunch of accessors below.
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

        public int TotalPoints
        {
            get { return totalPoints; }
            set { totalPoints = value; }
        }

        //Retrieve one long string for player stats.
        public string PlayStats
        {
            get { return playerName + "," + playerWins + "," + playerLosses + "," + tricksWon + "," + totalPoints; }
        }

        //Special variables for more complicated methods.
        private static StreamReader playerRead;
        private static Player newPlayer;
        private static List<Player> players;
        private static Player currPlayer = new Player("Guest");



        //Method to populate the list of players, so the player can choose a profile.
        public static List<Player> PlayerList (string path)
        {
            //const string fileLocation = @"../../Profiles/Profiles.csv";

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

        //Method to set the current player.
        public static Player SetCurrentPlayer(int playIndex)
        {

            //The default player is just a Guest account.

            //If a player has been chosen, their information is loaded, and turned into the current player.
            if (players.Count() > 0)
            {
                currPlayer = players[playIndex];
            }

            return currPlayer;
        }

        //Method to retrieve the current player.
        public static Player CurrentPlayer()
        {
            return currPlayer;
        }

        public static void UpdatePlayerStats()
        {
            string path = @"../../Profiles.csv";
            List<string> lines = new List<string>();
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                string[] split = line.Split(',');

                                if (split[0].Contains(CurrentPlayer().Name))
                                {
                                    split[1] = CurrentPlayer().TotalWins.ToString();
                                    split[2] = CurrentPlayer().TotalLosses.ToString();
                                    split[3] = CurrentPlayer().TotalTricks.ToString();
                                    split[4] = CurrentPlayer().TotalPoints.ToString();
                                    line = string.Join(",", split);
                                }
                            }
                            lines.Add(line);
                        }
                    }

                    using (StreamWriter target = new StreamWriter(path, false))
                    {
                        foreach (string line in lines)
                        {
                            target.WriteLine(line);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteLog(string line)
        {
            const string filePath = @"../../Log.txt";
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(DateTime.Now.ToLongTimeString() + ": " + line);
            }
        }


    }
}
