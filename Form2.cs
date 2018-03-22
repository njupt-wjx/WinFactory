using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace TCPClient
{
    public partial class Form2 : Form
    {
        string[] Date;
        string[] wDate;
        MyDatabase myDatabase = new MyDatabase();
        public Form2()
        {
            InitializeComponent();

            ///////////////重绘窗口大小////////////////////////
            int count = this.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = Size.Width;
            factor[i++] = Size.Height;
            foreach (Control ctrl in this.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)Size.Width;
                factor[i++] = ctrl.Location.Y / (float)Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            Tag = factor;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            chart1.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart1_GetToolTipText); //注册鼠标绕过提示 
            chart2.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart2_GetToolTipText);
            //chart初始化
            InitChart1();
            InitChart2();
            dateTimePicker1_ValueChanged(sender, e);

        }


        //chart初始化
        private void InitChart1()
        {
            //定义图表区
            chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            chart1.ChartAreas.Add(chartArea1);

            //定义存储和显示点的容器
            chart1.Series.Clear();
            Series series1 = new Series("锭速");//Series[0]
            chart1.Series.Add(series1);

            Series series2 = new Series("前罗拉转速");//Series[1]
            chart1.Series.Add(series2);

            //第二个轴
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            series2.YAxisType = AxisType.Secondary;
            chart1.ChartAreas[0].AxisY2.Minimum = 0;
            chart1.ChartAreas[0].AxisY2.Maximum = 300;
            chart1.ChartAreas[0].AxisY2.Interval = 20;
            this.chart1.ChartAreas[0].AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //Series series3 = new Series("中罗拉转速");//Series[2]
            //chart1.Series.Add(series3);

            //Series series4 = new Series("后罗拉转速");//Series[3]
            //chart1.Series.Add(series4);

            //Series series5 = new Series("S5");//Series[4]
            //chart1.Series.Add(series5);

            //Series series6 = new Series("S6");//Series[5]
            //chart1.Series.Add(series6);

            //设置图表的样式
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;//显示横纵坐标轴
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;


            chart1.ChartAreas[0].AxisY.Minimum = 0;//Y轴范围
            chart1.ChartAreas[0].AxisY.Maximum = 12000;

            //chart1.ChartAreas[0].AxisX.Minimum = 1;//X轴范围
            //chart1.ChartAreas[0].AxisX.Maximum = 20;

            //chart1.ChartAreas[0].AxisX.Interval = 1;//X轴间隔

            chart1.ChartAreas[0].AxisY.Interval = 800;//Y轴间隔
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.Red;

            //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;//网络线
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;


            //设置图标
            chart1.Titles.Clear();
            chart1.Titles.Add("S01");
            chart1.Titles[0].Text = "白班运行记录";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            //设置图表样式
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart1.Series[0].ChartType = SeriesChartType.Line;//折线图
            chart1.Series[0].MarkerSize = 4;
            chart1.Series[0].Points.Clear();

            chart1.Series[1].Color = Color.Blue;
            chart1.Series[1].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart1.Series[1].ChartType = SeriesChartType.Line;//折线图
            chart1.Series[1].MarkerSize = 4;
            chart1.Series[1].Points.Clear();

            //chart1.Series[2].Color = Color.Yellow;
            //chart1.Series[2].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart1.Series[2].ChartType = SeriesChartType.Line;//折线图
            //chart1.Series[2].Points.Clear();

            //chart1.Series[3].Color = Color.Green;
            //chart1.Series[3].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart1.Series[3].ChartType = SeriesChartType.Line;//折线图
            //chart1.Series[3].Points.Clear();

            //chart1.Series[4].Color = Color.Blue;
            //chart1.Series[4].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart1.Series[4].ChartType = SeriesChartType.Line;//折线图
            //chart1.Series[4].Points.Clear();

            //chart1.Series[5].Color = Color.Cyan;
            //chart1.Series[5].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart1.Series[5].ChartType = SeriesChartType.Line;//折线图
            //chart1.Series[5].Points.Clear();

            // Zoom into the X axis
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(2, 3);

            // Enable range selection and zooming end user interface
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            // 设置滚动条的大小
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 15;

            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom;

            // 设置自动放大与缩小的最小量
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 5;
        }

        private void InitChart2()
        {
            //定义图表区
            chart2.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C2");
            chart2.ChartAreas.Add(chartArea1);

            //定义存储和显示点的容器
            chart2.Series.Clear();
            Series series1 = new Series("锭速");//Series[0]
            chart2.Series.Add(series1);

            Series series2 = new Series("前罗拉转速");//Series[1]
            chart2.Series.Add(series2);

            //第二个轴
            chart2.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            series2.YAxisType = AxisType.Secondary;
            chart2.ChartAreas[0].AxisY2.Minimum = 0;
            chart2.ChartAreas[0].AxisY2.Maximum = 300;
            chart2.ChartAreas[0].AxisY2.Interval = 20;
            this.chart2.ChartAreas[0].AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //Series series3 = new Series("中罗拉转速");//Series[2]
            //chart2.Series.Add(series3);

            //Series series4 = new Series("后罗拉转速");//Series[3]
            //chart2.Series.Add(series4);

            //Series series5 = new Series("S5");//Series[4]
            //chart2.Series.Add(series5);

            //Series series6 = new Series("S6");//Series[5]
            //chart2.Series.Add(series6);

            //设置图表的样式
            chart2.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;//显示横纵坐标轴
            chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            this.chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.Red;

            chart2.ChartAreas[0].AxisY.Minimum = 0;//Y轴范围
            chart2.ChartAreas[0].AxisY.Maximum = 12000;

            //chart1.ChartAreas[0].AxisX.Minimum = 1;//X轴范围
            //chart1.ChartAreas[0].AxisX.Maximum = 20;

            //chart1.ChartAreas[0].AxisX.Interval = 1;//X轴间隔

            chart2.ChartAreas[0].AxisY.Interval = 800;//Y轴间隔

            //this.chart1.ChartAreas[0].AxisY.IsLogarithmic = true;
            //this.ct_coll.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;  
            //chartArea1.AxisX.IsLogarithmic = true;

            //chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;//网络线
            //chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;


            //设置图标
            chart2.Titles.Clear();
            chart2.Titles.Add("S01");
            chart2.Titles[0].Text = "晚班运行记录";
            this.chart2.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart2.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            //设置图表样式
            chart2.Series[0].Color = Color.Red;
            chart2.Series[0].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart2.Series[0].ChartType = SeriesChartType.Line;//折线图
            chart2.Series[0].MarkerSize = 4;
            chart2.Series[0].Points.Clear();

            chart2.Series[1].Color = Color.Blue;
            chart2.Series[1].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart2.Series[1].ChartType = SeriesChartType.Line;//折线图
            chart2.Series[1].MarkerSize = 4;
            chart2.Series[1].Points.Clear();

            //chart2.Series[2].Color = Color.Yellow;
            //chart2.Series[2].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart2.Series[2].ChartType = SeriesChartType.Line;//折线图
            //chart2.Series[2].Points.Clear();

            //chart2.Series[3].Color = Color.Green;
            //chart2.Series[3].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart2.Series[3].ChartType = SeriesChartType.Line;//折线图
            //chart2.Series[3].Points.Clear();

            //chart2.Series[4].Color = Color.Blue;
            //chart2.Series[4].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart2.Series[4].ChartType = SeriesChartType.Line;//折线图
            //chart2.Series[4].Points.Clear();

            //chart2.Series[5].Color = Color.Cyan;
            //chart2.Series[5].MarkerStyle = MarkerStyle.Circle;//圆形点
            //chart2.Series[5].ChartType = SeriesChartType.Line;//折线图
            //chart2.Series[5].Points.Clear();

            // Zoom into the X axis
            //chart2.ChartAreas[0].AxisX.ScaleView.Zoom(2, 3);

            // Enable range selection and zooming end user interface
            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            // 设置滚动条的大小
            chart2.ChartAreas[0].AxisX.ScrollBar.Size = 15;

            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            chart2.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom;

            // 设置自动放大与缩小的最小量
            chart2.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart2.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 5;

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //先将控件清空
            label1.Text = "一共有0条记录";
            label3.Text = "白班效率";
            dayOnLong.Text = "白班运行时长";
            dayOffLong.Text = "白班停车时长";
            label2.Text = "一共有0条记录";
            label4.Text = "晚班效率";
            nightOnLong.Text = "晚班运行时长";
            nightOffLong.Text = "晚班停车时长";

            string curdate = dateTimePicker1.Text.ToString();
            string beforedate = dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd");
            //string sql = null;
            //MySqlConnection conn = new MySqlConnection("Host =localhost;Database=factory;Username=root;Password=123456");

            //数据库表名必须与comboBox下拉名相同
            string sql = "select Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,Date,dingSpeed from " + comboBox1.Text.ToString() + " where Date between" + "'" + beforedate + " 07:30:00" + "'"
                                               + " and " + "'" + beforedate + " 19:30:00" + "'";
            string sql1 = "select Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,Date,dingSpeed from " + comboBox1.Text.ToString() + " where Date between" + "'" + beforedate + " 19:30:00" + "'"
                                               + " and " + "'" + curdate + " 07:30:00" + "'";

            DataSet ds = myDatabase.getDataSet(sql, "CS");
            DataSet ds1 = myDatabase.getDataSet(sql1, "CS1");

            int count;
            int count1;

            count = ds.Tables[0].Rows.Count;
            count1 = ds1.Tables[0].Rows.Count;

            label1.Text = "昨天白班共有" + count.ToString() + "条记录";//显示行数
            label2.Text = "昨天晚班共有" + count1.ToString() + "条记录";//显示行数

            //白班
            int[] speed1 = new int[count];
            int[] speed2 = new int[count];
            int[] speed3 = new int[count];
            int[] speed4 = new int[count];
            int[] speed5 = new int[count];
            int[] speed6 = new int[count];
            Date = new string[count];
            int[] dingSpeed = new int[count];

            //晚班
            int[] wspeed1 = new int[count1];
            int[] wspeed2 = new int[count1];
            int[] wspeed3 = new int[count1];
            int[] wspeed4 = new int[count1];
            int[] wspeed5 = new int[count1];
            int[] wspeed6 = new int[count1];
            wDate = new string[count1];
            int[] wdingSpeed = new int[count1];

            int i = 0, j = 0, k = 0, l = 0, m = 0, n = 0, d = 0, h = 0;
            int i1 = 0, j1 = 0, k1 = 0, l1 = 0, m1 = 0, n1 = 0, d1 = 0, h1 = 0;
            double dayEfficiency = 0.0;
            double nightEfficiency = 0.0;
            foreach (DataRow row in ds.Tables[0].Rows)//遍历所有行
            {

                speed1[i++] = int.Parse(row[0].ToString());//row[0]表示第一列
                speed2[j++] = int.Parse(row[1].ToString());
                speed3[k++] = int.Parse(row[2].ToString());
                speed4[l++] = int.Parse(row[3].ToString());
                speed5[m++] = int.Parse(row[4].ToString());
                speed6[n++] = int.Parse(row[5].ToString());
                Date[d++] = DateTime.Parse(row[6].ToString()).ToString("HH:mm");
                dingSpeed[h++] = int.Parse(row[7].ToString());
                if (speed1[i - 1] != 0)
                {
                    dayEfficiency++;
                }

            }

            //MessageBox.Show("" + dayEfficiency);
            foreach (DataRow row in ds1.Tables[0].Rows)//遍历所有行
            {

                wspeed1[i1++] = int.Parse(row[0].ToString());//row[0]表示第一列
                wspeed2[j1++] = int.Parse(row[1].ToString());
                wspeed3[k1++] = int.Parse(row[2].ToString());
                wspeed4[l1++] = int.Parse(row[3].ToString());
                wspeed5[m1++] = int.Parse(row[4].ToString());
                wspeed6[n1++] = int.Parse(row[5].ToString());
                wDate[d1++] = DateTime.Parse(row[6].ToString()).ToString("HH:mm");
                wdingSpeed[h1++] = int.Parse(row[7].ToString());
                if (wspeed1[i1 - 1] != 0)
                {
                    nightEfficiency++;
                }

            }
            //白班
            if (count == 0)
            {
                label3.Text = "白班效率：0.00%";
            }
            else
            {
                label3.Text = "白班效率：" + (dayEfficiency / count).ToString("P");
                dayOnLong.Text = "运行时间：" + (dayEfficiency / count * 12).ToString("f2");
                dayOffLong.Text = "停车时间：" + (12 - (dayEfficiency / count * 12)).ToString("f2");
            }


            //晚班
            if (count1 == 0)
            {
                label4.Text = "晚班效率：0.00%";
            }
            else
            {
                label4.Text = "晚班效率:" + (nightEfficiency / count1).ToString("P");
                nightOnLong.Text = "运行时间: " + ((nightEfficiency / count1) * 12).ToString("f2");
                nightOffLong.Text = "停车时间: " + (12 - ((nightEfficiency / count1) * 12)).ToString("f2");
            }


            ///////////////////////////////////////////////////////////////////////////////////
            drawLine(dingSpeed, speed1, speed2, speed3, speed4, speed5, speed6, Date);
            wdrawLine(wdingSpeed, wspeed1, wspeed2, wspeed3, wspeed4, wspeed5, wspeed6, wDate);

            MyDatabase.mysqlConn.Close();
            MyDatabase.mysqlConn.Dispose();
            chart1.Focus();
        }

        //白班画图
        public void drawLine(int[] dingSpeed, int[] speed1, int[] speed2, int[] speed3, int[] speed4, int[] speed5, int[] speed6, string[] date)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            //this.chart1.Series[2].Points.Clear();
            //this.chart1.Series[3].Points.Clear();
            //this.chart1.Series[4].Points.Clear();
            //this.chart1.Series[5].Points.Clear();
            for (int i = 0; i < speed1.Length; i++)//因为speed1的长度与其他speed长度一样
            {
                this.chart1.Series[0].Points.AddXY(date[i], dingSpeed[i]);
                this.chart1.Series[1].Points.AddXY(date[i], speed2[i]);
                //this.chart1.Series[2].Points.AddXY(date[i], speed3[i]);
                //this.chart1.Series[3].Points.AddXY(date[i], speed4[i]);
                //this.chart1.Series[4].Points.AddXY(date[i], speed5[i]);
                //this.chart1.Series[5].Points.AddXY(date[i], speed6[i]);
            }
        }
        //晚班画图
        public void wdrawLine(int[] dingSpeed, int[] speed1, int[] speed2, int[] speed3, int[] speed4, int[] speed5, int[] speed6, string[] date)
        {
            this.chart2.Series[0].Points.Clear();
            this.chart2.Series[1].Points.Clear();
            //this.chart2.Series[2].Points.Clear();
            //this.chart2.Series[3].Points.Clear();
            //this.chart2.Series[4].Points.Clear();
            //this.chart2.Series[5].Points.Clear();
            for (int i = 0; i < speed1.Length; i++)//因为speed1的长度与其他speed长度一样
            {
                this.chart2.Series[0].Points.AddXY(date[i], dingSpeed[i]);
                this.chart2.Series[1].Points.AddXY(date[i], speed2[i]);
                //this.chart2.Series[2].Points.AddXY(date[i], speed3[i]);
                //this.chart2.Series[3].Points.AddXY(date[i], speed4[i]);
                //this.chart2.Series[4].Points.AddXY(date[i], speed5[i]);
                //this.chart2.Series[5].Points.AddXY(date[i], speed6[i]);
            }
        }

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];

                string time = Date[i];
                //分别显示x轴和y轴的数值，其中{1:F3},表示显示的是float类型，精确到小数点后3位。   
                // e.Text = string.Format("次数:{0};数值:{1:F1} ", dp.XValue, dp.YValues[0]);
                e.Text = string.Format("时间:{0}\n转速:{1} ", time, dp.YValues[0]);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1_ValueChanged(sender, e);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            float[] scale = (float[])Tag;
            int i = 2;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Left = (int)(Size.Width * scale[i++]);
                ctrl.Top = (int)(Size.Height * scale[i++]);
                ctrl.Width = (int)(Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                ctrl.Height = (int)(Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);
            }

            //每次使用的都是最初始的控件大小，保证准确无误。
        }





        private void Export_Excel_Click(object sender, EventArgs e)
        {
            //导出excel
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return;//点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            CExportExcel.MergeCells(worksheet, 1, 1, 1, 7, date + " 生产情况");
            CExportExcel.MergeCells(worksheet, 2, 1, 22, 1, "白班");
            CExportExcel.MergeCells(worksheet, 23, 1, 42, 1, "晚班");
            worksheet.Cells[2, 2] = "机器号";
            worksheet.Cells[2, 3] = "开车时刻";
            worksheet.Cells[2, 4] = "停车时刻";
            worksheet.Cells[2, 5] = "效率";
            worksheet.Cells[2, 6] = "产量";
            worksheet.Cells[2, 7] = "开车时间间隔";
            worksheet.Cells[2, 8] = "停车时间间隔";
            worksheet.Cells[2, 9] = "运行时长";
            worksheet.Cells[2, 10] = "停车时长";
            for (int i = 1; i <= 20; i++)
            {
                worksheet.Cells[i + 2, 2] = "M" + i.ToString();
                worksheet.Cells[i + 22, 2] = "M" + i.ToString();
            }
            CExportExcel.HVCenterAlign(worksheet, 2, 2, 42, 10);
            //CExportExcel.ExportExcel();
            string curdate = dateTimePicker1.Text.ToString();
            string beforedate = dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd");
            for (int machine = 1; machine <= 20; machine++)
            {
                string sql = "select Speed1,Date from " + "M" + machine.ToString() + " where Date between" + "'" + beforedate + " 07:30:00" + "'"
                                              + " and " + "'" + beforedate + " 19:30:00" + "'";
                string nightsql = "select Speed1,Date from " + "M" + machine.ToString() + " where Date between" + "'" + beforedate + " 19:30:00" + "'"
                                                   + " and " + "'" + curdate + " 07:30:00" + "'";
                //string sql = "select Speed1,Date from " + "M" + machine.ToString() + " where Date between" + "'" + curdate + " 07:30:00" + "'"
                //                              + " and " + "'" + curdate + " 19:30:00" + "'";
                //string nightsql = "select Speed1,Date from " + "M" + machine.ToString() + " where Date between" + "'" + curdate + " 19:30:00" + "'"
                //                                   + " and " + "'" + curdate + " 20:30:00" + "'";
                DataSet ds = myDatabase.getDataSet(sql, "CS");
                DataSet nightds = myDatabase.getDataSet(nightsql, "nightCS");

                int count;
                int nightcount;
                count = ds.Tables[0].Rows.Count;
                nightcount = nightds.Tables[0].Rows.Count;
                //白班
                int[] speed1 = new int[count];
                string[] Date = new string[count];
                //晚班
                int[] nightspeed1 = new int[nightcount];
                string[] nightDate = new string[nightcount];
                int i = 0, d = 0;
                int i1 = 0, d1 = 0;
                //效率
                double dayEfficiency = 0.0;
                double nightEfficiency = 0.0;

                foreach (DataRow row in ds.Tables[0].Rows)//遍历所有行
                {

                    speed1[i++] = int.Parse(row[0].ToString());//row[0]表示第一列
                    Date[d++] = DateTime.Parse(row[1].ToString()).ToString("HH:mm");
                    if (speed1[i - 1] != 0)
                    {
                        dayEfficiency++;
                    }
                }
                if (count == 0)
                {
                    worksheet.Cells[machine + 2, 5] = "";
                }
                else
                {
                    worksheet.Cells[machine + 2, 5] = (dayEfficiency / count).ToString("P");
                    worksheet.Cells[machine + 2, 9] = (dayEfficiency / count * 12).ToString("f2");
                    worksheet.Cells[machine + 2, 10] = (12 - dayEfficiency / count * 12).ToString("f2");
                }


                foreach (DataRow row in nightds.Tables[0].Rows)//遍历所有行
                {
                    nightspeed1[i1++] = int.Parse(row[0].ToString());//row[0]表示第一列
                    nightDate[d1++] = DateTime.Parse(row[1].ToString()).ToString("HH:mm");
                    if (nightspeed1[i1 - 1] != 0)
                    {
                        nightEfficiency++;
                    }
                }
                if (nightcount == 0)
                {
                    worksheet.Cells[machine + 22, 5] = "";
                }
                else
                {
                    worksheet.Cells[machine + 22, 5] = (nightEfficiency / nightcount).ToString("P");
                    worksheet.Cells[machine + 22, 9] = (nightEfficiency / nightcount * 12).ToString("f2");
                    worksheet.Cells[machine + 22, 10] = (12 - nightEfficiency / nightcount * 12).ToString("f2");
                }

                //////////////////////////////////////////////////////////////////////////////////////

            }

            MyDatabase.mysqlConn.Close();
            MyDatabase.mysqlConn.Dispose();
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应 
            if (saveFileName != null)
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("导出文件可能出错" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("导出Excel成功", "提示", MessageBoxButtons.OK);
        }


        private void chart2_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                string time = wDate[i];
                //分别显示x轴和y轴的数值，其中{1:F3},表示显示的是float类型，精确到小数点后3位。   
                // e.Text = string.Format("次数:{0};数值:{1:F1} ", dp.XValue, dp.YValues[0]);
                e.Text = string.Format("时间:{0}\n转速:{1} ", time, dp.YValues[0]);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }



        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult myTestResult = chart1.HitTest(e.X, e.Y);
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                //this.Cursor = Cursors.Cross;  
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string time = Date[i];
                MyDatabase.mysqlConn.Close();
                MyDatabase.mysqlConn.Dispose();
                MessageBox.Show("时间：" + time + "\n" + "转速：" + dp.YValues[0]);
            }
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult myTestResult = chart2.HitTest(e.X, e.Y);
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                //this.Cursor = Cursors.Cross;  
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string time = wDate[i];
                MyDatabase.mysqlConn.Close();
                MyDatabase.mysqlConn.Dispose();
                MessageBox.Show("时间：" + time + "\n" + "转速：" + dp.YValues[0]);
            }
        }
    }
}
