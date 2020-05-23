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
        int antalfloder;
        int antalsjöar;
        int havsstorlek;
        int sjöstorlek;
        int flodbredd;
        int snöstorlek;
        int skogsstorlek;
        int antalsnöar;
        int antalskogar;
        public WorldGen()
        {
            antalsjöar = 2;
            sjöstorlek = 400;
            snöstorlek = 1000;
            skogsstorlek = 1000;
            havsstorlek = 1000;
            antalfloder = 1;
            flodbredd = 3;
            antalsnöar = 1;
            antalskogar = 1;
        }
        public int Antalfloder
        {
            set { antalfloder = value; }
            get { return antalfloder; }
        }
        public int Antalsjöar
        {
            set { antalsjöar = value; }
            get { return antalsjöar; }
        }
        public int Havsstorlek
        {
            set { havsstorlek = value; }
            get { return havsstorlek; }
        }
        public int Sjöstorlek
        {
            set { sjöstorlek = value; }
            get { return sjöstorlek; }
        }
        public int Flodbredd
        {
            set { flodbredd = value; }
            get { return flodbredd; }
        }
        public int Snöstorlek
        {
            set { snöstorlek = value; }
            get { return snöstorlek; }
        }
        public int Skogsstorlek
        {
            set { skogsstorlek = value; }
            get { return skogsstorlek; }
        }
        public int Antalskogar
        {
            set { antalskogar = value; }
            get { return antalskogar; }
        }
        public int Antalsnöar
        {
            set { antalsnöar = value; }
            get { return antalsnöar; }
        }
        /// <summary>
       
        /// </summary>
        /// <param name="höjd"></param>
        /// <param name="bredd"></param>
        /// <param name="slump"></param>
        /// <returns></returns>
        
        /// <summary>
        /// Generates world
        /// </summary>
        public List<Block> Generate(int höjd, int bredd, Random slump, ref List<Block> lorg)
        {
            List<Block> l = new List<Block>();
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            List<int> ind = new List<int>();
            List<int> fillout = new List<int>();
            List<int> riverstartpoints = new List<int>();
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
                if (b.Id == 1 && slump.Next(10) == 0)
                {
                    b.Id = 14;
                }
            }
            int sx;
            int sy;
            //Havsgeneration//
            int s = slump.Next(4);
            if (s == 0)
            {
                l[0].Id = -1;
            }
            else if (s == 1)
            {
                l[99].Id = -1;
            }
            else if (s == 2)
            {
                l[9900].Id = -1;
            }
            else
            {
                l[9999].Id = -1;
            }
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l1.Add(1);
            l2.Add(-1);
            ind.Add(0);
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, havsstorlek, slump, 4, false, 3, 0);
            //Sjögeneration//
            for (int i = 0; i < antalsjöar; i++)
            {
                sx = slump.Next(100);
                sy = slump.Next(100);
                Rectangle tillf = new Rectangle(l[sy * 100 + sx].Rek.X - 1000, l[sy * 100 + sx].Rek.Y - 1000, 2100, 2100);
                bool abc = true;
                foreach (Block b in l)
                {
                    if ((b.Id == 3 || b.Id == -1) && b.Rek.Intersects(tillf))
                    {
                        abc = false;
                        i--;
                        break;
                    }
                }
                if (abc)
                {
                    l[sy * 100 + sx].Id = 3;
                    riverstartpoints.Add(l[sy * 100 + sx].Plats);
                }
                
            }
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l1.Add(1);
            l2.Add(3);
            ind.Add(0);
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, sjöstorlek, slump, 4, false, 3, 0);
            foreach(Block b in l)
            {
                if (b.Id == -1)
                {
                    b.Id = 3;
                }
            }
            //Flodgenerering//
            for(int i = 0; i < antalfloder; i++)
            {
                int t = slump.Next(396);
                if (t < 100)
                {
                    riverstartpoints.Add(t);
                }
                else if (t < 199)
                {
                    riverstartpoints.Add(t + 9800);
                }
                else if (t < 297)
                {
                    riverstartpoints.Add((t - 198) * 100);
                }
                else
                {
                    riverstartpoints.Add((t - 296) * 100 + 99);
                }
            }
            foreach (int e in riverstartpoints)
            {
                sx = e % 100;
                sy = e / 100;
                l[e].Id = -2;
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

               
                foreach (Block b in l)
                {
                    if (b.Id == -2)
                    {
                        b.Id = 3;
                    }
                }
            }
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l2.Add(3);
            ind.Add(0);
            Biomegen(l, l1, l2, ind, 0, slump, 2, true, 1, flodbredd);

            //Stranggen//
            fillout.Add(1);
            fillout.Add(3);
            fillout.Add(4);
            l = Surroundfill(l, fillout, 4, 3, false, 4);
            fillout.Clear();
            fillout.Add(1);
            fillout.Add(4);
            fillout.Add(5);
            l = Surroundfill(l, fillout, 5, 4, false, 4);
            fillout.Clear();
            fillout.Add(3);
            l = Surroundfill(l, fillout, 2, 0, true, 1);
            
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add(0);
            l2.Add(2);
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, 0, slump, 7, true, 5, 3);
            //Snöbiomegenerering//
            for(int i = 0; i < antalsnöar; i++)
            {
                sx = slump.Next(100);
                sy = slump.Next(100);
                Rectangle tillf = new Rectangle(l[sy * 100 + sx].Rek.X - 1000, l[sy * 100 + sx].Rek.Y - 1000, 2100, 2100);
                bool abc = true;
                foreach (Block b in l)
                {
                    if (b.Id == 6 && b.Rek.Intersects(tillf))
                    {
                        abc = false;
                        i--;
                        break;
                    }
                }
                if (abc)
                {
                    l[sy * 100 + sx].Id = 6;
                }

            }

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
            l = Biomegen(l, l1, l2, ind, snöstorlek, slump, 4, false, 3, 0);
            foreach(Block b in l)
            {
                if(b.Id==8 && slump.Next(2) == 0)
                {
                    b.Id = 9;
                }
            }
            //Skogsgenerering//
            for (int i = 0; i < antalskogar;)
            {
                sx = slump.Next(100);
                sy = slump.Next(100);
                Rectangle tillf = new Rectangle(l[sy * 100 + sx].Rek.X - 1000, l[sy * 100 + sx].Rek.Y - 1000, 2100, 2100);
                bool abc = false;
                if (l[sy * 100 + sx].Id == 0)
                {
                    abc = true;
                    i++;
                }
                foreach (Block b in l)
                {
                    if (b.Id == 10 && b.Rek.Intersects(tillf) && abc)
                    {
                        abc = false;
                        i--;
                        break;
                    }
                }
                if (abc)
                {

                    l[sy * 100 + sx].Id = 10;
                }

            }
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
            l = Biomegen(l, l1, l2, ind, skogsstorlek, slump, 4, false, 3, 0);
            foreach (Block b in l)
            {
                if (b.Id == 0 && slump.Next(10) == 0)
                {
                    b.Addontype = 1;
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);
                }
                else if(b.Id==0 && slump.Next(10) == 0 && b.Addontype == 0)
                {
                    b.Addontype = 2;
                    b.Addon = new Rectangle(b.Rek.X + slump.Next(80), b.Rek.Y + slump.Next(80), 20, 20);
                }
                else if (b.Id == 0 && slump.Next(10) == 0 && b.Addontype == 0)
                {
                    b.Addontype = 3;
                    b.Addon = new Rectangle(b.Rek.X + slump.Next(50), b.Rek.Y + slump.Next(50), 50, 50);
                }
                if (b.Id == 10 && slump.Next(2) == 0)
                {
                    b.Addontype = 1;
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);
                }
                
            }
            foreach(Block b in l)
            {
                l = Addonextension(l, b.Plats);
                if(b.Id == 1 || b.Id == 7 || b.Id == 8 || b.Id == 12)
                {
                    b.Maxhp = 200;
                    b.Hp = b.Maxhp;
                    b.Tool = 2;
                }
                else if (b.Id == 14)
                {
                    b.Maxhp = 500;
                    b.Hp = b.Maxhp;
                    b.Tool = 2;
                }
                else if (b.Addontype == 1)
                {
                    b.Hp = 50;
                    b.Maxhp = 50;
                    b.Tool = 1;
                }
                else
                {
                    b.Maxhp = 0;
                }
            }
            foreach(Block b in l)
            {
                lorg.Add(new Block(b.Rek, b.Map, b.Id, b.Plats, b.Addon, b.Addonext[0], b.Addonext[1], b.Addonext[2], b.Addonext[3], b.Addontrue[0], b.Addontrue[1], b.Addontrue[2], b.Addontrue[3], b.Addontype, b.Hp, b.Maxhp, b.Tool));
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
        private List<Block> Surroundfill(List<Block> l, List<int> fillout, int id, int omvandlasfrån, bool corners, int req)
        {

            foreach(Block b in l)
            {
                int isittrue = 0;
                bool t = false;
                if (b.Id == omvandlasfrån)
                {
                    isittrue += 4;
                    if (b.Plats % 100 < 99)
                    {
                        if(Surroundcheck(l[b.Plats + 1], fillout))
                        {
                            t = true;
                            isittrue++;
                        }
                        isittrue--;
                    }
                    if (b.Plats % 100 > 0)
                    {
                        if(Surroundcheck(l[b.Plats - 1], fillout))
                        {
                            t = true;
                            isittrue++;
                        }
                        isittrue--;
                    
                    }
                    if (b.Plats / 100 < 99)
                    {
                        if(Surroundcheck(l[b.Plats + 100], fillout))
                        {
                            t = true;
                            isittrue++;
                        }
                        isittrue--;
               
                    }
                    if (b.Plats / 100 > 0)
                    {
                        if(Surroundcheck(l[b.Plats - 100], fillout))
                        {
                            t = true;
                            isittrue++;
                        }
                        isittrue--;
  
                    }
                    if (corners)
                    {
                        isittrue += 4;
                        if(b.Plats % 100 < 99 && b.Plats / 100 < 99)
                        {
                            if(Surroundcheck(l[b.Plats + 101], fillout))
                            {
                                t = true;
                                isittrue++;
                            }
                            isittrue--;

                        }
                        if (b.Plats % 100 < 99 && b.Plats / 100 > 0)
                        {
                            if(Surroundcheck(l[b.Plats - 99], fillout))
                            {
                                t = true;
                                isittrue++;
                            }
                            isittrue--;
                        }
                        if (b.Plats % 100 > 0 && b.Plats / 100 < 99)
                        {
                            if(Surroundcheck(l[b.Plats + 99], fillout))
                            {
                                t = true;
                                isittrue++;
                            }
                            isittrue--;
                        }
                        if (b.Plats % 100 > 0 && b.Plats / 100 > 0)
                        {
                            if(Surroundcheck(l[b.Plats - 101], fillout))
                            {
                                t = true;
                                isittrue++;
                            }
                            isittrue--;
                        }
                    }
                    if (isittrue>=req && t)
                    {
                        b.Id = id;
                    }
                }
            }
            return l;
        }
        private bool Surroundcheck(Block b, List<int> fillout)
        {
            foreach(int i in fillout)
            {
                if (b.Id == i)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Block> Addonextension(List<Block> l, int p)
        {
            if (p % 100 > 0)
            {
                if (l[p].Addontype == l[p - 1].Addontype)
                {
                    l[p].Addontrue[3] = true;
                    l[p - 1].Addontrue[1] = true;
                }
                else
                {
                    l[p].Addontrue[3] = false;
                    l[p - 1].Addontrue[1] = false;
                }
            }
            if (p % 100 < 99)
            {
                if (l[p].Addontype == l[p + 1].Addontype)
                {
                    l[p].Addontrue[1] = true;
                    l[p + 1].Addontrue[3] = true;
                }
                else
                {
                    l[p].Addontrue[1] = false;
                    l[p + 1].Addontrue[3] = false;
                }
            }
            if (p / 100 > 0)
            {
                if (l[p].Addontype == l[p - 100].Addontype)
                {
                    l[p].Addontrue[0] = true;
                    l[p - 100].Addontrue[2] = true;
                }
                else
                {
                    l[p].Addontrue[0] = false;
                    l[p - 100].Addontrue[2] = false;
                }
            }
            if (p / 100 < 99)
            {

                if (l[p].Addontype == l[p + 100].Addontype)
                {
                    l[p].Addontrue[2] = true;
                    l[p + 100].Addontrue[0] = true;
                }
                else
                {
                    l[p].Addontrue[2] = false;
                    l[p + 100].Addontrue[0] = false;
                }

            }
            return l;
        }

    }
}
