using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Geared;

namespace PomiaryGUI
{
    public partial class Charts : UserControl
    {
        public event EventHandler ButtonShowClick;
        public int dots = 1000;
        
        ChartMode mode = ChartMode.power;

        private bool statusChart = true;
        private List<string> dates = new List<string>();
        private List<GearedValues<double>> Lines = new List<GearedValues<double>>();
        private Panel panel = new Panel();

        public Charts(ChartMode str)
        {
            InitializeComponent();
            buttonShow.Click += new EventHandler(ButtonShow_Click);
            comboBox1.SelectedItem = comboBox1.Items[0];
            mode = str;
            if (mode == ChartMode.power)
            {
                this.checkP.Text = "P";
                this.checkP_L1.Text = "P_L1";
                this.checkP_L2.Text = "P_L2";
                this.checkP_L3.Text = "P_L3";
                this.checkQ.Text = "Q";
                this.checkQ_L1.Text = "Q_L1";
                this.checkQ_L2.Text = "Q_L2";
                this.checkQ_L3.Text = "Q_L3";

                this.checkP.Visible = true;
                this.checkP_L1.Visible = true;
                this.checkP_L2.Visible = true;
                this.checkP_L3.Visible = true;
                this.checkQ.Visible = true;
                this.checkQ_L1.Visible = true;
                this.checkQ_L2.Visible = true;
                this.checkQ_L3.Visible = true;
            }
            else if (mode == ChartMode.current)
            {
                this.checkP.Text = "I";
                this.checkP_L1.Text = "I_L1";
                this.checkP_L2.Text = "I_L2";
                this.checkP_L3.Text = "I_L3";

                this.checkP.Visible = false;
                this.checkP_L1.Visible = true;
                this.checkP_L2.Visible = true;
                this.checkP_L3.Visible = true;
                this.checkQ.Visible = false;
                this.checkQ_L1.Visible = false;
                this.checkQ_L2.Visible = false;
                this.checkQ_L3.Visible = false;

                this.checkP.Checked = false;
                this.checkQ.Checked = false;
                this.checkQ_L1.Checked = false;
                this.checkQ_L2.Checked = false;
                this.checkQ_L3.Checked = false;
            }
            else if (mode == ChartMode.voltage)
            {
                this.checkP.Text = "V";
                this.checkP_L1.Text = "U_L1";
                this.checkP_L2.Text = "U_L2";
                this.checkP_L3.Text = "U_L3";

                this.checkP.Visible = false;
                this.checkP_L1.Visible = true;
                this.checkP_L2.Visible = true;
                this.checkP_L3.Visible = true;
                this.checkQ.Visible = false;
                this.checkQ_L1.Visible = false;
                this.checkQ_L2.Visible = false;
                this.checkQ_L3.Visible = false;

                this.checkP.Checked = false;
                this.checkQ.Checked = false;
                this.checkQ_L1.Checked = false;
                this.checkQ_L2.Checked = false;
                this.checkQ_L3.Checked = false;
            }
            else if (mode == ChartMode.cos)
            {
                this.checkP.Text = "Cos";
                this.checkP_L1.Text = "I_L1";
                this.checkP_L2.Text = "I_L2";
                this.checkP_L3.Text = "I_L3";

                this.checkP.Visible = true;
                this.checkP_L1.Visible = false;
                this.checkP_L2.Visible = false;
                this.checkP_L3.Visible = false;
                this.checkQ.Visible = false;
                this.checkQ_L1.Visible = false;
                this.checkQ_L2.Visible = false;
                this.checkQ_L3.Visible = false;

                this.checkP_L1.Checked = false;
                this.checkP_L2.Checked = false;
                this.checkP_L3.Checked = false;
                this.checkQ.Checked = false;
                this.checkQ_L1.Checked = false;
                this.checkQ_L2.Checked = false;
                this.checkQ_L3.Checked = false;
            }
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            HoursFrom.SelectedItem = HoursFrom.Items[0];
            HoursTo.SelectedItem = HoursTo.Items[0];
            MinutesFrom.SelectedItem = MinutesFrom.Items[0];
            MinutesTo.SelectedItem = MinutesTo.Items[0];
            DateFrom.Value = DateTime.Today.AddDays(-1);

            chart.DisableAnimations = true;
            chart.LegendLocation = LegendLocation.Bottom;
            chart.BackColor = Color.White;
            chart.Font = new Font(chart.Font.FontFamily, 16);

            this.Controls.Add(panel);
            panel.BackgroundImageLayout = ImageLayout.Zoom;
            panel.BackgroundImage = Properties.Resources.giphy;
            panel.Size = new Size(300, 200);
            panel.Location = new Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
            panel.Visible = false;
        }

