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
        List<Block> lorg = new List<Block>();
        
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
        Texture2D[] treeparts = new Texture2D[4];
        Texture2D fstone;
        Texture2D fwater;
        Texture2D mustex;
        Texture2D pixel;
        Texture2D onoff;
        Texture2D heart;
        Texture2D tree;
        SpriteFont text;
        List<Item> itemlist = new List<Item>();
        List<Texture2D> itemtextures = new List<Texture2D>();
        List<Worldedit> worldedit = new List<Worldedit>();
        List<Ghost> ghosts = new List<Ghost>();
        Mus mus;
        Siffra activeslot = new Siffra(0);
        Misc misc = new Misc();
        Rectangle hpbar;
        Rectangle hpbarbak;
        Rectangle hpbarbor;
        Rectangle healthheart;
        Siffra health;
        KeyboardState oldstate;
        MouseState oldmus;
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
        Slot[] inventory = new Slot[20];
        Rectangle inventoryhitb;
        Rectangle wetoggle;
        Player play;
        Rectangle weh;
        Siffra wef = new Siffra(0);
        List<Texture2D> allatex;
        Fonster f;
        WorldGen wg = new WorldGen();
        Bool b = new Bool(true);
        Bool we = new Bool(false);
        Bool inv = new Bool(false);
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
            onoff = Content.Load<Texture2D>("OnOff");
            heart = Content.Load<Texture2D>("Hjärta");
            tree = Content.Load<Texture2D>("Tree");
            treeparts[0] = Content.Load<Texture2D>("Tree1");
            treeparts[1] = Content.Load<Texture2D>("Tree2");
            treeparts[2] = Content.Load<Texture2D>("Tree3");
            treeparts[3] = Content.Load<Texture2D>("Tree4");
            itemlist.Add(new Item(0, Content.Load<Texture2D>("Log"), 16));
            text = Content.Load<SpriteFont>("Text");
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


            play = new Player(f.Bredd, f.Höjd);
            if (b.Boll == true)
            {
                if (l.Count==0)
                {
                    l = wg.Generate(f.Höjd, f.Bredd, rand, treeparts);
                }
                else
                {
                    List<Block> tillf = new List<Block>();
                    tillf = wg.Generate(f.Höjd, f.Bredd, rand, treeparts);
                    foreach(Block b in l)
                    {

                        b.Id = tillf[b.Plats].Id;
                        b.Addontype = tillf[b.Plats].Addontype;
                        b.Addontex = tillf[b.Plats].Addontex;
                        b.Addontrue = tillf[b.Plats].Addontrue;
                        int x;
                        int y;
                        x = tillf[b.Plats].Rek.X - tillf[b.Plats].Addon.X;
                        y = tillf[b.Plats].Rek.Y - tillf[b.Plats].Addon.Y;
                        b.Addon = new Rectangle(b.Rek.X - x, b.Rek.Y - y, tillf[b.Plats].Addon.Width, tillf[b.Plats].Addon.Height);
                        if (b.Rek.Intersects(play.Pos))
                        {
                            if (b.Id == 1)
                            {
                                b.Id = 0;
                            }
                            else if (b.Id == 5)
                            {
                                b.Id = 2;
                            }
                            else if (b.Id == 12)
                            {
                                b.Id = 10;
                            }
                            else if (b.Id == 9 || b.Id == 8)
                            {
                                b.Id = 6;
                            }
                        }
                    }
                }
                b.Boll = false;
                for (int i = 0; i < 14; i++)
                {
                    worldedit.Add(new Worldedit(i, f.Bredd - 21, 121 + i * 21));
                }
                weh = new Rectangle(f.Bredd - 21, 121, 21, worldedit.Count * 21);
                wetoggle = new Rectangle(f.Bredd - 21, 100, 21, 21);
                wef.Tal = 0;
                we.Boll = false;
                foreach(Block b in l)
                {
                    lorg.Add(new Block(b));
                }
                health = new Siffra(100);
                hpbarbor = new Rectangle(f.Bredd - 320, 10, 210, 30);
                hpbarbak = new Rectangle(f.Bredd - 315, 15, 200, 20);
                hpbar = new Rectangle(f.Bredd - 315, 15, health.Tal * 2, 20);
                healthheart = new Rectangle(f.Bredd - 330, 7, 30, 30);
                ghosts.Clear();
                inventory[0] = new Slot();
                inventory[0].Inventory(inventory);
                mus = new Mus(mstate);
                inventoryhitb = new Rectangle(0, 0, 450, 50);
            }
            if (inv.Boll)
            {
                inventoryhitb.Height = 105;
            }
            else
            {
                inventoryhitb.Height = 50;
            }
            activeslot = misc.Inventoryselect(activeslot, kstate, oldstate);
            mus.Musposchange(mstate.X, mstate.Y);
            if (mstate.LeftButton == ButtonState.Pressed)
            {
                if (mus.Hitb.Intersects(wetoggle))
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        if (we.Boll == true)
                        {
                            we.Boll = false;
                        }
                        else if (we.Boll == false)
                        {
                            we.Boll = true;
                        }
                    }

                }
                else if (we.Boll && mus.Hitb.Intersects(weh))
                {
                    foreach (Worldedit w in worldedit)
                    {
                        w.Active = false;
                        if (w.Bak.Intersects(mus.Hitb))
                        {
                            w.Active = true;
                            wef.Tal = w.Id;
                        }
                    }
                }
                else if (mus.Hitb.Intersects(inventoryhitb))
                {
                    if (oldmus.LeftButton == ButtonState.Released)
                    {
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (mus.Hitb.Intersects(inventory[i].Hitb))
                            {
                                if (kstate.IsKeyDown(Keys.LeftShift) || kstate.IsKeyDown(Keys.RightShift))
                                {
                                    while (true)
                                    {
                                        int a = inventory[i].Inventoryslotfind(inventory, inventory[i].It, i);
                                        if (a == i)
                                        {
                                            break;
                                        }
                                        else if (inventory[a].It.Id == -1)
                                        {
                                            inventory[a].It = inventory[i].It;
                                            inventory[a].Numb = inventory[i].Numb;
                                            inventory[i].It = new Item();
                                            inventory[i].Numb = 0;
                                            break;
                                        }
                                        else if (inventory[a].Numb + inventory[i].Numb <= inventory[i].It.Max)
                                        {
                                            inventory[a].Numb = inventory[a].Numb + inventory[i].Numb;
                                            inventory[i].It = new Item();
                                            inventory[i].Numb = 0;
                                            break;
                                        }
                                        else
                                        {
                                            int b = inventory[a].It.Max - inventory[a].Numb;
                                            inventory[a].Numb = inventory[a].It.Max;
                                            inventory[i].Numb -= b;
                                        }
                                    }

                                }
                                else if (mus.Sloot.It.Id != inventory[i].It.Id || inventory[i].It.Max == inventory[i].Numb || mus.Sloot.It.Max == mus.Sloot.Numb)
                                {
                                    mus.Sloot = mus.Mousecontentexchange(ref inventory[i], mus.Sloot);
                                }
                                else if (mus.Sloot.Numb + inventory[i].Numb <= mus.Sloot.It.Max)
                                {
                                    inventory[i].Numb += mus.Sloot.Numb;
                                    mus.Sloot.It = new Item();
                                    mus.Sloot.Numb = 0;
                                }
                                else
                                {
                                    int a = inventory[i].It.Max - inventory[i].Numb;
                                    inventory[i].Numb = inventory[i].It.Max;
                                    mus.Sloot.Numb -= a;
                                }
                            }
                        }
                    }

                }
                else if (we.Boll == false)
                {
                    foreach(Block b in l)
                    {
                        if(mus.Hitb.Intersects(b.Rek) && b.Addontype == "Tree")
                        {
                            b.Addontype = "none";
                            wg.Addonextension(l, b.Plats);
                            if (b.Plats % 100 < 99)
                            {
                                wg.Addonextension(l, b.Plats + 1);
                            }
                            if (b.Plats / 100 < 99)
                            {
                                wg.Addonextension(l, b.Plats + 100);
                            }
                            inventory[0].Inventoryadd(inventory, itemlist[0]);
                        }
                    }
                }
                else if ((mus.Hitb.X < f.Bredd - 100 || mus.Hitb.Y > 100) && we.Boll)
                {
                    foreach (Block b in l)
                    {
                        if (b.Rek.Intersects(mus.Hitb))
                        {
                            b.Id = wef.Tal;
                        }
                    }
                }
                else if (we.Boll)
                {
                    foreach (Block b in l)
                    {
                        if (b.Map.Intersects(mus.Pos))
                        {
                            b.Id = wef.Tal;
                        }
                    }
                }
            }
            if(mstate.RightButton == ButtonState.Pressed && oldmus.RightButton == ButtonState.Released && mstate.LeftButton == ButtonState.Released)
            {
                if (mus.Hitb.Intersects(inventoryhitb))
                {
                    for(int i = 0; i < 20; i++)
                    {
                        if (mus.Hitb.Intersects(inventory[i].Hitb))
                        {
                            if (mus.Sloot.It.Id == -1 && inventory[i].It.Id != -1)
                            {
                                mus.Sloot.It = inventory[i].It;
                                mus.Sloot.Numb = inventory[i].Numb / 2;
                                inventory[i].Numb -= mus.Sloot.Numb;
                                if (mus.Sloot.Numb == 0)
                                {
                                    mus.Sloot.It = new Item();
                                }
                            }
                            else if (mus.Sloot.It.Id == inventory[i].It.Id && mus.Sloot.It.Id != -1 && inventory[i].Numb < inventory[i].It.Max)
                            {
                                mus.Sloot.Numb--;
                                inventory[i].Numb++;
                                if (mus.Sloot.Numb == 0)
                                {
                                    mus.Sloot.It = new Item();
                                }
                            }
                            else if (mus.Sloot.It.Id != -1 && inventory[i].It.Id == -1)
                            {
                                inventory[i].It = mus.Sloot.It;
                                mus.Sloot.Numb--;
                                inventory[i].Numb++;
                                if (mus.Sloot.Numb == 0)
                                {
                                    mus.Sloot.It = new Item();
                                }
                            }
                        }
                    }
                }
            }
            play.Update(ref l, kstate, mstate, xauto, yauto, xautoscd, yautoscd, xautohcd, yautoncd, xautovcd, yautoucd, ghosts);
            if (kstate.IsKeyDown(Keys.Back) && oldstate.IsKeyDown(Keys.Back) == false)
            {
                b.Boll = true;
            }
            if (kstate.IsKeyDown(Keys.OemPlus) && oldstate.IsKeyUp(Keys.OemPlus))
            {
                foreach(Block b in l)
                {
                    b.Id = lorg[b.Plats].Id;
                }
            }
            if(kstate.IsKeyDown(Keys.Tab) && oldstate.IsKeyUp(Keys.Tab))
            {
                if (inv.Boll)
                {
                    inv.Boll = false;
                }
                else
                {
                    inv.Boll = true;
                }
            }
            if (kstate.IsKeyDown(Keys.O) && health.Tal > 0)
            {
                health.Tal--;
            }
            if (kstate.IsKeyDown(Keys.P) && health.Tal < 100)
            {
                health.Tal++;
            }
            if(kstate.IsKeyDown(Keys.L))
            {
                ghosts.Add(new Ghost(rand, l));
            }
            List<Ghost> tilfghosts = new List<Ghost>();
            foreach(Ghost g in ghosts)
            {
                tilfghosts.Add(g);

            }
            ghosts = tilfghosts;
            for(int i = 0; i < ghosts.Count; i++)
            {
                bool bo = ghosts[i].Update(play);
                if (bo)
                {
                    ghosts.Remove(ghosts[i]);
                    health.Tal -= 5;
                }
            }
            hpbar.Width = health.Tal * 2;
            oldstate = kstate;
            oldmus = mstate;
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
            foreach (Block b in l)
            {
                if (b.Rek.X > -100 && b.Rek.X < f.Bredd + 10 && b.Rek.Y > -100 && b.Rek.Y < f.Höjd + 10)
                {
                    if (b.Id == 0)
                    {
                        spriteBatch.Draw(grass, b.Rek, Color.White);
                    }
                    else if (b.Id == 1)
                    {
                        spriteBatch.Draw(stone, b.Rek, Color.White);
                    }
                    else if (b.Id == 3)
                    {
                        spriteBatch.Draw(water, b.Rek, Color.White);
                    }
                    else if (b.Id == 2)
                    {
                        spriteBatch.Draw(sand, b.Rek, Color.White);
                    }
                    else if (b.Id == 4)
                    {
                        spriteBatch.Draw(deepwater, b.Rek, Color.White);
                    }
                    else if (b.Id == 5)
                    {
                        spriteBatch.Draw(deepdeepwater, b.Rek, Color.White);
                    }
                    else if (b.Id == 6)
                    {
                        spriteBatch.Draw(snow, b.Rek, Color.White);
                    }
                    else if (b.Id == 7)
                    {
                        spriteBatch.Draw(ice, b.Rek, Color.White);
                    }
                    else if (b.Id == 8)
                    {
                        spriteBatch.Draw(snowstone, b.Rek, Color.White);
                    }
                    else if (b.Id == 9)
                    {
                        spriteBatch.Draw(icestone, b.Rek, Color.White);
                    }
                    else if (b.Id == 10)
                    {
                        spriteBatch.Draw(forestgrass, b.Rek, Color.White);
                    }
                    else if (b.Id == 11)
                    {
                        spriteBatch.Draw(dirt, b.Rek, Color.White);
                    }
                    else if (b.Id == 12)
                    {
                        spriteBatch.Draw(fstone, b.Rek, Color.White);
                    }
                    else if (b.Id == 13)
                    {
                        spriteBatch.Draw(fwater, b.Rek, Color.White);
                    }
                }

            }
            spriteBatch.Draw(player, play.Pos, Color.White);
            foreach (Block b in l)
            {
                if (b.Addontype != "none")
                {
                    if (b.Addontype == "Tree")
                    {
                        spriteBatch.Draw(tree, b.Rek, Color.White);
                    }
                    for(int i = 0; i < 4; i++)
                    {
                        if (b.Addontrue[i])
                        {
                            spriteBatch.Draw(b.Addontex[i], b.Rek, Color.White);
                        }
                    }
                }
            }
            foreach(Block b in l)
            {
                if (b.Id == 0)
                {
                    spriteBatch.Draw(mgrass, b.Map, Color.White);
                }
                else if (b.Id == 1)
                {
                    spriteBatch.Draw(mstone, b.Map, Color.White);
                }
                else if (b.Id == 3)
                {
                    spriteBatch.Draw(mwater, b.Map, Color.White);
                }
                else if (b.Id == 2)
                {
                    spriteBatch.Draw(msand, b.Map, Color.White);
                }
                else if (b.Id == 4)
                {
                    spriteBatch.Draw(mdeepwater, b.Map, Color.White);
                }
                else if (b.Id == 5)
                {
                    spriteBatch.Draw(mdeepdeepwater, b.Map, Color.White);
                }
                else if (b.Id == 6)
                {
                    spriteBatch.Draw(snow, b.Map, Color.White);
                }
                else if (b.Id == 7)
                {
                    spriteBatch.Draw(ice, b.Map, Color.White);
                }
                else if (b.Id == 8)
                {
                    spriteBatch.Draw(snowstone, b.Map, Color.White);
                }
                else if (b.Id == 9)
                {
                    spriteBatch.Draw(icestone, b.Map, Color.White);
                }
                else if (b.Id == 10)
                {
                    spriteBatch.Draw(forestgrass, b.Map, Color.White);
                }
                else if (b.Id == 11)
                {
                    spriteBatch.Draw(dirt, b.Map, Color.White);
                }
                else if (b.Id == 12)
                {
                    spriteBatch.Draw(fstone, b.Map, Color.White);
                }
                else if (b.Id == 13)
                {
                    spriteBatch.Draw(fwater, b.Map, Color.White);
                }
            }
            foreach(Ghost g in ghosts)
            {
                spriteBatch.Draw(pixel, g.Pos, Color.Red);
            }
            if (we.Boll == false)
            {
                spriteBatch.Draw(pixel, wetoggle, Color.Red);
            }
            else if (we.Boll)
            {
                spriteBatch.Draw(pixel, wetoggle, Color.Green);
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
                    if (w.Id == 0)
                    {
                        spriteBatch.Draw(mgrass, w.Förg, Color.White);
                    }
                    else if (w.Id == 1)
                    {
                        spriteBatch.Draw(mstone, w.Förg, Color.White);
                    }
                    else if (w.Id == 3)
                    {
                        spriteBatch.Draw(mwater, w.Förg, Color.White);
                    }
                    else if (w.Id == 2)
                    {
                        spriteBatch.Draw(msand, w.Förg, Color.White);
                    }
                    else if (w.Id == 4)
                    {
                        spriteBatch.Draw(mdeepwater, w.Förg, Color.White);
                    }
                    else if (w.Id == 5)
                    {
                        spriteBatch.Draw(mdeepdeepwater, w.Förg, Color.White);
                    }
                    else if (w.Id == 6)
                    {
                        spriteBatch.Draw(snow, w.Förg, Color.White);
                    }
                    else if (w.Id == 7)
                    {
                        spriteBatch.Draw(ice, w.Förg, Color.White);
                    }
                    else if (w.Id == 8)
                    {
                        spriteBatch.Draw(snowstone, w.Förg, Color.White);
                    }
                    else if (w.Id == 9)
                    {
                        spriteBatch.Draw(icestone, w.Förg, Color.White);
                    }
                    else if (w.Id == 10)
                    {
                        spriteBatch.Draw(forestgrass, w.Förg, Color.White);
                    }
                    else if (w.Id == 11)
                    {
                        spriteBatch.Draw(dirt, w.Förg, Color.White);
                    }
                    else if (w.Id == 12)
                    {
                        spriteBatch.Draw(fstone, w.Förg, Color.White);
                    }
                    else if (w.Id == 13)
                    {
                        spriteBatch.Draw(fwater, w.Förg, Color.White);
                    }

                }
            }
            Rectangle tillf = new Rectangle(f.Bredd - 18, 103, 15, 15);
            spriteBatch.Draw(pixel, tillf, Color.White);
            tillf = new Rectangle(tillf.X + 1, tillf.Y + 1, 13, 13);
            if (we.Boll)
            {
                spriteBatch.Draw(onoff, tillf, Color.Green);
            }
            else
            {
                spriteBatch.Draw(onoff, tillf, Color.Red);
            }
            for(int i = 0; i < 10; i++)
            {
                if (i == activeslot.Tal)
                {
                    spriteBatch.Draw(pixel, inventory[i].Hitb, Color.Yellow);
                }
                else
                {
                    spriteBatch.Draw(pixel, inventory[i].Hitb, Color.Blue);
                }
                spriteBatch.Draw(pixel, inventory[i].Förg, Color.DarkBlue);
                if (inventory[i].It.Id != -1)
                {
                    spriteBatch.Draw(inventory[i].It.Tex, inventory[i].Hitb, Color.White);
                    if (inventory[i].Numb < 10)
                    {
                        spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - 2 * text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                    }
                }
                if (i != 9)
                {
                    spriteBatch.DrawString(text, Convert.ToString(i + 1), new Vector2(inventory[i].Förg.X, inventory[i].Förg.Y), Color.White);
                }
            }
            if (inv.Boll)
            {
                for(int i = 10; i < 20; i++)
                {
                    spriteBatch.Draw(pixel, inventory[i].Hitb, Color.Blue);
                    spriteBatch.Draw(pixel, inventory[i].Förg, Color.DarkBlue);
                    if (inventory[i].It.Id != -1)
                    {
                        spriteBatch.Draw(inventory[i].It.Tex, inventory[i].Hitb, Color.White);
                        if (inventory[i].Numb < 10)
                        {
                            spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - 2 * text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                        }
                    }
                }
            }
            spriteBatch.Draw(pixel, hpbarbor, Color.White);
            spriteBatch.Draw(pixel, hpbarbak, Color.Black);
            spriteBatch.Draw(pixel, hpbar, Color.Red);
            spriteBatch.Draw(heart, healthheart, Color.White);

            if (mus.Sloot.It.Id == -1)
            {
                spriteBatch.Draw(mustex, mus.Pos, Color.White);
            }
            else
            {
                spriteBatch.Draw(mus.Sloot.It.Tex, mus.Sloot.Hitb, Color.White);
                if (mus.Sloot.Numb < 10)
                {
                    spriteBatch.DrawString(text, Convert.ToString(mus.Sloot.Numb), new Vector2(mus.Sloot.Förg.X + 34 - text.LineSpacing, mus.Sloot.Förg.Y + 24), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(text, Convert.ToString(mus.Sloot.Numb), new Vector2(mus.Sloot.Förg.X + 34 - 2 * text.LineSpacing, mus.Sloot.Förg.Y + 24), Color.White);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
