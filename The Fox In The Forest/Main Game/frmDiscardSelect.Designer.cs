﻿namespace Main_Game
{
    partial class frmDiscardSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbCards = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the card you would like to discard back into the deck.";
            // 
            // gbCards
            // 
            this.gbCards.Location = new System.Drawing.Point(12, 64);
            this.gbCards.Name = "gbCards";
            this.gbCards.Size = new System.Drawing.Size(623, 197);
            this.gbCards.TabIndex = 1;
            this.gbCards.TabStop = false;
            this.gbCards.Text = "Your Hand";
            // 
            // frmDiscardSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 273);
            this.Controls.Add(this.gbCards);
            this.Controls.Add(this.label1);
            this.Name = "frmDiscardSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Discard Select";
            this.Load += new System.EventHandler(this.frmDiscardSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCards;
    }
}