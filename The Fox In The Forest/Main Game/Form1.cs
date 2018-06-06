using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        int loadBefore = 0;
        bool ongoingGame = false;
        Game newGame;

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            this.hideScoringToolStripMenuItem.Visible = false;

            pbDeck.Image = ilCards.Images["Owl-Key_Card.png"];

            if(loadBefore != 0)
            {
                setNamePosition();
            }

            loadBefore++;
        }

         Player curPlayer = Player.CurrentPlayer();
        
        

        int x = 0;
        int y = 0;
        bool drag = false;
        List<Card> deck = new List<Card>();

        private void picMouseDown(object sender, MouseEventArgs e)
        {
            if (Game.PlayerTurn())
            {
                x = e.X;
                y = e.Y;
                drag = true;
            }
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
            InitiatePlay(sender, e);
            
        }



        private void choosePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayerChoice newForm = new frmPlayerChoice();
            newForm.ShowDialog();
            setNamePosition();
            //curPlayer = Player.CurrentPlayer();
            //if (curPlayer.Name.Length >= 5 && curPlayer.Name.Length < 10)
            //{
            //    lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
            //    lblName.Location = new Point(746,479);
            //}
            //else if (curPlayer.Name.Length >= 10)
            //{
            //    lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
            //    lblName.Location = new Point(731, 479);
            //}
            //else
            //{
            //    lblName.Text = curPlayer.Name + "'s Score";
            //    lblName.Location = new Point(735, 503);
            //}
            
        }

        private void setNamePosition()
        {

            curPlayer = Player.CurrentPlayer();
            if (curPlayer.Name.Length >= 5 && curPlayer.Name.Length < 10)
            {
                lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
                lblName.Location = new Point(746, 479);
            }
            else if (curPlayer.Name.Length >= 10)
            {
                lblName.Text = curPlayer.Name + "'s" + Environment.NewLine + "Score";
                lblName.Location = new Point(731, 479);
            }
            else
            {
                lblName.Text = curPlayer.Name + "'s Score";
                lblName.Location = new Point(735, 503);
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
            if (ongoingGame != true)
            {
                List<string> preCards = new List<string>();
                try
                {
                    if (Player.CurrentPlayer().Name == "Guest")
                    {
                        frmNamePrompt newPrompt = new frmNamePrompt();
                        newPrompt.ShowDialog();
                        if (newPrompt.DialogResult == DialogResult.OK)
                        {
                            frmPlayerChoice newForm = new frmPlayerChoice();
                            newForm.ShowDialog();
                            setNamePosition();
                        }
                    }
                    foreach (string card in ilCards.Images.Keys)
                    {
                        preCards.Add(card);
                    }

                    newGame = new Game();
                    ongoingGame = true;

                    deck = Game.SetCards(preCards);

                    Card.PopulateHands();



                    int left = 53; //10
                    int top = 529; //10
                    int row = 0;
                    foreach (Card card in Card.YourCurrentHand())
                    {

                        string cardFile = card.CardKey;
                        foreach (string cardImage in ilCards.Images.Keys)
                        {
                            
                            if (card.CardKey == cardImage)
                            {
                                
                                PictureBox newCard = new PictureBox();
                                int index = ilCards.Images.IndexOfKey(cardImage);
                                newCard.Image = ilCards.Images[index];
                                newCard.SizeMode = PictureBoxSizeMode.Zoom;
                                newCard.Size = new Size(70, 100);
                                newCard.Location = new Point(left, top);
                                newCard.Tag = card.CardNumber + "_" + card.CardSuit;
                                
                                if (row == 0)
                                {
                                    top += 110;
                                    left += 45;
                                    row++;
                                }
                                else
                                {
                                    top -= 110;
                                    left += 45;
                                    row--;
                                }
                                
                                this.Controls.Add(newCard);
                                newCard.MouseDown += new MouseEventHandler(picMouseDown);
                                newCard.MouseMove += new MouseEventHandler(picMouseMove);
                                newCard.MouseUp += new MouseEventHandler(picMouseUp);
                                //newCard.LocationChanged += new EventHandler(InitiatePlay);

                            }
                        }
                    }

                    left = 42;
                    top = 50;
                    row = 0;
                    foreach (Card card in Card.OpponentCurrentHand())
                    {
                        PictureBox newCard = new PictureBox();
                        
                        newCard.Image = ilCards.Images[0];
                        newCard.SizeMode = PictureBoxSizeMode.Zoom;
                        newCard.Size = new Size(70, 100);

                        
                        
                        newCard.Location = new Point(left, top);

                        
                       
                        if (row == 0)
                        {
                            top += 110;
                            left += 45;
                            row++;
                        }
                        else
                        {
                            top -= 110;
                            left += 45;
                            row--;
                        }

                        this.Controls.Add(newCard);

                    }

                    Card.SetTrump();

                    int a = ilCards.Images.IndexOfKey(Card.Trump().CardKey);
                    pbTrump.Image = ilCards.Images[a];

                    Label decreeLabel = new Label();
                    decreeLabel.Location = new Point(391, 304);
                    decreeLabel.Font = new Font("Palatino Linotype", 10, FontStyle.Regular);
                    decreeLabel.Text = "Decree Card";
                    decreeLabel.Size = new Size(85, 18);
                    this.Controls.Add(decreeLabel);
                    decreeLabel.Show();


                    ongoingGame = true;

                    //Asks user to call heads or tails to see who leads; the form returns Yes if they choose Heads, No if Tails.
                    frmCoinCall coin = new frmCoinCall();
                    coin.ShowDialog();
                    int result = -1;
                    if(coin.DialogResult == DialogResult.Yes)
                    {
                        result = 1;
                    }
                    else if ((coin.DialogResult == DialogResult.No))
                    {
                        result = 0;
                    }
                    if (result != -1)
                    {
                        //A true result means the user's call matches the flip result, so the player goes first. False result means the
                        //user's call did not match the flip result, so the opponent goes first.
                        bool coinWin = Game.Flip(result);

                        if (coinWin == true)
                        {
                            Label newLabel = new Label();
                            newLabel.Location = new Point(458, 497);
                            newLabel.Font = new Font("Palatino Linotype", 12, FontStyle.Regular);
                            newLabel.Text = "You won the coin flip; it's your turn.";
                            newLabel.Size = new Size(252, 22);
                            this.Controls.Add(newLabel);
                            newLabel.Show();
                            

                        }
                        else
                        {
                            Label newLabel = new Label();
                            newLabel.Location = new Point(387, 497);
                            newLabel.Font = new Font("Palatino Linotype", 12, FontStyle.Regular);
                            newLabel.Size = new Size(323, 22);
                            newLabel.Text = "You lost the coin flip; it's your opponent's turn.";
                            this.Controls.Add(newLabel);
                            newLabel.Show();
                            OppTurnTimer();
                        }

                        Game.SetLead(coinWin);
                        Game.SetTurn(coinWin);
                    }


                    //if (Game.CheckEnd(newGame.YourScore, newGame.OpponentScore))
                    //{
                    //    if (Game.Winner(newGame.YourScore, newGame.OpponentScore))
                    //    {
                    //        MessageBox.Show("You win!");
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("You lost...");
                    //    }
                    //}



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                //Alert if the player tries to start a new game while one is ongoing.
                frmNewGameAlert newForm = new frmNewGameAlert();
                newForm.ShowDialog();
                if(newForm.DialogResult == DialogResult.Yes)
                {
                    //TODO: Reset everything, add a loss to the player's records, and start a new game.
                }
            }
            
        }

        private void InitiatePlay(object sender, EventArgs e)
        {
            PictureBox loc = (sender as PictureBox);
            Point p = loc.Location;
            int x = p.X;
            int y = p.Y;
            if (x > 200 && x < 700)
            {
                if (y > 280 && y < 460)
                {
                    string[] bareChosen = loc.Tag.ToString().Split('_');
                    Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
                    Card.PlayCard(cardChoice);

                    PictureBox playedCard = new PictureBox();
                    int index = ilCards.Images.IndexOfKey(loc.Tag + ".bmp");
                    playedCard.Image = ilCards.Images[index];
                    playedCard.SizeMode = PictureBoxSizeMode.Zoom;
                    playedCard.Size = new Size(70, 100);
                    playedCard.Location = new Point(322, 332);
                    this.Controls.Add(playedCard);

                    Label newLabel = new Label();
                    newLabel.Location = new Point(320, 429);
                    newLabel.Font = new Font("Palatino Linotype", 11, FontStyle.Regular);
                    newLabel.Text = "Your Card";
                    newLabel.Size = new Size(77, 20);
                    this.Controls.Add(newLabel);

                    this.Controls.Remove(loc);
                    Game.SetTurn(false);
                    OppTurnTimer();
                }
            }

        }


        public static void OppTurnTimer()
        {
            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Random rand = new Random();
            int waitTime = rand.Next(1500, 5500);
            System.Timers.Timer turnTimer = new System.Timers.Timer(waitTime);
            // Wait for the user to hit <Enter>
            //TODO:Get it so when the timer goes off, "AI.TakeTurn()" starts.
            turnTimer.Elapsed += TimerCallback();

        }

        private static void TimerCallback()
        {
            // Display the date/time when this method got called.
            AI.TakeTurn();
            // Force a garbage collection to occur for this demo.
        }


        //A picture box item for if the player wants to see a reference on how scoring works.
        PictureBox pbScoring = new PictureBox();
        private void showScoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the scoring list object has handles on it (and thus has been shown before), it shows it, and sets its position.
            if (pbScoring.IsHandleCreated)
            {
                this.pbScoring.Show();
                pbScoring.Location = new Point(586, 295);
            }
            else
            {
                //Otherwise, it adds all of the different aspects that the picture box needs and makes it a part of the form.
                pbScoring.Location = new Point(586, 295);
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
