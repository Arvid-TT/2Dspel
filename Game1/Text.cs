using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Text
    {
        string txt;
        public Text(string t)
        {
            txt = t;
        }
        public string Txt
        {
            set { txt = value; }
            get { return txt; }
        }
    }
}
