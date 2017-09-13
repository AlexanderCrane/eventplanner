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
            this.addAvailabilityButton = new System.Windows.Forms.Button();
            this.addEventsButton = new System.Windows.Forms.Button();
            this.mainCalendar = new System.Windows.Forms.MonthCalendar();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addAvailabilityButton
            // 
            this.addAvailabilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAvailabilityButton.Location = new System.Drawing.Point(281, 145);
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
            this.addEventsButton.Location = new System.Drawing.Point(281, 58);
            this.addEventsButton.Name = "addEventsButton";
            this.addEventsButton.Size = new System.Drawing.Size(142, 85);
            this.addEventsButton.TabIndex = 0;
            this.addEventsButton.Text = "Add Events";
            this.addEventsButton.UseVisualStyleBackColor = true;
            this.addEventsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainCalendar
            // 
            this.mainCalendar.Location = new System.Drawing.Point(18, 76);
            this.mainCalendar.MaxSelectionCount = 1;
            this.mainCalendar.Name = "mainCalendar";
            this.mainCalendar.TabIndex = 4;
            this.mainCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mainCalendar_DateChanged);
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Location = new System.Drawing.Point(94, 247);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(28, 13);
            this.currentDateLabel.TabIndex = 5;
            this.currentDateLabel.Text = "date";
            this.currentDateLabel.Click += new System.EventHandler(this.currentDateLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 283);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.mainCalendar);
            this.Controls.Add(this.addAvailabilityButton);
            this.Controls.Add(this.addEventsButton);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Planner";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addAvailabilityButton;
        private System.Windows.Forms.Button addEventsButton;
        public System.Windows.Forms.MonthCalendar mainCalendar;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Label label1;
    }
}

