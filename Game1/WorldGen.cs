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
        Rectangle block;

        public List<Block> Generate(int höjd, int bredd, Random slump)
        {
            List<Block> l = new List<Block>();
            int p = 0;
            for (int y = höjd / 2 - 5000; y < höjd / 2 + 5000; y += 100)
            {
                for (int x = bredd / 2 - 5000; x < bredd / 2 + 5000; x += 100)
                {
                    int t = slump.Next(10);
                    if (t == 9)
                    {
                        Block g = new Block(new Rectangle(x, y, 100, 100), "Gray", p);
                        l.Add(g);
                    }
                    else
                    {
                        Block g = new Block(new Rectangle(x, y, 100, 100), "Green", p);
                        l.Add(g);
                    }
                    p++;
                }
            }
            foreach(Block g in l)
            {
                int tx = g.Plats % 100;
                int ty = (g.Plats - tx) / 100;
                g.Map = new Rectangle(bredd + tx - 100, ty, 1, 1);
            }
            int sx;
            int sy;
            int e;
            for(int i = 0; i < 30; i++)
            {
                sx = slump.Next(100);
                sy = slump.Next(100);
                int sjö = 1;
                List<int> helasjön = new List<int>();
                l[sy * 100 + sx].Färg = "Blue";
                while (sjö <= 200)
                {
                    foreach (Block g in l)
                    {
                        if (g.Färg == "Blue")
                        {
                            helasjön.Add(g.Plats);
                        }
                    }
                    foreach (int ee in helasjön)
                    {
                        if (ee >= 0)
                        {
                            int tx = ee % 100;
                            int ty = (ee - tx) / 100;
                            for (int o = 0; o < 4; o++)
                            {
                                int dir = slump.Next(4);
                                if (dir != 0)
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
                                    if (l[ty * 100 + tx].Färg != "Blue")
                                    {
                                        l[ty * 100 + tx].Färg = "Blue";
                                        sjö++;
                                    }

                                }

                            }
                        }

                    }


                }
                l[sy * 100 + sx].Färg = "River";
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
                int[] helafloden = new int[10000];
                int ugggh = 0;
                foreach (int ee in helafloden)
                {
                    helafloden[ugggh] = -1;
                    ugggh++;
                }
                for (int ii = 0; ii < 3; ii++)
                {
                    int k = 0;
                    foreach (Block g in l)
                    {
                        if (g.Färg == "River")
                        {
                            helafloden[k] = g.Plats;
                            k++;
                        }
                    }
                    foreach (int ee in helafloden)
                    {
                        if (ee >= 0)
                        {
                            int tx = ee % 100;
                            int ty = (ee - tx) / 100;
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
                                        sjö++;
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
            int[] helastranden = new int[10000];
            int oooo = 0;
            foreach (int ee in helastranden)
            {
                helastranden[oooo] = -1;
                oooo++;
            }

            for (int i = 0; i < 3; i++)
            {
                oooo = 0;
                foreach (Block g in l)
                {
                    if (g.Färg == "Yellow")
                    {
                        helastranden[oooo] = g.Plats;
                        oooo++;
                    }
                }
                foreach (int ee in helastranden)
                {
                    if (ee >= 0)
                    {
                        if (ee % 100 > 0)
                        {
                            int r = slump.Next(10);
                            if (l[ee - 1].Färg == "Green" && r == 0)
                            {
                                l[ee - 1].Färg = "Yellow";
                            }

                        }
                        if (ee % 100 < 99)
                        {
                            int r = slump.Next(10);
                            if (l[ee + 1].Färg == "Green" && r == 0)
                            {
                                l[ee + 1].Färg = "Yellow";
                            }
                        }
                        if ((ee - (ee % 100)) / 100 < 99)
                        {
                            int r = slump.Next(10);
                            if (l[ee + 100].Färg == "Green" && r == 0)
                            {
                                l[ee + 100].Färg = "Yellow";
                            }
                        }
                        if ((ee - (ee % 100)) / 100 > 0)
                        {
                            int r = slump.Next(10);
                            if (l[ee - 100].Färg == "Green" && r == 0)
                            {
                                l[ee - 100].Färg = "Yellow";
                            }
                        }

                    }

                }
            }
            sx = slump.Next(100);
            sy = slump.Next(100);
            int snö = 1;
            int[] helasnön = new int[1000];
            e = 0;
            foreach (int i in helasnön)
            {
                helasnön[e] = -1;
                e++;
            }
            l[sy * 100 + sx].Färg = "White";
            while (snö <= 1000)
            {
                int k = 0;
                foreach (Block g in l)
                {
                    if (g.Färg == "White" || g.Färg == "Lightblue")
                    {
                        helasnön[k] = g.Plats;
                        k++;
                    }
                }
                foreach (int i in helasnön)
                {
                    if (i >= 0)
                    {
                        int tx = i % 100;
                        int ty = (i - tx) / 100;
                        for (int o = 0; o < 4; o++)
                        {
                            int dir = slump.Next(4);
                            if (dir != 0)
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
                                if (l[ty * 100 + tx].Färg == "Yellow" || l[ty * 100 + tx].Färg == "Green")
                                {
                                    l[ty * 100 + tx].Färg = "White";
                                    snö++;
                                }
                                else if (l[ty * 100 + tx].Färg == "Blue" || l[ty * 100 + tx].Färg == "Deepblue" || l[ty * 100 + tx].Färg == "Deepdeepblue")
                                {
                                    l[ty * 100 + tx].Färg = "Lightblue";
                                    snö++;
                                }
                                else if (l[ty * 100 + tx].Färg == "Gray")
                                {
                                    l[ty * 100 + tx].Färg = "Lightgray";
                                    snö++;
                                }
                            }

                        }
                    }

                }
            }
            while (true)
            {
                sx = slump.Next(100);
                sy = slump.Next(100);
                if (l[sy * 100 + sx].Färg == "Green")
                {
                    break;
                }
            }

            int skog = 1;
            List<int> helaskogen = new List<int>();
            int oldskog;
            l[sy * 100 + sx].Färg = "Darkgreen";
            while (skog <= 1000)
            {
                int kk = 0;
                foreach (Block g in l)
                {
                    if (g.Färg == "Darkgreen" || g.Färg == "Brown" || g.Färg == "Cyan" || g.Färg == "Darkcyan")
                    {
                        helaskogen.Add(g.Plats);
                    }
                }
                oldskog = skog;
                foreach (int i in helaskogen)
                {
                    if (i >= 0)
                    {
                        int tx = i % 100;
                        int ty = (i - tx) / 100;
                        for (int o = 0; o < 4; o++)
                        {
                            int dir = slump.Next(4);
                            if (dir != 0)
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
                                if (l[ty * 100 + tx].Färg == "Green")
                                {
                                    l[ty * 100 + tx].Färg = "Darkgreen";
                                    skog++;
                                }
                                else if (l[ty * 100 + tx].Färg == "Yellow")
                                {
                                    l[ty * 100 + tx].Färg = "Brown";
                                    skog++;
                                }
                                else if (l[ty * 100 + tx].Färg == "Blue")
                                {
                                    l[ty * 100 + tx].Färg = "Cyan";
                                    skog++;
                                }
                                else if (l[ty * 100 + tx].Färg == "Gray")
                                {
                                    l[ty * 100 + tx].Färg = "Darkcyan";
                                    skog++;
                                }
                            }

                        }
                    }

                }
                if (oldskog == skog && skog > 5)
                {
                    while (true)
                    {
                        sx = slump.Next(100);
                        sy = slump.Next(100);
                        if (l[sy * 100 + sx].Färg == "Green")
                        {
                            l[sy * 100 + sx].Färg = "Darkgreen";
                            break;
                        }
                    }
                }

            }
            
            return l;
        }
    }
}
