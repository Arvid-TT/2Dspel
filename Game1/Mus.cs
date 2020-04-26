using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Mus
    {
        Rectangle pos;
        Rectangle hitb;
        Slot sloot;
        public Mus(MouseState m)
        {
            pos = new Rectangle(m.X - 10, m.Y - 10, 21, 21);
            hitb = new Rectangle(m.X, m.Y, 1, 1);
            sloot = new Slot(false, 0, m.X - 20, m.Y - 20);
        }
        public Rectangle Pos
        {
            set { pos = value; }
            get { return pos; }
        }
        public Rectangle Hitb
        {
            set { hitb = value; }
            get { return hitb; }
        }
        public Slot Sloot
        {
            set { sloot = value; }
            get { return sloot; }
        }
        public void Musposchange(int x, int y)
        {
            pos.X = x - 10;
            pos.Y = y - 10;
            hitb.X = x;
            hitb.Y = y;
            sloot.Slotposchange(x - 20, y - 20);
        }
        public Slot Mousecontentexchange(ref Slot s1, Slot s2)
        {
            Slot s3 = new Slot(s1.Contain, s1.Numb, s1.Hitb.X, s1.Hitb.Y);
            s3.It = s1.It;
            s1 = new Slot(s2.Contain, s2.Numb, s1.Hitb.X, s1.Hitb.Y);
            s1.It = s2.It;
            s2 = new Slot(s3.Contain, s3.Numb, s2.Hitb.X, s2.Hitb.Y);
            s2.It = s3.It;
            return s2;
        }
        public void Huvudmenyklick(List<Menuchoice> m, Bool meny, Bool hmeny,Bool normal, ref List<Block> l, WorldGen wg, Random slump, Fonster f, Bool wmeny)
        {
            if (m[0].Active)
            {
                l = wg.Generate(f.Höjd, f.Bredd, slump);
                meny.Boll = false;
                hmeny.Boll = false;
                normal.Boll = true;
            }
            else if (m[1].Active)
            {
                hmeny.Boll = false;
                wmeny.Boll = true;
                l = wg.Generate(f.Höjd, f.Bredd, slump);
                foreach(Block b in l)
                {
                    b.Mapposchange(-f.Bredd / 4, 100);
                    b.Double();
                }
            }
            
        }
        public void Worldmenyklick(List<Menuchoice> m, List<Menuchoice> u, List<Menuchoice> c, ref List<Block> l, WorldGen wg, Random slump, Mus mus, SpriteFont sf, Fonster f, Bool meny, Bool wmeny, Bool n, Bool hmeny)
        {
            bool b = false;
            
            if (m[0].Active)
            {
                if (mus.Hitb.X > m[0].Hitb.X + m[0].Hitb.Width / 2 && wg.Antalsjöar <= 9)
                {
                    wg.Antalsjöar++;
                }
                else if(mus.Hitb.X< m[0].Hitb.X + m[0].Hitb.Width / 2 && wg.Antalsjöar >= 1)
                {
                    wg.Antalsjöar--;
                }
                m[0] = new Menuchoice(m[0].Hitb.Y, Convert.ToString(wg.Antalsjöar), sf, m[0].Hitb.X + m[0].Hitb.Width / 2, true, m[0].Hitb.Height, true, true);
                b = true;
            }
            else if (m[1].Active)
            {
                if (mus.Hitb.X > m[1].Hitb.X + m[1].Hitb.Width / 2 && wg.Antalfloder <= 9)
                {
                    wg.Antalfloder++;
                }
                else if (mus.Hitb.X < m[1].Hitb.X + m[1].Hitb.Width / 2 && wg.Antalfloder >= 1)
                {
                    wg.Antalfloder--;
                }
                m[1] = new Menuchoice(m[1].Hitb.Y, Convert.ToString(wg.Antalfloder), sf, m[1].Hitb.X + m[1].Hitb.Width / 2, true, m[1].Hitb.Height, true, true);
                b = true;
            }
            else if (m[2].Active)
            {
                if (mus.Hitb.X > m[2].Hitb.X + m[2].Hitb.Width / 2 && wg. Antalskogar <= 9)
                {
                    wg.Antalskogar++;
                }
                else if (mus.Hitb.X < m[2].Hitb.X + m[2].Hitb.Width / 2 && wg.Antalskogar >= 1)
                {
                    wg.Antalskogar--;
                }
                m[2] = new Menuchoice(m[2].Hitb.Y, Convert.ToString(wg.Antalskogar), sf, m[2].Hitb.X + m[2].Hitb.Width / 2, true, m[2].Hitb.Height, true, true);
                b = true;
            }
            else if (m[3].Active)
            {
                if (mus.Hitb.X > m[3].Hitb.X + m[3].Hitb.Width / 2 && wg.Antalsnöar <= 9)
                {
                    wg.Antalsnöar++;
                }
                else if (mus.Hitb.X < m[3].Hitb.X + m[3].Hitb.Width / 2 && wg.Antalsnöar >= 1)
                {
                    wg.Antalsnöar--;
                }
                m[3] = new Menuchoice(m[3].Hitb.Y, Convert.ToString(wg.Antalsnöar), sf, m[3].Hitb.X + m[3].Hitb.Width / 2, true, m[3].Hitb.Height, true, true);
                b = true;
            }
            else if (m[4].Active)
            {
                if (mus.Hitb.X > m[4].Hitb.X + m[4].Hitb.Width / 2 && wg.Havsstorlek <= 9500)
                {
                    wg.Havsstorlek += 500;
                }
                else if (mus.Hitb.X < m[4].Hitb.X + m[4].Hitb.Width / 2 && wg.Havsstorlek >= 500)
                {
                    wg.Havsstorlek -= 500;
                }
                m[4] = new Menuchoice(m[4].Hitb.Y, Convert.ToString(wg.Havsstorlek), sf, m[4].Hitb.X + m[4].Hitb.Width / 2, true, m[4].Hitb.Height, true, true);
                b = true;
            }
            else if (m[5].Active)
            {
                if (mus.Hitb.X > m[5].Hitb.X + m[5].Hitb.Width / 2 && wg.Sjöstorlek <= 1900)
                {
                    wg.Sjöstorlek += 100;
                }
                else if (mus.Hitb.X < m[5].Hitb.X + m[5].Hitb.Width / 2 && wg.Sjöstorlek >= 100)
                {
                    wg.Sjöstorlek -= 100;
                }
                m[5] = new Menuchoice(m[5].Hitb.Y, Convert.ToString(wg.Sjöstorlek), sf, m[5].Hitb.X + m[5].Hitb.Width / 2, true, m[5].Hitb.Height, true, true);
                b = true;
            }
            else if (m[6].Active)
            {
                if (mus.Hitb.X > m[6].Hitb.X + m[6].Hitb.Width / 2 && wg.Flodbredd <= 9)
                {
                    wg.Flodbredd++;
                }
                else if (mus.Hitb.X < m[6].Hitb.X + m[6].Hitb.Width / 2 && wg.Flodbredd >= 1)
                {
                    wg.Flodbredd--;
                }
                m[6] = new Menuchoice(m[6].Hitb.Y, Convert.ToString(wg.Flodbredd), sf, m[6].Hitb.X + m[6].Hitb.Width / 2, true, m[6].Hitb.Height, true, true);
                b = true;
            }
            else if (m[7].Active)
            {
                if (mus.Hitb.X > m[7].Hitb.X + m[7].Hitb.Width / 2 && wg.Skogsstorlek <= 9500)
                {
                    wg.Skogsstorlek += 500;
                }
                else if (mus.Hitb.X < m[7].Hitb.X + m[7].Hitb.Width/2 && wg.Skogsstorlek >= 500)
                {
                    wg.Skogsstorlek -= 500;
                }
                m[7] = new Menuchoice(m[7].Hitb.Y, Convert.ToString(wg.Skogsstorlek), sf, m[7].Hitb.X + m[7].Hitb.Width / 2, true, m[7].Hitb.Height, true, true);
                b = true;
            }
            else if (m[8].Active)
            {
                if (mus.Hitb.X > m[8].Hitb.X + m[8].Hitb.Width / 2 && wg.Snöstorlek <= 9500)
                {
                    wg.Snöstorlek += 500;
                }
                else if (mus.Hitb.X < m[8].Hitb.X + m[8].Hitb.Width / 2 && wg.Snöstorlek >= 500)
                {
                    wg.Snöstorlek -= 500;

                }
                m[8] = new Menuchoice(m[8].Hitb.Y, Convert.ToString(wg.Snöstorlek), sf, m[8].Hitb.X + m[8].Hitb.Width / 2, true, m[8].Hitb.Height, true, true);
                b = true;
            }
            else if (c[0].Active)
            {
                b = true;
            }
            else if (c[1].Active)
            {
                l = wg.Generate(f.Höjd, f.Bredd, slump);
                meny.Boll = false;
                wmeny.Boll = false;
                n.Boll = true;
                return;
            }
            else if (c[2].Active)
            {
                wmeny.Boll = false;
                hmeny.Boll = true;

                wg = new WorldGen();
            }
            if (b)
            {
                l = wg.Generate(f.Höjd, f.Bredd, slump);
                foreach (Block bb in l)
                {
                    bb.Mapposchange(-f.Bredd / 4, 100);
                    bb.Double();
                }
            }
        }
        public void Update(List<Block> l, List<Worldedit> worldedit, KeyboardState kstate, MouseState mstate, MouseState oldmus, Slot[] inventory, Rectangle wetoggle, Bool we, Rectangle weh, Siffra wef, Rectangle inventoryhitb, Fonster f, WorldGen wg, List<Item> itemlist)
        {
            if (mstate.LeftButton == ButtonState.Pressed)
            {
                if (hitb.Intersects(wetoggle))
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        if (we.Boll == true)
                        {
                            we.Boll = false;
                        }
                        else if (we.Boll == false)
                        {
                            we.Boll = true;
                        }
                    }

                }
                else if (we.Boll && hitb.Intersects(weh))
                {
                    foreach (Worldedit w in worldedit)
                    {
                        w.Active = false;
                        if (w.Bak.Intersects(hitb))
                        {
                            w.Active = true;
                            wef.Tal = w.Id;
                        }
                    }
                }
                else if (hitb.Intersects(inventoryhitb))
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (hitb.Intersects(inventory[i].Hitb))
                            {
                                if (kstate.IsKeyDown(Keys.LeftShift) || kstate.IsKeyDown(Keys.RightShift))
                                {
                                    while (true)
                                    {
                                        int a = inventory[i].Inventoryslotfind(inventory, inventory[i].It, i);
                                        if (a == i)
                                        {
                                            break;
                                        }
                                        else if (inventory[a].It.Id == -1)
                                        {
                                            inventory[a].It = inventory[i].It;
                                            inventory[a].Numb = inventory[i].Numb;
                                            inventory[i].It = new Item();
                                            inventory[i].Numb = 0;
                                            break;
                                        }
                                        else if (inventory[a].Numb + inventory[i].Numb <= inventory[i].It.Max)
                                        {
                                            inventory[a].Numb = inventory[a].Numb + inventory[i].Numb;
                                            inventory[i].It = new Item();
                                            inventory[i].Numb = 0;
                                            break;
                                        }
                                        else
                                        {
                                            int b = inventory[a].It.Max - inventory[a].Numb;
                                            inventory[a].Numb = inventory[a].It.Max;
                                            inventory[i].Numb -= b;
                                        }
                                    }

                                }
                                else if (sloot.It.Id != inventory[i].It.Id || inventory[i].It.Max == inventory[i].Numb || sloot.It.Max == sloot.Numb)
                                {
                                    sloot = Mousecontentexchange(ref inventory[i], sloot);
                                }
                                else if (sloot.Numb + inventory[i].Numb <= sloot.It.Max)
                                {
                                    inventory[i].Numb += sloot.Numb;
                                    sloot.It = new Item();
                                    sloot.Numb = 0;
                                }
                                else
                                {
                                    int a = inventory[i].It.Max - inventory[i].Numb;
                                    inventory[i].Numb = inventory[i].It.Max;
                                    sloot.Numb -= a;
                                }
                            }
                        }
                    }

                }
                else if (we.Boll == false)
                {
                    foreach (Block b in l)
                    {
                        if (hitb.Intersects(b.Rek))
                        {
                            if (b.Addontype == 1)
                            {
                                b.Addontype = 0;
                                wg.Addonextension(l, b.Plats);
                                if (b.Plats % 100 < 99)
                                {
                                    wg.Addonextension(l, b.Plats + 1);
                                }
                                if (b.Plats / 100 < 99)
                                {
                                    wg.Addonextension(l, b.Plats + 100);
                                }
                                inventory[0].Inventoryadd(inventory, itemlist[0]);
                            }
                            else if (b.Addontype == 2 && hitb.Intersects(b.Addon))
                            {
                                b.Addontype = 0;
                                inventory[1].Inventoryadd(inventory, itemlist[1]);
                            }
                            else if(b.Addontype == 3 && hitb.Intersects(b.Addon))
                            {
                                b.Addontype = 0;
                                inventory[2].Inventoryadd(inventory, itemlist[2]);
                            }
                        }

                    }
                }
                else if ((hitb.X < f.Bredd - 100 || hitb.Y > 100) && we.Boll)
                {
                    foreach (Block b in l)
                    {
                        if (b.Rek.Intersects(hitb))
                        {
                            b.Id = wef.Tal;
                        }
                    }
                }
                else if (we.Boll)
                {
                    foreach (Block b in l)
                    {
                        if (b.Map.Intersects(pos))
                        {
                            b.Id = wef.Tal;
                        }
                    }
                }
            }
            if (mstate.RightButton == ButtonState.Pressed && oldmus.RightButton == ButtonState.Released && mstate.LeftButton == ButtonState.Released)
            {
                if (hitb.Intersects(inventoryhitb))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (hitb.Intersects(inventory[i].Hitb))
                        {
                            if (sloot.It.Id == -1 && inventory[i].It.Id != -1)
                            {
                                sloot.It = inventory[i].It;
                                sloot.Numb = inventory[i].Numb / 2;
                                inventory[i].Numb -= sloot.Numb;
                                if (sloot.Numb == 0)
                                {
                                    sloot.It = new Item();
                                }
                            }
                            else if (sloot.It.Id == inventory[i].It.Id && sloot.It.Id != -1 && inventory[i].Numb < inventory[i].It.Max)
                            {
                                sloot.Numb--;
                                inventory[i].Numb++;
                                if (sloot.Numb == 0)
                                {
                                    sloot.It = new Item();
                                }
                            }
                            else if (sloot.It.Id != -1 && inventory[i].It.Id == -1)
                            {
                                inventory[i].It = sloot.It;
                                sloot.Numb--;
                                inventory[i].Numb++;
                                if (sloot.Numb == 0)
                                {
                                    sloot.It = new Item();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
