using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCharMorningPull.Model
{
    public class WeatherModel
    {
        public string Status { get; set; } = string.Empty;
        public WeatherData[] Lives { get; set; } = new WeatherData[0];
    }
    public class WeatherData
    {
        /// <summary>
        /// 省份名称
        /// </summary>
        public string Province { get; set; } = string.Empty;
        /// <summary>
        /// 城市名称
        /// </summary>
        public string City { get; set; } = string.Empty;
        /// <summary>
        /// 区域编码
        /// </summary>
        public string Adcode { get; set; } = string.Empty;
        /// <summary>
        /// 天气现象
        /// </summary>
        public string Weather { get; set; } = string.Empty;
        /// <summary>
        /// 实时温度
        /// </summary>
        public string Temperature { get; set; } = string.Empty;
        /// <summary>
        /// 风向
        /// </summary>
        public string Winddirection { get; set; } = string.Empty;
        /// <summary>
        /// 风力
        /// </summary>
        public string Windpower { get; set; } = string.Empty;
        /// <summary>
        /// 空气湿度
        /// </summary>
        public string Humidity { get; set; } = string.Empty;
        /// <summary>
        /// 发行时间
        /// </summary>
        public string Reporttime { get; set; } = string.Empty;
    }
}
