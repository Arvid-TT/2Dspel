using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Mus
    {
        Rectangle pos;
        Rectangle hitb;
        Slot slot;
        public Mus(Rectangle p, Rectangle h)
        {
            pos = p;
            hitb = h;
        }
        public Rectangle Pos
        {
            set { pos = value; }
            get { return pos; }
        }
        public Rectangle Hitb
        {
            set { hitb = value; }
            get { return hitb; }
        }

    }
}
