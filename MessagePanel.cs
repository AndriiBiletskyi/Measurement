using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomiaryGUI
{
    public partial class MessagePanel : UserControl
    {
        public MessagePanel()
        {
            InitializeComponent();
        }

        public void Show(string str)
        {
            textBox.Text += str;
        }
    }
}
