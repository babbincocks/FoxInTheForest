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
    public partial class frmDiscardSelect : Form
    {
        public frmDiscardSelect()
        {
            InitializeComponent();
        }
        frmGame a = new frmGame();
        private void frmDiscardSelect_Load(object sender, EventArgs e)
        {
            int leftPos = 55;
            int topPos = 66;
            int row = 1;
            foreach(Card card in Card.YourCurrentHand())
            {
                

                //Images MIGHT not load with this new form.
                frmGame a = new frmGame();

                foreach(string file in a.ilCards.Images.Keys)
                {
                    if(file == card.CardKey)
                    {
                        int b = a.ilCards.Images.IndexOfKey(file);
                        PictureBox newCard = new PictureBox();
                        newCard.Size = new Size(50, 70);
                        newCard.Location = new Point(leftPos, topPos);
                        newCard.SizeMode = PictureBoxSizeMode.Zoom;
                        newCard.Tag = card.CardNumber + "_" + card.CardSuit;
                        leftPos += 54;
                        if (row > 7)
                        {
                            topPos += 70;
                            leftPos -= 378;
                            row = 0;
                        }
                        newCard.Image = a.ilCards.Images[b];
                        this.Controls.Add(newCard);
                        newCard.BringToFront();
                        newCard.MouseDoubleClick += new MouseEventHandler(CardSelect);
                        row++;
                    }
                }
            }
        }
        private string chosenCard = null;

        public string GetChosen()
        {
            return chosenCard;
        }
        
        public void CardSelect(object sender, MouseEventArgs e)
        {
            PictureBox currentCard = (PictureBox)sender;
            string[] bareChosen = currentCard.Tag.ToString().Split('_');
            Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
            chosenCard = cardChoice.CardKey;
            //int c = 0;
            //foreach (Image card in a.ilCards.Images)
            //{
                
                
            //    if(card == currentCard.Image)
            //    {
            //        chosenCard = a.ilCards.Images.Keys[c];
            //        break;
            //    }
            //    c++;
            //}
            this.DialogResult = DialogResult.OK;
        }
    }
}
