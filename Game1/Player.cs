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
        public void Update(ref List<Block> l, KeyboardState kstate, MouseState mstate, Siffra xauto, Siffra yauto, Siffra xautoscd, Siffra yautoscd, Siffra xautohcd, Siffra yautoncd, Siffra xautovcd, Siffra yautoucd, List<Ghost> ghosts)
        {
            bool icy = true;
            if (kstate.IsKeyDown(Keys.W))
            {
                for (int i = 0; i < speed; i++)
                {
                    if (Kollisionskoll(l, pos.X, pos.Y - speed + i, ref icy))
                    {
                        foreach (Block b in l)
                        {
                            b.Poschangey(speed - i);
                        }

                        foreach(Ghost g in ghosts)
                        {
                            g.Poschange(g.Pos.X, g.Pos.Y + speed - i);
                        }
                        break;
                    }

                }

                if (icy && yautoucd.Tal == 0)
                {
                    if (yauto.Tal < 6)
                    {
                        yauto.Tal++;
                    }
                    yautoscd.Tal = 30;
                    yautoucd.Tal = 10;
                }
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                for(int i = 0; i <speed; i++)
                {
                    if (Kollisionskoll(l, pos.X, pos.Y + speed - i, ref icy))
                    {
                        foreach (Block b in l)
                        {
                            b.Poschangey(- speed + i);
                        }
                        foreach (Ghost g in ghosts)
                        {
                            g.Poschange(g.Pos.X, g.Pos.Y - speed + i);
                        }
                        break;
                    }
                }

                if (icy && yautoncd.Tal == 0)
                {
                    if (yauto.Tal > -6)
                    {
                        yauto.Tal--;
                    }
                    yautoscd.Tal = 30;
                    yautoncd.Tal = 10;
                }
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                for (int i = 0; i < speed; i++)
                {
                    if (Kollisionskoll(l, pos.X - speed + i, pos.Y, ref icy))
                    {
                        foreach (Block b in l)
                        {
                            b.Poschangex(speed - i);
                        }
                        foreach (Ghost g in ghosts)
                        {
                            g.Poschange(g.Pos.X + speed - i, g.Pos.Y);
                        }
                        break;
                    }
                }

                if (icy && xautovcd.Tal == 0)
                {
                    if (xauto.Tal < 6)
                    {
                        xauto.Tal++;
                    }
                    xautoscd.Tal = 30;
                    xautovcd.Tal = 10;
                }
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                for(int i = 0; i < speed; i++)
                {
                    if(Kollisionskoll(l, pos.X + speed - i, pos.Y, ref icy))
                    {
                        foreach (Block b in l)
                        {
                            b.Poschangex(- speed + i);
                        }
                        foreach (Ghost g in ghosts)
                        {
                            g.Poschange(g.Pos.X - speed + i, g.Pos.Y);
                        }
                        break;
                    }
                }

                if (icy && xautohcd.Tal == 0)
                {
                    if (xauto.Tal > -6)
                    {
                        xauto.Tal--;
                    }
                    xautoscd.Tal = 30;
                    xautohcd.Tal = 10;
                }
            }
            if (Kollisionskoll(l, pos.X - xauto.Tal, pos.Y, ref icy) == true)
            {
                foreach (Block b in l)
                {
                    b.Poschangex(xauto.Tal);
                }
                foreach (Ghost g in ghosts)
                {
                    g.Poschange(g.Pos.X + xauto.Tal, g.Pos.Y);
                }

            }
            else
            {
                xauto.Tal = 0;
            }
            if (Kollisionskoll(l, pos.X, pos.Y - yauto.Tal, ref icy) == true)
            {
                foreach (Block b in l)
                {
                    b.Poschangey(yauto.Tal);
                }
                foreach (Ghost g in ghosts)
                {
                    g.Poschange(g.Pos.X, g.Pos.Y + yauto.Tal);
                }
            }
            else
            {
                yauto.Tal = 0;
            }
            if (xautoscd.Tal == 0)
            {

                if (xauto.Tal < 0)
                {
                    xauto.Tal++;
                }
                else if (xauto.Tal > 0)
                {
                    xauto.Tal--;
                }
                if (icy)
                {
                    xautoscd.Tal = 30;
                }
                else
                {
                    xautoscd.Tal = 5;
                }
            }
            if(yautoscd.Tal == 0)
            {
                if (yauto.Tal < 0)
                {
                    yauto.Tal++;
                }
                else if (yauto.Tal > 0)
                {
                    yauto.Tal--;
                }
                if (icy)
                {
                    yautoscd.Tal = 30;
                }
                else
                {
                    yautoscd.Tal = 5;
                }
            }

            yautoucd.Tal = Cooldown(yautoucd.Tal);
            xautovcd.Tal = Cooldown(xautovcd.Tal);
            yautoncd.Tal = Cooldown(yautoncd.Tal);
            xautohcd.Tal = Cooldown(xautohcd.Tal);
            yautoscd.Tal = Cooldown(yautoscd.Tal);
            xautoscd.Tal = Cooldown(xautoscd.Tal);


        }
        private bool Kollisionskoll(List<Block> l, int x, int y, ref bool ice)
        {
            bool b = false;
            bool v = false;
            bool vv = false;
            foreach (Block g in l)
            {

                Rectangle r = new Rectangle(x, y, 80, 40);
                if (g.Rek.Intersects(r))
                {
                    if (g.Addontype != "None")
                    {
                        if (g.Addon.Intersects(r))
                        {
                            return false;
                        }
                    }
                    if (g.Färg == "Gray" || g.Färg == "Deepdeepblue" || g.Färg == "Lightgray" || g.Färg == "Lightcyan" || g.Färg == "Darkcyan")
                    {
                        return false;
                    }
                    else if (g.Färg == "Deepblue")
                    {
                        vv = true;
                    }
                    else if (g.Färg == "Blue" || g.Färg == "Lightblue" || g.Färg == "Cyan")
                    {
                        v = true;
                    }
                    if (g.Färg != "Deepblue")
                    {
                        b = true;
                    }
                    if(g.Färg != "Lightblue")
                    {
                        ice = false;
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
        private int Cooldown(int cd)
        {
            if (cd > 0)
            {
                cd--;
            }
            return cd;
        }
    }
}
