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
    public partial class AdminWindow : Form
    {
        Size currentSize;
        //this is a weird trick to prevent the text position caret from showing up when we click on our read-only calendar text boxes?
        //its ugly but it works

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public AdminWindow()
        {
            currentSize = this.Size;
            InitializeComponent();
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            //NO POINT TO THIS IN ADMIN
            //TODO - discuss design with team
            TextBox[] TextBoxArray = new TextBox[48];
            DateTime currentTime = DateTime.Today;
            
            for (int i = 0; i < 48; i++)
            { 
                TextBox text = new TextBox();
                text.GotFocus += hideTextBoxCursor;
                Label timeLabel = new Label();
                timeLabel.Anchor = (AnchorStyles.Right);

                timeLabel.Text = "              " + currentTime.ToShortTimeString();

                Console.Out.WriteLine(timeLabel.Width.ToString());
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

        private void addEventButton_Click(object sender, EventArgs e)
        {
            //open 'add event dialog'
            RegisterEventWindow registerPopup = new RegisterEventWindow(monthCalendar1.SelectionStart);
            registerPopup.ShowDialog();
        }

        private void changeHourButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I work, but I don't do my job :D");

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 8 == 0)
            {
                flowLayoutPanel1.SetFlowBreak(e.Control as Control, true);
            }

        }

        private void AdminWindow_Resize(object sender, EventArgs e)
        {

        }
    }
}
