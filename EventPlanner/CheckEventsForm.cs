using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CheckEventsForm : Form
    {
        List<Event> evtList;
        string userName;
        bool use24Hour;
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";

        /// <summary>
        /// Constructor for the Check Events form.
        /// </summary>
        /// <param name="userName">The user's provided name.</param>
        /// <param name="use24Hour">Whether to use 24 hour time.</param>
        public CheckEventsForm(string userName, bool use24Hour)
        {
            this.use24Hour = use24Hour;
            evtList = new List<Event>();
            this.userName = userName;
            this.use24Hour = use24Hour;
            InitializeComponent();
        }

        /// <summary>
        /// Load behavior for the Check Events form.
        /// Populates the events combo box.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void CheckEventsForm_Load(object sender, EventArgs e)
        {
            pullEventsFromJSON();
            List<Event> yourEvents = new List<Event>();
            foreach (Event i in evtList)
            {
                if (i.host.Equals(userName))
                {
                    yourEvents.Add(i);
                }
            }

            yourEventsBox.DataSource = yourEvents;
            Event ev = null;
            if (yourEvents.Count != 0)
            {
                yourEventsBox.SelectedIndex = 0;
                ev = (Event)yourEventsBox.SelectedItem;
            }
            else
            {
                this.Close();
                MessageBox.Show("You have not created any events!");
            }
        }
        /// <summary>
        /// Deserialize the JSON save file to a list of events.
        /// </summary>
        private void pullEventsFromJSON()
        {
            // read file into a string and deserialize JSON to a type
            if (File.Exists(path))
            {
                evtList = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));


            }
        }

        /// <summary>
        /// Click behavior for the back button. 
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// SelectedValueChanged behavior for the events combobox.
        /// Updates the attendees info text for the newly selected event.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void yourEventsBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Event ev = (Event)yourEventsBox.SelectedItem;
            attendeesBox.Clear();
            if (ev != null)
            {
                if (ev.attendees != null)
                {
                    foreach (Tuple<String, List<DateTime>> tuple in ev.attendees)
                    {
                        List<String> timeStrings = new List<string>();
                        foreach (DateTime dt in tuple.Item2)
                        {
                            if (!use24Hour)
                            {
                                timeStrings.Add(dt.ToShortTimeString());
                            }
                            else
                            {
                                String dateFormat = "HH:mm";
                                timeStrings.Add(dt.ToString(dateFormat));
                            }
                        }
                        attendeesBox.Text += tuple.Item1;
                        attendeesBox.Text += ":";
                        attendeesBox.Text += String.Join(",", timeStrings);
                        attendeesBox.Text += "\r\n";
                    }
                }
            }
        }
    }
}
