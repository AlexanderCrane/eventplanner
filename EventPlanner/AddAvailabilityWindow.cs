using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Form allowing users to flag their available time slots for an event.
    /// </summary>
    public partial class AddAvailabilityWindow : Form
    {
        #region Private Fields and Properties
        private string userName;
        private List<AvailabilityCheckBox> checkboxList = new List<AvailabilityCheckBox>();
        private List<DateTime> availableTimes = new List<DateTime>(); //times where user is joining an event

        private List<DateTime> possibleTimes = new List<DateTime>(); //possible times attend event
        private List<int> attendeesPerTime = new List<int>(); //list of attendees joining at certain times
        private List<DateTime> unAvailableTimes = new List<DateTime>();
        private List<Event> allEvents;
        private Tuple<String, List<DateTime>> yourAttendance;
        private string path;
        private bool use24Hour;
        #endregion

        /// <summary>
        /// Constructor for the Add Availability window.
        /// </summary>
        /// <param name="events">The list of events relevant to the selected time period.</param>
        /// <param name="userName">The user's chosen name.</param>
        /// <param name="allEvents">The master list of all events, to be updated and written to JSON.</param>
        /// <param name="use24Hour">Whether to use 24 hour time.</param>
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

        /// <summary>
        /// Updates the text box showing the current attendees of the event.
        /// </summary>
        /// <param name="ev">The selected event.</param>
        private void updateAttendees(Event ev)
        {
            attendeesBox.Clear();
            if (ev.attendees != null) {
                foreach (Tuple<String, List<DateTime>> tuple in ev.attendees)
                {
                    List<String> timeStrings = new List<string>();
                    if (tuple.Item1 == userName)
                    {
                        List<DateTime> yourAttDTs = new List<DateTime>();
                        foreach(DateTime dt in tuple.Item2)
                        {
                            yourAttDTs.Add(dt);
                        }
                        yourAttendance = new Tuple<string, List<DateTime>>(userName, yourAttDTs);
                    }
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
            capacityBox.Text = selectedEvent.getCapacity().ToString();
            if (yourAttendance != null)
            {
                yourAttendance.Item2.Clear();
            }
            updateAttendees(selectedEvent);
            unAvailableTimes.Clear();
            possibleTimes.Clear();
            attendeesPerTime.Clear();
            checkboxList.Clear();

            //gives me list of date time tuples
            for (int i = 0; i < selectedEvent.dateTimes.Count; i++)
            {
                TimeSpan timeDifference = selectedEvent.dateTimes[i].Item2 - selectedEvent.dateTimes[i].Item1;

                int minuteIntervals = (int)timeDifference.TotalMinutes / 30;

                DateTime startTimeBox = selectedEvent.dateTimes[i].Item1;

                CheckUnavailableTimes(minuteIntervals, startTimeBox, selectedEvent);

                for (int j = 0; j < minuteIntervals; j++)
                {
                    bool noCheckBox = false;

                    if (unAvailableTimes != null && unAvailableTimes.Count > 0)
                    {
                        for (int k = 0; k < unAvailableTimes.Count; k++)
                        {
                            if (unAvailableTimes[k] == startTimeBox)
                            {
                                unAvailableTimes.RemoveAt(k);
                                noCheckBox = true;
                                break;
                            }
                        }
                    }
                    AvailabilityCheckBox cB = AddCheckbox(startTimeBox);
                    flowPanel.Controls.Add(cB);
                    if (noCheckBox && !cB.Checked )
                    {
                        cB.Enabled = false;
                    }
                    
                    
                    startTimeBox = startTimeBox.AddMinutes(30);
                }
            }
        }

        /// <summary>
        /// Add Unavailable Times To List So They Can't Be Selected
        /// </summary>
        /// <param name="minuteIntervals">The number of 30 minute intervals in the relevant time window.</param>
        /// <param name="startTimeBox">The starting DateTime of the relevant time window.</param>
        /// <param name="selectedEvent">The event selected for availability modification.</param>
        private void CheckUnavailableTimes(int minuteIntervals, DateTime startTimeBox, Event selectedEvent)
        {
            if (selectedEvent.getAttendeeCount() >= selectedEvent.getCapacity())
            {
                List<Tuple<String, List<DateTime>>> peopleAndTimes = selectedEvent.getAttendees();

                for (int j = 0; j < minuteIntervals; j++)
                {
                    possibleTimes.Add(startTimeBox);
                    attendeesPerTime.Add(0);
                    startTimeBox = startTimeBox.AddMinutes(30);
                }

                for (int i = 0; i < peopleAndTimes.Count; i++) //num of attendees
                {
                    for (int l = 0; l < peopleAndTimes[i].Item2.Count; l++) //times per attendee
                    {
                        for (int k = 0; k < possibleTimes.Count; k++) //possible times
                        {
                            if (peopleAndTimes[i].Item2[l] == possibleTimes[k])
                            {
                                attendeesPerTime[k]++;
                            }
                        }
                    }
                }

                for (int a = 0; a < attendeesPerTime.Count; a++)
                {
                    Console.WriteLine("Attendees " + attendeesPerTime[a]);
                    Console.WriteLine(selectedEvent.getCapacity());
                    if (attendeesPerTime[a] >= selectedEvent.getCapacity())
                    {
                        unAvailableTimes.Add(possibleTimes[a]);
                    }
                }

                if(unAvailableTimes.Count > 0)
                {
                    if(unAvailableTimes.Count == possibleTimes.Count)
                    {
                        capacityWarning.Text = "Warning! Attendee Capacity Reached.";
                    }
                    else
                    {
                        capacityWarning.Text = "Warning! Attendee Capacity Reached For Some Times.";
                    }
                }
                else
                {
                    capacityWarning.Text = "Join Events That Meet Your Schedule";
                }

                capacityWarning.Refresh();
            }
        }

        /// <summary>
        /// Adds checkboxes for times, but checkboxes do nothing so far
        /// </summary>
        /// <param name="dTime">The datetime to add a checkbox for.</param>
        private AvailabilityCheckBox AddCheckbox(DateTime dTime)
        {
            AvailabilityCheckBox cB = new AvailabilityCheckBox();
            cB.associatedDateTime = dTime;
            if (yourAttendance != null)
            {
                if (yourAttendance.Item2.Contains(dTime))
                {
                    cB.Checked = true;
                }
            }
            if (!use24Hour)
            {
                cB.Text = dTime.ToShortTimeString();

            }
            else
            {
                String dateFormat = "HH:mm";
                cB.Text = dTime.ToString(dateFormat);
            }

            checkboxList.Add(cB);
            return (cB);
        }

        /// <summary>
        /// Click behavior for the save button.
        /// Prepares to overwrite the user's current attendee info on the event with the current state of their checkboxes.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
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

        /// <summary>
        /// Writes the changes to the user's attendee info to JSON.
        /// </summary>
        /// <param name="realEvent">The event in the main list of all events to be modified.</param>
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
