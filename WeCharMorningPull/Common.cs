using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeCharMorningPull.Model;

namespace WeCharMorningPull
{
    public static class Common
    {
        public static T JsonToClass<T>(this string json) where T : class
        {
           return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
