﻿using System;
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
        List<ComboBox> endTimes = new List<ComboBox>();

        //list of times that we use as the source for our dropdown has to be strings to be formatted properly
        //we can reference them against the original list of datetimes for actual logic
        List<ComboBoxDateTime> halfHourDateTimes = new List<ComboBoxDateTime>();
        List<String> halfHourStrings = new List<String>();

        public int numberOfEvents = 0;

        /// <summary>
        /// Constructor for the RegisterEventWindow form.
        /// </summary>
        /// <param name="selectedDate">The date selected by the user.</param>
        /// <param name="use24Hour">Whether 24 hour time will be used.</param>
        public RegisterEventWindow(DateTime selectedDate, bool use24Hour)
        {
            InitializeComponent();
            dateLabel.Text = "Adding event for: " + selectedDate.ToShortDateString();
            ComboBoxDateTime currentTime = new ComboBoxDateTime(selectedDate.Date, use24Hour);
            for (int i = 0; i < 48; i++)
            {
                //start at midnight, add DateTimes in 30 minute increments until we have all 48
                halfHourDateTimes.Add(currentTime);
                //convert to string - military time string if it's enabled, regular otherwise
                if (!use24Hour)
                {
                    halfHourStrings.Add(currentTime.shortTimeString);
                }
                else
                {
                    String twentyFourFormat = "HH:mm";
                    halfHourStrings.Add(currentTime.inner.ToString(twentyFourFormat));
                }
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
        /// Write the event specified by the user to a file as JSON.
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            String errorText = "";
            Boolean inputError = false;
            Boolean comboBoxError = false;
            DateTime previousEndTime = DateTime.MinValue;
            int capInt;
            bool timeWindowError = false;
            List<Tuple<DateTime, DateTime>> dateTimes = new List<Tuple<DateTime, DateTime>>();
            int.TryParse(capacityText.Text, out capInt);
            foreach (Tuple<ComboBox, ComboBox> currentBoxes in timeBoxes)
            {
                //ensure the time slots are valid
                //if end time is 12:00 AM that is equivalent to 11:59:59 pm, not a repeat or smaller number.
                //if both times are 12:00AM we have to put the event into every text box!!!
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
                else if (startTime <= previousEndTime && !timeWindowError)
                {
                    errorText = String.Concat(errorText, "Two of the selected time windows overlap.");
                    inputError = true;
                    timeWindowError = true;
                }
                previousEndTime = endTime;

                dateTimes.Add(new Tuple<DateTime, DateTime>(startTime, endTime));
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
            if (inputError)
            {
                MessageBox.Show(errorText);               
            }
            else
            {
                //Write event specified by user to file
                this.Close();
                MessageBox.Show("Event Created!");

                Event evt = new Event(nameTextBox.Text, "Austin", briefMessageText.Text, dateTimes, locationText.Text, 1, capInt);

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
                            numberOfEvents++;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File write failed with exception." + ex.ToString());
                    }
                
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

    }
}
