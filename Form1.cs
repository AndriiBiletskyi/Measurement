using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PomiaryGUI.Charts;
using Indicators;
using LiveCharts.WinForms;

namespace PomiaryGUI
{
    public interface IMainForm
    {
        #region events
        event EventHandler<ChartsParameters> ButShowChartsClick;
        event EventHandler<RaportsParameters> ButShowRaportsClick;
        event EventHandler ButCloseClick;
        event EventHandler<EquControlData> ButChartsEquipmentsClick;
        event EventHandler AplicationStart;
        event EventHandler ChangeConnect;
        event EventHandler ExecuteScript;
        event EventHandler<int> SettingsGetDataForID;
        event EventHandler<SettingsEquipmentsData> SettingsUpdateDataForID;
        event EventHandler<SettingsEquipmentsData> SettingsAddNewEquipmentToDB;
        event EventHandler ReplaceDDMM;
        #endregion

        void FormClose();
        List<List<string>> AllEquipmentsList { get; set; }

        #region Equipments
        List<string> EquList { get; set; }
        List<int> IdList { get; set; }
        void EquipmentsFill(DataTable dataTable);
        void UpdateLastDataForEquipments(EquControlData equControlData);
        #endregion

        #region Charts
        void ChartData(DataTable tb, object sender, string name);
        #endregion

        #region Raports
        void RaportsData(DataTable dataTable);
        DateTime RaportsGetDateFrom();
        DateTime RaportsGetDateTo();
        #endregion

        #region Settings
        List<string> SettingsGetDataConnection();
        string SettingsGetDataConnectionString();
        bool GetReplace();
        bool GetConnectionWay();
        void SettingsSetDataForID(SettingsEquipmentsData data);
        #endregion
    }

    public partial class MainForm : Form, IMainForm
    {
        #region Events

        #endregion

        #region Panels
        Charts Power = new Charts(ChartMode.power);      
        Charts Current = new Charts(ChartMode.current);
        Charts Voltage = new Charts(ChartMode.voltage);
        Charts Cos = new Charts(ChartMode.cos);
        EquControl PanelEqu = new EquControl();

        Raports PanelRaport = new Raports();

        SettingsConnection PanelSettingsConnection = new SettingsConnection();
        SettingsEquipments PanelSettingsEquipments = new SettingsEquipments();
        #endregion

        List<string> equList = new List<string>();
        List<int> idList = new List<int>();
        List<InstantaneousValues> inst = new List<InstantaneousValues>();
        int timeTick = 0;
        //MessagePanel messagePanel = new MessagePanel();
        
        public MainForm()
        {
            InitializeComponent();

            LangComboBox.Visible = false;
            panelLang.Visible = false;
            labelDataTime.Text = DateTime.Now.ToString();
            labelDataTime.Location = new Point(panelBottom.Width - labelDataTime.Width, 0);
            panelBottom.Height = labelDataTime.Height;
            panelBottom.Location = new Point(panelBottom.Location.X, this.Height - panelBottom.Height);

            #region Buttons events
            butCharts.Click += new EventHandler(ButCharts_Click);
            butChartsPower.Click += new EventHandler(But_Click);
            butChartsCurrent.Click += new EventHandler(But_Click);
            butChartsVoltage.Click += new EventHandler(But_Click);
            butChartsCos.Click += new EventHandler(But_Click);
            butChartsEquipments.Click += new EventHandler(ButChartsEquipments_Click);

            butRaports.Click += new EventHandler(ButRaports_Click);
            butRaportsHourly.Click += new EventHandler(But_Click);
            butRaportsDaily.Click += new EventHandler(But_Click);
            butRaportsWeekly.Click += new EventHandler(But_Click);
            butRaportsMonthly.Click += new EventHandler(But_Click);
            butRaportsAnnual.Click += new EventHandler(But_Click);

            butSettings.Click += new EventHandler(ButSettings_Click);
            butSettingsConnection.Click += new EventHandler(But_Click);
            butSettingsNetwork.Click += new EventHandler(But_Click);
            butSettingsEquipments.Click += new EventHandler(But_Click);
            #endregion

            LangComboBox.SelectedValueChanged += new EventHandler(LangComboBox_TextChanged);

            #region Charts events
            Power.ButtonShowClick += new EventHandler(ButtonShowChartsClick);
            Current.ButtonShowClick += new EventHandler(ButtonShowChartsClick);
            Voltage.ButtonShowClick += new EventHandler(ButtonShowChartsClick);
            Cos.ButtonShowClick += new EventHandler(ButtonShowChartsClick);
            #endregion

            #region Raports panel events
            PanelRaport.ButtonShowClick += new EventHandler(ButtonShowRaportsClick);
            #endregion

            #region Settings events
            PanelSettingsConnection.ButtonConnectClick += new EventHandler(Change_Connect);
            PanelSettingsConnection.ButtonExecuteScriptClick += new EventHandler(Execute_Script);
            PanelSettingsConnection.ReplaceDDMM += new EventHandler(Replace_DD_MM);
            PanelSettingsEquipments.IDChanged += new EventHandler<int>(SettingsEquipmentsIDChanged);
            PanelSettingsEquipments.UpdateData += new EventHandler<SettingsEquipmentsData>(SettingsEquipmentsUpdateData);
            PanelSettingsEquipments.AddNewEquipment += new EventHandler<SettingsEquipmentsData>(SettingsAddNewEquipment);
            #endregion

            //panelBottom.Controls.Add(messagePanel);
        }

