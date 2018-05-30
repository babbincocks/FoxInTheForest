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


        public static Card trump;

        //This might not even be done in the class, not sure yet.
        public static Card Trump(Card newCard)
        {
            trump = newCard;

            return trump;
        }

        public static Card Trump()
        { 
            return trump;
        }


        //public Card()
        //{
        //    number = 1;
        //    suit = "Bell";
        //}

        //Constructor that sets the values of a card.
        public Card(int cardNumber, string cardSuit)
        {
            number = cardNumber;
            suit = cardSuit;
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

        //As odd-numbered cards have special effects that can affect a play, it needs to be handled somewhere. Maybe here?
        public void Effect(Card yourCard, Card oppCard)
        {

            if (yourCard.CardNumber == 1)
            {

            }
            else if (yourCard.CardNumber == 3)
            {

            }
            else if (yourCard.CardNumber == 5)
            {

            }
            else if (yourCard.CardNumber == 7)
            {

            }
            else if (yourCard.CardNumber == 9)
            {
                if (oppCard.CardNumber != 9)
                {
                    if (oppCard.CardSuit != trump.CardSuit)
                    {

                    }
                }
            }
            else if (yourCard.CardNumber == 11)
            {

            }
        }



        //Variable that will be the current state of the deck, and another for the used cards to go.
        private static List<Card> deck;
        private static List<Card> discard;

        //If the deck needs to be retrieved in its entirety.
        public static List<Card> Deck()
        {
            return deck;
        }

        //If the discard pile needs to be retrieved in its entirety.
        public static List<Card> DiscardPile()
        {
            return discard;
        }

        public static void Discard(List<Card> cards)
        {
            try
            {
                foreach (Card card in cards)
                {
                    discard.Add(card);
                }
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

        public static List<Card> PopulateDeck(List<string> cards)
        {
            deck = new List<Card>();

            foreach (string card in cards)
            {
                if (!card.Contains("Owl") && !card.Contains("FitF"))
                {
                    string[] cardEle = card.Split('_');
                    string cardNumber = cardEle[0];
                    string cardSuit = cardEle[1];
                    if (cardNumber == "Ace")
                    {
                        cardNumber = "1";
                    }

                    cardSuit = cardSuit.Replace(".png", "");
                    cardSuit = cardSuit.Replace(".bmp", ""); //Erase line later.

                    if (cardSuit == "Clubs")
                    {
                        cardSuit = "Bell";
                    }
                    else if (cardSuit == "Diamonds")
                    {
                        cardSuit = "Moon";
                    }
                    else if (cardSuit == "Hearts")
                    {
                        cardSuit = "Key";
                    }

                    if (cardNumber == "Jack")
                    {
                        cardNumber = "11";
                    }
                    Card current = new Card(int.Parse(cardNumber), cardSuit);
                    deck.Add(current);
                }
            }
            return deck;
        }



        private static Random rng = new Random();

        public static List<Card> Shuffle(List<Card> shuffleDeck)
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

            return shuffleDeck;
            
        }

        private static List<Card> yourHand;
        private static List<Card> oppHand;

        public static List<Card> YourCurrentHand()
        {
            return yourHand;
        }

        public static Card PlayCard(Card chosenCard)
        {
            yourHand.Remove(chosenCard);
            return chosenCard;
        }

        public static Card OpponentPlayCard(Card chosenCard)
        {
            oppHand.Remove(chosenCard);
            return chosenCard;
        }

    }
}
