using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RegisterEventWindow : Form
    {
        public RegisterEventWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Write event specified by user to file
            this.Close();
        }

        private void addSlotButton_Click(object sender, EventArgs e)
        {
            //add another row of combo boxes for the user to add another, non-contiguous timeslot
        }
    }
}
