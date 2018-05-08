using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Web;
using System.IO;
namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Socket newclient;
        //public bool Connected;
        public Thread myThread;
        public delegate void MyInvoke(string str);
        MyDatabase myDatabase = new MyDatabase();
        SynchronizationContext m_SyncContext = null;//获取UI线程同步上下文

      /// <summary>
      /// ///////////////////////////////////////////////
      /// </summary>
        public bool btnstatu = true;  //开始停止服务按钮状态
        //public Thread myThread;       //声明一个线程实例
        public Socket newsock;        //声明一个Socket实例
        public Socket server1;
        public Socket Client;
        //public delegate void MyInvoke(string str);
        public IPEndPoint localEP;
        public int localPort;
        public EndPoint remote;
        public Hashtable _sessionTable;
        public bool m_Listening;

        
        int errCount = 0;//发送错误次数

        int i = 0;
        int j = 0;
        int machineNumber;
        string machineNumberStr;

        string headStr;
        int head, speed1=0, speed2=0, speed3=0, speed4=0, speed5=0,speed6=0,dingSpeed=0;

        int byteCount = 32;
        public Form1()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;

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

        //当有客户端连接时的处理
        public void OnConnectRequest(IAsyncResult ar)
        {
            //初始化一个SOCKET，用于其它客户端的连接
            server1 = (Socket)ar.AsyncState;
            Client = server1.EndAccept(ar);

            //将要发送给连接上来的客户端的提示字符串
            //DateTimeOffset now = DateTimeOffset.Now;
            //timer2.Enabled = true;
            this.Invoke((MethodInvoker)delegate
            {
                timer2.Enabled = true;
            });

            string strDateLine = "success";
            Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
            //将提示信息发送给客户端,并在服务端显示连接信息。
            remote = Client.RemoteEndPoint;

            //showMsg(Client.RemoteEndPoint.ToString() + "连接成功。" + "\r\n");
            showMsg("连接成功。" + "\r\n");

            Client.Send(byteDateLine, byteDateLine.Length, 0);
            userListOperate(Client.RemoteEndPoint.ToString());
            //把连接成功的客户端的SOCKET实例放入哈希表
            _sessionTable.Add(Client.RemoteEndPoint, null);

            //等待新的客户端连接
            server1.BeginAccept(new AsyncCallback(OnConnectRequest), server1);

            while (true)
            {
                try
                {
                    //byte[] data = new byte[1024];
                    //int recv = Client.Receive(data);
                    //string stringdata = Encoding.UTF8.GetString(data, 0, 32);
                    //showMsg(stringdata + "\r\n");
                    //m_SyncContext.Post(setTextSafePost, stringdata);
                    byte[] data = new byte[9];
                   // int recv = Client.Receive(data);
                    int recv = Client.Receive(data);//string stringdata = Encoding.UTF8.GetString(data, 0, 32);
                    int head1 = (int)data[0];
                    int s1 = (((int)data[1]) << 8) | data[2];
                    int s2 = ((int)data[3] << 8) | data[4];
                    int s3 = ((int)data[5] << 8) | data[6];
                    int s4 = ((int)data[7] << 8) | data[8];
                    //int s5 = ((int)data[9] << 8) | data[10];
                    //int s6 = ((int)data[11] << 8) | data[12];

                    string headstr;
                    if (head1 < 10)
                    {
                        headstr = "0" + head1.ToString();
                    }
                    else headstr = head1.ToString();

                    string stringdata = headstr + "#"
                                        + s1.ToString() + "#"
                                        + s2.ToString() + "#"
                                        + s3.ToString() + "#"
                                        + s4.ToString()+"#0000#0000";
                    showMsg("\r\n" + stringdata + "\r\n");

                    //receiveMsg.AppendText(stringdata + "\r\n");

                    m_SyncContext.Post(setTextSafePost, stringdata);

                }
                catch (System.Exception ex)
                {

                }
            }

        }


        private void setTextSafePost(object text)
        {
            
            string str = text.ToString();
            int count = str.Length;
            //string str = str1.Substring(0, 32);
            string str1 = str.Substring(0, 3);
            if (count <= byteCount)
            {
                if (str1 == "01#"
                    || str1 == "02#"
                    || str1 == "03#"
                    || str1 == "04#"
                    || str1 == "05#"
                    || str1 == "06#"
                    || str1 == "07#"
                    || str1 == "08#"
                    || str1 == "09#"
                    || str1 == "10#"
                    || str1 == "11#"
                    || str1 == "12#"
                    || str1 == "13#"
                    || str1 == "14#"
                    || str1 == "15#"
                    || str1 == "16#"
                    || str1 == "17#"
                    || str1 == "18#"
                    || str1 == "19#"
                    || str1 == "20#")
                {
                    //MessageBox.Show("正常");
                    string[] arr = str.Split('#');

                    headStr = arr[0].ToString();
                    head = int.Parse(arr[0]);
                    speed1 = int.Parse(arr[1]);
                    speed2 = int.Parse(arr[2]);
                    speed3 = int.Parse(arr[3]);
                    speed4 = int.Parse(arr[4]);
                    speed5 = int.Parse(arr[5]);
                    speed6 = int.Parse(arr[6]);
                    if (String.IsNullOrEmpty(textBox6.Text))
                    {
                        dingSpeed = 0;
                    }
                    else 
                    {
                        dingSpeed = (int)(speed1 * double.Parse(textBox6.Text));
                    }

                    
                    //M1
                    if (machineNumberStr == headStr)
                    {
                        string hms = DateTime.Now.ToString("HH:mm");
                        //DateTime hms = DateTime.Now;
                        this.chart1.Series[0].Points.AddXY(hms, dingSpeed);
                        this.chart1.Series[1].Points.AddXY(hms, speed2);
                        //this.chart1.Series[1].Points.AddY(speed2);
                        //this.chart1.Series[2].Points.AddXY(hms, speed3);
                        //this.chart1.Series[3].Points.AddXY(hms, speed4);
                        //this.chart1.Series[4].Points.AddXY(hms, speed5);
                        //this.chart1.Series[5].Points.AddXY(hms, speed6);
                        textBox1.Text = speed1.ToString();
                        textBox2.Text = speed2.ToString();
                        textBox3.Text = speed3.ToString();
                        textBox4.Text = speed4.ToString();
                        //textBox5.Text = speed5.ToString();
                        //textBox6.Text = speed6.ToString();
                        textBox5.Text = dingSpeed.ToString();
                        textBox7.Text = head.ToString();
                        if (String.IsNullOrEmpty(stanardspeed.Text))
                        {    
                        }
                        else
                        {
                            if (dingSpeed <= int.Parse(stanardspeed.Text) - 100 || dingSpeed >= int.Parse(stanardspeed.Text) + 100)
                            {
                                textBox5.BackColor = Color.Red;
                            }
                            else
                            {
                                textBox5.BackColor = Color.White;
                            }
                        }

                        
                        if (hms.Equals("00:00"))
                        {
                            //i = 0;
                            this.chart1.Series[0].Points.Clear();
                            this.chart1.Series[1].Points.Clear();
                            //this.chart1.Series[2].Points.Clear();
                            //this.chart1.Series[3].Points.Clear();
                            //this.chart1.Series[4].Points.Clear();
                            //this.chart1.Series[5].Points.Clear();
                            receiveMsg.Text = "";
                        }
                    }

                    //提交到远程数据库中
                    try
                    {
                        string postSpeed = head.ToString() + " "
                                          + speed1.ToString() + " "
                                          + speed2.ToString() + " "
                                          + speed3.ToString() + " "
                                          + speed4.ToString() + " "
                                          + speed5.ToString() + " "
                                          + speed6.ToString() + " "
                                          + dingSpeed.ToString();
                        string url = "http://localhost:8081/Factory/ReceiveSpeedServlet?postSpeed=" + postSpeed;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "POST";
                        using (WebResponse wr = request.GetResponse())
                        {
                            //在这里对接收到的页面内容进行处理
                        }
                        
                    }
                    catch (Exception e)
                    {
                    }
                    //根据Head分别插入数据库
                    //dataBae.insertDataToDatabase(head, speed1, speed2, speed3, speed4, speed5, speed6);

                    myDatabase.insertSpeedToDatabase(head, speed1, speed2, speed3, speed4, speed5,speed6, dingSpeed);
                    //timer1.Enabled = false;
                    //timer1.Interval = 30000;
                    //timer1.Enabled = true;
                }


            }
            else
            {
                //errCount++;
                //MessageBox.Show("不正常");
                if (errCount == 5)
                {
                    //MessageBox.Show("发送数据不正常");
                    errCount = 0;
                }
            }

        }

        public void showMsg(string msg)
        {
            {
                //在线程里以安全方式调用控件
                if (receiveMsg.InvokeRequired)
                {
                    MyInvoke _myinvoke = new MyInvoke(showMsg);
                    receiveMsg.Invoke(_myinvoke, new object[] { msg });

                }
                else
                {
                    receiveMsg.AppendText(msg);
                }
            }
        }


        private void SendMsg_Click(object sender, EventArgs e)
        {
            int m_length = mymessage.Text.Length;
            byte[] data = new byte[m_length];
            data = Encoding.UTF8.GetBytes(mymessage.Text);
            remote = Client.RemoteEndPoint;
            Client.Send(data, data.Length, 0);
            showMsg("我说：" + mymessage.Text + "\r\n");
            //receiveMsg.AppendText("我说："+mymessage.Text + "\r\n");
            mymessage.Text = "";
            //newclient.Shutdown(SocketShutdown.Both);
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myThread != null)
            {
                //myThread.Abort();  
            }
            e.Cancel = true;
        }




        ////////////////////////////////////////////////////// 
        private void Form1_Load(object sender, EventArgs e)
        {
            //close.Enabled = false;//初始化断开按钮
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
            //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];
            hostIp.Text = "主机IP:" + localaddr.ToString();
            InitChart();
        }
        

        //当选中发生变化时应该清除ponits
        private void comboBox1_selectedIndexChange(object sender, EventArgs e)
        {

            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            //this.chart1.Series[2].Points.Clear();
            //this.chart1.Series[3].Points.Clear();
            //this.chart1.Series[4].Points.Clear();
            //this.chart1.Series[5].Points.Clear();
            ///////////////
            string date = DateTime.Now.ToString("yyyy-MM-dd");//2008-9-4
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//2008-9-4 20:02:10
            string sql = "select Speed1,Speed2,Speed3,Speed4,Speed5,Speed6,Date,dingSpeed from " + comboBox1.Text.ToString() + " where Date between" + "'" + date + " 00:00:00" + "'"
                                               + "and" + "'" + datetime + "'";
            DataSet ds = myDatabase.getDataSet(sql, "CS1");
            int count = 0;
            count = ds.Tables[0].Rows.Count;
            
            int[] speed1 = new int[count];
            int[] speed2 = new int[count];
            int[] speed3 = new int[count];
            int[] speed4 = new int[count];
            int[] speed5 = new int[count];
            int[] speed6 = new int[count];
            string[] Date = new string[count];
            int[] dingSpeed = new int[count];

            int i = 0, j = 0, k = 0, l = 0, m = 0, n = 0, d = 0,h=0;
            foreach (DataRow row in ds.Tables[0].Rows)//遍历所有行
            {
                speed1[i++] = int.Parse(row[0].ToString());//row[0]表示第一列
                speed2[j++] = int.Parse(row[1].ToString());
                speed3[k++] = int.Parse(row[2].ToString());
                speed4[l++] = int.Parse(row[3].ToString());
                speed5[m++] = int.Parse(row[4].ToString());
                speed6[n++] = int.Parse(row[5].ToString());
                Date[d++] = DateTime.Parse(row[6].ToString()).ToString("HH:mm:ss");
                dingSpeed[h++] = int.Parse(row[7].ToString());

            }

            drawLine(dingSpeed,speed1, speed2, speed3, speed4, speed5, speed6, Date);

            MyDatabase.mysqlConn.Close();
            MyDatabase.mysqlConn.Dispose();


            ////////////////////////////
            machineNumber = comboBox1.SelectedIndex + 1;
            if (machineNumber < 10)
            {
                machineNumberStr = "0" + machineNumber.ToString();
            }
            else
            {
                machineNumberStr = machineNumber.ToString();
            }

            i = 0;
            textBox7.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            chart1.Focus();
        }

        public void drawLine(int[] dingSpeed,int[] speed1, int[] speed2, int[] speed3, int[] speed4, int[] speed5, int[] speed6, string[] date)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            //this.chart1.Series[2].Points.Clear();
            //this.chart1.Series[3].Points.Clear();
            //this.chart1.Series[4].Points.Clear();
            //this.chart1.Series[5].Points.Clear();
            for (int i = 0; i < speed1.Length; i++)//因为speed1的长度与其他speed长度一样
            {
                this.chart1.Series[0].Points.AddXY(date[i], dingSpeed[i]);//锭速
                this.chart1.Series[1].Points.AddXY(date[i], speed2[i]);//前罗拉
                //this.chart1.Series[2].Points.AddXY(date[i], speed3[i]);
                //this.chart1.Series[3].Points.AddXY(date[i], speed4[i]);
                //this.chart1.Series[4].Points.AddXY(date[i], speed5[i]);
                //this.chart1.Series[5].Points.AddXY(date[i], speed6[i]);
            }
        }

        private void InitChart()
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

            //坐标轴标题
            //this.chart1.ChartAreas[0].AxisX.Title = "时间";
            //this.chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
            //this.chart1.ChartAreas[0].AxisY.Title = "r/min";
            //this.chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
            //this.chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;

            //Series series3 = new Series("中罗拉转速");//Series[2]
            //chart1.Series.Add(series3);

            //Series series4 = new Series("后罗拉转速");//Series[3]
            //chart1.Series.Add(series4);

            //Series series5 = new Series("S5");//Series[4]
            //chart1.Series.Add(series5);

            //Series series6 = new Series("S6");//Series[5]
            //chart1.Series.Add(series6);
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            //设置图表的样式
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;//显示横纵坐标轴
            //chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisX.Minimum = 24;
            //chart1.ChartAreas[0].AxisX.Interval = 1;//Y轴间隔

            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisY.Minimum = 0;//Y轴范围
            chart1.ChartAreas[0].AxisY.Maximum = 12000;
            chart1.ChartAreas[0].AxisY.Interval = 800;//Y轴间隔
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.Red;
            //第二个轴
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            series2.YAxisType = AxisType.Secondary;
            chart1.ChartAreas[0].AxisY2.Minimum = 0;
            chart1.ChartAreas[0].AxisY2.Maximum = 300;
            chart1.ChartAreas[0].AxisY2.Interval = 20;
            this.chart1.ChartAreas[0].AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Blue;

            chart1.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last); //水平滚动条始终居于最右边


            //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;//网络线
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;


            //设置图标
            chart1.Titles.Clear();
            chart1.Titles.Add("S01");
            chart1.Titles[0].Text = "速率显示";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            //设置图表样式
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart1.Series[0].ChartType = SeriesChartType.Line;//折线图
            chart1.Series[0].MarkerSize = 3;
            chart1.Series[0].Points.Clear();

            chart1.Series[1].Color = Color.Blue;
            chart1.Series[1].MarkerStyle = MarkerStyle.Circle;//圆形点
            chart1.Series[1].ChartType = SeriesChartType.Line;//折线图
            chart1.Series[1].MarkerSize = 3;
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
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            // 设置自动放大与缩小的最小量
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 2;

            //chart1.ChartAreas[0].CursorX.Interval = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void clear_db_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除吗！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                //用户选择确认的操作
                //MessageBox.Show("您选择的是【确认】");
                //MySqlConnection conn = new MySqlConnection("Host =localhost;Database=factory;Username=root;Password=123456");
                //MySqlCommand Cmd = new MySqlCommand();
                //conn.Open();
                try
                {
                    //if (conn.State == ConnectionState.Open)
                    //{
                    //    Cmd.Connection = conn;
                    //    for (int i = 1; i < 21;i++ )
                    //    {
                    //        Cmd.CommandText = "truncate table M" + i.ToString(); 
                    //        Cmd.CommandType = CommandType.Text;
                    //        int ret = Cmd.ExecuteNonQuery();
                    //    }

                    //}
                    for (int i = 1; i < 21; i++)
                    {
                        //DELETE FROM M1 WHERE Date < DATE_SUB(CURDATE(),INTERVAL 6 MONTH);
                        string sql = "delete from M" + i.ToString() + " where Date < DATE_SUB(curdate() , interval 6 month)";
                        myDatabase.executeSql(sql);
                    }

                    MessageBox.Show("清除成功", "提示");
                    MyDatabase.mysqlConn.Close();
                    MyDatabase.mysqlConn.Dispose();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (dr == DialogResult.Cancel)
            {
                //用户选择取消的操作
                //MessageBox.Show("您选择的是【取消】");
            }
        }

       

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                //this.notifyIcon1.Visible = false; //不可见

            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                //this.notifyIcon1.Visible = true;
            }
        }


        private void openMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float[] scale = (float[])Tag;
            int i = 2;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Left = (int)(Size.Width * scale[i++]);
                ctrl.Top = (int)(Size.Height * scale[i++]);
                ctrl.Width = (int)(Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                ctrl.Height = (int)(Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);

                //每次使用的都是最初始的控件大小，保证准确无误。
            }
        }

        private void btnempty_Click(object sender, EventArgs e)
        {
            receiveMsg.Text = "";
        }

        
     /*******************************************************************/
        //用来设置服务端监听的端口号
        public int setPort
        {
            get { return localPort; }
            set { localPort = value; }
        }
       
        //监听函数
        public void Listen()
        {   //设置端口
            setPort = int.Parse(server_port.Text.Trim());
            //初始化SOCKET实例
            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //允许SOCKET被绑定在已使用的地址上。
            newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //初始化终结点实例
            localEP = new IPEndPoint(IPAddress.Any, setPort);
            try
            {
                _sessionTable = new Hashtable(500);
                //绑定
                newsock.Bind(localEP);
                //监听
                newsock.Listen(10);
                //开始接受连接，异步。
                newsock.BeginAccept(new AsyncCallback(OnConnectRequest), newsock);
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
            }

        }

        private void startService_Click(object sender, EventArgs e)
        {
            
            //新建一个委托线程
            ThreadStart myThreadDelegate = new ThreadStart(Listen);
            //实例化新线程
            myThread = new Thread(myThreadDelegate);

            if (btnstatu)
            {

                myThread.Start();
                statuBar.Text = "服务已启动，等待客户端连接";
                btnstatu = false;
                //startService.Text = "停止服务";
                startService.Text = "已启动";
                startService.Enabled = false;
            }
            else
            {
                //停止服务（绑定的套接字没有关闭,因此客户端还是可以连接上来）
                //timer2.Enabled = false;
                myThread.Interrupt();
                myThread.Abort();
 
                //showClientMsg("服务器已停止服务"+"\r\n");
                btnstatu = true;
                startService.Text = "开始服务";
                statuBar.Text = "服务已停止";

            }

        }

        //Listbox
        public void userListOperate(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperate);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Add(msg);
            }
        }

        public void userListOperateR(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperateR);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Remove(msg);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {


            string strDateLine = "kokoko";
            Byte[] byteDateLine = Encoding.UTF8.GetBytes(strDateLine);
            //将提示信息发送给客户端,并在服务端显示连接信息。
            remote = Client.RemoteEndPoint;
            try
            {
                //Client.Send(byteDateLine, byteDateLine.Length, 0);
                Client.SendTo(byteDateLine, remote);
            }
            catch (System.Exception ex)
            {
            	
            }
            
            
            
        }

        private void clear_speedrate_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            //this.chart1.Series[2].Points.Clear();
            //this.chart1.Series[3].Points.Clear();
            //this.chart1.Series[4].Points.Clear();
            //this.chart1.Series[5].Points.Clear();
        }

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                //分别显示x轴和y轴的数值，其中{1:F3},表示显示的是float类型，精确到小数点后3位。   
                // e.Text = string.Format("次数:{0};数值:{1:F1} ", dp.XValue, dp.YValues[0]);
                //DateTime.Parse(row[6].ToString()).ToString("HH:mm:ss");
                string date = DateTime.Now.ToString("yyyy-MM-dd");//2008-9-4
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//2008-9-4 20:02:10
                string sql = "select Date from " + comboBox1.Text.ToString() + " where Date between" + "'" + date + " 00:00:00" + "'"
                                                   + "and" + "'" + datetime + "'";
                DataSet ds = myDatabase.getDataSet(sql, "CS1");
                int count = ds.Tables[0].Rows.Count;
                string time = DateTime.Parse(ds.Tables[0].Rows[i][0].ToString()).ToString("HH:mm:ss");
              
                
                MyDatabase.mysqlConn.Close();
                MyDatabase.mysqlConn.Dispose();
                e.Text = string.Format("时间:{0}\n转速:{1}",time,dp.YValues[0]);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
           
           HitTestResult myTestResult = chart1.HitTest(e.X,e. Y);  
           if (myTestResult.ChartElementType == ChartElementType.DataPoint)  
           {  
               //this.Cursor = Cursors.Cross;  
               int i = myTestResult.PointIndex;  
               DataPoint dp = myTestResult.Series.Points[i];
               string date = DateTime.Now.ToString("yyyy-MM-dd");//2008-9-4
               string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//2008-9-4 20:02:10
               string sql = "select Date from " + comboBox1.Text.ToString() + " where Date between" + "'" + date + " 00:00:00" + "'"
                                                  + "and" + "'" + datetime + "'";
               DataSet ds = myDatabase.getDataSet(sql, "CS1");
               int count = ds.Tables[0].Rows.Count;
               string time = DateTime.Parse(ds.Tables[0].Rows[i][0].ToString()).ToString("HH:mm:ss");
               MyDatabase.mysqlConn.Close();
               MyDatabase.mysqlConn.Dispose();
               MessageBox.Show("时间："+time+"\n"+"转速："+dp.YValues[0]);
           }  
           else  
           {  
               this.Cursor = Cursors.Default;  
           }  
        }

        private void btn_ShowProcessPara_Click(object sender, EventArgs e)
        {

        }  
        

  

    }
}
