using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AwesomeThreadingFun.Builder;

namespace AwesomeThreadingFun
{

    /*
     * 
     * 
     * Guess what just worked \o/ ~Andreas
     * 
     * 
     */ 

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class Gameworld : Game
    {
        private object key = new object();
        private SpriteFont font;

        private static Gameworld _instance;
        public static Gameworld Instance { get { return _instance == null ? _instance = new Gameworld() : _instance; } }

        public Random Random;
        public SpriteFont Font
        {
            get { return font; }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> gos;

        private Gameworld()
        {
            base.IsMouseVisible = true;
            gos = new List<GameObject>();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Random = new Random((int)DateTime.Now.Ticks);
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
            Other.Picture.Initialize(Content);
            ButtonEventHandler.Initialize();
            font = Content.Load<SpriteFont>("Fonts/font");

            GameObject Factory;

            Add(new Director(new ShopBuilder()).BuildObject());

            Add(new Director(new PeopleSpawnBuilder(20, 1000, new Other.VectorF(GraphicsDevice.Viewport.Width / 2, 0))).BuildObject());
            Add(new Director(new PeopleSpawnBuilder(20, 1000, new Other.VectorF(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height))).BuildObject());
            
            Factory = new Director(new FactoryBuilder(new Other.Vector(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), 1500, 1)).BuildObject();
            Factory.GetComponent<Components.Factory>().AddContract(new ShopItems.Contract(20, 200000));
            Add(Factory);

            Factory = new Director(new FactoryBuilder(new Other.Vector(GraphicsDevice.Viewport.Width, 0), 1000, 2)).BuildObject();
            Factory.GetComponent<Components.Factory>().AddContract(new ShopItems.Contract(10, 5000000));
            Add(Factory);
            
            Factory = new Director(new FactoryBuilder(new Other.Vector(0, GraphicsDevice.Viewport.Height - 200), 500, 3)).BuildObject();
            Add(Factory);

            Add(new Director(new ButtonBuilder(ButtonType.LoadingbayUpgrade, new Other.VectorF(
                GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2))).BuildObject());
        }

        /// <summary>
        /// Adds a gameobject to the world, and starts its loop
        /// </summary>
        /// <param name="go">The gameobject to add</param>
        public void Add(GameObject go)
        {
            lock (key) { gos.Add(go); }
            go.Start();
        }

        /// <summary>
        /// Removes a gameobject from the world, and tells the gameobject to please go kill itself
        /// </summary>
        /// <param name="go">the gameobject to remove</param>
        public void Remove(GameObject go)
        {
            lock (key) { gos.Remove(go); }
            go.Kill();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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

            InputManager.Update(gameTime.TotalGameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// Gets a gameobject matching the specified filter
        /// </summary>
        /// <param name="Filter">The filter to filter with</param>
        /// <returns>the first occuring matching the Filter</returns>
        public GameObject GetGameobject(Func<GameObject, bool> Filter)
            => gos.Find(g => Filter(g));

        /// <summary>
        /// Gets all gameobjects matching the specified filter
        /// </summary>
        /// <param name="Filter">The filter to filter with</param>
        /// <returns>All occuring matches of the filter</returns>
        public GameObject[] GetGameobjects(Func<GameObject, bool> Filter)
            => gos.FindAll(g => Filter(g)).ToArray();

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            lock (key)
            {
                for (int i = 0; i < gos.Count; i++)
                    gos[i].Draw(this.spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
