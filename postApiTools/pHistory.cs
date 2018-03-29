using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// by:(chenran)apiziliao@gmail.com
/// </summary>
namespace postApiTools
{
    using System.Threading;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Data;
    using FastColoredTextBoxNS;

    /// <summary>
    /// 历史记录类
    /// </summary>
    public class pHistory
    {
        /// <summary>
        /// 表名
        /// </summary>
        const string table = "history";

        /// <summary>
        /// 实例化sqlite
        /// </summary>
        public static lib.pSqlite sqlite = new lib.pSqlite(Config.historyDataDb);
        /// <summary>
        /// 错误信息
        /// </summary>
        public static string error = "";

        /// <summary>
        /// 刷新postJson显示历史
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="url"></param>
        /// <param name="dataUrl"></param>
        /// <param name="method"></param>
        public static void postJsonShow(DataGridView history, string postJson, string url, string method, string result = "")
        {
            if (pHistory.insertPostJson(url, postJson, method, result) > 0)
            {
                Thread th = new Thread(new ParameterizedThreadStart(dataViewShow));
                th.Start(history);
            }
            else
            {
                error = sqlite.error;//显示错误信息
            }
        }

        /// <summary>
        /// 刷新显示历史
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="url"></param>
        /// <param name="dataUrl"></param>
        /// <param name="method"></param>
        public static void dataViewShow(DataGridView history, DataGridView urlDataView, string url, string method, string result = "")
        {
            string[,] urlData = pform1.dataViewUrlDataToObjectArray(urlDataView);
            if (pHistory.insert(url, urlData, method, result) > 0)
            {
                Thread th = new Thread(new ParameterizedThreadStart(dataViewShow));
                th.Start(history);
            }
            else
            {
                error = sqlite.error;//显示错误信息
            }
        }

        /// <summary>
        /// 线程中刷新
        /// </summary>
        private static void dataViewShow(object history)
        {
            dataViewRefresh((DataGridView)history);
        }

        /// <summary>
        /// 获取最新一个hash
        /// </summary>
        /// <returns></returns>
        public static string NewDataHash()
        {
            Dictionary<string, string> data = sqlite.getOne("select *from " + table + " order by addtime desc limit 0,1");
            if (data.Count > 0)
            {
                return data["hash"];
            }
            return "";
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="comboBox_url_type"></param>
        public static void fillData(DataGridView dd, string hash, ComboBox comboBox_url_type, TextBox textBox_url, FastColoredTextBox textBox_html)
        {
            try
            {
                if (hash == "") { return; }
                dd.BeginInvoke(new Action(() =>
                {
                    Dictionary<string, string> data = sqlite.getOne("select *from " + table + " where hash='" + hash + "'");
                    if (data.Count <= 0)
                    {
                        return;
                    }
                    comboBox_url_type.Text = data["method"];
                    textBox_url.Text = data["url"];
                    string str = lib.pBase64.base64ToString(data["dataurl"]);
                    string[,] array = pJson.jsonStrToObjectArrayString(str, 3);//获取字符串数组
                    dd.Invalidate();//重新绘制
                    dd.Rows.Clear();//清理行数
                    if (array != null)
                    {
                        if (array.GetLength(0) > 0)
                        {
                            dd.Rows.Add(array.GetLength(0));
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                dd.Rows[i].Cells[0].Value = array[i, 0];
                                dd.Rows[i].Cells[1].Value = array[i, 1];
                                dd.Rows[i].Cells[2].Value = array[i, 2];
                                dd.Rows[i].Cells[3].Value = lib.pBase.dataGridViewHttpDataValueToTypeListName(array[i, 2]);//输出类型
                            }
                        }
                    }
                    if (!data.ContainsKey("result")) { MessageBox.Show("出错！请清理历史！"); }
                    else
                    {
                        data["result"] = lib.pBase64.base64ToString(data["result"]);//base64
                        textBox_html.Text = data["result"];//上次api结果
                        Form1.f.testHtml = data["result"];//上次api结果
                    }
                }));
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                MessageBox.Show("请重试");
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="comboBox_url_type"></param>
        public static void fillDataNoTh(DataGridView dd, string hash, ComboBox comboBox_url_type, TextBox textBox_url, FastColoredTextBox textBox_html)
        {
            try
            {
                if (hash == "") { return; }
                Dictionary<string, string> data = sqlite.getOne("select *from " + table + " where hash='" + hash + "'");
                if (data.Count <= 0)
                {
                    return;
                }
                comboBox_url_type.Text = data["method"];
                textBox_url.Text = data["url"];
                string str = lib.pBase64.base64ToString(data["dataurl"]);
                string[,] array = pJson.jsonStrToObjectArrayString(str, 3);//获取字符串数组
                dd.Invalidate();//重新绘制
                dd.Rows.Clear();//清理行数
                if (array != null)
                {
                    if (array.GetLength(0) > 0)
                    {
                        dd.Rows.Add(array.GetLength(0));
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            dd.Rows[i].Cells[0].Value = array[i, 0];
                            dd.Rows[i].Cells[1].Value = array[i, 1];
                            dd.Rows[i].Cells[2].Value = array[i, 2];
                            dd.Rows[i].Cells[3].Value = lib.pBase.dataGridViewHttpDataValueToTypeListName(array[i, 2]);//输出类型
                        }
                    }
                }
                if (!data.ContainsKey("result")) { MessageBox.Show("出错！请清理历史！"); }
                else
                {
                    data["result"] = lib.pBase64.base64ToString(data["result"]);//base64
                    textBox_html.Text = data["result"];//上次api结果
                    Form1.f.testHtml = data["result"];//上次api结果
                }
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                //MessageBox.Show("请重试");
            }
        }

        private delegate void dataViewRefreshD(DataGridView history);

        /// <summary>
        /// 包含添加过总数
        /// </summary>
        public static int dataViewRefreshRows = 0;
        /// <summary>
        /// 历史数组
        /// </summary>
        public static string[] urlHistoryList;

        /// <summary>
        /// 快捷键动态绑定方法
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void cmsGetHistory(object obj1, object obj2)
        {
            if (obj2 == null) { return; }
            ToolStripItemClickedEventArgs t = (ToolStripItemClickedEventArgs)obj2;
            if (t.ClickedItem.ToString() == "查看结果")
            {
                DataGridViewSelectedRowCollection rows = historyPublic.SelectedRows;
                if (rows.Count <= 0) { return; }
                string hash = rows[0].Cells[0].ToolTipText;//hash
                string title = rows[0].Cells[1].Value.ToString();//title
                Dictionary<string, string> data = sqlite.getOne("select *from " + table + " where hash='" + hash + "'");
                Thread th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
                {
                    Application.Run(new FormAll.GetHistory(title, hash, data));//线程启动窗体
                });
                th.SetApartmentState(ApartmentState.STA);
                th.IsBackground = true;
                th.Start();
            }
        }
        /// <summary>
        /// 定义
        /// </summary>
        public static DataGridView historyPublic;

