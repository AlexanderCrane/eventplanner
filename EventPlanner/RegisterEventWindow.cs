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

namespace WindowsFormsApplication1
{
    public partial class RegisterEventWindow : Form
    {

        //user can add new time slots to an event 
        //maintain a list of the boxes for entering these so we can reference them when they save
        List<Tuple<ComboBox, ComboBox>> timeBoxes = new List<Tuple<ComboBox, ComboBox>>();
        List<ComboBox> endTimes = new List<ComboBox>();
        public int numberOfEvents = 0;

        //list of times that we use as the source for our dropdown has to be strings to be formatted properly
        //we can reference them against the original list of datetimes for actual logic
        List<DateTime> halfHourDateTimes = new List<DateTime>();
        List<String> halfHourStrings = new List<String>();
        public RegisterEventWindow(DateTime selectedDate, bool use24Hour)
        {
            InitializeComponent();
            dateLabel.Text = "Adding event for: " + selectedDate.ToShortDateString();
            DateTime currentTime = selectedDate.Date;
            for (int i = 0; i < 48; i++)
            {
                halfHourDateTimes.Add(currentTime);
                if (!use24Hour)
                {
                    halfHourStrings.Add(currentTime.ToShortTimeString());
                }
                else
                {
                    String twentyFourFormat = "HH:mm";
                    halfHourStrings.Add(currentTime.ToString(twentyFourFormat));
                }
                currentTime = currentTime.AddMinutes(30);
            }
            startTimeBox.DataSource = halfHourStrings;

            endTimeBox.BindingContext = new BindingContext();
            endTimeBox.DataSource = halfHourStrings;
            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(startTimeBox, endTimeBox));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach(Tuple<ComboBox, ComboBox> currentBoxes in timeBoxes)
            {
                String endTimeString = (String)currentBoxes.Item2.SelectedItem;
                String startTimeString = (String)currentBoxes.Item1.SelectedItem;
                DateTime startTime = DateTime.Parse(startTimeString);
                DateTime endTime = DateTime.Parse(endTimeString);

                //if end time is 12:00 AM that is equivalent to 11:59:59 pm, not a repeat or smaller number.
                if (endTime <= startTime && endTime.ToShortTimeString() != "12:00 AM")
                {
                    MessageBox.Show("At least one of the time slots is impossible.");
                    break;
                }
                else
                {
                    //Write event specified by user to file
                    this.Close();
                    MessageBox.Show("Event Created!");

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/eventSaveFile.json";

                    System.IO.StreamWriter file;
                    if (numberOfEvents == 0)
                    {
                        // Write the string to a file.
                        file = new System.IO.StreamWriter(path);
                    }
                    else
                    {
                        file = new System.IO.StreamWriter(path);
                    }
                    numberOfEvents++;

                    //JSON
                    //file.WriteLine(eventName, ",", capacity, ",", briefMsg, ",", startTime, ",", endTime);
                    file.Close();
                }
            }

        }

        private void addSlotButton_Click(object sender, EventArgs e)
        {

            ComboBox newStartBox = new ComboBox();
            newStartBox.Text = "Start Time";
            newStartBox.BindingContext = new BindingContext();
            newStartBox.DataSource = halfHourStrings;
            newStartBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBox newEndBox = new ComboBox();
            newEndBox.Text = "End Time";
            newEndBox.BindingContext = new BindingContext();
            newEndBox.DataSource = halfHourStrings;
            newEndBox.DropDownStyle = ComboBoxStyle.DropDownList;

            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(newStartBox, newEndBox));
            flowLayoutPanel1.Controls.Add(newStartBox);
            flowLayoutPanel1.Controls.Add(newEndBox);
            //add another row of combo boxes for the user to add another, non-contiguous timeslot
        }

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
            //do nothing yet
        }
    }
}
