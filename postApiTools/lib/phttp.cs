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
        /// 上传文件方法
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="valuesList">参数二维数组</param>
        /// <param name="pathList">文件二维数组</param>
        /// <param name="encodingString">编码</param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[,] valuesList = null, string[,] pathList = null, string encodingString = "utf-8")
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");//开始头
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");//结束尾
                Stream postStreamStart = request.GetRequestStream();//添加数据
                postStreamStart.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);//开始
                if (valuesList != null)
                {
                    for (int i = 0; i < valuesList.GetLength(0); i++)
                    {
                        byte[] by = Encoding.UTF8.GetBytes(string.Format("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}", valuesList[i, 0], valuesList[i, 1]));
                        postStreamStart.Write(by, 0, by.Length);
                    }
                }
                if (pathList != null)
                {
                    for (int i = 0; i < pathList.GetLength(0); i++)
                    {
                        int pos = pathList[i, 1].LastIndexOf("\\");
                        string fileName = pathList[i, 1].Substring(pos + 1);
                        byte[] postHeaderBytes = Encoding.UTF8.GetBytes(string.Format("\r\n--" + boundary + "\r\nContent-Disposition:form-data;name=\"" + pathList[i, 0] + "\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
                        FileStream fs = new FileStream(pathList[i, 1], FileMode.Open, FileAccess.Read);
                        byte[] bArr = new byte[fs.Length];
                        fs.Read(bArr, 0, bArr.Length);
                        fs.Close();
                        postStreamStart.Write(postHeaderBytes, 0, postHeaderBytes.Length);//添加参数
                        postStreamStart.Write(bArr, 0, bArr.Length);//添加文件
                    }
                }
                postStreamStart.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);//结尾
                                                                                    //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
                                                                                                                                        //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.GetEncoding(encodingString));
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                postStreamStart.Close();//关闭
                response.Close();//关闭
                return content;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response == null)
                {
                    return errorDataShow;
                }
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));//读取流
                pLogs.logs(ex.ToString());//写入日志
                string str = sr.ReadToEnd();
                response.Close();
                sr.Close();
                return str;
            }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        private const string errorDataShow = "连接终止...远程服务器无法访问!";



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
                webReq.KeepAlive = false;  //设置不建立持久性连接连接
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded;charset=utf8";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
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
                if (response == null)
                {
                    return errorDataShow;
                }
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));//读取流
                pLogs.logs(ex.ToString());//写入日志
                string str = sr.ReadToEnd();
                response.Close();
                sr.Close();
                return str;
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
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
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
                if (response == null)
                {
                    return errorDataShow;
                }
                HttpCustom_Response_Headers_Object = response.Headers;//写入数据到WebHeaderCollection
                HttpCustom_code = lib.pBase.enumToValueInt(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()).ToString();//赋值状态码
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodingString));//读取流
                pLogs.logs(ex.ToString());//写入日志
                return sr.ReadToEnd();
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
