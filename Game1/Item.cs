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
        int type;
        int tooldmg;
        //Item id list:
        //-1 = inget
        //0 = trä
        //1 = sten
        //2 = pinne
        //3 = flinta

        //Item type list:
        //0 = crafting
        //1 = axe
        //2 = pickaxe

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
        public Item(int i, Texture2D t, int m, int ty, int td)
        {
            id = i;
            tex = t;
            max = m;
            type = ty;
            tooldmg = td;
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
        public int Tooldmg
        {
            set { tooldmg = value; }
            get { return tooldmg; }
        }
        public int Type
        {
            set { type = value; }
            get { return type; }
        }
    }
}
