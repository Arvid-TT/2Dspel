using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Block> l = new List<Block>();
        Texture2D grass;
        Texture2D stone;
        Texture2D deepwater;
        Texture2D water;
        Texture2D player;
        Texture2D sand;
        Texture2D deepdeepwater;
        Texture2D mgrass;
        Texture2D mstone;
        Texture2D mdeepwater;
        Texture2D mwater;
        Texture2D msand;
        Texture2D mdeepdeepwater;
        Texture2D snow;
        Texture2D ice;
        Texture2D snowstone;
        Texture2D icestone;
        Texture2D forestgrass;
        Texture2D dirt;
        Texture2D msnow;
        Texture2D mice;
        Texture2D fstone;
        Texture2D fwater;
        Texture2D mustex;
        Texture2D pixel;
        List<Worldedit> worldedit = new List<Worldedit>();
        Mus mus;
        KeyboardState oldstate;
        Siffra xauto = new Siffra(0);
        Siffra yauto = new Siffra(0);
        Siffra xautovcd = new Siffra(0);
        Siffra yautoucd = new Siffra(0);
        Siffra xautohcd = new Siffra(0);
        Siffra yautoncd = new Siffra(0);
        Siffra yautoscd = new Siffra(0);
        Siffra xautoscd = new Siffra(0);
        Siffra xautocd = new Siffra(0);
        Siffra yautocd = new Siffra(0);
        Player play;
        Rectangle weh;
        Text wef = new Text("Green");
        List<Texture2D> allatex;
        Fonster f;
        WorldGen wg = new WorldGen();
        Bool b = new Bool(true);
        Bool we = new Bool(false);
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            f = new Fonster(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            grass = Content.Load<Texture2D>("Grass");
            stone = Content.Load<Texture2D>("Stone");
            deepwater = Content.Load<Texture2D>("Water");
            player = Content.Load<Texture2D>("Player");
            sand = Content.Load<Texture2D>("Sand");
            water = Content.Load<Texture2D>("Sky");
            deepdeepwater = Content.Load<Texture2D>("Deepf-ingwater");
            snow = Content.Load<Texture2D>("Snow");
            ice = Content.Load<Texture2D>("Ice");
            snowstone = Content.Load<Texture2D>("Snowstone");
            icestone = Content.Load<Texture2D>("Icestone");
            forestgrass = Content.Load<Texture2D>("Forest");
            dirt = Content.Load<Texture2D>("Dirt");
            mustex = Content.Load<Texture2D>("Mus");
            fstone = Content.Load<Texture2D>("Foreststone");
            fwater = Content.Load<Texture2D>("Forestwater");
            mgrass = Content.Load<Texture2D>("mGrass");
            mstone = Content.Load<Texture2D>("mStone");
            mdeepwater = Content.Load<Texture2D>("mWater");
            pixel = Content.Load<Texture2D>("Pixel");
            msand = Content.Load<Texture2D>("mSand");
            mwater = Content.Load<Texture2D>("mSky");
            mdeepdeepwater = Content.Load<Texture2D>("mDeepf-ingwater");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kstate = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();
            Rectangle p = new Rectangle(mstate.X, mstate.Y, 21, 21);
            Rectangle h = new Rectangle(mstate.X +10, mstate.Y +10, 1, 1);
            mus = new Mus(p, h);

            foreach(Block b in l)
            {
                if(mus.Hitb.Intersects(b.Rek) && mstate.LeftButton == ButtonState.Pressed)
                {
                    b.Färg = "Green";
                }
            }

            play = new Player(f.Bredd, f.Höjd);
            if (b.Boll == true)
            {
                l = wg.Generate(f.Höjd, f.Bredd, rand);
                b.Boll = false;
                int i = 0;
                for (i = 0; i < 12; i++)
                {
                    worldedit.Add(new Worldedit(i, f.Bredd - 21, 100 + i * 21));
                }
                weh = new Rectangle(100, f.Bredd - 21, 21, 100 + i * 21);
            }
            if (mstate.LeftButton == ButtonState.Pressed)
            {
                if (we.Boll && mus.Hitb.Intersects(weh))
                {
                    foreach(Worldedit w in worldedit)
                    {
                        w.Active = false;
                        if (w.Bak.Intersects(mus.Hitb))
                        {
                            w.Active = true;
                            wef.Txt = w.Färg;
                        }
                    }
                }
                else if (mus.Hitb.X < f.Bredd - 100 && mus.Hitb.Y > 100)
                {
                    foreach(Block b in l)
                    {
                        if (b.Rek.Intersects(mus.Hitb))
                        {
                            b.Färg = wef.Txt;
                        }
                    }
                }
            }
            play.Update(ref l, kstate, mstate, xauto, yauto, xautoscd, yautoscd, xautohcd, yautoncd, xautovcd, yautoucd);
            if (kstate.IsKeyDown(Keys.Back) && oldstate.IsKeyDown(Keys.Back) == false)
            {
                b.Boll = true;
            }
            we.Boll = true;
            oldstate = kstate;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (Block gras in l)
            {
                if (gras.Rek.X > -100 && gras.Rek.X < f.Bredd + 10 && gras.Rek.Y > -100 && gras.Rek.Y < f.Höjd + 10)
                {
                    if (gras.Färg == "Green")
                    {
                        spriteBatch.Draw(grass, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Gray")
                    {
                        spriteBatch.Draw(stone, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Blue")
                    {
                        spriteBatch.Draw(water, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Yellow")
                    {
                        spriteBatch.Draw(sand, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Deepblue")
                    {
                        spriteBatch.Draw(deepwater, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Deepdeepblue")
                    {
                        spriteBatch.Draw(deepdeepwater, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "White")
                    {
                        spriteBatch.Draw(snow, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Lightblue")
                    {
                        spriteBatch.Draw(ice, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Lightgray")
                    {
                        spriteBatch.Draw(snowstone, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Lightcyan")
                    {
                        spriteBatch.Draw(icestone, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Darkgreen")
                    {
                        spriteBatch.Draw(forestgrass, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Brown")
                    {
                        spriteBatch.Draw(dirt, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Darkcyan")
                    {
                        spriteBatch.Draw(fstone, gras.Rek, Color.White);
                    }
                    else if (gras.Färg == "Cyan")
                    {
                        spriteBatch.Draw(fwater, gras.Rek, Color.White);
                    }
                }
                
            }
            foreach(Block gras in l)
            {
                if (gras.Färg == "Green")
                {
                    spriteBatch.Draw(mgrass, gras.Map, Color.White);
                }
                else if (gras.Färg == "Gray")
                {
                    spriteBatch.Draw(mstone, gras.Map, Color.White);
                }
                else if (gras.Färg == "Blue")
                {
                    spriteBatch.Draw(mwater, gras.Map, Color.White);
                }
                else if (gras.Färg == "Yellow")
                {
                    spriteBatch.Draw(msand, gras.Map, Color.White);
                }
                else if (gras.Färg == "Deepblue")
                {
                    spriteBatch.Draw(mdeepwater, gras.Map, Color.White);
                }
                else if (gras.Färg == "Deepdeepblue")
                {
                    spriteBatch.Draw(mdeepdeepwater, gras.Map, Color.White);
                }
                else if (gras.Färg == "White")
                {
                    spriteBatch.Draw(snow, gras.Map, Color.White);
                }
                else if (gras.Färg == "Lightblue")
                {
                    spriteBatch.Draw(ice, gras.Map, Color.White);
                }
                else if (gras.Färg == "Lightgray")
                {
                    spriteBatch.Draw(snowstone, gras.Map, Color.White);
                }
                else if (gras.Färg == "Lightcyan")
                {
                    spriteBatch.Draw(icestone, gras.Map, Color.White);
                }
                else if (gras.Färg == "Darkgreen")
                {
                    spriteBatch.Draw(forestgrass, gras.Map, Color.White);
                }
                else if (gras.Färg == "Brown")
                {
                    spriteBatch.Draw(dirt, gras.Map, Color.White);
                }
                else if (gras.Färg == "Darkcyan")
                {
                    spriteBatch.Draw(fstone, gras.Map, Color.White);
                }
                else if (gras.Färg == "Cyan")
                {
                    spriteBatch.Draw(fwater, gras.Map, Color.White);
                }
            }
            if (we.Boll)
            {
                foreach (Worldedit w in worldedit)
                {
                    if (w.Active)
                    {
                        spriteBatch.Draw(pixel, w.Bak, Color.Yellow);
                    }
                    else
                    {
                        spriteBatch.Draw(pixel, w.Bak, Color.White);
                    }
                    if (w.Färg == "Green")
                    {
                        spriteBatch.Draw(mgrass, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Gray")
                    {
                        spriteBatch.Draw(mstone, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Blue")
                    {
                        spriteBatch.Draw(mwater, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Yellow")
                    {
                        spriteBatch.Draw(msand, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Deepblue")
                    {
                        spriteBatch.Draw(mdeepwater, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Deepdeepblue")
                    {
                        spriteBatch.Draw(mdeepdeepwater, w.Förg, Color.White);
                    }
                    else if (w.Färg == "White")
                    {
                        spriteBatch.Draw(snow, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Lightblue")
                    {
                        spriteBatch.Draw(ice, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Lightgray")
                    {
                        spriteBatch.Draw(snowstone, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Lightcyan")
                    {
                        spriteBatch.Draw(icestone, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Darkgreen")
                    {
                        spriteBatch.Draw(forestgrass, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Brown")
                    {
                        spriteBatch.Draw(dirt, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Darkcyan")
                    {
                        spriteBatch.Draw(fstone, w.Förg, Color.White);
                    }
                    else if (w.Färg == "Cyan")
                    {
                        spriteBatch.Draw(fwater, w.Förg, Color.White);
                    }

                }
            }


            spriteBatch.Draw(player, play.Pos, Color.White);
            spriteBatch.Draw(mustex, mus.Pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
