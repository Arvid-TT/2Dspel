using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Fonster
    {
        int bredd;
        int höjd;

        public Fonster(int b, int h)
        {
            bredd = b;
            höjd = h;
        }
        public int Bredd
        {
            get { return bredd; }
            set { bredd = value; }
        }
        public int Höjd
        {
            get { return höjd; }
            set { höjd = value; }
        }
    }
}
