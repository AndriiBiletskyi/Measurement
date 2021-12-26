
namespace PomiaryGUI
{
    partial class SettingsEquipments
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
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.EquipmentNamePL = new System.Windows.Forms.TextBox();
            this.Power = new System.Windows.Forms.TextBox();
            this.Current = new System.Windows.Forms.TextBox();
            this.Voltage = new System.Windows.Forms.TextBox();
            this.comboBoxPhase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butSaveChanges = new System.Windows.Forms.Button();
            this.checkEdit = new System.Windows.Forms.CheckBox();
            this.checkAdd = new System.Windows.Forms.CheckBox();
            this.TextIDAdd = new System.Windows.Forms.TextBox();
            this.UnitOfPower = new System.Windows.Forms.TextBox();
            this.EquipmentNameEN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxID
            // 
            this.comboBoxID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(19, 52);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(107, 32);
            this.comboBoxID.TabIndex = 0;
            // 
            // EquipmentNamePL
            // 
            this.EquipmentNamePL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EquipmentNamePL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EquipmentNamePL.Location = new System.Drawing.Point(132, 52);
            this.EquipmentNamePL.Name = "EquipmentNamePL";
            this.EquipmentNamePL.Size = new System.Drawing.Size(585, 32);
            this.EquipmentNamePL.TabIndex = 1;
            // 
            // Power
            // 
            this.Power.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Power.Location = new System.Drawing.Point(132, 128);
            this.Power.Name = "Power";
            this.Power.Size = new System.Drawing.Size(79, 32);
            this.Power.TabIndex = 1;
            this.Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Current
            // 
            this.Current.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Current.Location = new System.Drawing.Point(132, 166);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(79, 32);
            this.Current.TabIndex = 1;
            this.Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Voltage
            // 
            this.Voltage.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Voltage.Location = new System.Drawing.Point(132, 204);
            this.Voltage.Name = "Voltage";
            this.Voltage.Size = new System.Drawing.Size(79, 32);
            this.Voltage.TabIndex = 1;
            this.Voltage.Text = "400";
            this.Voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxPhase
            // 
            this.comboBoxPhase.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxPhase.FormattingEnabled = true;
            this.comboBoxPhase.Items.AddRange(new object[] {
            "1",
            "3"});
            this.comboBoxPhase.Location = new System.Drawing.Point(132, 242);
            this.comboBoxPhase.Name = "comboBoxPhase";
            this.comboBoxPhase.Size = new System.Drawing.Size(79, 32);
            this.comboBoxPhase.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(217, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(217, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(217, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phase";
            // 
            // butSaveChanges
            // 
            this.butSaveChanges.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.butSaveChanges.Location = new System.Drawing.Point(132, 280);
            this.butSaveChanges.Name = "butSaveChanges";
            this.butSaveChanges.Size = new System.Drawing.Size(149, 32);
            this.butSaveChanges.TabIndex = 3;
            this.butSaveChanges.Text = "Save";
            this.butSaveChanges.UseVisualStyleBackColor = true;
            // 
            // checkEdit
            // 
            this.checkEdit.AutoSize = true;
            this.checkEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkEdit.Location = new System.Drawing.Point(34, 14);
            this.checkEdit.Name = "checkEdit";
            this.checkEdit.Size = new System.Drawing.Size(55, 23);
            this.checkEdit.TabIndex = 6;
            this.checkEdit.Text = "Edit";
            this.checkEdit.UseVisualStyleBackColor = true;
            // 
            // checkAdd
            // 
            this.checkAdd.AutoSize = true;
            this.checkAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkAdd.Location = new System.Drawing.Point(129, 14);
            this.checkAdd.Name = "checkAdd";
            this.checkAdd.Size = new System.Drawing.Size(58, 23);
            this.checkAdd.TabIndex = 6;
            this.checkAdd.Text = "New";
            this.checkAdd.UseVisualStyleBackColor = true;
            // 
            // TextIDAdd
            // 
            this.TextIDAdd.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextIDAdd.Location = new System.Drawing.Point(19, 52);
            this.TextIDAdd.Name = "TextIDAdd";
            this.TextIDAdd.Size = new System.Drawing.Size(107, 32);
            this.TextIDAdd.TabIndex = 1;
            // 
            // UnitOfPower
            // 
            this.UnitOfPower.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UnitOfPower.Location = new System.Drawing.Point(217, 128);
            this.UnitOfPower.Name = "UnitOfPower";
            this.UnitOfPower.Size = new System.Drawing.Size(46, 32);
            this.UnitOfPower.TabIndex = 1;
            this.UnitOfPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EquipmentNameEN
            // 
            this.EquipmentNameEN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EquipmentNameEN.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EquipmentNameEN.Location = new System.Drawing.Point(132, 90);
            this.EquipmentNameEN.Name = "EquipmentNameEN";
            this.EquipmentNameEN.Size = new System.Drawing.Size(585, 32);
            this.EquipmentNameEN.TabIndex = 1;
            // 
            // SettingsEquipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkAdd);
            this.Controls.Add(this.checkEdit);
            this.Controls.Add(this.butSaveChanges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Voltage);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.TextIDAdd);
            this.Controls.Add(this.UnitOfPower);
            this.Controls.Add(this.Power);
            this.Controls.Add(this.EquipmentNameEN);
            this.Controls.Add(this.EquipmentNamePL);
            this.Controls.Add(this.comboBoxPhase);
            this.Controls.Add(this.comboBoxID);
            this.Name = "SettingsEquipments";
            this.Size = new System.Drawing.Size(720, 452);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.TextBox EquipmentNamePL;
        private System.Windows.Forms.TextBox Power;
        private System.Windows.Forms.TextBox Current;
        private System.Windows.Forms.TextBox Voltage;
        private System.Windows.Forms.ComboBox comboBoxPhase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butSaveChanges;
        private System.Windows.Forms.CheckBox checkEdit;
        private System.Windows.Forms.CheckBox checkAdd;
        private System.Windows.Forms.TextBox TextIDAdd;
        private System.Windows.Forms.TextBox UnitOfPower;
        private System.Windows.Forms.TextBox EquipmentNameEN;
    }
}
