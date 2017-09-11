namespace WindowsFormsApplication1
{
    partial class StartWindow
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
            this.addAvailabilityButton = new System.Windows.Forms.Button();
            this.addEventsButton = new System.Windows.Forms.Button();
            this.usernameBox = new CueTextBox();
            this.SuspendLayout();
            // 
            // addAvailabilityButton
            // 
            this.addAvailabilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAvailabilityButton.Location = new System.Drawing.Point(157, 54);
            this.addAvailabilityButton.Name = "addAvailabilityButton";
            this.addAvailabilityButton.Size = new System.Drawing.Size(142, 85);
            this.addAvailabilityButton.TabIndex = 1;
            this.addAvailabilityButton.Text = "Add Availability";
            this.addAvailabilityButton.UseVisualStyleBackColor = true;
            this.addAvailabilityButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // addEventsButton
            // 
            this.addEventsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEventsButton.Location = new System.Drawing.Point(-1, 54);
            this.addEventsButton.Name = "addEventsButton";
            this.addEventsButton.Size = new System.Drawing.Size(142, 85);
            this.addEventsButton.TabIndex = 0;
            this.addEventsButton.Text = "Add Events";
            this.addEventsButton.UseVisualStyleBackColor = true;
            this.addEventsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Cue = "Enter your name...";
            this.usernameBox.Location = new System.Drawing.Point(97, 28);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 136);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.addAvailabilityButton);
            this.Controls.Add(this.addEventsButton);
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Planner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addAvailabilityButton;
        private System.Windows.Forms.Button addEventsButton;
        private CueTextBox usernameBox;
    }
}

