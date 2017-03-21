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

        private static Gameworld _instance;
        public static Gameworld Instance { get { return _instance == null ? _instance = new Gameworld() : _instance; } }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> gos;

        private Gameworld()
        {
            base.IsMouseVisible = true;
            gos = new List<GameObject>();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            GameObject Factory;

            Add(new Director(new ShopBuilder()).BuildObject());

            Factory = new Director(new FactoryBuilder(new Other.Vector(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height))).BuildObject();
            Factory.GetComponent<Components.Factory>().AddContract(new ShopItems.Contract(20, 200000));
            Add(Factory);

            Factory = new Director(new FactoryBuilder(new Other.Vector(GraphicsDevice.Viewport.Width, 0))).BuildObject();
            Factory.GetComponent<Components.Factory>().AddContract(new ShopItems.Contract(10, 5000000));
            Add(Factory);

            Factory = new Director(new FactoryBuilder(new Other.Vector(0, GraphicsDevice.Viewport.Height))).BuildObject();
            Factory.GetComponent<Components.Factory>().AddContract(new ShopItems.Contract(50, 100000));
            Add(Factory);
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
