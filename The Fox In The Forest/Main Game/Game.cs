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
        private static int roundPoints = 0;

        private static bool yourTurn;
        private static bool playLead;

        private static Card playerChosenCard;
        private static Card opponentChosenCard;

        public static void SetLead(bool lead)
        {
            playLead = lead;

        }

        public static int GetRoundPoints()
        {
            return roundPoints;
        }

        public static void SetRoundPoints(int increase)
        {
            if (increase > 0 && increase < 3)
            {
                roundPoints += increase;
            }

        }

        public static void ResetRoundPoints()
        {
            roundPoints = 0;
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

        public static bool Hand()
        {
            bool playerWin = false;

            //If neither played card is an effect card...
             if (Game.PlayerChosenCard().CardNumber % 2 == 0  && Game.OpponentChosenCard().CardNumber % 2 == 0)
             {
                //...and the player lead...
                if (Game.PlayerLead())
                {

                    if (Game.PlayerChosenCard().CardSuit == Card.Trump().CardSuit)
                    {
                        if (Game.OpponentChosenCard().CardSuit != Card.Trump().CardSuit)
                        {
                            playerWin = true;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                playerWin = false;
                            }
                        }
                    }
                    else if (Game.PlayerChosenCard().CardSuit != Card.Trump().CardSuit && Game.OpponentChosenCard().CardSuit == Card.Trump().CardSuit)
                    {
                        playerWin = false;
                    }
                    else
                    {
                        if (Game.PlayerChosenCard().CardSuit != Game.OpponentChosenCard().CardSuit)
                        {
                            playerWin = true;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
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
                    if(Game.OpponentChosenCard().CardSuit == Card.Trump().CardSuit)
                    {
                        if (Game.PlayerChosenCard().CardSuit != Card.Trump().CardSuit)
                        {
                            playerWin = false;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                playerWin = false;
                            }
                        }
                    }
                    else if (Game.PlayerChosenCard().CardSuit == Card.Trump().CardSuit && Game.OpponentChosenCard().CardSuit != Card.Trump().CardSuit)
                    {
                        playerWin = true;
                    }
                    else
                    {
                        if (Game.PlayerChosenCard().CardSuit != Game.OpponentChosenCard().CardSuit)
                        {
                            playerWin = false;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
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
             }
            else
            /*
             Returned Effect integer meanings:
             0: No effect, just go off of card values. 
             1: Player definitely wins.
             2: Player definitely loses.
             3: Player lost, but played a 1, so they will have the lead next round.
             */
            {
                int result = Card.Effect(Game.PlayerChosenCard(), Game.OpponentChosenCard());
                if (result == 1)
                {
                    playerWin = true;
                    SetLead(true);
                }
                else if (result == 2)
                {
                    playerWin = false;
                    SetLead(false);
                }
                else if (result == 3)
                {
                    playerWin = false;
                    SetLead(true);
                }
                else
                {
                    if (Game.PlayerLead())
                    {

                        if (Game.PlayerChosenCard().CardSuit == Card.Trump().CardSuit)
                        {
                            if (Game.OpponentChosenCard().CardSuit != Card.Trump().CardSuit)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
                                {
                                    playerWin = true;
                                }
                                else
                                {
                                    playerWin = false;
                                }
                            }
                        }
                        else if (Game.PlayerChosenCard().CardSuit != Card.Trump().CardSuit && Game.OpponentChosenCard().CardSuit == Card.Trump().CardSuit)
                        {
                            playerWin = false;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardSuit != Game.OpponentChosenCard().CardSuit)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
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
                        if (Game.OpponentChosenCard().CardSuit == Card.Trump().CardSuit)
                        {
                            if (Game.PlayerChosenCard().CardSuit != Card.Trump().CardSuit)
                            {
                                playerWin = false;
                            }
                            else
                            {
                                if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
                                {
                                    playerWin = true;
                                }
                                else
                                {
                                    playerWin = false;
                                }
                            }
                        }
                        else if (Game.PlayerChosenCard().CardSuit == Card.Trump().CardSuit && Game.OpponentChosenCard().CardSuit != Card.Trump().CardSuit)
                        {
                            playerWin = true;
                        }
                        else
                        {
                            if (Game.PlayerChosenCard().CardSuit != Game.OpponentChosenCard().CardSuit)
                            {
                                playerWin = false;
                            }
                            else
                            {
                                if (Game.PlayerChosenCard().CardNumber > Game.OpponentChosenCard().CardNumber)
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
                }
            }



            return playerWin;
        }

        

        public static int[] RoundEnd(int yourTricks, int oppTricks)
        {
            int[] scores = new int[2];

            if(yourTricks < 4)
            {
                scores[0] = 6;
            }
            else if(yourTricks == 4)
            {
                scores[0] = 1;
            }
            else if (yourTricks == 5)
            {
                scores[0] = 2;
            }
            else if (yourTricks == 6)
            {
                scores[0] = 3;
            }
            else if (yourTricks > 6 && yourTricks < 10)
            {
                scores[0] = 6;
            }
            else if (yourTricks > 9)
            {
                scores[0] = 0;
            }


            if (oppTricks < 4)
            {
                scores[1] = 6;
            }
            else if (oppTricks == 4)
            {
                scores[1] = 1;
            }
            else if (oppTricks == 5)
            {
                scores[1] = 2;
            }
            else if (oppTricks == 6)
            {
                scores[1] = 3;
            }
            else if (oppTricks > 6 && oppTricks < 10)
            {
                scores[1] = 6;
            }
            else if (oppTricks > 9)
            {
                scores[1] = 0;
            }


            

            return scores;
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
