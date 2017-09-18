namespace WindowsFormsApplication1
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.addAvailabilityButton = new System.Windows.Forms.Button();
            this.addEventsButton = new System.Windows.Forms.Button();
            this.mainCalendar = new System.Windows.Forms.MonthCalendar();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.twentyFourCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkEventsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addAvailabilityButton
            // 
            this.addAvailabilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAvailabilityButton.Location = new System.Drawing.Point(281, 179);
            this.addAvailabilityButton.Name = "addAvailabilityButton";
            this.addAvailabilityButton.Size = new System.Drawing.Size(142, 55);
            this.addAvailabilityButton.TabIndex = 1;
            this.addAvailabilityButton.Text = "Add Availability";
            this.addAvailabilityButton.UseVisualStyleBackColor = true;
            this.addAvailabilityButton.Click += new System.EventHandler(this.addAvailabilityButton_Click);
            // 
            // addEventsButton
            // 
            this.addEventsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEventsButton.Location = new System.Drawing.Point(281, 29);
            this.addEventsButton.Name = "addEventsButton";
            this.addEventsButton.Size = new System.Drawing.Size(142, 49);
            this.addEventsButton.TabIndex = 0;
            this.addEventsButton.Text = "Add Events";
            this.addEventsButton.UseVisualStyleBackColor = true;
            this.addEventsButton.Click += new System.EventHandler(this.addEventsButton_Click);
            // 
            // mainCalendar
            // 
            this.mainCalendar.Location = new System.Drawing.Point(18, 29);
            this.mainCalendar.MaxSelectionCount = 1;
            this.mainCalendar.Name = "mainCalendar";
            this.mainCalendar.TabIndex = 4;
            this.mainCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mainCalendar_DateChanged);
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Location = new System.Drawing.Point(65, 200);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(28, 13);
            this.currentDateLabel.TabIndex = 5;
            this.currentDateLabel.Text = "date";
            this.currentDateLabel.TextChanged += new System.EventHandler(this.currentDateLabel_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // twentyFourCheckbox
            // 
            this.twentyFourCheckbox.AutoSize = true;
            this.twentyFourCheckbox.Location = new System.Drawing.Point(206, 253);
            this.twentyFourCheckbox.Name = "twentyFourCheckbox";
            this.twentyFourCheckbox.Size = new System.Drawing.Size(123, 17);
            this.twentyFourCheckbox.TabIndex = 7;
            this.twentyFourCheckbox.Text = "Use 24 Hour Times?";
            this.twentyFourCheckbox.UseVisualStyleBackColor = true;
            this.twentyFourCheckbox.CheckedChanged += new System.EventHandler(this.twentyFourCheckbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 249);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear All Events";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearEventsButton_Click);
            // 
            // checkEventsButton
            // 
            this.checkEventsButton.Location = new System.Drawing.Point(281, 102);
            this.checkEventsButton.Name = "checkEventsButton";
            this.checkEventsButton.Size = new System.Drawing.Size(142, 55);
            this.checkEventsButton.TabIndex = 9;
            this.checkEventsButton.Text = "Check Your Events";
            this.checkEventsButton.UseVisualStyleBackColor = true;
            this.checkEventsButton.Click += new System.EventHandler(this.checkEventsButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(335, 249);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 10;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 283);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.checkEventsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.twentyFourCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.mainCalendar);
            this.Controls.Add(this.addAvailabilityButton);
            this.Controls.Add(this.addEventsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(438, 322);
            this.MinimumSize = new System.Drawing.Size(438, 322);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doodle 2: Electric Boogaloo";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addAvailabilityButton;
        private System.Windows.Forms.Button addEventsButton;
        private System.Windows.Forms.MonthCalendar mainCalendar;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox twentyFourCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button checkEventsButton;
        private System.Windows.Forms.Button quitButton;
    }
}

