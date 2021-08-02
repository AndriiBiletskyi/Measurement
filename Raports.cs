using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace PomiaryGUI
{
    public partial class Raports : UserControl
    {
        private DataTable data = new DataTable();
        private bool statusRaports = true;
        private Panel panel = new Panel();
        public event EventHandler ButtonShowClick;

        public Raports()
        {
            InitializeComponent();
            buttonShow.Click += new EventHandler(ButtonShow_Click);
        }

        private void Raports_Load(object sender, EventArgs e)
        {
            HoursFrom.SelectedItem = HoursFrom.Items[0];
            HoursTo.SelectedItem = HoursTo.Items[23];
            MinutesFrom.SelectedItem = MinutesFrom.Items[0];
            MinutesTo.SelectedItem = MinutesTo.Items[59];

            dataGridViewRaports.DefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Bold);
            dataGridViewRaports.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Bold);
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

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            if (StatusRaports)
            {
                ButtonShowClick?.Invoke(this, EventArgs.Empty);
                StatusRaports = false;
            }
        }

        public void SetData(DataTable dataTable)
        {
            data.Clear();
            data.Columns.Clear();
            data = dataTable;
            dataGridViewRaports.DataSource = data;
            dataGridViewRaports.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewRaports.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridViewRaports.Columns[0].Frozen = true;
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
                    panel.Location = new Point(this.Width / 2 - panel.Width / 2,
                                       this.Height / 2 - panel.Height / 2);
                }
            }
        }
    }
}
