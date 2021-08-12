﻿using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace PomiaryGUI
{
    public partial class Raports : UserControl
    {
        private System.Data.DataTable data = new System.Data.DataTable();
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

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Records";

            try
            {
                for (int i = 1; i < dataGridViewRaports.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridViewRaports.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridViewRaports.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridViewRaports.Columns.Count; j++)
                    {
                        if (dataGridViewRaports.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridViewRaports.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                app.Quit();
                workbook = null;
                worksheet = null;
            }
        }

        private void Raports_Load(object sender, EventArgs e)
        {
            HoursFrom.SelectedItem = HoursFrom.Items[0];
            HoursTo.SelectedItem = HoursTo.Items[23];
            MinutesFrom.SelectedItem = MinutesFrom.Items[0];
            MinutesTo.SelectedItem = MinutesTo.Items[59];

            DateFrom.Value = new DateTime(2021, 1, 1);
            DateTo.Value = new DateTime(2021, 12, 31);

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

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            if (StatusRaports)
            {
                ButtonShowClick?.Invoke(this, EventArgs.Empty);
                StatusRaports = false;
            }
        }

        public void SetData(System.Data.DataTable dataTable)
        {
            data.Clear();
            data.Columns.Clear();
            data = dataTable;
            dataGridViewRaports.DataSource = data;
            if (dataGridViewRaports.Columns.Count > 0)
            {
                dataGridViewRaports.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewRaports.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridViewRaports.Columns[0].Frozen = true;
            }
            foreach (DataGridViewColumn column in dataGridViewRaports.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }
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
                }
                else
                {
                    dataGridViewRaports.Visible = false;
                    panel.Visible = true;
                    panel.Location = new System.Drawing.Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
                }
            }
        }
    }
}
