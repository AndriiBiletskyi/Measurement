using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PomiaryGUI
{
    static class Loading
    {
        static private bool isActive = false;
        static private Form _form;
        static private Panel panel = new Panel(); 

        static public void Show(Form form)
        {
            if (!isActive)
            {
                _form = form;
                _form.Opacity = 0.75;
                isActive = true;
                _form.Controls.Add(panel);
                panel.BackgroundImageLayout = ImageLayout.Zoom;
                panel.BackgroundImage = Properties.Resources.giphy;
                panel.Size = new Size(300, 200);
                panel.Location = new Point(form.Width / 2 - panel.Width/2, form.Height / 2 - panel.Height/2);
                panel.Show();
                panel.BringToFront();
            }
        }

        static public void Close()
        {
            if (isActive) 
            {
                _form.Opacity = 1.0;
                isActive = false;
                _form.Controls.Remove(panel);
            }
        }
    }
}
