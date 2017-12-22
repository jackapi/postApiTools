using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// by:(chenran)apiziliao@gmail.com
/// </summary>
namespace postApiTools.lib
{
    public class pRunTimeNumber
    {
        public static DateTime beforDT;

        public static DateTime afterDT;

        /// <summary>
        /// 运行开始
        /// </summary>
        public static void start()
        {
            beforDT = System.DateTime.Now;
        }
        /// <summary>
        /// 运行结束
        /// </summary>
        public static void end()
        {
             afterDT = System.DateTime.Now;
        }
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <returns></returns>
        public static string result()
        {
            TimeSpan ts = afterDT.Subtract(beforDT);
            return Math.Ceiling(ts.TotalMilliseconds).ToString();
        }
    }
}
