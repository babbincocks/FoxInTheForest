using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class Card
    {       //The Card class, which will handle card values and help with maintaining the deck.

        //Backing variables
        int number;
        string suit;
        string cardKey;


        private static Card trump;



        public static Card Trump()
        { 
            return trump;
        }

        public static void SetTrump()
        {       //Set decree card at beginning of round.
            try
            {
                trump = deck.Last();
                deck.RemoveAt(deck.Count - 1);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void SetTrump(Card choice)
        {       //For when switching decree card with card in hand.
            trump.CardNumber = choice.CardNumber;
            trump.CardSuit = choice.CardSuit;
            trump.CardKey = choice.CardKey;
        }

        public Card()
        {

        }

        //Constructor that sets the values of a card.
        public Card(int cardNumber, string cardSuit)
        {
            number = cardNumber;
            suit = cardSuit;
            cardKey = cardNumber + "_" + cardSuit + ".png";
        }

        //Couple of accessors.
        public int CardNumber
        {
            get { return number; }
            set { number = value; }
        }


        public string CardSuit
        {
            get { return suit; }
            set { suit = value; }
        }

        public string CardKey
        {
            get { return cardKey; }
            set { cardKey = number + "_" + suit + ".png"; }
        }
        

            //11 is handled elsewhere.
        public static int Effect(Card yourCard, Card oppCard)
        {       //Logic for certain effect cards are handled here (1, 5, 7, and 9)
            int result = 0;


            if (yourCard.CardNumber == 1)
            {
                if (oppCard.CardNumber > 1)
                {
                    if (oppCard.CardSuit == yourCard.CardSuit)
                    {       //3 means loss, but player will go first.
                        result = 3;
                        
                    }
                    //else if (oppCard.CardSuit == trump.CardSuit)
                    //{

                    //}
                }
                //else
                //{

                //}
            }
            else if (yourCard.CardNumber == 5)
            {
                DrawCard();
                frmDiscardSelect newDiscard = new frmDiscardSelect();
                newDiscard.ShowDialog();
                if (newDiscard.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    string returnedCard = newDiscard.GetChosen();
                    newDiscard.Close();
                    foreach(Card card in YourCurrentHand())
                    {
                        string[] c = returnedCard.Split('_');
                        c[1] = c[1].Replace(".png", "");
                        Card b = new Card(int.Parse(c[0]), c[1]);
                        if (b.CardKey == card.CardKey)
                        {
                            Discard(card);
                            break;
                        }
                    }
                    
                }
            }
            else if (yourCard.CardNumber == 7)
            {
                if (oppCard.CardNumber == 7)
                {
                    Game.SetRoundPoints(2);
                }
                else
                {
                    Game.SetRoundPoints(1);
                }
            }
            else if (yourCard.CardNumber == 9)
            {
                if (oppCard.CardSuit == trump.CardSuit)
                {
                     if(oppCard.CardNumber != 9)
                     {
                        if(oppCard.CardNumber > yourCard.CardNumber)
                        {
                            result = 2;
                        }
                        else if (oppCard.CardNumber < yourCard.CardNumber)
                        {
                            result = 1;
                        }
                     }
                     else if (Game.PlayerLead())
                     {
                        result = 1;
                     }
                     else
                     {
                        result = 2;
                     }
                }
                else if (oppCard.CardSuit != trump.CardSuit)
                {
                    if (oppCard.CardNumber != 9)
                    {
                        result = 1;
                    }
                    else if (Game.PlayerLead())
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 2;
                    }
                }
                
            }
            //11 will be handled elsewhere.

            if (oppCard.CardNumber == 7 && yourCard.CardNumber != 7)
            {
                Game.SetRoundPoints(1);
            }
            else if(oppCard.CardNumber == 9 && yourCard.CardNumber != 9)
            {
                if (yourCard.CardSuit == trump.CardSuit)
                {
                    if (yourCard.CardNumber > oppCard.CardNumber)
                    {
                        result = 1;
                    }
                    else if (yourCard.CardNumber < oppCard.CardNumber)
                    {
                        result = 2;
                    }
                }
                else
                {
                    result = 2;
                }
            }


            return result;
        }





        //Variable that will be the current state of the deck
        private static List<Card> deck;


        //If the deck needs to be retrieved in its entirety.
        public static List<Card> Deck()
        {
            return deck;
        }





        //Discard for the effect of a 5 card.
        public static void Discard(Card card)
        {
            try
            {
                PlayCard(card);
                deck.Add(card);
                Card placeholder = deck[0];
                deck[0] = deck[deck.Count - 1];
                deck[deck.Count - 1] = placeholder;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DrawCard()
        {
            Card newCard = deck.Last();
            deck.RemoveAt(deck.Count - 1);
            yourHand.Add(newCard);


        }

        public static void OppDrawCard()
        {
            Card newCard = deck.Last();
            deck.RemoveAt(deck.Count - 1);
            oppHand.Add(newCard);
        }



        public static List<Card> PopulateDeck(List<string> cards)
        {
            deck = new List<Card>();

            foreach (string card in cards)
            {
                //Don't want to put the card back face or the scoring sheet reference in the deck, so this if statement.
                if (!card.Contains("Owl") && !card.Contains("FitF"))
                {
                    string[] cardEle = card.Split('_');
                    string cardNumber = cardEle[0];
                    string cardSuit = cardEle[1];

                    cardSuit = cardSuit.Replace(".png", "");

                    Card current = new Card(int.Parse(cardNumber), cardSuit);
                    deck.Add(current);
                }
            }
            return deck;
        }



        private static Random rng = new Random();
        
        public static List<Card> Shuffle(List<Card> shuffleDeck)
        {
            int count = 1;
            while (count < 5)
            {
                int n = shuffleDeck.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card choice = shuffleDeck[k];
                    shuffleDeck[k] = shuffleDeck[n];
                    shuffleDeck[n] = choice;

                }
                count++;
            }

            return shuffleDeck;
            
        }

        //Cards currently in player hand and opponent hand.
        private static List<Card> yourHand = new List<Card>();
        private static List<Card> oppHand = new List<Card>();

        public static List<Card> YourCurrentHand()
        {
            return yourHand;
        }

        public static List<Card> OpponentCurrentHand()
        {
            return oppHand;
        }

        public static Card PlayCard(Card chosenCard)
        {
            foreach(Card card in yourHand)
            {
                if (card.CardKey == chosenCard.CardKey)
                {
                    yourHand.Remove(card);
                    break;
                }
            }
            
            return chosenCard;
            
        }

        public static Card OpponentPlayCard(Card chosenCard)
        {
            foreach (Card card in oppHand)
            {
                if (card.CardKey == chosenCard.CardKey)
                {
                    oppHand.Remove(chosenCard);
                    break;
                }
            }
            return chosenCard;
        }

        public static void PopulateHands()
        {
            while(yourHand.Count < 13)
            {
                yourHand.Add(deck[deck.Count - 1]);
                    deck.Remove(deck[deck.Count - 1]);
            }
            while(oppHand.Count < 13)
            {
                oppHand.Add(deck[deck.Count - 1]);
                deck.Remove(deck[deck.Count - 1]);
            }
        }



    }
}
