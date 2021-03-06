﻿using Microsoft.Xna.Framework;
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
        List<Menuchoice> gamemenu = new List<Menuchoice>();
        Menuchoice ingamemeny;
        List<Texture2D> addons = new List<Texture2D>();
        List<Texture2D[]> addonextensions = new List<Texture2D[]>();
        List<Craftcheck> total = new List<Craftcheck>();
        List<Crafting> allcrafts = new List<Crafting>();
        List<Crafting> craftable = new List<Crafting>();
        Menuchoice hmenytext;
        Menuchoice wmenytext;
        Texture2D player;
        Texture2D mustex;
        Texture2D pixel;
        Texture2D onoff;
        Texture2D heart;
        Texture2D pil;
        SpriteFont text;
        SpriteFont menytext;
        SpriteFont stortext;
        SpriteFont mellantext;
        SpriteFont smalltext;
        List<Item> itemlist = new List<Item>();
        List<Texture2D> itemtextures = new List<Texture2D>();
        List<Worldedit> worldedit = new List<Worldedit>();
        List<Ghost> ghosts = new List<Ghost>();
        Mus mus;
        Rectangle trash;
        int activeslot = 0;
        Misc misc = new Misc();
        Rectangle hpbar;
        Rectangle hpbarbak;
        Rectangle hpbarbor;
        Rectangle healthheart;
        Rectangle craftingoutline = new Rectangle(5, 115, 0, 40);
        Rectangle craftinginside = new Rectangle(8, 118, 0, 34);
        Rectangle craftshow;
        Rectangle craftarrow;
        Rectangle gamemenuin;
        Rectangle gamemenuout;
        int health;
        KeyboardState oldstate;
        MouseState oldmus;
        int xauto = 0;
        int yauto = 0;
        int xautovcd = 0;
        int yautoucd = 0;
        int xautohcd = 0;
        int yautoncd = 0;
        int yautoscd = 0;
        int xautoscd = 0;
        int xautocd = 0;
        int yautocd = 0;
        Slot[] inventory = new Slot[20];
        Rectangle inventoryhitb;
        Rectangle wetoggle;
        Player play;
        Rectangle weh;
        int wef = 0;
        List<Texture2D> allatex;
        Fonster f;
        WorldGen wg = new WorldGen();
        bool we = false;
        bool inv = false;
        bool first = true;
        bool meny = true;
        bool hmeny = true;
        bool normal = false;
        bool wmeny = false;
        bool inmeny = false;
        bool loopcancel = false;
        Random rand = new Random();
        int muscrafting = 300;
        bool muscraft;

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
            addonextensions.Add(new Texture2D[4]);
            addonextensions.Add(new Texture2D[4]);
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
            blocktextures.Add(Content.Load<Texture2D>("jrn"));
            pixel = Content.Load<Texture2D>("Pixel");
            onoff = Content.Load<Texture2D>("OnOff");
            heart = Content.Load<Texture2D>("Hjärta");
            addons.Add(Content.Load<Texture2D>("tree"));
            addons.Add(Content.Load<Texture2D>("sten"));
            addons.Add(Content.Load<Texture2D>("stiik"));
            addons.Add(Content.Load<Texture2D>("Trävägg"));
            addons.Add(Content.Load<Texture2D>("Stenvgg"));
            addons.Add(Content.Load<Texture2D>("trägolv"));
            addons.Add(Content.Load<Texture2D>("stenvg"));
            for (int i = 0; i < 4; i++)
            {
                addonextensions[0][i] = Content.Load<Texture2D>("nothing");
                addonextensions[2][i] = Content.Load<Texture2D>("nothing");
                addonextensions[3][i] = Content.Load<Texture2D>("nothing");
                addonextensions[6][i] = Content.Load<Texture2D>("nothing");
                addonextensions[7][i] = Content.Load<Texture2D>("nothing");
            }
            addonextensions[1][0] = Content.Load<Texture2D>("Tree1");
            addonextensions[1][1] = Content.Load<Texture2D>("Tree2");
            addonextensions[1][2] = Content.Load<Texture2D>("Tree3");
            addonextensions[1][3] = Content.Load<Texture2D>("Tree4");
            addonextensions[4][0] = Content.Load<Texture2D>("Trävägg 1");
            addonextensions[4][1] = Content.Load<Texture2D>("Trävägg 2");
            addonextensions[4][2] = Content.Load<Texture2D>("Trävägg 3");
            addonextensions[4][3] = Content.Load<Texture2D>("Trävägg 4");
            addonextensions[5][0] = Content.Load<Texture2D>("Stenvgg 1");
            addonextensions[5][1] = Content.Load<Texture2D>("Stenvgg 2");
            addonextensions[5][2] = Content.Load<Texture2D>("Stenvgg 3");
            addonextensions[5][3] = Content.Load<Texture2D>("Stenvgg 4");
            itemlist.Add(new Item(0, Content.Load<Texture2D>("Log"), 16));
            itemlist.Add(new Item(1, Content.Load<Texture2D>("steen"), 16));
            itemlist.Add(new Item(2, Content.Load<Texture2D>("stick"), 16));
            itemlist.Add(new Item(3, Content.Load<Texture2D>("flint"), 16));
            itemlist.Add(new Item(4, Content.Load<Texture2D>("hatchet"), 1, 1, 1));
            itemlist.Add(new Item(5, Content.Load<Texture2D>("Plant fiber"), 16));
            itemlist.Add(new Item(6, Content.Load<Texture2D>("Pickaxe"), 1, 2, 1));
            itemlist.Add(new Item(7, Content.Load<Texture2D>("Tragvgg"), 16));
            itemlist.Add(new Item(8, Content.Load<Texture2D>("stnvgg"), 16));
            itemlist.Add(new Item(9, Content.Load<Texture2D>("Tragolv"), 16));
            itemlist.Add(new Item(10, Content.Load<Texture2D>("stengolv"), 16));
            itemlist.Add(new Item(11, Content.Load<Texture2D>("irn ore"), 16));
            itemlist.Add(new Item(12, Content.Load<Texture2D>("coal"), 16));
            itemlist.Add(new Item(13, Content.Load<Texture2D>("iron"), 16));
            itemlist.Add(new Item(14, Content.Load<Texture2D>("iron Pickaxe"), 1, 2, 3));
            itemlist.Add(new Item(15, Content.Load<Texture2D>("axe"), 1, 1, 3));
            text = Content.Load<SpriteFont>("Text");
            menytext = Content.Load<SpriteFont>("Menytext");
            stortext = Content.Load<SpriteFont>("Stortext");
            mellantext = Content.Load<SpriteFont>("Mellanstor");
            smalltext = Content.Load<SpriteFont>("litentext");
            pil = Content.Load<Texture2D>("pil");
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
           

            KeyboardState kstate = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();



            if (first )
            {
                play = new Player(f.Bredd, f.Höjd);
                first  = false;
                for (int i = 0; i < 14; i++)
                {
                    worldedit.Add(new Worldedit(i, f.Bredd - 21, 121 + i * 21));
                }
                weh = new Rectangle(f.Bredd - 21, 121, 21, worldedit.Count * 21);
                wetoggle = new Rectangle(f.Bredd - 21, 100, 21, 21);
                wef  = 0;
                health = 100;
                hpbarbor = new Rectangle(f.Bredd - 320, 10, 210, 30);
                hpbarbak = new Rectangle(f.Bredd - 315, 15, 200, 20);
                hpbar = new Rectangle(f.Bredd - 315, 15, health  * 2, 20);
                healthheart = new Rectangle(f.Bredd - 330, 7, 30, 30);
                ghosts.Clear();
                inventory[0] = new Slot();
                inventory[0].Inventory(inventory);
                trash = new Rectangle(inventory[19].Hitb.X + 50, inventory[19].Hitb.Y, 40, 40);
                mus = new Mus(mstate);
                inventoryhitb = new Rectangle(0, 0, 450, 50);
                hmenytext = new Menuchoice(50, "Main Menu", stortext, f.Bredd / 2, false, 70, false, false);
                hmenytext.Mainmenucreate(huvudmeny, menytext, f.Bredd / 2);
                wmenytext = new Menuchoice(10, "Create custom world", menytext, f.Bredd / 2, false, 70, false, false);
                wmenytext.Worldmenucreate(worldmeny, unclickablew, clickablew, text, mellantext, f.Bredd / 2, wg);
                for(int i = 0; i < itemlist.Count; i++)
                {
                    total.Add(new Craftcheck(i, 0));
                }
                List<Craftcheck> temp = new List<Craftcheck>();
                temp.Add(new Craftcheck(1, 2));
                allcrafts.Add(new Crafting(temp, 3));
                allcrafts[0].Craftingcreation(allcrafts);
                gamemenuout = new Rectangle(f.Bredd / 2 - 125, 70, 250, 300);
                gamemenuin = new Rectangle(gamemenuout.X + 5, gamemenuout.Y + 5, gamemenuout.Width - 10, gamemenuout.Height - 10);
                ingamemeny = new Menuchoice(90, "Paused", menytext, f.Bredd / 2, false, 50, false, false);
                ingamemeny.Ingamemenucreate(gamemenu, mellantext, f.Bredd / 2);
            }
            mus.Musposchange(mstate.X, mstate.Y);
            if (meny )
            {
                if (hmeny )
                {
                    foreach(Menuchoice m in huvudmeny)
                    {
                        m.Active = false;
                        if (mus.Hitb.Intersects(m.Hitb))
                        {
                            m.Active = true;
                        }
                    }
                    if (mstate.LeftButton == ButtonState.Pressed && oldmus.LeftButton == ButtonState.Released)
                    {
                        bool end = false;
                        mus.Huvudmenyklick(huvudmeny, ref meny, ref hmeny, ref normal, ref l, wg, rand, f, ref wmeny, ref lorg, ref end);
                        if (end)
                        {
                            Exit();
                        }
                    }
                }
                if (wmeny )
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
                        mus.Worldmenyklick(worldmeny, unclickablew, clickablew , ref l, wg, rand, mus, mellantext, f, ref meny, ref wmeny, ref normal, ref hmeny, ref lorg);
                    }
                }
            }
            if (inmeny)
            {
                if (kstate.IsKeyDown(Keys.Escape) && oldstate.IsKeyUp(Keys.Escape))
                {
                    inmeny = false;
                    normal = true;
                    loopcancel = false;
                }
                foreach(Menuchoice m in gamemenu)
                {
                    m.Active = false;
                    if (mus.Hitb.Intersects(m.Hitb))
                    {
                        m.Active = true;
                    }

                }
                if (mstate.LeftButton == ButtonState.Pressed && oldmus.LeftButton == ButtonState.Released)
                {
                    bool end = false;
                    mus.Ingamemenuklick(gamemenu, ref inmeny, ref normal, ref l, wg, rand, f.Höjd, f.Bredd, ref hmeny, ref end, ref lorg, ref meny);
                    if (end)
                    {
                        Exit();
                    }
                }
            }
            if(normal )
            {
               
                if (inv )
                {
                    inventoryhitb.Height = 105;
                }
                else
                {
                    inventoryhitb.Height = 50;
                }
                activeslot = misc.Inventoryselect(activeslot, kstate, oldstate);

                mus.Update(l, worldedit, kstate, mstate, oldmus, inventory, wetoggle, ref we, weh, ref wef, inventoryhitb, f, wg, itemlist, total, ref craftable, allcrafts, ref craftingoutline, ref craftinginside, activeslot, rand, play.Pos, trash, inv);
                play.Update(ref l, kstate, mstate, ref xauto, ref yauto, ref xautoscd, ref yautoscd, ref xautohcd, ref yautoncd, ref xautovcd, ref yautoucd, ghosts);
                if (kstate.IsKeyDown(Keys.Back) && oldstate.IsKeyDown(Keys.Back) == false)
                {
                    l = wg.Generate(f.Höjd, f.Bredd, rand, ref lorg);
                }
                if (kstate.IsKeyDown(Keys.Tab) && oldstate.IsKeyUp(Keys.Tab))
                {
                    if (inv )
                    {
                        inv  = false;
                    }
                    else
                    {
                        inv  = true;
                    }


                }
                if (mus.Hitb.Intersects(craftingoutline) && inv )
                {
                    muscraft = true;
                    for (int i = 0; i < craftable.Count; i++)
                    {
                        if (mus.Hitb.Intersects(craftable[i].Place.Hitb))
                        {
                            craftable[i].Requirementshow(ref craftarrow, ref craftshow);
                            muscrafting = i;

                            break;
                        }
                    }


                }
                else
                {
                    muscraft = false;
                }
                if (kstate.IsKeyDown(Keys.O) && health  > 0)
                {
                    health --;
                }
                if (kstate.IsKeyDown(Keys.P) && health  < 100)
                {
                    health ++;
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
                        health  -= 5;
                    }
                }
                hpbar.Width = health  * 2;
                if(kstate.IsKeyDown(Keys.Escape) && oldstate.IsKeyUp(Keys.Escape) && loopcancel)
                {
                    inmeny = true;
                    normal = false;
                }
                loopcancel = true;
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
            if (meny )
            {
                if (hmeny )
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
                if (wmeny )
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
            else if (normal || inmeny)
            {

                foreach (Block b in l)
                {
                    spriteBatch.Draw(blocktextures[b.Id], b.Rek, Color.White);
                    if (b.Addontype >= 2)
                    {
                        spriteBatch.Draw(addons[b.Addontype], b.Addon, Color.White);
                        for(int i = 1; i < 4; i++)
                        {
                            if (b.Addontrue[i])
                            {
                                spriteBatch.Draw(addonextensions[b.Addontype][i], b.Rek, Color.White);
                            }
                        }
                        if (b.Addontrue[0])
                        {
                            spriteBatch.Draw(addonextensions[b.Addontype][0], b.Rek, Color.White);
                        }
                    }
                }
                spriteBatch.Draw(player, play.Pos, Color.White);
                foreach (Block b in l)
                {
                    if (b.Addontype == 1)
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
                if (we  == false)
                {
                    spriteBatch.Draw(pixel, wetoggle, Color.Red);
                }
                else if (we )
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
                if (we )
                {
                    spriteBatch.Draw(onoff, tillf, Color.Green);
                }
                else
                {
                    spriteBatch.Draw(onoff, tillf, Color.Red);
                }
                for (int i = 0; i < 10; i++)
                {
                    if (i == activeslot )
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
                        if (inventory[i].Numb < 10 && inventory[i].It.Max > 1)
                        {
                            spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                        }

                        else if (inventory[i].It.Max > 1)
                        {
                            spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - 2 * text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                        }
                    }
                    if (i != 9)
                    {
                        spriteBatch.DrawString(text, Convert.ToString(i + 1), new Vector2(inventory[i].Förg.X, inventory[i].Förg.Y), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(text, "0", new Vector2(inventory[i].Förg.X, inventory[i].Förg.Y), Color.White);
                    }
                }
                if (inv )
                {
                    for (int i = 10; i < 20; i++)
                    {
                        spriteBatch.Draw(pixel, inventory[i].Hitb, Color.Blue);
                        spriteBatch.Draw(pixel, inventory[i].Förg, Color.DarkBlue);
                        if (inventory[i].It.Id != -1)
                        {
                            spriteBatch.Draw(inventory[i].It.Tex, inventory[i].Hitb, Color.White);
                            if (inventory[i].Numb < 10 && inventory[i].It.Max > 1)
                            {
                                spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                            }
                            else if(inventory[i].It.Max > 1)
                            {
                                spriteBatch.DrawString(text, Convert.ToString(inventory[i].Numb), new Vector2(inventory[i].Förg.X + 34 - 2 * text.LineSpacing, inventory[i].Förg.Y + 24), Color.White);
                            }
                        }
                    }
                    spriteBatch.Draw(pixel, craftingoutline, Color.Blue);
                    spriteBatch.Draw(pixel, craftinginside, Color.LightBlue);
                    foreach(Crafting c in craftable)
                    {
                        spriteBatch.Draw(c.Place.It.Tex, c.Place.Hitb, Color.White);
                    }
                    if(muscraft)
                    {

                        spriteBatch.Draw(pixel, craftshow, Color.DarkBlue);
                        spriteBatch.Draw(pil, craftarrow, Color.DarkBlue);
                        for(int i = 0; i < craftable[muscrafting].Req.Count; i++)
                        {
                            spriteBatch.Draw(itemlist[craftable[muscrafting].Req[i].Id].Tex, new Rectangle(craftshow.X + i * 40, craftshow.Y, 40, 40), Color.White);
                            if(craftable[muscrafting].Req[i].Numb > 1)
                            {
                                spriteBatch.DrawString(text, Convert.ToString(craftable[muscrafting].Req[i].Numb), new Vector2(craftshow.X + i * 40 + 30, craftshow.Y + 30), Color.White);
                            }
                        }
                    }
                    spriteBatch.Draw(pixel, trash, Color.Black);
                }
                spriteBatch.Draw(pixel, hpbarbor, Color.White);
                spriteBatch.Draw(pixel, hpbarbak, Color.Black);
                spriteBatch.Draw(pixel, hpbar, Color.Red);
                spriteBatch.Draw(heart, healthheart, Color.White);
                if (inmeny)
                {
                    spriteBatch.Draw(pixel, gamemenuout, Color.White);
                    spriteBatch.Draw(pixel, gamemenuin, Color.Black);
                    spriteBatch.DrawString(menytext, ingamemeny.Text, ingamemeny.Textlocation, Color.White);
                    foreach (Menuchoice m in gamemenu)
                    {
                        spriteBatch.DrawString(mellantext, m.Text, m.Textlocation, Color.White);
                        if (m.Active)
                        {
                            spriteBatch.DrawString(mellantext, ">", m.Leftchoice, Color.White);
                            spriteBatch.DrawString(mellantext, "<", m.Rightchoice, Color.White);
                        }
                    }
                }
                if (mus.Sloot.It.Id == -1 || inmeny)
                {
                    spriteBatch.Draw(mustex, mus.Pos, Color.White);
                }
                else
                {
                    spriteBatch.Draw(mus.Sloot.It.Tex, mus.Sloot.Hitb, Color.White);
                    if (mus.Sloot.Numb < 10 && mus.Sloot.It.Max > 1)
                    {
                        spriteBatch.DrawString(text, Convert.ToString(mus.Sloot.Numb), new Vector2(mus.Sloot.Förg.X + 34 - text.LineSpacing, mus.Sloot.Förg.Y + 24), Color.White);
                    }
                    else if(mus.Sloot.It.Max > 1)
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
