using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Linq;

//-----------------------------------------------------------------------------------
//  P1    
//  P2
//  P3
//  P
//
//  Q1
//  Q2
//  Q3
//  Q
//
//  U1
//  U2
//  U3
//  
//  I1
//  I2
//  I3
//
//  cosp
//
//  P_day
//  Q_day
//
//  
//
//-----------------------------------------------------------------------------------

namespace PomiaryGUI
{
    public class Presenter
    {
        private readonly IMainForm _mainForm;
        private readonly IDataManager _dataManager;

        private List<int> equID = new List<int>();
        private List<string> equName = new List<string>();
        private Dictionary<int, string> equIDName = new Dictionary<int, string>();
        private Dictionary<int, (float minValue, float maxValue, EquipmentType type)> equParameters = new Dictionary<int, (float minValue, float maxValue, EquipmentType type)>();

        public Presenter(IMainForm mainForm, IDataManager dataManager)
        {
            _mainForm = mainForm;
            _dataManager = dataManager;

            _mainForm.ButCloseClick += new EventHandler(MainFormButCloseClick);

            _mainForm.ButChartsEquipmentsClick += new EventHandler<EquControlData>(MainFormButEquClick);

            _mainForm.ChangeConnect += new EventHandler(MainFormChangeConnect);
            _mainForm.ExecuteScript += new EventHandler(MainFormExecuteScript);
            _mainForm.ReplaceDDMM += new EventHandler(MainFormReplaceDDMM);
            _mainForm.ButShowChartsClick += new EventHandler<ChartsParameters>(MainFormButShowChartsClick);
            _mainForm.ButShowRaportsClick += new EventHandler<RaportsParameters>(MainFormButShowRaportsClick);
            _mainForm.SettingsGetDataForID += new EventHandler<int>(MainFormSettingsGetDataForID);
            _mainForm.SettingsUpdateDataForID += new EventHandler<SettingsEquipmentsData>(MainFormSettingsUpdateDataForID);
            _mainForm.SettingsAddNewEquipmentToDB += new EventHandler<SettingsEquipmentsData>(MainFormSettingsAddNewEquipment);

            _mainForm.AplicationStart += new EventHandler(MainFormGetEquList);

            _dataManager.Message += new EventHandler<string>(DataManagerMessage);

            MainFormChangeConnect(null, null);
        }

        private void DataManagerMessage(object sender, string e)
        {
            MessageBox.Show(e);
        }

        private void MainFormGetEquList(object sender, EventArgs e)
        {
            DataTable equTable = _dataManager.GetEquList();
            equID.Clear();
            equIDName.Clear();
            equName.Clear();
            equParameters.Clear();
            equID = equTable.AsEnumerable().Where(x => x.Field<object>("ID") != DBNull.Value).Select(x => (int)x["ID"]).ToList();

            foreach (var i in equID)
            {
                string name = equTable.AsEnumerable().Where(x => x.Field<int>("ID") == i).Select(x => x["NamePL"].ToString()).First();
                equName.Add(name);
                equIDName.Add(i, name);

                float minVal = 0;
                float maxVal = Convert.ToSingle(equTable.AsEnumerable().Where(x => x.Field<int>("ID") == i).Select(x => x["RatedPower"]).First());
                string type = Convert.ToString(equTable.AsEnumerable().Where(x => x.Field<int>("ID") == i).Select(x => x["Type"]).First());
                EquipmentType eqType;
                if (type == EquipmentType.Electricity.ToString()) eqType = EquipmentType.Electricity;
                else if(type == EquipmentType.Air.ToString()) eqType = EquipmentType.Air;
                else eqType = EquipmentType.Unknow;
                equParameters.Add(i, (minVal, maxVal, eqType));
            }
            _mainForm.EquList = equName;
            _mainForm.IdList = equID;
            equTable.Dispose();
        }

