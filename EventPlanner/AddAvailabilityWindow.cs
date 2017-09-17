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
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Form allowing users to flag their available time slots for an event.
    /// </summary>
    public partial class AddAvailabilityWindow : Form
    {
        private string userName;
        private List<AvailabilityCheckBox> checkboxList = new List<AvailabilityCheckBox>();
        private List<DateTime> availableTimes = new List<DateTime>();
        private List<Event> allEvents;
        private string path;
        private bool use24Hour;

        /// <summary>
        /// Constructor for the Add Availability window.
        /// </summary>
        public AddAvailabilityWindow(List<Event> events, string userName, List<Event> allEvents, bool use24Hour)
        {
            checkboxList = new List<AvailabilityCheckBox>();
            availableTimes = new List<DateTime>();
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";
            this.userName = userName;
            this.allEvents = allEvents;
            this.use24Hour = use24Hour;
            InitializeComponent();
            eventComboBox.DataSource = events;
            eventComboBox.DisplayMember = "nameOfEvent";
            eventComboBox.SelectedIndex = 0;

            Event startingEvent = (Event)eventComboBox.SelectedItem;
            //UpdateAttendees(startingEvent);
            System.Diagnostics.Debug.WriteLine(userName);
        }

        private void UpdateAttendees(Event ev)
        {
            attendeesBox.Clear();
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
                attendeesBox.Text += String.Join(", ", timeStrings);
                attendeesBox.Text += "\r\n";
            }
        }

        /// <summary>
        /// adds checkboxes for times
        /// </summary>
        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowPanel.Controls.Clear();
            Console.Write(eventComboBox.DataSource);

            ComboBox comBox = (ComboBox)sender;
            Event selectedEvent = (Event)comBox.SelectedItem;

            hostBox.Text = selectedEvent.getHost()??"";
            locationBox.Text = selectedEvent.getLocation()??"";
            briefBox.Text = selectedEvent.getBrief()??"";
            UpdateAttendees(selectedEvent);

            //gives me list of date time tuples
            for (int i = 0; i < selectedEvent.dateTimes.Count; i++)
            {
                Console.Write("item 1: " + selectedEvent.dateTimes[i].Item1);
                Console.Write("item 2: " + selectedEvent.dateTimes[i].Item2);

                TimeSpan timeDifference = selectedEvent.dateTimes[i].Item2 - selectedEvent.dateTimes[i].Item1;

                int minuteIntervals = (int)timeDifference.TotalMinutes / 30;

                DateTime startTimeBox = selectedEvent.dateTimes[i].Item1;
                for (int j = 0; j < minuteIntervals; j++)
                {
                    AvailabilityCheckBox cB = AddCheckbox(startTimeBox);
                    flowPanel.Controls.Add(cB);

                    startTimeBox = startTimeBox.AddMinutes(30);
                }
            }
        }

        /// <summary>
        /// Adds checkboxes for times, but checkboxes do nothing so far
        /// </summary>
        private AvailabilityCheckBox AddCheckbox(DateTime dTime)
        {
            AvailabilityCheckBox cB = new AvailabilityCheckBox();
            cB.associatedDateTime = dTime;
            cB.Text = dTime.ToShortTimeString();

            checkboxList.Add(cB);
            return (cB);
        }

        private void saveAvailabilityButton_Click(object sender, EventArgs e)
        {
            Event realEvent = allEvents.Find(x => x.nameOfEvent == ((Event)eventComboBox.SelectedItem).nameOfEvent);
            if (realEvent != null)
            {
                for (int i = 0; i < checkboxList.Count; i++)
                {
                    if (checkboxList[i].Checked)
                    {
                        availableTimes.Add(checkboxList[i].associatedDateTime);
                    }
                }
                WriteToJSON(realEvent);
            }
            this.Close();
        }

        private void WriteToJSON(Event realEvent)
        {
            realEvent.setAttendees(1);
            realEvent.addAttendee(userName, availableTimes);
            //JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter file = new StreamWriter(path, append: false))
            {
                serializer.Serialize(file, allEvents);
            }
        }
    }
}
