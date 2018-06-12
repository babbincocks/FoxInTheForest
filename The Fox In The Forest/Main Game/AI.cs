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
                        if (AI.CheckScore(GetTricks()))
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
                            //TODO: Check if this method of checking if the card list is empty is functional.
                            if (!cardPicks.Any())
                            {
                                foreach (Card card in Card.OpponentCurrentHand())
                                {

                                    if (AI.CheckScore(GetTricks()))
                                    {
                                        if (card.CardSuit == Card.Trump().CardSuit)
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
                                        else
                                        {

                                        }

                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }

                    if (!overrideChoice)
                    {
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
    }
}
