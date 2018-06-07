using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class Game
    {
        private static int yourScore;
        private static int oppScore;
        private static int yourTricks;
        private static int oppTricks;

        private static bool yourTurn;
        private static bool playLead;

        private static Card playerChosenCard;
        private static Card opponentChosenCard;

        public static void SetLead(bool lead)
        {
            playLead = lead;

        }

        public static void SetTurn(bool turn)
        {
            yourTurn = turn;
        }

        public static bool PlayerLead()
        {
            return playLead;
        }

        public static bool PlayerTurn()
        {
            return yourTurn;
        }

        public Game()
        {
            yourScore = 0;
            oppScore = 0;
            yourTricks = 0;
            oppTricks = 0;
        }

        public static int YourScore
            {
            get { return yourScore; }
            set { yourScore = value; }
            }

        public static int OpponentScore
        {
            get { return oppScore; }
            set { oppScore = value; }
        }

        public static int YourTricks
        {
            get { return yourTricks; }
            set { yourTricks = value; }
        }

        public static int OpponentTricks
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

        public static Card PlayerChosenCard()
        {
            return playerChosenCard;

        }

        public static void SetPlayerCard(Card choice)
        {
            playerChosenCard = choice;
        }

        public static void SetOpponentCard(Card choice)
        {
            opponentChosenCard = choice;
        }

        public static Card OpponentChosenCard()
        {
            return opponentChosenCard;

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
                            playerWin = true;
                        }
                        else
                        {
                            if (yourCard.CardNumber > oppCard.CardNumber)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                playerWin = false;
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
