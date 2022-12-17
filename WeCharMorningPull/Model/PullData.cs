using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCharMorningPull.Model
{
    public class PullBody
    {
        public string touser { get; set; } = string.Empty;
        public string template_id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public PullData data { get; set; } = new();
    }
    public class PullData
    {
        public DataContent City { get; set; } = new();
        public DataContent Weather { get; set; } = new();
        public DataContent Temperature { get; set; } = new();
        public DataContent LoveDay { get; set; } = new();
        public DataContent BeginBirthday { get; set; } = new();
        public DataContent PiPi { get; set; } = new();
        public DataContent XZYSContent { get; set; } = new();
    }
    public class DataContent
    {
        public string Colors { get; set; } = "#00E8FF,#E0CC00,#293CFF,#67D200,#FF0000,#5B58D1,#FF00AB,#00FFAB";
        public string value { get; set; } = string.Empty;
        public string color => Colors.Split(",")[new Random().Next(0, Colors.Split(",").ToList().Count)];
    }
}
