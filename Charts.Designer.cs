
namespace PomiaryGUI
{
    partial class Charts
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
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.buttonShow = new System.Windows.Forms.Button();
            this.chart = new LiveCharts.WinForms.CartesianChart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkP = new System.Windows.Forms.CheckBox();
            this.checkP_L1 = new System.Windows.Forms.CheckBox();
            this.checkP_L2 = new System.Windows.Forms.CheckBox();
            this.checkP_L3 = new System.Windows.Forms.CheckBox();
            this.checkQ = new System.Windows.Forms.CheckBox();
            this.checkQ_L1 = new System.Windows.Forms.CheckBox();
            this.checkQ_L2 = new System.Windows.Forms.CheckBox();
            this.checkQ_L3 = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateFrom
            // 
            this.DateFrom.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFrom.Location = new System.Drawing.Point(4, 1);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(154, 30);
            this.DateFrom.TabIndex = 0;
            this.DateFrom.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // DateTo
            // 
            this.DateTo.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTo.Location = new System.Drawing.Point(4, 33);
            this.DateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(317, 30);
            this.DateTo.TabIndex = 0;
            this.DateTo.Value = new System.DateTime(2021, 12, 31, 23, 59, 59, 0);
            // 
            // buttonShow
            // 
            this.buttonShow.AutoSize = true;
            this.buttonShow.Location = new System.Drawing.Point(329, 4);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(52, 27);
            this.buttonShow.TabIndex = 2;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chart.ForeColor = System.Drawing.Color.Black;
            this.chart.Location = new System.Drawing.Point(0, 74);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1368, 665);
            this.chart.TabIndex = 3;
            this.chart.Text = "cartesianChart1";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Szyn-1",
            "Szyn-2",
            "Szyn-3",
            "Szyn-4",
            "Szyn-5",
            "Piec 5",
            "Piec 6",
            "Piec 7",
            "Parowy BM",
            "Parowy AB_BQ",
            "Piec 3",
            "Piec 8"});
            this.comboBox1.Location = new System.Drawing.Point(437, 4);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(797, 38);
            this.comboBox1.TabIndex = 4;
            // 
            // checkP
            // 
            this.checkP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP.AutoSize = true;
            this.checkP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP.Location = new System.Drawing.Point(754, 41);
            this.checkP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkP.Name = "checkP";
            this.checkP.Size = new System.Drawing.Size(44, 27);
            this.checkP.TabIndex = 5;
            this.checkP.Text = "P";
            this.checkP.UseVisualStyleBackColor = true;
            // 
            // checkP_L1
            // 
            this.checkP_L1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L1.AutoSize = true;
            this.checkP_L1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L1.Location = new System.Drawing.Point(806, 41);
            this.checkP_L1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkP_L1.Name = "checkP_L1";
            this.checkP_L1.Size = new System.Drawing.Size(77, 27);
            this.checkP_L1.TabIndex = 5;
            this.checkP_L1.Text = "P_L1";
            this.checkP_L1.UseVisualStyleBackColor = true;
            // 
            // checkP_L2
            // 
            this.checkP_L2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L2.AutoSize = true;
            this.checkP_L2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L2.Location = new System.Drawing.Point(891, 41);
            this.checkP_L2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkP_L2.Name = "checkP_L2";
            this.checkP_L2.Size = new System.Drawing.Size(77, 27);
            this.checkP_L2.TabIndex = 5;
            this.checkP_L2.Text = "P_L2";
            this.checkP_L2.UseVisualStyleBackColor = true;
            // 
            // checkP_L3
            // 
            this.checkP_L3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L3.AutoSize = true;
            this.checkP_L3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L3.Location = new System.Drawing.Point(974, 41);
            this.checkP_L3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkP_L3.Name = "checkP_L3";
            this.checkP_L3.Size = new System.Drawing.Size(77, 27);
            this.checkP_L3.TabIndex = 5;
            this.checkP_L3.Text = "P_L3";
            this.checkP_L3.UseVisualStyleBackColor = true;
            // 
            // checkQ
            // 
            this.checkQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ.AutoSize = true;
            this.checkQ.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ.Location = new System.Drawing.Point(1056, 41);
            this.checkQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkQ.Name = "checkQ";
            this.checkQ.Size = new System.Drawing.Size(48, 27);
            this.checkQ.TabIndex = 5;
            this.checkQ.Text = "Q";
            this.checkQ.UseVisualStyleBackColor = true;
            // 
            // checkQ_L1
            // 
            this.checkQ_L1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L1.AutoSize = true;
            this.checkQ_L1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L1.Location = new System.Drawing.Point(1111, 41);
            this.checkQ_L1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkQ_L1.Name = "checkQ_L1";
            this.checkQ_L1.Size = new System.Drawing.Size(81, 27);
            this.checkQ_L1.TabIndex = 5;
            this.checkQ_L1.Text = "Q_L1";
            this.checkQ_L1.UseVisualStyleBackColor = true;
            // 
            // checkQ_L2
            // 
            this.checkQ_L2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L2.AutoSize = true;
            this.checkQ_L2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L2.Location = new System.Drawing.Point(1199, 41);
            this.checkQ_L2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkQ_L2.Name = "checkQ_L2";
            this.checkQ_L2.Size = new System.Drawing.Size(81, 27);
            this.checkQ_L2.TabIndex = 5;
            this.checkQ_L2.Text = "Q_L2";
            this.checkQ_L2.UseVisualStyleBackColor = true;
            // 
            // checkQ_L3
            // 
            this.checkQ_L3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L3.AutoSize = true;
            this.checkQ_L3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L3.Location = new System.Drawing.Point(1287, 41);
            this.checkQ_L3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkQ_L3.Name = "checkQ_L3";
            this.checkQ_L3.Size = new System.Drawing.Size(81, 27);
            this.checkQ_L3.TabIndex = 5;
            this.checkQ_L3.Text = "Q_L3";
            this.checkQ_L3.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.AutoSize = true;
            this.buttonExport.Location = new System.Drawing.Point(1241, 9);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(78, 27);
            this.buttonExport.TabIndex = 6;
            this.buttonExport.Text = "Export >>";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.button1_Click);
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.checkQ_L3);
            this.Controls.Add(this.checkQ_L2);
            this.Controls.Add(this.checkQ_L1);
            this.Controls.Add(this.checkQ);
            this.Controls.Add(this.checkP_L3);
            this.Controls.Add(this.checkP_L2);
            this.Controls.Add(this.checkP_L1);
            this.Controls.Add(this.checkP);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Charts";
            this.Size = new System.Drawing.Size(1368, 738);
            this.Load += new System.EventHandler(this.Chart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.Button buttonShow;
        private LiveCharts.WinForms.CartesianChart chart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkP;
        private System.Windows.Forms.CheckBox checkP_L1;
        private System.Windows.Forms.CheckBox checkP_L2;
        private System.Windows.Forms.CheckBox checkP_L3;
        private System.Windows.Forms.CheckBox checkQ;
        private System.Windows.Forms.CheckBox checkQ_L1;
        private System.Windows.Forms.CheckBox checkQ_L2;
        private System.Windows.Forms.CheckBox checkQ_L3;
        private System.Windows.Forms.Button buttonExport;
    }
}
