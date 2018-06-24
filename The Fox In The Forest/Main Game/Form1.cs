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
            pbDeck.Tag = "Deck";

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
            PictureBox pb = (PictureBox)sender;
            Point p = pb.Location;
            int x = p.X;
            int y = p.Y;
            if (x > 200 && x < 700 && y > 280 && y < 460)
            {
                if (pb.Tag.ToString() != "FitF" && !pb.Tag.ToString().Contains("3"))
                {
                    InitiatePlay(sender, e);
                }
                else if (pb.Tag.ToString().Contains("3"))
                {
                    string[] bareChosen = pb.Tag.ToString().Split('_');
                    Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
                    Game.SetPlayerCard(cardChoice);

                    frmDecreeSwitch newSwitch = new frmDecreeSwitch();
                    newSwitch.ShowDialog();
                    if (newSwitch.DialogResult == DialogResult.OK)
                    {
                        Card place = Card.Trump();
                        foreach (Card card in Card.YourCurrentHand())
                        {
                            if (card.CardKey == newSwitch.GetChosen())
                            {

                                Card.SetTrump(card);
                                card.CardNumber = place.CardNumber;
                                card.CardSuit = place.CardSuit;
                                card.CardKey = card.CardNumber + "_" + card.CardSuit + ".png";


                                int i = ilCards.Images.IndexOfKey(newSwitch.GetChosen());
                                pbTrump.Image = ilCards.Images[i];
                                break;
                            }
                        }



                    }
                    InitiatePlay(sender, e);
                }
            }
            else
            {
                pb.Location = initialPoint;
            }
        }

        private void FoxSwitch(Card handCard, Card decreeCard)
        {

            
        }

        private void choosePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ongoingGame == true)
            {
                frmPlayerChangeWarning newWarning = new frmPlayerChangeWarning();
                newWarning.ShowDialog();
                if(newWarning.DialogResult == DialogResult.Yes)
                {
                    frmPlayerChoice newForm = new frmPlayerChoice();
                    newForm.ShowDialog();
                    setNamePosition();
                    //TODO: Have it so if the player chooses a new player, the game will reset.

                }
            }
            else
            {
                frmPlayerChoice newForm = new frmPlayerChoice();
                newForm.ShowDialog();
                setNamePosition();
            }
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
                currentGame = new Game();
                List<string> preCards = new List<string>();
                //TODO: Change how retrieving scores is set up.
                
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


                    UpdateLabels();

                    deck = Game.SetCards(preCards);

                    Card.PopulateHands();

                    RefreshCardDisplay();

                    Card.SetTrump();

                    int a = ilCards.Images.IndexOfKey(Card.Trump().CardKey);
                    pbTrump.Image = ilCards.Images[a];

                    lblDecree.Visible = true;

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

                            var t = Task.Run(async delegate
                            {
                                Random rng = new Random();
                                await Task.Delay(rng.Next(1000, 5000));
                                
                            });
                            t.Wait();
                            TurnTimerCallBack();

                        }

                        
                    }


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

        private void HandFinish()
        {

            lblPlayerTurn.Visible = false;
            lblOppTurn.Visible = false;
            if (Game.Hand())
            {
                //Player wins the trick.
                currentGame.YourTricks++;
                currentGame.YourScore += Game.GetRoundPoints();
                

                
                lblWinTrick.Visible = true;
                if (Game.OpponentChosenCard().CardNumber == 1)
                {
                    Game.SetLead(false);
                }
                else
                {
                    Game.SetLead(true);
                }
                
            }
            else
            {
                //Player loses the trick.
                currentGame.OpponentTricks++;
                currentGame.OpponentScore += Game.GetRoundPoints();
                

                lblLoseTrick.Visible = true;

                if (Game.PlayerChosenCard().CardNumber == 1)
                {
                    Game.SetLead(true);
                }
                else
                {
                    Game.SetLead(false);
                }
                

            }

            Game.ResetRoundPoints();
            lblRoundEnd.Visible = true;

            UpdateLabels();

            var t = Task.Run(async delegate
            {
                await Task.Delay(2000);
            });
            t.Wait();
            //TODO: Get rid of drawing cards. 


            if (!Card.OpponentCurrentHand().Any() && !Card.YourCurrentHand().Any())
            {
                int[] scores = Game.RoundEnd(currentGame.YourTricks, currentGame.OpponentTricks);
                currentGame.YourScore = currentGame.YourScore + scores[0];
                currentGame.OpponentScore = currentGame.OpponentScore + scores[1];

                Player.CurrentPlayer().TotalTricks += currentGame.YourTricks;
                currentGame.YourTricks = 0;
                currentGame.OpponentTricks = 0;

                UpdateLabels();
                
                if (Game.CheckEnd(currentGame.YourScore, currentGame.OpponentScore))
                {
                    if(Game.Winner(currentGame.YourScore, currentGame.OpponentScore))
                        {
                        MessageBox.Show("You've won!");
                        Player.CurrentPlayer().TotalWins++;
                    }
                    else
                    {
                        MessageBox.Show("You've lost...");
                        Player.CurrentPlayer().TotalLosses++;
                    }

                    ongoingGame = false;
                    

                }
                else
                {
                    deck.Clear();
                    
                    List<string> preCards = new List<string>();

                    foreach (string card in ilCards.Images.Keys)
                    {
                        preCards.Add(card);
                    }

                    deck = Game.SetCards(preCards);

                    Card.SetTrump();

                    Card.PopulateHands();


                    Card.SetTrump();

                    int a = ilCards.Images.IndexOfKey(Card.Trump().CardKey);
                    pbTrump.Image = ilCards.Images[a];

                    lblDecree.Visible = true;


                }

            }

            RefreshCardDisplay();

            lblRoundEnd.Visible = false;

            lblLoseTrick.Visible = false;
            lblWinTrick.Visible = false;



            pbPlayerCard.Image = null;
            pbOppCard.Image = null;
            lblOppCard.Visible = false;
            lblPlayerCard.Visible = false;

            Game.SetOpponentCard(null);

            if (Game.PlayerLead())
            {
                lblPlayerTurn.Visible = true;
                Game.SetTurn(true);
            }
            else
            {
                Game.SetTurn(false);
                lblOppTurn.Visible = true;
                var think = Task.Run(async delegate
                {
                    Random rng = new Random();
                    await Task.Delay(rng.Next(1000, 5000));
                });
                think.Wait();
                TurnTimerCallBack();
            }

            

        }

        private void CompThink()
        {
            var think = Task.Run(async delegate
                {
                    Random rng = new Random();
                    await Task.Delay(rng.Next(1000, 5000));
                });
                think.Wait();
        }

        private void InitiatePlay(object sender, EventArgs e)
        {
            PictureBox loc = (sender as PictureBox);
            //Point p = loc.Location;
            //int x = p.X;
            //int y = p.Y;
            //if (x > 200 && x < 700 && y > 280 && y < 460)
            //{
            
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

                        HandFinish();
   
                        }
                        
                        
                    }
                
            //}
            //else
            //{
            //    if (loc.Tag.ToString() != "FitF")
            //    {
            //        loc.Location = initialPoint;
            //    }
            //}

        }

        //public void OppTurnTimer()
        //{

        //    Random rand = new Random();

        //    int waitTime = rand.Next(1000, 4000);
        //    int elTime = waitTime / 4;
        //    System.Timers.Timer turnTimer = new System.Timers.Timer(waitTime);
        //    System.Timers.Timer elTimer = new System.Timers.Timer(elTime);

        //    turnTimer.AutoReset = false;
        //    elTimer.Elapsed += EllipsisTimerCallback;
        //    //turnTimer.Elapsed += TurnTimerCallBack;
        //    turnTimer.Enabled = true;
        //    elTimer.Enabled = true;



        //}

        //public void CompThink()
        //{
        //    Random rng = new Random();
        //    DateTime thinking = DateTime.Now.AddSeconds(rng.Next(1, 5));
        //    //int a = 1;
        //    while (DateTime.Now < thinking)
        //    {
        //        //a++;
        //        //a--;
        //    }
        //}

        private void UpdateLabels()
        {       //Code to update the scoring labels.
            lblTricks.Text = currentGame.YourTricks.ToString();
            lblOppTricks.Text = currentGame.OpponentTricks.ToString();

            lblScore.Text = currentGame.YourScore.ToString();
            lblOppScore.Text = currentGame.OpponentScore.ToString();
        }


        public void TurnTimerCallBack()
        {
            try
            {
                //Timer is set off, so the AI takes its turn.
               Card oppChoice = AI.TakeTurn();

                if (oppChoice.CardNumber == 3)
                {
                    Card.SetTrump(AI.ChangeDecree());
                }

                        
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
                    HandFinish();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //public static int dotx = 727;
        //public static int dotNum = 0;
        //private void EllipsisTimerCallback(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    //TODO: The turn timer works, but the ellipsis timer to show the AI "thinking" isn't quite working.
        //    Label dot = new Label();
        //    dot.Text = ".";
        //    dot.Font = new Font("Palatino Linotype", 16, FontStyle.Regular);
        //    dot.Location = new Point(dotx, 128);
        //    dotNum++;
        //    dotx += 15;
        //    this.Controls.Add(dot);
            
        //    if (dotNum == 3)
        //    {
        //        dotx = 727;
        //        dotNum = 0;
        //    }
        //}


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
                pbScoring.Tag = "FitF";
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

            newForm.Show();
        }

        private void RefreshCardDisplay()
        {

            foreach(Control ctrl in this.Controls.OfType<PictureBox>().ToList())
            {
                
                if (ctrl.Tag.ToString().Contains("Bell") || ctrl.Tag.ToString().Contains("Key") || ctrl.Tag.ToString().Contains("Moon"))
                {
                    this.Controls.Remove(ctrl);
                }
            }

            int left = 53; //10
            int top = 529; //10
            int row = 0;
            foreach (Card card in Card.YourCurrentHand())
            {

                string cardFile = card.CardKey;
                foreach (string cardImage in ilCards.Images.Keys)
                {

                    if (cardFile == cardImage)
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
                        break;
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
                newCard.Tag = "oppCard_" + card.CardKey;


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
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCredits newForm = new frmCredits();
            newForm.Show();
        }
    }
}
