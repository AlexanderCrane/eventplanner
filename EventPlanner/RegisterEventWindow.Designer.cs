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
            this.eventNameBox = new System.Windows.Forms.TextBox();
            this.startTimeBox = new System.Windows.Forms.ComboBox();
            this.endTimeBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addSlotButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.removeTimeSlotButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventNameBox
            // 
            this.eventNameBox.Location = new System.Drawing.Point(69, 37);
            this.eventNameBox.Name = "eventNameBox";
            this.eventNameBox.Size = new System.Drawing.Size(152, 20);
            this.eventNameBox.TabIndex = 0;
            this.eventNameBox.Text = "Event Name";
            // 
            // startTimeBox
            // 
            this.startTimeBox.FormattingEnabled = true;
            this.startTimeBox.Location = new System.Drawing.Point(3, 3);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(121, 21);
            this.startTimeBox.TabIndex = 1;
            this.startTimeBox.Text = "Start Time";
            // 
            // endTimeBox
            // 
            this.endTimeBox.FormattingEnabled = true;
            this.endTimeBox.Location = new System.Drawing.Point(130, 3);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(121, 21);
            this.endTimeBox.TabIndex = 2;
            this.endTimeBox.Text = "End Time";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(197, 217);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addSlotButton
            // 
            this.addSlotButton.Location = new System.Drawing.Point(22, 178);
            this.addSlotButton.Name = "addSlotButton";
            this.addSlotButton.Size = new System.Drawing.Size(119, 23);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 63);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(255, 100);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // removeTimeSlotButton
            // 
            this.removeTimeSlotButton.Location = new System.Drawing.Point(149, 178);
            this.removeTimeSlotButton.Name = "removeTimeSlotButton";
            this.removeTimeSlotButton.Size = new System.Drawing.Size(119, 23);
            this.removeTimeSlotButton.TabIndex = 6;
            this.removeTimeSlotButton.Text = "Remove Time Slot";
            this.removeTimeSlotButton.UseVisualStyleBackColor = true;
            this.removeTimeSlotButton.Click += new System.EventHandler(this.removeTimeSlotButton_Click);
            // 
            // RegisterEventWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.removeTimeSlotButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.addSlotButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.eventNameBox);
            this.Name = "RegisterEventWindow";
            this.Text = "RegisterEventWindow";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eventNameBox;
        private System.Windows.Forms.ComboBox startTimeBox;
        private System.Windows.Forms.ComboBox endTimeBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addSlotButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button removeTimeSlotButton;
    }
}