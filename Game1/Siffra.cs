using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Siffra
    {
        int tal;
        public Siffra(int t)
        {
            tal = t;
        }
        public int Tal
        {
            set { tal = value; }
            get { return tal; }
        }
    }
}
