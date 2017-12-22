using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pDate
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static int getTimeStamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            int timeStamp = (int)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 时间戳转时间对象
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime timeStampToDate(int timeStamp)
        {
            long unixTimeStamp = timeStamp;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(unixTimeStamp);
            return dt;
        }
    }
}
