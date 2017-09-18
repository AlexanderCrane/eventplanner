using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Form allowing user to add a new event.
    /// </summary>
    public partial class RegisterEventWindow : Form
    {

        //user can add new time slots to an event 
        //maintain a list of the boxes for entering these so we can reference them when they save
        List<Tuple<ComboBox, ComboBox>> timeBoxes = new List<Tuple<ComboBox, ComboBox>>();
        
        List<ComboBoxDateTime> halfHourDateTimes = new List<ComboBoxDateTime>();
        List<ComboBoxDateTime> halfHourDateTimesForEnd = new List<ComboBoxDateTime>();

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";

        private string userName;

        /// <summary>
        /// Constructor for the RegisterEventWindow form.
        /// </summary>
        /// <param name="selectedDate">The date selected by the user.</param>
        /// <param name="use24Hour">Whether 24 hour time will be used.</param>
        /// <param name="username">The name provided by the user.</param>
        public RegisterEventWindow(DateTime selectedDate, bool use24Hour, string username)
        {
            InitializeComponent();
            userName = username;
            dateLabel.Text = "Adding event for: " + selectedDate.ToShortDateString();

            //int local_hrs; 

            ComboBoxDateTime currentTime = new ComboBoxDateTime(selectedDate, use24Hour);


            /*
             ** To show only valid time slots. For today, don't show time slots for time that has passed.
             */
            //If the selected date is after today, show all 48 time slots. That is, let the loop run 48 times.
            //if ( selectedDate.Date > DateTime.Now)
            //{
            //    currentTime = new ComboBoxDateTime(selectedDate.Date, use24Hour);
            //    local_hrs = -1;
            //}

            ////If the selected date is today, round off to the nearest next half hour using the Round method. Pass that to ComboBoxDateTime
            ////Loop should run such that only slots till midnight are displayed. Should not run 48 times.
            //else
            //{
            //    DateTime test = Round(DateTime.Now); //Get current time rounded to the next hour
            //    currentTime = new ComboBoxDateTime(test, use24Hour);
            //    local_hrs = DateTime.Now.Hour*2; 
            //}

            for (int i = 0; i < 48; i++)
            {
                if (currentTime.inner >= DateTime.Now)
                {
                    halfHourDateTimes.Add(currentTime);
                    halfHourDateTimesForEnd.Add(currentTime);
                }
                currentTime = new ComboBoxDateTime(currentTime.inner.AddMinutes(30), use24Hour);
            }
            DateTime midnight = selectedDate.AddDays(1);
            halfHourDateTimesForEnd.Add(new ComboBoxDateTime(midnight, use24Hour));
            //use the list of times as the list of options for our time boxes
            startTimeBox.DataSource = halfHourDateTimes;
            startTimeBox.DisplayMember = "shortTimeString";

            endTimeBox.BindingContext = new BindingContext();
            endTimeBox.DataSource = halfHourDateTimesForEnd;
            endTimeBox.DisplayMember = "shortTimeStringForEndBoxes";

            //put the time boxes in a tuple to associate them and put it in a list to keep track of it
            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(startTimeBox, endTimeBox));
        }

        /// <summary>
        /// Round a DateTime to the nearest 30 minutes.
        /// </summary>
        /// <param name="dateTime">The Current Date selected by the user.</param>
        public static DateTime Round(DateTime dateTime)
        {
            var updated = dateTime.AddMinutes(30);

            if (dateTime.Minute < 30)
            {
                return new DateTime(updated.Year, updated.Month, updated.Day,
                                 updated.Hour, 30, 0, dateTime.Kind);
            }
            else
            {
                return new DateTime(updated.Year, updated.Month, updated.Day,
                                 updated.Hour, 0, 0, dateTime.Kind);
            }
            
        }

        //make a new event object with the user's chosen options, write it to file
        /// <summary>
        /// Click behavior for the save button.
        /// Check for valid input in the form and collect user input.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            String errorText = "";
            Boolean inputError = false;
            Boolean comboBoxError = false;

            DateTime previousEndTime = DateTime.MinValue;
            DateTime previousStartTime = DateTime.MinValue;

            int capInt;
            bool timeWindowError = false;

            List<Tuple<DateTime, DateTime>> dateTimes = new List<Tuple<DateTime, DateTime>>();

            int.TryParse(capacityText.Text, out capInt);
            foreach (Tuple<ComboBox, ComboBox> currentBoxes in timeBoxes)
            {
                //ensure the time slots are valid
                //if end time is 12:00 AM that is equivalent to 11:59:59 pm, not a repeat or smaller number.
                DateTime startTime = (currentBoxes.Item1.SelectedValue as ComboBoxDateTime).inner;
                DateTime endTime = (currentBoxes.Item2.SelectedValue as ComboBoxDateTime).inner;

                if (endTime <= startTime && !endTime.ToShortTimeString().Equals("12:00 AM") && !comboBoxError)
                {
                    errorText = String.Concat(errorText, "At least one of the time slots is impossible.");
                    comboBoxError = true;
                    inputError = true;
                }
                if (endTime.ToShortTimeString().Equals("12:00 AM"))
                {
                    endTime = endTime.AddDays(1);
                }
                if (((startTime >= previousStartTime) && (startTime <= previousEndTime)||
                    ((endTime >= previousStartTime) && (endTime <= previousEndTime))) && (startTime != previousEndTime) && !timeWindowError)
                {
                        errorText = String.Concat(errorText, "\nTwo of the selected time windows overlap.");
                        inputError = true;
                        timeWindowError = true;
                }
                previousStartTime = startTime;
                previousEndTime = endTime;

                dateTimes.Add(new Tuple<DateTime, DateTime>(startTime, endTime));
                dateTimes.Sort((x, y) => DateTime.Compare(x.Item1, y.Item1));

            }
            if (nameTextBox.Text.Length == 0)
            {
                errorText = String.Concat(errorText, "\n Event name cannot be empty.");
                inputError = true;
            }
            if (nameTextBox.Text.Length > 36)
            {
                errorText = String.Concat(errorText, "\nEvent name is too long.");
                inputError = true;
            }
            if (File.Exists(path))
            {
                List<Event> evts = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));
                foreach (Event evt in evts)
                {
                    if (evt.nameOfEvent == nameTextBox.Text)
                    {
                        inputError = true;
                        errorText = String.Concat(errorText, "\nEvent name already exists.");
                    }
                }
            }
            
            if (capInt == 0)
            {
                errorText = String.Concat(errorText, "\nCapacity must be a nonzero number.");
                inputError = true;
            }
            if (locationText.Text.Length == 0)
            {
                errorText = String.Concat(errorText, "\n Event Location cannot be empty.");
                inputError = true;
            }
            if (briefMessageText.Text.Length == 0)
            {
                errorText = String.Concat(errorText, "\n Event Description cannot be empty.");
                inputError = true;
            }
            if (inputError)
            {
                MessageBox.Show(errorText);
            }
            else
            {
                buildEvent(capInt, dateTimes);
            }
        }

        /// <summary>
        /// Builds a new event object from the user's input and writes it to file.
        /// </summary>
        /// <param name="capInt">The user's chosen capacity value, converted to int.</param>
        /// <param name="dateTimes">The user's chosen DateTime time slots</param>
        private void buildEvent(int capInt, List<Tuple<DateTime, DateTime>> dateTimes)
        {
            //Write event specified by user to file
            this.Close();

            Event evt = new Event(nameTextBox.Text, userName, briefMessageText.Text, dateTimes, locationText.Text, 1, capInt);
            List<Tuple<String, List<DateTime>>> startingAttendees = new List<Tuple<string, List<DateTime>>>();
            List<DateTime> attendeeDTs = new List<DateTime>();

            foreach (Tuple<DateTime, DateTime> tuple in dateTimes)
            {
                DateTime currentTime = tuple.Item1;
                while (currentTime != tuple.Item2)
                {
                    attendeeDTs.Add(currentTime);
                    currentTime = currentTime.AddMinutes(30);
                }
            }
            startingAttendees.Add(new Tuple<String, List<DateTime>>(userName, attendeeDTs));
            evt.attendees = startingAttendees;

            JsonSerializer serializer = new JsonSerializer();

            // Write the string to a file.
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter file = new StreamWriter(path, append: true))
                    {
                        //TODO add event to usersavefile too.
                        List<Event> evts = new List<Event>();
                        evts.Add(evt);
                        serializer.Serialize(file, evts);
                    }
                }
                else
                {
                    List<Event> evts = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));
                    evts.Add(evt);
                    using (StreamWriter file = new StreamWriter(path, append: false))
                    {
                        serializer.Serialize(file, evts);
                    }
                }
                MessageBox.Show("Event created! You will be added as an attendee to this event.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("File write failed with exception." + ex.ToString());
            }

        }

        /// <summary>
        /// Click behavior for the add slot button.
        /// Dynamically add two more combo boxes for the user to input a second, non-contiguous time slot.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void addSlotButton_Click(object sender, EventArgs e)
        {
            ComboBox newStartBox = new ComboBox();
            newStartBox.Text = "Start Time";
            newStartBox.BindingContext = new BindingContext();
            newStartBox.DataSource = halfHourDateTimes;
            newStartBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBox newEndBox = new ComboBox();
            newEndBox.Text = "End Time";
            newEndBox.BindingContext = new BindingContext();
            newEndBox.DataSource = halfHourDateTimesForEnd;
            newEndBox.DropDownStyle = ComboBoxStyle.DropDownList;

            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(newStartBox, newEndBox));
            flowLayoutPanel1.Controls.Add(newStartBox);
            flowLayoutPanel1.Controls.Add(newEndBox);
            //add another row of combo boxes for the user to add another, non-contiguous timeslot
        }
        //remove aditional time windows if you've added them
        /// <summary>
        /// Click behavior for the remove time slot button.
        /// Remove the last added time slot.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void removeTimeSlotButton_Click(object sender, EventArgs e)
        {
            if (timeBoxes.Count > 1)
            {
                flowLayoutPanel1.Controls.Remove(timeBoxes.Last().Item1);
                flowLayoutPanel1.Controls.Remove(timeBoxes.Last().Item2);
                timeBoxes.Remove(timeBoxes.Last());
            }
        }

        /// <summary>
        /// KeyPress behavior for the capacity textbox.
        /// Prevents the addition of any characters other than digits.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>

        private void capacityText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// A wrapper for the DateTime class for 24 hour formatting.
        /// </summary>
        private class ComboBoxDateTime
        {
            private String sts;
            /// <summary>
            /// The short time string of the contained DateTime.
            /// </summary>
            public string shortTimeString { get { return sts; } set { sts = value; } }
            /// <summary>
            /// The short time string of the contained date time, with (Next Day) appended if it's 12:00AM.
            /// </summary>
            public string shortTimeStringForEndBoxes
            {
                get { if (!sts.Equals("12:00 AM")){
                        return sts;
                    }
                    else
                    {
                        return (sts + "(Next Day)");
                    }
                }
                set { shortTimeStringForEndBoxes = value; }
            }
            /// <summary>
            /// The DateTime contained by the wrapper class.
            /// </summary>
            public DateTime inner;
            /// <summary>
            /// Constructor for the ComboBoxDateTime wrapper object.
            /// </summary>
            /// <param name="dt">The dateTime to be contained by the object</param>
            /// <param name="use24Hour">Whether to use 24 hour time.</param>
            public ComboBoxDateTime(DateTime dt, bool use24Hour)
            {
                this.inner = dt;
                if (use24Hour)
                {
                    String dateFormat = "HH:mm";
                    this.sts = inner.ToString(dateFormat);
                }
                else
                {
                    this.sts = inner.ToShortTimeString();
                }

            }
            /// <summary>
            /// ToString override for ComboBoxDateTime. 
            /// </summary>
            /// <returns>The short time string of the object's DateTime in the specified format.</returns>
            public override string ToString()
            {
                return this.sts;
            }
        }

        /// <summary>
        /// Click behavior for the cancel button.
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
