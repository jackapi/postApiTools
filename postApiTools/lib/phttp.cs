using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class phttp
    {
        /// <summary>
        /// 后台发送POST请求
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <param name="data">发送的数据</param>
        /// <returns></returns>
        public static string HttpPost(string url, string data)
        {
            try
            {
                //创建post请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                byte[] payload = Encoding.UTF8.GetBytes(data);
                request.ContentLength = payload.Length;

                //发送post的请求
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string value = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();

                return value;
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// POST请求自定义
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <param name="data">发送的数据</param>
        /// <returns></returns>
        public static string HttpPostCustom(string url, string data, string encodingString = "utf-8")
        {
            try
            {
                //创建post请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                //request.ContentType = "application/json;charset=UTF-8";
                request.ContentType = "text/html;charset=UTF-8";
                byte[] payload = Encoding.UTF8.GetBytes(data);
                request.ContentLength = payload.Length;

                //发送post的请求
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(encodingString));
                string value = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();
                HttpCustom_html = value;
                return value;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Post提交数据
        /// </summary>
        /// <param name="postUrl">URL</param>
        /// <param name="paramData">参数</param>
        /// <returns></returns>
        public static string PostWebRequestCustom(string postUrl, string paramData, string encodingString = "utf-8")
        {
            try
            {
                string ret = string.Empty;
                if (!postUrl.StartsWith("http://"))
                    return "";

                byte[] byteArray = Encoding.Default.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = response.StatusCode.ToString();//状态
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                int code = Convert.ToInt32(Enum.Parse(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()));//获取异常状态码
                HttpCustom_code = code.ToString();//赋值状态码
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));//读取流
                pLogs.logs(ex.ToString());//写入日志
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// http请求返回状态
        /// </summary>
        public static string HttpCustom_code = "";
        /// <summary>
        /// http请求返回的HTML
        /// </summary>
        public static string HttpCustom_html = "";
        /// <summary>
        /// http请求返回报文
        /// </summary>
        public static string[,] HttpCustom_Response_Headers = null;

        public static WebHeaderCollection HttpCustom_Response_Headers_Object = null;

        /// <summary>
        /// 获取返回报文头
        /// </summary>
        /// <returns></returns>
        public static string[,] Get_HttpCustom_Response_Headers()
        {
            if (HttpCustom_Response_Headers_Object == null)
            {
                return null;
            }
            int headerCount = HttpCustom_Response_Headers_Object.Keys.Count;
            HttpCustom_Response_Headers = new string[headerCount, 2];
            //Http response头  
            for (int i = 0; i < HttpCustom_Response_Headers_Object.Keys.Count; i++)
            {
                HttpCustom_Response_Headers[i, 0] = HttpCustom_Response_Headers_Object.Keys[i];
                HttpCustom_Response_Headers[i, 1] = HttpCustom_Response_Headers_Object.Get(i);
            }
            return HttpCustom_Response_Headers;
        }




        /// <summary>
        /// 前台GET自定义测试请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="encodingString"></param>
        /// <returns></returns>
        public static string HttpGetCustom(string url, string data, string encodingString = "utf-8")
        {

            try
            {
                //创建Get请求
                url = url + (data == "" ? "" : "?") + data;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = response.StatusCode.ToString();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(encodingString));
                string retString = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
                response.Close();
                HttpCustom_html = retString;
                return retString;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                int code = Convert.ToInt32(Enum.Parse(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()));//获取异常状态码
                HttpCustom_code = code.ToString();//赋值状态码
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));//读取流
                pLogs.logs(ex.ToString());//写入日志
                return sr.ReadToEnd();
            }
        }





        /// <summary>
        /// 后台发送GET请求
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <param name="data">发送的数据</param>
        /// <returns></returns>
        public static string HttpGet(string url, string data)
        {
            try
            {
                //创建Get请求
                url = url + (data == "" ? "" : "?") + data;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream stream = response.GetResponseStream();
                Stream stream = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 自动转编码 获取网页源码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string getWebHtml(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                Random rand = new Random();
                int r = rand.Next(1, 3);
                if (r == 1)
                {
                    wc.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                }
                if (r == 2)
                {
                    wc.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.221 Safari/537.36 SE 2.X MetaSr 1.0";
                }
                Byte[] pageData = wc.DownloadData(url);
                string header = wc.ResponseHeaders["Content-Type"];
                string encoding = wc.Encoding.BodyName.ToString();
                string html = "";
                if (encoding == "gb2312" || encoding == "gbk" || encoding == "GBK")
                {
                    html = Encoding.GetEncoding("GBK").GetString(pageData);
                }
                if (header.IndexOf("utf-8") > 0 || header.IndexOf("UTF-8") > 0)
                {
                    html = Encoding.GetEncoding("utf-8").GetString(pageData);
                }
                return html;
            }
            catch (Exception ex)
            {
                pLogs.logs("URL:" + url + "\r\n" + ex.ToString());
                return "";
            }

        }
    }
}
