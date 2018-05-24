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
    public partial class frmTrickTake : Form
    {
        public frmTrickTake()
        {
            InitializeComponent();
        }

        private void frmTrickTake_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //https://boardgamegeek.com/boardgamemechanic/2009/trick-taking
        }
    }
}
