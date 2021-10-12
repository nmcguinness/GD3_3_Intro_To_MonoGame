using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GDLibrary
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            System.Diagnostics.Debug.WriteLine("Game1");
        }

        protected override void Initialize()
        {
            System.Diagnostics.Debug.WriteLine("Initialize");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            System.Diagnostics.Debug.WriteLine("LoadContent");
        }

        protected override void UnloadContent()
        {
            System.Diagnostics.Debug.WriteLine("UnloadContent");
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            System.Diagnostics.Debug.WriteLine("Update");
            System.Diagnostics.Debug.WriteLine(gameTime.ElapsedGameTime.TotalMilliseconds);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            System.Diagnostics.Debug.WriteLine("Draw");

            base.Draw(gameTime);
        }
    }
}