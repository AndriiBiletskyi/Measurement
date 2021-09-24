
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
            this.butExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateFrom
            // 
            this.DateFrom.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFrom.Location = new System.Drawing.Point(3, 1);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(116, 26);
            this.DateFrom.TabIndex = 0;
            this.DateFrom.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // DateTo
            // 
            this.DateTo.CustomFormat = "MMMM/dd/yyyy HH:mm:ss";
            this.DateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTo.Location = new System.Drawing.Point(3, 27);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(239, 26);
            this.DateTo.TabIndex = 0;
            this.DateTo.Value = new System.DateTime(2021, 12, 31, 23, 59, 59, 0);
            // 
            // buttonShow
            // 
            this.buttonShow.AutoSize = true;
            this.buttonShow.Location = new System.Drawing.Point(247, 3);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(44, 23);
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
            this.chart.Location = new System.Drawing.Point(0, 60);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1026, 540);
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
            this.comboBox1.Location = new System.Drawing.Point(328, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(599, 32);
            this.comboBox1.TabIndex = 4;
            // 
            // checkP
            // 
            this.checkP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP.AutoSize = true;
            this.checkP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP.Location = new System.Drawing.Point(562, 33);
            this.checkP.Name = "checkP";
            this.checkP.Size = new System.Drawing.Size(37, 23);
            this.checkP.TabIndex = 5;
            this.checkP.Text = "P";
            this.checkP.UseVisualStyleBackColor = true;
            // 
            // checkP_L1
            // 
            this.checkP_L1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L1.AutoSize = true;
            this.checkP_L1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L1.Location = new System.Drawing.Point(599, 33);
            this.checkP_L1.Name = "checkP_L1";
            this.checkP_L1.Size = new System.Drawing.Size(63, 23);
            this.checkP_L1.TabIndex = 5;
            this.checkP_L1.Text = "P_L1";
            this.checkP_L1.UseVisualStyleBackColor = true;
            // 
            // checkP_L2
            // 
            this.checkP_L2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L2.AutoSize = true;
            this.checkP_L2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L2.Location = new System.Drawing.Point(663, 33);
            this.checkP_L2.Name = "checkP_L2";
            this.checkP_L2.Size = new System.Drawing.Size(63, 23);
            this.checkP_L2.TabIndex = 5;
            this.checkP_L2.Text = "P_L2";
            this.checkP_L2.UseVisualStyleBackColor = true;
            // 
            // checkP_L3
            // 
            this.checkP_L3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkP_L3.AutoSize = true;
            this.checkP_L3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkP_L3.Location = new System.Drawing.Point(725, 33);
            this.checkP_L3.Name = "checkP_L3";
            this.checkP_L3.Size = new System.Drawing.Size(63, 23);
            this.checkP_L3.TabIndex = 5;
            this.checkP_L3.Text = "P_L3";
            this.checkP_L3.UseVisualStyleBackColor = true;
            // 
            // checkQ
            // 
            this.checkQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ.AutoSize = true;
            this.checkQ.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ.Location = new System.Drawing.Point(788, 33);
            this.checkQ.Name = "checkQ";
            this.checkQ.Size = new System.Drawing.Size(40, 23);
            this.checkQ.TabIndex = 5;
            this.checkQ.Text = "Q";
            this.checkQ.UseVisualStyleBackColor = true;
            // 
            // checkQ_L1
            // 
            this.checkQ_L1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L1.AutoSize = true;
            this.checkQ_L1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L1.Location = new System.Drawing.Point(828, 33);
            this.checkQ_L1.Name = "checkQ_L1";
            this.checkQ_L1.Size = new System.Drawing.Size(66, 23);
            this.checkQ_L1.TabIndex = 5;
            this.checkQ_L1.Text = "Q_L1";
            this.checkQ_L1.UseVisualStyleBackColor = true;
            // 
            // checkQ_L2
            // 
            this.checkQ_L2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L2.AutoSize = true;
            this.checkQ_L2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L2.Location = new System.Drawing.Point(894, 33);
            this.checkQ_L2.Name = "checkQ_L2";
            this.checkQ_L2.Size = new System.Drawing.Size(66, 23);
            this.checkQ_L2.TabIndex = 5;
            this.checkQ_L2.Text = "Q_L2";
            this.checkQ_L2.UseVisualStyleBackColor = true;
            // 
            // checkQ_L3
            // 
            this.checkQ_L3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkQ_L3.AutoSize = true;
            this.checkQ_L3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkQ_L3.Location = new System.Drawing.Point(960, 33);
            this.checkQ_L3.Name = "checkQ_L3";
            this.checkQ_L3.Size = new System.Drawing.Size(66, 23);
            this.checkQ_L3.TabIndex = 5;
            this.checkQ_L3.Text = "Q_L3";
            this.checkQ_L3.UseVisualStyleBackColor = true;
            // 
            // butExport
            // 
            this.butExport.AutoSize = true;
            this.butExport.Location = new System.Drawing.Point(931, 7);
            this.butExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(62, 23);
            this.butExport.TabIndex = 6;
            this.butExport.Text = "Export >>";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.ButExport_Click);
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.butExport);
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
            this.Name = "Charts";
            this.Size = new System.Drawing.Size(1026, 600);
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
        private System.Windows.Forms.Button butExport;
    }
}
