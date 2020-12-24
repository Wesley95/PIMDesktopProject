using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class TextVerifyDTO
    {
        public string Text { get; set; }
        public string Campo { get; set; }
        public int Sizemin { get; set; }
        public int Sizemax { get; set; }

        public TextVerifyDTO(string text, string campo, int min, int max)
        {
            Text = text;
            Campo = campo;
            Sizemin = min;
            Sizemax = max;
        }
    }
}
