using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Main_Game
{
    public partial class frmPlayerChoice : Form
    {
        public frmPlayerChoice()
        {
            InitializeComponent();
        }
        StreamWriter playerWrite;

        List<Player> players = new List<Player>();
        Player newPlayer;
        const string fileLocation = @"../../Profiles.csv";

        private void frmPlayerChoice_Load(object sender, EventArgs e)
        {
            try
            {
                
                //playerRead = new StreamReader(fileLocation);
                //while (!playerRead.EndOfStream)
                //{
                //    string[] player = new string[5];
                //    player = playerRead.ReadLine().Split(',');
                //    int i = 0;
                //    foreach (string cell in player)
                //    {
                //        if (cell == null)
                //        {
                //            player[i] = "0";
                //        }
                //        i++;
                //    }
                //    newPlayer = new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3]), int.Parse(player[4]));
                //        players.Add(newPlayer);
                //        lbExistingPlayers.Items.Add(newPlayer.Name);

                //}
                //playerRead.Close();

                players = Player.PlayerList(fileLocation);
                for (int i = 0; i < players.Count(); i++)
                {
                    lbExistingPlayers.Items.Add(players[i].Name);
                }

                this.MaximizeBox = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtNewName.Text.Length > 15)
                //{
                //    MessageBox.Show("Name is too long. Please shorten profile name.");
                //}
                //else
                //{ 

                bool c = true;
                foreach (Player player in players)
                {
                    if (player.Name == txtNewName.Text)
                    {
                        c = false;
                    }
                }

                    if (c == true)
                    {
                        newPlayer = new Player(txtNewName.Text);
                        players.Add(newPlayer);
                        lbExistingPlayers.Items.Add(newPlayer.Name);

                        using (playerWrite = File.AppendText(fileLocation))
                        {
                            playerWrite.WriteLine(newPlayer.PlayStats);
                        }
                        int a = players.Count - 1;
                        lbExistingPlayers.SelectedIndex = a;//(txtNewName.Text);


                        Player.SetCurrentPlayer(lbExistingPlayers.SelectedIndex);

                    } 
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbExistingPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbExistingPlayers.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Player.SetCurrentPlayer(lbExistingPlayers.SelectedIndex);
                Close();
            }
        }

        private void lbExistingPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.SetCurrentPlayer(lbExistingPlayers.SelectedIndex);
            Player statCheck = Player.CurrentPlayer();

            lblTricks.Text = statCheck.TotalTricks.ToString();
            lblPoints.Text = statCheck.TotalPoints.ToString();

            double wins = statCheck.TotalWins;
            double loss = statCheck.TotalLosses;
            double WL = 0;

            if (wins == 0 && loss == 0)
            {
                WL = 0;
            }
            else if (wins != 0 && loss == 0)
            {
                WL += wins;
            }
            else if (wins == 0 && loss != 0)
            {
                WL -= loss;
            }
            else
            {
                WL = wins / loss;
            }
                 
            lblWL.Text = wins.ToString() + "/" + loss.ToString() + " ( " + WL.ToString("n2") + " )";
            
        }

        private void txtNewName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNewName.Text.Length == 15)
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
