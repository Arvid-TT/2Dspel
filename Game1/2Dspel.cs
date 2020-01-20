using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        List<Rectangle> l = new List<Rectangle>();
        Texture2D grass;
        Fonster f;
        Bool b = new Bool(true);

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
            if (b.Boll == true)
            {
                for (int y = f.Höjd / 2 - 5000; y < f.Höjd/2+5000; y += 100)
                {
                    for (int x = f.Bredd / 2 - 5000; x < f.Bredd/2 + 5000; x += 100)
                    {
                        l.Add(new Rectangle(x, y, 100, 100));
                    }
                }
                b.Boll = false;
            }
            if (kstate.IsKeyDown(Keys.Up))
            {
                List<Rectangle> tillflista = new List<Rectangle>();
                foreach (Rectangle r in l)
                {
                    tillflista.Add(new Rectangle(r.X, r.Y + 5, 100, 100));
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                List<Rectangle> tillflista = new List<Rectangle>();
                foreach (Rectangle r in l)
                {
                    tillflista.Add(new Rectangle(r.X, r.Y - 5, 100, 100));
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                List<Rectangle> tillflista = new List<Rectangle>();
                foreach (Rectangle r in l)
                {
                    tillflista.Add(new Rectangle(r.X + 5, r.Y, 100, 100));
                }
                l = tillflista;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                List<Rectangle> tillflista = new List<Rectangle>();
                foreach (Rectangle r in l)
                {
                    tillflista.Add(new Rectangle(r.X - 5, r.Y, 100, 100));
                }
                l = tillflista;
            }
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
            foreach (Rectangle gras in l)
            {
                spriteBatch.Draw(grass, gras, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
