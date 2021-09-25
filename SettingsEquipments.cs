using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomiaryGUI
{
    public partial class SettingsEquipments : UserControl
    {
        public event EventHandler<int> IDChanged;
        public event EventHandler<SettingsEquipmentsData> UpdateData;

        public SettingsEquipments()
        {
            InitializeComponent();
            comboBoxID.TextChanged += new EventHandler(ComboBoxIDChanged);
            checkAdd.CheckedChanged += new EventHandler(CheckAdd);
            checkEdit.CheckedChanged += new EventHandler(CheckEdit);
            butSaveChanges.Click += new EventHandler(ButSaveChangesClick);
            checkEdit.Checked = true;
            comboBoxPhase.SelectedItem = comboBoxPhase.Items[1];
        }

        private void CheckEdit(object sender, EventArgs e)
        {
            if (checkEdit.Checked)
            {
                checkAdd.Checked = false;
                comboBoxID.Visible = true;
                TextIDAdd.Visible = false;
                butSaveChanges.Text = "Save";
            }
            else
            {
                if (checkAdd.Checked) checkEdit.Checked = false;
                else checkEdit.Checked = true;
            } 
        }

        private void CheckAdd(object sender, EventArgs e)
        {
            if (checkAdd.Checked)
            {
                checkEdit.Checked = false;
                comboBoxID.Visible = false;
                TextIDAdd.Visible = true;
                butSaveChanges.Text = "Add";
            }
            else
            {
                if (checkEdit.Checked) checkAdd.Checked = false;
                else checkAdd.Checked = true;
            }
        }

        public List<int> IdList
        {
            get
            {
                var list = new List<int>();
                foreach (var i in comboBoxID.Items)
                    list.Add(Convert.ToInt32(i));
                return list;
            }
            set
            {
                comboBoxID.Items.Clear();
                foreach (var i in value)
                    comboBoxID.Items.Add(i);
            }
        }
        
        public void SetDataForID(SettingsEquipmentsData data)
        {
            try
            {
                EquipmentName.Text = data.Name;
                Power.Text = data.RatedPower.ToString();
                Current.Text = data.RatedCurrent.ToString();
                Voltage.Text = data.RatedVoltage.ToString();
                comboBoxPhase.SelectedItem = data.NumberOfPhases.ToString();
                UnitOfPower.Text = data.UnitOfPower;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetEquList(List<int> id)
        {
            comboBoxID.Items.Clear();
            foreach (var i in id)
                comboBoxID.Items.Add(i.ToString());
        }

        private void ComboBoxIDChanged(object sender, EventArgs e)
        {
            IDChanged?.Invoke(sender, Convert.ToInt32(comboBoxID.SelectedItem));
        }

        private void ButSaveChangesClick(object sender, EventArgs e)
        {
            if (checkEdit.Checked)
            {
                var data = new SettingsEquipmentsData
                {
                    Id = Convert.ToInt32(comboBoxID.SelectedItem),
                    Name = EquipmentName.Text,
                    RatedPower = Convert.ToSingle(Power.Text),
                    RatedCurrent = Convert.ToSingle(Current.Text),
                    RatedVoltage = Convert.ToSingle(Voltage.Text),
                    NumberOfPhases = Convert.ToInt32(comboBoxPhase.SelectedItem),
                    UnitOfPower = UnitOfPower.Text
                };
                UpdateData?.Invoke(sender, data);
            }
        }
    }
}
