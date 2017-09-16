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
            foreach(Event i in evtList)
            {
                if (i.host.Equals(userName))
                {
                    yourEvents.Add(i);
                }
            }
            yourEventsBox.DataSource = yourEvents;
            yourEventsBox.SelectedIndex = 0;
            Event ev = (Event)yourEventsBox.SelectedItem;
            List<Tuple<String, List<DateTime>>> testList = new List<Tuple<string, List<DateTime>>>();
            List<DateTime> testTimes = new List<DateTime>();
            testTimes.Add(DateTime.Today);
            testTimes.Add(DateTime.Today.AddHours(5));
            testList.Add(new Tuple<string, List<DateTime>>("Jakob", testTimes));
            ev.attendees = testList;
            if (ev != null) {
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
    }
}
