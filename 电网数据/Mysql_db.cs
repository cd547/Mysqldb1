using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace 电网数据
{
    /// <summary>
    /// 通用数据库类MySQL 
    /// </summary>
    public class Mysql_db
    {
        public string server;
        public string uid;
        public string password;
        public string database;
        public string connStr;
        public Mysql_db(string server, string uid, string password, string database)
        {
            this.server = server;
            this.uid = uid;
            this.password = password;
            this.database = database;
            this.connStr = "server=" + this.server + ";uid=" + this.uid + ";password=" + this.password + ";Charset=utf8;database=" + this.database;
        }

        public string Test_Conn()
        {
            string ans;
            try
            {
                MySqlConnection Conn = new MySqlConnection(this.connStr);
                Conn.Open();
                ans = Conn.State.ToString();
                if (Conn != null)
                {
                    Conn.Close();
                    Conn.Dispose();
                }

            }
            catch(MySqlException exp) {
                ans = exp.ToString();
            }
            GC.Collect();
            return ans;
        }

       
        //打开数据库链接
        public MySqlConnection Open_Conn()
        {
            MySqlConnection Conn = new MySqlConnection(this.connStr);
            Conn.Open();
            
            return Conn;
        }
        //关闭数据库链接
        public  void Close_Conn(MySqlConnection Conn)
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
            GC.Collect();
        }
        //运行MySql语句
        public int Run_SQL(string SQL)
        {
            
            MySqlConnection Conn = Open_Conn();
            MySqlCommand Cmd = Create_Cmd(SQL, Conn);
            try
            {
                int result_count = Cmd.ExecuteNonQuery();
                Close_Conn(Conn);
                return result_count;
            }
            catch(MySqlException exp)
            {

                Close_Conn(Conn);
                return 0;
            }
        }
        // 生成Command对象 
        public  MySqlCommand Create_Cmd(string SQL, MySqlConnection Conn)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Conn);
            return Cmd;
        }
        // 运行MySql语句返回 DataTable
        public  DataTable Get_DataTable(string SQL,string Table_name)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            DataTable dt = new DataTable(Table_name);
            Da.Fill(dt);
            return dt;
        }
        // 运行MySql语句返回 MySqlDataReader对象
        public  MySqlDataReader Get_Reader(string SQL)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlCommand Cmd = Create_Cmd(SQL, Conn);
            MySqlDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return Dr;
        }
        // 运行MySql语句返回 MySqlDataAdapter对象 
        public  MySqlDataAdapter Get_Adapter(string SQL)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Conn);
            return Da;
        }
        // 运行MySql语句,返回DataSet对象
        public  DataSet Get_DataSet(string SQL, DataSet Ds)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            return Ds;
        }
        // 运行MySql语句,返回DataSet对象
        public  DataSet Get_DataSet(string SQL, DataSet Ds, string tablename)
        {
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }
        // 运行MySql语句,返回DataSet对象，将数据进行了分页
        public  DataSet Get_DataSet(string SQL,  DataSet Ds, int StartIndex, int PageSize, string tablename)
        {
            MySqlConnection Conn = Open_Conn();
            MySqlDataAdapter Da = Get_Adapter(SQL);
            try
            {
                Da.Fill(Ds, StartIndex, PageSize, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Close_Conn(Conn);
            return Ds;
        }
        // 返回MySql语句执行结果的第一行第一列
        public string Get_Row1_Col1_Value(string SQL)
        {
            MySqlConnection Conn = Open_Conn();
            string result;
            MySqlDataReader Dr;
            try
            {
                Dr = Create_Cmd(SQL, Conn).ExecuteReader();
                if (Dr.Read())
                {
                    result = Dr[0].ToString();
                    Dr.Close();
                }
                else
                {
                    result = "";
                    Dr.Close();
                }
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return result;
        }

       
    }
}
