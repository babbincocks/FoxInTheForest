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


        

        public Card(int cardNumber, string cardSuit)
        {
            number = cardNumber;
            suit = cardSuit;
        }

        public int cardNumber
        {
            get { return number; }
            set { number = value; }
        }

        public string cardSuit
        {
            get { return suit; }
            set { suit = value; }
        }

        public Card(int cardNumber)
        {

            if (cardNumber == 1)
            {

            }
            else if (cardNumber == 3)
            {

            }
            else if (cardNumber == 5)
            {

            }
            else if (cardNumber == 7)
            {

            }
            else if (cardNumber == 9)
            {

            }
            else if (cardNumber == 11)
            {

            }
            else
            {

            }
        }

        public void Shuffle(List<Card> deck)
        {

        }
    }
}
