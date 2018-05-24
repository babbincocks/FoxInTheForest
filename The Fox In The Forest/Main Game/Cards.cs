using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class Card
    {
        int number;
        string suit;

        public Card Trump(string suit, int number)
        {
            Card trump = new Card(number, suit);

            return trump;
        }
        
        public Card()
        {
            number = 1;
            suit = "Bell";
        }

        public Card(int cardNumber, string cardSuit)
        {
            number = cardNumber;
            suit = cardSuit;
        }

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

        public void Effect(int yourCard, int oppCard)
        {

            if (yourCard == 1)
            {

            }
            else if (yourCard == 3)
            {

            }
            else if (yourCard == 5)
            {

            }
            else if (yourCard == 7)
            {

            }
            else if (yourCard == 9)
            {
                if (oppCard != 9)
                {

                }
            }
            else if (yourCard == 11)
            {

            }
            else
            {

            }
        }

        private static List<Card> deck;

        public static List<Card> Deck()
        {
            return deck;
        }

        public static List<Card> PopulateDeck(List<string> cards)
        {
            deck = new List<Card>();

            foreach (string card in cards)
            {
                if (!card.Contains("Owl"))
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
    }
}
