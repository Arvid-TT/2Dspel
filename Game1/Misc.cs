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
        /// <summary>
        /// Bestämmer vilken ruta i hotbaren som ska vara aktiv,
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public int Inventoryselect(int s, KeyboardState k, KeyboardState o)
        {
            if (k.IsKeyDown(Keys.D1) && o.IsKeyUp(Keys.D1))
            {
                s  = 0;
            }
            if (k.IsKeyDown(Keys.D2) && o.IsKeyUp(Keys.D2))
            {
                s  = 1;
            }
            if (k.IsKeyDown(Keys.D3) && o.IsKeyUp(Keys.D3))
            {
                s  = 2;
            }
            if (k.IsKeyDown(Keys.D4) && o.IsKeyUp(Keys.D4))
            {
                s  = 3;
            }
            if (k.IsKeyDown(Keys.D5) && o.IsKeyUp(Keys.D5))
            {
                s  = 4;
            }
            if (k.IsKeyDown(Keys.D6) && o.IsKeyUp(Keys.D6))
            {
                s  = 5;
            }
            if (k.IsKeyDown(Keys.D7) && o.IsKeyUp(Keys.D7))
            {
                s  = 6;
            }
            if (k.IsKeyDown(Keys.D8) && o.IsKeyUp(Keys.D8))
            {
                s  = 7;
            }
            if (k.IsKeyDown(Keys.D9) && o.IsKeyUp(Keys.D9))
            {
                s  = 8;
            }
            if (k.IsKeyDown(Keys.D0) && o.IsKeyUp(Keys.D0))
            {
                s  = 9;
            }
            return s;
        }
    }
}