        private void MainFormButEquClick(object sender, EquControlData e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("ID",        typeof(int));
                dt.Columns.Add("Nazwa_urzadzenia", typeof(string));
                dt.Columns.Add("Status",    typeof(bool));
                dt.Columns.Add("P",         typeof(float));
                dt.Columns.Add("P_L1",      typeof(float));
                dt.Columns.Add("P_L2",      typeof(float));
                dt.Columns.Add("P_L3",      typeof(float));

                _dataManager.GetLastEquData(e.eqNumbers, ref dt);

                //_mainForm.EquipmentsFill(dt);//1635 ms

                var lastDataForAllEquipments = new EquControlData();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    bool state = dt.Rows[i]["Status"] != DBNull.Value ? (bool)dt.Rows[i]["Status"] : false;
                    lastDataForAllEquipments.eqNumbers.Add(id);
                    lastDataForAllEquipments.eqParameters.Add(id,
                                                             (equIDName[id],
                                                              equParameters[id].minValue,
                                                              equParameters[id].maxValue,
                                                              equParameters[id].type,
                                                              state)
                                                              );

                    var temp = new Dictionary<string, float>();
                    object oP = dt.Rows[i]["P"];
                    double fP = oP == DBNull.Value ? 0.0f : Math.Round(Convert.ToSingle(oP)/1000, 2);
                    string name = equIDName[id] + " - ";
                    temp.Add(name + "P" + ", kW", (float)fP);

                    oP = dt.Rows[i]["P_L1"];
                    fP = oP == DBNull.Value ? 0.0f : Math.Round(Convert.ToSingle(oP) / 1000, 2);
                    temp.Add(name + "P_L1" + ", kW", (float)fP);

                    oP = dt.Rows[i]["P_L2"];
                    fP = oP == DBNull.Value ? 0.0f : Math.Round(Convert.ToSingle(oP) / 1000, 2);
                    temp.Add(name + "P_L2" + ", kW", (float)fP);

                    oP = dt.Rows[i]["P_L3"];
                    fP = oP == DBNull.Value ? 0.0f : Math.Round(Convert.ToSingle(oP) / 1000, 2);
                    temp.Add(name + "P_L3" + ", kW", (float)fP);

                    lastDataForAllEquipments.eqData.Add(id, temp);
                }
                _mainForm.UpdateLastDataForEquipments(lastDataForAllEquipments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dt.Dispose();
            }
        }

        private void MainFormButCloseClick(object sender, EventArgs e)
        {
            _dataManager.SqlConnectionClose();
            _mainForm.FormClose();
        }

        private async void MainFormButShowChartsClick(object sender, ChartsParameters e)
        {
            DataTable dataTable = new DataTable();
            await Task.Run(() =>
            {
                int temp = equIDName.ContainsValue(e.EquName) ? equIDName.First(x => x.Value == e.EquName).Key : 0;
                dataTable = _dataManager.GetDataPower(temp, e.DateFrom, e.DateTo, e.Lines);
            });
            _mainForm.ChartData(dataTable, sender, e.EquName);
        }

        private void MainFormButShowRaportsClick(object sender, RaportsParameters e)
        {
            switch (e.FormState)
            {
                case FormStates.hourly:
                    RaportData(Raport.hour, e.DateFrom, e.DateTo);
                    break;
                case FormStates.daily:
                    RaportData(Raport.day, e.DateFrom, e.DateTo);
                    break;
                case FormStates.weekly:
                    RaportData(Raport.week, e.DateFrom, e.DateTo);
                    break;
                case FormStates.monthly:
                    RaportData(Raport.month, e.DateFrom, e.DateTo);
                    break;
                case FormStates.annual:
                    RaportData(Raport.year, e.DateFrom, e.DateTo);
                    break;
            }
        }

        private void MainFormChangeConnect(object sender, EventArgs e)
        {
            if (_mainForm.GetConnectionWay())
            {
                _dataManager.SetConnection(_mainForm.SettingsGetDataConnectionString());
            }
            else
            {
                _dataManager.SetConnection(_mainForm.SettingsGetDataConnection());
            }
            MainFormGetEquList(sender, e);
        }

        private void MainFormExecuteScript(object sender, EventArgs e)
        {
            _dataManager.ExecuteScript();
        }

