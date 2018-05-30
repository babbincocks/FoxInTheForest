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

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            this.hideScoringToolStripMenuItem.Visible = false;

            pbDeck.Image = ilCards.Images["Owl-Key_Card.png"];

            

        }

        Player curPlayer = Player.CurrentPlayer();
         Card trump = new Card(1, "Bell");
        
        

        int x = 0;
        int y = 0;
        bool drag = false;
        List<Card> deck = new List<Card>();

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


        

        



        private void choosePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayerChoice newForm = new frmPlayerChoice();
            newForm.ShowDialog();

            curPlayer = Player.CurrentPlayer();
            if (curPlayer.Name.Length >= 5 && curPlayer.Name.Length < 10)
            {
                lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
                lblName.Location = new Point(710,455);
            }
            else if (curPlayer.Name.Length >= 10)
            {
                lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
                lblName.Location = new Point(695, 455);
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

        private void sortCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> preCards = new List<string>();
            try
            {
                foreach (string card in ilCards.Images.Keys)
                {
                    preCards.Add(card);
                }

                Game newGame = new Game();

                deck = Game.SetCards(preCards);

                if(Game.CheckEnd(newGame.YourScore, newGame.OpponentScore))
                {
                    if(Game.Winner(newGame.YourScore, newGame.OpponentScore))
                    {
                        MessageBox.Show("You win!");
                    }
                    else
                    {
                        MessageBox.Show("You lost...");
                    }
                }
                else
                {

                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //A picture box item for if the player wants to see a reference on how scoring works.
        PictureBox pbScoring = new PictureBox();
        private void showScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the scoring list object has handles on it (and thus has been shown before), it shows it, and sets its position.
            if (pbScoring.IsHandleCreated)
            {
                this.pbScoring.Show();
                pbScoring.Location = new Point(654, 247);
            }
            else
            {
                //Otherwise, it adds all of the different aspects that the picture box needs and makes it a part of the form.
                pbScoring.Location = new Point(654, 247);
                pbScoring.Size = new Size(135, 192);
                pbScoring.MouseDown += new MouseEventHandler(picMouseDown);
                pbScoring.MouseMove += new MouseEventHandler(picMouseMove);
                pbScoring.MouseUp += new MouseEventHandler(picMouseUp);
                pbScoring.Image = ilCards.Images["FitFScoreRef.png"];
                pbScoring.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pbScoring);
                
            }
            //Finally, the "Show Scoring" button is hidden, and the "Hide Scoring" button is shown.
            this.showScoringToolStripMenuItem.Visible = false;
            this.hideScoringToolStripMenuItem.Visible = true;


        }

        private void hideScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This button shouldn't be able to be clicked until the "Show Scoring" button is clicked, but just in case, it
            //checks to see if the control has been created; if so, it hides it.
            if (this.Controls.Contains(pbScoring))
            {
                this.pbScoring.Hide();
            }
            //Button visibility is then switched.
            this.hideScoringToolStripMenuItem.Visible = false;
            this.showScoringToolStripMenuItem.Visible = true;
            

            
        }

        private void rulesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRules newForm = new frmRules();

            newForm.ShowDialog();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

        }
    }
}
