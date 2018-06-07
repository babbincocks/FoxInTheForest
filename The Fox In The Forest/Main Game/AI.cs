using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class AI
    {

        public static bool CheckScore(int compTricks)
        {
            bool desirePoints = true;
            if (compTricks < 4 || (compTricks > 6 && compTricks < 10))
            {
                desirePoints = false;
            }

            return desirePoints;
        }



        public static Card TakeTurn()
        {
            Card chosenCard = new Card();
            bool overrideChoice = false;
            if (!Game.PlayerTurn())
            {
                List<Card> cardPicks = new List<Card>();

                try
                {
                    if (!Game.PlayerLead())
                    {
                        if (AI.CheckScore(Game.OpponentTricks))
                        {

                        }
                        else
                        {

                        }
                    }
                    else
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

                                if (AI.CheckScore(Game.OpponentTricks))
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

                                }
                            }
                        }
                    }

                    if (!overrideChoice)
                    {
                        Random rng = new Random();
                        int choice = rng.Next(Card.OpponentCurrentHand().Count);
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
