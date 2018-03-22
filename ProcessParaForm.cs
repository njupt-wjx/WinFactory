using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCPClient
{
    public partial class ProcessParaForm : Form
    {
        private double SpindleSpeed,MainShaftSpeed,NfrSpeed,NbrSpeed,
                        Tex,Dt,T,P;
        public ProcessParaForm()
        {
            InitializeComponent();
        }

        private void ProcessParaForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_selectedIndexChange(object sender, EventArgs e)
        {
            txtMainShaftSpeed.Text = "0";
            txtNfrSpeed.Text = "0";
            txtNbrSpeed.Text = "0";
            txtSpindleSpeed.Text = "0";
            txtTex.Text = "0";
            txtDt.Text = "0";
            txtT.Text = "0";
            txtP.Text = "0";
            MyDatabase DataBase = new MyDatabase();
            // select * from 表名 limit 1;第一条
            //mysql> select * from apple order by id desc LIMIT 1;最后一条
            string sql = "select Speed1,Speed2,Speed4,dingSpeed from " + comboBox1.Text.ToString() + " order by ID desc limit 1";
            MySqlDataReader sdr = DataBase.getReader(sql);
            sdr.Read();
            if (sdr.HasRows)
            {
                txtMainShaftSpeed.Text = sdr["Speed1"].ToString().Trim();//主轴
                MainShaftSpeed = Double.Parse(txtMainShaftSpeed.Text);

                txtNfrSpeed.Text = sdr["Speed2"].ToString().Trim();//前罗拉
                NfrSpeed = Double.Parse(txtNfrSpeed.Text);

                txtNbrSpeed.Text = sdr["Speed4"].ToString().Trim();//后罗拉
                NbrSpeed = Double.Parse(txtNbrSpeed.Text);

                txtSpindleSpeed.Text = sdr["dingSpeed"].ToString().Trim();//锭速
                SpindleSpeed = Double.Parse(txtSpindleSpeed.Text);
            
                combD.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if (NbrSpeed!=0.0)
           {
               Dt = NfrSpeed / NbrSpeed;
               txtDt.Text = Dt.ToString("0.00");//牵伸倍数,保留两位小数
           }
           else
           {
               txtDt.Text = "0.00";
           }
            ////////////////////////////////////
           if (txtRov.Text != "" && Dt != 0)
           {
               Tex = Double.Parse(txtRov.Text) / Dt;//细纱号数
               txtTex.Text = Tex.ToString("0.00");
           }
           else
           {
               txtTex.Text = "0.00";
           }
            ///////////////////////////////////
            if (NfrSpeed != 0)
            {
                T = (1000*SpindleSpeed)/(3.14*Double.Parse(combDr.Text)*NfrSpeed);//捻度
                txtT.Text = T.ToString("0.00");
            }
            else
            {
                txtT.Text = "0.00";
            }
            ////////////////////////////////////
            if (T!=0)
            {
                P = (SpindleSpeed * 60 * Tex * 1000) / (T * 1000 * 1000);//千锭小时产量
                txtP.Text = P.ToString("0.00");
            }
            else
            {
                txtP.Text = "0.00";
            }

        }
    }
}
