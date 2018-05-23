namespace Main_Game
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choosePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sortCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilCards = new System.Windows.Forms.ImageList(this.components);
            this.lblOppScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCards = new System.Windows.Forms.GroupBox();
            this.gbOpponent = new System.Windows.Forms.GroupBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.choosePlayerToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // choosePlayerToolStripMenuItem
            // 
            this.choosePlayerToolStripMenuItem.Name = "choosePlayerToolStripMenuItem";
            this.choosePlayerToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.choosePlayerToolStripMenuItem.Text = "Choose &Player";
            this.choosePlayerToolStripMenuItem.Click += new System.EventHandler(this.choosePlayerToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem1,
            this.sortCardsToolStripMenuItem});
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.rulesToolStripMenuItem.Text = "&Game";
            // 
            // rulesToolStripMenuItem1
            // 
            this.rulesToolStripMenuItem1.Name = "rulesToolStripMenuItem1";
            this.rulesToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.rulesToolStripMenuItem1.Text = "&Rules";
            this.rulesToolStripMenuItem1.Click += new System.EventHandler(this.rulesToolStripMenuItem1_Click);
            // 
            // sortCardsToolStripMenuItem
            // 
            this.sortCardsToolStripMenuItem.Name = "sortCardsToolStripMenuItem";
            this.sortCardsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sortCardsToolStripMenuItem.Text = "Sort &Cards";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ilCards
            // 
            this.ilCards.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilCards.ImageStream")));
            this.ilCards.TransparentColor = System.Drawing.Color.Transparent;
            this.ilCards.Images.SetKeyName(0, "Owl-Key_Card.png");
            this.ilCards.Images.SetKeyName(1, "Ace_Clubs.bmp");
            this.ilCards.Images.SetKeyName(2, "Ace_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(3, "Ace_Hearts.bmp");
            this.ilCards.Images.SetKeyName(4, "2_Clubs.bmp");
            this.ilCards.Images.SetKeyName(5, "2_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(6, "2_Hearts.bmp");
            this.ilCards.Images.SetKeyName(7, "3_Clubs.bmp");
            this.ilCards.Images.SetKeyName(8, "3_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(9, "3_Hearts.bmp");
            this.ilCards.Images.SetKeyName(10, "4_Clubs.bmp");
            this.ilCards.Images.SetKeyName(11, "4_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(12, "4_Hearts.bmp");
            this.ilCards.Images.SetKeyName(13, "5_Clubs.bmp");
            this.ilCards.Images.SetKeyName(14, "5_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(15, "5_Hearts.bmp");
            this.ilCards.Images.SetKeyName(16, "6_Clubs.bmp");
            this.ilCards.Images.SetKeyName(17, "6_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(18, "6_Hearts.bmp");
            this.ilCards.Images.SetKeyName(19, "7_Clubs.bmp");
            this.ilCards.Images.SetKeyName(20, "7_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(21, "7_Hearts.bmp");
            this.ilCards.Images.SetKeyName(22, "8_Clubs.bmp");
            this.ilCards.Images.SetKeyName(23, "8_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(24, "8_Hearts.bmp");
            this.ilCards.Images.SetKeyName(25, "9_Clubs.bmp");
            this.ilCards.Images.SetKeyName(26, "9_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(27, "9_Hearts.bmp");
            this.ilCards.Images.SetKeyName(28, "10_Clubs.bmp");
            this.ilCards.Images.SetKeyName(29, "10_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(30, "10_Hearts.bmp");
            this.ilCards.Images.SetKeyName(31, "Jack_Clubs.bmp");
            this.ilCards.Images.SetKeyName(32, "Jack_Diamonds.bmp");
            this.ilCards.Images.SetKeyName(33, "Jack_Hearts.bmp");
            // 
            // lblOppScore
            // 
            this.lblOppScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOppScore.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOppScore.Location = new System.Drawing.Point(695, 155);
            this.lblOppScore.Name = "lblOppScore";
            this.lblOppScore.Size = new System.Drawing.Size(98, 33);
            this.lblOppScore.TabIndex = 3;
            this.lblOppScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScore.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(691, 499);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(98, 33);
            this.lblScore.TabIndex = 4;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(699, 479);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Your Score";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(703, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Opponent\'s\r\nScore";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbCards
            // 
            this.gbCards.Location = new System.Drawing.Point(42, 494);
            this.gbCards.Name = "gbCards";
            this.gbCards.Size = new System.Drawing.Size(639, 149);
            this.gbCards.TabIndex = 7;
            this.gbCards.TabStop = false;
            // 
            // gbOpponent
            // 
            this.gbOpponent.Location = new System.Drawing.Point(42, 39);
            this.gbOpponent.Name = "gbOpponent";
            this.gbOpponent.Size = new System.Drawing.Size(639, 149);
            this.gbOpponent.TabIndex = 8;
            this.gbOpponent.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(68, 447);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(74, 27);
            this.btnDraw.TabIndex = 9;
            this.btnDraw.Text = "&Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            // 
            // pbDeck
            // 
            this.pbDeck.Location = new System.Drawing.Point(42, 240);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(135, 192);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(814, 671);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.gbOpponent);
            this.Controls.Add(this.gbCards);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblOppScore);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Fox In The Forest";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sortCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ImageList ilCards;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Label lblOppScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbCards;
        private System.Windows.Forms.GroupBox gbOpponent;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ToolStripMenuItem choosePlayerToolStripMenuItem;
    }
}

