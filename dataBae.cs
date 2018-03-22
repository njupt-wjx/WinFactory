using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace TCPClient
{
    class dataBae
    {


        public static void insertDataToDatabase(int head,int speed1,int speed2,int speed3,int speed4,int speed5,int speed6)
        {
            MySqlConnection conn = new MySqlConnection("Host =localhost;Database=factory;Username=root;Password=123456");
            MySqlCommand Cmd = new MySqlCommand();
            conn.Open();

            switch (head)
            {
                case 1:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M1(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                // MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M2(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M3(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M4(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 5:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M5(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 6:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M6(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 7:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M7(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 8:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M8(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 9:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M9(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 10:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M10(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 11:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M11(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                // MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 12:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M12(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 13:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M13(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 14:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M14(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 15:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M15(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 16:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M16(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 17:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M17(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 18:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M18(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 19:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M19(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 20:
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            Cmd.Connection = conn;
                            Cmd.CommandText = "insert into M20(Date,Speed1,Speed2,Speed3,Speed4,Speed5,Speed6) values ('"
                                              + DateTime.Now.ToString() + "'" + "," + speed1 + "," + speed2 + "," + speed3 + "," + speed4 + "," + speed5 + "," + speed6 + ")";
                            Cmd.CommandType = CommandType.Text;
                            int ret = Cmd.ExecuteNonQuery();
                            if (ret > 0)
                            {
                                //MessageBox.Show("添加成功", "提示");
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
    }
}
