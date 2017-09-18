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
            this.cancelButton = new System.Windows.Forms.Button();
            this.briefMessageText = new CueTextBox();
            this.locationText = new CueTextBox();
            this.nameTextBox = new CueTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTimeBox
            // 
            this.startTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTimeBox.FormattingEnabled = true;
            this.startTimeBox.Location = new System.Drawing.Point(3, 3);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(121, 21);
            this.startTimeBox.TabIndex = 5;
            // 
            // endTimeBox
            // 
            this.endTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endTimeBox.FormattingEnabled = true;
            this.endTimeBox.Location = new System.Drawing.Point(130, 3);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(121, 21);
            this.endTimeBox.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(194, 272);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addSlotButton
            // 
            this.addSlotButton.Location = new System.Drawing.Point(19, 228);
            this.addSlotButton.Name = "addSlotButton";
            this.addSlotButton.Size = new System.Drawing.Size(119, 23);
            this.addSlotButton.TabIndex = 9;
            this.addSlotButton.Text = "Add Time Slot";
            this.addSlotButton.UseVisualStyleBackColor = true;
            this.addSlotButton.Click += new System.EventHandler(this.addSlotButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.startTimeBox);
            this.flowLayoutPanel1.Controls.Add(this.endTimeBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 113);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(274, 100);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // removeTimeSlotButton
            // 
            this.removeTimeSlotButton.Location = new System.Drawing.Point(146, 228);
            this.removeTimeSlotButton.Name = "removeTimeSlotButton";
            this.removeTimeSlotButton.Size = new System.Drawing.Size(119, 23);
            this.removeTimeSlotButton.TabIndex = 8;
            this.removeTimeSlotButton.Text = "Remove Time Slot";
            this.removeTimeSlotButton.UseVisualStyleBackColor = true;
            this.removeTimeSlotButton.Click += new System.EventHandler(this.removeTimeSlotButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Time";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(14, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(35, 13);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "label3";
            // 
            // capacityText
            // 
            this.capacityText.Location = new System.Drawing.Point(224, 25);
            this.capacityText.Name = "capacityText";
            this.capacityText.Size = new System.Drawing.Size(41, 20);
            this.capacityText.TabIndex = 3;
            this.capacityText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.capacityText_KeyPress);
            // 
            // capLabel
            // 
            this.capLabel.AutoSize = true;
            this.capLabel.Location = new System.Drawing.Point(221, 9);
            this.capLabel.Name = "capLabel";
            this.capLabel.Size = new System.Drawing.Size(48, 13);
            this.capLabel.TabIndex = 13;
            this.capLabel.Text = "Capacity";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(11, 273);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // briefMessageText
            // 
            this.briefMessageText.Cue = "Description";
            this.briefMessageText.Location = new System.Drawing.Point(12, 51);
            this.briefMessageText.Name = "briefMessageText";
            this.briefMessageText.Size = new System.Drawing.Size(253, 20);
            this.briefMessageText.TabIndex = 4;
            // 
            // locationText
            // 
            this.locationText.Cue = "Location";
            this.locationText.Location = new System.Drawing.Point(115, 25);
            this.locationText.Name = "locationText";
            this.locationText.Size = new System.Drawing.Size(100, 20);
            this.locationText.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Cue = "Event Name";
            this.nameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // RegisterEventWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 307);
            this.Controls.Add(this.cancelButton);
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
            this.MaximumSize = new System.Drawing.Size(308, 346);
            this.MinimumSize = new System.Drawing.Size(308, 346);
            this.Name = "RegisterEventWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button cancelButton;
    }
}