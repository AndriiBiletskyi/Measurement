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

namespace Indicators
{
    public partial class Indi : UserControl
    {
        private Timer reactionsTimer = new Timer { Enabled = false, Interval = 100 };
        private float angle = 180;
        private float _Angle = 180;
        private float _Interval = 100;
        private float steps = 0;
        private readonly int segments = 5;
        private string _Name = "Gauge";
        private float _MinValue = 0;
        private float _MaxValue = 100;
        private float _YellowZone = 20;
        private float _Value = 0;
        private Font _NameFont = new Font("Arial", 10, FontStyle.Regular);
        private Font _ValueFont = new Font("Arial", 10, FontStyle.Regular);
        private List<Label> labSegments = new List<Label>();
        private bool _Status = false;

        Pen penTransparent = new Pen(new SolidBrush(Color.Transparent), 2f);
        Pen penBlack = new Pen(new SolidBrush(Color.Black), 2f);
        Pen penGreen = new Pen(new SolidBrush(Color.Green), 0.01f);
        Brush brushLightGreen = new SolidBrush(Color.LightGreen);
        Brush brushBlack = new SolidBrush(Color.Black);
        Brush brushYellow = new SolidBrush(Color.Yellow);
        Graphics er;
        Rectangle rect, rect2 = new Rectangle(0, 0, 0, 0);
        Point pRect, pRect2 = new Point(0, 0);
        Point pArrowStart, pArrowEnd, pArrowLeft, pArrowRight, pArrowBottom = new Point(0, 0); 
        
        public Indi()
        {
            InitializeComponent();
            reactionsTimer.Tick += new EventHandler(ReactionsTimerTick);
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            UpdateStyles();
            labelName.Font = _NameFont;
            labelValue.Font = _ValueFont;
            float val = _MinValue;
            for(int i = 0; i <= segments; i++)
            {
                if (i == segments) val = _MaxValue;
                var label = new Label
                {
                    Text = val.ToString(),
                    Visible = true,
                    AutoSize = true,
                    Size = labelValue.Size,
                    Name = "segment" + i.ToString(),
                    Font = labelValue.Font,
                    BackColor = Color.Transparent,
                    Location = new Point(50 * i, 200)
                };
                val += (_MaxValue - _MinValue) / segments;
                labSegments.Add(label);
            }
            Controls.AddRange(labSegments.ToArray());
        }