        /// <summary>
        /// 刷新历史数据框
        /// </summary>
        /// <param name="history"></param>
        public static void dataViewRefresh(DataGridView history)
        {
            try
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("查看结果");
                cms.ItemClicked += cmsGetHistory;
                history.ContextMenuStrip = cms;
                history.BeginInvoke(new Action(() =>
                {

                    Dictionary<int, object> data = sqlite.getRows("select *from " + table + " order by addtime desc limit 0,50");
                    if (data.Count <= 0)
                    {
                        urlHistoryList = new string[2];
                        urlHistoryList[0] = "http://";
                        urlHistoryList[1] = "https://";
                        history.Rows.Clear();//清理行数
                        return;
                    }

                    //if (dataViewRefreshRows > 0)
                    //{
                    //    history.Invalidate();
                    //    history.ReadOnly = true;//不可编辑
                    //    DataGridViewRowCollection yuan = history.Rows;

                    //    history.Rows.Clear();//清理行数
                    //    history.Rows.Add(data.Count);
                    //    for (int i = dataViewRefreshRows ; i < data.Count; i++)
                    //    {
                    //        history.DataSource = yuan;
                    //        Dictionary<string, string> d = new Dictionary<string, string> { };
                    //        d = (Dictionary<string, string>)data[i];
                    //        history.Rows[i].Cells[0].Value = d["method"];
                    //        history.Rows[i].Cells[0].ToolTipText = d["hash"];
                    //        history.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                    //        history.Rows[i].Cells[1].Value = d["url"];
                    //        history.Rows[i].Cells[1].ToolTipText = d["url"];
                    //        history.Rows[i].DataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //        history.Rows[i].DataGridView.AutoResizeColumns();
                    //        history.Rows[i].DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                    //        dataViewRefreshRows++;
                    //    }
                    //    return;
                    //}
                    //history.Invalidate();
                    history.Rows.Clear();//清理行数
                    history.Rows.Add(data.Count);
                    //history.RowTemplate.Height = 30;//行距
                    //设置自动调整高度
                    history.ReadOnly = true;//不可编辑
                    urlHistoryList = new string[data.Count + 2];
                    history.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    history.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader; ///根据数据内容自动调整列宽
                    history.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    for (int i = 0; i < data.Count; i++)
                    {

                        Dictionary<string, string> d = new Dictionary<string, string> { };
                        d = (Dictionary<string, string>)data[i];
                        history.Rows[i].Cells[0].Value = d["method"];
                        history.Rows[i].Cells[0].ToolTipText = d["hash"];
                        history.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                        history.Rows[i].Cells[1].Value = d["url"] + "\n";
                        history.Rows[i].Cells[1].ToolTipText = d["url"];
                        dataViewRefreshRows++;
                        //history.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                        urlHistoryList[i] = d["url"];
                    }
                    urlHistoryList[data.Count] = "http://";
                    urlHistoryList[data.Count + 1] = "https://";
                    historyPublic = history;
                }));
            }
            catch (Exception ex)
            {
                history.Invoke(new Action(() =>
                {
                    history.Invalidate();
                    history.Rows.Clear();//清理行数
                }));
                pLogs.logs(ex.ToString());
            }
        }

