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

namespace WindowsFormsApplication1
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            DateTime startdate = DateTime.Today;
            DateTime endDate = startdate.AddDays(1);
            CalendarItem item = new CalendarItem(calendar1, startdate, endDate, "testEvent");
            calendar1.Items.Add(item);
        }

        private void monthView2_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SelectionStart = monthView2.SelectionStart;
            calendar1.Refresh();
        }
    }
}
