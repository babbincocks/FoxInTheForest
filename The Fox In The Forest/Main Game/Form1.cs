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

        //Variable for checking if this form has been loaded before. Used for appearances when a player loads a profile.
        int loadBefore = 0;

        //Variables for determining whether a game is ongoing or not.
        bool ongoingGame = false;
        Game currentGame;

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            this.hideScoringToolStripMenuItem.Visible = false;

            //Load an image for the deck.
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

        //List to hold what cards can be played if the AI plays an 11.
        List<Card> playerElevenChoices = new List<Card>();

        private void picMouseDown(object sender, MouseEventArgs e)
        {       //Code for initial event when a card is clicked.

            
            PictureBox pic = (PictureBox)sender;

            //Variable to determine whether the card that's being clicked is fine to play or not. If false, it's good. 
            bool followsuit = false;
            
            //Register where the card started, in case something goes wrong; that way, it'll just go back to where it was before.
            initialPoint = pic.Location;

            //So nothing will activate if it's not the player's turn.
            if (Game.PlayerTurn())
            {
                //If the player is going second, they will most likely need to follow suit. But if they lead, they won't have any restrictions.
                if (!Game.PlayerLead())
                {
                    //All picture boxes have tags containing what card they are. If it's of the same suit as the opponent's choice, and the
                    //opponent didn't play an 11, it's definitely good.
                    if (pic.Tag.ToString().Contains(Game.OpponentChosenCard().CardSuit) && !playerElevenChoices.Any())
                    {
                        followsuit = false;
                    }
                    //If the AI played an 11, this would kick in.
                    else if (playerElevenChoices.Any())
                    {
                        foreach(Card card in playerElevenChoices)
                        {
                            string cardcut = card.CardKey.Replace(".png", "");
                            if(cardcut == pic.Tag.ToString())
                            {
                                followsuit = false;
                                break;

                            }
                            else
                            {
                                followsuit = true;
                            }
                        }
                    }
                    else if (!pic.Tag.ToString().Contains(Game.OpponentChosenCard().CardSuit))
                    {
                        //Goes through the player's hand to see if they have a card to follow suit with.
                        foreach (Card card in Card.YourCurrentHand())
                        {
                            if (card.CardSuit == Game.OpponentChosenCard().CardSuit)
                            {
                                followsuit = true;
                                break;
                            }


                        }
                    }

                }
            
                
                //Allows the picturebox to be moved if nothing changed the state of followsuit.
                if (!followsuit)
                {

                    x = e.X;
                    y = e.Y;
                    drag = true;
                }
            }
        }

        private void picMouseMove(object sender, MouseEventArgs e)
        {
            //Standard pic move code.
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
            //If it's within a certain area and isn't the scoring sheet reference nor a 3 card, it plays the card right away.
            if (x > 200 && x < 700 && y > 280 && y < 460)
            {
                if (pb.Tag.ToString() != "FitF" && !pb.Tag.ToString().Contains("3"))
                {
                    InitiatePlay(sender, e);
                }
                //If it's a 3 card, a form is opened, so the user can choose a card to switch the decree card with.
                else if (pb.Tag.ToString().Contains("3"))
                {
                    string[] bareChosen = pb.Tag.ToString().Split('_');
                    Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
                    Game.SetPlayerCard(cardChoice);

                    frmDecreeSwitch newSwitch = new frmDecreeSwitch();
                    newSwitch.ShowDialog();
                    if (newSwitch.DialogResult == DialogResult.OK)
                    {
                        Card place = new Card(Card.Trump().CardNumber, Card.Trump().CardSuit);
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
                    //After that, the play is determined.
                    InitiatePlay(sender, e);
                }
            }
            else
            {
                //If it's not within the proper area, the card's position is reset.
                pb.Location = initialPoint;
            }
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
                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        RestartGame();
                    }

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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (!ongoingGame)
            {
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
                    //Since the game won't be going on, it will "restart" the game by really just starting the game.
                    RestartGame();


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
                    
                    RestartGame();
                }
            }
            
        }

        private void HandFinish()
        {

            lblPlayerTurn.Visible = false;
            lblOppTurn.Visible = false;
            try
            {
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

                playerElevenChoices.Clear();

                Game.ResetRoundPoints();


                UpdateLabels();

                var t = Task.Run(async delegate
                {
                    await Task.Delay(2000);
                });
                t.Wait();


                if (!Card.OpponentCurrentHand().Any() && !Card.YourCurrentHand().Any())
                {
                    int[] scores = Game.RoundEnd(currentGame.YourTricks, currentGame.OpponentTricks);
                    currentGame.YourScore = currentGame.YourScore + scores[0];
                    currentGame.OpponentScore = currentGame.OpponentScore + scores[1];

                    Player.CurrentPlayer().TotalTricks += currentGame.YourTricks;
                    currentGame.YourTricks = 0;
                    currentGame.OpponentTricks = 0;

                    lblRoundEnd.Visible = true;
                    UpdateLabels();

                    if (Game.CheckEnd(currentGame.YourScore, currentGame.OpponentScore))
                    {
                        if (Game.Winner(currentGame.YourScore, currentGame.OpponentScore))
                        {
                            MessageBox.Show("You've won!");
                            Player.CurrentPlayer().TotalWins++;
                            Player.CurrentPlayer().TotalPoints += currentGame.YourScore;
                        }
                        else
                        {
                            MessageBox.Show("You've lost...");
                            Player.CurrentPlayer().TotalLosses++;
                            Player.CurrentPlayer().TotalPoints += currentGame.YourScore;
                        }

                        ongoingGame = false;
                        pbTrump.Image = ilCards.Images[0];
                        Card.Deck().Clear();
                        Player.UpdatePlayerStats();
                        



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
                        await Task.Delay(rng.Next(1000));
                    });
                    think.Wait();
                    AITurn();
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void RestartGame()
        {
            try
            {
                List<string> preCards = new List<string>();

                if (ongoingGame)
                {
                    Player.CurrentPlayer().TotalLosses++;
                    Player.UpdatePlayerStats();
                    deck.Clear();
                    Card.OpponentCurrentHand().Clear();
                    Card.YourCurrentHand().Clear();
                    UpdateLabels();
                    RefreshCardDisplay();
                    pbPlayerCard.Image = null;
                    pbOppCard.Image = null;
                    pbTrump.Image = null;


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
                if (coin.DialogResult == DialogResult.Yes)
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
                            await Task.Delay(rng.Next(1000));

                        });
                        t.Wait();
                        AITurn();

                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //private void CompThink()
        //{
        //    var think = Task.Run(async delegate
        //        {
        //            Random rng = new Random();
        //            await Task.Delay(rng.Next(1000, 5000));
        //        });
        //        think.Wait();
        //}

        private void InitiatePlay(object sender, EventArgs e)
        {       //This is the code of what happens when the player plays a card.
            try
            {
                PictureBox loc = (sender as PictureBox);
                //Point p = loc.Location;
                //int x = p.X;
                //int y = p.Y;
                //if (x > 200 && x < 700 && y > 280 && y < 460)
                //{

                if (loc.Tag != null)
                {
                    if (loc.Tag.ToString().Contains("3"))
                    {

                        Card.PlayCard(Game.PlayerChosenCard());

                        int index = ilCards.Images.IndexOfKey(Game.PlayerChosenCard().CardKey);
                        pbPlayerCard.Image = ilCards.Images[index];
                        lblPlayerCard.Visible = true;

                        this.Controls.Remove(loc);
                    }
                    else
                    {
                        string[] bareChosen = loc.Tag.ToString().Split('_');
                        Card cardChoice = new Card(int.Parse(bareChosen[0]), bareChosen[1]);
                        Game.SetPlayerCard(cardChoice);
                        Card.PlayCard(cardChoice);

                        int index = ilCards.Images.IndexOfKey(cardChoice.CardKey);
                        pbPlayerCard.Image = ilCards.Images[index];
                        lblPlayerCard.Visible = true;

                        this.Controls.Remove(loc);
                    }


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
                            await Task.Delay(rng.Next(1000));
                        });
                        t.Wait();
                        AITurn();
                    }
                    //If the player did go first, that means both have put a card down by now, so the result is checked.
                    else if (!Game.PlayerLead())
                    {

                        HandFinish();

                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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





        private void UpdateLabels()
        {       //Code to update the scoring labels.
            try
            {
                lblTricks.Text = currentGame.YourTricks.ToString();
                lblOppTricks.Text = currentGame.OpponentTricks.ToString();

                lblScore.Text = currentGame.YourScore.ToString();
                lblOppScore.Text = currentGame.OpponentScore.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void AITurn()
        {       //Code for the opponent taking its turn.
            try
            {
                //Timer is set off, so the AI takes its turn.
               Card oppChoice = AI.TakeTurn();

                if (oppChoice.CardNumber == 3)
                {
                    Card place = new Card(Card.Trump().CardNumber, Card.Trump().CardSuit);
                    Card.SetTrump(AI.ChangeDecree());

                    
                    foreach (Card card in Card.OpponentCurrentHand())
                    {
                        if (card.CardKey == Card.Trump().CardKey)
                        {


                            card.CardNumber = place.CardNumber;
                            card.CardSuit = place.CardSuit;
                            card.CardKey = card.CardNumber + "_" + card.CardSuit + ".png";


                            int i = ilCards.Images.IndexOfKey(Card.Trump().CardKey);
                            pbTrump.Image = ilCards.Images[i];
                            break;
                        }
                    }
                }

                        
                int index = ilCards.Images.IndexOfKey(oppChoice.CardKey);
                pbOppCard.Image = ilCards.Images[index];
                lblOppCard.Visible = true;

                //If the player didn't go first, it's assumed that the player now needs to go, so now they can.
                if (!Game.PlayerLead())
                {

                    if (oppChoice.CardNumber == 11)
                    {
                        int highest = 0;
                        foreach(Card card in Card.YourCurrentHand())
                        {
                            if(card.CardSuit == oppChoice.CardSuit)
                            {
                                if(card.CardNumber == 1)
                                {
                                    playerElevenChoices.Add(card);
                                }
                                else
                                {
                                    if (card.CardNumber > highest)
                                    {
                                        highest = card.CardNumber;
                                    }
                                }
                            }
                        }

                        if (highest > 0)
                        {
                            foreach(Card card in Card.YourCurrentHand())
                            {
                                if(card.CardSuit == oppChoice.CardSuit && card.CardNumber == highest)
                                {
                                    playerElevenChoices.Add(card);
                                    break;
                                }
                            }
                        }
                    }
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

        //Below is something I was thinking of adding: an animated ellipsis to show the AI "thinking" when it's its turn. Due to how I got the
        //game to simulate the AI "thinking", which is a task delay, it sort of wouldn't work, if I'm not mistaken. Honestly, I've been thinking
        //of removing the computer's simulated thinking at all, and just have it play as things come.

        //public static int dotx = 727;
        //public static int dotNum = 0;
        //private void EllipsisTimerCallback(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    
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
        {       //Code for displaying the previously mentioned scoring reference.

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
        {       //Code for hiding the scoring reference.

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
        {       //Code for showing the rules pop-up window.
            frmRules newForm = new frmRules();

            newForm.Show();
        }

        private void RefreshCardDisplay()
        {       //Code for refreshing what cards are in both player's hands.
            try
            {
                //Goes through all of the pictureboxes on the form and removes the ones that have the name of a suit in it.
                foreach (Control ctrl in this.Controls.OfType<PictureBox>().ToList())
                {

                    if (ctrl.Tag.ToString().Contains("Bell") || ctrl.Tag.ToString().Contains("Key") || ctrl.Tag.ToString().Contains("Moon"))
                    {
                        this.Controls.Remove(ctrl);
                    }
                }


                //Coordinates
                int left = 53;
                int top = 529;
                int row = 0;
                //Adds all cards that the player currently has to be displayed near the bottom half of the form. Tags these new cards with the card
                //that they are as well.
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

                            //Adds click events to the new card and adds it to the form.
                            this.Controls.Add(newCard);
                            newCard.MouseDown += new MouseEventHandler(picMouseDown);
                            newCard.MouseMove += new MouseEventHandler(picMouseMove);
                            newCard.MouseUp += new MouseEventHandler(picMouseUp);
                            break;
                        }
                    }
                }

                //Changes the coordinates to display them up where the AI's cards would be. They all have the same image (card back face), but are
                //tagged as their representative value.
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {       //Code for showing the credits window.
            frmCredits newForm = new frmCredits();
            newForm.Show();
        }


    }
}
