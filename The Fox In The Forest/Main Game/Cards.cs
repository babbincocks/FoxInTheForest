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

        public void Shuffle(List<Card> deck)
        {

        }
    }
}
