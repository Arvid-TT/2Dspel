using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class WorldGen
    {

        public List<Block> Generate(int höjd, int bredd, Random slump, Texture2D[] treeparts)
        {
            List<Block> l = new List<Block>();
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            List<int> ind = new List<int>();
            int p = 0;
            for (int y = höjd / 2 - 5000; y < höjd / 2 + 5000; y += 100)
            {
                for (int x = bredd / 2 - 5000; x < bredd / 2 + 5000; x += 100)
                {
                    l.Add(new Block(new Rectangle(x, y, 100, 100), 0, p));
                    p++;
                }
            }
            foreach(Block b in l)
            {
                if (slump.Next(100) == 0)
                {
                    b.Id = 1;
                }

            }
            l1.Clear();
            l2.Clear();
            l1.Add(0);
            l2.Add(1);
            ind.Clear();
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, 0, slump, 4, true, 3, 4);
            foreach (Block b in l)
            {
                int tx = b.Plats % 100;
                int ty = (b.Plats - tx) / 100;
                b.Map = new Rectangle(bredd + tx - 100, ty, 1, 1);
            }
            int sx;
            int sy;
            for(int i = 0; i < 2; i++)
            {
                int temp = slump.Next(10000);
                sy = temp / 100;
                sx = temp % 100;
                l[temp].Id = 3;
                l1.Clear();
                l2.Clear();
                ind.Clear();
                l1.Add(0);
                l1.Add(1);
                l1.Add(-1);
                l2.Add(3);
                ind.Add(0);
                ind.Add(0);
                ind.Add(0);
                l = Biomegen(l, l1, l2, ind, 200, slump, 4, false, 3, 0);
                l[temp].Id = -2;
                int d;
                if (sy < 50 && sx < 50)
                {
                    d = 3;
                }
                else if (sy < 50 && sx >= 50)
                {
                    d = 4;
                }
                else if (sy >= 50 && sx < 50)
                {
                    d = 2;
                }
                else if (sy >= 50 && sx >= 50)
                {
                    d = 1;
                }
                else
                {
                    d = 0;
                }
                bool f = false;
                while (d != 0)
                {
                    if (((d == 1 && f == false) || (d == 4 && f)) && sx > 0)
                    {
                        sx--;
                    }
                    else if (((d == 2 && f == false) || (d == 1 && f)) && sy > 0)
                    {
                        sy--;
                    }
                    else if (((d == 3 && f == false) || (d == 2 && f)) && sx < 99)
                    {
                        sx++;
                    }
                    else if (((d == 4 && f == false) || (d == 3 && f)) && sy < 99)
                    {
                        sy++;
                    }
                    else
                    {
                        break;
                    }
                    int slumptillf = slump.Next(5);
                    if (slumptillf == 0)
                    {
                        if (f)
                        {
                            f = false;
                        }
                        else
                        {
                            f = true;
                        }
                    }
                    l[sy * 100 + sx].Id = -2;
                }
                l1.Clear();
                l2.Clear();
                ind.Clear();
                l1.Add(0);
                l2.Add(-2);
                ind.Add(0);
                Biomegen(l, l1, l2, ind, 0, slump, 2, true, 1, 3);
               
                foreach (Block b in l)
                {
                    if (b.Id == -2 || b.Id == 3)
                    {
                        b.Id = -1;
                    }
                }
            }
            foreach(Block b in l)
            {
                if (b.Id == -1)
                {
                    b.Id = 3;
                }
            }
            foreach(Block b in l)
            {

                if (b.Id == 3)
                {
                    bool dpw = true;
                    if (b.Plats % 100 > 0)
                    {
                        if (l[b.Plats - 1].Id == 0)
                        {
                            dpw = false;
                        }

                    }
                    if (b.Plats % 100 < 99)
                    {
                        if (l[b.Plats + 1].Id == 0)
                        {
                            dpw = false;
                        }
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 < 99)
                    {
                        if (l[b.Plats + 100].Id == 0)
                        {
                            dpw = false;
                        }
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 > 0)
                    {
                        if (l[b.Plats - 100].Id == 0)
                        {
                            dpw = false;
                        }
                    }
                    if (dpw)
                    {
                        b.Id = 4;
                    }
                }
            }
            foreach (Block b in l)
            {

                if (b.Id == 4)
                {
                    bool dpw = true;
                    if (b.Plats % 100 > 0)
                    {
                        if (l[b.Plats - 1].Id == 0 || l[b.Plats - 1].Id == 3)
                        {
                            dpw = false;
                        }

                    }
                    if (b.Plats % 100 < 99)
                    {
                        if (l[b.Plats + 1].Id == 0 || l[b.Plats + 1].Id == 3)
                        {
                            dpw = false;
                        }
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 < 99)
                    {
                        if (l[b.Plats + 100].Id == 0 || l[b.Plats + 100].Id == 3)
                        {
                            dpw = false;
                        }
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 > 0)
                    {
                        if (l[b.Plats - 100].Id == 0 || l[b.Plats - 100].Id == 3)
                        {
                            dpw = false;
                        }
                    }
                    if (dpw)
                    {
                        b.Id = 5;
                    }
                }
            }
            foreach(Block b in l)
            {
                if (b.Id == 0)
                {
                    bool aa = false;
                    bool ab = false;
                    bool ac = false;
                    bool ad = false;
                    if (b.Plats % 100 > 0)
                    {
                        if (l[b.Plats - 1].Id == 3)
                        {
                            b.Id = 2;
                        }
                        aa = true;

                    }
                    if (b.Plats % 100 < 99)
                    {
                        if (l[b.Plats + 1].Id == 3)
                        {
                            b.Id = 2;
                        }
                        ab = true;
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 < 99)
                    {
                        if (l[b.Plats + 100].Id == 3)
                        {
                            b.Id = 2;
                        }
                        ac = true;
                    }
                    if ((b.Plats - (b.Plats % 100)) / 100 > 0)
                    {
                        if (l[b.Plats - 100].Id == 3)
                        {
                            b.Id = 2;
                        }
                        ad = true;
                    }
                    if (aa && ac)
                    {
                        if (l[b.Plats + 99].Id == 3)
                        {
                            b.Id = 2;
                        }
                    }
                    if (aa && ad)
                    {
                        if (l[b.Plats - 101].Id == 3)
                        {
                            b.Id = 2;
                        }
                    }
                    if (ab && ac)
                    {
                        if (l[b.Plats + 101].Id == 3)
                        {
                            b.Id = 2;
                        }
                    }
                    if (ab && ad)
                    {
                        if (l[b.Plats - 99].Id == 3)
                        {
                            b.Id = 2;
                        }
                    }
                }

            }
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l2.Add(2);
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, 0, slump, 7, true, 5, 3);
            //Snöbiomegenerering//
            sx = slump.Next(100);
            sy = slump.Next(100);
            l[sy * 100 + sx].Id = 6;
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l1.Add(2);
            l1.Add(1);
            l1.Add(3);
            l1.Add(4);
            l1.Add(5);
            l2.Add(6);
            l2.Add(8);
            l2.Add(7);
            ind.Add(0);
            ind.Add(0);
            ind.Add(1);
            ind.Add(2);
            ind.Add(2);
            ind.Add(2);
            l = Biomegen(l, l1, l2, ind, 1000, slump, 4, false, 3, 0);
            foreach(Block b in l)
            {
                if(b.Id==8 && slump.Next(2) == 0)
                {
                    b.Id = 9;
                }
            }
            //Skogsgenerering//
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l1.Add(2);
            l1.Add(1);
            l1.Add(3);
            l2.Add(10);
            l2.Add(11);
            l2.Add(12);
            l2.Add(13);
            for(int i = 0; i < 4; i++)
            {
                ind.Add(i);
            }
            while (true)
            {
                int k = slump.Next(10000);
                if (l[k].Id == 0)
                {
                    l[k].Id = 10;
                    break;
                }
            }
            l = Biomegen(l, l1, l2, ind, 1000, slump, 4, false, 3, 0);
            foreach (Block b in l)
            {
                if (b.Id == 0 && slump.Next(10) == 0)
                {
                    b.Addontype = "Tree";
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);
                    b.Addontex = treeparts;
                }
                if (b.Id == 10 && slump.Next(2) == 0)
                {
                    b.Addontype = "Tree";
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);
                    b.Addontex = treeparts;
                }
            }
            foreach(Block b in l)
            {
                l = Addonextension(l, b.Plats);
            }
            return l;
        }
        private List<Block> Biomegen(List<Block> l, List<int> omvandlasfrån, List<int> omvandlastill, List<int> index, int storlek, Random slump, int spridchans, bool sep, int minspridchans, int antal)
        {
            int g = 0;
            List<int> wholebiome = new List<int>();
            int old;
            while ((wholebiome.Count < storlek && sep == false) || (sep && g < antal))
            {
                g++;
                wholebiome.Clear();
                foreach (Block b in l)
                {
                    foreach (int s in omvandlastill)
                    {
                        if (b.Id == s)
                        {
                            wholebiome.Add(b.Plats);
                            break;
                        }
                    }
                }
                old = wholebiome.Count;
                foreach (int e in wholebiome)
                {
                    int tx = e % 100;
                    int ty = (e - tx) / 100;
                    if (tx < 99 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e + 1].Id == omvandlasfrån[i])
                            {
                                l[e + 1].Id = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (tx > 0 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e - 1].Id == omvandlasfrån[i])
                            {
                                l[e - 1].Id = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (ty < 99 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e + 100].Id == omvandlasfrån[i])
                            {
                                l[e + 100].Id = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (ty > 0 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e - 100].Id == omvandlasfrån[i])
                            {
                                l[e - 100].Id = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                }
                if (old + 5 > wholebiome.Count && g > 1000)
                {
                    break;
                }
            }
            return l;
            
        }
        public List<Block> Addonextension(List<Block> l, int p)
        {
            if (p % 100 > 0)
            {
                if (l[p].Addontype == l[p - 1].Addontype)
                {
                    l[p - 1].Addontrue[1] = true;
                    l[p].Addontrue[3] = true;
                }
                else
                {
                    l[p - 1].Addontrue[1] = false;
                    l[p].Addontrue[3] = false;
                }

            }
            if (p / 100 > 0)
            {
                if (l[p].Addontype == l[p - 100].Addontype)
                {
                    l[p - 100].Addontrue[2] = true;
                    l[p].Addontrue[0] = true;
                }
                else
                {
                    l[p - 100].Addontrue[2] = false;
                    l[p].Addontrue[0] = false;
                }

            }
            return l;
        }

    }
}
