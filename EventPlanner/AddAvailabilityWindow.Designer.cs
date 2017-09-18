namespace WindowsFormsApplication1
{
    partial class AddAvailabilityWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAvailabilityWindow));
            this.saveAvailabilityButton = new System.Windows.Forms.Button();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.briefBox = new System.Windows.Forms.TextBox();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.hostBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.attendeesBox = new System.Windows.Forms.TextBox();
            this.AttendeesLabel = new System.Windows.Forms.Label();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityBox = new System.Windows.Forms.TextBox();
            this.capacityWarning = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveAvailabilityButton
            // 
            this.saveAvailabilityButton.Location = new System.Drawing.Point(153, 484);
            this.saveAvailabilityButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveAvailabilityButton.Name = "saveAvailabilityButton";
            this.saveAvailabilityButton.Size = new System.Drawing.Size(118, 23);
            this.saveAvailabilityButton.TabIndex = 1;
            this.saveAvailabilityButton.Text = "Save Availability";
            this.saveAvailabilityButton.UseVisualStyleBackColor = true;
            this.saveAvailabilityButton.Click += new System.EventHandler(this.saveAvailabilityButton_Click);
            // 
            // eventComboBox
            // 
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(23, 30);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(247, 21);
            this.eventComboBox.TabIndex = 2;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(23, 216);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(247, 249);
            this.flowPanel.TabIndex = 3;
            // 
            // briefBox
            // 
            this.briefBox.Location = new System.Drawing.Point(25, 92);
            this.briefBox.Margin = new System.Windows.Forms.Padding(2);
            this.briefBox.Name = "briefBox";
            this.briefBox.ReadOnly = true;
            this.briefBox.Size = new System.Drawing.Size(245, 20);
            this.briefBox.TabIndex = 4;
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(133, 61);
            this.locationBox.Margin = new System.Windows.Forms.Padding(2);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(74, 20);
            this.locationBox.TabIndex = 5;
            // 
            // hostBox
            // 
            this.hostBox.Location = new System.Drawing.Point(25, 61);
            this.hostBox.Margin = new System.Windows.Forms.Padding(2);
            this.hostBox.Name = "hostBox";
            this.hostBox.ReadOnly = true;
            this.hostBox.Size = new System.Drawing.Size(104, 20);
            this.hostBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 7);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 7);
            this.label2.TabIndex = 8;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 7);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // attendeesBox
            // 
            this.attendeesBox.Location = new System.Drawing.Point(23, 126);
            this.attendeesBox.Margin = new System.Windows.Forms.Padding(2);
            this.attendeesBox.Multiline = true;
            this.attendeesBox.Name = "attendeesBox";
            this.attendeesBox.ReadOnly = true;
            this.attendeesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.attendeesBox.Size = new System.Drawing.Size(247, 86);
            this.attendeesBox.TabIndex = 10;
            // 
            // AttendeesLabel
            // 
            this.AttendeesLabel.AutoSize = true;
            this.AttendeesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendeesLabel.Location = new System.Drawing.Point(22, 117);
            this.AttendeesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttendeesLabel.Name = "AttendeesLabel";
            this.AttendeesLabel.Size = new System.Drawing.Size(37, 7);
            this.AttendeesLabel.TabIndex = 11;
            this.AttendeesLabel.Text = "Attendees";
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel.Location = new System.Drawing.Point(210, 53);
            this.capacityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(33, 7);
            this.capacityLabel.TabIndex = 13;
            this.capacityLabel.Text = "Capacity";
            // 
            // capacityBox
            // 
            this.capacityBox.Location = new System.Drawing.Point(211, 61);
            this.capacityBox.Margin = new System.Windows.Forms.Padding(2);
            this.capacityBox.Name = "capacityBox";
            this.capacityBox.ReadOnly = true;
            this.capacityBox.Size = new System.Drawing.Size(59, 20);
            this.capacityBox.TabIndex = 12;
            // 
            // capacityWarning
            // 
            this.capacityWarning.AutoSize = true;
            this.capacityWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityWarning.ForeColor = System.Drawing.Color.DarkGray;
            this.capacityWarning.Location = new System.Drawing.Point(12, 9);
            this.capacityWarning.Name = "capacityWarning";
            this.capacityWarning.Size = new System.Drawing.Size(184, 13);
            this.capacityWarning.TabIndex = 14;
            this.capacityWarning.Text = "Join Events That Meet Your Schedule";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(23, 484);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 15;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // AddAvailabilityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 518);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.capacityWarning);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.capacityBox);
            this.Controls.Add(this.AttendeesLabel);
            this.Controls.Add(this.attendeesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostBox);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.briefBox);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.saveAvailabilityButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(298, 557);
            this.MinimumSize = new System.Drawing.Size(298, 557);
            this.Name = "AddAvailabilityWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Availability";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveAvailabilityButton;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.TextBox briefBox;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.TextBox hostBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox attendeesBox;
        private System.Windows.Forms.Label AttendeesLabel;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.TextBox capacityBox;
        private System.Windows.Forms.Label capacityWarning;
        private System.Windows.Forms.Button selectAllButton;
    }
}