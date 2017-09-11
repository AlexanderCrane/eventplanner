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

namespace WindowsFormsApplication1
{
    public partial class RegisterEventWindow : Form
    {

        //user can add new time slots to an event 
        //maintain a list of the boxes for entering these so we can reference them when they save
        List<ComboBox> startTimes = new List<ComboBox>();
        List<ComboBox> endTimes = new List<ComboBox>();


        //list of times that we use as the source for our dropdown has to be strings to be formatted properly
        //we can reference them against the original list of datetimes for actual logic
        List<DateTime> halfHourDateTimes = new List<DateTime>();
        List<String> halfHourStrings = new List<String>();
        public RegisterEventWindow()
        {
            InitializeComponent();
            DateTime currentTime = DateTime.Today;
            for (int i = 0; i < 48; i++)
            {
                halfHourDateTimes.Add(currentTime);
                halfHourStrings.Add(currentTime.ToShortTimeString());
                currentTime = currentTime.AddMinutes(30);
            }
            startTimeBox.DataSource = halfHourStrings;
            startTimes.Add(startTimeBox);

            endTimeBox.BindingContext = new BindingContext();
            endTimeBox.DataSource = halfHourStrings;
            endTimes.Add(endTimeBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            startTimes[0].SelectedItem
            //Write event specified by user to file
            this.Close();
        }

        private void addSlotButton_Click(object sender, EventArgs e)
        {

            ComboBox newStartBox = new ComboBox();
            newStartBox.Text = "Start Time";
            newStartBox.BindingContext = new BindingContext();
            newStartBox.DataSource = halfHourStrings;

            ComboBox newEndBox = new ComboBox();
            newEndBox.Text = "End Time";
            newEndBox.BindingContext = new BindingContext();
            newEndBox.DataSource = halfHourStrings;

            startTimes.Add(newStartBox);
            endTimes.Add(newEndBox);
            flowLayoutPanel1.Controls.Add(newStartBox);
            flowLayoutPanel1.Controls.Add(newEndBox);
            //add another row of combo boxes for the user to add another, non-contiguous timeslot
        }

        private void removeTimeSlotButton_Click(object sender, EventArgs e)
        {
            if (startTimes.Count > 1 && endTimes.Count > 1)
            {
                flowLayoutPanel1.Controls.Remove(startTimes.Last());
                flowLayoutPanel1.Controls.Remove(endTimes.Last());
                startTimes.Remove(startTimes.Last());
                endTimes.Remove(endTimes.Last());
            }
        }
    }
}
