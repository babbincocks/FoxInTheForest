using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Game
{
    public partial class frmGame : Form
    {
        int x = 0;
        int y = 0;
        bool drag = false;
        List<Card> allCards = new List<Card>();

        private void picMouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            drag = true;
        }

        private void picMouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                PictureBox pb = (PictureBox)sender;

                pb.Top += e.Y - y;
                pb.Left += e.X - x;
                pb.BringToFront();
                
            }
        }

        private void picMouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }


        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            pbDeck.Image = ilCards.Images["Owl-Key_Card.png"];


            int c = 0;
            foreach (string card in ilCards.Images.Keys)
            {
                if (!card.Contains("Owl"))
                {
                    string[] cardEle = card.Split('_');
                    string cardNumber = cardEle[0];
                    string cardSuit = cardEle[1];
                    cardSuit = cardSuit.Replace(".png", "");
                    Card current = new Card(int.Parse(cardNumber), cardSuit);
                    allCards.Add(current);
                }


                
            }



        }

    }
}
