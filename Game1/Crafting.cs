﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Crafting
    {
        List<Craftcheck> req;
        int end;
        Slot place;
        public Crafting(List<Craftcheck> r, int e)
        {
            req = new List<Craftcheck>();
            foreach(Craftcheck rr in r)
            {
                req.Add(new Craftcheck(rr.Id, rr.Numb));
            }
            end = e;
        }
        public List<Craftcheck> Req
        {
            set { req = value; }
            get { return req; }
        }
        public int End
        {
            set { end = value; }
            get { return end; }
        }
        public Slot Place
        {
            set { place = value; }
            get { return place; }
        }
        public void Transfer(ref List<Crafting> n, List<Craftcheck> cc, List<Crafting> a, List<Item> itemlist, ref Rectangle outline, ref Rectangle inside)
        {
            n.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                bool b = true;
                foreach(Craftcheck c in a[i].Req)
                {
                    if (cc[c.Id].Numb < c.Numb)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    n.Add(new Crafting(a[i].Req, a[i].End));
                }
            }
            for (int i = 0; i < n.Count; i++)
            {
                n[i].Place = new Slot(true, 0, 5 + 40 * i, 115, itemlist[n[i].End]);
            }

            outline.Width = n.Count * 40;
            inside.Width = outline.Width - 6;

        }
        public void Requirementshow(ref Rectangle p, ref Rectangle o)
        {
            p = new Rectangle(place.Hitb.X, place.Hitb.Y + 40, 40, 20);
            if(place.Hitb.X - req.Count*20 >= -15)
            {
                o = new Rectangle(place.Hitb.X + 20 - req.Count * 20, place.Hitb.Y + 60, req.Count * 40, 40);
            }
            else
            {
                o = new Rectangle(5, place.Hitb.Y + 60, req.Count * 40, 40);
            }
        }
    }

}
