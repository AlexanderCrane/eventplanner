using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CheckEventsForm : Form
    {
        List<Event> evtList;
        string userName;
        bool closeImmediately = false;
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";

        public CheckEventsForm(string userName)
        {
            evtList = new List<Event>();
            this.userName = userName;
            InitializeComponent();
        }

        private void CheckEventsForm_Load(object sender, EventArgs e)
        {
            pullEventsFromJSON();
            List<Event> yourEvents = new List<Event>();
            foreach (Event i in evtList)
            {
                if (i.host.Equals(userName))
                {
                    yourEvents.Add(i);
                }
            }

            yourEventsBox.DataSource = yourEvents;
            Event ev = null;
            if (yourEvents.Count != 0)
            {
                yourEventsBox.SelectedIndex = 0;
                ev = (Event)yourEventsBox.SelectedItem;
            }
            else
            {
                this.Close();
                MessageBox.Show("You have not created any events!");
            }
            if (ev != null)
            {
                if (ev.attendees != null)
                {
                    foreach (Tuple<String, List<DateTime>> tuple in ev.attendees)
                    {
                        List<String> timeStrings = new List<string>();
                        foreach (DateTime dt in tuple.Item2)
                        {
                            timeStrings.Add(dt.ToShortTimeString());
                        }
                        attendeesBox.Text += tuple.Item1;
                        attendeesBox.Text += ":";
                        attendeesBox.Text += String.Join(",", timeStrings);
                        attendeesBox.Text += "\r\n";
                    }
                }
            }
        }
        private void pullEventsFromJSON()
        {
            // read file into a string and deserialize JSON to a type
            if (File.Exists(path))
            {
                evtList = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));


            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