        #region FormBL
        FormStates formStates = FormStates.start;

        #region Buttons
        private void MarkBottomBut(Point loc, Size size)
        {
            panelButtonMark.Location = new Point(loc.X, loc.Y + size.Height - panelButtonMark.Height);
            panelButtonMark.Width = size.Width;
            panelButtonMark.BringToFront();
        }

        private void HideButtonsCharts()
        {
            butChartsPower.Visible = false;
            butChartsCurrent.Visible = false;
            butChartsVoltage.Visible = false;
            butChartsCos.Visible = false;
            butChartsEquipments.Visible = false;
        }

        private void HideButtonsRaports()
        {
            butRaportsHourly.Visible = false;
            butRaportsDaily.Visible = false;
            butRaportsWeekly.Visible = false;
            butRaportsMonthly.Visible = false;
            butRaportsAnnual.Visible = false;
        }

        private void HideButtonsSettings()
        {
            butSettingsEquipments.Visible = false;
            butSettingsConnection.Visible = false;
            butSettingsNetwork.Visible = false;
        }

        private void ShowButtonsCharts()
        {
            butChartsPower.Visible = true;
            butChartsCurrent.Visible = true;
            butChartsVoltage.Visible = true;
            butChartsCos.Visible = true;
            butChartsEquipments.Visible = true;
        }

        private void ShowButtonsRaports()
        {
            butRaportsHourly.Visible = true;
            butRaportsDaily.Visible = true;
            butRaportsWeekly.Visible = true;
            butRaportsMonthly.Visible = true;
            butRaportsAnnual.Visible = true;
        }

        private void ShowButtonsSettings()
        {
            butSettingsEquipments.Visible = true;
            butSettingsConnection.Visible = true;
            butSettingsNetwork.Visible = true;
        }

        private void ButtonsRightPosition(Button butup, Button but)
        {
            but.Location = new Point(panelButtons.Width - but.Width, butup.Location.Y + butup.Height);
        }
        #endregion

        #region EquPanel

        private void _EquComboBoxTextChanged(object sender, EventArgs e)
        {
            //if (ButChartsEquipmentsClick != null) ButChartsEquipmentsClick(this, EventArgs.Empty);
        }

        private void _GroupsComboBoxTextChanged(object sender, EventArgs e)
        {
            //if (ButChartsEquipmentsClick != null) ButChartsEquipmentsClick(this, EventArgs.Empty);
        }

        private void EquPanelShow()
        {
            PanelEqu.Visible = true;
            PanelReSize(PanelEqu);

            PanelEqu.Refresh();

        }

        private void EquPanelHide()
        {
            PanelEqu.Visible = false;
        }

        #endregion

        #region Panel

        private void PanelShow(Control panel)
        {
            panel.Visible = true;
            PanelReSize(panel);
            panel.Refresh();
        }

        private void PanelReSize(Control panel)
        {
            panel.Size = new Size(this.Width - panelButtons.Width,
                                  this.Height - panelHead.Height - panelBottom.Height);
        }

        private void AllPanelsHide()
        {
            PanelEqu.Visible = false;
            Power.Visible = false;
            Current.Visible = false;
            Voltage.Visible = false;
            Cos.Visible = false;
            PanelSettingsConnection.Visible = false;
            PanelSettingsEquipments.Visible = false;
            PanelRaport.Visible = false;
        }

