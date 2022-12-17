using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCharMorningPull.Model
{
    public class Token
    {
        public string Access_token { get; set; } = string.Empty;
        public int Expires_in { get; set; } = 0;
    }
}
