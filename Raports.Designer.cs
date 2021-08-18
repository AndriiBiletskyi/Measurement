
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.buttonShow.Location = new System.Drawing.Point(227, 0);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(100, 66);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // DateTo
            // 
            this.DateTo.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTo.Location = new System.Drawing.Point(4, 33);
            this.DateTo.Margin = new System.Windows.Forms.Padding(4);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(222, 30);
            this.DateTo.TabIndex = 6;
            this.DateTo.Value = new System.DateTime(2021, 12, 31, 23, 59, 59, 0);
            // 
            // DateFrom
            // 
            this.DateFrom.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFrom.Location = new System.Drawing.Point(0, 1);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(226, 30);
            this.DateFrom.TabIndex = 7;
            this.DateFrom.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // dataGridViewRaports
            // 
            this.dataGridViewRaports.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewRaports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewRaports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRaports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRaports.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRaports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRaports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRaports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewRaports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time_Day});
            this.dataGridViewRaports.GridColor = System.Drawing.Color.Black;
            this.dataGridViewRaports.Location = new System.Drawing.Point(0, 66);
            this.dataGridViewRaports.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRaports.Name = "dataGridViewRaports";
            this.dataGridViewRaports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewRaports.RowHeadersWidth = 51;
            this.dataGridViewRaports.Size = new System.Drawing.Size(1067, 615);
            this.dataGridViewRaports.TabIndex = 13;
            // 
            // Time_Day
            // 
            this.Time_Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Time_Day.DefaultCellStyle = dataGridViewCellStyle9;
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
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Raports";
            this.Size = new System.Drawing.Size(1067, 682);
            this.Load += new System.EventHandler(this.Raports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DataGridView dataGridViewRaports;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time_Day;
        private System.Windows.Forms.Button buttonExport;
    }
}
