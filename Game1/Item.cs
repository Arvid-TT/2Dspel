using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Item
    {
        int id;
        Texture2D tex;
        int max;
        //Item id list:
        //-1 = inget
        //0 = trä
        public Item()
        {
            id = -1;
        }
        public Item(int i, Texture2D t, int m)
        {
            id = i;
            tex = t;
            max = m;
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public Texture2D Tex
        {
            set { tex = value; }
            get { return tex; }
        }
        public int Max
        {
            set { max = value; }
            get { return max; }
        }
    }
}
