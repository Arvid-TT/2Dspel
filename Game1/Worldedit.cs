using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Worldedit
    {
        Rectangle bak;
        Rectangle förg;
        bool active;
        int id;
        public Worldedit(int i, int x, int y)
        {
            active = false;
            förg = new Rectangle(x + 3, y + 3, 15, 15);
            bak = new Rectangle(x, y, 21, 21);
            id = i;
        }
        public Rectangle Bak
        {
            set { bak = value; }
            get { return bak; }
        }
        public Rectangle Förg
        {
            set { förg = value; }
            get { return förg; }
        }
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
    }
}
