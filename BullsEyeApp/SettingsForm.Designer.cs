namespace BullsEyeApp
{
    partial class SettingsForm
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
            this.numberOfChancesButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberOfChancesButton
            // 
            this.numberOfChancesButton.AccessibleName = "numberOfChancesButton";
            this.numberOfChancesButton.Location = new System.Drawing.Point(67, 12);
            this.numberOfChancesButton.Name = "numberOfChancesButton";
            this.numberOfChancesButton.Size = new System.Drawing.Size(169, 24);
            this.numberOfChancesButton.TabIndex = 0;
            this.numberOfChancesButton.Text = "Number of chances: 4";
            this.numberOfChancesButton.UseVisualStyleBackColor = true;
            this.numberOfChancesButton.Click += new System.EventHandler(this.buttonChancesCounter_Click);
            // 
            // startButton
            // 
            this.startButton.AccessibleName = "startButton";
            this.startButton.Location = new System.Drawing.Point(213, 98);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(84, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 132);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.numberOfChancesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button numberOfChancesButton;
        private System.Windows.Forms.Button startButton;
    }
}