        #endregion

        #endregion

        #region EventForwarding
        private void ButtonShowChartsClick(object sender, EventArgs e)
        {
            var charparam = new ChartsParameters(((Charts)sender).GetEquSelected(),
                                                 ((Charts)sender).GetDateFrom(),
                                                 ((Charts)sender).GetDateTo(),
                                                 ((Charts)sender).GetCheckedLines());
            ButShowChartsClick?.Invoke(sender, charparam);
        }

        private void ButtonShowRaportsClick(object sender, EventArgs e)
        {
            var raportparam = new RaportsParameters(formStates, PanelRaport.GetDateFrom(), PanelRaport.GetDateTo());
            ButShowRaportsClick?.Invoke(sender, raportparam);
        }

        private void ButCharts_Click(object sender, EventArgs e)
        {
            if (butChartsPower.Visible)
            {
                HideButtonsCharts();
                HideButtonsRaports();
                HideButtonsSettings();
                ButtonsRightPosition(butCharts, butRaports);
                ButtonsRightPosition(butRaports, butSettings);
                MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }
            else
            {
                HideButtonsRaports();
                HideButtonsSettings();
                ShowButtonsCharts();
                ButtonsRightPosition(butCharts, butChartsPower);
                ButtonsRightPosition(butChartsPower, butChartsCurrent);
                ButtonsRightPosition(butChartsCurrent, butChartsVoltage);
                ButtonsRightPosition(butChartsVoltage, butChartsCos);
                ButtonsRightPosition(butChartsCos, butChartsEquipments);
                ButtonsRightPosition(butChartsEquipments, butRaports);
                ButtonsRightPosition(butRaports, butSettings);
                if (formStates == FormStates.power) MarkBottomBut(butChartsPower.Location, butChartsPower.Size);
                else if (formStates == FormStates.current) MarkBottomBut(butChartsCurrent.Location, butChartsCurrent.Size);
                else if (formStates == FormStates.voltage) MarkBottomBut(butChartsVoltage.Location, butChartsVoltage.Size);
                else if (formStates == FormStates.cos) MarkBottomBut(butChartsCos.Location, butChartsCos.Size);
                else if (formStates == FormStates.equipments) MarkBottomBut(butChartsEquipments.Location, butChartsEquipments.Size);
                else MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "butChartsPower":
                    if(formStates != FormStates.power)
                    {
                        AllPanelsHide();
                        formStates = FormStates.power;
                        PanelShow(Power);
                    }
                    break;
                case "butChartsCurrent":
                    if (formStates != FormStates.current)
                    {
                        AllPanelsHide();
                        formStates = FormStates.current;
                        PanelShow(Current);
                    }
                    break;
                case "butChartsVoltage":
                    if (formStates != FormStates.voltage)
                    {
                        AllPanelsHide();
                        formStates = FormStates.voltage;
                        PanelShow(Voltage);
                    }
                    break;
                case "butChartsCos":
                    if (formStates != FormStates.cos)
                    {
                        AllPanelsHide();
                        formStates = FormStates.cos;
                        PanelShow(Cos);
                    }
                    break;
                case "butRaportsHourly":
                    if (formStates != FormStates.hourly)
                    {
                        AllPanelsHide();
                        formStates = FormStates.hourly;
                        PanelShow(PanelRaport);
                    }
                    break;
                case "butRaportsDaily":
                    if (formStates != FormStates.daily)
                    {
                        AllPanelsHide();
                        formStates = FormStates.daily;
                        PanelShow(PanelRaport);
                    }
                    break;
                case "butRaportsWeekly":
                    if (formStates != FormStates.weekly)
                    {
                        AllPanelsHide();
                        formStates = FormStates.weekly;
                        PanelShow(PanelRaport);
                    }
                    break;
                case "butRaportsMonthly":
                    if (formStates != FormStates.monthly)
                    {
                        AllPanelsHide();
                        formStates = FormStates.monthly;
                        PanelShow(PanelRaport);
                    }
                    break;
                case "butRaportsAnnual":
                    if (formStates != FormStates.annual)
                    {
                        AllPanelsHide();
                        formStates = FormStates.annual;
                        PanelShow(PanelRaport);
                    }
                    break;
                case "butSettingsEquipments":
                    if (formStates != FormStates.setequipments)
                    {
                        AllPanelsHide();
                        formStates = FormStates.setequipments;
                        PanelShow(PanelSettingsEquipments);
                    }
                    break;
                case "butSettingsConnection":
                    if (formStates != FormStates.connection)
                    {
                        AllPanelsHide();
                        formStates = FormStates.connection;
                        PanelShow(PanelSettingsConnection);
                    }
                    break;
                case "butSettingsNetwork":
                    if (formStates != FormStates.network)
                    {
                        AllPanelsHide();
                        formStates = FormStates.network;
                        //PanelShow(PanelRaport);
                    }
                    break;
            }
            MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
        }

