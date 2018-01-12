using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    using WebSocketSharp;
    using WebSocketSharp.Net;
    using Newtonsoft;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// socket 更新服务
    /// </summary>
    public class pUpdateServerSocket
    {
        public WebSocket socket = null;
        /// <summary>
        /// 随机数
        /// </summary>
        public Random r = new Random();
        /// <summary>
        /// 线程
        /// </summary>
        public Thread th = null;

        /// <summary>
        /// 心跳线程
        /// </summary>
        public Thread pongTh = null;
        /// <summary>
        /// 心跳锁
        /// </summary>
        public int pongLook = 0;

        /// <summary>
        /// 心跳json
        /// </summary>
        /// <returns></returns>
        public string pong()
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("type", "pong");
            d.Add("tools", "postApiTools");
            d.Add("rand", r.Next(1000, 9999).ToString());
            return pJson.objectToJsonStr(d);
        }

        /// <summary>
        /// 内容待发列表
        /// </summary>
        public Dictionary<int, string> sendList = new Dictionary<int, string> { };

        /// <summary>
        /// 收件列表
        /// </summary>
        public Dictionary<string, string> messageList = new Dictionary<string, string> { };


        public pUpdateServerSocket()
        {
            if (socket == null)
            {
                start();
            }
        }
        /// <summary>
        /// socket主线程方法
        /// </summary>
        public void startFun()
        {
            try
            {
                if (socket == null)
                {
                    if (Config.openServerWebSocketIp != "" && Config.openServerWebSocketPort != "")
                    {
                        socket = new WebSocket(string.Format("ws://{0}:{1}", Config.openServerWebSocketIp, Config.openServerWebSocketPort));
                    }
                    else
                    {
                        return;
                    }
                }
                socket.OnOpen += (sender, e) => { };//打开
                socket.Connect();
                socket.OnError += (sender, e) => { };//错误
                socket.OnClose += (sender, e) => { };//远程关闭
                login();//登录
            }
            catch
            {
                startFun();
            }
            while (true)
            {
                try
                {
                    if (pongTh == null)
                    {
                        pongTh = new Thread(pongFun); //心跳线程
                        pongTh.Start();
                    }
                    else
                    {
                        if (pongTh.Name == null)
                        {
                            pongTh = new Thread(pongFun); //心跳线程
                            pongTh.Start();
                        }
                    }
                    sendMessage();//发送方法
                    getContent();//接收信息
                    Thread.Sleep(100);
                }
                catch { }

            }
        }

        /// <summary>
        /// 登录更新操作
        /// </summary>
        public void login()
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("type", "login_websocket");
            d.Add("room_id", "1");
            d.Add("client_name", Config.openServerName);
            d.Add("token", Config.userToken);
            socketSend(pJson.objectToJsonStr(d));
        }
        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="content"></param>
        public void sendMessage()
        {
            if (sendList.Count > 0)//发送内容排序
            {
                Dictionary<string, string> d = new Dictionary<string, string> { };
                d.Add("type", "say");
                d.Add("room_id", "1");
                d.Add("client_name", Config.openServerName);
                d.Add("server_hash", "sdfsd");
                d.Add("content", sendList[sendList.Count]);
                d.Add("token", Config.userToken);
                //socket.Send(pJson.objectToJsonStr(d));
                sendList.Remove(sendList.Count);
            }
        }

        /// <summary>
        /// 发送文档更新消息
        /// </summary>
        /// <param name="serverHash"></param>
        public void sendServerHashUpdate(string serverHash)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("type", "document_hash_update");
            d.Add("room_id", "1");
            d.Add("client_name", Config.openServerName);
            d.Add("hash", serverHash);
            d.Add("token", Config.userToken);
            socketSend(pJson.objectToJsonStr(d));
        }
        public void sendServerHashMessage(string serverHash)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("type", "say");
            d.Add("room_id", "1");
            d.Add("client_name", Config.openServerName);
            d.Add("server_hash", "sdfsd");
            d.Add("content", sendList[sendList.Count]);
            d.Add("token", Config.userToken);
            //socket.Send(pJson.objectToJsonStr(d));
            sendList.Remove(sendList.Count);
        }
        /// <summary>
        /// 获取接收内容
        /// </summary>
        public void getContent()
        {
            try
            {
                if (socket == null)
                {
                    startFun();
                }
                socket.OnMessage += (sender, e) =>
                {
                    JObject job = pJson.jsonToJobject(e.Data);
                    if (job == null) { return; }
                    if (job["type"]==null) { return; }
                    if (job["type"].ToString() == "ping") { return; }
                    if (job["messageHash"]==null)
                    {
                        return;
                    }
                    if (!messageList.ContainsKey(job["messageHash"].ToString()))//判断消息是否接收存在
                    {
                        messageList.Add(job["messageHash"].ToString(), e.Data);
                    }
                };//返回信息
            }
            catch { }
        }

        /// <summary>
        /// 心跳线程方法
        /// </summary>
        public void pongFun()
        {
            if (pongTh == null) { return; }
            if (pongLook > 0) { pongTh = null; return; }
            pongLook++;
            socketSend(pong().ToString());//心跳
            Thread.Sleep(int.Parse(Config.openServerSocketSleep));//心跳延时
            if (pongTh != null) { if (pongTh.Name != null) pongTh.Join(); }
            pongTh = null;
            pongLook--;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="content"></param>
        public void socketSend(string content)
        {
            try
            {
                socket.Send(content);
            }
            catch
            {
                startFun();
            }
        }

        /// <summary>
        /// 开启
        /// </summary>
        public void start()
        {
            if (th == null)
            {
                th = new Thread(startFun);
                th.Start();
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void stop()
        {
            if (th != null)
            {
                th.Join();
                socket.Close();
                socket = null;
            }
        }


    }
}
