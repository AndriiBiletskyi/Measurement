using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

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
        void DD_MM(bool state);
        float GetFirstData(int eq, DateTime begin, DateTime end, string Value);
        float GetLastData(int eq, DateTime begin, DateTime end, string Value);
        void GetFirstLastData(int eq, DateTime begin, DateTime end, ref float P_day, ref float Q_day);
        DataTable GetEquList();
        Int32 GetRezultCount(List<int> eq, DateTime begin, DateTime end);
        DataTable GetConsumption(Dictionary<int,string> equ, List<DateTime> times);
    }

    public class DataManager: IDataManager
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
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
            Password = "Kayser2021"
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
            }catch(Exception ex)
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
        }

        public void DD_MM(bool state)
        {
            _DD_MM_ = state;
        }
    
        private string Replace(DateTime dt, bool ddmm)
        {
            if (ddmm)
            {
                return  dt.Year.ToString() + "."
                        + dt.Month.ToString() + "."
                        + dt.Day.ToString() + " "
                        + dt.TimeOfDay.ToString();
            }
            else
            {
                return  dt.Year.ToString() + "."
                        + dt.Day.ToString() + " "
                        + dt.Month.ToString() + "."
                        + dt.TimeOfDay.ToString();
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
                    foreach(var s in colums)
                    {
                        str2 += "," + s;
                    }

                    string str = "SELECT " + str2 + " FROM dbo.\"" + Convert.ToString(eq) + "\" " + "WHERE (Czas BETWEEN '" + Replace(begin, _DD_MM_) + "' AND '" + Replace(end, _DD_MM_) + "')" + "ORDER BY ID ASC";
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
    }
}
