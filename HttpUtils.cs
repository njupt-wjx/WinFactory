using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace TCPClient
{
    class HttpUtils
    {
        //POST请求
        public static String HttpPostData(String url, String data)
        {
            string strReturn = string.Empty;
            //byte[] byteData = Encoding.GetEncoding("GBK").GetBytes(data);  //在转换字节时指定编码格式
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteData.Length;

            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(byteData, 0, byteData.Length);//发送数据
                }
                //get reponse data and parse
                using (WebResponse response = req.GetResponse())
                {
                    //解决乱码：utf-8 + streamreader.readtoend
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    strReturn = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }
    }
}
