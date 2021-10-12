using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/**
 * 1. View, Projection (Camera)
 * 2. Effect (shader code running on GFX card)
 * 3. Vertices
 * 4. PrimitiveType (line, triangle)
 */

namespace GDLibrary
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Matrix view;
        private Matrix projection;
        private BasicEffect effect;
        private VertexPositionColor[] vertices;

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
            InitializeCamera();
            IntializeEffect();
            InitializeVertices();

            base.Initialize();
        }

        #region Initialization

        private void InitializeCamera()
        {
            /*
             * View - position, look, up, target, right
             * Projection - NCP, FCP, AspectRatio, FoV
             */

            Vector3 cameraPosition = new Vector3(0, 0, 10);
            Vector3 cameraTarget = new Vector3(0, 0, 0);
            Vector3 cameraUp = Vector3.UnitY;

            view = Matrix.CreateLookAt(cameraPosition,
                cameraTarget, cameraUp);

            float fieldOfView = (float)Math.PI / 2.0f;
            float aspectRatio = 16 / 10.0f; // 1.6f; // 1920/1080.0f;
            float nearPlaneDistance = 0.1f;
            float farPlaneDistance = 1000;

            projection =
                Matrix.CreatePerspectiveFieldOfView(fieldOfView,
                aspectRatio, nearPlaneDistance, farPlaneDistance);
        }

        private void IntializeEffect()
        {
            //default shader provided by MonoGame
            effect = new BasicEffect(_graphics.GraphicsDevice);
            effect.VertexColorEnabled = true;
        }

        private void InitializeVertices()
        {
            //VertexPositionColor[]
            vertices
                = new VertexPositionColor[2];

            //left
            vertices[0] = new VertexPositionColor(
                new Vector3(-5, 0, 0), Color.Red);

            //right
            vertices[1] = new VertexPositionColor(
                    new Vector3(5, 0, 0), Color.Green);
        }

        #endregion Initialization

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //     System.Diagnostics.Debug.WriteLine("LoadContent");
        }

        protected override void UnloadContent()
        {
            //     System.Diagnostics.Debug.WriteLine("UnloadContent");
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            //     System.Diagnostics.Debug.WriteLine("Update");
            //      System.Diagnostics.Debug.WriteLine(gameTime.ElapsedGameTime.TotalMilliseconds);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //set variables on the shader
            effect.World = Matrix.Identity;
            effect.View = view;
            effect.Projection = projection;

            //load the variables (W,V,P) for use in the next draw pass
            effect.CurrentTechnique.Passes[0].Apply();

            effect.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                               PrimitiveType.LineList, vertices, 0, 1);

            base.Draw(gameTime);
        }
    }
}