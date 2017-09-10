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
    public partial class SelectMode : Form
    {
        public SelectMode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserWindow user = new UserWindow();
            user.Show();
        }
    }
}
