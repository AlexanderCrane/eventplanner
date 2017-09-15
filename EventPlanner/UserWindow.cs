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

        public UserWindow(bool use24Hour)
        {
            this.use24Hour = use24Hour;
            InitializeComponent();
        }

        //display the selected date
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();

        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //add 48 textboxes to a panel, one for each time slot
        //todo - load events from file to associate with these and displayt heir names
        private void UserWindow_Load(object sender, EventArgs e)
        {
            AgendaTextBox[] TextBoxArray = new AgendaTextBox[48];
            DateTime currentTime = DateTime.Today;

            for (int i = 0; i < 48; i++)
            {
                
               // Event testEvent = new Event("NarutoRunDownMass", "Austin", "asfajkaj", "19:00", "21:00", "Mass St", 50, 100);

                AgendaTextBox text = new AgendaTextBox();

               // text.associatedEvents.Add(testEvent);
                text.GotFocus += hideTextBoxCursor;
                foreach(Event ev in text.associatedEvents)
                {
                    text.Text += ev;
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

                TextBoxArray[i] = text;
                text.Name = "text" + i.ToString();
                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(300, 30);
                flowLayoutPanel1.Controls.Add(timeLabel);
                flowLayoutPanel1.Controls.Add(text);
                currentTime = currentTime.AddMinutes(30);
            }

            currentDateLabel.Text = DateTime.Today.ToShortDateString();
        }


        private void hideTextBoxCursor(object sender, EventArgs args)
        {
            TextBox box = sender as TextBox;
            HideCaret(box.Handle);
        }
    }
}
