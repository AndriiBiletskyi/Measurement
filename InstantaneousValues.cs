using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;
using Brushes = System.Windows.Media.Brushes;

namespace PomiaryGUI
{
    public partial class InstantaneousValues : UserControl
    {
        private string _name;
        public int Number = 0;
        private float _min = 0;
        private float _max = 100;
        private float _value = 100;
        private bool _status = false;
        private ToolTip toolTip = new ToolTip();
        

        public InstantaneousValues()
        {
            InitializeComponent();

            this.Tag = "InstantaneousValues";
            this.angularGauge.Wedge = 270;
            this.angularGauge.TicksForeground = Brushes.Black;
            this.angularGauge.Base.Foreground = Brushes.Black;
            this.angularGauge.Base.FontWeight = System.Windows.FontWeights.Bold;
            this.angularGauge.TicksStrokeThickness = 1;
            this.angularGauge.Base.FontSize = 11;
            this.angularGauge.SectionsInnerRadius = 1;
            

            //this.toolTip.AutoPopDelay = 3000;
            //this.toolTip.InitialDelay = 500;
            //this.toolTip.ReshowDelay = 200;
            //this.toolTip.ShowAlways = true;

            //this.toolTip.SetToolTip(this.angularGauge, _value.ToString());

            this.Visible = false;
        }

        private void ChangeSize()
        {
            //Control control = (Control)sender;
            this.labelName.Height = 30;
            angularGauge.Size = new Size(this.Width, this.Height - 30);
            labelName.Size = new Size(this.Width - this.labelName.Height, this.labelName.Height);
            labelName.Location = new Point(0, 0);
            panelStatus.Size = new Size(this.labelName.Height, this.labelName.Height);
            panelStatus.Location = new Point(this.Width - this.panelStatus.Width, 0);
            angularGauge.Location = new Point(0, this.labelName.Height);
            labelValue.Size = new Size(60, 30);
            labelValue.Location = new Point(this.Width / 2 - labelValue.Width / 2 - 5, this.Height - labelValue.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ChangeSize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        public new string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                this.labelName.Text = _name;
                this.toolTip.SetToolTip(this.angularGauge, _name);
            }
        }

        public float Min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
                this.angularGauge.FromValue = _min;
                this.angularGauge.TickStep = (_max - _min) / 100;
                this.angularGauge.LabelsStep = this.angularGauge.TickStep * 10;
            }
        }

        public float Max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
                this.angularGauge.ToValue = _max;
                this.angularGauge.TickStep = (_max - _min) / 100;
                this.angularGauge.LabelsStep = this.angularGauge.TickStep * 10;
            }
        }

        public float Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                this.angularGauge.Value = _value;
                this.labelValue.Text = _value.ToString("0.00");
            }
        }

        public bool Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
                if (_status)
                {
                    this.panelStatus.BackColor = Color.Green;
                    this.toolTip.SetToolTip(this.panelStatus, "Connected");
                }
                else 
                {
                    this.panelStatus.BackColor = Color.Red;
                    this.toolTip.SetToolTip(this.panelStatus, "Not Connected");
                }
            }
        }
    }
}
