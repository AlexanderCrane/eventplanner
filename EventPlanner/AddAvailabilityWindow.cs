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

        /// <summary>
        /// Constructor for the Add Availability window.
        /// </summary>
        public AddAvailabilityWindow(List<Event> events)
        {
            InitializeComponent();
            eventComboBox.DataSource = events;
            eventComboBox.DisplayMember = "nameOfEvent";
        }

        /// <summary>
        /// adds checkboxes for times
        /// </summary>
        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Write(eventComboBox.DataSource);

            ComboBox comBox = (ComboBox)sender;
            Event selectedEvent = (Event)comBox.SelectedItem;

            hostBox.Text = selectedEvent.getHost();
            locationBox.Text = selectedEvent.getLocation();
            briefBox.Text = selectedEvent.getBrief();

            //gives me list of date time tuples
            for (int i = 0; i < selectedEvent.dateTimes.Count; i++)
            {
                Console.Write("item 1: " + selectedEvent.dateTimes[i].Item1);
                Console.Write("item 2: " + selectedEvent.dateTimes[i].Item2);

                TimeSpan timeDifference = selectedEvent.dateTimes[i].Item2 - selectedEvent.dateTimes[i].Item1;

                int minuteIntervals = (int)timeDifference.TotalMinutes % 30;

                DateTime startTimeBox = selectedEvent.dateTimes[i].Item1;
                for (int j = 0; j < minuteIntervals; j++)
                {
                    CheckBox cB = AddCheckbox(startTimeBox.ToString());
                    flowPanel.Controls.Add(cB);

                    startTimeBox.AddMinutes(30);
                }
            }
        }

        /// <summary>
        /// Adds checkboxes for times, but checkboxes do nothing so far
        /// </summary>
        private CheckBox AddCheckbox(string dTime)
        {
            CheckBox cB = new CheckBox();
            cB.Text = "Join at: " + dTime;
            return (cB);
        }
    }
}
