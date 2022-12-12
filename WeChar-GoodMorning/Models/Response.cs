using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChar_GoodMorning.Models
{
    public class Response
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } 
        /// <summary>
        /// 状态信息
        /// </summary>
        public string info { get; set; }
    }
}
