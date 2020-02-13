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
        string färg;
        public Worldedit(int i, int x, int y)
        {
            active = false;
            förg = new Rectangle(x + 3, y + 3, 15, 15);
            bak = new Rectangle(x, y, 21, 21);
            if(i == 0)
            {
                färg = "Green";
                active = true;
            }
            else if(i == 1)
            {
                färg = "Gray";
            }
            else if (i == 2)
            {
                färg = "Yellow";
            }
            else if (i == 3)
            {
                färg = "Blue";
            }
            else if (i == 4)
            {
                färg = "Deepblue";
            }
            else if (i == 5)
            {
                färg = "Deepdeepblue";
            }
            else if (i == 6)
            {
                färg = "White";
            }
            else if (i == 7)
            {
                färg = "Lightblue";
            }
            else if (i == 8)
            {
                färg = "Lightgray";
            }
            else if (i == 9)
            {
                färg = "Lightcyan";
            }
            else if (i == 10)
            {
                färg = "Darkgreen";
            }
            else if (i == 11)
            {
                färg = "Brown";
            }
            else if (i == 1)
            {
                färg = "Cyan";
            }
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
        public string Färg
        {
            set { färg = value; }
            get { return färg; }
        }
    }
}
