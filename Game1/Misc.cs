using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Misc
    {
        public Siffra Inventoryselect(Siffra s, KeyboardState k, KeyboardState o)
        {
            if (k.IsKeyDown(Keys.D1) && o.IsKeyUp(Keys.D1))
            {
                s.Tal = 0;
            }
            if (k.IsKeyDown(Keys.D2) && o.IsKeyUp(Keys.D2))
            {
                s.Tal = 1;
            }
            if (k.IsKeyDown(Keys.D3) && o.IsKeyUp(Keys.D3))
            {
                s.Tal = 2;
            }
            if (k.IsKeyDown(Keys.D4) && o.IsKeyUp(Keys.D4))
            {
                s.Tal = 3;
            }
            if (k.IsKeyDown(Keys.D5) && o.IsKeyUp(Keys.D5))
            {
                s.Tal = 4;
            }
            if (k.IsKeyDown(Keys.D6) && o.IsKeyUp(Keys.D6))
            {
                s.Tal = 5;
            }
            if (k.IsKeyDown(Keys.D7) && o.IsKeyUp(Keys.D7))
            {
                s.Tal = 6;
            }
            if (k.IsKeyDown(Keys.D8) && o.IsKeyUp(Keys.D8))
            {
                s.Tal = 7;
            }
            if (k.IsKeyDown(Keys.D9) && o.IsKeyUp(Keys.D9))
            {
                s.Tal = 8;
            }
            if (k.IsKeyDown(Keys.D0) && o.IsKeyUp(Keys.D0))
            {
                s.Tal = 9;
            }
            return s;
        }
    }
}
