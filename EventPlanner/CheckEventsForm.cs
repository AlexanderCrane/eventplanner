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

            //TODO replace yourEvents with list from user
            //cmbbox holds lists of admin events
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
            if (ev.dateTimes != null && ev.dateTimes.Count != 0)
            {
                dateLabel.Text = "Date: " + ev.dateTimes[0].Item2.ToShortDateString();
            }
            TimeSpan duration;
            DateTime start, end;
            Boolean continuous = false;
            
            

            attendeesBox.Clear();
            if (ev != null)
            {
                if (ev.attendees != null)
                {

                    //listing attendance for each every person attending admins event
                    foreach (Tuple<String, List<DateTime>> tuple in ev.attendees)
                    {
                        List<String> timeStrings = new List<string>();
                        DateTime[] times = tuple.Item2.ToArray<DateTime>();
                        int count = 0;
                        start = tuple.Item2[0];
                        end = start;


                        //go through the list and adding start/end date to strings
                        foreach (DateTime dt in tuple.Item2)
                        {
                            //checking next time exists
                            if (count +1 < times.Length)
                            {
                                duration = times[count + 1] - dt;
                                //checking if continuous
                                if (duration.ToString() == "00:30:00")
                                {
                                    end = times[count + 1];
                                    continuous = true;
                                    count++;
                                }
                                //not coninuous anymore
                                else
                                {
                                    //adding to string in 24 hour or 12 hour format
                                    if (!use24Hour)
                                    {
                                        if (continuous)
                                            timeStrings.Add(start.ToShortTimeString() + " to " + end.AddMinutes(30).ToShortTimeString());
                                        else
                                            timeStrings.Add(start.ToShortTimeString());
                                    }

                                    else
                                    {
                                        String dateFormat = "HH:mm";
                                        if (continuous)
                                            timeStrings.Add(start.ToString(dateFormat) + " to " + end.AddMinutes(30).ToString(dateFormat));
                                        else
                                            timeStrings.Add(start.ToString(dateFormat));
                                    }

                                    //trackekrs for print outs
                                    start = times[count + 1];
                                    count++;
                                    continuous = false;
                                }
                            }
                            //end of string of times
                            else
                            {
                                //adding to string in 24 hour or 12 hour format
                                if (!use24Hour)
                                {
                                    if (continuous)
                                        timeStrings.Add(start.ToShortTimeString() + " to " + end.AddMinutes(30).ToShortTimeString());
                                    else
                                        timeStrings.Add(start.ToShortTimeString());
                                }

                                else
                                {
                                    String dateFormat = "HH:mm";
                                    if (continuous)
                                        timeStrings.Add(start.ToString(dateFormat) + " to " + end.AddMinutes(30).ToString(dateFormat));
                                    else
                                        timeStrings.Add(start.ToString(dateFormat));
                                }
                                continuous = false;
                            }
                            
                   
                        }

                        //printing strings to text box
                        attendeesBox.Text += tuple.Item1;
                        attendeesBox.Text += ":";
                        attendeesBox.Text += String.Join(", ", timeStrings);
                        attendeesBox.Text += "\r\n";
                    }
                }
            }
        }
    }
}
