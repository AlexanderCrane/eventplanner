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
            Event ev = (Event)yourEventsBox.SelectedItem;
            if (ev.attendees != null)
            {
                String attendees = string.Join(",", ev.attendees);
            }
            attendeesBox.Text += (ev.attendees + ",");
                
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
