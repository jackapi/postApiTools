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
        /// 刷新显示历史
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="url"></param>
        /// <param name="dataUrl"></param>
        /// <param name="method"></param>
        public static void dataViewShow(DataGridView history, DataGridView urlDataView, string url, string method)
        {
            string[,] urlData = pform1.dataViewUrlDataToObjectArray(urlDataView);
            if (pHistory.insert(url, urlData, method) > 0)
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
        /// 填充数据
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="comboBox_url_type"></param>
        public static void fillData(DataGridView dd, string hash, ComboBox comboBox_url_type, TextBox textBox_url, FastColoredTextBox textBox_html)
        {
            try
            {
                dd.Invoke(new Action(() =>
                {
                    Dictionary<string, string> data = sqlite.getOne("select *from " + table + " where hash='" + hash + "'");
                    comboBox_url_type.Text = data["method"];
                    textBox_url.Text = data["url"];
                    string str = lib.pBase64.base64ToString(data["dataurl"]);
                    string[,] array = pJson.jsonStrToObjectArrayString(str, 3);//获取字符串数组
                    dd.Invalidate();//重新绘制
                    dd.Rows.Clear();//清理行数
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
                    textBox_html.Text = "";
                }));
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                MessageBox.Show("请重试");
            }
        }

        private delegate void dataViewRefreshD(DataGridView history);

        /// <summary>
        /// 包含添加过总数
        /// </summary>
        public static int dataViewRefreshRows = 0;

        /// <summary>
        /// 刷新历史数据框
        /// </summary>
        /// <param name="history"></param>
        public static void dataViewRefresh(DataGridView history)
        {
            try
            {
                history.Invoke(new Action(() =>
                {
                    Dictionary<int, object> data = sqlite.getRows("select *from " + table + " order by addtime desc limit 0,32");
                    if (data.Count <= 0)
                    {
                        history.Invalidate();
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
                    history.Invalidate();
                    history.Rows.Clear();//清理行数
                    history.Rows.Add(data.Count);
                    //history.RowTemplate.Height = 30;//行距
                                                    //设置自动调整高度
                    history.ReadOnly = true;//不可编辑

                    for (int i = 0; i < data.Count; i++)
                    {

                        Dictionary<string, string> d = new Dictionary<string, string> { };
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
                        //history.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    }
                    history.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    history.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
        public static int insert(string url, string[,] dataUrl, string method)
        {
            string dataUrlStr = pJson.objectToJsonStr(dataUrl);
            dataUrlStr = lib.pBase64.stringToBase64(dataUrlStr);
            Random r = new Random();
            string hash = lib.pBase.CreateMD5Hash(lib.pDate.getTimeStamp().ToString() + r.Next(10000, 99999).ToString());//生成hash
            create();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + table);
            sb.Append(" (hash,url,dataurl,method,addtime)VALUES(");
            sb.Append("'" + hash + "',");
            sb.Append("'" + url + "',");
            sb.Append("'" + dataUrlStr + "',");
            sb.Append("'" + method + "',");
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
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + table + "(hash varchar(200) , url varchar(200), dataurl varchar(2000), method varchar(200),addtime integer);");
        }

        /// <summary>
        /// 清理全部
        /// </summary>
        public static int historyAllDelete()
        {
            return sqlite.executeNonQuery("delete from " + table);
        }
    }
}
