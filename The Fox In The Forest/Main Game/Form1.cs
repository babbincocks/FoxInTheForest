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
        Player curPlayer = Player.CurrentPlayer();
         Card trump = new Card(1, "Bell");
        
        public frmGame()
        {
            InitializeComponent();
        }

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


        

        private void frmGame_Load(object sender, EventArgs e)
        {
            pbDeck.Image = ilCards.Images["Owl-Key_Card.png"];


            foreach (string card in ilCards.Images.Keys)
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

                    Card current = new Card(int.Parse(cardNumber), cardSuit);
                    allCards.Add(current);
                }


                
            }



        }

        private void rulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRules newForm = new frmRules();

            newForm.ShowDialog();
        }

        private void choosePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayerChoice newForm = new frmPlayerChoice();
            newForm.ShowDialog();
            //refer to csv and get name if created, or get from list box if selected

            curPlayer = Player.CurrentPlayer();
            if (curPlayer.Name.Length >= 5)
            {
                lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
                lblName.Location = new Point(699,479);
            }
            else
            {
                lblName.Text = curPlayer.Name + "'s Score";
                lblName.Location = new Point(699, 479);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
