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
            this.SuspendLayout();
            // 
            // saveAvailabilityButton
            // 
            this.saveAvailabilityButton.Location = new System.Drawing.Point(78, 484);
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
            this.flowPanel.Location = new System.Drawing.Point(23, 131);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(247, 334);
            this.flowPanel.TabIndex = 3;
            // 
            // briefBox
            // 
            this.briefBox.Location = new System.Drawing.Point(47, 91);
            this.briefBox.Margin = new System.Windows.Forms.Padding(2);
            this.briefBox.Name = "briefBox";
            this.briefBox.ReadOnly = true;
            this.briefBox.Size = new System.Drawing.Size(166, 20);
            this.briefBox.TabIndex = 4;
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(117, 60);
            this.locationBox.Margin = new System.Windows.Forms.Padding(2);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(95, 20);
            this.locationBox.TabIndex = 5;
            // 
            // hostBox
            // 
            this.hostBox.Location = new System.Drawing.Point(47, 60);
            this.hostBox.Margin = new System.Windows.Forms.Padding(2);
            this.hostBox.Name = "hostBox";
            this.hostBox.ReadOnly = true;
            this.hostBox.Size = new System.Drawing.Size(68, 20);
            this.hostBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 7);
            this.label1.TabIndex = 7;
            this.label1.Text = "host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 7);
            this.label2.TabIndex = 8;
            this.label2.Text = "location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 7);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // AddAvailabilityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 518);
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
            this.Name = "AddAvailabilityWindow";
            this.Text = "AddAvailabilityWindow";
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
    }
}