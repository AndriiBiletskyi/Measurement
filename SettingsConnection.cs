using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PomiaryGUI.Properties;

namespace PomiaryGUI
{
    public partial class SettingsConnection : UserControl
    {
        public event EventHandler ButtonConnectClick;
        public event EventHandler ButtonExecuteScriptClick;
        public event EventHandler ReplaceDDMM;

        public SettingsConnection()
        {
            InitializeComponent();
            butConnect.Click += new EventHandler(ButtonConnect_Click);
            butExecuteScript.Click += new EventHandler(ButtonExecuteScript_Click);
            checkBoxTime.CheckStateChanged += new EventHandler(Replace_DD_MM);
            textSerwer.Enabled = !checkStringConnection.Checked;
            textInitialCatalog.Enabled = !checkStringConnection.Checked;
            textUserID.Enabled = !checkStringConnection.Checked;
            textPassword.Enabled = !checkStringConnection.Checked;
            textStringConnection.Enabled = checkStringConnection.Checked;

            textPassword.PasswordChar = '*';
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            SaveDataForConnection();
            ButtonConnectClick?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonExecuteScript_Click(object sender, EventArgs e)
        {
            ButtonExecuteScriptClick?.Invoke(this, EventArgs.Empty);
        }

        private void Replace_DD_MM(object sender, EventArgs e)
        {

            PomiaryGUI.Properties.Settings.Default["SetDDMM"] = checkBoxTime.Checked;
            PomiaryGUI.Properties.Settings.Default.Save();
            ReplaceDDMM?.Invoke(this, EventArgs.Empty);
        }

        public List<string> GetDataConnection()
        {
            return new List<string>() { textSerwer.Text, 
                                        textInitialCatalog.Text, 
                                        textUserID.Text,
                                        textPassword.Text
                                      };
        }

        public string GetDataConnectionString()
        {
            return textStringConnection.Text;
        }

        public bool GetReplace()
        {
            return checkBoxTime.Checked;
        }

        public bool GetConnectionWay()
        {
            GetDataForConnection();
            return checkStringConnection.Checked;
        }

        private void CheckStringConnection_CheckedChanged(object sender, EventArgs e)
        {
            textSerwer.Enabled = !checkStringConnection.Checked;
            textInitialCatalog.Enabled = !checkStringConnection.Checked;
            textUserID.Enabled = !checkStringConnection.Checked;
            textPassword.Enabled = !checkStringConnection.Checked;
            textStringConnection.Enabled = checkStringConnection.Checked;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            int offset = labelConnectionString.Width + checkStringConnection.Width + 10;

            textSerwer.Width = this.Width - offset - 50;
            textInitialCatalog.Width = textSerwer.Width;
            textUserID.Width = textSerwer.Width;
            textPassword.Width = textSerwer.Width;
            textStringConnection.Width = textSerwer.Width;

            labelSerwer.Location = new Point(offset - labelSerwer.Width, 0);
            labelInitialCatalog.Location = new Point(offset - labelInitialCatalog.Width, labelSerwer.Location.Y + labelSerwer.Height);
            labelUserID.Location = new Point(offset - labelUserID.Width, labelInitialCatalog.Location.Y + labelInitialCatalog.Height);
            labelPassword.Location = new Point(offset - labelPassword.Width, labelUserID.Location.Y + labelUserID.Height);
            labelConnectionString.Location = new Point(0, labelPassword.Location.Y + labelPassword.Height);
            checkStringConnection.Location = new Point(labelConnectionString.Width + 5, labelPassword.Location.Y + labelPassword.Height + labelConnectionString.Height/3);

            textSerwer.Location = new Point(offset, labelSerwer.Location.Y);
            textInitialCatalog.Location = new Point(offset, labelInitialCatalog.Location.Y);
            textUserID.Location = new Point(offset, labelUserID.Location.Y);
            textPassword.Location = new Point(offset, labelPassword.Location.Y);
            textStringConnection.Location = new Point(offset, labelConnectionString.Location.Y);

            butConnect.Location = new Point(textStringConnection.Location.X + textStringConnection.Width - butConnect.Width,
                                            textStringConnection.Location.Y + textStringConnection.Height + 10);

            checkBoxTime.Location = new Point(0, butConnect.Location.Y + butConnect.Height + 20);

        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            checkBoxTime.Checked = (bool)PomiaryGUI.Properties.Settings.Default["SetDDMM"];
            ReplaceDDMM?.Invoke(this, EventArgs.Empty);
        }

        private void SaveDataForConnection()
        {
            PomiaryGUI.Properties.Settings.Default["SetConnection"] = checkStringConnection.Checked;
            PomiaryGUI.Properties.Settings.Default["textStringConnection"] = textStringConnection.Text;
            PomiaryGUI.Properties.Settings.Default["textSerwer"] = textSerwer.Text;
            PomiaryGUI.Properties.Settings.Default["textInitialCatalog"] = textInitialCatalog.Text;
            PomiaryGUI.Properties.Settings.Default["textUserID"] = textUserID.Text;
            PomiaryGUI.Properties.Settings.Default["textPassword"] = textPassword.Text;
            PomiaryGUI.Properties.Settings.Default.Save();
        }

        private void GetDataForConnection()
        {
            checkStringConnection.Checked = (bool)PomiaryGUI.Properties.Settings.Default["SetConnection"];
            textStringConnection.Text = (string)PomiaryGUI.Properties.Settings.Default["textStringConnection"];
            textSerwer.Text = (string)PomiaryGUI.Properties.Settings.Default["textSerwer"];
            textInitialCatalog.Text = (string)PomiaryGUI.Properties.Settings.Default["textInitialCatalog"];
            textUserID.Text = (string)PomiaryGUI.Properties.Settings.Default["textUserID"];
            textPassword.Text = (string)PomiaryGUI.Properties.Settings.Default["textPassword"];
        }
    }
}
