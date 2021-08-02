
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
            this.label1 = new System.Windows.Forms.Label();
            this.textInitialCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.UserID = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.textStringConnection = new System.Windows.Forms.TextBox();
            this.checkStringConnection = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textSerwer
            // 
            this.textSerwer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSerwer.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textSerwer.Location = new System.Drawing.Point(213, 75);
            this.textSerwer.Name = "textSerwer";
            this.textSerwer.Size = new System.Drawing.Size(541, 32);
            this.textSerwer.TabIndex = 0;
            this.textSerwer.Text = "PL02K01-C0AH8FL,1433\\SQL25012021";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(132, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serwer";
            // 
            // textInitialCatalog
            // 
            this.textInitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInitialCatalog.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textInitialCatalog.Location = new System.Drawing.Point(213, 113);
            this.textInitialCatalog.Name = "textInitialCatalog";
            this.textInitialCatalog.Size = new System.Drawing.Size(541, 32);
            this.textInitialCatalog.TabIndex = 0;
            this.textInitialCatalog.Text = "pomiary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(68, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial Catalog";
            // 
            // butConnect
            // 
            this.butConnect.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.butConnect.Location = new System.Drawing.Point(177, 267);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(131, 47);
            this.butConnect.TabIndex = 2;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            // 
            // textUserID
            // 
            this.textUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUserID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textUserID.Location = new System.Drawing.Point(213, 151);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(541, 32);
            this.textUserID.TabIndex = 0;
            this.textUserID.Text = "uzytkownik";
            // 
            // textPassword
            // 
            this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textPassword.Location = new System.Drawing.Point(213, 189);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(541, 32);
            this.textPassword.TabIndex = 0;
            this.textPassword.Text = "Kayser2021";
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserID.Location = new System.Drawing.Point(132, 155);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(73, 24);
            this.UserID.TabIndex = 1;
            this.UserID.Text = "UserID";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Password.Location = new System.Drawing.Point(109, 193);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(96, 24);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBoxTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxTime.Location = new System.Drawing.Point(0, 400);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(757, 28);
            this.checkBoxTime.TabIndex = 3;
            this.checkBoxTime.Text = "Replace DD:MM";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            // 
            // textStringConnection
            // 
            this.textStringConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textStringConnection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textStringConnection.Location = new System.Drawing.Point(213, 227);
            this.textStringConnection.Name = "textStringConnection";
            this.textStringConnection.Size = new System.Drawing.Size(541, 32);
            this.textStringConnection.TabIndex = 0;
            // 
            // checkStringConnection
            // 
            this.checkStringConnection.AutoSize = true;
            this.checkStringConnection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkStringConnection.Location = new System.Drawing.Point(190, 237);
            this.checkStringConnection.Name = "checkStringConnection";
            this.checkStringConnection.Size = new System.Drawing.Size(15, 14);
            this.checkStringConnection.TabIndex = 3;
            this.checkStringConnection.UseVisualStyleBackColor = true;
            this.checkStringConnection.CheckedChanged += new System.EventHandler(this.CheckStringConnection_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(15, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Connection String";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkStringConnection);
            this.Controls.Add(this.checkBoxTime);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textStringConnection);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.textInitialCatalog);
            this.Controls.Add(this.textSerwer);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(757, 428);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSerwer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textInitialCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.TextBox textStringConnection;
        private System.Windows.Forms.CheckBox checkStringConnection;
        private System.Windows.Forms.Label label3;
    }
}
