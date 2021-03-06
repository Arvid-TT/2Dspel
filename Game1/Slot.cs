﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game1
{
    class Slot
    {
        bool contain;
        Item it;
        int numb;
        Rectangle hitb;
        Rectangle förg;
        public Slot()
        {
        }
        public Slot(bool c, int n, int x, int y)
        {
            contain = c;
            numb = n;
            hitb = new Rectangle(x, y, 40, 40);
            förg = new Rectangle(x + 3, y + 3, 34, 34);
            it = new Item();
        }
        public Slot(bool c, int n, int x, int y, Item i)
        {
            contain = c;
            numb = n;
            hitb = new Rectangle(x, y, 40, 40);
            förg = new Rectangle(x + 3, y + 3, 34, 34);
            it = new Item(i.Id, i.Tex, i.Max);
        }
        public bool Contain
        {
            set { contain = value; }
            get { return contain; }
        }
        public Item It
        {
            set { it = value; }
            get { return it; }
        }
        public int Numb
        {
            set { numb = value; }
            get { return numb; }
        }
        public Rectangle Hitb
        {
            set { hitb = value; }
            get { return hitb; }
        }
        public Rectangle Förg
        {
            set { förg = value; }
            get { return förg; }
        }
        /// <summary>
        /// Byter plats på en slot.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Slotposchange(int x, int y)
        {
            hitb.X = x;
            hitb.Y = y;
            förg.X = x + 3;
            förg.Y = y + 3;
        }
        /// <summary>
        /// Skapar inventoryt.
        /// </summary>
        /// <param name="s"></param>
        public void Inventory(Slot[] s)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    s[y * 10 + x] = new Slot(false, 0, 5 + 45 * x, 10 + 50 * y);
                }
            }
        }
        /// <summary>
        /// Hittar rutan i inventoryt med det rätta föremålet.
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="item"></param>
        /// <param name="orgpos"></param>
        /// <returns></returns>
        public int Inventoryslotfind(Slot[] inv, Item item, int orgpos)
        {
            for (int i = 0; i < inv.Length; i++)
            {
                if (inv[i].It == item && i != orgpos && inv[i].Numb < item.Max)
                {
                    return i;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (inv[i].It.Id == -1 && i < orgpos)
                {
                    return i;
                }
            }
            return orgpos;
        }
        /// <summary>
        /// Lägger till ett föremål i inventoryt.
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="item"></param>
        public void Inventoryadd(Slot[] inv, Item item)
        {
            foreach (Slot s in inv)
            {
                if (s.It == item && s.Numb < item.Max)
                {
                    s.Numb++;
                    return;
                }
            }
            foreach (Slot s in inv)
            {
                if (s.It.Id == -1)
                {
                    s.It = item;
                    s.Numb = 1;
                    return;
                }
            }
        }
        /// <summary>
        /// Tar bort ett antal av ett visst föremål från inventoryt.
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="item"></param>
        /// <param name="numb"></param>
        /// <param name="mus"></param>
        public void Inventoryremove(Slot[] inv, Item item, int numb, Slot mus)
        {
            while (true)
            {
                int search = -1;
                int ant = 100;
                for (int i = 0; i < inv.Length; i++)
                {
                    if (inv[i].It == item && ant > inv[i].Numb)
                    {
                        ant = inv[i].Numb;
                        search = i;
                    }
                }
                if (mus.It == item && ant == 100)
                {
                    ant = mus.Numb;
                }
                if (ant > numb && search > -1)
                {
                    inv[search].Numb -= numb;
                    return;
                }
                else if (ant == numb && search > -1)
                {
                    inv[search].Numb = 0;
                    inv[search].It = new Item();
                    return;
                }
                else if (ant < numb && search > -1)
                {
                    inv[search].Numb = 0;
                    inv[search].It = new Item();
                    numb -= ant;
                }
                else
                {
                    if (ant > numb)
                    {
                        mus.Numb -= numb;
                        return;
                    }
                    else if(ant == numb)
                    {
                        mus.Numb = 0;
                        mus.It = new Item();
                        return;
                    }
                }
            }

        }
    }
}