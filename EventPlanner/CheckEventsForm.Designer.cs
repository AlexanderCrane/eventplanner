﻿namespace WindowsFormsApplication1
{
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
            this.SuspendLayout();
            // 
            // yourEventsBox
            // 
            this.yourEventsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yourEventsBox.FormattingEnabled = true;
            this.yourEventsBox.Location = new System.Drawing.Point(85, 42);
            this.yourEventsBox.Name = "yourEventsBox";
            this.yourEventsBox.Size = new System.Drawing.Size(121, 21);
            this.yourEventsBox.TabIndex = 0;
            // 
            // AttendeesLabel
            // 
            this.AttendeesLabel.AutoSize = true;
            this.AttendeesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendeesLabel.Location = new System.Drawing.Point(18, 83);
            this.AttendeesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttendeesLabel.Name = "AttendeesLabel";
            this.AttendeesLabel.Size = new System.Drawing.Size(37, 7);
            this.AttendeesLabel.TabIndex = 13;
            this.AttendeesLabel.Text = "Attendees";
            // 
            // attendeesBox
            // 
            this.attendeesBox.Location = new System.Drawing.Point(19, 92);
            this.attendeesBox.Margin = new System.Windows.Forms.Padding(2);
            this.attendeesBox.Multiline = true;
            this.attendeesBox.Name = "attendeesBox";
            this.attendeesBox.ReadOnly = true;
            this.attendeesBox.Size = new System.Drawing.Size(247, 86);
            this.attendeesBox.TabIndex = 12;
            // 
            // CheckEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AttendeesLabel);
            this.Controls.Add(this.attendeesBox);
            this.Controls.Add(this.yourEventsBox);
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
    }
}