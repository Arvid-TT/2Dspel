using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Slot
    {
        bool contain;
        Item it;
        int numb;
        Rectangle hitb;
        public Slot()
        {

        }
        public Slot(bool c, int n, int x, int y)
        {
            contain = c;
            numb = n;
            hitb = new Rectangle(x, y, 40, 40);
            it = new Item();
        }
        public bool Contain
        {
            set { contain = value; }
            get { return contain; }
        }
        public Item It
        {
            set { it = value; }
            get { return it; }
        }
        public int Numb
        {
            set { numb = value; }
            get { return numb; }
        }
        public Rectangle Hitb
        {
            set { hitb = value; }
            get { return hitb; }
        }
        public void Inventory(Slot[] s)
        {
            for(int y = 0; y < 2; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    s[y * 10 + x] = new Slot(false, 0, 5 + 45 * x, 10 + 50 * y);
                }
            }
        }
    }
}