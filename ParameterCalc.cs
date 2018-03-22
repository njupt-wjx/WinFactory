using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCPClient
{
    class ParameterCalc
    {
        //string[] time; 
        //int[] speed1, speed2, speed3, speed4, speed5, speed6;
        //string[] nighttime;
        //int[] nightspeed1, nightspeed2, nightspeed3, nightspeed4, nightspeed5, nightspeed6;
        /// <summary> 
        /// 速率的计算
        public static void Speed(System.Windows.Forms.DateTimePicker dateTimePicker,string machine,string[] time, int[] speed1, int[] speed2, int[] speed3, int[] speed4, int[] speed5, int[] speed6
                                 ,string[] nighttime,int[] nightspeed1,int[] nightspeed2,int[] nightspeed3,int[] nightspeed4,int[] nightspeed5,int[] nightspeed6)
        {
            string curdate = dateTimePicker.Text.ToString();
            string beforedate = dateTimePicker.Value.AddDays(-1).ToString("yyyy-MM-dd");
            string daysql = "select Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,Date from " + machine + " where Date between" + "'" + beforedate + " 07:30:00" + "'"
                                               + " and " + "'" + beforedate + " 19:30:00" + "'";
            string nightsql = "select Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,Date from " + machine + " where Date between" + "'" + beforedate + " 19:30:00" + "'"
                                               + " and " + "'" + curdate + " 07:30:00" + "'";
            MyDatabase myDatabase = new MyDatabase();
            DataSet day_ds = myDatabase.getDataSet(daysql, "dayDS");
            DataSet night_ds = myDatabase.getDataSet(nightsql, "nightDS");

            int daycount ;
            int nightcount;

            daycount = day_ds.Tables[0].Rows.Count;
            nightcount = night_ds.Tables[0].Rows.Count;

            //speed1 = new int[daycount];
            //speed2 = new int[daycount];
            //speed3 = new int[daycount];
            //speed4 = new int[daycount];
            //speed5 = new int[daycount];
            //speed6 = new int[daycount];
            //time = new string[daycount];
            //nightspeed1 = new int[nightcount];
            //nightspeed2 = new int[nightcount];
            //nightspeed3 = new int[nightcount];
            //nightspeed4 = new int[nightcount];
            //nightspeed5 = new int[nightcount];
            //nightspeed6 = new int[nightcount];
            //nighttime = new string[nightcount];

            int i = 0, j = 0, k = 0, l = 0, m = 0, n = 0, d = 0;
            int i1 = 0, j1 = 0, k1 = 0, l1 = 0, m1 = 0, n1 = 0, d1 = 0;
            foreach (DataRow row in day_ds.Tables[0].Rows)//遍历所有行
            {
                speed1[i++] = int.Parse(row[0].ToString());//row[0]表示第一列
                speed2[j++] = int.Parse(row[1].ToString());
                speed3[k++] = int.Parse(row[2].ToString());
                speed4[l++] = int.Parse(row[3].ToString());
                speed5[m++] = int.Parse(row[4].ToString());
                speed6[n++] = int.Parse(row[5].ToString());
                time[d++] = DateTime.Parse(row[6].ToString()).ToString("HH:mm");
            }
            foreach (DataRow row in night_ds.Tables[0].Rows)//遍历所有行
            {

                nightspeed1[i1++] = int.Parse(row[0].ToString());//row[0]表示第一列
                nightspeed2[j1++] = int.Parse(row[1].ToString());
                nightspeed3[k1++] = int.Parse(row[2].ToString());
                nightspeed4[l1++] = int.Parse(row[3].ToString());
                nightspeed5[m1++] = int.Parse(row[4].ToString());
                nightspeed6[n1++] = int.Parse(row[5].ToString());
                nighttime[d1++] = DateTime.Parse(row[6].ToString()).ToString("HH:mm");
            }
        }

        //开关机时间
        public static string TurnOnTime( int[] speed1,string[] time)
        {
            string TurnOnTime = "";
            for (int i = 0; i < speed1.Length - 1;i++ )
            {
                if (speed1[i] == 0 && speed1[i + 1] != 0)
                {
                    TurnOnTime += time[i];
                }
            }
            return TurnOnTime;
        }

        public static string TurnOffTime( int[] speed1, string[] time)
        {
            string TurnOffTime = "";
            for (int i = 0; i < speed1.Length - 1; i++)
            {
                if (speed1[i] != 0 && speed1[i + 1] == 0)
                {
                    TurnOffTime += time[i];
                }
            }
            return TurnOffTime;
        }


        //效率问题
        public static string efficiency(int[] speed)
        {
            double count = 0.0;
            for (int i = 0; i < speed.Length;i++ )
            {
                if (speed[i] != 0)
                {
                    count++;
                }
            }
            return (count / speed.Length).ToString("P");
        }
        
    }
}