        static int historyCountI = 0;
        static int historyCount = 0;
        public static void dataViewHistoryLoading(DataGridView history)
        {
            try
            {
                int size = 5;
                history.Invoke(new Action(() =>
                {
                    historyCount = size * historyCountI;
                    Dictionary<int, object> data = sqlite.getRows("select *from " + table + " order by addtime desc limit " + historyCount + "," + size);
                    if (data.Count <= 0)
                    {
                        return;
                    }
                    int yuan = history.Rows.Count;
                    history.Rows.Add(yuan + data.Count);
                    history.RowTemplate.Height = 30;//行距 //设置自动调整高度
                    history.ReadOnly = true;//不可编辑
                    for (int i = yuan; i < (yuan + data.Count); i++)
                    {
                        Dictionary<string, string> d = new Dictionary<string, string> { };
                        if (d.Count <= 0)
                        {
                            continue;
                        }
                        d = (Dictionary<string, string>)data[i];
                        history.Rows[i].Cells[0].Value = d["method"];
                        history.Rows[i].Cells[0].ToolTipText = d["hash"];
                        history.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                        history.Rows[i].Cells[1].Value = d["url"];
                        history.Rows[i].Cells[1].ToolTipText = d["url"];
                        history.Rows[i].DataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        history.Rows[i].DataGridView.AutoResizeColumns();
                        history.Rows[i].DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                        dataViewRefreshRows++;
                    }
                    historyCountI++;
                }));
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataUrl"></param>
        /// <param name="method"></param>
        public static int insertPostJson(string url, string data, string method, string result)
        {
            data = lib.pBase64.stringToBase64(data);
            Random r = new Random();
            string hash = lib.pBase.CreateMD5Hash(lib.pDate.getTimeStamp().ToString() + r.Next(10000, 99999).ToString());//生成hash
            create();
            result = lib.pBase64.stringToBase64(result);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + table);
            sb.Append(" (hash,url,postjson,method,result,addtime)VALUES(");
            sb.Append("'" + hash + "',");
            sb.Append("'" + url + "',");
            sb.Append("'" + data + "',");
            sb.Append("'" + method + "',"); ;
            sb.Append("'" + result + "',");
            sb.Append("'" + lib.pDate.getTimeStamp() + "'");
            sb.Append(")");
            int row = sqlite.insert(sb.ToString());
            return row;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataUrl"></param>
        /// <param name="method"></param>
        public static int insert(string url, string[,] dataUrl, string method, string result)
        {
            string dataUrlStr = pJson.objectToJsonStr(dataUrl);
            dataUrlStr = lib.pBase64.stringToBase64(dataUrlStr);
            Random r = new Random();
            string hash = lib.pBase.CreateMD5Hash(lib.pDate.getTimeStamp().ToString() + r.Next(10000, 99999).ToString());//生成hash
            create();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + table);
            sb.Append(" (hash,url,dataurl,method,result,addtime)VALUES(");
            sb.Append("'" + hash + "',");
            sb.Append("'" + url + "',");
            sb.Append("'" + dataUrlStr + "',");
            sb.Append("'" + method + "',"); ;
            sb.Append("'" + result + "',");
            sb.Append("'" + lib.pDate.getTimeStamp() + "'");
            sb.Append(")");
            int row = sqlite.insert(sb.ToString());
            return row;
        }

        /// <summary>
        /// 创建表
        /// </summary>
        public static void create()
        {
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + table + "(hash varchar(200) , url varchar(200), dataurl varchar(2000),postjson varchar(2000), method varchar(200),result varchar(2000),addtime integer);");
            sqlite.executeNonQuery("ALTER TABLE " + table + " ADD COLUMN postjson varchar(2000)");
        }

        /// <summary>
        /// 清理全部
        /// </summary>
        public static int historyAllDelete()
        {
            //return sqlite.executeNonQuery("delete from " + table);
            return sqlite.executeNonQuery("DROP TABLE " + table);
        }

        public static void close()
        {
            sqlite.close();
        }
    }
}
