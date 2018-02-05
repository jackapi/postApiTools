using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.Models
{
    public class UrlDataView
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 参数说明
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string type { get; set; }
    }
}
