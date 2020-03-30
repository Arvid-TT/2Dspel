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
        Texture2D[] addontex;
        bool[] addontrue;
        string addontype;
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
        //12 = Forest water
        //13 = Mossy Stone
        public Block(Rectangle r, int i, int p)
        {
            rek = r;
            id = i;
            plats = p;
            addontype = "none";
            addonext = new Rectangle[4];
            addontex = new Texture2D[4];
            addontrue = new bool[4];
        }
        public Block(Block b)
        {
            rek = b.Rek;
            map = b.Map;
            id = b.Id;
            plats = b.Plats;
            addon = b.Addon;
            addonext = b.Addonext;
            addontype = b.Addontype;
            addontrue = new bool[4];
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
        public string Addontype
        {
            set { addontype = value; }
            get { return addontype; }
        }
        public Texture2D[] Addontex
        {
            set { addontex = value; }
            get { return addontex; }
        }
        public bool[] Addontrue
        {
            set { addontrue = value; }
            get { return addontrue; }
        }
        public void Draw(SpriteBatch spritebatch)
        {

        }
        public void Poschangex(int x)
        {
            rek.X += x;
            if (addontype != "none")
            {
                addon.X += x;
            }
        }
        public void Poschangey(int y)
        {
            rek.Y += y;
            if (addontype != "none")
            {
                addon.Y += y;
            }
        }
        public void Poschange(int x, int y)
        {
            rek.X = x;
            rek.Y = y;
        }
    }
}