        private void ButChartsEquipments_Click(object sender, EventArgs e)
        {
            if (formStates != FormStates.equipments)
            {
                AllPanelsHide();
                EquPanelShow();
                formStates = FormStates.equipments;
            }
            MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            var eqControl = new EquControlData();
            eqControl.eqNumbers = idList;
            ButChartsEquipmentsClick?.Invoke(sender, eqControl);
        }

        private void ButRaports_Click(object sender, EventArgs e)
        {
            if (butRaportsDaily.Visible)
            {
                HideButtonsCharts();
                HideButtonsRaports();
                HideButtonsSettings();
                ButtonsRightPosition(butCharts, butRaports);
                ButtonsRightPosition(butRaports, butSettings);
                MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }
            else
            {
                HideButtonsCharts();
                HideButtonsSettings();
                ShowButtonsRaports();
                ButtonsRightPosition(butCharts, butRaports);
                ButtonsRightPosition(butRaports, butRaportsHourly);
                ButtonsRightPosition(butRaportsHourly, butRaportsDaily);
                ButtonsRightPosition(butRaportsDaily, butRaportsWeekly);
                ButtonsRightPosition(butRaportsWeekly, butRaportsMonthly);
                ButtonsRightPosition(butRaportsMonthly, butRaportsAnnual);
                ButtonsRightPosition(butRaportsAnnual, butSettings);
                if (formStates == FormStates.hourly) MarkBottomBut(butRaportsHourly.Location, butRaportsHourly.Size);
                else if (formStates == FormStates.daily) MarkBottomBut(butRaportsDaily.Location, butRaportsDaily.Size);
                else if (formStates == FormStates.weekly) MarkBottomBut(butRaportsWeekly.Location, butRaportsWeekly.Size);
                else if (formStates == FormStates.monthly) MarkBottomBut(butRaportsMonthly.Location, butRaportsMonthly.Size);
                else if (formStates == FormStates.annual) MarkBottomBut(butRaportsAnnual.Location, butRaportsAnnual.Size);
                else MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }
        }

        private void ButSettings_Click(object sender, EventArgs e)
        {
            if (butSettingsEquipments.Visible)
            {
                HideButtonsCharts();
                HideButtonsRaports();
                HideButtonsSettings();
                ButtonsRightPosition(butCharts, butRaports);
                ButtonsRightPosition(butRaports, butSettings);
                MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }
            else
            {
                HideButtonsCharts();
                HideButtonsRaports();
                ShowButtonsSettings();
                ButtonsRightPosition(butCharts, butRaports);
                ButtonsRightPosition(butRaports, butSettings);
                ButtonsRightPosition(butSettings, butSettingsEquipments);
                ButtonsRightPosition(butSettingsEquipments, butSettingsConnection);
                ButtonsRightPosition(butSettingsConnection, butSettingsNetwork);

                if (formStates == FormStates.setequipments) MarkBottomBut(butSettingsEquipments.Location, butSettingsEquipments.Size);
                else if (formStates == FormStates.connection) MarkBottomBut(butSettingsConnection.Location, butSettingsConnection.Size);
                else if (formStates == FormStates.network) MarkBottomBut(butSettingsNetwork.Location, butSettingsNetwork.Size);
                else MarkBottomBut(((Button)sender).Location, ((Button)sender).Size);
            }


            //if (formStates != FormStates.settings)
            //{
            //    AllPanelsHide();
            //    SettingsPanelShow();
            //    formStates = FormStates.settings;
            //}

            
        }

        private void ButClose_Click(object sender, EventArgs e)
        {
            ButCloseClick?.Invoke(sender, EventArgs.Empty);
        }

