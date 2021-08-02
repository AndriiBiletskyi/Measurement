
namespace PomiaryGUI
{
    partial class InstantaneousValues
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
            this.angularGauge = new LiveCharts.WinForms.AngularGauge();
            this.labelName = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labelValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // angularGauge
            // 
            this.angularGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.angularGauge.BackColor = System.Drawing.Color.White;
            this.angularGauge.Location = new System.Drawing.Point(0, 50);
            this.angularGauge.Name = "angularGauge";
            this.angularGauge.Size = new System.Drawing.Size(398, 248);
            this.angularGauge.TabIndex = 0;
            this.angularGauge.Text = "angularGauge1";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(398, 50);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "label1657567";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.BackColor = System.Drawing.Color.Red;
            this.panelStatus.Location = new System.Drawing.Point(368, 50);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(30, 30);
            this.panelStatus.TabIndex = 2;
            // 
            // labelValue
            // 
            this.labelValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelValue.BackColor = System.Drawing.Color.Transparent;
            this.labelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelValue.ForeColor = System.Drawing.Color.Black;
            this.labelValue.Location = new System.Drawing.Point(164, 251);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(55, 30);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "100.00";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstantaneousValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.angularGauge);
            this.Name = "InstantaneousValues";
            this.Size = new System.Drawing.Size(398, 298);
            this.Tag = "InstantaneousValues";
            this.Resize += new System.EventHandler(this.InstantaneousValues_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.AngularGauge angularGauge;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelValue;
    }
}
