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
        public void Update(ref List<Block> l, KeyboardState kstate, MouseState mstate, ref int xauto, ref int yauto, ref int xautoscd, ref int yautoscd, ref int xautohcd, ref int yautoncd, ref int xautovcd, ref int yautoucd, List<Ghost> ghosts)
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

                if (icy && yautoucd  == 0)
                {
                    if (yauto  < 6)
                    {
                        yauto ++;
                    }
                    yautoscd  = 30;
                    yautoucd  = 10;
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

                if (icy && yautoncd  == 0)
                {
                    if (yauto  > -6)
                    {
                        yauto --;
                    }
                    yautoscd  = 30;
                    yautoncd  = 10;
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

                if (icy && xautovcd  == 0)
                {
                    if (xauto  < 6)
                    {
                        xauto ++;
                    }
                    xautoscd  = 30;
                    xautovcd  = 10;
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

                if (icy && xautohcd  == 0)
                {
                    if (xauto  > -6)
                    {
                        xauto --;
                    }
                    xautoscd  = 30;
                    xautohcd  = 10;
                }
            }
            if (Kollisionskoll(l, pos.X - xauto , pos.Y, ref icy) == true)
            {
                foreach (Block b in l)
                {
                    b.Poschangex(xauto );
                }
                foreach (Ghost g in ghosts)
                {
                    g.Poschange(g.Pos.X + xauto , g.Pos.Y);
                }

            }
            else
            {
                xauto  = 0;
            }
            if (Kollisionskoll(l, pos.X, pos.Y - yauto , ref icy) == true)
            {
                foreach (Block b in l)
                {
                    b.Poschangey(yauto );
                }
                foreach (Ghost g in ghosts)
                {
                    g.Poschange(g.Pos.X, g.Pos.Y + yauto );
                }
            }
            else
            {
                yauto  = 0;
            }
            if (xautoscd  == 0)
            {

                if (xauto  < 0)
                {
                    xauto ++;
                }
                else if (xauto  > 0)
                {
                    xauto --;
                }
                if (icy)
                {
                    xautoscd  = 30;
                }
                else
                {
                    xautoscd  = 5;
                }
            }
            if(yautoscd  == 0)
            {
                if (yauto  < 0)
                {
                    yauto ++;
                }
                else if (yauto  > 0)
                {
                    yauto --;
                }
                if (icy)
                {
                    yautoscd  = 30;
                }
                else
                {
                    yautoscd  = 5;
                }
            }

            yautoucd  = Cooldown(yautoucd );
            xautovcd  = Cooldown(xautovcd );
            yautoncd  = Cooldown(yautoncd );
            xautohcd  = Cooldown(xautohcd );
            yautoscd  = Cooldown(yautoscd );
            xautoscd  = Cooldown(xautoscd );


        }
        private bool Kollisionskoll(List<Block> l, int x, int y, ref bool ice)
        {
            bool bb = false;
            bool v = false;
            bool vv = false;
            bool vg = false;
            foreach (Block b in l)
            {

                Rectangle r = new Rectangle(x, y, 80, 40);
                if (b.Rek.Intersects(r))
                {
                    if (b.Addontype == 1 || (b.Addontype > 3 && b.Addontype < 6))
                    {
                        if (b.Addon.Intersects(r))
                        {
                            return false;
                        }
                    }
                    else if (b.Addontype == 6 || b.Addontype == 7)
                    {
                        vg = true;
                        ice = false;
                        bb = true;
                    }
                    else if (b.Id == 1 || b.Id == 5 || b.Id == 8 || b.Id == 9 || b.Id == 12 || b.Id == 14)
                    {
                        return false;
                    }
                    else if (b.Id == 4)
                    {
                        vv = true;
                    }
                    else if (b.Id == 3 || b.Id == 7 || b.Id == 13)
                    {
                        v = true;
                    }
                    if (b.Id != 4)
                    {
                        bb = true;
                    }
                    if(b.Id != 7)
                    {
                        ice = false;
                    }
                }
            }
            if (vg)
            {
                speed = 6;
            }
            else if (vv)
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
            return bb;
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
