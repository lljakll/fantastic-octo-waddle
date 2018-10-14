namespace fantasticOctoWaddle
{
    partial class Instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instructions));
            this.RTBInstructions = new System.Windows.Forms.RichTextBox();
            this.LblInstructionFormTitle = new System.Windows.Forms.Label();
            this.BtnInstructionsClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTBInstructions
            // 
            this.RTBInstructions.Location = new System.Drawing.Point(32, 120);
            this.RTBInstructions.Name = "RTBInstructions";
            this.RTBInstructions.Size = new System.Drawing.Size(864, 768);
            this.RTBInstructions.TabIndex = 0;
            this.RTBInstructions.Text = resources.GetString("RTBInstructions.Text");
            // 
            // LblInstructionFormTitle
            // 
            this.LblInstructionFormTitle.AutoSize = true;
            this.LblInstructionFormTitle.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInstructionFormTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblInstructionFormTitle.Location = new System.Drawing.Point(56, 24);
            this.LblInstructionFormTitle.Name = "LblInstructionFormTitle";
            this.LblInstructionFormTitle.Size = new System.Drawing.Size(810, 70);
            this.LblInstructionFormTitle.TabIndex = 1;
            this.LblInstructionFormTitle.Text = "AMMO SWEEPER Instructions";
            // 
            // BtnInstructionsClose
            // 
            this.BtnInstructionsClose.Location = new System.Drawing.Point(364, 912);
            this.BtnInstructionsClose.Name = "BtnInstructionsClose";
            this.BtnInstructionsClose.Size = new System.Drawing.Size(200, 64);
            this.BtnInstructionsClose.TabIndex = 2;
            this.BtnInstructionsClose.Text = "Close";
            this.BtnInstructionsClose.UseVisualStyleBackColor = true;
            this.BtnInstructionsClose.Click += new System.EventHandler(this.BtnInstructionsClose_Click);
            // 
            // Instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(945, 1113);
            this.Controls.Add(this.BtnInstructionsClose);
            this.Controls.Add(this.LblInstructionFormTitle);
            this.Controls.Add(this.RTBInstructions);
            this.Name = "Instructions";
            this.Text = "Instructions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBInstructions;
        private System.Windows.Forms.Label LblInstructionFormTitle;
        private System.Windows.Forms.Button BtnInstructionsClose;
    }
}