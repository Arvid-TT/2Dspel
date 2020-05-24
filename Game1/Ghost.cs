using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Ghost
    {
        Rectangle pos;
        int speed;
        public Ghost(Random slump, List<Block> l)
        {
            int p = slump.Next(10000);
            speed = 5;
            pos = new Rectangle(l[p].Rek.X, l[p].Rek.Y, 50, 50);
        }
        public Rectangle Pos
        {
            set { pos = value; }
            get { return pos; }
        }
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }
        /// <summary>
        /// Uppdaterar spökernas rörelse.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Update(Player p)
        {
            if (p.Pos.X + 70 < pos.X)
            {
                pos.X -= speed;
            }
            else if (p.Pos.X > pos.X + 30)
            {
                pos.X += speed;
            }
            if (p.Pos.Y + 30 < pos.Y)
            {
                pos.Y -= speed;
            }
            else if (p.Pos.Y > pos.Y + 30)
            {
                pos.Y += speed;
            }
            if (pos.Intersects(p.Pos))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Byter plats på spökena.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Poschange(int x, int y)
        {
            pos.X = x;
            pos.Y = y;
        }
    }
}
