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

            foreach (string card in ilCards.Images.Keys)
            {
                preCards.Add(card);
            }

            deck = Card.PopulateDeck(preCards);

            deck = Card.Deck();

            deck = Card.Shuffle(deck);


        }

        PictureBox pbScoring = new PictureBox();
        private void showScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pbScoring.IsHandleCreated)
            {
                this.pbScoring.Show();
                pbScoring.Location = new Point(654, 247);
            }
            else
            {
                pbScoring.Location = new Point(654, 247);
                pbScoring.Size = new Size(135, 192);
                pbScoring.MouseDown += new MouseEventHandler(picMouseDown);
                pbScoring.MouseMove += new MouseEventHandler(picMouseMove);
                pbScoring.MouseUp += new MouseEventHandler(picMouseUp);
                pbScoring.Image = ilCards.Images["FitFScoreRef.png"];
                pbScoring.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pbScoring);
                
            }
            this.showScoringToolStripMenuItem.Visible = false;
            this.hideScoringToolStripMenuItem.Visible = true;


        }

        private void hideScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(pbScoring))
            {
                this.pbScoring.Hide();
            }
            this.hideScoringToolStripMenuItem.Visible = false;
            this.showScoringToolStripMenuItem.Visible = true;
            

            
        }

        private void rulesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRules newForm = new frmRules();

            newForm.ShowDialog();
        }
    }
}
