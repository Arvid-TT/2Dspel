using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class WorldGen
    {

        public List<Block> Generate(int höjd, int bredd, Random slump)
        {
            List<Block> l = new List<Block>();
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<int> ind = new List<int>();
            int p = 0;
            for (int y = höjd / 2 - 5000; y < höjd / 2 + 5000; y += 100)
            {
                for (int x = bredd / 2 - 5000; x < bredd / 2 + 5000; x += 100)
                {
                    l.Add(new Block(new Rectangle(x, y, 100, 100), "Green", p));
                    p++;
                }
            }
            foreach(Block b in l)
            {
                if (slump.Next(100) == 0)
                {
                    b.Färg = "Temp";
                    l1.Clear();
                    l2.Clear();
                    l1.Add("Green");
                    l2.Add("Temp");
                    ind.Clear();
                    ind.Add(0);
                    l = Biomegen(l, l1, l2, ind, 0, slump, 4, true, 3, 4);
                    foreach(Block bb in l)
                    {
                        if (bb.Färg == "Temp")
                        {
                            bb.Färg = "Gray";
                        }
                    }
                }
            }
            foreach(Block b in l)
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
                l[temp].Färg = "Blue";
                l1.Clear();
                l2.Clear();
                ind.Clear();
                l1.Add("Green");
                l1.Add("Gray");
                l1.Add("Temp");
                l2.Add("Blue");
                ind.Add(0);
                ind.Add(0);
                ind.Add(0);
                l = Biomegen(l, l1, l2, ind, 200, slump, 4, false, 3, 0);
                l[temp].Färg = "River";
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
                    l[sy * 100 + sx].Färg = "River";
                }
                List<int> helafloden = new List<int>();
                for (int ii = 0; ii < 3; ii++)
                {
                    foreach (Block b in l)
                    {
                        if (b.Färg == "River")
                        {
                            helafloden.Add(b.Plats);
                        }
                    }
                    foreach (int e in helafloden)
                    {
                        if (e >= 0)
                        {
                            int tx = e % 100;
                            int ty = (e - tx) / 100;
                            for (int o = 0; o < 4; o++)
                            {
                                int dir = slump.Next(4);
                                if (dir <= 1)
                                {
                                    if (o == 0 && tx < 99)
                                    {
                                        tx++;
                                    }
                                    else if (o == 1 && tx > 0)
                                    {
                                        tx--;
                                    }
                                    else if (o == 2 && ty < 99)
                                    {
                                        ty++;
                                    }
                                    else if (o == 3 && ty > 0)
                                    {
                                        ty--;
                                    }
                                    if (l[ty * 100 + tx].Färg == "Gray" || l[ty * 100 + tx].Färg == "Green")
                                    {
                                        l[ty * 100 + tx].Färg = "River";
                                    }

                                }

                            }
                        }

                    }
                }
                foreach (Block g in l)
                {
                    if (g.Färg == "River")
                    {
                        g.Färg = "Blue";
                    }
                }
                foreach(Block b in l)
                {
                    if (b.Färg == "Blue")
                    {
                        b.Färg = "Temp";
                    }
                }
            }
            foreach(Block b in l)
            {
                if (b.Färg == "Temp")
                {
                    b.Färg = "Blue";
                }
            }
            foreach(Block g in l)
            {

                if (g.Färg == "Blue")
                {
                    bool dpw = true;
                    if (g.Plats % 100 > 0)
                    {
                        if (l[g.Plats - 1].Färg != "Blue" && l[g.Plats - 1].Färg != "Deepblue")
                        {
                            dpw = false;
                        }

                    }
                    if (g.Plats % 100 < 99)
                    {
                        if (l[g.Plats + 1].Färg != "Blue" && l[g.Plats + 1].Färg != "Deepblue")
                        {
                            dpw = false;
                        }
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 < 99)
                    {
                        if (l[g.Plats + 100].Färg != "Blue" && l[g.Plats + 100].Färg != "Deepblue")
                        {
                            dpw = false;
                        }
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 > 0)
                    {
                        if (l[g.Plats - 100].Färg != "Blue" && l[g.Plats - 100].Färg != "Deepblue")
                        {
                            dpw = false;
                        }
                    }
                    if (dpw)
                    {
                        g.Färg = "Deepblue";
                    }
                }
            }
            foreach (Block g in l)
            {

                if (g.Färg == "Deepblue")
                {
                    bool dpw = true;
                    if (g.Plats % 100 > 0)
                    {
                        if (l[g.Plats - 1].Färg != "Deepblue" && l[g.Plats - 1].Färg != "Deepdeepblue")
                        {
                            dpw = false;
                        }

                    }
                    if (g.Plats % 100 < 99)
                    {
                        if (l[g.Plats + 1].Färg != "Deepblue" && l[g.Plats + 1].Färg != "Deepdeepblue")
                        {
                            dpw = false;
                        }
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 < 99)
                    {
                        if (l[g.Plats + 100].Färg != "Deepblue" && l[g.Plats + 100].Färg != "Deepdeepblue")
                        {
                            dpw = false;
                        }
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 > 0)
                    {
                        if (l[g.Plats - 100].Färg != "Deepblue" && l[g.Plats - 100].Färg != "Deepdeepblue")
                        {
                            dpw = false;
                        }
                    }
                    if (dpw)
                    {
                        g.Färg = "Deepdeepblue";
                    }
                }
            }
            l[4949].Färg = "Green";
            l[4950].Färg = "Green";
            l[5049].Färg = "Green";
            l[5050].Färg = "Green";
            foreach(Block g in l)
            {
                if (g.Färg == "Green")
                {
                    bool aa = false;
                    bool ab = false;
                    bool ac = false;
                    bool ad = false;
                    if (g.Plats % 100 > 0)
                    {
                        if (l[g.Plats - 1].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                        aa = true;

                    }
                    if (g.Plats % 100 < 99)
                    {
                        if (l[g.Plats + 1].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                        ab = true;
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 < 99)
                    {
                        if (l[g.Plats + 100].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                        ac = true;
                    }
                    if ((g.Plats - (g.Plats % 100)) / 100 > 0)
                    {
                        if (l[g.Plats - 100].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                        ad = true;
                    }
                    if (aa && ac)
                    {
                        if (l[g.Plats + 99].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                    }
                    if (aa && ad)
                    {
                        if (l[g.Plats - 101].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                    }
                    if (ab && ac)
                    {
                        if (l[g.Plats + 101].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                    }
                    if (ab && ad)
                    {
                        if (l[g.Plats - 99].Färg == "Blue")
                        {
                            g.Färg = "Yellow";
                        }
                    }
                }

            }
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add("Green");
            l2.Add("Yellow");
            ind.Add(0);
            l = Biomegen(l, l1, l2, ind, 0, slump, 7, true, 5, 3);
            //Snöbiomegenerering//
            sx = slump.Next(100);
            sy = slump.Next(100);
            l[sy * 100 + sx].Färg = "White";
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add("Green");
            l1.Add("Yellow");
            l1.Add("Gray");
            l1.Add("Blue");
            l1.Add("Deepblue");
            l1.Add("Deepdeepblue");
            l2.Add("White");
            l2.Add("Lightgray");
            l2.Add("Lightblue");
            ind.Add(0);
            ind.Add(0);
            ind.Add(1);
            ind.Add(2);
            ind.Add(2);
            ind.Add(2);
            l = Biomegen(l, l1, l2, ind, 1000, slump, 4, false, 3, 0);
            foreach(Block b in l)
            {
                if(b.Färg=="Lightgray" && slump.Next(2) == 0)
                {
                    b.Färg = "Lightcyan";
                }
            }
            //Skogsgenerering//
            l1.Clear();
            l2.Clear();
            ind.Clear();
            l1.Add("Green");
            l1.Add("Yellow");
            l1.Add("Gray");
            l1.Add("Blue");
            l2.Add("Darkgreen");
            l2.Add("Brown");
            l2.Add("Darkcyan");
            l2.Add("Cyan");
            for(int i = 0; i < 4; i++)
            {
                ind.Add(i);
            }
            while (true)
            {
                int k = slump.Next(10000);
                if (l[k].Färg == "Green")
                {
                    l[k].Färg = "Darkgreen";
                    break;
                }
            }
            l = Biomegen(l, l1, l2, ind, 1000, slump, 4, false, 3, 0);
            foreach (Block b in l)
            {
                if (b.Färg == "Green" && slump.Next(10) == 0)
                {
                    b.Addontype = "Tree";
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);

                }
                if (b.Färg == "Darkgreen" && slump.Next(2) == 0)
                {
                    b.Addontype = "Tree";
                    b.Addon = new Rectangle(b.Rek.X + 40, b.Rek.Y + 40, 20, 20);
                }
            }
            return l;
        }
        private List<Block> Biomegen(List<Block> l, List<string> omvandlasfrån, List<string> omvandlastill, List<int> index, int storlek, Random slump, int spridchans, bool sep, int minspridchans, int antal)
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
                    foreach (string s in omvandlastill)
                    {
                        if (b.Färg == s)
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
                            if (l[e + 1].Färg == omvandlasfrån[i])
                            {
                                l[e + 1].Färg = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (tx > 0 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e - 1].Färg == omvandlasfrån[i])
                            {
                                l[e - 1].Färg = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (ty < 99 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e + 100].Färg == omvandlasfrån[i])
                            {
                                l[e + 100].Färg = omvandlastill[index[i]];
                                break;
                            }
                        }
                    }
                    if (ty > 0 && slump.Next(spridchans) >= minspridchans)
                    {
                        for (int i = 0; i < omvandlasfrån.Count; i++)
                        {
                            if (l[e - 100].Färg == omvandlasfrån[i])
                            {
                                l[e - 100].Färg = omvandlastill[index[i]];
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

    }
}
