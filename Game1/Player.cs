using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Player
    {
        Rectangle pos;
        int speed;
        public Player(int b, int h)
        {
            pos = new Rectangle(b / 2 - 40, h / 2 - 20, 80, 40);
            speed = 5;
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
        public void Update(ref List<Grass> l, KeyboardState kstate, MouseState mstate)
        {
            if (kstate.IsKeyDown(Keys.Up) && Kollisionskoll(l, pos.X, pos.Y - speed))
            {
                List<Grass> tillflista = new List<Grass>();
                foreach (Grass r in l)
                {
                    Grass tillfg = new Grass(new Rectangle(r.Rek.X, r.Rek.Y + speed, 100, 100), r.Färg, r.Plats, r.Map);
                    tillflista.Add(tillfg);
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Down) && Kollisionskoll(l, pos.X, pos.Y + speed))
            {
                List<Grass> tillflista = new List<Grass>();
                foreach (Grass r in l)
                {
                    Grass tillfg = new Grass(new Rectangle(r.Rek.X, r.Rek.Y - speed, 100, 100), r.Färg, r.Plats, r.Map);
                    tillflista.Add(tillfg);
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Left) && Kollisionskoll(l, pos.X - speed, pos.Y))
            {
                List<Grass> tillflista = new List<Grass>();
                foreach (Grass r in l)
                {
                    Grass tillfg = new Grass(new Rectangle(r.Rek.X + speed, r.Rek.Y, 100, 100), r.Färg, r.Plats, r.Map);
                    tillflista.Add(tillfg);
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Right) && Kollisionskoll(l, pos.X + speed, pos.Y))
            {
                List<Grass> tillflista = new List<Grass>();
                foreach (Grass r in l)
                {
                    Grass tillfg = new Grass(new Rectangle(r.Rek.X - speed, r.Rek.Y, 100, 100), r.Färg, r.Plats, r.Map);
                    tillflista.Add(tillfg);
                }
                l = tillflista;
            }
        }
        private bool Kollisionskoll(List<Grass> l, int x, int y)
        {
            bool b = false;
            bool v = false;
            bool vv = false;
            foreach (Grass g in l)
            {

                Rectangle r = new Rectangle(x, y, 80, 40);
                if (g.Rek.Intersects(r))
                {
                    if (g.Färg == "Gray" || g.Färg == "Deepdeepblue")
                    {
                        return false;
                    }
                    else if (g.Färg == "Deepblue")
                    {
                        vv = true;
                    }
                    else if (g.Färg == "Blue")
                    {
                        v = true;
                    }
                    if (g.Färg != "Deepblue")
                    {
                        b = true;
                    }

                }
            }
            if (vv)
            {
                speed = 1;
            }
            else if (v)
            {
                speed = 2;
            }
            else
            {
                speed = 5;
            }
            return b;
        }
    }
}
