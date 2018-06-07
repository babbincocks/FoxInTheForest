﻿namespace Main_Game
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
            this.sortCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showScoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideScoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilCards = new System.Windows.Forms.ImageList(this.components);
            this.lblOppScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbTrump = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
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
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
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
            this.sortCardsToolStripMenuItem,
            this.showScoringToolStripMenuItem,
            this.hideScoringToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.rulesToolStripMenuItem.Text = "&Game";
            // 
            // sortCardsToolStripMenuItem
            // 
            this.sortCardsToolStripMenuItem.Name = "sortCardsToolStripMenuItem";
            this.sortCardsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.sortCardsToolStripMenuItem.Text = "Sort &Hand";
            this.sortCardsToolStripMenuItem.Click += new System.EventHandler(this.sortCardsToolStripMenuItem_Click);
            // 
            // showScoringToolStripMenuItem
            // 
            this.showScoringToolStripMenuItem.Name = "showScoringToolStripMenuItem";
            this.showScoringToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.showScoringToolStripMenuItem.Text = "Show Scoring";
            this.showScoringToolStripMenuItem.Click += new System.EventHandler(this.showScoringToolStripMenuItem_Click);
            // 
            // hideScoringToolStripMenuItem
            // 
            this.hideScoringToolStripMenuItem.Name = "hideScoringToolStripMenuItem";
            this.hideScoringToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.hideScoringToolStripMenuItem.Text = "Hide Scoring";
            this.hideScoringToolStripMenuItem.Click += new System.EventHandler(this.hideScoringToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem2,
            this.guideToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // rulesToolStripMenuItem2
            // 
            this.rulesToolStripMenuItem2.Name = "rulesToolStripMenuItem2";
            this.rulesToolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.rulesToolStripMenuItem2.Text = "&Rules";
            this.rulesToolStripMenuItem2.Click += new System.EventHandler(this.rulesToolStripMenuItem2_Click);
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.guideToolStripMenuItem.Text = "G&uide";
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
            this.ilCards.Images.SetKeyName(1, "1_Bell.bmp");
            this.ilCards.Images.SetKeyName(2, "1_Moon.bmp");
            this.ilCards.Images.SetKeyName(3, "1_Key.bmp");
            this.ilCards.Images.SetKeyName(4, "2_Bell.bmp");
            this.ilCards.Images.SetKeyName(5, "2_Moon.bmp");
            this.ilCards.Images.SetKeyName(6, "2_Key.bmp");
            this.ilCards.Images.SetKeyName(7, "3_Bell.bmp");
            this.ilCards.Images.SetKeyName(8, "3_Moon.bmp");
            this.ilCards.Images.SetKeyName(9, "3_Key.bmp");
            this.ilCards.Images.SetKeyName(10, "4_Bell.bmp");
            this.ilCards.Images.SetKeyName(11, "4_Moon.bmp");
            this.ilCards.Images.SetKeyName(12, "4_Key.bmp");
            this.ilCards.Images.SetKeyName(13, "5_Bell.bmp");
            this.ilCards.Images.SetKeyName(14, "5_Moon.bmp");
            this.ilCards.Images.SetKeyName(15, "5_Key.bmp");
            this.ilCards.Images.SetKeyName(16, "6_Bell.bmp");
            this.ilCards.Images.SetKeyName(17, "6_Moon.bmp");
            this.ilCards.Images.SetKeyName(18, "6_Key.bmp");
            this.ilCards.Images.SetKeyName(19, "7_Bell.bmp");
            this.ilCards.Images.SetKeyName(20, "7_Moon.bmp");
            this.ilCards.Images.SetKeyName(21, "7_Key.bmp");
            this.ilCards.Images.SetKeyName(22, "8_Bell.bmp");
            this.ilCards.Images.SetKeyName(23, "8_Moon.bmp");
            this.ilCards.Images.SetKeyName(24, "8_Key.bmp");
            this.ilCards.Images.SetKeyName(25, "9_Bell.bmp");
            this.ilCards.Images.SetKeyName(26, "9_Moon.bmp");
            this.ilCards.Images.SetKeyName(27, "9_Key.bmp");
            this.ilCards.Images.SetKeyName(28, "10_Bell.bmp");
            this.ilCards.Images.SetKeyName(29, "10_Moon.bmp");
            this.ilCards.Images.SetKeyName(30, "10_Key.bmp");
            this.ilCards.Images.SetKeyName(31, "11_Bell.bmp");
            this.ilCards.Images.SetKeyName(32, "11_Moon.bmp");
            this.ilCards.Images.SetKeyName(33, "11_Key.bmp");
            this.ilCards.Images.SetKeyName(34, "FitFScoreRef.png");
            // 
            // lblOppScore
            // 
            this.lblOppScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOppScore.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOppScore.Location = new System.Drawing.Point(727, 231);
            this.lblOppScore.Name = "lblOppScore";
            this.lblOppScore.Size = new System.Drawing.Size(98, 33);
            this.lblOppScore.TabIndex = 3;
            this.lblOppScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScore.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(727, 523);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(98, 33);
            this.lblScore.TabIndex = 4;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(735, 503);
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
            this.label2.Location = new System.Drawing.Point(735, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Opponent\'s\r\nScore";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(60, 447);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(74, 27);
            this.btnDraw.TabIndex = 9;
            this.btnDraw.Text = "&Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // pbDeck
            // 
            this.pbDeck.Location = new System.Drawing.Point(42, 277);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(109, 155);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            // 
            // pbTrump
            // 
            this.pbTrump.Location = new System.Drawing.Point(393, 326);
            this.pbTrump.Name = "pbTrump";
            this.pbTrump.Size = new System.Drawing.Size(80, 110);
            this.pbTrump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTrump.TabIndex = 10;
            this.pbTrump.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(42, 518);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 225);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(858, 755);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbTrump);
            this.Controls.Add(this.btnDraw);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Label lblOppScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ToolStripMenuItem choosePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showScoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideScoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        public System.Windows.Forms.ImageList ilCards;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbTrump;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

