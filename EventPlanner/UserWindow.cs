using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class UserWindow : Form
    {
        //this is a weird trick to prevent the text position caret from showing up when we click on our read-only calendar text boxes?
        //its ugly but it works

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
            System.Diagnostics.Debug.WriteLine(this.userName);
        }


        /// <summary>
        /// Date Selected behavior for the calendar.
        /// Updates the selected date when it changes and updates the 'agenda' panel to show that day's events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            getEventsForTheDay(e.Start);
            currentDateLabel.Text = e.Start.ToShortDateString();
            for (int i = 0; i < 48; i++)
            {
                AgendaTextBox text = TextBoxArray[i];
                text.Text = "";
                text.associatedEvents.Clear();
            }
            for (int i = 0; i<48; i++) {
                AgendaTextBox text = TextBoxArray[i];
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
                    text.Text += ev.ToString() + " ";
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
        /// Creates A List of Events This Day
        /// </summary>
        private void getEventsForTheDay(DateTime currentTime)
        {
            //cleardayEvents
            if (dayEvents != null)
            {
                dayEvents.Clear();
            }
            //dayEvents
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

        //add 48 textboxes to a panel, one for each time slot
        //todo - load events from file to associate with these and displayt heir names
        /// <summary>
        /// Load behavior for the user window.
        /// Populates the 'agenda' panel of textboxes and loads the events from the day selected in MainWindow into them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWindow_Load(object sender, EventArgs e)
        {
            DateTime currentTime = startingDate;

            monthCalendar1.SelectionStart = startingDate;
            monthCalendar1.SelectionEnd = startingDate;
            currentDateLabel.Text = startingDate.ToShortDateString();

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
                //Event testEvent = new Event("33323289679111673265050105032946746271022", "Austin", "asfajkaj", new List<Tuple<DateTime, DateTime>>(), "Mass St", 50, 100);
                //Event testEventtwo = new Event("3360292493154691677656104369796918174839742715026412054022817489762285530991460209690737435657947018", "Austin", "asfajkaj", new List<Tuple<DateTime, DateTime>>(), "Mass St", 50, 100);

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
                    text.Text += ev.ToString() + " ";
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
        }

        private void Text_Click(object sender, EventArgs e)
        {
            AgendaTextBox send = sender as AgendaTextBox;
            System.Diagnostics.Debug.WriteLine(userName);

            AddAvailabilityWindow addAvail = new AddAvailabilityWindow(send.associatedEvents, userName, evtList);
            addAvail.ShowDialog();
        }

        //Source of JSON Work: https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
        //& Jackob
        //NOTE: 
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void hideTextBoxCursor(object sender, EventArgs args)
        {
            TextBox box = sender as TextBox;
            HideCaret(box.Handle);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
