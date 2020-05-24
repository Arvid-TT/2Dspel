using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Block
    {
        Rectangle rek;
        Rectangle map;
        int id;
        int plats;
        Rectangle addon;
        Rectangle[] addonext;
        bool[] addontrue;
        int addontype;
        int hp;
        int maxhp;
        int tool;
        //Item id meaning:
        //>0 = temp
        //0 = Grass
        //1 = Stone
        //2 = Sand
        //3 = Shallow Water
        //4 = Water
        //5 = Deep Water
        //6 = Snow
        //7 = Ice
        //8 = Snowstone
        //9 = Icestone
        //10 = Forest Ground
        //11 = Dirt
        //12 = Mossy Stone
        //13 = Forest water
        //14 = Iron

        //Item addontype meaning
        //0 = no addon
        //1 = tree
        //2 = stone
        //3 = stick
        //4 = wooden wall
        //5 = stone wall
        //6 = wooden path
        //7 = stone path

        public Block(Rectangle r, int i, int p)
        {
            rek = r;
            id = i;
            plats = p;
            addontype = 0;
            addonext = new Rectangle[4];
            addontrue = new bool[4];
        }
        public Block(Rectangle r, Rectangle m, int i, int p, Rectangle a, Rectangle an1, Rectangle an2, Rectangle an3, Rectangle an4, bool n1, bool n2, bool n3, bool n4, int at, int h, int mh, int t)
        {
            rek = new Rectangle(r.X, r.Y, r.Width, r.Height);
            map = new Rectangle(m.X, m.Y, m.Width, m.Height);
            id = i;
            plats = p;
            addon = new Rectangle(a.X, a.Y, a.Width, a.Height);
            addonext = new Rectangle[4];
            addonext[0] = new Rectangle(an1.X, an1.Y, an1.Width, an1.Height);
            addonext[1] = new Rectangle(an2.X, an2.Y, an2.Width, an2.Height);
            addonext[2] = new Rectangle(an3.X, an3.Y, an3.Width, an3.Height);
            addonext[3] = new Rectangle(an4.X, an4.Y, an4.Width, an4.Height);
            addontrue = new bool[4];
            addontrue[0] = n1;
            addontrue[1] = n2;
            addontrue[2] = n3;
            addontrue[3] = n4;
            addontype = at;
            hp = h;
            maxhp = mh;
            tool = t;
        }
        
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public Rectangle Rek
        {
            set { rek = value; }
            get { return rek; }
        }
        public int Plats
        {
            set { plats = value; }
            get { return plats; }
        }
        public Rectangle Map
        {
            set { map = value; }
            get { return map; }
        }
        public Rectangle[] Addonext
        {
            set { addonext = value; }
            get { return addonext; }
        }
        public Rectangle Addon
        {
            set { addon = value; }
            get { return addon; }
        }
        public int Addontype
        {
            set { addontype = value; }
            get { return addontype; }
        }
        public bool[] Addontrue
        {
            set { addontrue = value; }
            get { return addontrue; }
        }
        public int Hp
        {
            set { hp = value; }
            get { return hp; }
        }
        public int Maxhp
        {
            set { maxhp = value; }
            get { return maxhp; }
        }
        public int Tool
        {
            set { tool = value; }
            get { return tool; }
        }
        /// <summary>
        /// Ändrar på x-kordinaten för ett block.
        /// </summary>
        /// <param name="x"></param>
        public void Poschangex(int x)
        {
            rek.X += x;
            if (addontype != 0)
            {
                addon.X += x;
            }
        }
        /// <summary>
        /// Ändrar på y-kordinaten för ett block.
        /// </summary>
        /// <param name="y"></param>
        public void Poschangey(int y)
        {
            rek.Y += y;
            if (addontype != 0)
            {
                addon.Y += y;
            }
        }
        /// <summary>
        /// Ändrar på x och y-kordinaten för ett blocks plats på kartan.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Mapposchange(int x, int y)
        {
            map.X += x;
            map.Y += y;
        }
        /// <summary>
        /// Dubblar blockets höjd och bredd på kartan samt flyttar på det för att det ska passa in med andra.
        /// </summary>
        public void Double()
        {
            map.Width *= 2;
            map.Height *= 2;
            map.X += plats % 100;
            map.Y += plats / 100;
        }
    }
}
