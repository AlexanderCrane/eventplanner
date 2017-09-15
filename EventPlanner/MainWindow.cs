﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainWindow : Form
    {
        private string userName;
        private bool use24Hour;
        public MainWindow(string userName)
        {
            InitializeComponent();
            //lock size
            this.MaximumSize = this.Size;
            this.userName = userName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                DateTime placeHolder = mainCalendar.SelectionStart;
                RegisterEventWindow registerPopup = new RegisterEventWindow(placeHolder, use24Hour);
                registerPopup.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                UserWindow user = new UserWindow(use24Hour);
                user.ShowDialog();
        }

        private void mainCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {
            currentDateLabel.Text = DateTime.Today.ToShortDateString();
            label1.Text = "Logged in as " + userName;
        }

        private void twentyFourCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            use24Hour = box.Checked;
            Console.Out.WriteLine(use24Hour);
        }
    }
}