        private void LangComboBox_TextChanged(object sender, EventArgs e)
        {
            //if (LangComboBoxTextChanged != null) LangComboBoxTextChanged(this, EventArgs.Empty);
            if (LangComboBox.Text == "EN") panelLang.BackgroundImage = Properties.Resources.GB;
            if (LangComboBox.Text == "PL") panelLang.BackgroundImage = Properties.Resources.PL;
            if (LangComboBox.Text == "DE") panelLang.BackgroundImage = Properties.Resources.DE;
            if (LangComboBox.Text == "UA") panelLang.BackgroundImage = Properties.Resources.UA;
            if (LangComboBox.Text == "ES") panelLang.BackgroundImage = Properties.Resources.ES;
            if (LangComboBox.Text == "HU") panelLang.BackgroundImage = Properties.Resources.HU;
        }

        private void Change_Connect(object sender, EventArgs e)
        {
            ChangeConnect?.Invoke(sender, EventArgs.Empty);
        }

        private void Execute_Script(object sender, EventArgs e)
        {
            ExecuteScript?.Invoke(sender, EventArgs.Empty);
        }

        private void Replace_DD_MM(object sender, EventArgs e)
        {
            ReplaceDDMM?.Invoke(sender, EventArgs.Empty);
        }

        private void SettingsEquipmentsIDChanged(object sender, int id)
        {
            SettingsGetDataForID?.Invoke(sender, id);
        }

        private void SettingsEquipmentsUpdateData(object sender, SettingsEquipmentsData data)
        {
            SettingsUpdateDataForID?.Invoke(sender, data);
        }

        private void SettingsAddNewEquipment(object sender, SettingsEquipmentsData data)
        {
            SettingsAddNewEquipmentToDB?.Invoke(sender, data);
        }
        #endregion

        #region IMainForm

        public List<List<string>> AllEquipmentsList
        {
            get
            {
                return AllEquipmentsList;
            }

            set
            {
                AllEquipmentsList = value;
            }
        }

