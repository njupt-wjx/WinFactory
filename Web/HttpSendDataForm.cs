using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace TCPClient.Web
{
    public partial class HttpSendDataForm : Form
    {
        public HttpSendDataForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string wjx = "wjx";
                string url = "http://localhost:8081/Factory/NameServlet?name="+wjx;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                using (WebResponse wr = request.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                }
            }
            catch (System.Exception ex)
            {
            	
            }
   
            
        }

        private void HttpSendDataForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
