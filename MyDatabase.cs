using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCPClient
{
    class MyDatabase
    {
        #region  全局变量
        public static string Login_ID = "";
        public static string Login_Name = "";

        //定义静态全局变量，记录“基础信息” 各窗体的表名、SQL语句、以及要添加和修改的字段名
        public static string Mean_SQL = "";
        public static string Mean_Table = "";
        public static string Mean_Field = "";
        public static MySqlConnection mysqlConn;
        public static string M_str_sqlcon = "Host=localhost;Database=factory;Username=root;Password=123456";
        public static int Login_n = 0;//用户登录与重新登录标识
        public static string AllSql = "select * from tb_Stuffbusic";
        #endregion

#region 打开数据库
        public MySqlConnection openConn()
        {
            mysqlConn = new MySqlConnection(M_str_sqlcon);
            mysqlConn.Open();
            return mysqlConn;
        }
#endregion
        
#region 关闭数据库
        public void closeConn()
        {
            if (mysqlConn.State == ConnectionState.Open)
            {
                mysqlConn.Close();
                mysqlConn.Dispose();
            }
        }
#endregion

#region 数据读取器对象
        ///<summary>
        ///数据读取器对象
        ///</summary>
        ///<param name="sqlStr">sql语句</param>
        ///
        //getReader,返回MySqlDataReader类型sdr
        public MySqlDataReader getReader(string sqlStr)
        {
            openConn();//打开数据库
            MySqlCommand Cmd = mysqlConn.CreateCommand();
            Cmd.CommandText = sqlStr;
            MySqlDataReader sdr = Cmd.ExecuteReader();
            return sdr;
        }
#endregion

 #region 打开数据库并执行sql语句，释放资源
        ///<summary>
        ///打开数据库并执行sql语句，释放资源
        ///</summary>
        ///<param name="sqlStr">sql语句</param>
        ///executeSql通过SqlCommand对象执行数据库的添加修改和删除操作，在执行完成后释放资源，关闭连接
        public void executeSql(string sqlStr)
        {
            openConn();
            MySqlCommand Cmd = new MySqlCommand(sqlStr, mysqlConn);
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            closeConn();
        }
#endregion


#region 得到数据集DataSet对象
        ///<summary>
        ///得到数据集DataSet对象
        ///</summary>
        ///<param name="sqlStr">sql语句</param>
        ///<param name="tableName">填充的表名</param>
        /// getDataSet(string sqlStr,string tableName)返回类型是DataSet，tableName是填充DataSet数据集的数据表名
        public DataSet getDataSet(string sqlStr, string tableName)
        {
            openConn();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStr, mysqlConn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tableName);
            closeConn();
            return ds;
        }
#endregion


        #region 插入速率到数据库中
        public void insertSpeedToDatabase(int head, int speed1, int speed2, int speed3, int speed4, int speed5, int speed6,int dingSpeed)
        {
            string sql="insert into M"+head.ToString()+"(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,dingSpeed) values ('"
                                             + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + "," + dingSpeed + ")";
            executeSql(sql);
            //switch (head)
            //{
            //case 1:
            //        sql = "insert into M1(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
            //                                  + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
            //        executeSql(sql);
            //    break;
           
            //}

        }
        #endregion


    }
}
