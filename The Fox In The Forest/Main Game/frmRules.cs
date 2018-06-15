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
    public partial class frmRules : Form
    {
        public frmRules()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTrickTake newTake = new frmTrickTake();

            newTake.Show();
        }

        private void frmRules_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
