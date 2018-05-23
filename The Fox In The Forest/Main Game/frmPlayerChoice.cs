﻿using System;
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
        const string fileLocation = @"../../../Profiles/Profiles.csv";
        StreamReader playerRead;
        StreamWriter playerWrite;

        List<Player> players = new List<Player>();
        Player newPlayer;

        private void frmPlayerChoice_Load(object sender, EventArgs e)
        {
            try
            {
                playerRead = new StreamReader(fileLocation);
                while (!playerRead.EndOfStream)
                {
                    string[] player = new string[5];
                    player = playerRead.ReadLine().Split(',');
                    int i = 0;
                    foreach (string cell in player)
                    {
                        if (cell == null)
                        {
                            player[i] = "0";
                        }
                        i++;
                    }
                    newPlayer = new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3]), int.Parse(player[4]));
                        players.Add(newPlayer);
                        lbExistingPlayers.Items.Add(newPlayer.Name);
                    
                }
                playerRead.Close();
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
                if (txtNewName.Text.Length > 25)
                {
                    throw new Exception("Name is too long. Please shorten profile name.");
                }

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
                    Player newPlayer = new Player(txtNewName.Text);
                    players.Add(newPlayer);
                    lbExistingPlayers.Items.Add(newPlayer.Name);

                    using (playerWrite = File.AppendText(@"../../../Profiles/Profiles.csv"))
                    {
                        playerWrite.WriteLine(newPlayer.PlayStats);
                    }
                    playerWrite.Close();
                    int a = (players.Count - 1);
                    lbExistingPlayers.SelectedIndex = a;//(txtNewName.Text);
                    txtNewName.Clear();
                    
                }
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
                newPlayer = players[lbExistingPlayers.SelectedIndex];

                this.DialogResult = DialogResult.No;
                
            }
        }
    }
}
