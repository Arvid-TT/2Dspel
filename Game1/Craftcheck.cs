using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Craftcheck
    {
        int id;
        int numb;
        public Craftcheck(int i, int n)
        {
            id = i;
            numb = n;
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Numb
        {
            set { numb = value; }
            get { return numb; }
        }
    }
}