        private void ReactionsTimerTick(object sender, EventArgs e)
        {
            angle += steps;
            if (steps >= 0)
            {
                if (angle >= _Angle)
                {
                    angle = _Angle;
                    reactionsTimer.Enabled = false;
                }
            }
            else
            {
                if (angle <= _Angle)
                {
                    angle = _Angle;
                    reactionsTimer.Enabled = false;
                }
            }
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int x1 = 0, y1 = 0, x2 = Width, y2 = Height;
            er = e.Graphics;
            LinearGradientBrush gradBrush = new LinearGradientBrush(new Rectangle(x1, y1, x2, y2), Color.White, Color.White, LinearGradientMode.Vertical);
            er.FillRectangle(gradBrush, x1, y1, x2, y2);

            float side = (float)Height * 0.95f;
            float side2 = side * 0.8f;
            float shiftVertical = (float)(Height) * 0.2f;

            pRect.X = (Width - (int)side) / 2;
            pRect.Y = (int)(Height - side / 2 - shiftVertical);
            pRect2.X = (int)(pRect.X + (float)(Width) * 0.01f);
            pRect2.Y = (int)(Height - side2 / 2 - shiftVertical);
            rect.Location = pRect;
            rect.Width = rect.Height = (int)side;
            rect2.Location = pRect2;
            rect2.Width = rect2.Height = (int)side2;

            float alfaStart = 180;
            float alfaStart2 = 180;
            float delta = 180 / segments;
            double delta2 = delta;
            GraphicsPath graphicsPath = new GraphicsPath();
            for (int i = 0; i < segments - 1; i++)
            {
                int shift = 2;
                if (i == (segments - 1)) shift = 0;
                double tempAlpha = alfaStart + delta;
                double a = (float)rect.Width / 2;
                double b = rect.X + (float)rect.Width / 2 - (rect2.X + (float)rect2.Width / 2);
                double arcSinn = Math.Asin(b * Math.Sin(tempAlpha / 57.3f) / a) * 57.3f;
                tempAlpha += arcSinn;
                delta2 = tempAlpha - alfaStart2;
                graphicsPath.AddArc(rect, alfaStart2, (float)(delta2 - shift));
                graphicsPath.AddArc(rect2, alfaStart + delta - shift, -delta + shift);
                alfaStart += delta;
                alfaStart2 += (float)delta2;
                graphicsPath.CloseFigure();
                er.DrawPath(penBlack, graphicsPath);
                er.FillPath(brushLightGreen, graphicsPath);
            }

            GraphicsPath lastPath = new GraphicsPath();
            double tempA = alfaStart + delta;
            double aa = (float)rect.Width / 2;
            double bb = rect.X + (float)rect.Width / 2 - (rect2.X + (float)rect2.Width / 2);
            double arcSin = Math.Asin(bb * Math.Sin(tempA / 57.3f) / aa) * 57.3f;
            tempA += arcSin;
            delta2 = tempA - alfaStart2;
            lastPath.AddArc(rect, alfaStart2, (float)(delta2));
            lastPath.AddArc(rect2, alfaStart + delta, -delta);
            lastPath.CloseFigure();
            er.DrawPath(penBlack, lastPath);
            er.FillPath(brushYellow, lastPath);

            #region Arrow
            GraphicsPath arrowPath = new GraphicsPath();
            pArrowStart.X = rect2.X + rect2.Width / 2;
            pArrowStart.Y = rect2.Y + rect2.Height / 2;
            float offsetArrow = (rect.X + rect.Width - (rect2.X + rect2.Width)) / 2 * (angle - 180) / 180;
            float l = rect2.Width / 2 + offsetArrow;
            pArrowEnd.X = (int)((float)pArrowStart.X + Math.Cos(angle / 57.3) * l);
            pArrowEnd.Y = (int)((float)pArrowStart.Y + Math.Sin(angle / 57.3) * l);

            float arrowWidth = (float)(0.02 * Width);
            #region Centr circle of arrow
            arrowPath.AddEllipse(pArrowStart.X - arrowWidth/5, pArrowStart.Y - arrowWidth / 5, 2*arrowWidth / 5, 2 * arrowWidth / 5);
            arrowPath.CloseFigure();
            er.DrawPath(penTransparent, arrowPath);
            #endregion

            pArrowLeft.X = (int)((float)pArrowStart.X + Math.Cos((angle - 90) / 57.3) * arrowWidth);
            pArrowLeft.Y = (int)((float)pArrowStart.Y + Math.Sin((angle - 90) / 57.3) * arrowWidth);
            pArrowRight.X = (int)((float)pArrowStart.X + Math.Cos((angle + 90) / 57.3) * arrowWidth);
            pArrowRight.Y = (int)((float)pArrowStart.Y + Math.Sin((angle + 90) / 57.3) * arrowWidth);
            pArrowBottom.X = (int)((float)pArrowStart.X + Math.Cos((angle - 180) / 57.3) * arrowWidth);
            pArrowBottom.Y = (int)((float)pArrowStart.Y + Math.Sin((angle - 180) / 57.3) * arrowWidth);
            arrowPath.AddLine(pArrowRight, pArrowEnd);
            arrowPath.AddLine(pArrowEnd, pArrowLeft);
            arrowPath.AddArc(pArrowStart.X - arrowWidth, pArrowStart.Y - arrowWidth, arrowWidth * 2, arrowWidth * 2, angle - 90, -180);
            arrowPath.CloseFigure();
            er.DrawPath(penTransparent, arrowPath);
            er.FillPath(brushBlack, arrowPath);

            #endregion

            labelName.Height = pRect.Y;
            labelValue.Height = Height - rect.Height / 2 - labelName.Height;
            labelValue.Text = Math.Round(_Value, 2).ToString("F2");

            labSegments[0].Location = new Point(pRect2.X + 2, pRect.Y + rect.Height/2 - labSegments[0].Height/2);
            
            labSegments[1].Location = new Point(pRect2.X + 2, pRect.Y + rect.Height / 2 - labSegments[0].Height / 2);

            //foreach (var lab in labSegments)
            //    lab.BringToFront();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
        
        public float MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
                if (_MaxValue <= _MinValue) _MaxValue = _MinValue + 0.1f;
                int i = 0;
                float val = _MinValue;
                foreach (var label in labSegments)
                {
                    label.Text = val.ToString();
                    val += (_MaxValue - _MinValue) / segments;
                }
                labSegments.Last().Text = _MaxValue.ToString();
            }
        }

        public float MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
                if (_MinValue >= _MaxValue) _MinValue = _MaxValue - 0.1f;
                int i = 0;
                float val = _MinValue;
                foreach (var label in labSegments)
                {
                    label.Text = val.ToString();
                    val += (_MaxValue - _MinValue) / segments;
                }
                labSegments.Last().Text = _MaxValue.ToString();
            }
        }

        public float Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                if (_Value > _MaxValue) _Value = _MaxValue;
                if (_Value < _MinValue) _Value = _MinValue;
                Angle = 180 + 180 * ((_Value - _MinValue) / (_MaxValue - _MinValue));
            }
        }

        public string NameText
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                labelName.Text = _Name;
            }
        }

        public float YellowZone
        {
            get
            {
                return _YellowZone;
            }
            set
            {
                _YellowZone = value;
                if (_YellowZone < 0) _YellowZone = 0;
                if (_YellowZone > 100) _YellowZone = 100;
            }
        }

        public Font NameFont
        {
            get
            {
                return _NameFont;
            }
            set
            {
                _NameFont = value;
                labelName.Font = _NameFont;
            }
        }

        public Font ValueFont
        {
            get
            {
                return _ValueFont;
            }
            set
            {
                _ValueFont = value;
                labelValue.Font = _ValueFont;
            }
        }

        private float Angle
        {
            get
            {
                return _Angle;
            }
            set
            {
                _Angle = value;
                if (_Angle < 180) _Angle = 180;
                if (_Angle > 360) _Angle = 360;
                steps = (_Angle - angle) * reactionsTimer.Interval / (_Interval);
                if (steps != 0) reactionsTimer.Enabled = true;
            }
        }
        
        public float Interval
        {
            get
            {
                return _Interval;
            }
            set
            {
                _Interval = value;
                if (_Interval < 10) _Interval = 10;
                if (_Interval > 10000) _Interval = 10000;
            }
        }

        public bool Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
    }
}
