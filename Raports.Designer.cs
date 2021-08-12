
namespace PomiaryGUI
{
    partial class Raports
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonShow = new System.Windows.Forms.Button();
            this.MinutesTo = new System.Windows.Forms.ComboBox();
            this.HoursTo = new System.Windows.Forms.ComboBox();
            this.MinutesFrom = new System.Windows.Forms.ComboBox();
            this.HoursFrom = new System.Windows.Forms.ComboBox();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewRaports = new System.Windows.Forms.DataGridView();
            this.Time_Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaports)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(227, 0);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(100, 66);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // MinutesTo
            // 
            this.MinutesTo.BackColor = System.Drawing.Color.White;
            this.MinutesTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinutesTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinutesTo.ForeColor = System.Drawing.Color.Black;
            this.MinutesTo.FormattingEnabled = true;
            this.MinutesTo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesTo.Location = new System.Drawing.Point(53, 33);
            this.MinutesTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinutesTo.Name = "MinutesTo";
            this.MinutesTo.Size = new System.Drawing.Size(52, 31);
            this.MinutesTo.TabIndex = 8;
            // 
            // HoursTo
            // 
            this.HoursTo.BackColor = System.Drawing.Color.White;
            this.HoursTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HoursTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HoursTo.ForeColor = System.Drawing.Color.Black;
            this.HoursTo.FormattingEnabled = true;
            this.HoursTo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursTo.Location = new System.Drawing.Point(0, 33);
            this.HoursTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HoursTo.Name = "HoursTo";
            this.HoursTo.Size = new System.Drawing.Size(52, 31);
            this.HoursTo.TabIndex = 9;
            // 
            // MinutesFrom
            // 
            this.MinutesFrom.BackColor = System.Drawing.Color.White;
            this.MinutesFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinutesFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinutesFrom.ForeColor = System.Drawing.Color.Black;
            this.MinutesFrom.FormattingEnabled = true;
            this.MinutesFrom.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesFrom.Location = new System.Drawing.Point(53, 0);
            this.MinutesFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinutesFrom.Name = "MinutesFrom";
            this.MinutesFrom.Size = new System.Drawing.Size(52, 31);
            this.MinutesFrom.TabIndex = 10;
            // 
            // HoursFrom
            // 
            this.HoursFrom.BackColor = System.Drawing.Color.White;
            this.HoursFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HoursFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HoursFrom.ForeColor = System.Drawing.Color.Black;
            this.HoursFrom.FormattingEnabled = true;
            this.HoursFrom.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursFrom.Location = new System.Drawing.Point(0, 0);
            this.HoursFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HoursFrom.Name = "HoursFrom";
            this.HoursFrom.Size = new System.Drawing.Size(52, 31);
            this.HoursFrom.TabIndex = 11;
            // 
            // DateTo
            // 
            this.DateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTo.Location = new System.Drawing.Point(107, 33);
            this.DateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(119, 30);
            this.DateTo.TabIndex = 6;
            // 
            // DateFrom
            // 
            this.DateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateFrom.Location = new System.Drawing.Point(107, 1);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(119, 30);
            this.DateFrom.TabIndex = 7;
            // 
            // dataGridViewRaports
            // 
            this.dataGridViewRaports.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewRaports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRaports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRaports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRaports.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRaports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRaports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRaports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRaports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time_Day});
            this.dataGridViewRaports.GridColor = System.Drawing.Color.Black;
            this.dataGridViewRaports.Location = new System.Drawing.Point(0, 66);
            this.dataGridViewRaports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewRaports.Name = "dataGridViewRaports";
            this.dataGridViewRaports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewRaports.RowHeadersWidth = 51;
            this.dataGridViewRaports.Size = new System.Drawing.Size(1067, 615);
            this.dataGridViewRaports.TabIndex = 13;
            // 
            // Time_Day
            // 
            this.Time_Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Time_Day.DefaultCellStyle = dataGridViewCellStyle3;
            this.Time_Day.HeaderText = "Time/Day";
            this.Time_Day.MinimumWidth = 6;
            this.Time_Day.Name = "Time_Day";
            this.Time_Day.Width = 158;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(963, 1);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 66);
            this.buttonExport.TabIndex = 12;
            this.buttonExport.Text = "Export >>";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // Raports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewRaports);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.MinutesTo);
            this.Controls.Add(this.HoursTo);
            this.Controls.Add(this.MinutesFrom);
            this.Controls.Add(this.HoursFrom);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Raports";
            this.Size = new System.Drawing.Size(1067, 682);
            this.Load += new System.EventHandler(this.Raports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.ComboBox MinutesTo;
        private System.Windows.Forms.ComboBox HoursTo;
        private System.Windows.Forms.ComboBox MinutesFrom;
        private System.Windows.Forms.ComboBox HoursFrom;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DataGridView dataGridViewRaports;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time_Day;
        private System.Windows.Forms.Button buttonExport;
    }
}
