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

        private DataTable equTable;
        private List<int> equID = new List<int>();
        private List<string> equName = new List<string>();
        private Dictionary<int, string> equIDName = new Dictionary<int, string>();

        public Presenter(IMainForm mainForm, IDataManager dataManager)
        {
            _mainForm = mainForm;
            _dataManager = dataManager;

            _mainForm.ButCloseClick += new EventHandler(MainFormButCloseClick);

            //_mainForm.ButChartsEquipmentsClick += new EventHandler(_mainForm_ButEquClick);

            _mainForm.ChangeConnect += new EventHandler(MainFormChangeConnect);
            _mainForm.ReplaceDDMM += new EventHandler(MainFormReplaceDDMM);
            _mainForm.ButShowChartsClick += new EventHandler<List<object>>(MainFormButShowChartsClick);
            _mainForm.ButShowRaportsClick += new EventHandler<List<object>>(MainFormButShowRaportsClick);

            _mainForm.AplicationStart += new EventHandler(MainFormGetEquList);

            _dataManager.Message += new EventHandler<string>(DataManagerMessage);
        }

        private void DataManagerMessage(object sender, string e)
        {
            MessageBox.Show(e);
        }

        private void MainFormGetEquList(object sender, EventArgs e)
        {
            equTable = _dataManager.GetEquList();
            equID.Clear();
            equIDName.Clear();
            equName.Clear();
            equID = equTable.AsEnumerable().Where(x => x.Field<object>("ID") != DBNull.Value).Select(x => (int)x["ID"]).ToList();

            foreach (var i in equID)
            {
                string name = equTable.AsEnumerable().Where(x => x.Field<int>("ID") == i).Select(x => x["NamePL"].ToString()).First();
                equName.Add(name);
                equIDName.Add(i, name);
            }
            _mainForm.EquList = equName;
        }

        private void MainFormButEquClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = _dataManager.GetEquData(1, new DateTime(1800, 1, 1, 1, 1, 1), new DateTime(1800, 1, 1, 1, 1, 1));

                foreach (string i in _mainForm.EquList)//200ms
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow = _dataManager.GetLastEquData(Convert.ToInt32(i));
                    dataTable.ImportRow(dataRow);
                }
                _mainForm.EquipmentsFill(dataTable);//1635 ms

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainFormButCloseClick(object sender, EventArgs e)
        {
            _dataManager.SqlConnectionClose();
            _mainForm.FormClose();
        }

        private async void MainFormButShowChartsClick(object sender, List<object> e)
        {
            DataTable dataTable = new DataTable();
            await Task.Run(() =>
            {
                int temp = equIDName.ContainsValue((string)e[0]) ? equIDName.First(x => x.Value == (string)e[0]).Key : 0;
                dataTable = _dataManager.GetEquData(temp,
                                                    (DateTime)e[1],
                                                    (DateTime)e[2],
                                                    (List<string>)e[3]);
            });
            _mainForm.ChartData(dataTable, sender);
        }

        private void MainFormButShowRaportsClick(object sender, List<object> e)
        {
            //switch (e[0])
            //{
            //    case FormStates.daily:
            //        Raport_data(Raport.day, (DateTime)e[1], (DateTime)e[2]);
            //        break;
            //    case FormStates.weekly:
            //        Raport_data(Raport.week, (DateTime)e[1], (DateTime)e[2]);
            //        break;
            //    case FormStates.monthly:
            //        Raport_data(Raport.month, (DateTime)e[1], (DateTime)e[2]);
            //        break;
            //    case FormStates.annual:
            //        Raport_data(Raport.year, (DateTime)e[1], (DateTime)e[2]);
            //        break;
            //}
            //RaportData1(Raport.year, (DateTime)e[1], (DateTime)e[2]);
            RaportData3(Raport.month, (DateTime)e[1], (DateTime)e[2]);
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

        private async void RaportData1(Raport step, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            try
            {
                DataTable dataTable = _dataManager.GetEquData(1, new DateTime(1800, 1, 1, 1, 1, 1),
                                                                 new DateTime(1800, 1, 1, 1, 1, 1));
                if (!dataTable.Columns.Contains("Nazwa_urzadzenia")) return;
                DataTable dataRaports = new DataTable();
                dataRaports.Columns.Add("Time/Day", typeof(string));
                //DateTime dateTimeFrom = _mainForm.RaportsGetDateFrom();
                //DateTime dateTimeTo = _mainForm.RaportsGetDateTo();
                List<DateTime> time_day = new List<DateTime>();
                List<List<float>> PQ_List = new List<List<float>>();
                /*  Equ     P,Q(dateTimeFrom)   P,Q(dateTimeFrom + 1.0).... P,Q(dateTimeTo)       
                 *  0       P,Q                 P,Q                         P,Q
                 *  1       ...                 ...                         ...
                 *  ...     ...                 ...                         ...
                 *  n       ...                 ...                         ...
                 */

                await Task.Run(() =>
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 1; i < 13; i++)//2000
                    {
                        dataRow = _dataManager.GetLastEquData(i);
                        if (dataRow.Table.Columns.Contains("Nazwa_urzadzenia"))
                        {
                            dataRaports.Columns.Add(Convert.ToString(dataRow["Nazwa_urzadzenia"]) + ", P", typeof(float));
                            dataRaports.Columns.Add(Convert.ToString(dataRow["Nazwa_urzadzenia"]) + ", Q", typeof(float));
                        }
                        else
                        {
                            dataRaports.Columns.Add("Unknow " + i.ToString() + ", P", typeof(float));
                            dataRaports.Columns.Add("Unknow " + i.ToString() + ", Q", typeof(float));
                        }
                    }
                    dataRow = null;

                    if (dateTimeTo <= dateTimeFrom) return;
                    DateTime dateTime = new DateTime();
                    if (step == Raport.day)
                    {
                        dateTime = dateTimeFrom.AddHours(1.0);
                        if ((dateTimeTo - dateTimeFrom).TotalDays > 7) dateTimeTo = dateTimeFrom.AddDays(7.0);
                    }
                    else if (step == Raport.week)
                    {
                        dateTime = dateTimeFrom.AddDays(1.0);
                        if ((dateTimeTo - dateTimeFrom).TotalDays > 7 * 4) dateTimeTo = dateTimeFrom.AddDays(7.0 * 4);
                    }
                    else if (step == Raport.month)
                    {
                        dateTime = dateTimeFrom.AddDays(1.0);
                        if ((dateTimeTo - dateTimeFrom).TotalDays > 31 * 4) dateTimeTo = dateTimeFrom.AddDays(31 * 4);
                    }
                    else if (step == Raport.year)
                    {
                        dateTime = dateTimeFrom.AddMonths(1);
                    }

                    time_day.Add(dateTimeFrom);
                    while (dateTime < dateTimeTo)
                    {
                        time_day.Add(dateTime);
                        if (step == Raport.day) dateTime = dateTime.AddHours(1.0);
                        else if (step == Raport.week) dateTime = dateTime.AddDays(1.0);
                        else if (step == Raport.month) dateTime = dateTime.AddDays(1.0);
                        else if (step == Raport.year) dateTime = dateTime.AddMonths(1);
                    }
                    time_day.Add(dateTimeTo);
                    //12 000

                    for (int i = 1; i < 13; i++)//10000
                                                //Enumerable.Range(0, 13).AsParallel().ForAll(i =>
                    {
                        //L.Clear();
                        List<float> L = new List<float>();
                        for (int r = 0; r < time_day.Count - 1; r++)
                        {
                            float P_day = 0;
                            float Q_day = 0;
                            if (r == (time_day.Count - 2))
                            {
                                _dataManager.GetFirstLastData(i, time_day[r], time_day[r + 1], ref P_day, ref Q_day);
                            }
                            else
                            {
                                _dataManager.GetFirstLastData(i, time_day[r], time_day[r + 1].AddSeconds(-1.0), ref P_day, ref Q_day);
                            }
                            L.Add(P_day);
                            L.Add(Q_day);
                        }
                        PQ_List.Add(L);
                    }
                    //10 000

                    for (int i = 0; i < time_day.Count - 1; i++)
                    {
                        DataRow row = dataRaports.NewRow();
                        if (i == (time_day.Count - 2)) row[0] = time_day[i].ToString() + System.Environment.NewLine + time_day[i + 1].ToString();
                        else row[0] = time_day[i].ToString() + System.Environment.NewLine + time_day[i + 1].AddSeconds(-1.0).ToString();
                        int q = 1;
                        foreach (var r in PQ_List)
                        {
                            row[q] = r[i * 2];
                            q++;
                            row[q] = r[i * 2 + 1];
                            q++;
                        }
                        dataRaports.Rows.Add(row);
                    }
                    DataRow lastrow = dataRaports.NewRow();
                    lastrow[0] = "Total";// dateTimeFrom.ToString() + System.Environment.NewLine + dateTimeTo.ToString();
                    for (int i = 1; i < dataRaports.Columns.Count; i++)
                    {
                        lastrow[i] = (float)Math.Round(dataRaports.AsEnumerable().Sum(x => (float)x[i]), 2);
                    }
                    dataRaports.Rows.Add(lastrow);
                });

                _mainForm.RaportsData(dataRaports);
                PQ_List = null;
                dataRaports = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void RaportData2(Raport raport, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var dataRaports = new DataTable();
            dataRaports.Columns.Add("Day/Time", typeof(string));
            var dateList = new List<DateTime>();
            DateTime dateTime = dateTimeFrom;
            var PdayList = new Dictionary<int, List<float>>();
            var QdayList = new Dictionary<int, List<float>>();

            try
            {
                await Task.Run(() =>
                {
                    dateTimeTo = dateTimeFrom > dateTimeTo ? dateTimeFrom : dateTimeTo;
                    dateList.Add(dateTimeFrom);
                    while (dateTime < dateTimeTo)
                    {
                        if (raport == Raport.day) dateTime = dateTime.AddHours(1.0);
                        else if (raport == Raport.week) dateTime = dateTime.AddDays(1.0);
                        else if (raport == Raport.month) dateTime = dateTime.AddDays(1.0);
                        else if (raport == Raport.year) dateTime = dateTime.AddMonths(1);
                        if (dateTime < dateTimeTo) dateList.Add(dateTime);
                    }
                    dateList.Add(dateTimeTo);

                    foreach (var equ in equID)
                    {
                        PdayList.Add(equ, new List<float>());
                        QdayList.Add(equ, new List<float>());
                        for (int i = 0; i < dateList.Count - 1; i++)
                        {
                            PdayList[equ].Add(_dataManager.GetFirstData(equ, dateList[i], dateList[i + 1], "P_day"));
                            QdayList[equ].Add(_dataManager.GetFirstData(equ, dateList[i], dateList[i + 1], "Q_day"));
                            if (i == dateList.Count - 2)
                            {
                                PdayList[equ].Add(_dataManager.GetLastData(equ, dateList[i], dateList[i + 1], "P_day"));
                                QdayList[equ].Add(_dataManager.GetLastData(equ, dateList[i], dateList[i + 1], "Q_day"));
                            }
                        }
                    }

                    foreach (var eq in equIDName.Keys)
                    {
                        string s = equIDName[eq];
                        if (string.IsNullOrWhiteSpace(s)) { s = "Unknow" + eq.ToString(); }
                        dataRaports.Columns.Add(s + ", P", typeof(float));
                        dataRaports.Columns.Add(s + ", Q", typeof(float));
                    }
                    for (int i = 0; i < dateList.Count - 1; i++)
                    {
                        DataRow row = dataRaports.NewRow();
                        if (i == (dateList.Count - 2)) row[0] = dateList[i].ToString() + System.Environment.NewLine + dateList[i + 1].ToString();
                        else row[0] = dateList[i].ToString() + System.Environment.NewLine + dateList[i + 1].AddSeconds(-1.0).ToString();

                        int q = 0;
                        foreach (var equ in PdayList.Keys)
                        {
                            row[q * 2 + 1] = Math.Round((PdayList[equ][i + 1] - PdayList[equ][i]) / 1000, 2);
                            row[q * 2 + 2] = Math.Round((QdayList[equ][i + 1] - QdayList[equ][i]) / 1000, 2);
                            q++;
                        }
                        dataRaports.Rows.Add(row);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _mainForm.RaportsData(dataRaports);
            }
        }

        private void MainFormReplaceDDMM(object sender, EventArgs e)
        {
            _dataManager.DD_MM(_mainForm.GetReplace());
        }

        private async void RaportData3(Raport step, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var dataRaports = new DataTable();
            dataRaports.Columns.Add("Day/Time", typeof(string));
            var dateList = new List<DateTime>();
            DateTime dateTime = dateTimeFrom;
            var PdayList = new Dictionary<int, List<float>>();
            var QdayList = new Dictionary<int, List<float>>();

            try
            {
                await Task.Run(() =>
                {
                    dateTimeTo = dateTimeFrom > dateTimeTo ? dateTimeFrom : dateTimeTo;
                    dateList.Add(dateTimeFrom);
                    while (dateTime < dateTimeTo)
                    {
                        if (step == Raport.day) dateTime = dateTime.AddHours(1.0);
                        else if (step == Raport.week) dateTime = dateTime.AddDays(1.0);
                        else if (step == Raport.month) dateTime = dateTime.AddDays(1.0);
                        else if (step == Raport.year) dateTime = dateTime.AddMonths(1);
                        if (dateTime < dateTimeTo) dateList.Add(dateTime);
                    }
                    dateList.Add(dateTimeTo);

                    dataRaports = _dataManager.GetConsumption2(equIDName, dateList);
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
