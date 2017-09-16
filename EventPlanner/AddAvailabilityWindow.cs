using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Form allowing users to flag their available time slots for an event.
    /// </summary>
    public partial class AddAvailabilityWindow : Form
    {
        private string userName;
        private List<CheckBox> checkboxList = new List<CheckBox>();
        private List<Event> allEvents;
        /// <summary>
        /// Constructor for the Add Availability window.
        /// </summary>
        public AddAvailabilityWindow(List<Event> events, string userName, List<Event> allEvents)
        {
            InitializeComponent();
            eventComboBox.DataSource = events;
            eventComboBox.DisplayMember = "nameOfEvent";
            this.userName = userName;
            this.allEvents = allEvents;
            System.Diagnostics.Debug.WriteLine(userName);

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
            if (selectedEvent.attendees != null)
            {
                attendeesBox.Text = string.Join(",", selectedEvent.attendees);
            }

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
            if (realEvent == null)
            {

            }
            else
            {
                System.Diagnostics.Debug.WriteLine(checkboxList.Count);
                for (int i = 0; i < checkboxList.Count; i++)
                {
                    if (checkboxList[i].Checked)
                    {
                        //Method
                        break;
                    }
                }
            }
            this.Close();
        }
    }
}
