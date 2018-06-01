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



        public static bool Hand(Card yourCard, Card oppCard, bool youLead)
        {
            bool playerWin = false;

             if (yourCard.CardNumber % 2 == 0  && oppCard.CardNumber % 2 == 0)
            {
                if (youLead == true)
                {
                    if (yourCard.CardSuit == Card.Trump().CardSuit && oppCard.CardSuit != Card.Trump().CardSuit)
                    {
                        playerWin = true;
                    }
                    else if (yourCard.CardSuit != Card.Trump().CardSuit && oppCard.CardSuit == Card.Trump().CardSuit)
                    {
                        playerWin = false;
                    }
                    else if (yourCard.CardSuit == Card.Trump().CardSuit && oppCard.CardSuit == Card.Trump().CardSuit)
                    {
                        if(yourCard.CardNumber > oppCard.CardNumber)
                        {
                            playerWin = true;
                        }
                        else
                        {
                            playerWin = false;
                        }
                    }
                    else
                    {
                        if (yourCard.CardSuit != oppCard.CardSuit)
                        {
                            //player wins
                        }
                        else
                        {
                            if (yourCard.CardNumber > oppCard.CardNumber)
                            {
                                //player wins
                            }
                            else
                            {
                                //player loses
                            }
                        }
                        
                    }
                }
                else
                {

                }
             }
            else
            /*
             Returned Effect integer meanings:
             0: No effect, just go off of card values. 
             1: Player definitely wins.
             2: Player definitely loses.
             */
            {
                if (Card.Effect(yourCard, oppCard) == 1)
                {
                    playerWin = true;
                }
                else if (Card.Effect(yourCard, oppCard) == 2)
                {
                    playerWin = false;
                }
                else
                {

                }
            }

            return playerWin;
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