        public void EquipmentsFill(DataTable dataTable)
        {
            try
            {
                if (dataTable != null &&
                    dataTable.Columns.Contains("Nazwa_urzadzenia") &&
                    dataTable.Columns.Contains("Status") &&
                    dataTable.Columns.Contains("P") &&
                    dataTable.Columns.Contains("P_L1") &&
                    dataTable.Columns.Contains("P_L2") &&
                    dataTable.Columns.Contains("P_L3"))
                {
                    Point p = new Point(((PanelEqu.Width / 4) - 200) / 2, 40);
                    int step = PanelEqu.Width / 4;
                    int q = 0;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!dataTable.Rows[i].IsNull("Nazwa_urzadzenia") &&
                            !dataTable.Rows[i].IsNull("Status") &&
                            !dataTable.Rows[i].IsNull("P") &&
                            !dataTable.Rows[i].IsNull("P_L1") &&
                            !dataTable.Rows[i].IsNull("P_L2") &&
                            !dataTable.Rows[i].IsNull("P_L3"))
                        {
                            for (int r = 0; r < 4; r++)
                            {
                                string quer = "";
                                if (r == 0) quer = "P";
                                else if (r == 1) quer = "P_L1";
                                else if (r == 2) quer = "P_L2";
                                else if (r == 3) quer = "P_L3";

                                if (inst.Count >= (q + 1))
                                {
                                    inst.ElementAt(q).Status = Convert.ToBoolean(dataTable.Rows[i]["Status"]);
                                    inst.ElementAt(q).Name = Convert.ToString(dataTable.Rows[i]["Nazwa_urzadzenia"]) + " - " + quer + ", kW";
                                    if (inst.ElementAt(q).Status == false)
                                    {
                                        inst.ElementAt(q).Value = 0;
                                    }
                                    else if (!dataTable.Rows[i].IsNull(quer))
                                    {
                                        inst.ElementAt(q).Value = Convert.ToSingle(dataTable.Rows[i][quer]) / 1000;
                                    }
                                    else inst.ElementAt(q).Value = 0;

                                    inst.ElementAt(q).Max = 100;
                                    inst.ElementAt(q).Min = 0;
                                    if (!inst.ElementAt(q).Visible)
                                    {
                                        inst.ElementAt(q).Size = new Size(200, 200);
                                        inst.ElementAt(q).Location = new Point(p.X + step * (q % 4), p.Y + 220 * (q / 4));
                                        inst.ElementAt(q).Visible = true;
                                    }
                                }
                                q++;
                            }
                        }
                        else
                        {
                            for (int r = 0; r < 4; r++)
                            {
                                string quer = "";
                                if (r == 0) quer = "P";
                                else if (r == 1) quer = "P_L1";
                                else if (r == 2) quer = "P_L2";
                                else if (r == 3) quer = "P_L3";

                                if (inst.Count >= (q + 1))
                                {
                                    inst.ElementAt(q).Status = false;
                                    inst.ElementAt(q).Name = "Unknow" + " - " + quer + ", kW";
                                    inst.ElementAt(q).Value = 0;
                                    inst.ElementAt(q).Max = 100;
                                    inst.ElementAt(q).Min = 0;
                                    if (!inst.ElementAt(q).Visible)
                                    {
                                        inst.ElementAt(q).Size = new Size(200, 200);
                                        inst.ElementAt(q).Location = new Point(p.X + step * (q % 4), p.Y + 220 * (q / 4));
                                        inst.ElementAt(q).Visible = true;
                                    }
                                }
                                q++;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form_EquFill \n" + ex.ToString());
            }
        }

        public void UpdateLastDataForEquipments(EquControlData equControlData)
        {
            try
            {
                int dif = inst.Count - equControlData.eqNumbers.Count * 4;
                for (int l = 0; l < dif; l++)
                {
                    PanelEqu.Controls.RemoveAt(PanelEqu.Controls.IndexOf(inst.Last()));
                    inst.RemoveAt(inst.Count - 1);
                }

                dif = equControlData.eqNumbers.Count * 4 - inst.Count;
                for (int l = 0; l < dif; l++)
                { 
                    inst.Add(new InstantaneousValues());
                    inst.Last().Visible = false;
                    PanelEqu.Controls.Add(inst.Last());
                }

                int i = 0;
                int side = 250;
                int margin = 20;
                int step = PanelEqu.Width / 4;
                if (step <= side) side = step - margin;
                Point p = new Point(((PanelEqu.Width / 4) - side) / 2, margin);
                foreach (var eq in equControlData.eqData.Keys)
                {
                    foreach(var chart in equControlData.eqData[eq])
                    {
                        inst.ElementAt(i).Name = chart.Key;
                        inst.ElementAt(i).Value = chart.Value;
                        inst.ElementAt(i).Min = equControlData.eqParameters[eq].minValue;
                        inst.ElementAt(i).Max = equControlData.eqParameters[eq].maxValue;
                        inst.ElementAt(i).Status = equControlData.eqParameters[eq].state;
                        if (!inst.ElementAt(i).Visible)
                        {
                            inst.ElementAt(i).Size = new Size(side, side);
                            inst.ElementAt(i).Location = new Point(p.X + step * (i % 4), p.Y + (side + margin) * (i / 4));
                            inst.ElementAt(i).Visible = true;
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<string> EquList
        {
            get
            {
                return equList;
            }
            set
            {
                equList = value;
                Power.EquList = value;
                Voltage.EquList = value;
                Current.EquList = value;
                Cos.EquList = value;
            }
        }

        public List<int> IdList
        {
            get
            {
                return idList;
            }
            set
            {
                idList = value;
                PanelSettingsEquipments.SetEquList(value);
            }
        }

        public void FormClose()
        {
            MainForm.ActiveForm.Close();
        }

        #region Charts
        public void ChartData(DataTable tb, object sender, string name)
        {
            new Thread(() =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    ((Charts)sender).SetDataChart(tb, name);
                }));
            }).Start();
        }
        #endregion
        #region Raports
        public void RaportsData(DataTable dataTable)
        {
            PanelRaport.SetData(dataTable);
        }

        public DateTime RaportsGetDateFrom()
        {
            return PanelRaport.GetDateFrom();
        }

        public DateTime RaportsGetDateTo()
        {
            return PanelRaport.GetDateTo();
        }
        #endregion
        #region Settings
        public List<string> SettingsGetDataConnection()
        {
            return PanelSettingsConnection.GetDataConnection();
        }

        public string SettingsGetDataConnectionString()
        {
            return PanelSettingsConnection.GetDataConnectionString();
        }

        public bool GetReplace()
        {
            return PanelSettingsConnection.GetReplace();
        }

        public bool GetConnectionWay()
        {
            return PanelSettingsConnection.GetConnectionWay();
        }

        public void SettingsSetDataForID(SettingsEquipmentsData data)
        {
            PanelSettingsEquipments.SetDataForID(data);
        }
        #endregion
        #region events
        public event EventHandler<ChartsParameters> ButShowChartsClick;
        public event EventHandler<RaportsParameters> ButShowRaportsClick;
        public event EventHandler ButCloseClick;
        public event EventHandler<EquControlData> ButChartsEquipmentsClick;
        public event EventHandler AplicationStart;

        //public event EventHandler LangComboBoxTextChanged;

        public event EventHandler<int> SettingsGetDataForID;
        public event EventHandler<SettingsEquipmentsData> SettingsUpdateDataForID;
        public event EventHandler<SettingsEquipmentsData> SettingsAddNewEquipmentToDB;

        public event EventHandler ChangeConnect;
        public event EventHandler ExecuteScript;
        public event EventHandler ReplaceDDMM;
        #endregion
        #endregion

        #region FormAction

        private void ButMin_Click(object sender, EventArgs e)
        {
            MainForm.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void PanelHead_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Drawing.Rectangle rect = Screen.GetWorkingArea(this);
            if (this.MaximizedBounds != Screen.GetWorkingArea(this))
            {
                this.MaximizedBounds = Screen.GetWorkingArea(this);
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Maximized;
                MainForm.ActiveForm.Refresh();
            }
        }

        private void TimerDataTime_Tick(object sender, EventArgs e)
        {
            labelDataTime.Text = DateTime.Now.ToString();

            if (timeTick % 10 == 0)
            {
                if (formStates == FormStates.equipments)
                {
                    var eqControl = new EquControlData();
                    eqControl.eqNumbers = idList;
                    ButChartsEquipmentsClick?.Invoke(sender, eqControl);
                }
            }

            timeTick++;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //_init = true;

            #region PanelEqu
            this.Controls.Add(PanelEqu);
            this.PanelEqu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            PanelEqu.Visible = false;
            PanelEqu.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(PanelEqu);
            #endregion
            #region PanelPower
            Power.Visible = false;
            this.Controls.Add(Power);
            this.Power.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            Power.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(Power);
            #endregion
            #region PanelCurrent
            Current.Visible = false;
            this.Controls.Add(Current);
            this.Current.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            Current.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(Current);
            #endregion
            #region PanelVoltage
            Voltage.Visible = false;
            this.Controls.Add(Voltage);
            this.Voltage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            Voltage.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(Voltage);
            #endregion
            #region PanelCos
            Cos.Visible = false;
            this.Controls.Add(Cos);
            this.Cos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            Cos.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(Cos);
            #endregion
            #region PanelRaports
            PanelRaport.Visible = false;
            this.Controls.Add(PanelRaport);
            this.PanelRaport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            PanelRaport.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(PanelRaport);
            #endregion
            #region PanelSettingsConnection
            PanelSettingsConnection.Visible = false;
            this.Controls.Add(PanelSettingsConnection);
            this.PanelSettingsConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            PanelSettingsConnection.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(PanelSettingsConnection);
            #endregion
            #region PanelSettingsEquipments
            PanelSettingsEquipments.Visible = false;
            this.Controls.Add(PanelSettingsEquipments);
            this.PanelSettingsEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            PanelSettingsEquipments.Location = new Point(panelButtons.Width, panelHead.Height);
            PanelReSize(PanelSettingsEquipments);
            #endregion

            LangComboBox.SelectedItem = LangComboBox.Items[0];

            MainFormInit();

            HideButtonsCharts();
            HideButtonsRaports();
            HideButtonsSettings();
            ButtonsRightPosition(butCharts, butRaports);
            ButtonsRightPosition(butRaports, butSettings);

            labelDataTime.Location = new Point(panelBottom.Width - labelDataTime.Width,0);

            PanelHead_MouseDoubleClick(this, new MouseEventArgs(new MouseButtons(),0,0,0,0));
        }

        private void MainFormInit()
        {
            AplicationStart?.Invoke(this, EventArgs.Empty);
            panelButtons.Visible = true;
        }
        #endregion

        #region MainFormDragging
        private bool isDragging = false;
        private int x, y;
        private void panelHead_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            x = e.X;
            y = e.Y;
        }

        private void panelHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                MainForm.ActiveForm.Location = new Point(MainForm.ActiveForm.Location.X + e.X - x,
                                                         MainForm.ActiveForm.Location.Y + e.Y - y);
            }
        }

        private void panelHead_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        #endregion
   
    }
}
