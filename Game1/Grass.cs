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
        string färg;

        public Grass(Rectangle r, string f)
        {
            rek = r;
            färg = f;
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
        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
