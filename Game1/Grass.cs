using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Grass
    {
        Rectangle rek;
        Rectangle map;
        string färg;
        int plats;

        public Grass(Rectangle r, string f, int p)
        {
            rek = r;
            färg = f;
            plats = p;
        }
        public Grass(Rectangle r, string f, int p, Rectangle m)
        {
            rek = r;
            färg = f;
            plats = p;
            map = m;
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
        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
