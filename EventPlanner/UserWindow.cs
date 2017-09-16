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

        /// <summary>
        /// Constructor for the user window.
        /// </summary>
        /// <param name="use24Hour">Whether to use 24 hour times in the 'agenda' panel.</param>
        /// <param name="selectedDate">The date selected previously on the main window calendar.</param>
        public UserWindow(bool use24Hour, DateTime selectedDate)
        {
            InitializeComponent();
            this.use24Hour = use24Hour;
            this.startingDate = selectedDate;
        }

        
        /// <summary>
        /// Date Selected behavior for the calendar.
        /// Updates the selected date when it changes and updates the 'agenda' panel to show that day's events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();

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
            AgendaTextBox[] TextBoxArray = new AgendaTextBox[48];
            DateTime currentTime = DateTime.Today;

            monthCalendar1.SelectionStart = startingDate;
            monthCalendar1.SelectionEnd = startingDate;
            currentDateLabel.Text = startingDate.ToShortDateString();

            for (int i = 0; i < 48; i++)
            {
                
                Event testEvent = new Event("NarutoRunDownMass123456789012345678901234567890", "Austin", "asfajkaj", new List<Tuple<DateTime, DateTime>>(), "Mass St", 50, 100);

                AgendaTextBox text = new AgendaTextBox();

                text.associatedEvents.Add(testEvent);
                text.GotFocus += hideTextBoxCursor;
                foreach(Event ev in text.associatedEvents)
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
            AddAvailabilityWindow addAvail = new AddAvailabilityWindow(send.associatedEvents);
            addAvail.ShowDialog();
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
    }
}
