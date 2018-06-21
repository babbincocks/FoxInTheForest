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
        {
            trump = deck.Last();
            deck.RemoveAt(deck.Count - 1);
        }

        public Card()
        {

        }

        //Constructor that sets the values of a card.
        public Card(int cardNumber, string cardSuit)
        {
            number = cardNumber;
            suit = cardSuit;
            cardKey = cardNumber + "_" + cardSuit + ".bmp";
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
        }

        //As odd-numbered cards have special effects that can affect a play, it needs to be handled somewhere. Maybe here?

            //11 is handled in the AI class, if the player plays it at least.
        public static int Effect(Card yourCard, Card oppCard)
        {
            int result = 0;


            if (yourCard.CardNumber == 1)
            {
                if (oppCard.CardNumber > 1 && oppCard.CardSuit == yourCard.CardSuit)
                {
                    result = 3;
                }
                //else if ()
                //{

                //}
            }
            else if (yourCard.CardNumber == 3)
            {
                FoxSwitch();
            }
            else if (yourCard.CardNumber == 5)
            {
                //This might not work, actions might need to be switched over to the new discard form.
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
                        c[1] = c[1].Replace(".bmp", "");
                        Card b = new Card(int.Parse(c[0]), c[1]);
                        if (b.CardKey == card.CardKey)
                        {
                            Discard(card);
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
                     else if (oppCard.CardNumber == 9)
                    {
                        result = 0;
                    }
                }
                else if (oppCard.CardSuit != trump.CardSuit)
                {
                    result = 1;
                }
                
            }
            else if (yourCard.CardNumber == 11)
            {

            }

            return result;
        }

        public static void FoxSwitch()
        {

        }



        //Variable that will be the current state of the deck, and another for the used cards to go.
        private static List<Card> deck;
        private static List<Card> discard = new List<Card>();

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
                if (!card.Contains("Owl") && !card.Contains("FitF"))
                {
                    string[] cardEle = card.Split('_');
                    string cardNumber = cardEle[0];
                    string cardSuit = cardEle[1];

                    cardSuit = cardSuit.Replace(".png", "");
                    cardSuit = cardSuit.Replace(".bmp", ""); //Erase line later.

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
            yourHand.Remove(chosenCard);
            return chosenCard;
            
        }

        public static Card OpponentPlayCard(Card chosenCard)
        {
            oppHand.Remove(chosenCard);
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
