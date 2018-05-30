using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class Game
    {
        private int yourScore = 0;
        private int oppScore = 0;
        private int yourTricks = 0;
        private int oppTricks = 0;

        public int YourScore
            {
            get { return yourScore; }
            set { yourScore = value; }
            }

        public int OpponentScore
        {
            get { return oppScore; }
            set { oppScore = value; }
        }

        public int YourTricks
        {
            get { return yourTricks; }
            set { yourTricks = value; }
        }

        public int OpponentTricks
        {
            get { return oppTricks; }
            set { oppTricks = value; }
        }


        public static List<Card> SetCards(List<string> preCards)
        {
            List<Card> deck = Card.PopulateDeck(preCards);

            deck = Card.Shuffle(deck);

            return deck;

        }
        private static Random rng = new Random();
        public static bool Flip(int call)
        {
            bool win = false;

            int result = rng.Next(2);

            if (call == result)
            {
                win = true;
            }

                return win;
        }



        public static void Hand(Card yourCard, Card oppCard)
        {
            

            
        }
        
        


        public static bool CheckEnd(int yourScore, int oppScore)
        {
            
            bool finished = false;

            if (yourScore >= 21 || oppScore >= 21)
            {
                finished = true;
            }

            return finished;
        }

        public static bool Winner(int yourScore, int oppScore)
        {
            bool playerWin = false;
            if (yourScore > oppScore)
            {
                playerWin = true;
            }
            else if (oppScore > yourScore)
            {
                playerWin = false;
            }

            return playerWin;
        }
    }
}
