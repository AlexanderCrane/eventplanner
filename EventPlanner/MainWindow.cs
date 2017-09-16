using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Primary form allowing for mode selection.
    /// </summary>
    public partial class MainWindow : Form
    {
        private string userName;
        private bool use24Hour;
        /// <summary>
        /// Constructor for the main window. 
        /// </summary>
        /// <param name="userName">The name provided by the user in LoginPopup.</param>
        public MainWindow(string userName)
        {
            InitializeComponent();
            //lock size
            this.MaximumSize = this.Size;
            this.userName = userName;
        }

        /// <summary>
        /// Click behavior for the button to open the RegisterEventWindow.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
                DateTime placeHolder = mainCalendar.SelectionStart;
                RegisterEventWindow registerPopup = new RegisterEventWindow(placeHolder, use24Hour);
                registerPopup.ShowDialog();
        }

        /// <summary>
        /// Click behavior for the button to open the UserWindow.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void button2_Click(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";
            // read file into a string and deserialize JSON to a type
            if (File.Exists(path))
            {
                System.Diagnostics.Debug.WriteLine(userName);
                UserWindow user = new UserWindow(use24Hour, mainCalendar.SelectionStart, userName);
                user.ShowDialog();
            }
            else
            {
                MessageBox.Show("No events to join!");
            }
        }

        /// <summary>
        /// Date Changed behavior for the calendar. Updates a label with the selected date.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void mainCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();
        }

        /// <summary>
        /// Load behavior for the main window. Displays the user's name and updates a label to the current date.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void StartWindow_Load(object sender, EventArgs e)
        {
            currentDateLabel.Text = DateTime.Today.ToShortDateString();
            label1.Text = "Logged in as " + userName;
        }

        /// <summary>
        /// CheckedChanged behavior for the 24 hour mode checkbox. Updates a boolean representing the selected mode.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void twentyFourCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            use24Hour = box.Checked;
            Console.Out.WriteLine(use24Hour);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";
            //System.IO.File.WriteAllText(path, "");

            if (File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

        }
    }
}
