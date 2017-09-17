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
            ComboBoxDateTime currentTime = new ComboBoxDateTime(selectedDate.Date, use24Hour);
            for (int i = 0; i < 48; i++)
            {
                //start at midnight, add DateTimes in 30 minute increments until we have all 48
                halfHourDateTimes.Add(currentTime);
                currentTime = new ComboBoxDateTime(currentTime.inner.AddMinutes(30), use24Hour);
            }
            //use the list of times as the list of options for our time boxes
            startTimeBox.DataSource = halfHourDateTimes;
            startTimeBox.DisplayMember = "shortTimeString";

            endTimeBox.BindingContext = new BindingContext();
            endTimeBox.DataSource = halfHourDateTimes;
            endTimeBox.DisplayMember = "shortTimeStringForEndBoxes";

            //put the time boxes in a tuple to associate them and put it in a list to keep track of it
            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(startTimeBox, endTimeBox));
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
                    ((endTime >= previousStartTime) && (endTime <= previousEndTime))) && !timeWindowError)
                {
                    errorText = String.Concat(errorText, "\nTwo of the selected time windows overlap.");
                    inputError = true;
                    timeWindowError = true;
                }
                previousStartTime = startTime;
                previousEndTime = endTime;

                dateTimes.Add(new Tuple<DateTime, DateTime>(startTime, endTime));
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

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";
            JsonSerializer serializer = new JsonSerializer();

            // Write the string to a file.
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter file = new StreamWriter(path, append: true))
                    {
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
                MessageBox.Show("Event created!");

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            newEndBox.DataSource = halfHourDateTimes;
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

        /*
         * Note: Brief Message Stored
         * Author Austin
        */
        private void briefMessage_TextChanged(object sender, EventArgs e)
        {
            //Nothing important happened today
        }

        private void capacityText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private class ComboBoxDateTime
        {
            private String sts;
            public string shortTimeString { get { return sts; } set { sts = value; } }
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
            public DateTime inner;
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
            public override string ToString()
            {
                return this.sts;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
