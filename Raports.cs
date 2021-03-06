using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace PomiaryGUI
{
    public partial class Raports : UserControl
    {
        private bool statusRaports = true;
        private Panel panel = new Panel();
        public event EventHandler ButtonShowClick;
        public event EventHandler ButtonExportClick;

        public Raports()
        {
            InitializeComponent();
            buttonShow.Click += new EventHandler(ButtonShow_Click);
            buttonExport.Click += new EventHandler(ButtonExport_Click);
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            ButtonExportClick?.Invoke(this, EventArgs.Empty);
            try
            {
                var app = new Microsoft.Office.Interop.Excel.Application();
                app.Workbooks.Add();
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)app.ActiveSheet;

                int i, j;
                for(i = 0; i < dataGridViewRaports.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridViewRaports.Columns[i].HeaderText;
                }
                for(i = 0; i <= dataGridViewRaports.RowCount - 1; i++)
                {
                    for(j = 0; j <= dataGridViewRaports.ColumnCount - 1; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewRaports[j, i].Value;
                    }
                }

                app.Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                //app.Quit();
                //workbook = null;
                //worksheet = null;
            }
        }

        private void Raports_Load(object sender, EventArgs e)
        {
            dataGridViewRaports.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            dataGridViewRaports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            dataGridViewRaports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewRaports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewRaports.AllowUserToAddRows = false;
            dataGridViewRaports.RowHeadersVisible = false;
            dataGridViewRaports.BorderStyle = BorderStyle.None;
            dataGridViewRaports.Columns.Clear();
            dataGridViewRaports.Refresh();

            this.Controls.Add(panel);
            panel.BackgroundImageLayout = ImageLayout.Zoom;
            panel.BackgroundImage = Properties.Resources.giphy;
            panel.Size = new Size(300, 200);
            panel.Location = new System.Drawing.Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
            panel.Visible = false;

            string stri = DateFrom.Value.ToLongDateString() +
                          DateFrom.Value.ToShortTimeString();
            DateFrom.Width = (int)(TextRenderer.MeasureText(stri, DateFrom.Font).Width*1.5f);
            DateTo.Width = DateFrom.Width;
            DateFrom.Location = new System.Drawing.Point(0, 0);
            DateTo.Location = new System.Drawing.Point(0, DateFrom.Height);

            buttonShow.Height = DateFrom.Height + DateTo.Height + 2;
            buttonShow.Location = new System.Drawing.Point(DateFrom.Location.X + DateFrom.Width, DateFrom.Location.Y-1);

            buttonExport.Location = new System.Drawing.Point(this.Width - buttonExport.Width, buttonShow.Location.Y);
        }

        public DateTime GetDateFrom()
        {
            return new DateTime(Convert.ToInt32(DateFrom.Value.Year),
                                Convert.ToInt32(DateFrom.Value.Month),
                                Convert.ToInt32(DateFrom.Value.Day),
                                Convert.ToInt32(DateFrom.Value.Hour),
                                Convert.ToInt32(DateFrom.Value.Minute),
                                Convert.ToInt32(DateFrom.Value.Second));
        }

        public DateTime GetDateTo()
        {
            return new DateTime(Convert.ToInt32(DateTo.Value.Year),
                                Convert.ToInt32(DateTo.Value.Month),
                                Convert.ToInt32(DateTo.Value.Day),
                                Convert.ToInt32(DateTo.Value.Hour),
                                Convert.ToInt32(DateTo.Value.Minute),
                                Convert.ToInt32(DateTo.Value.Second));
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            if (StatusRaports)
            {
                StatusRaports = false;
                ButtonShowClick?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SetData(System.Data.DataTable dataTable)
        {
            dataGridViewRaports.DataSource = dataTable;
            if (dataGridViewRaports.Columns.Count > 0)
            {
                dataGridViewRaports.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewRaports.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridViewRaports.Columns[0].Frozen = true;
            }
            //foreach (DataGridViewColumn column in dataGridViewRaports.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            dataGridViewRaports.Refresh();

            StatusRaports = true;
        }

        private bool StatusRaports
        {
            get
            {
                return statusRaports;
            }
            set
            {
                statusRaports = value;
                if (statusRaports)
                {
                    dataGridViewRaports.Visible = true;
                    panel.Visible = false;
                    buttonExport.Enabled = true;
                    buttonShow.Enabled = true;
                    DateFrom.Enabled = true;
                    DateTo.Enabled = true;
                }
                else
                {
                    dataGridViewRaports.Visible = false;
                    buttonExport.Enabled = false;
                    buttonShow.Enabled = false;
                    DateFrom.Enabled = false;
                    DateTo.Enabled = false;
                    panel.Visible = true;
                    panel.Location = new System.Drawing.Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
                }
            }
        }
    }
}
