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
    public partial class JoinEventWindow : Form
    {
        public JoinEventWindow(String senderText)
        {
            label1.Text = senderText;
            InitializeComponent();
        }
    }
}