        public DateTime GetDateFrom()
        {
            return new DateTime(Convert.ToInt32(DateFrom.Value.Year), 
                                Convert.ToInt32(DateFrom.Value.Month),
                                Convert.ToInt32(DateFrom.Value.Day),
                                Convert.ToInt32(HoursFrom.Text),
                                Convert.ToInt32(MinutesFrom.Text),
                                Convert.ToInt32(0));
        }

        public DateTime GetDateTo()
        {
            return new DateTime(Convert.ToInt32(DateTo.Value.Year),
                                Convert.ToInt32(DateTo.Value.Month),
                                Convert.ToInt32(DateTo.Value.Day),
                                Convert.ToInt32(HoursTo.Text),
                                Convert.ToInt32(MinutesTo.Text),
                                Convert.ToInt32(0));
        }

        public List<string> EquList
        {
            set
            {
                comboBox1.Items.Clear();
                foreach (var i in value)
                {
                    if(!string.IsNullOrWhiteSpace(i))
                        comboBox1.Items.Add(i);
                }
                if(comboBox1.Items.Count>0) comboBox1.SelectedItem = comboBox1.Items[0] ?? "";
            }
        }

        public string GetEquSelected()
        {
            if (comboBox1.Items.Count > 0)
            {
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                return "";
            }
            
            //return _equList.FirstOrDefault(x => x.Value == comboBox1.SelectedItem.ToString()).Key;
            //if (comboBox1.Text == "Szyn-1") return 1;
            //if (comboBox1.Text == "Szyn-2") return 2;
            //if (comboBox1.Text == "Szyn-3") return 3;
            //if (comboBox1.Text == "Szyn-4") return 4;
            //if (comboBox1.Text == "Szyn-5") return 5;
            //if (comboBox1.Text == "Piec 5") return 6;
            //if (comboBox1.Text == "Piec 6") return 7;
            //if (comboBox1.Text == "Piec 7") return 8;
            //if (comboBox1.Text == "Parowy BM") return 9;
            //if (comboBox1.Text == "Parowy AB_BQ") return 10;
            //if (comboBox1.Text == "Piec 3") return 11;
            //if (comboBox1.Text == "Piec 8") return 12;

            //return 0;
        }

        public List<string> GetCheckedLines()
        {
            List<string> vs = new List<string>();
            vs.Clear();
            if(checkP.Checked)vs.Add(checkP.Text);
            if(checkQ.Checked)vs.Add(checkQ.Text);
            if(checkP_L1.Checked)vs.Add(checkP_L1.Text);
            if(checkP_L2.Checked)vs.Add(checkP_L2.Text);
            if(checkP_L3.Checked)vs.Add(checkP_L3.Text);
            if(checkQ_L1.Checked)vs.Add(checkQ_L1.Text);
            if(checkQ_L2.Checked)vs.Add(checkQ_L2.Text);
            if(checkQ_L3.Checked)vs.Add(checkQ_L3.Text);

            return vs;
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            if (StatusChart)
            {
                ButtonShowClick?.Invoke(this, EventArgs.Empty);
                StatusChart = false;
            }
        }
        
