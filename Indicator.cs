using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomiaryGUI
{
    public partial class Indicator : UserControl
    {
        public Indicator()
        {
            InitializeComponent();
        }

        private void Indicator_Load(object sender, EventArgs e)
        {
            System.Drawing.Graphics MyFormGrap = this.CreateGraphics();
            LinearGradientBrush gradBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.LightGray, Color.White, LinearGradientMode.Vertical);
            MyFormGrap.FillRectangle(gradBrush, 0, 0, this.Width, this.Height); 
            MyFormGrap.Dispose();
        }
    }
}
