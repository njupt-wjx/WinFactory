using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TCPClient.Web;


namespace TCPClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ProcessParaForm());
            //Application.Run(new Form1());
            //Application.Run(new AdminAddForm());
            //Application.Run(new HttpSendDataForm());
            Application.Run(new MainForm());
        }
    }
}
