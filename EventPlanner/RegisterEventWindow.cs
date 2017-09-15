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
                //start at midnight, add DateTimes in 30 minute increments until we have all 48
                halfHourDateTimes.Add(currentTime);
                //convert to string - military time string if it's enabled, regular otherwise
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
            //use the list of times as the list of options for our time boxes
            startTimeBox.DataSource = halfHourStrings;

            endTimeBox.BindingContext = new BindingContext();
            endTimeBox.DataSource = halfHourStrings;
            //put the time boxes in a tuple to associate them and put it in a list to keep track of it
            timeBoxes.Add(new Tuple<ComboBox, ComboBox>(startTimeBox, endTimeBox));
        }
        //make a new event object with the user's chosen options, write it to file
        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach(Tuple<ComboBox, ComboBox> currentBoxes in timeBoxes)
            {
                String endTimeString = (String)currentBoxes.Item2.SelectedItem;
                String startTimeString = (String)currentBoxes.Item1.SelectedItem;
                DateTime startTime = DateTime.Parse(startTimeString);
                DateTime endTime = DateTime.Parse(endTimeString);
                //ensure the time slots are valid
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



                    //string path = @"C:\Users\Alexander\Desktop\Example.txt";
                    //string path = @".\test.txt";
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/eventSaveFile.txt";

                    //if (!File.Exists(path))
                    //{
                      //  File.Create(path);
                        //TextWriter tw = new StreamWriter(path);
                        // tw.WriteLine("The very first line!");
                        //tw.Close();
                    //}
                    //else if (File.Exists(path))
                    //{
                    //    TextWriter tw = new StreamWriter(path);
                    //    tw.WriteLine("The next line!");
                    //    tw.Close();
                    //}

                    // Write the string to a file.
                    System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                    file.WriteLine(startTime);
                    file.WriteLine("\n");
                    file.WriteLine(endTime);

                    file.Close();
                }
            }

        }
        //dynamically add two more combo boxes to enter a new start time and end time for a new time window
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
       //remove aditional time windows if you've added them
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
