using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
    public interface IDataManager
    {
        event EventHandler<string> Message;
        void SetConnection(List<string> list);
        void SetConnection(string str);
        void SqlConnectionClose();
        DataRow GetLastEquData(int eq);
        DataTable GetEquData(int eq, DateTime begin, DateTime end);
        DataTable GetEquData(int eq, DateTime begin, DateTime end,List<string> colums);
        DataTable GetEquData2(int eq, DateTime begin, DateTime end, List<string> colums);
        void DD_MM(bool state);
        float GetFirstData(int eq, DateTime begin, DateTime end, string Value);
        float GetLastData(int eq, DateTime begin, DateTime end, string Value);
        void GetFirstLastData(int eq, DateTime begin, DateTime end, ref float P_day, ref float Q_day);
        DataTable GetEquList();
        Int32 GetRezultCount(List<int> eq, DateTime begin, DateTime end);
        DataTable GetConsumption(Dictionary<int,string> equ, List<DateTime> times);
        DataTable GetConsumption2(Dictionary<int, string> equ, List<DateTime> times);
        DataTable GetConsumption3(Dictionary<int, string> equ, List<DateTime> times);
        DataTable GetConsumption4(Dictionary<int, string> equ, List<DateTime> times);
        DataTable GetDataPower(int eq, DateTime begin, DateTime end, List<string> colums);
       
    }

    public class DataManager: IDataManager
    {
        private SqlConnection sqlConnection = null, sqlConnectionPower = null;
        private SqlDataAdapter dataAdapter = null, dataAdapterPower = null;
        private DataSet dataSet = null, dataSetPower = null;
        private SqlCommand cmd;
        //private DataTable table = null;
        //private string connection = @"Data Source=PL02K01-C0AH8FL\SQL25012021;Initial Catalog=pomiary;Userid=uzytkownik;Password=Kayser2021";
        private string con = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS_0804\MSSQL\DATA\pomiary.mdf;Integrated Security = True; Connect Timeout = 30";
        //private string con = @"Data Source=PL02K02-F1QQ9WC\SQLEXPRESS;Initial Catalog=pomiary;Integrated Security=True";
        private bool _DD_MM_ = false;

        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder()
        {
            DataSource = "PL02K01-C0AH8FL,1433\\SQL25012021",
            InitialCatalog = "pomiary",
            UserID = "uzytkownik",
            Password = "Kayser2022"
        };

        public event EventHandler<string> Message;

        private void Sql_Connect()
        {
            try
            {
                if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection = new SqlConnection(con);
                    sqlConnection.Open();
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        Message?.Invoke(this, "Connection - OK");
                    }
                    else
                    {
                        Message?.Invoke(this, "Connection - NOK");
                    }
                }
                if (sqlConnectionPower == null || sqlConnectionPower.State == ConnectionState.Closed)
                {
                    sqlConnectionPower = new SqlConnection(con);
                    sqlConnectionPower.Open();
                    if (sqlConnectionPower.State == ConnectionState.Open)
                    {
                        Message?.Invoke(this, "ConnectionPower - OK");
                    }
                    else
                    {
                        Message?.Invoke(this, "ConnectionPower - NOK");
                    }
                }
            }
            catch(Exception ex)
            {
                Message?.Invoke(this,ex.ToString());
            }            
        }

        public DataRow GetLastEquData(int eq)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();
                    DataTable table = null;
                    string str = "SELECT TOP 1 * FROM dbo.\"" + Convert.ToString(eq) + "\" " + "ORDER BY ID DESC";
                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));
                    table = dataSet.Tables["dbo." + Convert.ToString(eq)];

                    if (table != null) return table.AsEnumerable().Last();
                }

                return new DataTable().NewRow();
            }
            catch(Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable().NewRow();
            }
        }

        public DataTable GetEquData(int eq, DateTime begin, DateTime end)
        {                               /*12.03.2021 19:45:53*/
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();
                                     
                    string str = "SELECT Czas,Nazwa_urzadzenia,P,Status FROM dbo.\"" + Convert.ToString(eq) + "\" " + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')" + "ORDER BY ID ASC";
                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));

                    return dataSet.Tables["dbo." + Convert.ToString(eq)];
                }

                return new DataTable();
            }
            catch(Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public float GetFirstData(int eq, DateTime begin, DateTime end, string Value)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();

                    string str = "SELECT TOP 1 " + Value + " FROM dbo.\"" + Convert.ToString(eq) + "\" "
                                    + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '"
                                                              + Replace(end, _DD_MM_) + "')"
                                                              + " AND "+ Value + " IS NOT NULL "
                                                              + " ORDER BY ID ASC";
                    cmd = new SqlCommand(str, sqlConnection);
                    float res = 0;
                    object o = cmd.ExecuteScalar();
                    if (o != null) res = Convert.ToSingle(o);
                    cmd.Dispose();
                    return res;
                }
                return 0.0f;

            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return 0.0f;
            }
        }

        public float GetLastData(int eq, DateTime begin, DateTime end, string Value)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();

                    string str = "SELECT TOP 1 " + Value + " FROM dbo.\"" + Convert.ToString(eq) + "\" "
                                    + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '"
                                                              + Replace(end, _DD_MM_) + "')"
                                                              + " AND " + Value + " IS NOT NULL "
                                                              + " ORDER BY ID DESC";
                    cmd = new SqlCommand(str, sqlConnection);
                    float res = 0;
                    object o = cmd.ExecuteScalar();
                    if (o != null) res = Convert.ToSingle(o);
                    cmd.Dispose();
                    return res;
                }
                return 0.0f;

            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return 0.0f;
            }
        }

        public void GetFirstLastData(int eq, DateTime begin, DateTime end, ref float P_day, ref float Q_day)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();

                    string str = "SELECT * FROM dbo.\"" + Convert.ToString(eq) + "\" "
                                + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) 
                                + "' AND '" + Replace(end, _DD_MM_) + "')"
                                + "ORDER BY ID ASC";

                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));

                    List<object> P_list = new List<object>();
                    List<object> Q_list = new List<object>();
                    using (var dt = dataSet.Tables["dbo." + Convert.ToString(eq)])
                    {
                        if(dt != null)
                        {
                            P_list = dt.AsEnumerable().Select(x => x["P_day"]).ToList();
                            Q_list = dt.AsEnumerable().Select(x => x["Q_day"]).ToList();

                            P_day = (float)Math.Round((Convert.ToSingle(P_list.LastOrDefault(x => x!=DBNull.Value)) - Convert.ToSingle(P_list.FirstOrDefault(x => x != DBNull.Value))) / 1000, 2);
                            Q_day = (float)Math.Round((Convert.ToSingle(Q_list.LastOrDefault(x => x != DBNull.Value)) - Convert.ToSingle(Q_list.FirstOrDefault(x => x != DBNull.Value))) / 1000, 2);
                        }
                        else
                        {
                            P_day = 0.0f;
                            Q_day = 0.0f;
                        }
                    }
                    P_list = null;
                    Q_list = null;
                }

            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
            }
        }

        public void SetConnection(List<string> list)
        {
            try
            {
                connection = new SqlConnectionStringBuilder()
                {
                    DataSource = list[0],
                    InitialCatalog = list[1],
                    UserID = list[2],
                    Password = list[3]
                };

                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
                con = connection.ConnectionString;
                Sql_Connect();
            }    
            catch(Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
            }
        }

        public void SetConnection(string str)
        {
            try
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
                con = str;
                Sql_Connect();
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
            }
        }

        public void SqlConnectionClose()
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            if (sqlConnectionPower != null && sqlConnectionPower.State != ConnectionState.Closed)
                sqlConnectionPower.Close();
        }

        public void DD_MM(bool state)
        {
            _DD_MM_ = state;
        }
    
        private string Replace(DateTime dt, bool ddmm)
        {
            if (ddmm)
            {
                return dt.Year.ToString() + "."
                        + dt.Month.ToString() + "."
                        + dt.Day.ToString() + " "
                        + dt.Hour.ToString() + ":"
                        + dt.Minute.ToString() + ":"
                        + dt.Second.ToString();
            }
            else
            {
                return  dt.Year.ToString() + "."
                        + dt.Day.ToString() + "."
                        + dt.Month.ToString() + " "
                        + dt.Hour.ToString() + ":"
                        + dt.Minute.ToString() + ":"
                        + dt.Second.ToString();
            }
        }

        public DataTable GetEquData(int eq, DateTime begin, DateTime end, List<string> colums)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();

                    string str2 = "Czas,Nazwa_urzadzenia,Status";
                    foreach (var s in colums)
                    {
                        str2 += "," + s;
                    }

                    string str = "SELECT " + str2 + " FROM dbo.\"" + Convert.ToString(eq) + "\" " + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')" + "ORDER BY ID ASC";
                    dataSet = new DataSet();
                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));

                    return dataSet.Tables["dbo." + Convert.ToString(eq)];
                }

                return new DataTable();
            }
            catch(Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetEquData2(int eq, DateTime begin, DateTime end, List<string> colums)
        {
            try
            {
                if (eq > 0 && eq < 256)
                {
                    Sql_Connect();
                    string strDb = "FROM dbo.\"" + Convert.ToString(eq) + "\" ";
                    string strWhere = "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')";
                    string str = "SELECT count(ID) as idcount " + strDb + strWhere;
                    int count = 0;
                    dataSet = new DataSet();
                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));
                    count = (int)dataSet.Tables["dbo." + Convert.ToString(eq)].Rows[0]["idcount"];
                    int firstid = 1;
                    str = "SELECT top 1 ID " + strDb + strWhere + " order by ID asc";
                    dataSet = new DataSet();
                    dataAdapter = new SqlDataAdapter(str, sqlConnection);
                    dataAdapter.Fill(dataSet, "dbo." + Convert.ToString(eq));
                    firstid = (int)dataSet.Tables["dbo." + Convert.ToString(eq)].Rows[0]["ID"];


                }
                return new DataTable();
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetEquList()
        {
            try
            {
                Sql_Connect();
                string str = "SELECT * FROM dbo.equipments ORDER BY ID ASC";
                dataAdapter = new SqlDataAdapter(str, sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "dbo.equipments");
                return dataSet.Tables["dbo.equipments"];
            }
            catch(Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public Int32 GetRezultCount(List<int> eq, DateTime begin, DateTime end)
        {
            try
            {
                Int32 tempCount = 0;

                foreach(var i in eq.Where(x => x > 0 && x < 256))
                //eq.Where(x => x > 0 && x < 256).AsParallel().ForAll(i =>
                {
                    Sql_Connect();

                    string str = "SELECT COUNT(Czas) FROM dbo.\"" + Convert.ToString(i) + "\" " + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')";
                    cmd = new SqlCommand(str, sqlConnection);
                    Int32 t = (Int32)cmd.ExecuteScalar();
                    tempCount = t > tempCount ? t : tempCount;
                }//);

                return tempCount;//14000
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return 0;
            }
        }

        public DataTable GetConsumption(Dictionary<int,string> equ, List<DateTime> times)
        {
            try
            {
                Sql_Connect();

                DataTable dt = new DataTable();
                
                foreach (var eq in equ.Keys)
                {
                    string str = "";
                    string strDb = "FROM dbo.\"" + Convert.ToString(eq) + "\" ";
                    string strPres = "(MAX(P_day) - MIN(P_day)) AS '" + equ[eq] +", P'";

                    for (int i = 0; i < times.Count - 1; i++)
                    {
                        string strWhere = "WHERE(Czas BETWEEN '" + Replace(times[i], _DD_MM_) + "' AND '" + Replace(times[i + 1], _DD_MM_) + "') AND Q_day IS NOT NULL";

                        str += "SELECT " + strPres + ", " +
                                      "(" +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere + " ORDER BY ID DESC" +
                                        ")" +
                                        " - " +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere +
                                        ")" +
                                    ") AS '" + equ[eq] + ", Q '" +

                               strDb +
                               "WHERE (Czas BETWEEN '" + Replace(times[i], _DD_MM_) +
                                             "' AND '" + Replace(times[i + 1], _DD_MM_) + "')";

                        if (i != times.Count - 2) str += " UNION ALL ";
                    }

                    dataAdapter = new SqlDataAdapter(str.ToString(), sqlConnection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "dbo.Consumption" + Convert.ToString(eq));

                    dt.Columns.Add(dataSet.Tables["dbo.Consumption" + Convert.ToString(eq)].Columns[0]);
                    dt.Columns.Add(dataSet.Tables["dbo.Consumption" + Convert.ToString(eq)].Columns[1]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetConsumption2(Dictionary<int, string> equ, List<DateTime> times)
        {
            try
            {
                List<SqlConnection> sqlConnectionsList = new List<SqlConnection>
                {
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con)
                };
                foreach (var i in sqlConnectionsList)
                {
                    i.Open();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Day/Time", typeof(string));
                foreach (var eq in equ.Keys)
                {
                    string s = equ[eq];
                    if (string.IsNullOrWhiteSpace(s)) { s = "Unknow" + eq.ToString(); }
                    dt.Columns.Add(s + ", P", typeof(float));
                    dt.Columns.Add(s + ", Q", typeof(float));
                }
                for (int i = 0; i < times.Count - 1; i++)
                {
                    DataRow row = dt.NewRow();
                    if (i == (times.Count - 2)) row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].ToString();
                    else row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].AddSeconds(-1.0).ToString();
                    dt.Rows.Add(row);
                }
                var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                //foreach (var eq in l)
                Parallel.ForEach(l, eq =>
                {
                    string str = "";
                    string strDb = "FROM dbo.\"" + Convert.ToString(eq) + "\" ";
                    string strPres = "((MAX(P_day) - MIN(P_day))/1000) AS '" + equ[eq] + ", P'";

                    for (int i = 0; i < times.Count - 1; i++)
                    {
                        string strWhere = "WHERE(Czas BETWEEN '" + Replace(times[i], _DD_MM_) + "' AND '" + Replace(times[i + 1], _DD_MM_) + "') AND Q_day IS NOT NULL";

                        str += "SELECT " + strPres + ", " +
                                      "((" +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere + " ORDER BY ID DESC" +
                                        ")" +
                                        " - " +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere +
                                        ")" +
                                      ")/1000) AS '" + equ[eq] + ", Q' " +

                               strDb +
                               "WHERE (Czas BETWEEN '" + Replace(times[i], _DD_MM_) +
                                             "' AND '" + Replace(times[i + 1], _DD_MM_) + "')";

                        if (i != times.Count - 2) str += " UNION ALL ";
                    }

                    var dataAdapt = new SqlDataAdapter(str.ToString(), sqlConnectionsList[eq-1]);
                    var dataS = new DataSet();
                    dataAdapt.Fill(dataS, "dbo.Consumption" + Convert.ToString(eq));
                    int qwer = 0;
                    foreach (DataRow row in dataS.Tables["dbo.Consumption" + Convert.ToString(eq)].Rows)
                    {
                        dt.Rows[qwer][equ[eq] + ", P"] = row[equ[eq] + ", P"] !=DBNull.Value ? Math.Round((double)row[equ[eq] + ", P"],2) : 0;
                        dt.Rows[qwer][equ[eq] + ", Q"] = row[equ[eq] + ", Q"] != DBNull.Value ? Math.Round((double)row[equ[eq] + ", Q"], 2) : 0;
                        qwer++;
                    }
                });

                foreach (var i in sqlConnectionsList)
                {
                    i.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetConsumption3(Dictionary<int, string> equ, List<DateTime> times)
        {
            try
            {
                List<SqlConnection> sqlConnectionsList = new List<SqlConnection>
                {
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con),
                    new SqlConnection(con)
                };

                var dataAdapt = new List<SqlDataAdapter> 
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                };
                var dataS = new List<DataSet>
                {
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet(),
                    new DataSet()
                };
                foreach (var i in sqlConnectionsList)
                {
                    i.Open();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Day/Time", typeof(string));
                foreach (var eq in equ.Keys)
                {
                    string s = equ[eq];
                    if (string.IsNullOrWhiteSpace(s)) { s = "Unknow" + eq.ToString(); }
                    dt.Columns.Add(s + ", P", typeof(float));
                    dt.Columns.Add(s + ", Q", typeof(float));
                }
                for (int i = 0; i < times.Count - 1; i++)
                {
                    DataRow row = dt.NewRow();
                    if (i == (times.Count - 2)) row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].ToString();
                    else row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].AddSeconds(-1.0).ToString();
                    dt.Rows.Add(row);
                }
                var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                //foreach (var eq in l)
                Parallel.ForEach(l, eq =>
                {
                    string str = "";
                    string strDb = "FROM dbo.\"" + Convert.ToString(eq) + "\" ";
                    string strPres = "((MAX(P_day) - MIN(P_day))/1000) AS '" + equ[eq] + ", P'";

                    for (int i = 0; i < times.Count - 1; i++)
                    {
                        string strWhere = "WHERE(Czas BETWEEN '" + Replace(times[i], _DD_MM_) + "' AND '" + Replace(times[i + 1], _DD_MM_) + "') AND Q_day IS NOT NULL";

                        str += "SELECT " + strPres + ", " +
                                      "((" +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere + " ORDER BY ID DESC" +
                                        ")" +
                                        " - " +
                                        "(" +
                                            "SELECT TOP 1 Q_day " + strDb + strWhere +
                                        ")" +
                                      ")/1000) AS '" + equ[eq] + ", Q' " +
                               //"(MAX(Q_day)/1000) AS '" + equ[eq] + ", Q' " +

                               strDb +
                               "WHERE (Czas BETWEEN '" + Replace(times[i], _DD_MM_) +
                                             "' AND '" + Replace(times[i + 1], _DD_MM_) + "')";

                        if (i != times.Count - 2) str += " UNION ALL ";
                    }

                    dataAdapt[eq - 1] = new SqlDataAdapter(str.ToString(), sqlConnectionsList[eq-1]);
                    //var dataS[eq - 1] = new DataSet();
                    dataAdapt[eq - 1].Fill(dataS[eq - 1], "dbo.Consumption" + Convert.ToString(eq));
                    int qwer = 0;
                    foreach (DataRow row in dataS[eq - 1].Tables["dbo.Consumption" + Convert.ToString(eq)].Rows)
                    {
                        dt.Rows[qwer][equ[eq] + ", P"] = row[equ[eq] + ", P"] != DBNull.Value ? Math.Round((double)row[equ[eq] + ", P"], 2) : 0;
                        dt.Rows[qwer][equ[eq] + ", Q"] = row[equ[eq] + ", Q"] != DBNull.Value ? Math.Round((double)row[equ[eq] + ", Q"], 2) : 0;
                        qwer++;
                    }
                });

                foreach (var i in sqlConnectionsList)
                {
                    i.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetConsumption4(Dictionary<int, string> equ, List<DateTime> times)
        {
            var dt = new DataTable();
            try
            {
                dt.Columns.Add("Day/Time", typeof(string));
                for (int i = 0; i < times.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    if (i < times.Count - 2) row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].AddSeconds(-1.0).ToString();
                    else if (i == (times.Count - 2)) row[0] = times[i].ToString() + System.Environment.NewLine + times[i + 1].ToString();
                    else row[0] = "Total";
                    dt.Rows.Add(row);
                }
                if (equ.Keys.Count == 0) return dt;
                var _sqlConnections = new List<SqlConnection>();
                var _dataAdapts = new List<SqlDataAdapter>();
                var _dataSets = new List<DataSet>();
                //var _rows = new List<DataRow[]>();

                foreach (var eq in equ.Keys)
                {
                    string s = equ[eq];
                    if (string.IsNullOrWhiteSpace(s)) { s = "Unknow" + eq.ToString(); }
                    dt.Columns.Add(s + ", P", typeof(float));
                    dt.Columns.Add(s + ", Q", typeof(float));
                    _sqlConnections.Add(new SqlConnection(con));
                    _dataAdapts.Add(null);
                    _dataSets.Add(new DataSet());
                }
                var l = equ.Keys.ToList();
                var locker = new object();
                Parallel.ForEach(l, eq =>
                //foreach(var eq in l)
                 {
                     string str = "";
                     string strDb = "FROM dbo.\"" + Convert.ToString(eq) + "\" ";
                     for (int i = 0; i < times.Count; i++)
                     {
                         string strWhere = "";
                         if(i < times.Count - 1) strWhere = " WHERE (Czas BETWEEN '" + Replace(times[i], _DD_MM_) + "' AND '" + Replace(times[i + 1], _DD_MM_) + "') ";
                         else strWhere = " WHERE (Czas BETWEEN '" + Replace(times.First(), _DD_MM_) + "' AND '" + Replace(times.Last(), _DD_MM_) + "') ";
                         str = "SELECT * FROM " +
                            "(" +
                                "(" + "" +
                                    "SELECT TOP 1 Czas,P_day,Q_day " +
                                    strDb + strWhere + " AND P_day IS NOT NULL ORDER BY Czas ASC " +
                                ") " +
                                "UNION ALL " +
                                "(" +
                                    "SELECT TOP 1 Czas,P_day,Q_day " +
                                    strDb + strWhere + " AND P_day IS NOT NULL ORDER BY Czas DESC " +
                                ") " + 
                             ") t";
                        string table = "dbo.Consumption" + Convert.ToString(eq) + i.ToString();
                        _dataAdapts[l.IndexOf(eq)] = new SqlDataAdapter(str.ToString(), _sqlConnections[l.IndexOf(eq)]);
                        _dataAdapts[l.IndexOf(eq)].Fill(_dataSets[l.IndexOf(eq)], table);
                        object firstP, lastP, firstQ, lastQ; 
                        if(_dataSets[l.IndexOf(eq)].Tables[table].Rows.Count < 2)
                        {
                            firstP = 0f;
                            lastP = 0f;
                            firstQ = 0f;
                            lastQ = 0f;
                        }
                        else
                        {
                            firstP = _dataSets[l.IndexOf(eq)].Tables[table].Rows[0]["P_day"];
                            lastP = _dataSets[l.IndexOf(eq)].Tables[table].Rows[1]["P_day"];
                            firstQ = _dataSets[l.IndexOf(eq)].Tables[table].Rows[0]["Q_day"];
                            lastQ = _dataSets[l.IndexOf(eq)].Tables[table].Rows[1]["Q_day"];
                        }

                        if (firstP == DBNull.Value) firstP = 0f;
                        if (lastP == DBNull.Value) lastP = 0f;
                        if (firstQ == DBNull.Value) firstQ = 0f;
                        if (lastQ == DBNull.Value) lastQ = 0f;

                         lock(locker)
                         {
                             dt.Rows[i][equ[eq] + ", P"] = Math.Round((Convert.ToSingle(lastP) - Convert.ToSingle(firstP)) / 1000, 2);
                             dt.Rows[i][equ[eq] + ", Q"] = Math.Round((Convert.ToSingle(lastQ) - Convert.ToSingle(firstQ)) / 1000, 2);
                         }
                     }

                 });

                foreach (var sql in _sqlConnections)
                    sql.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        public DataTable GetDataPower(int eq, DateTime begin, DateTime end, List<string> colums)
        {
            if (colums.Count == 0) return new DataTable();
            try
            {
                if (eq > 0 && eq < 256)
                {
                    string str2 = "Czas";
                    foreach (var s in colums)
                    {
                        str2 += "," + s;
                    }
                    string tableName = "dbo." + Convert.ToString(eq);
                    string str = "SELECT " + str2 + " FROM dbo.\"" + Convert.ToString(eq) + "\" " + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')";// AND Czas IS NOT NULL";
                    dataSetPower = new DataSet();
                    dataAdapterPower = new SqlDataAdapter(str, sqlConnectionPower);
                    dataAdapterPower.Fill(dataSetPower, tableName);

                    int datasize = dataSetPower.Tables[tableName].Rows.Count;
                    if (datasize == 0) return new DataTable();

                    var tempDataTable = new DataTable();
                    tempDataTable.Columns.Add("Czas", typeof(string));
                    foreach(var col in colums)
                    {
                        tempDataTable.Columns.Add(col, typeof(float));
                    }

                    int step = datasize / 1000;
                    int arraycapacity = 0;
                    if (step == 0)
                    {
                        step = 1;
                        arraycapacity = datasize * 2;
                    }
                    else
                    {
                        if(datasize % step == 0)
                        {
                            arraycapacity = (datasize / step) * 2;
                        }
                        else
                        {
                            arraycapacity = (datasize / step) * 2 + 2;
                        }
                    }
                    

                    var p = dataSetPower.Tables[tableName].AsEnumerable().Select(x => x.Field<object>(colums[0])).Select(x => x != DBNull.Value ? x : 0).ToArray();
    
                    var indexArray = new int[arraycapacity];
                    var pointsArray = new float[arraycapacity];

                    int count = 0;
                    for (int i = 0; i < datasize; i += step)
                    {
                        int [] indexes = { 0, 0 };
                        float[] points = { 0, 0 };
                        int slice = (i + step) >= datasize ? (datasize - i - 1) : step;
                        if (slice != 0) MinMax(p.AsSpan().Slice(i, slice), ref indexes, ref points);
                        else MinMax(new object [] { p[i]}, ref indexes, ref points);
                        indexArray[count] = indexes[0] + i;
                        pointsArray[count] = points[0];
                        count++;
                        indexArray[count] = indexes[1] + i;
                        pointsArray[count] = points[1];
                        count++;
                    }

                    for (int i = 0; i < indexArray.Length; i++)
                    {
                        var row = tempDataTable.NewRow();
                        row["Czas"] = dataSetPower.Tables[tableName].Rows[indexArray[i]]["Czas"];
                        row[colums[0]] = pointsArray[i];
                        for(int q = 1; q < colums.Count; q++)
                        {
                            row[colums[q]] = dataSetPower.Tables[tableName].Rows[indexArray[i]][colums[q]]; ;
                            if (row[colums[q]] == DBNull.Value) row[colums[q]] = 0;
                        }
                        tempDataTable.Rows.Add(row);
                    }
                    return tempDataTable;
                }

                return new DataTable();
            }
            catch (Exception ex)  
            {
                Message?.Invoke(this, ex.ToString());
                return new DataTable();
            }
        }

        private void MinMax(ReadOnlySpan<object> dots, ref int [] indexes, ref float[] points)
        {
            float min_val = dots[0] == null ? 0 : Convert.ToSingle(dots[0]);
            float max_val = min_val;
            int min_index = 0;
            int max_index = 0;
            int index = 0;
            foreach (var m in dots)
            {
                float temp = m == null ? 0 : Convert.ToSingle(m);
                if (min_val >= temp)
                {
                    min_val = temp;
                    min_index = index;
                }
                if (max_val <= temp)
                {
                    max_val = temp;
                    max_index = index;
                }
                index++;
            }
            indexes[0] = min_index;
            indexes[1] = max_index;
            points[0] = min_val;
            points[1] = max_val;
        }
    }
}
