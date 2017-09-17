namespace WindowsFormsApplication1
{
    /// <summary>
    /// A form allowing users to check the attendees of events created under their username.
    /// </summary>
    partial class CheckEventsForm
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
            this.yourEventsBox = new System.Windows.Forms.ComboBox();
            this.AttendeesLabel = new System.Windows.Forms.Label();
            this.attendeesBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yourEventsBox
            // 
            this.yourEventsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yourEventsBox.FormattingEnabled = true;
            this.yourEventsBox.Location = new System.Drawing.Point(219, 39);
            this.yourEventsBox.Name = "yourEventsBox";
            this.yourEventsBox.Size = new System.Drawing.Size(121, 21);
            this.yourEventsBox.TabIndex = 0;
            this.yourEventsBox.SelectedValueChanged += new System.EventHandler(this.yourEventsBox_SelectedValueChanged);
            // 
            // AttendeesLabel
            // 
            this.AttendeesLabel.AutoSize = true;
            this.AttendeesLabel.Location = new System.Drawing.Point(25, 87);
            this.AttendeesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttendeesLabel.Name = "AttendeesLabel";
            this.AttendeesLabel.Size = new System.Drawing.Size(55, 13);
            this.AttendeesLabel.TabIndex = 13;
            this.AttendeesLabel.Text = "Attendees";
            // 
            // attendeesBox
            // 
            this.attendeesBox.Location = new System.Drawing.Point(28, 102);
            this.attendeesBox.Margin = new System.Windows.Forms.Padding(2);
            this.attendeesBox.Multiline = true;
            this.attendeesBox.Name = "attendeesBox";
            this.attendeesBox.ReadOnly = true;
            this.attendeesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.attendeesBox.Size = new System.Drawing.Size(532, 227);
            this.attendeesBox.TabIndex = 12;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackButton.Location = new System.Drawing.Point(414, 28);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(146, 40);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CheckEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 349);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AttendeesLabel);
            this.Controls.Add(this.attendeesBox);
            this.Controls.Add(this.yourEventsBox);
            this.MinimumSize = new System.Drawing.Size(597, 388);
            this.Name = "CheckEventsForm";
            this.Text = "CheckEventsForm";
            this.Load += new System.EventHandler(this.CheckEventsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox yourEventsBox;
        private System.Windows.Forms.Label AttendeesLabel;
        private System.Windows.Forms.TextBox attendeesBox;
        private System.Windows.Forms.Button BackButton;
    }
}