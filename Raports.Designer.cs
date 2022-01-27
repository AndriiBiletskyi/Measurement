
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
            this.buttonShow.Location = new System.Drawing.Point(370, 0);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 54);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // DateTo
            // 
            this.DateTo.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTo.Location = new System.Drawing.Point(3, 27);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(168, 26);
            this.DateTo.TabIndex = 6;
            this.DateTo.Value = new System.DateTime(2021, 12, 31, 23, 59, 59, 0);
            // 
            // DateFrom
            // 
            this.DateFrom.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFrom.Location = new System.Drawing.Point(0, 1);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(170, 26);
            this.DateFrom.TabIndex = 7;
            this.DateFrom.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
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
            this.dataGridViewRaports.Location = new System.Drawing.Point(0, 54);
            this.dataGridViewRaports.Name = "dataGridViewRaports";
            this.dataGridViewRaports.ReadOnly = true;
            this.dataGridViewRaports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewRaports.RowHeadersWidth = 51;
            this.dataGridViewRaports.Size = new System.Drawing.Size(800, 500);
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
            this.Time_Day.ReadOnly = true;
            this.Time_Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time_Day.Width = 103;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(722, 1);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 54);
            this.buttonExport.TabIndex = 12;
            this.buttonExport.Text = "Export >>";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // Raports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewRaports);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Name = "Raports";
            this.Size = new System.Drawing.Size(800, 554);
            this.Load += new System.EventHandler(this.Raports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DataGridView dataGridViewRaports;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time_Day;
    }
}
