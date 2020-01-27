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
        List<Grass> l = new List<Grass>();
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
        Player play;
        Fonster f;
        WorldGen wg = new WorldGen();
        Bool b = new Bool(true);
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
            mgrass = Content.Load<Texture2D>("mGrass");
            mstone = Content.Load<Texture2D>("mStone");
            mdeepwater = Content.Load<Texture2D>("mWater");
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
            play = new Player(f.Bredd, f.Höjd);
            if (b.Boll == true)
            {
                l = wg.Generate(f.Höjd, f.Bredd, rand);
                b.Boll = false;
            }
            play.Update(ref l, kstate, mstate);
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
            foreach (Grass gras in l)
            {
                if (gras.Färg == "White")
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
            }
            foreach(Grass gras in l)
            {
                if (gras.Färg == "White")
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
            }
            spriteBatch.Draw(player, play.Pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