        private void MainFormSettingsGetDataForID(object sender, int id)
        {
            var data = new SettingsEquipmentsData();
            if (id > 0 && id < 256)
            {
                try
                {
                    var tempTable = _dataManager.GetEquList();

                    data.Id = id;

                    object o_namePL = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["NamePL"].ToString()).First();
                    data.NamePL = o_namePL != DBNull.Value ? Convert.ToString(o_namePL) : "";

                    object o_nameEN = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["NameEN"].ToString()).First();
                    data.NameEN = o_nameEN != DBNull.Value ? Convert.ToString(o_nameEN) : "";

                    object o_ratedPower = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["RatedPower"]).First();
                    data.RatedPower = o_ratedPower != DBNull.Value ? Convert.ToSingle(o_ratedPower) : 0;

                    object o_ratedCurrent = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["RatedCurrent"]).First();
                    data.RatedCurrent = o_ratedCurrent != DBNull.Value ? Convert.ToSingle(o_ratedCurrent) : 0;

                    object o_ratedVoltage = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["RatedVoltage"]).First();
                    data.RatedVoltage = o_ratedVoltage != DBNull.Value ? Convert.ToSingle(o_ratedVoltage) : 0;

                    object o_numberOfPhases = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["NumberOfPhases"]).First();
                    data.NumberOfPhases = o_numberOfPhases != DBNull.Value ? Convert.ToInt32(o_numberOfPhases) : 0;

                    object o_unitOfPower = tempTable.AsEnumerable().Where(x => x.Field<int>("ID") == id).Select(x => x["UnitOfPower"].ToString()).First();
                    data.UnitOfPower = o_unitOfPower != DBNull.Value ? Convert.ToString(o_unitOfPower) : "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }           
            _mainForm.SettingsSetDataForID(data);
        }

        private void MainFormSettingsUpdateDataForID(object sender, SettingsEquipmentsData data)
        {
            _dataManager.UpdateDataForID(data);
            MainFormGetEquList(sender, null);
        }

        private void MainFormSettingsAddNewEquipment(object sender, SettingsEquipmentsData data)
        {
            if (equID.Contains(data.Id))
            {
                MessageBox.Show("Equipnemt with number = " + data.Id.ToString() + " is exist");
                return;
            }
            _dataManager.AddNewEquipment(data);
            MainFormGetEquList(sender, null);
        }

        private void MainFormReplaceDDMM(object sender, EventArgs e)
        {
            _dataManager.DD_MM(_mainForm.GetReplace());
        }

        private async void RaportData(Raport step, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var dataRaports = new DataTable();
            dataRaports.Columns.Add("Day/Time", typeof(string));

            try
            {
                await Task.Run(() =>
                {
                    dataRaports = _dataManager.GetConsumption(equIDName, dateTimeFrom, dateTimeTo, step);
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _mainForm.RaportsData(dataRaports);
            }
        }
    }
}


//private async void Raport_data(Raport step, DateTime dateTimeFrom, DateTime dateTimeTo)
//{
//    DataTable dataRaports = new DataTable();
//    dataRaports.Columns.Add("Day/Time", typeof(string));
//    try
//    {
//        if (dateTimeFrom > dateTimeTo) dateTimeFrom = dateTimeTo;
//        List<DateTime> timeList = new List<DateTime>();
//        List<List<float>> PQ_List = new List<List<float>>();
//        await Task.Run(() =>
//        {
//            int ind = 1;
//            foreach (var eq in equName)
//            {
//                string s = eq;
//                if (string.IsNullOrWhiteSpace(eq)){ s = "Unknow" + ind.ToString(); ind++; }
//                dataRaports.Columns.Add(s + ", P", typeof(float));
//                dataRaports.Columns.Add(s + ", Q", typeof(float));
//            }

//            //Int32 rezultCount = _dataManager.GetRezultCount(equList.AsEnumerable().Select(x => x.Field<int>("ID")).ToList(),
//            //                                                    dateTimeFrom, dateTimeTo);
//            DateTime dateTime = new DateTime();
//            if (step == Raport.day)
//            {
//                dateTime = dateTimeFrom.AddHours(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 7) dateTimeTo = dateTimeFrom.AddDays(7.0);
//            }
//            else if (step == Raport.week)
//            {
//                dateTime = dateTimeFrom.AddDays(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 7 * 4) dateTimeTo = dateTimeFrom.AddDays(7.0 * 4);
//            }
//            else if (step == Raport.month)
//            {
//                dateTime = dateTimeFrom.AddDays(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 31 * 4) dateTimeTo = dateTimeFrom.AddDays(31 * 4);
//            }
//            else if (step == Raport.year)
//            {
//                dateTime = dateTimeFrom.AddMonths(1);
//            }

