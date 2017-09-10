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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addSlotButton = new System.Windows.Forms.Button();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Start Time";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(151, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "End Time";
            // 
            // saveButton
            // 
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
            this.addSlotButton.Location = new System.Drawing.Point(85, 90);
            this.addSlotButton.Name = "addSlotButton";
            this.addSlotButton.Size = new System.Drawing.Size(119, 23);
            this.addSlotButton.TabIndex = 4;
            this.addSlotButton.Text = "Add Time Slot";
            this.addSlotButton.UseVisualStyleBackColor = true;
            this.addSlotButton.Click += new System.EventHandler(this.addSlotButton_Click);
            // 
            // RegisterEventWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addSlotButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.eventNameBox);
            this.Name = "RegisterEventWindow";
            this.Text = "RegisterEventWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eventNameBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addSlotButton;
    }
}