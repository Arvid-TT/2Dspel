using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Menuchoice
    {
        string text;
        Vector2 textlocation;
        Vector2 rightchoice;
        Vector2 leftchoice;
        Rectangle hitb;
        bool active;
        bool clickable;
        bool changable;
        public Menuchoice(int y, string t, SpriteFont sf, int f, bool a, int b, bool c, bool d)
        {
            textlocation = new Vector2(f - ((t.Length * sf.LineSpacing) / 2), y);
            clickable = c;
            changable = d;
            text = t;
            if (c)
            {
                rightchoice = new Vector2(textlocation.X + ((t.Length + 1) * sf.LineSpacing), y);
                leftchoice = new Vector2(textlocation.X - 2 * sf.LineSpacing, y);
                hitb = new Rectangle(Convert.ToInt32(leftchoice.X), Convert.ToInt32(leftchoice.Y), sf.LineSpacing * (t.Length + 4), b);
                active = a;
            }
        }
        public string Text
        {
            set { text = value; }
            get { return text; }
        }
        public Vector2 Textlocation
        {
            set { textlocation = value; }
            get { return textlocation; }
        }
        public Vector2 Rightchoice
        {
            set { rightchoice = value; }
            get { return rightchoice; }
        }
        public Vector2 Leftchoice
        {
            set { leftchoice = value; }
            get { return leftchoice; }
        }
        public Rectangle Hitb
        {
            set { hitb = value; }
            get { return hitb; }
        }
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }
        public bool Clickable
        {
            set { clickable = value; }
            get { return clickable; }
        }
        public bool Changable
        {
            set { changable = value; }
            get { return changable; }
        }
        public void Mainmenucreate(List<Menuchoice> m, SpriteFont sf, int f)
        {
            m.Add(new Menuchoice(200, "Create New World", sf, f, false, 30, true, false));
            m.Add(new Menuchoice(300, "Create Custom World", sf, f, false, 30, true, false));
            m.Add(new Menuchoice(400, "Settings", sf, f, false, 30, true, false));
        }
        public void Worldmenucreate(List<Menuchoice> m, List<Menuchoice> u, List<Menuchoice> c, SpriteFont sf1, SpriteFont sf2, int f, WorldGen wg)
        {
            u.Add(new Menuchoice(70, "Number of Lakes", sf2, f/2, false, 10, false, false));
            m.Add(new Menuchoice(70, Convert.ToString(wg.Antalsjöar), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(100, "Number of Rivers", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(100, Convert.ToString(wg.Antalfloder), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(130, "Number of Forests", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(130, Convert.ToString(wg.Antalskogar), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(160, "Number of Arctics", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(160, Convert.ToString(wg.Antalsnöar), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(190, "Size of The Ocean", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(190, Convert.ToString(wg.Havsstorlek), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(220, "Lake Size", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(220, Convert.ToString(wg.Sjöstorlek), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(250, "River Width", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(250, Convert.ToString(wg.Flodbredd), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(280, "Forest Size", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(280, Convert.ToString(wg.Skogsstorlek), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(310, "Arctic Size", sf2, f / 2, false, 10, false, false));
            m.Add(new Menuchoice(310, Convert.ToString(wg.Snöstorlek), sf2, f, false, 20, true, true));
            u.Add(new Menuchoice(70, "Example World", sf2, 3 * f / 2, false, 10, false, false));
            c.Add(new Menuchoice(310, "Regenerate", sf2, 3 * f / 2, false, 20, true, false));
            c.Add(new Menuchoice(400, "Generate World", sf2, 3 * f / 2, false, 20, true, false));
            c.Add(new Menuchoice(400, "Back", sf2, f / 2, false, 20, true, false));
        }
    }
}