//            timeList.Add(dateTimeFrom);

//            while (dateTime < dateTimeTo)
//            {
//                timeList.Add(dateTime);
//                if (step == Raport.day) dateTime = dateTime.AddHours(1.0);
//                else if (step == Raport.week) dateTime = dateTime.AddDays(1.0);
//                else if (step == Raport.month) dateTime = dateTime.AddDays(1.0);
//                else if (step == Raport.year) dateTime = dateTime.AddMonths(1);
//            }
//            timeList.Add(dateTimeTo);
//            for(int i = 0; i < timeList.Count - 1; i++) 
//            {
//                DataRow row = dataRaports.NewRow();
//                if (i == (timeList.Count - 2)) row[0] = timeList[i].ToString() + System.Environment.NewLine + timeList[i + 1].ToString();
//                else row[0] = timeList[i].ToString() + System.Environment.NewLine + timeList[i + 1].AddSeconds(-1.0).ToString();

//                dataRaports.Rows.Add(row);
//            }

//            Dictionary<int,List<float>> PQ = new Dictionary<int, List<float>>();

//            equID.ForEach(i =>
//            {
//                PQ.Add(i, new List<float>());
//            });

//            equID.AsParallel().ForAll(i =>
//            //equID.ForEach(i=>
//            {
//                List<float> L = new List<float>();
//                for (int r = 0; r < timeList.Count - 1; r++)
//                {
//                    float P_day = 0;
//                    float Q_day = 0;
//                    if (r == (timeList.Count - 2))
//                    {
//                        _dataManager.GetFirstLastData(i, timeList[r], timeList[r + 1], ref P_day, ref Q_day);
//                    }
//                    else
//                    {
//                        _dataManager.GetFirstLastData(i, timeList[r], timeList[r + 1].AddSeconds(-1.0), ref P_day, ref Q_day);
//                    }
//                    PQ[i].Add(P_day);
//                    PQ[i].Add(Q_day);
//                }
//            });
//            int q = 0;
//            foreach (int pq in PQ.Keys)
//            {
//                int r = 0;
//                for (int i = 0; i < PQ[pq].Count;i+=2)
//                {
//                    dataRaports.Rows[r][q * 2 + 1] = PQ[pq][i];
//                    dataRaports.Rows[r][q * 2 + 2] = PQ[pq][i+1];
//                    r++;
//                }                        
//                q++;
//            }
//            DataRow lastrow = dataRaports.NewRow();
//            lastrow[0] = "Total";// dateTimeFrom.ToString() + System.Environment.NewLine + dateTimeTo.ToString();
//            for (int i = 1; i < dataRaports.Columns.Count; i++)
//            {
//                lastrow[i] = (float)Math.Round(dataRaports.AsEnumerable().Sum(x => (float)x[i]), 2);
//            }
//            dataRaports.Rows.Add(lastrow);
//        });

//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.ToString());
//    }
//    finally
//    {
//        _mainForm.RaportsData(dataRaports);
//        dataRaports = null;
//    }
//}

//private async void RaportData1(Raport step, DateTime dateTimeFrom, DateTime dateTimeTo)
//{
//    try
//    {
//        DataTable dataTable = _dataManager.GetEquData(1, new DateTime(1800, 1, 1, 1, 1, 1),
//                                                         new DateTime(1800, 1, 1, 1, 1, 1));
//        if (!dataTable.Columns.Contains("Nazwa_urzadzenia")) return;
//        DataTable dataRaports = new DataTable();
//        dataRaports.Columns.Add("Time/Day", typeof(string));
//        //DateTime dateTimeFrom = _mainForm.RaportsGetDateFrom();
//        //DateTime dateTimeTo = _mainForm.RaportsGetDateTo();
//        List<DateTime> time_day = new List<DateTime>();
//        List<List<float>> PQ_List = new List<List<float>>();
//        /*  Equ     P,Q(dateTimeFrom)   P,Q(dateTimeFrom + 1.0).... P,Q(dateTimeTo)       
//         *  0       P,Q                 P,Q                         P,Q
//         *  1       ...                 ...                         ...
//         *  ...     ...                 ...                         ...
//         *  n       ...                 ...                         ...
//         */

