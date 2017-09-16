namespace WindowsFormsApplication1
{
    partial class RegisterEventWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterEventWindow));
            this.startTimeBox = new System.Windows.Forms.ComboBox();
            this.endTimeBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addSlotButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.removeTimeSlotButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.capacityText = new System.Windows.Forms.TextBox();
            this.capLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new CueTextBox();
            this.locationText = new CueTextBox();
            this.briefMessageText = new CueTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTimeBox
            // 
            this.startTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTimeBox.FormattingEnabled = true;
            this.startTimeBox.Location = new System.Drawing.Point(4, 4);
            this.startTimeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(160, 24);
            this.startTimeBox.TabIndex = 1;
            // 
            // endTimeBox
            // 
            this.endTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endTimeBox.FormattingEnabled = true;
            this.endTimeBox.Location = new System.Drawing.Point(172, 4);
            this.endTimeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(160, 24);
            this.endTimeBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(259, 335);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addSlotButton
            // 
            this.addSlotButton.Location = new System.Drawing.Point(25, 281);
            this.addSlotButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addSlotButton.Name = "addSlotButton";
            this.addSlotButton.Size = new System.Drawing.Size(159, 28);
            this.addSlotButton.TabIndex = 4;
            this.addSlotButton.Text = "Add Time Slot";
            this.addSlotButton.UseVisualStyleBackColor = true;
            this.addSlotButton.Click += new System.EventHandler(this.addSlotButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.startTimeBox);
            this.flowLayoutPanel1.Controls.Add(this.endTimeBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 139);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(340, 123);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // removeTimeSlotButton
            // 
            this.removeTimeSlotButton.Location = new System.Drawing.Point(195, 281);
            this.removeTimeSlotButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removeTimeSlotButton.Name = "removeTimeSlotButton";
            this.removeTimeSlotButton.Size = new System.Drawing.Size(159, 28);
            this.removeTimeSlotButton.TabIndex = 6;
            this.removeTimeSlotButton.Text = "Remove Time Slot";
            this.removeTimeSlotButton.UseVisualStyleBackColor = true;
            this.removeTimeSlotButton.Click += new System.EventHandler(this.removeTimeSlotButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Time";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(19, 11);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 17);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "label3";
            // 
            // capacityText
            // 
            this.capacityText.Location = new System.Drawing.Point(299, 31);
            this.capacityText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.capacityText.Name = "capacityText";
            this.capacityText.Size = new System.Drawing.Size(53, 22);
            this.capacityText.TabIndex = 12;
            this.capacityText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.capacityText_KeyPress);
            // 
            // capLabel
            // 
            this.capLabel.AutoSize = true;
            this.capLabel.Location = new System.Drawing.Point(295, 11);
            this.capLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capLabel.Name = "capLabel";
            this.capLabel.Size = new System.Drawing.Size(62, 17);
            this.capLabel.TabIndex = 13;
            this.capLabel.Text = "Capacity";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Cue = "Event Name";
            this.nameTextBox.Location = new System.Drawing.Point(16, 31);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(132, 22);
            this.nameTextBox.TabIndex = 16;
            // 
            // locationText
            // 
            this.locationText.Cue = "Location";
            this.locationText.Location = new System.Drawing.Point(153, 31);
            this.locationText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.locationText.Name = "locationText";
            this.locationText.Size = new System.Drawing.Size(132, 22);
            this.locationText.TabIndex = 17;
            // 
            // briefMessageText
            // 
            this.briefMessageText.Cue = "Description";
            this.briefMessageText.Location = new System.Drawing.Point(16, 63);
            this.briefMessageText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.briefMessageText.Name = "briefMessageText";
            this.briefMessageText.Size = new System.Drawing.Size(336, 22);
            this.briefMessageText.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Return to Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterEventWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 378);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.briefMessageText);
            this.Controls.Add(this.locationText);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.capLabel);
            this.Controls.Add(this.capacityText);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeTimeSlotButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.addSlotButton);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegisterEventWindow";
            this.Text = "Create Event";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox startTimeBox;
        private System.Windows.Forms.ComboBox endTimeBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addSlotButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button removeTimeSlotButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox capacityText;
        private System.Windows.Forms.Label capLabel;
        private CueTextBox nameTextBox;
        private CueTextBox locationText;
        private CueTextBox briefMessageText;
        private System.Windows.Forms.Button button1;
    }
}