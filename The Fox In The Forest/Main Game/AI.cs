using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class AI
    {

        private static int score;
        private static int tricks;

        public static bool CheckScore(int compTricks)
        {
            bool desirePoints = true;
            if (compTricks < 4 || (compTricks > 6 && compTricks < 10))
            {
                desirePoints = false;
            }

            return desirePoints;
        }

        public static void SetScore(int points)
        {
            score += points;
        }

        public static int GetScore()
        {
            return score;
        }

        public static void SetTricks(int points)
        {
            tricks += points;
        }

        public static int GetTricks()
        {
            return tricks;
        }

        public static void ResetPoints()
        {
            score = 0;
        }

        public static void ResetTricks()
        {
            tricks = 0;
        }


        public static Card TakeTurn()
        {       
            Card chosenCard = new Card();
            bool overrideChoice = false;
            bool no11 = false;

            if (!Game.PlayerTurn())
            {
                List<Card> cardPicks = new List<Card>();

                try
                {
                    if (!Game.PlayerLead())
                    {
                        if (CheckScore(GetTricks()))
                        {
                            foreach(Card card in Card.OpponentCurrentHand())
                            {
                                if(card.CardNumber == 11 || card.CardNumber == 9 || card.CardSuit == Card.Trump().CardSuit)
                                {
                                    cardPicks.Add(card);
                                }
                                
                            }
                        }
                        else
                        {
                            foreach (Card card in Card.OpponentCurrentHand())
                            {
                                if (card.CardNumber == 1 || card.CardNumber == 3 || card.CardSuit != Card.Trump().CardSuit)
                                {
                                    cardPicks.Add(card);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Game.PlayerChosenCard().CardNumber == 11)
                        {
                            int highest = 0;
                            foreach (Card card in Card.OpponentCurrentHand())
                            {
                                if (card.CardSuit == Game.PlayerChosenCard().CardSuit)
                                {
                                    if (card.CardNumber == 1)
                                    {
                                        cardPicks.Add(card);
                                    }
                                    else if (card.CardNumber > highest)
                                    {
                                        highest = card.CardNumber;
                                    }
                                }
                                
                            }
                            foreach (Card card in Card.OpponentCurrentHand())
                            {
                                if (card.CardNumber == highest && card.CardSuit == Game.PlayerChosenCard().CardSuit)
                                {
                                    cardPicks.Add(card);
                                }
                            }
                            if (!cardPicks.Any())
                            {
                                no11 = true;
                            }
                        }
                        else
                        {
                            no11 = true;
                        }

                        
                        if (no11 == true)
                        {
                            foreach (Card card in Card.OpponentCurrentHand())
                            {
                                if (card.CardSuit == Game.PlayerChosenCard().CardSuit)
                                {
                                    cardPicks.Add(card);
                                }
                            }
                            
                            if (!cardPicks.Any())
                            {
                                foreach (Card card in Card.OpponentCurrentHand())
                                {

                                    if (CheckScore(GetTricks()))
                                    {
                                        if (card.CardSuit != Card.Trump().CardSuit)
                                        {
                                            if (card.CardNumber == 9)
                                            {
                                                if (Game.PlayerChosenCard().CardNumber == 9 && Game.PlayerChosenCard().CardSuit != Card.Trump().CardSuit)

                                                {
                                                    chosenCard = card;
                                                    overrideChoice = true;
                                                    break;
                                                }
                                            }

                                            cardPicks.Add(card);

                                        }
                                       

                                    }
                                    else
                                    {
                                        if (card.CardSuit == Game.PlayerChosenCard().CardSuit)
                                        {
                                            cardPicks.Add(card);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!overrideChoice)
                    {
                        if (!cardPicks.Any())
                        {
                            foreach(Card card in Card.OpponentCurrentHand())
                            {
                                cardPicks.Add(card);
                            }
                            
                        }
                        
                            Random rng = new Random();
                            int choice = rng.Next(cardPicks.Count);
                            chosenCard = cardPicks[choice];
                        

                    }



                }
                catch(Exception ex)
                {
                    throw ex;
                }
             
            }
            Game.SetOpponentCard(chosenCard);
            return Card.OpponentPlayCard(chosenCard);
        }


        public static Card ChangeDecree()
        {
            Card choice = null;
            int moons = 0;
            int keys = 0;
            int bells = 0;
            string suitChoice = "Bell";

            if(!Game.PlayerLead())
            {
                foreach(Card card in Card.OpponentCurrentHand())
                {
                    if (card.CardSuit == "Moon")
                    {
                        moons++;
                    }
                    else if (card.CardSuit == "Key")
                    {
                        keys++;
                    }
                    else
                    {
                        bells++;
                    }
                }

                if (moons == Math.Max(Math.Max(moons, bells), keys))
                {
                    suitChoice = "Moon";
                }
                else if (keys == Math.Max(Math.Max(moons, bells), keys))
                {
                    suitChoice = "Key";
                }
                else if (bells == Math.Max(Math.Max(moons, bells), keys))
                {
                    suitChoice = "Bell";
                }

                foreach(Card card in Card.OpponentCurrentHand())
                {
                    if(card.CardSuit == suitChoice)
                    {
                        if(CheckScore(GetTricks()) && card.CardNumber % 2 == 0)
                        {
                            choice = card;
                        }
                    }
                }

            }
            else
            {
                //If the computer is going second and they want points, they will try to get a card that will change the suit to the detriment of the player.
                if(CheckScore(GetTricks()))
                {
                    foreach(Card card in Card.OpponentCurrentHand())
                    {
                        if(card.CardSuit != Game.PlayerChosenCard().CardSuit && card.CardSuit != Card.Trump().CardSuit)
                        {
                            choice = card;
                        }
                    }
                }
                //If they don't want points, they will try to get a card that will change the suit to the "benefit" of the player.
                else
                {
                    foreach (Card card in Card.OpponentCurrentHand())
                    {
                        if (card.CardSuit == Game.PlayerChosenCard().CardSuit)
                        {
                            choice = card;
                        }
                    }
                }
            }
            //If nothing gets chosen in the end, and not because there's nothing left, just the first card is chosen.
            if(choice == null && Card.OpponentCurrentHand().Any())
            {
                choice = Card.OpponentCurrentHand()[0];
            }


            return choice;
        }

    }
}
