using System.Configuration;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeCharMorningPull;
using WeCharMorningPull.Model;


HttpClient httpClient = new();
string AccToken = "";
WeatherModel Weather = new();
JiTangModel JiTang = new();
XZYSModel XZYS = new();
GetJiTang(); GetXZYSAsync();
GetAccToken();
GetWeatherAsync();


List<string> lsTouser = ConfigurationManager.AppSettings["Touser"]!.Split(",").ToList();
lsTouser.ForEach(i => PostWeCharPull(i));

void GetJiTang()
{
    string JiTangKey = ConfigurationManager.AppSettings["JiTangKey"]!;
    string url = $"https://apis.juhe.cn/fapig/soup/query?key={JiTangKey}";
    var result = httpClient.GetAsync(url).Result;
    result.EnsureSuccessStatusCode();
    string responseBody = result.Content.ReadAsStringAsync().Result;
    JiTang = responseBody.JsonToClass<JiTangModel>();

}

void GetWeatherAsync()
{
    string GaudWeatherKey = ConfigurationManager.AppSettings["GaudWeatherKey"]!;
    string CityId = ConfigurationManager.AppSettings["CityId"]!;
    string dgurl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={CityId}&key={GaudWeatherKey}";
    var getHttpData = httpClient.GetAsync(dgurl).Result;
    getHttpData.EnsureSuccessStatusCode();
    string responseBody = getHttpData.Content.ReadAsStringAsync().Result;
    Weather = responseBody.JsonToClass<WeatherModel>();
}

void GetXZYSAsync()
{
    string XZYSKey = ConfigurationManager.AppSettings["XZYSKey"]!;
    string XZName = ConfigurationManager.AppSettings["XZName"]!;
    string XZType = ConfigurationManager.AppSettings["XZType"]!;
    string dgurl = $"http://web.juhe.cn/constellation/getAll?consName={XZName}&type={XZType}&key={XZYSKey}";
    var result = httpClient.GetAsync(dgurl).Result;
    result.EnsureSuccessStatusCode();
    string responseBody = result.Content.ReadAsStringAsync().Result;
    XZYS = responseBody.JsonToClass<XZYSModel>();

}


void GetAccToken()
{
    string Appid = ConfigurationManager.AppSettings["Appid"]!;
    string AppSecret = ConfigurationManager.AppSettings["AppSecret"]!;
    string tokenUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={Appid}&secret={AppSecret}";
    var getHttpData = httpClient.GetAsync(tokenUrl).Result;
    getHttpData.EnsureSuccessStatusCode();
    string responseBody = getHttpData.Content.ReadAsStringAsync().Result;
    Token token = responseBody.JsonToClass<Token>();
    AccToken = token.Access_token ;
}

void PostWeCharPull(string touser)
{
    string TemplateId = ConfigurationManager.AppSettings["TemplateId"]!;
    string LoveDay = ConfigurationManager.AppSettings["LoveDay"]!;
    string BabyBirthday = ConfigurationManager.AppSettings["BabyBirthday"]!;
    string GoUrl = ConfigurationManager.AppSettings["GoUrl"]!;
    string s = DateTime.Parse(BabyBirthday) > DateTime.Now ? (DateTime.Parse(BabyBirthday).Day - DateTime.Now.Day).ToString() : (DateTime.Parse(BabyBirthday).AddYears(1) - DateTime.Now).ToString();
    string birthDay = s[..s.IndexOf('.')];
    PullData data = new();
    
    data.City.value = Weather.Lives[0].City == "0"?"天气API调用失败啦...": Weather.Lives[0].City;
    data.Weather.value = Weather.Lives[0].Weather;
    data.Temperature.value = Weather.Lives[0].Temperature+"°";
    data.LoveDay.value = (DateTime.Now - DateTime.Parse(LoveDay)).Days.ToString()+" 天";
    data.BeginBirthday.value = birthDay + " 天";
    data.PiPi.value = JiTang.Error_code == 0 ? JiTang.Result.Text : "鸡汤调用失败啦...";
    data.XZYSContent.value = XZYS.Resultcode == "200" ? $"{XZYS.Name} {XZYS.Summary}" : "星座运势调用失败啦...";
    PullBody pullBody = new()
    {
        touser = touser,
        template_id = TemplateId,
        data = data
    };
    
    string weCharPullUrl = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={AccToken}{(!string.IsNullOrWhiteSpace(GoUrl) ? $"&url={GoUrl}" : "")}";
    var strContent = new StringContent(JsonSerializer.Serialize(pullBody), encoding: Encoding.UTF8);
    var response =  httpClient.PostAsync(weCharPullUrl, strContent).Result;
    response.EnsureSuccessStatusCode();
    _= response.Content.ReadAsStringAsync().Result;
    if (response.IsSuccessStatusCode) Console.WriteLine("成功推送啦~");
    else Console.WriteLine("推送失败啦...");
}