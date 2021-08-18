
namespace PomiaryGUI
{
    partial class Settings
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
            this.textSerwer = new System.Windows.Forms.TextBox();
            this.labelSerwer = new System.Windows.Forms.Label();
            this.textInitialCatalog = new System.Windows.Forms.TextBox();
            this.labelInitialCatalog = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.textStringConnection = new System.Windows.Forms.TextBox();
            this.checkStringConnection = new System.Windows.Forms.CheckBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textSerwer
            // 
            this.textSerwer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSerwer.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textSerwer.Location = new System.Drawing.Point(284, 92);
            this.textSerwer.Margin = new System.Windows.Forms.Padding(4);
            this.textSerwer.Name = "textSerwer";
            this.textSerwer.Size = new System.Drawing.Size(720, 38);
            this.textSerwer.TabIndex = 0;
            this.textSerwer.Text = "PL02K01-C0AH8FL,1433\\SQL25012021";
            // 
            // labelSerwer
            // 
            this.labelSerwer.AutoSize = true;
            this.labelSerwer.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSerwer.Location = new System.Drawing.Point(176, 97);
            this.labelSerwer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSerwer.Name = "labelSerwer";
            this.labelSerwer.Size = new System.Drawing.Size(96, 31);
            this.labelSerwer.TabIndex = 1;
            this.labelSerwer.Text = "Serwer";
            // 
            // textInitialCatalog
            // 
            this.textInitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInitialCatalog.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textInitialCatalog.Location = new System.Drawing.Point(284, 139);
            this.textInitialCatalog.Margin = new System.Windows.Forms.Padding(4);
            this.textInitialCatalog.Name = "textInitialCatalog";
            this.textInitialCatalog.Size = new System.Drawing.Size(720, 38);
            this.textInitialCatalog.TabIndex = 0;
            this.textInitialCatalog.Text = "pomiary";
            // 
            // labelInitialCatalog
            // 
            this.labelInitialCatalog.AutoSize = true;
            this.labelInitialCatalog.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInitialCatalog.Location = new System.Drawing.Point(91, 144);
            this.labelInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInitialCatalog.Name = "labelInitialCatalog";
            this.labelInitialCatalog.Size = new System.Drawing.Size(185, 31);
            this.labelInitialCatalog.TabIndex = 1;
            this.labelInitialCatalog.Text = "Initial Catalog";
            // 
            // butConnect
            // 
            this.butConnect.AutoSize = true;
            this.butConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butConnect.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.butConnect.Location = new System.Drawing.Point(236, 329);
            this.butConnect.Margin = new System.Windows.Forms.Padding(4);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(121, 41);
            this.butConnect.TabIndex = 2;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            // 
            // textUserID
            // 
            this.textUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUserID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textUserID.Location = new System.Drawing.Point(284, 186);
            this.textUserID.Margin = new System.Windows.Forms.Padding(4);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(720, 38);
            this.textUserID.TabIndex = 0;
            this.textUserID.Text = "uzytkownik";
            // 
            // textPassword
            // 
            this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textPassword.Location = new System.Drawing.Point(284, 233);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(720, 38);
            this.textPassword.TabIndex = 0;
            this.textPassword.Text = "Kayser2021";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUserID.Location = new System.Drawing.Point(176, 191);
            this.labelUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(99, 31);
            this.labelUserID.TabIndex = 1;
            this.labelUserID.Text = "UserID";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPassword.Location = new System.Drawing.Point(145, 238);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(127, 31);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxTime.Location = new System.Drawing.Point(36, 408);
            this.checkBoxTime.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(235, 35);
            this.checkBoxTime.TabIndex = 3;
            this.checkBoxTime.Text = "Replace DD:MM";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            // 
            // textStringConnection
            // 
            this.textStringConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textStringConnection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textStringConnection.Location = new System.Drawing.Point(284, 279);
            this.textStringConnection.Margin = new System.Windows.Forms.Padding(4);
            this.textStringConnection.Name = "textStringConnection";
            this.textStringConnection.Size = new System.Drawing.Size(720, 38);
            this.textStringConnection.TabIndex = 0;
            // 
            // checkStringConnection
            // 
            this.checkStringConnection.AutoSize = true;
            this.checkStringConnection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkStringConnection.Location = new System.Drawing.Point(253, 292);
            this.checkStringConnection.Margin = new System.Windows.Forms.Padding(4);
            this.checkStringConnection.Name = "checkStringConnection";
            this.checkStringConnection.Size = new System.Drawing.Size(18, 17);
            this.checkStringConnection.TabIndex = 3;
            this.checkStringConnection.UseVisualStyleBackColor = true;
            this.checkStringConnection.CheckedChanged += new System.EventHandler(this.CheckStringConnection_CheckedChanged);
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConnectionString.Location = new System.Drawing.Point(20, 283);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(227, 31);
            this.labelConnectionString.TabIndex = 1;
            this.labelConnectionString.Text = "Connection String";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkStringConnection);
            this.Controls.Add(this.checkBoxTime);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelInitialCatalog);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.labelSerwer);
            this.Controls.Add(this.textStringConnection);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.textInitialCatalog);
            this.Controls.Add(this.textSerwer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1009, 527);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSerwer;
        private System.Windows.Forms.Label labelSerwer;
        private System.Windows.Forms.TextBox textInitialCatalog;
        private System.Windows.Forms.Label labelInitialCatalog;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.TextBox textStringConnection;
        private System.Windows.Forms.CheckBox checkStringConnection;
        private System.Windows.Forms.Label labelConnectionString;
    }
}
