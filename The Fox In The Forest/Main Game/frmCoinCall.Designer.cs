namespace Main_Game
{
    partial class frmCoinCall
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
            this.btnHeads = new System.Windows.Forms.Button();
            this.btnTails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Call it to see who will lead:\r\nHeads or Tails?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHeads
            // 
            this.btnHeads.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnHeads.Location = new System.Drawing.Point(51, 81);
            this.btnHeads.Name = "btnHeads";
            this.btnHeads.Size = new System.Drawing.Size(75, 23);
            this.btnHeads.TabIndex = 1;
            this.btnHeads.Text = "Heads";
            this.btnHeads.UseVisualStyleBackColor = true;
            // 
            // btnTails
            // 
            this.btnTails.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnTails.Location = new System.Drawing.Point(160, 81);
            this.btnTails.Name = "btnTails";
            this.btnTails.Size = new System.Drawing.Size(75, 23);
            this.btnTails.TabIndex = 2;
            this.btnTails.Text = "Tails";
            this.btnTails.UseVisualStyleBackColor = true;
            // 
            // frmCoinCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 122);
            this.Controls.Add(this.btnTails);
            this.Controls.Add(this.btnHeads);
            this.Controls.Add(this.label1);
            this.Name = "frmCoinCall";
            this.Text = "Coin Flip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHeads;
        private System.Windows.Forms.Button btnTails;
    }
}