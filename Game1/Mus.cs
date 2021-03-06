﻿using Microsoft.Xna.Framework;
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
        /// <summary>
        /// Bestämmer musen och dess delars nya position varje frame.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Musposchange(int x, int y)
        {
            pos.X = x - 10;
            pos.Y = y - 10;
            hitb.X = x;
            hitb.Y = y;
            sloot.Slotposchange(x - 20, y - 20);
        }
        /// <summary>
        /// Byter plats på föremålen mellan musen och ett slot i inventoryt.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Bestämmer vad som händer när man klickar i huvudmenyn.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="meny"></param>
        /// <param name="hmeny"></param>
        /// <param name="normal"></param>
        /// <param name="l"></param>
        /// <param name="wg"></param>
        /// <param name="slump"></param>
        /// <param name="f"></param>
        /// <param name="wmeny"></param>
        /// <param name="lorg"></param>
        /// <param name="end"></param>
        public void Huvudmenyklick(List<Menuchoice> m, ref bool meny, ref bool hmeny, ref bool normal, ref List<Block> l, WorldGen wg, Random slump, Fonster f, ref bool wmeny, ref List<Block> lorg, ref bool end)
        {
            if (m[0].Active)
            {
                l = wg.Generate(f.Höjd, f.Bredd, slump, ref lorg);
                meny  = false;
                hmeny  = false;
                normal  = true;
            }
            else if (m[1].Active)
            {
                hmeny  = false;
                wmeny  = true;
                l = wg.Generate(f.Höjd, f.Bredd, slump, ref lorg);
                foreach(Block b in l)
                {
                    b.Mapposchange(-f.Bredd / 4, 100);
                    b.Double();
                }
            }
            else if (m[2].Active)
            {
                end = true;
                return;
            }
        }
        /// <summary>
        /// Bestämmer vad som händer när man klickar i världsmenyn.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <param name="l"></param>
        /// <param name="wg"></param>
        /// <param name="slump"></param>
        /// <param name="mus"></param>
        /// <param name="sf"></param>
        /// <param name="f"></param>
        /// <param name="meny"></param>
        /// <param name="wmeny"></param>
        /// <param name="n"></param>
        /// <param name="hmeny"></param>
        /// <param name="lorg"></param>
        public void Worldmenyklick(List<Menuchoice> m, List<Menuchoice> u, List<Menuchoice> c, ref List<Block> l, WorldGen wg, Random slump, Mus mus, SpriteFont sf, Fonster f, ref bool meny, ref bool wmeny, ref bool n, ref bool hmeny, ref List<Block> lorg)
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
                l = wg.Generate(f.Höjd, f.Bredd, slump, ref lorg);
                meny  = false;
                wmeny  = false;
                n  = true;
                return;
            }
            else if (c[2].Active)
            {
                wmeny  = false;
                hmeny  = true;

                wg = new WorldGen();
            }
            if (b)
            {
                l = wg.Generate(f.Höjd, f.Bredd, slump, ref lorg);
                foreach (Block bb in l)
                {
                    bb.Mapposchange(-f.Bredd / 4, 100);
                    bb.Double();
                }
            }
        }
        /// <summary>
        /// Bestämmer vad som händer om man klickar i in-game menyn.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="ing"></param>
        /// <param name="normal"></param>
        /// <param name="l"></param>
        /// <param name="wg"></param>
        /// <param name="slump"></param>
        /// <param name="h"></param>
        /// <param name="br"></param>
        /// <param name="menu"></param>
        /// <param name="end"></param>
        /// <param name="lorg"></param>
        /// <param name="men"></param>
        public void Ingamemenuklick(List<Menuchoice> m, ref bool ing, ref bool normal, ref List<Block> l, WorldGen wg, Random slump, int h, int br, ref bool menu, ref bool end, ref List<Block> lorg, ref bool men)
        {
            if (m[0].Active)
            {
                ing = false;
                normal = true;
                return;
            }
            if (m[1].Active)
            {
                ing = false;
                normal = true;
                l.Clear();
                foreach(Block b in lorg)
                {
                    l.Add(new Block(b.Rek, b.Map, b.Id, b.Plats, b.Addon, b.Addonext[0], b.Addonext[1], b.Addonext[2], b.Addonext[3], b.Addontrue[0], b.Addontrue[1], b.Addontrue[2], b.Addontrue[3], b.Addontype, b.Hp, b.Maxhp, b.Tool));
                }
                return;
            }
            if (m[2].Active)
            {
                l = wg.Generate(h, br, slump, ref lorg);
                ing = false;
                normal = true;
                return;
            }
            if (m[3].Active)
            {
                menu = true;
                ing = false;
                men = true;
                return;
            }
            if (m[4].Active)
            {
                end = true;
                return;
            }
        }
        /// <summary>
        /// Uppdaterar allt som har med musen att göra.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="worldedit"></param>
        /// <param name="kstate"></param>
        /// <param name="mstate"></param>
        /// <param name="oldmus"></param>
        /// <param name="inventory"></param>
        /// <param name="wetoggle"></param>
        /// <param name="we"></param>
        /// <param name="weh"></param>
        /// <param name="wef"></param>
        /// <param name="inventoryhitb"></param>
        /// <param name="f"></param>
        /// <param name="wg"></param>
        /// <param name="itemlist"></param>
        /// <param name="total"></param>
        /// <param name="craftable"></param>
        /// <param name="allcrafts"></param>
        /// <param name="outline"></param>
        /// <param name="inside"></param>
        /// <param name="inv"></param>
        /// <param name="slump"></param>
        /// <param name="player"></param>
        /// <param name="trash"></param>
        public void Update(List<Block> l, List<Worldedit> worldedit, KeyboardState kstate, MouseState mstate, MouseState oldmus, Slot[] inventory, Rectangle wetoggle, ref bool we, Rectangle weh, ref int wef, Rectangle inventoryhitb, Fonster f, WorldGen wg, List<Item> itemlist, List<Craftcheck> total, ref List<Crafting> craftable, List<Crafting> allcrafts, ref Rectangle outline, ref Rectangle inside, int inv, Random slump, Rectangle player, Rectangle trash, bool inve)
        {
            if (mstate.LeftButton == ButtonState.Pressed)
            {
                if (hitb.Intersects(wetoggle))
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        if (we  == true)
                        {
                            we  = false;
                        }
                        else if (we  == false)
                        {
                            we  = true;
                        }
                    }

                }
                else if (we  && hitb.Intersects(weh))
                {
                    foreach (Worldedit w in worldedit)
                    {
                        w.Active = false;
                        if (w.Bak.Intersects(hitb))
                        {
                            w.Active = true;
                            wef  = w.Id;
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
                else if (hitb.Intersects(trash))
                {
                    if (sloot.It.Id != -1)
                    {
                        total[sloot.It.Id].Numb -= sloot.Numb;
                        sloot.Numb = 0;
                        sloot.It = new Item();
                        allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                    }

                }
                else if (hitb.Intersects(outline) && inve)
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        foreach (Crafting c in craftable)
                        {
                            if (hitb.Intersects(c.Place.Hitb))
                            {
                                if (kstate.IsKeyDown(Keys.RightShift) || kstate.IsKeyDown(Keys.LeftShift))
                                {
                                    inventory[0].Inventoryadd(inventory, itemlist[c.End]);
                                    total[c.End].Numb++;
                                    foreach (Craftcheck cc in c.Req)
                                    {
                                        total[cc.Id].Numb -= cc.Numb;
                                        inventory[0].Inventoryremove(inventory, itemlist[cc.Id], cc.Numb, sloot);
                                    }
                                    allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                                }
                                else if (sloot.It.Id == -1 || (sloot.It.Id == c.End && sloot.Numb < Sloot.It.Max))
                                {
                                    sloot.It = itemlist[c.End];
                                    sloot.Numb++;
                                    total[c.End].Numb++;
                                    foreach (Craftcheck cc in c.Req)
                                    {
                                        total[cc.Id].Numb -= cc.Numb;
                                        inventory[0].Inventoryremove(inventory, itemlist[cc.Id], cc.Numb, sloot);
                                    }
                                    allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (we  == false)
                {
                    foreach (Block b in l)
                    {
                        if (hitb.Intersects(b.Rek))
                        {
                            if (b.Maxhp > 0 && b.Tool == inventory[inv].It.Type && player.Intersects(b.Rek) == false)
                            {
                                b.Hp -= inventory[inv].It.Tooldmg;
                                if (b.Hp <= 0)
                                {
                                    if (b.Addontype == 1)
                                    {
                                        for (int i = 0; i <= slump.Next(2); i++)
                                        {
                                            total[0].Numb++;
                                            inventory[0].Inventoryadd(inventory, itemlist[0]);
                                        }
                                        if (slump.Next(10) == 0)
                                        {
                                            total[5].Numb++;
                                            inventory[0].Inventoryadd(inventory, itemlist[5]);
                                        }

                                    }
                                    else if (b.Addontype == 4)
                                    {
                                        total[7].Numb++;
                                        inventory[0].Inventoryadd(inventory, itemlist[7]);
                                    }
                                    else if (b.Addontype == 5)
                                    {
                                        total[8].Numb++;
                                        inventory[0].Inventoryadd(inventory, itemlist[8]);
                                    }
                                    else if (b.Addontype == 0)
                                    {
                                        
                                        for (int i = 0; i <= slump.Next(1, 5); i++)
                                        {
                                            total[1].Numb++;
                                            inventory[0].Inventoryadd(inventory, itemlist[1]);
                                        }
                                        if (b.Id == 14)
                                        {

                                            total[11].Numb++;
                                            inventory[0].Inventoryadd(inventory, itemlist[11]);

                                        }
                                        else
                                        {
                                            if (slump.Next(10) == 0)
                                            {
                                                total[12].Numb++;
                                                inventory[0].Inventoryadd(inventory, itemlist[12]);
                                            }
                                        }
                                        b.Id = 11;
                                    }
                                    b.Maxhp = 0;
                                    b.Addontype = 0;
                                    wg.Addonextension(l, b.Plats);
                                    allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                                }
                            }
                            else if (b.Addontype == 2 && hitb.Intersects(b.Addon))
                            {
                                b.Addontype = 0;
                                total[1].Numb++;
                                inventory[1].Inventoryadd(inventory, itemlist[1]);
                                allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                            }
                            else if (b.Addontype == 3 && hitb.Intersects(b.Addon))
                            {
                                b.Addontype = 0;
                                total[2].Numb++;
                                inventory[2].Inventoryadd(inventory, itemlist[2]);
                                allcrafts[0].Transfer(ref craftable, total, allcrafts, itemlist, ref outline, ref inside);
                            }
                            else if (b.Addontype == 0 && inventory[inv].It.Id == 7 && player.Intersects(b.Rek) == false)
                            {
                                b.Addontype = 4;
                                b.Maxhp = 100;
                                b.Hp = 100;
                                b.Tool = 1;
                                b.Addon = new Rectangle(b.Rek.X, b.Rek.Y, b.Rek.Width, b.Rek.Height);
                                wg.Addonextension(l, b.Plats);
                                total[7].Numb--;
                                inventory[0].Inventoryremove(inventory, itemlist[7], 1, sloot);
                            }
                            else if (b.Addontype == 0 && inventory[inv].It.Id == 8 && player.Intersects(b.Rek) == false)
                            {
                                b.Addontype = 5;
                                b.Maxhp = 100;
                                b.Hp = 100;
                                b.Tool = 2;
                                b.Addon = new Rectangle(b.Rek.X, b.Rek.Y, b.Rek.Width, b.Rek.Height);
                                wg.Addonextension(l, b.Plats);
                                total[8].Numb--;
                                inventory[0].Inventoryremove(inventory, itemlist[8], 1, sloot);
                            }
                            else if (b.Addontype == 0 && inventory[inv].It.Id == 9)
                            {
                                b.Addontype = 6;
                                b.Maxhp = 100;
                                b.Hp = 100;
                                b.Tool = 1;
                                b.Addon = new Rectangle(b.Rek.X, b.Rek.Y, b.Rek.Width, b.Rek.Height);
                                wg.Addonextension(l, b.Plats);
                                total[9].Numb--;
                                inventory[0].Inventoryremove(inventory, itemlist[9], 1, sloot);
                            }
                            else if (b.Addontype == 0 && inventory[inv].It.Id == 10)
                            {
                                b.Addontype = 7;
                                b.Maxhp = 100;
                                b.Hp = 100;
                                b.Tool = 2;
                                b.Addon = new Rectangle(b.Rek.X, b.Rek.Y, b.Rek.Width, b.Rek.Height);
                                wg.Addonextension(l, b.Plats);
                                total[10].Numb--;
                                inventory[0].Inventoryremove(inventory, itemlist[10], 1, sloot);
                            }
                        }

                    }
                }
                else if ((hitb.X < f.Bredd - 100 || hitb.Y > 100) && we )
                {
                    foreach (Block b in l)
                    {
                        if (b.Rek.Intersects(hitb))
                        {
                            b.Id = wef;
                        }
                    }
                }
                else if (we )
                {
                    foreach (Block b in l)
                    {
                        if (b.Map.Intersects(pos))
                        {
                            b.Id = wef ;
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
