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
        string färg;
        int plats;
        Rectangle addon;
        List<Rectangle> addonext;
        string addontype;

        public Block(Rectangle r, string f, int p)
        {
            rek = r;
            färg = f;
            plats = p;
            addontype = "none";
            addonext = new List<Rectangle>();
        }
        
        public string Färg
        {
            set { färg = value; }
            get { return färg; }
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
        public List<Rectangle> Addonext
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
