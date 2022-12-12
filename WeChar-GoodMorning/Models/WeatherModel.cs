using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChar_GoodMorning.Models
{
    public class WeatherModel
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 天气
        /// </summary>
        public string weather { get; set; }
        /// <summary>
        /// 当前温度
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public string winddirection { get; set; }
        /// <summary>
        /// 风力
        /// </summary>
        public string windpower { get; set; }
        // <summary>
        /// 空气湿度
        /// </summary>
        public string humidity { get; set; }

    }
}
