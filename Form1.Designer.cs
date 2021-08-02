
namespace PomiaryGUI
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btClose = new System.Windows.Forms.Button();
            this.panelHead = new System.Windows.Forms.Panel();
            this.btMin = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.butRaportsAnnual = new System.Windows.Forms.Button();
            this.butRaportsMonthly = new System.Windows.Forms.Button();
            this.butRaportsWeekly = new System.Windows.Forms.Button();
            this.butRaportsDaily = new System.Windows.Forms.Button();
            this.panelButtonMark = new System.Windows.Forms.Panel();
            this.butSettings = new System.Windows.Forms.Button();
            this.butRaports = new System.Windows.Forms.Button();
            this.butChartsEquipments = new System.Windows.Forms.Button();
            this.butChartsPower = new System.Windows.Forms.Button();
            this.butChartsCos = new System.Windows.Forms.Button();
            this.butChartsVoltage = new System.Windows.Forms.Button();
            this.butChartsCurrent = new System.Windows.Forms.Button();
            this.butCharts = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.LangComboBox = new System.Windows.Forms.ComboBox();
            this.panelLang = new System.Windows.Forms.Panel();
            this.labelDataTime = new System.Windows.Forms.Label();
            this.timerDataTime = new System.Windows.Forms.Timer(this.components);
            this.panelHead.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btClose.BackgroundImage")));
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btClose.Location = new System.Drawing.Point(770, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(30, 30);
            this.btClose.TabIndex = 0;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.ButClose_Click);
            // 
            // panelHead
            // 
            this.panelHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHead.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelHead.Controls.Add(this.btMin);
            this.panelHead.Controls.Add(this.btClose);
            this.panelHead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(800, 30);
            this.panelHead.TabIndex = 1;
            this.panelHead.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PanelHead_MouseDoubleClick);
            this.panelHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseDown);
            this.panelHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseMove);
            this.panelHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseUp);
            // 
            // btMin
            // 
            this.btMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMin.BackgroundImage")));
            this.btMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMin.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btMin.FlatAppearance.BorderSize = 0;
            this.btMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMin.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btMin.Location = new System.Drawing.Point(740, 0);
            this.btMin.Name = "btMin";
            this.btMin.Size = new System.Drawing.Size(30, 30);
            this.btMin.TabIndex = 0;
            this.btMin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btMin.UseVisualStyleBackColor = true;
            this.btMin.Click += new System.EventHandler(this.ButMin_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.butRaportsAnnual);
            this.panelButtons.Controls.Add(this.butRaportsMonthly);
            this.panelButtons.Controls.Add(this.butRaportsWeekly);
            this.panelButtons.Controls.Add(this.butRaportsDaily);
            this.panelButtons.Controls.Add(this.panelButtonMark);
            this.panelButtons.Controls.Add(this.butSettings);
            this.panelButtons.Controls.Add(this.butRaports);
            this.panelButtons.Controls.Add(this.butChartsEquipments);
            this.panelButtons.Controls.Add(this.butChartsPower);
            this.panelButtons.Controls.Add(this.butChartsCos);
            this.panelButtons.Controls.Add(this.butChartsVoltage);
            this.panelButtons.Controls.Add(this.butChartsCurrent);
            this.panelButtons.Controls.Add(this.butCharts);
            this.panelButtons.Location = new System.Drawing.Point(0, 30);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(150, 420);
            this.panelButtons.TabIndex = 2;
            this.panelButtons.Visible = false;
            // 
            // butRaportsAnnual
            // 
            this.butRaportsAnnual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRaportsAnnual.AutoSize = true;
            this.butRaportsAnnual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butRaportsAnnual.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butRaportsAnnual.FlatAppearance.BorderSize = 0;
            this.butRaportsAnnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRaportsAnnual.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRaportsAnnual.Location = new System.Drawing.Point(81, 345);
            this.butRaportsAnnual.Name = "butRaportsAnnual";
            this.butRaportsAnnual.Size = new System.Drawing.Size(66, 29);
            this.butRaportsAnnual.TabIndex = 4;
            this.butRaportsAnnual.Text = "Annual";
            this.butRaportsAnnual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRaportsAnnual.UseVisualStyleBackColor = true;
            // 
            // butRaportsMonthly
            // 
            this.butRaportsMonthly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRaportsMonthly.AutoSize = true;
            this.butRaportsMonthly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butRaportsMonthly.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butRaportsMonthly.FlatAppearance.BorderSize = 0;
            this.butRaportsMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRaportsMonthly.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRaportsMonthly.Location = new System.Drawing.Point(71, 307);
            this.butRaportsMonthly.Name = "butRaportsMonthly";
            this.butRaportsMonthly.Size = new System.Drawing.Size(76, 29);
            this.butRaportsMonthly.TabIndex = 4;
            this.butRaportsMonthly.Text = "Monthly";
            this.butRaportsMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRaportsMonthly.UseVisualStyleBackColor = true;
            // 
            // butRaportsWeekly
            // 
            this.butRaportsWeekly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRaportsWeekly.AutoSize = true;
            this.butRaportsWeekly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butRaportsWeekly.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butRaportsWeekly.FlatAppearance.BorderSize = 0;
            this.butRaportsWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRaportsWeekly.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRaportsWeekly.Location = new System.Drawing.Point(75, 271);
            this.butRaportsWeekly.Name = "butRaportsWeekly";
            this.butRaportsWeekly.Size = new System.Drawing.Size(70, 29);
            this.butRaportsWeekly.TabIndex = 4;
            this.butRaportsWeekly.Text = "Weekly";
            this.butRaportsWeekly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRaportsWeekly.UseVisualStyleBackColor = true;
            // 
            // butRaportsDaily
            // 
            this.butRaportsDaily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRaportsDaily.AutoSize = true;
            this.butRaportsDaily.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butRaportsDaily.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butRaportsDaily.FlatAppearance.BorderSize = 0;
            this.butRaportsDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRaportsDaily.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRaportsDaily.Location = new System.Drawing.Point(92, 234);
            this.butRaportsDaily.Name = "butRaportsDaily";
            this.butRaportsDaily.Size = new System.Drawing.Size(55, 29);
            this.butRaportsDaily.TabIndex = 4;
            this.butRaportsDaily.Text = "Daily";
            this.butRaportsDaily.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRaportsDaily.UseVisualStyleBackColor = true;
            // 
            // panelButtonMark
            // 
            this.panelButtonMark.BackColor = System.Drawing.Color.Red;
            this.panelButtonMark.Location = new System.Drawing.Point(0, 40);
            this.panelButtonMark.Name = "panelButtonMark";
            this.panelButtonMark.Size = new System.Drawing.Size(150, 3);
            this.panelButtonMark.TabIndex = 3;
            // 
            // butSettings
            // 
            this.butSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSettings.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butSettings.FlatAppearance.BorderSize = 0;
            this.butSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSettings.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSettings.Location = new System.Drawing.Point(0, 376);
            this.butSettings.Name = "butSettings";
            this.butSettings.Size = new System.Drawing.Size(150, 40);
            this.butSettings.TabIndex = 0;
            this.butSettings.Text = "Settings";
            this.butSettings.UseVisualStyleBackColor = true;
            // 
            // butRaports
            // 
            this.butRaports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRaports.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butRaports.FlatAppearance.BorderSize = 0;
            this.butRaports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRaports.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRaports.Location = new System.Drawing.Point(0, 196);
            this.butRaports.Name = "butRaports";
            this.butRaports.Size = new System.Drawing.Size(150, 40);
            this.butRaports.TabIndex = 0;
            this.butRaports.Text = "Reports";
            this.butRaports.UseVisualStyleBackColor = true;
            // 
            // butChartsEquipments
            // 
            this.butChartsEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChartsEquipments.AutoSize = true;
            this.butChartsEquipments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butChartsEquipments.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butChartsEquipments.FlatAppearance.BorderSize = 0;
            this.butChartsEquipments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChartsEquipments.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChartsEquipments.Location = new System.Drawing.Point(53, 167);
            this.butChartsEquipments.Name = "butChartsEquipments";
            this.butChartsEquipments.Size = new System.Drawing.Size(97, 29);
            this.butChartsEquipments.TabIndex = 0;
            this.butChartsEquipments.Text = "Equipments";
            this.butChartsEquipments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChartsEquipments.UseVisualStyleBackColor = true;
            // 
            // butChartsPower
            // 
            this.butChartsPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChartsPower.AutoSize = true;
            this.butChartsPower.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butChartsPower.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butChartsPower.FlatAppearance.BorderSize = 0;
            this.butChartsPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChartsPower.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChartsPower.Location = new System.Drawing.Point(90, 46);
            this.butChartsPower.Name = "butChartsPower";
            this.butChartsPower.Size = new System.Drawing.Size(60, 29);
            this.butChartsPower.TabIndex = 0;
            this.butChartsPower.Text = "Power";
            this.butChartsPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChartsPower.UseVisualStyleBackColor = true;
            // 
            // butChartsCos
            // 
            this.butChartsCos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChartsCos.AutoSize = true;
            this.butChartsCos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butChartsCos.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butChartsCos.FlatAppearance.BorderSize = 0;
            this.butChartsCos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChartsCos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChartsCos.Location = new System.Drawing.Point(105, 137);
            this.butChartsCos.Name = "butChartsCos";
            this.butChartsCos.Size = new System.Drawing.Size(45, 29);
            this.butChartsCos.TabIndex = 0;
            this.butChartsCos.Text = "Cos";
            this.butChartsCos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChartsCos.UseVisualStyleBackColor = true;
            // 
            // butChartsVoltage
            // 
            this.butChartsVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChartsVoltage.AutoSize = true;
            this.butChartsVoltage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butChartsVoltage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butChartsVoltage.FlatAppearance.BorderSize = 0;
            this.butChartsVoltage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChartsVoltage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChartsVoltage.Location = new System.Drawing.Point(80, 109);
            this.butChartsVoltage.Name = "butChartsVoltage";
            this.butChartsVoltage.Size = new System.Drawing.Size(70, 29);
            this.butChartsVoltage.TabIndex = 0;
            this.butChartsVoltage.Text = "Voltage";
            this.butChartsVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChartsVoltage.UseVisualStyleBackColor = true;
            // 
            // butChartsCurrent
            // 
            this.butChartsCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChartsCurrent.AutoSize = true;
            this.butChartsCurrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butChartsCurrent.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butChartsCurrent.FlatAppearance.BorderSize = 0;
            this.butChartsCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChartsCurrent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChartsCurrent.Location = new System.Drawing.Point(79, 76);
            this.butChartsCurrent.Name = "butChartsCurrent";
            this.butChartsCurrent.Size = new System.Drawing.Size(71, 29);
            this.butChartsCurrent.TabIndex = 0;
            this.butChartsCurrent.Text = "Current";
            this.butChartsCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butChartsCurrent.UseVisualStyleBackColor = true;
            // 
            // butCharts
            // 
            this.butCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCharts.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.butCharts.FlatAppearance.BorderSize = 0;
            this.butCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCharts.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCharts.Location = new System.Drawing.Point(0, 0);
            this.butCharts.Name = "butCharts";
            this.butCharts.Size = new System.Drawing.Size(150, 40);
            this.butCharts.TabIndex = 0;
            this.butCharts.Text = "Charts";
            this.butCharts.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.BackColor = System.Drawing.Color.DimGray;
            this.panelBottom.Controls.Add(this.LangComboBox);
            this.panelBottom.Controls.Add(this.panelLang);
            this.panelBottom.Controls.Add(this.labelDataTime);
            this.panelBottom.Location = new System.Drawing.Point(0, 450);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 30);
            this.panelBottom.TabIndex = 5;
            // 
            // LangComboBox
            // 
            this.LangComboBox.BackColor = System.Drawing.Color.White;
            this.LangComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LangComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LangComboBox.ItemHeight = 19;
            this.LangComboBox.Items.AddRange(new object[] {
            "EN",
            "PL",
            "DE",
            "UA",
            "ES",
            "HU"});
            this.LangComboBox.Location = new System.Drawing.Point(50, 1);
            this.LangComboBox.Name = "LangComboBox";
            this.LangComboBox.Size = new System.Drawing.Size(50, 27);
            this.LangComboBox.TabIndex = 2;
            // 
            // panelLang
            // 
            this.panelLang.BackgroundImage = global::PomiaryGUI.Properties.Resources.GB;
            this.panelLang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLang.Location = new System.Drawing.Point(0, 0);
            this.panelLang.Name = "panelLang";
            this.panelLang.Size = new System.Drawing.Size(50, 30);
            this.panelLang.TabIndex = 1;
            // 
            // labelDataTime
            // 
            this.labelDataTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDataTime.AutoSize = true;
            this.labelDataTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDataTime.ForeColor = System.Drawing.Color.White;
            this.labelDataTime.Location = new System.Drawing.Point(591, 3);
            this.labelDataTime.Name = "labelDataTime";
            this.labelDataTime.Size = new System.Drawing.Size(45, 24);
            this.labelDataTime.TabIndex = 0;
            this.labelDataTime.Text = "time";
            // 
            // timerDataTime
            // 
            this.timerDataTime.Enabled = true;
            this.timerDataTime.Interval = 1000;
            this.timerDataTime.Tick += new System.EventHandler(this.TimerDataTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelHead.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Button btMin;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button butCharts;
        private System.Windows.Forms.Button butChartsCurrent;
        private System.Windows.Forms.Panel panelButtonMark;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button butChartsEquipments;
        private System.Windows.Forms.Label labelDataTime;
        private System.Windows.Forms.Timer timerDataTime;
        private System.Windows.Forms.Button butRaports;
        private System.Windows.Forms.Button butSettings;
        private System.Windows.Forms.Button butChartsPower;
        private System.Windows.Forms.Button butChartsCos;
        private System.Windows.Forms.Button butChartsVoltage;
        private System.Windows.Forms.Button butRaportsAnnual;
        private System.Windows.Forms.Button butRaportsMonthly;
        private System.Windows.Forms.Button butRaportsWeekly;
        private System.Windows.Forms.Button butRaportsDaily;
        private System.Windows.Forms.Panel panelLang;
        private System.Windows.Forms.ComboBox LangComboBox;
    }
}

