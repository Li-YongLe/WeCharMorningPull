using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCharMorningPull.Model
{
    public class JiTangModel
    {
        public int Error_code { get; set; } = 0;
        public JiTangData Result { get; set; } = new();

    }
    public class JiTangData
    {
        public string Text { get; set; } = string.Empty;
    }
}