        public async void SetDataChart(DataTable table)
        {
            try
            {
                chart.Series.Clear();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                dates.Clear();

                Lines.Clear();

                if (table == null || GetCheckedLines().Count == 0)
                {
                    chart.Refresh();
                    return;
                }

                foreach (string str in GetCheckedLines())
                {
                    Lines.Add(new GearedValues<double>());
                }

                DataTable temptable = new DataTable();
                DataColumn tempcolumn;
                DataRow temprow, temprow1, temprow2;
                var checkedLines= GetCheckedLines();

                tempcolumn = new DataColumn
                {
                    DataType = System.Type.GetType("System.DateTime"),
                    ColumnName = "Czas",
                    AutoIncrement = false,
                    Caption = "Czas",
                    ReadOnly = false,
                    Unique = false
                };
                temptable.Columns.Add(tempcolumn);

                foreach (string str in GetCheckedLines())
                {
                    tempcolumn = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Single"),
                        ColumnName = str,
                        AutoIncrement = false,
                        Caption = str,
                        ReadOnly = false,
                        Unique = false
                    };
                    temptable.Columns.Add(tempcolumn);
                }

                await Task.Run(() => {
                    //    int stepCount = table.Rows.Count / dots;
                    //    DataTable dataTable;
                    //    //List<DataRow> listRows = new List<DataRow>();
                    //    //for (int i = 0; i < stepCount; i++)
                    //    //{
                    //    //    listRows.Add(temptable.NewRow());
                    //    //    listRows.Add(temptable.NewRow());
                    //    //}
                    //    for (int i = 0; i <= dots; i++)
                    //    //Enumerable.Range(0, (int)stepCount).AsParallel().ForAll(i =>
                    //    {
                    //        temprow1 = temptable.NewRow();//first
                    //        temprow2 = temptable.NewRow();//last
                    //        int tempCount = 0;
                    //        if (i < dots) tempCount = i * stepCount + stepCount;
                    //        else tempCount = table.Rows.Count - i * stepCount;
                    //            //if(i < dots) dataTable = (DataTable)table.AsEnumerable().Skip(i * stepCount).Take(stepCount);
                    //            //else dataTable = (DataTable)table.AsEnumerable().Skip(i * stepCount).Take(table.Rows.Count - i * stepCount);
                    //            //temprow1["Czas"] = (DateTime)rows.Select(x => x.Field<object>("Czas")).Where(x => x != DBNull.Value).First();
                    //            //temprow2["Czas"] = (DateTime)rows.Select(x => x.Field<object>("Czas")).Where(x => x != DBNull.Value).Last();
                    //        temprow1["Czas"] = table.Rows[i * stepCount]["Czas"];
                    //        temprow2["Czas"] = table.Rows[tempCount]["Czas"];
                    //        //checkedLines.AsParallel().ForAll(str =>
                    //        foreach (var str in checkedLines)
                    //        {

                    //            //List<object> oList = rows. //Select(p => p.Field<object>(str)).ToList();
                    //            //oList.Sort();
                    //            //object oMin = oList.First();
                    //            //object oMax = oList.Last();
                    //            //temprow1[str] = oMin;// == null ? 0.0f : oMin;
                    //            //temprow2[str] = oMax;// == null ? 0.0f : oMax;
                    //        }//);
                    //        temptable.Rows.Add(temprow1);
                    //        temptable.Rows.Add(temprow2);
                    //        //rows = null;
                    //    }

                    //    checkedLines.AsParallel().ForAll(str =>
                    //    {
                    //        int div = 1;
                    //        if (mode == ChartMode.power) div = 1000;
                    //        //Lines[checkedLines.IndexOf(str)].AddRange(temptable.AsEnumerable().Select(x => x.Field<object>(str)).
                    //        //        Select(x => x ?? 0).
                    //        //        Select(x => x != DBNull.Value ? (((float)x) / div) : 0.0));
                    //        Lines[checkedLines.IndexOf(str)].AddRange(temptable.AsEnumerable().Select(x => x.Field<object>(str)).
                    //                                                    Where(x => x != null).
                    //                                                    Select(x => x != DBNull.Value ? (((float)x) / div) : 0.0));
                    //});
                    //    dates.AddRange(temptable.AsEnumerable().Select(x => x.Field<DateTime>("Czas").ToString()));

                    if (table.Rows.Count > dots)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if ((table.Rows.Count - i) > table.Rows.Count / dots)
                            {
                                temptable.Clear();
                                for (int q = 0; q < (table.Rows.Count / dots); q++)
                                {
                                    temprow = temptable.NewRow();
                                    foreach (string str in GetCheckedLines())
                                    {
                                        object objTemp = table.Rows[i][str];
                                        double doubTemp = 0.0;
                                        if (objTemp != DBNull.Value)
                                            doubTemp = (double)objTemp;

                                        if (mode == ChartMode.power) temprow[str] = doubTemp / 1000;
                                        else temprow[str] = doubTemp;
                                    }
                                    temprow["Czas"] = Convert.ToString(table.Rows[i]["Czas"]);
                                    temptable.Rows.Add(temprow);

                                    if (((table.Rows.Count / dots) - q) > 1) i++;
                                }

                                var dataRow = temptable.AsEnumerable().OrderByDescending(row => row.Field<float>(GetCheckedLines()[0])).FirstOrDefault();

                                foreach (string str in GetCheckedLines())
                                {
                                    dataRow = temptable.AsEnumerable()
                                        .OrderByDescending(row => row.Field<float>(str))
                                        .FirstOrDefault();
                                    Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(dataRow[str]));
                                }

                                dates.Add(Convert.ToString(dataRow["Czas"]));

                                foreach (string str in GetCheckedLines())
                                {
                                    dataRow = temptable.AsEnumerable()
                                        .OrderByDescending(row => row.Field<float>(str))
                                        .LastOrDefault();
                                    Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(dataRow[str]));
                                }

                                dates.Add(Convert.ToString(dataRow["Czas"]));
                            }
                            else
                            {
                                if (Convert.ToBoolean(table.Rows[i]["Status"]))
                                {
                                    foreach (string str in GetCheckedLines())
                                    {
                                        if (mode == ChartMode.power) Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(table.Rows[i][str]) / 1000);
                                        else Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(table.Rows[i][str]));
                                    }
                                    dates.Add(Convert.ToString(table.Rows[i]["Czas"]));
                                }
                                else
                                {
                                    foreach (string str in GetCheckedLines())
                                    {
                                        Lines[GetCheckedLines().IndexOf(str)].Add(0.0);
                                    }
                                    dates.Add(Convert.ToString(table.Rows[i]["Czas"]));
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (Convert.ToBoolean(row["Status"]))
                            {
                                foreach (string str in GetCheckedLines())
                                {
                                    if (mode == ChartMode.power) Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(row[str]) / 1000);
                                    else Lines[GetCheckedLines().IndexOf(str)].Add(Convert.ToDouble(row[str]));
                                }
                                dates.Add(Convert.ToString(row["Czas"]));
                            }
                            else
                            {
                                foreach (string str in GetCheckedLines())
                                {
                                    Lines[GetCheckedLines().IndexOf(str)].Add(0.0);
                                }
                                dates.Add(Convert.ToString(row["Czas"]));
                            }
                        }
                    }
                });
                
                string _n = "";
                if (table.Rows.Count > 1 && !table.Rows[2].IsNull("Nazwa_urzadzenia"))
                {
                    _n = Convert.ToString(table.Rows[2]["Nazwa_urzadzenia"]);
                }
                int val = 100;
                if (mode == ChartMode.power)
                {
                    if (_n.Contains("Piec")) val = 100;
                    else if (_n.Contains("Szyn")) val = 50;
                }
                else if (mode == ChartMode.current)
                {
                    if (_n.Contains("Piec")) val = 150;
                    else if (_n.Contains("Szyn")) val = 100;
                }
                else if (mode == ChartMode.voltage)
                {
                    if (_n.Contains("Piec")) val = 250;
                    else if (_n.Contains("Szyn")) val = 250;
                }
                else if (mode == ChartMode.cos)
                {
                    if (_n.Contains("Piec")) val = 1;
                    else if (_n.Contains("Szyn")) val = 1;
                }

                chart.AxisY.Add(new Axis()
                {
                    Title = _n,
                    MaxValue = val,
                    FontSize = 20
                });
                chart.AxisX.Add(new Axis()
                {
                    Labels = dates,
                    FontSize = 16
                });

                chart.Series = new SeriesCollection();
                foreach (var i in Lines)
                {
                    chart.Series.Add(new GLineSeries
                    {
                        Values = i.AsGearedValues().WithQuality(Quality.Low),
                        Title = GetCheckedLines()[Lines.IndexOf(i)].ToString(),
                        ScalesYAt = 0,
                        Fill = System.Windows.Media.Brushes.Transparent,
                        StrokeThickness = .5,
                        PointGeometry = null
                    });
                }
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                StatusChart = true;
            }

        }
       
        private bool StatusChart
        {
            get
            {
                return statusChart;
            }
            set
            {
                statusChart = value;
                if (statusChart)
                {
                    chart.Visible = true;
                    panel.Visible = false;
                }else
                {
                    chart.Visible = false;
                    panel.Visible = true;
                    panel.Location = new Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
                }
            }
        }
    }
}
