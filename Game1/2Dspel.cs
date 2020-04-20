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
        List<Texture2D> blocktextures = new List<Texture2D>();
        List<Menuchoice> huvudmeny = new List<Menuchoice>();
        List<Menuchoice> worldmeny = new List<Menuchoice>();
        List<Menuchoice> unclickablew = new List<Menuchoice>();
        List<Menuchoice> clickablew = new List<Menuchoice>();
        List<Texture2D> addons = new List<Texture2D>();
        List<Texture2D[]> addonextensions = new List<Texture2D[]>();
        Menuchoice hmenytext;
        Menuchoice wmenytext;
        Texture2D player;
        Texture2D mustex;
        Texture2D pixel;
        Texture2D onoff;
        Texture2D heart;
        SpriteFont text;
        SpriteFont menytext;
        SpriteFont stortext;
        SpriteFont mellantext;
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
        Bool we = new Bool(false);
        Bool inv = new Bool(false);
        Bool first = new Bool(true);
        Bool meny = new Bool(true);
        Bool hmeny = new Bool(true);
        Bool normal = new Bool(false);
        Bool wmeny = new Bool(false);
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
            addonextensions.Add(new Texture2D[4]);
            addonextensions.Add(new Texture2D[4]);
            addonextensions.Add(new Texture2D[4]);
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
            blocktextures.Add(Content.Load<Texture2D>("Grass"));
            blocktextures.Add(Content.Load<Texture2D>("Stone"));
            addons.Add(Content.Load<Texture2D>("nothing"));
            player = Content.Load<Texture2D>("Player");
            blocktextures.Add(Content.Load<Texture2D>("Sand"));
            
            blocktextures.Add(Content.Load<Texture2D>("Sky"));
            blocktextures.Add(Content.Load<Texture2D>("Water"));
            blocktextures.Add(Content.Load<Texture2D>("Deepf-ingwater"));
            blocktextures.Add(Content.Load<Texture2D>("Snow"));
            blocktextures.Add(Content.Load<Texture2D>("Ice"));
            blocktextures.Add(Content.Load<Texture2D>("Snowstone"));
            blocktextures.Add(Content.Load<Texture2D>("Icestone"));
            blocktextures.Add(Content.Load<Texture2D>("Forest"));
            blocktextures.Add(Content.Load<Texture2D>("Dirt"));
            mustex = Content.Load<Texture2D>("Mus");
            blocktextures.Add(Content.Load<Texture2D>("Foreststone"));
            blocktextures.Add(Content.Load<Texture2D>("Forestwater"));
            pixel = Content.Load<Texture2D>("Pixel");
            onoff = Content.Load<Texture2D>("OnOff");
            heart = Content.Load<Texture2D>("Hjärta");
            addons.Add(Content.Load<Texture2D>("tree"));
            addons.Add(Content.Load<Texture2D>("sten"));
            for (int i = 0; i < 4; i++)
            {
                addonextensions[0][i] = Content.Load<Texture2D>("nothing");
                addonextensions[2][i] = Content.Load<Texture2D>("nothing");
            }
            addonextensions[1][0] = Content.Load<Texture2D>("Tree1");
            addonextensions[1][1] = Content.Load<Texture2D>("Tree2");
            addonextensions[1][2] = Content.Load<Texture2D>("Tree3");
            addonextensions[1][3] = Content.Load<Texture2D>("Tree4");
            itemlist.Add(new Item(0, Content.Load<Texture2D>("Log"), 16));
            text = Content.Load<SpriteFont>("Text");
            menytext = Content.Load<SpriteFont>("Menytext");
            stortext = Content.Load<SpriteFont>("Stortext");
            mellantext = Content.Load<SpriteFont>("Mellanstor");
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
            if (first.Boll)
            {
                first.Boll = false;
                for (int i = 0; i < 14; i++)
                {
                    worldedit.Add(new Worldedit(i, f.Bredd - 21, 121 + i * 21));
                }
                weh = new Rectangle(f.Bredd - 21, 121, 21, worldedit.Count * 21);
                wetoggle = new Rectangle(f.Bredd - 21, 100, 21, 21);
                wef.Tal = 0;
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
                hmenytext = new Menuchoice(50, "Main Menu", stortext, f.Bredd / 2, false, 70, false, false);
                hmenytext.Mainmenucreate(huvudmeny, menytext, f.Bredd / 2);
                wmenytext = new Menuchoice(10, "Create custom world", menytext, f.Bredd / 2, false, 70, false, false);
                wmenytext.Worldmenucreate(worldmeny, unclickablew, clickablew, text, mellantext, f.Bredd / 2, wg);
            }
            mus.Musposchange(mstate.X, mstate.Y);
            if (meny.Boll)
            {
                if (hmeny.Boll)
                {
                    foreach(Menuchoice m in huvudmeny)
                    {
                        m.Active = false;
                        if (mus.Hitb.Intersects(m.Hitb))
                        {
                            m.Active = true;
                        }
                    }
                    if (mstate.LeftButton == ButtonState.Pressed)
                    {
                        mus.Huvudmenyklick(huvudmeny, meny, hmeny, normal, ref l, wg, rand, f, wmeny);
                    }
                }
                if (wmeny.Boll)
                {
                    foreach(Menuchoice m in worldmeny)
                    {
                        m.Active = false;
                        if (mus.Hitb.Intersects(m.Hitb))
                        {
                            m.Active = true;
                        }
                    }
                    foreach(Menuchoice m in clickablew)
                    {
                        m.Active = false;
                        if (mus.Hitb.Intersects(m.Hitb))
                        {
                            m.Active = true;
                        }
                    }
                    if (mstate.LeftButton == ButtonState.Pressed && oldmus.LeftButton == ButtonState.Released)
                    {
                        mus.Worldmenyklick(worldmeny, unclickablew, clickablew , ref l, wg, rand, mus, mellantext, f, meny, wmeny, normal, hmeny);
                    }
                }
            }
            if(normal.Boll)
            {
               
                if (inv.Boll)
                {
                    inventoryhitb.Height = 105;
                }
                else
                {
                    inventoryhitb.Height = 50;
                }
                activeslot = misc.Inventoryselect(activeslot, kstate, oldstate);

                mus.Update(l, worldedit, kstate, mstate, oldmus, inventory, wetoggle, we, weh, wef, inventoryhitb, f, wg, itemlist);
                play.Update(ref l, kstate, mstate, xauto, yauto, xautoscd, yautoscd, xautohcd, yautoncd, xautovcd, yautoucd, ghosts);
                if (kstate.IsKeyDown(Keys.Back) && oldstate.IsKeyDown(Keys.Back) == false)
                {
                    l = wg.Generate(f.Höjd, f.Bredd, rand);
                }
                if (kstate.IsKeyDown(Keys.OemPlus) && oldstate.IsKeyUp(Keys.OemPlus))
                {
                    foreach (Block b in l)
                    {
                        b.Id = lorg[b.Plats].Id;
                    }
                }
                if (kstate.IsKeyDown(Keys.Tab) && oldstate.IsKeyUp(Keys.Tab))
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
                if (kstate.IsKeyDown(Keys.L))
                {
                    ghosts.Add(new Ghost(rand, l));
                }
                for (int i = 0; i < ghosts.Count; i++)
                {
                    bool bo = ghosts[i].Update(play);
                    if (bo)
                    {
                        ghosts.Remove(ghosts[i]);
                        health.Tal -= 5;
                    }
                }
                hpbar.Width = health.Tal * 2;
            }
            
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
            if (meny.Boll)
            {
                if (hmeny.Boll)
                {
                    spriteBatch.DrawString(stortext, hmenytext.Text, hmenytext.Textlocation, Color.White);
                    foreach(Menuchoice m in huvudmeny)
                    {
                        spriteBatch.DrawString(menytext, m.Text, m.Textlocation, Color.White);
                        if (m.Active)
                        {
                            spriteBatch.DrawString(menytext, ">", m.Leftchoice, Color.White);
                            spriteBatch.DrawString(menytext, "<", m.Rightchoice, Color.White);
                        }
                    }
                }
                if (wmeny.Boll)
                {
                    spriteBatch.DrawString(menytext, wmenytext.Text, wmenytext.Textlocation, Color.White);
                    foreach(Menuchoice m in unclickablew)
                    {
                        spriteBatch.DrawString(mellantext, m.Text, m.Textlocation, Color.White);
                    }
                    foreach(Menuchoice m in worldmeny)
                    {
                        spriteBatch.DrawString(mellantext, m.Text, m.Textlocation, Color.White);
                        if (m.Active)
                        {
                            spriteBatch.DrawString(mellantext, ">", m.Rightchoice, Color.White);
                            spriteBatch.DrawString(mellantext, "<", m.Leftchoice, Color.White);
                        }
                    }
                    foreach(Menuchoice m in clickablew)
                    {
                        spriteBatch.DrawString(mellantext, m.Text, m.Textlocation, Color.White);
                    }
                    for(int i = 0; i < 3; i++)
                    {
                        if (clickablew[i].Active)
                        {
                            if (i == 0)
                            {
                                spriteBatch.DrawString(mellantext, "<", clickablew[i].Rightchoice, Color.White);
                                spriteBatch.DrawString(mellantext, ">", clickablew[i].Leftchoice, Color.White);
                            }
                            else if (i == 1)
                            {
                                spriteBatch.DrawString(mellantext, "-->", clickablew[i].Rightchoice, Color.White);
                            }
                            else if (i == 2)
                            {
                                spriteBatch.DrawString(mellantext, "<--", new Vector2(clickablew[i].Leftchoice.X - 2 * mellantext.LineSpacing, clickablew[i].Leftchoice.Y), Color.White);
                            }
                        }

                    }

                    foreach (Block b in l)
                    {
                        spriteBatch.Draw(blocktextures[b.Id], b.Map, Color.White);
                    }
                }
                spriteBatch.Draw(mustex, mus.Pos, Color.White);
            }
            else
            {
                foreach (Block b in l)
                {
                    spriteBatch.Draw(blocktextures[b.Id], b.Rek, Color.White);

                }
                spriteBatch.Draw(player, play.Pos, Color.White);
                foreach (Block b in l)
                {
                    if (b.Addontype != 0)
                    {
                        spriteBatch.Draw(addons[b.Addontype], b.Rek, Color.White);
                        for (int i = 0; i < 4; i++)
                        {
                            if (b.Addontrue[i])
                            {
                                spriteBatch.Draw(addonextensions[b.Addontype][i], b.Rek, Color.White);
                            }
                        }
                    }
                }
                foreach (Block b in l)
                {
                    spriteBatch.Draw(blocktextures[b.Id], b.Map, Color.White);
                }
                foreach (Ghost g in ghosts)
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
                        spriteBatch.Draw(blocktextures[w.Id], w.Förg, Color.White);
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
                for (int i = 0; i < 10; i++)
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
                    for (int i = 10; i < 20; i++)
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
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