//        await Task.Run(() =>
//        {
//            DataRow dataRow = dataTable.NewRow();
//            for (int i = 1; i < 13; i++)//2000
//            {
//                dataRow = _dataManager.GetLastEquData(i);
//                if (dataRow.Table.Columns.Contains("Nazwa_urzadzenia"))
//                {
//                    dataRaports.Columns.Add(Convert.ToString(dataRow["Nazwa_urzadzenia"]) + ", P", typeof(float));
//                    dataRaports.Columns.Add(Convert.ToString(dataRow["Nazwa_urzadzenia"]) + ", Q", typeof(float));
//                }
//                else
//                {
//                    dataRaports.Columns.Add("Unknow " + i.ToString() + ", P", typeof(float));
//                    dataRaports.Columns.Add("Unknow " + i.ToString() + ", Q", typeof(float));
//                }
//            }
//            dataRow = null;

//            if (dateTimeTo <= dateTimeFrom) return;
//            DateTime dateTime = new DateTime();
//            if (step == Raport.day)
//            {
//                dateTime = dateTimeFrom.AddHours(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 7) dateTimeTo = dateTimeFrom.AddDays(7.0);
//            }
//            else if (step == Raport.week)
//            {
//                dateTime = dateTimeFrom.AddDays(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 7 * 4) dateTimeTo = dateTimeFrom.AddDays(7.0 * 4);
//            }
//            else if (step == Raport.month)
//            {
//                dateTime = dateTimeFrom.AddDays(1.0);
//                if ((dateTimeTo - dateTimeFrom).TotalDays > 31 * 4) dateTimeTo = dateTimeFrom.AddDays(31 * 4);
//            }
//            else if (step == Raport.year)
//            {
//                dateTime = dateTimeFrom.AddMonths(1);
//            }

//            time_day.Add(dateTimeFrom);
//            while (dateTime < dateTimeTo)
//            {
//                time_day.Add(dateTime);
//                if (step == Raport.day) dateTime = dateTime.AddHours(1.0);
//                else if (step == Raport.week) dateTime = dateTime.AddDays(1.0);
//                else if (step == Raport.month) dateTime = dateTime.AddDays(1.0);
//                else if (step == Raport.year) dateTime = dateTime.AddMonths(1);
//            }
//            time_day.Add(dateTimeTo);
//            //12 000

//            for (int i = 1; i < 13; i++)//10000
//                                        //Enumerable.Range(0, 13).AsParallel().ForAll(i =>
//            {
//                //L.Clear();
//                List<float> L = new List<float>();
//                for (int r = 0; r < time_day.Count - 1; r++)
//                {
//                    float P_day = 0;
//                    float Q_day = 0;
//                    if (r == (time_day.Count - 2))
//                    {
//                        _dataManager.GetFirstLastData(i, time_day[r], time_day[r + 1], ref P_day, ref Q_day);
//                    }
//                    else
//                    {
//                        _dataManager.GetFirstLastData(i, time_day[r], time_day[r + 1].AddSeconds(-1.0), ref P_day, ref Q_day);
//                    }
//                    L.Add(P_day);
//                    L.Add(Q_day);
//                }
//                PQ_List.Add(L);
//            }
//            //10 000

