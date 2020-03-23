using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        Slot sloot;
        public Mus(MouseState m)
        {
            pos = new Rectangle(m.X - 10, m.Y - 10, 21, 21);
            hitb = new Rectangle(m.X, m.Y, 1, 1);
            sloot = new Slot(false, 0, m.X - 20, m.Y - 20);
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
        public Slot Sloot
        {
            set { sloot = value; }
            get { return sloot; }
        }
        public void Musposchange(int x, int y)
        {
            pos.X = x - 10;
            pos.Y = y - 10;
            hitb.X = x;
            hitb.Y = y;
            sloot.Slotposchange(x - 20, y - 20);
        }
        public Slot Mousecontentexchange(ref Slot s1, Slot s2)
        {
            Slot s3 = new Slot(s1.Contain, s1.Numb, s1.Hitb.X, s1.Hitb.Y);
            s3.It = s1.It;
            s1 = new Slot(s2.Contain, s2.Numb, s1.Hitb.X, s1.Hitb.Y);
            s1.It = s2.It;
            s2 = new Slot(s3.Contain, s3.Numb, s2.Hitb.X, s2.Hitb.Y);
            s2.It = s3.It;
            return s2;
        }
    }
}
