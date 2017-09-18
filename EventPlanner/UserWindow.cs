using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserWindow : Form
    {

        /// <summary>
        /// A method used in hiding the insertion caret.
        /// </summary>
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private bool use24Hour;
        private DateTime startingDate;
        private string userName;
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";

        private List<Event> evtList = new List<Event>();
        private List<Event> dayEvents = new List<Event>();
        AgendaTextBox[] TextBoxArray = new AgendaTextBox[48];

        /// <summary>
        /// Constructor for the user window.
        /// </summary>
        /// <param name="use24Hour">Whether to use 24 hour times in the 'agenda' panel.</param>
        /// <param name="selectedDate">The date selected previously on the main window calendar.</param>
        /// <param name="userName">The username entered in LoginPopup</param>
        public UserWindow(bool use24Hour, DateTime selectedDate, string userName)
        {
            InitializeComponent();
            this.use24Hour = use24Hour;
            this.startingDate = selectedDate;
            this.userName = userName;
        }


        /// <summary>
        /// Date Selected behavior for the calendar.
        /// Updates the selected date when it changes and updates the 'agenda' panel to show that day's events
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            getEventsForTheDay(e.Start);
            currentDateLabel.Text = e.Start.ToShortDateString();

            for (int i = 0; i < 48; i++)
            {
               AgendaTextBox text = TextBoxArray[i];
                text.Text = "";
                text.associatedEvents.Clear();
                String eventText = "";
                int eventsAdded =0;

                DateTime selectedDate = monthCalendar1.SelectionStart;
                DateTime associatedDT = text.associatedDateTime;
                int hour = associatedDT.Hour;
                int minute = associatedDT.Minute;

                text.associatedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hour, minute, 0);

                for (int j = 0; j < dayEvents.Count; j++)
                {
                    for (int k = 0; k < dayEvents[j].dateTimes.Count; k++)
                    {
                        if (text.associatedDateTime < dayEvents[j].dateTimes[k].Item2 && text.associatedDateTime >= dayEvents[j].dateTimes[k].Item1)
                        {
                            if (!text.associatedEvents.Contains(dayEvents[j]))
                            {
                                text.associatedEvents.Add(dayEvents[j]);
                            }
                        }
                    }
                }
                foreach (Event ev in text.associatedEvents)
                {
                    if (text.Text.Length + ev.ToString().Length > 94)
                    {
                        if (eventsAdded == 0)
                        {
                            text.Text += "Event text too long to display. Click for details.";
                            break;
                        }
                        else
                        {
                            text.Text += "...";
                        }
                    }
                    else
                    {
                        text.Text += ev.ToString() + " ";
                    }
                    eventsAdded++;
                }
            }
        }

        /// <summary>
        /// Click behavior for the done button.
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Populates dayEvents with the list of events for the selected day.
        /// </summary>
        /// <param name="currentTime">The time to pull the selected day from.</param>
        private void getEventsForTheDay(DateTime currentTime)
        {
            //cleardayEvents
            if (dayEvents != null)
            {
                dayEvents.Clear();
            }
            //dayEvents
            if (evtList != null)
            {
                foreach (Event evt in evtList)
                {
                    for (int i = 0; i < evt.dateTimes.Count; i++)
                    {
                        if (currentTime.Day == evt.dateTimes[i].Item1.Day)
                        {
                            dayEvents.Add(evt);
                            break;
                        }
                    }
                }
            }
        }

        //add 48 textboxes to a panel, one for each time slot
        //todo - load events from file to associate with these and displayt heir names
        /// <summary>
        /// Load behavior for the user window.
        /// Populates the 'agenda' panel of textboxes and loads the events from the day selected in MainWindow into them.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void UserWindow_Load(object sender, EventArgs e)
        {
            DateTime currentTime = startingDate;
            if (File.Exists(path))
            {
                pullEventsFromJSON();
                if (evtList != null)
                {
                    getEventsForTheDay(currentTime);
                }
            }

            for (int i = 0; i < 48; i++)
            {
                int eventsAdded = 0;
                AgendaTextBox text = new AgendaTextBox();
                text.associatedDateTime = currentTime;

                for (int j = 0; j < dayEvents.Count; j++)
                {
                    for(int k = 0; k < dayEvents[j].dateTimes.Count; k++)
                    {
                        
                        if (text.associatedDateTime < dayEvents[j].dateTimes[k].Item2 && text.associatedDateTime >= dayEvents[j].dateTimes[k].Item1)
                        {
                            if (!text.associatedEvents.Contains(dayEvents[j]))
                            {
                                text.associatedEvents.Add(dayEvents[j]);
                            }
                        }
                    }
                }

                text.GotFocus += hideTextBoxCursor;
                foreach (Event ev in text.associatedEvents)
                {
                    if (text.Text.Length + ev.ToString().Length > 94)
                    {
                        if (eventsAdded == 0)
                        {
                            text.Text += "Event text too long to display. Click for details.";
                        }
                        else
                        {
                            text.Text += "others...";
                        }
                        break;
                    }
                    else
                    {
                        text.Text += ev.ToString();
                        if (eventsAdded < text.associatedEvents.Count-1)
                        {
                            text.Text += ", ";
                        }
                    }
                    eventsAdded++;
                }
                Label timeLabel = new Label();
                timeLabel.Anchor = (AnchorStyles.Right);
                if (!use24Hour)
                {
                    timeLabel.Text = "              " + currentTime.ToShortTimeString();
                }
                else
                {
                    String twentyFourFormat = "HH:mm";
                    timeLabel.Text = "              " + currentTime.ToString(twentyFourFormat);
                }
                text.ReadOnly = true;
                text.Multiline = true;

                text.Click += Text_Click;

                TextBoxArray[i] = text;
                text.Name = "text" + i.ToString();
                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(300, 50);
                flowLayoutPanel1.Controls.Add(timeLabel);
                flowLayoutPanel1.Controls.Add(text);
                currentTime = currentTime.AddMinutes(30);
            }
            monthCalendar1.SelectionStart = startingDate;
            monthCalendar1.SelectionEnd = startingDate;
            currentDateLabel.Text = startingDate.ToShortDateString();
        }

        /// <summary>
        /// Click behavior for the Agenda text boxes.
        /// Opens the addavailabilitywindow so the user can flag themselves available for events.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void Text_Click(object sender, EventArgs e)
        {
            AgendaTextBox send = sender as AgendaTextBox;
            if (send.associatedEvents != null && send.associatedEvents.Count != 0)
            {
                AddAvailabilityWindow addAvail = new AddAvailabilityWindow(send.associatedEvents, userName, evtList, use24Hour);
                addAvail.ShowDialog();
            }
            else
            {
                MessageBox.Show("This time slot has no events.");
            }
        }

        //Source of JSON Work: https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
    
        /// <summary>
        /// Deserialize the JSON save file into a list of events.
        /// </summary>
        private void pullEventsFromJSON()
        {
            // read file into a string and deserialize JSON to a type
            if (File.Exists(path))
            {
                evtList = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));
                foreach (Event e in evtList)
                {
                    Console.Write(e.getHost());
                }
            }
        }

        /// <summary>
        /// GotFocus behavior for the agenda text boxes. Hides the insertion caret.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="args">Winforms event arguments.</param>
        private void hideTextBoxCursor(object sender, EventArgs args)
        {
            TextBox box = sender as TextBox;
            HideCaret(box.Handle);
        }

        /// <summary>
        /// Click behavior for the close button. Closes the form.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
