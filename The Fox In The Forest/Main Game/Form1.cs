using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        Game currentGame;

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
        Point initialPoint;
        List<Card> deck = new List<Card>();

        private void picMouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            initialPoint = pic.Location;
            if (Game.PlayerTurn())
            {
                x = e.X;
                y = e.Y;
                //initialPoint = this.FindForm().PointToClient(this.Parent.PointToScreen(this.Location));
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
                //TODO: Change how retrieving scores is set up.
                lblOppScore.Text = Game.OpponentScore();
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

                    currentGame = new Game();
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

                    lblDecree.Visible = true;


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
                            
                            lblWinFlip.Show();

                            Game.SetLead(coinWin);
                            Game.SetTurn(coinWin);

                        }
                        else
                        {
                            
                            lblLoseFlip.Show();

                            Game.SetLead(coinWin);
                            Game.SetTurn(coinWin);

                            //Random rng = new Random();
                            //Thread.Sleep(rng.Next(1000, 4000));

                            //CompThink();

                            //OppTurnTimer();

                            var t = Task.Run(async delegate
                            {
                                Random rng = new Random();
                                await Task.Delay(rng.Next(1000, 5000));
                                
                            });
                            t.Wait();
                            TurnTimerCallBack();

                        }

                        
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
            if (x > 200 && x < 700 && y > 280 && y < 460)
            {
            
                    if (loc.Tag != null)
                    {

                        string[] bareChosen = loc.Tag.ToString().Split('_');
                        Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
                        Game.SetPlayerCard(cardChoice);
                        Card.PlayCard(cardChoice);
                        
                        int index = ilCards.Images.IndexOfKey(cardChoice.CardKey);
                        pbPlayerCard.Image = ilCards.Images[index];
                        lblPlayerCard.Visible = true;

                        this.Controls.Remove(loc);

                        if (Game.PlayerLead())
                        {
                            Game.SetTurn(false);
                        lblPlayerTurn.Visible = false;
                        lblWinFlip.Visible = false;
                        lblLoseFlip.Visible = false;
                        lblOppTurn.Visible = true;
                        //int a = 1;
                        //    while(a < 40)
                        //{
                        //    a++;
                        //}
                        //Random rng = new Random();
                        //int a = rng.Next(1000, 4000);
                        //Thread.Sleep(a);
                        //CompThink();
                        //OppTurnTimer();
                        var t = Task.Run(async delegate
                        {
                            Random rng = new Random();
                            await Task.Delay(rng.Next(1000, 5000));
                        });
                        t.Wait();
                        TurnTimerCallBack();
                    }
                        //If the player did go first, that means both have put a card down by now, so the result is checked.
                        else if (!Game.PlayerLead())
                        {
                            if (Game.Hand(Game.PlayerChosenCard(), Game.OpponentChosenCard(), Game.PlayerLead()))
                            {
                                //Player wins the trick.
                                Game.YourTricks++;
                            lblPlayerTurn.Visible = false;
                            lblOppTurn.Visible = false;
                            lblWinTrick.Visible = true;
                            }
                            else
                            {
                                //Player loses the trick.
                                Game.OpponentTricks++;
                            lblPlayerTurn.Visible = false;
                            lblOppTurn.Visible = true;
                            lblLoseTrick.Visible = true;
                            }
                        }
                        
                        
                    }
                
            }
            else
            {
                loc.Location = initialPoint;
            }

        }

        public void OppTurnTimer()
        {

            Random rand = new Random();

            int waitTime = rand.Next(1000, 4000);
            int elTime = waitTime / 4;
            System.Timers.Timer turnTimer = new System.Timers.Timer(waitTime);
            System.Timers.Timer elTimer = new System.Timers.Timer(elTime);

            turnTimer.AutoReset = false;
            elTimer.Elapsed += EllipsisTimerCallback;
            //turnTimer.Elapsed += TurnTimerCallBack;
            turnTimer.Enabled = true;
            elTimer.Enabled = true;



        }

        public void CompThink()
        {
            Random rng = new Random();
            DateTime thinking = DateTime.Now.AddSeconds(rng.Next(1, 5));
            //int a = 1;
            while (DateTime.Now < thinking)
            {
                //a++;
                //a--;
            }
        }


        public void TurnTimerCallBack()
        {
            try
            {
                //Timer is set off, so the AI takes its turn.
               Card oppChoice = AI.TakeTurn();

                        
                int index = ilCards.Images.IndexOfKey(oppChoice.CardKey);
                pbOppCard.Image = ilCards.Images[index];
                lblOppCard.Visible = true;

                //If the player didn't go first, it's assumed that the player now needs to go, so now they can.
                if (!Game.PlayerLead())
                {
                    Game.SetTurn(true);
                    lblPlayerTurn.Visible = false;
                    lblWinFlip.Visible = false;
                    lblLoseFlip.Visible = false;
                    lblOppTurn.Visible = false;
                    lblPlayerTurn.Visible = true;
                }
                //If the player did go first, that means both have put a card down by now, so the result is checked.
                else if (Game.PlayerLead())
                {
                    if (Game.Hand(Game.PlayerChosenCard(), Game.OpponentChosenCard(), Game.PlayerLead()))
                    {
                        //Player win trick.
                        Game.YourTricks++;
                        lblPlayerTurn.Visible = false;
                        lblOppTurn.Visible = false;
                        lblWinTrick.Visible = true;
                    }
                    else
                    {
                        //Player lose trick.
                        Game.OpponentTricks++;
                        lblPlayerTurn.Visible = false;
                        lblOppTurn.Visible = true;
                        lblLoseTrick.Visible = true;
                        
                    }
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static int dotx = 727;
        public static int dotNum = 0;
        private static void EllipsisTimerCallback(Object source, System.Timers.ElapsedEventArgs e)
        {
            //TODO: The turn timer works, but the ellipsis timer to show the AI "thinking" isn't quite working.
            Label dot = new Label();
            dot.Text = ".";
            dot.Font = new Font("Palatino Linotype", 16, FontStyle.Regular);
            dot.Location = new Point(dotx, 128);
            dotNum++;
            dotx += 15;
            
            if (dotNum == 3)
            {
                dotx = 727;
                dotNum = 0;
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