//            for (int i = 0; i < time_day.Count - 1; i++)
//            {
//                DataRow row = dataRaports.NewRow();
//                if (i == (time_day.Count - 2)) row[0] = time_day[i].ToString() + System.Environment.NewLine + time_day[i + 1].ToString();
//                else row[0] = time_day[i].ToString() + System.Environment.NewLine + time_day[i + 1].AddSeconds(-1.0).ToString();
//                int q = 1;
//                foreach (var r in PQ_List)
//                {
//                    row[q] = r[i * 2];
//                    q++;
//                    row[q] = r[i * 2 + 1];
//                    q++;
//                }
//                dataRaports.Rows.Add(row);
//            }
//            DataRow lastrow = dataRaports.NewRow();
//            lastrow[0] = "Total";// dateTimeFrom.ToString() + System.Environment.NewLine + dateTimeTo.ToString();
//            for (int i = 1; i < dataRaports.Columns.Count; i++)
//            {
//                lastrow[i] = (float)Math.Round(dataRaports.AsEnumerable().Sum(x => (float)x[i]), 2);
//            }
//            dataRaports.Rows.Add(lastrow);
//        });

//        _mainForm.RaportsData(dataRaports);
//        PQ_List = null;
//        dataRaports = null;
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.ToString());
//    }
//}

//private async void RaportData2(Raport raport, DateTime dateTimeFrom, DateTime dateTimeTo)
//{
//    var dataRaports = new DataTable();
//    dataRaports.Columns.Add("Day/Time", typeof(string));
//    var dateList = new List<DateTime>();
//    DateTime dateTime = dateTimeFrom;
//    var PdayList = new Dictionary<int, List<float>>();
//    var QdayList = new Dictionary<int, List<float>>();

//    try
//    {
//        await Task.Run(() =>
//        {
//            dateTimeTo = dateTimeFrom > dateTimeTo ? dateTimeFrom : dateTimeTo;
//            dateList.Add(dateTimeFrom);
//            while (dateTime < dateTimeTo)
//            {
//                if (raport == Raport.day) dateTime = dateTime.AddHours(1.0);
//                else if (raport == Raport.week) dateTime = dateTime.AddDays(1.0);
//                else if (raport == Raport.month) dateTime = dateTime.AddDays(1.0);
//                else if (raport == Raport.year) dateTime = dateTime.AddMonths(1);
//                if (dateTime < dateTimeTo) dateList.Add(dateTime);
//            }
//            dateList.Add(dateTimeTo);

//            foreach (var equ in equID)
//            {
//                PdayList.Add(equ, new List<float>());
//                QdayList.Add(equ, new List<float>());
//                for (int i = 0; i < dateList.Count - 1; i++)
//                {
//                    PdayList[equ].Add(_dataManager.GetFirstData(equ, dateList[i], dateList[i + 1], "P_day"));
//                    QdayList[equ].Add(_dataManager.GetFirstData(equ, dateList[i], dateList[i + 1], "Q_day"));
//                    if (i == dateList.Count - 2)
//                    {
//                        PdayList[equ].Add(_dataManager.GetLastData(equ, dateList[i], dateList[i + 1], "P_day"));
//                        QdayList[equ].Add(_dataManager.GetLastData(equ, dateList[i], dateList[i + 1], "Q_day"));
//                    }
//                }
//            }

//            foreach (var eq in equIDName.Keys)
//            {
//                string s = equIDName[eq];
//                if (string.IsNullOrWhiteSpace(s)) { s = "Unknow" + eq.ToString(); }
//                dataRaports.Columns.Add(s + ", P", typeof(float));
//                dataRaports.Columns.Add(s + ", Q", typeof(float));
//            }
//            for (int i = 0; i < dateList.Count - 1; i++)
//            {
//                DataRow row = dataRaports.NewRow();
//                if (i == (dateList.Count - 2)) row[0] = dateList[i].ToString() + System.Environment.NewLine + dateList[i + 1].ToString();
//                else row[0] = dateList[i].ToString() + System.Environment.NewLine + dateList[i + 1].AddSeconds(-1.0).ToString();

//                int q = 0;
//                foreach (var equ in PdayList.Keys)
//                {
//                    row[q * 2 + 1] = Math.Round((PdayList[equ][i + 1] - PdayList[equ][i]) / 1000, 2);
//                    row[q * 2 + 2] = Math.Round((QdayList[equ][i + 1] - QdayList[equ][i]) / 1000, 2);
//                    q++;
//                }
//                dataRaports.Rows.Add(row);
//            }
//        });
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.ToString());
//    }
//    finally
//    {
//        _mainForm.RaportsData(dataRaports);
//    }
//}