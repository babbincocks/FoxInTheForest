namespace Main_Game
{
    partial class frmDecreeSwitch
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
            this.btnNoSwitch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the card you would like to switch the decree card with";
            // 
            // btnNoSwitch
            // 
            this.btnNoSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNoSwitch.Location = new System.Drawing.Point(527, 232);
            this.btnNoSwitch.Name = "btnNoSwitch";
            this.btnNoSwitch.Size = new System.Drawing.Size(108, 29);
            this.btnNoSwitch.TabIndex = 2;
            this.btnNoSwitch.Text = "Don\'t Switch";
            this.btnNoSwitch.UseVisualStyleBackColor = true;
            this.btnNoSwitch.Click += new System.EventHandler(this.btnNoSwitch_Click);
            // 
            // frmDecreeSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 273);
            this.Controls.Add(this.btnNoSwitch);
            this.Controls.Add(this.label1);
            this.Name = "frmDecreeSwitch";
            this.Text = "Decree Card Switch";
            this.Load += new System.EventHandler(this.frmDecreeSwitch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoSwitch;
    }
}