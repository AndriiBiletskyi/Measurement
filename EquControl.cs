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

    public partial class EquControl : UserControl
    {
        //public event EventHandler EquComboBoxTextChanged;
        //public event EventHandler GroupsComboBoxTextChanged;

        

        public EquControl()
        {
            InitializeComponent();
          
            //EquComboBox.TextChanged += new EventHandler(EquComboBox_TextChanged);
            //GroupsComboBox.TextChanged += new EventHandler(GroupsComboBox_TextChanged);
        }

        //#region ComboBox
        //private void EquComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (EquComboBoxTextChanged != null) EquComboBoxTextChanged(this, EventArgs.Empty);
        //}

        //public void EquComboBoxAdd(string value)
        //{
        //    EquComboBox.Items.Add(value); 
        //}

        //public void EquComboBoxClear()
        //{
        //    EquComboBox.Items.Clear();
        //}

        //public string EquComboBoxText()
        //{
        //    return EquComboBox.Text;
        //}

        //public int EquComboBoxCount()
        //{
        //    return EquComboBox.Items.Count;
        //}

        //public ComboBox.ObjectCollection EqucomboBoxItems()
        //{
        //    return EquComboBox.Items;
        //}

        //private void GroupsComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (GroupsComboBoxTextChanged != null) GroupsComboBoxTextChanged(this, EventArgs.Empty);
        //}

        //public void GroupsComboBoxAdd(string value)
        //{
        //    GroupsComboBox.Items.Add(value);
        //}

        //public void GroupsComboBoxClear()
        //{
        //    GroupsComboBox.Items.Clear();
        //}

        //public string GroupsComboBoxText()
        //{
        //    return GroupsComboBox.Text;
        //}

        //public int GroupsComboBoxCount()
        //{
        //    return GroupsComboBox.Items.Count;
        //}

        //public ComboBox.ObjectCollection GroupscomboBoxItems()
        //{
        //    return GroupsComboBox.Items;
        //}
        //#endregion

        #region Equcontrol
        private void EquControl_Resize(object sender, EventArgs e)
        {
            //GroupsComboBox.Size = new Size(((Control)sender).Width / 2, GroupsComboBox.Height);
            //GroupsComboBox.Location = new Point(0, 0);
            //EquComboBox.Size = new Size(((Control)sender).Width / 2, EquComboBox.Height);
            //EquComboBox.Location = new Point(((Control)sender).Width / 2, 0);
        }

        private void EquControl_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void EquControl_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            //toolTip.SetToolTip(this.EquComboBox, "Equipments");
            //toolTip.SetToolTip(this.GroupsComboBox, "Groups");
        }

        #endregion

      
    }
}
