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
        public event EventHandler<SettingsEquipmentsData> AddNewEquipment;

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
                EquipmentNamePL.Text = data.NamePL;
                EquipmentNameEN.Text = data.NameEN;
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
                var data = new SettingsEquipmentsData();
                CollectData(ref data);
                data.Id = Convert.ToInt32(comboBoxID.SelectedItem);
                UpdateData?.Invoke(sender, data);
            }else if (checkAdd.Checked)
            {
                var data = new SettingsEquipmentsData();
                CollectData(ref data);
                data.Id = Convert.ToInt32(TextIDAdd.Text);
                AddNewEquipment?.Invoke(sender, data);
            }
        }

        private void CollectData(ref SettingsEquipmentsData settingsEquipmentsData)
        {
            
            settingsEquipmentsData.NamePL = EquipmentNamePL.Text;
            settingsEquipmentsData.NameEN = EquipmentNameEN.Text;
            settingsEquipmentsData.RatedPower = Convert.ToSingle(Power.Text);
            settingsEquipmentsData.RatedCurrent = Convert.ToSingle(Current.Text);
            settingsEquipmentsData.RatedVoltage = Convert.ToSingle(Voltage.Text);
            settingsEquipmentsData.NumberOfPhases = Convert.ToInt32(comboBoxPhase.SelectedItem);
            settingsEquipmentsData.UnitOfPower = UnitOfPower.Text;
        }
    }
}
