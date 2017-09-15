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


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();

        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserWindow_Load(object sender, EventArgs e)
        {
            TextBox[] TextBoxArray = new TextBox[48];
            DateTime currentTime = DateTime.Today;

            for (int i = 0; i < 48; i++)
            {
                TextBox text = new TextBox();
                text.GotFocus += hideTextBoxCursor;
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

                text.Click += Text_Click;

                TextBoxArray[i] = text;
                text.Name = "text" + i.ToString();
                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(300, 30);
                flowLayoutPanel1.Controls.Add(timeLabel);
                flowLayoutPanel1.Controls.Add(text);
                currentTime = currentTime.AddMinutes(30);
            }

            TextBoxArray[3].Text = "test";

            currentDateLabel.Text = DateTime.Today.ToShortDateString();
        }

        private void Text_Click(object sender, EventArgs e)
        {
            AddAvailabilityWindow addAvail = new AddAvailabilityWindow();
            addAvail.ShowDialog();
        }

        private void hideTextBoxCursor(object sender, EventArgs args)
        {
            TextBox box = sender as TextBox;
            HideCaret(box.Handle);
        }
    }
}
