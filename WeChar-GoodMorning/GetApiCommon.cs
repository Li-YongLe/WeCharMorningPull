using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeChar_GoodMorning
{
    public class GetApiCommon
    {
        public string GetApi()
        {
            string serviceAddress = $"https://restapi.amap.com/v3/weather/weatherInfo?parameters";//请求URL地址
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            for (int i = 0; i < cfa.AppSettings.Settings.Count; i++)
            {
                serviceAddress += $"&{cfa.AppSettings.Settings.AllKeys[i]}={cfa.AppSettings.Settings[cfa.AppSettings.Settings.AllKeys[i]].Value}";
            }
            using (var client = new WebClient())
            {

                client.Encoding = Encoding.UTF8;
                var data = client.DownloadString(serviceAddress);
                //var obj = JsonConvert.DeserializeObject<JObject>(data);
                //Console.Write(obj);
                //Console.ReadKey();

            }
            return "";
        }
    }
}
