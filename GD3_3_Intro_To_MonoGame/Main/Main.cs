using GDLibrary.Factory;
using GDLibrary.Type;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        #region Member Variables

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Matrix view;
        private Matrix projection;
        private BasicEffect effect;
        private VertexPositionColor[] vertices;
        private float rotationInDegrees = 0;
        private Vector3 translation = Vector3.Zero;
        private IVertexData vertexData;
        private IVertexData yAxisVertexData;
        private IVertexData zAxisVertexData;
        private BasicEffect texturedEffect;
        private Texture2D skyboxBackTexture;
        private Texture2D skyboxLeftTexture;
        private Texture2D skyboxRightTexture;
        private int worldScale = 400;

        #endregion Member Variables

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

        #region Initialization

        protected override void Initialize()
        {
            InitializeResolution(640, 480);
            InitializeCamera();
            IntializeEffect();
            InitializeVertices();
            LoadAssets();

            base.Initialize();
        }

        private void LoadAssets()
        {
            LoadTextures();
        }

        private void LoadTextures()
        {
            skyboxBackTexture
            = Content.Load<Texture2D>(
                "Assets/Textures/Skybox/back");

            skyboxLeftTexture
            = Content.Load<Texture2D>(
              "Assets/Textures/Skybox/left");

            skyboxRightTexture
            = Content.Load<Texture2D>(
            "Assets/Textures/Skybox/right");
        }

        private void InitializeResolution(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }

        private void InitializeCamera()
        {
            /*
             * View - position, look, up, target, right
             * Projection - NCP, FCP, AspectRatio, FoV
             */

            Vector3 cameraPosition = new Vector3(0, 0, 5);
            Vector3 cameraTarget = new Vector3(0, 0, 0);
            Vector3 cameraUp = Vector3.UnitY;

            view = Matrix.CreateLookAt(cameraPosition,
                cameraTarget, cameraUp);

            float fieldOfView = (float)Math.PI / 2.0f;
            float aspectRatio = (float)_graphics.PreferredBackBufferWidth
                / _graphics.PreferredBackBufferHeight;
            float nearPlaneDistance = 0.1f;
            float farPlaneDistance = 1000;

            projection =
                Matrix.CreatePerspectiveFieldOfView(fieldOfView,
                aspectRatio, nearPlaneDistance, farPlaneDistance);
        }

        private void IntializeEffect()
        {
            //wireframe, filled triangles
            effect = new BasicEffect(_graphics.GraphicsDevice);
            effect.VertexColorEnabled = true;

            //textured unlit
            texturedEffect = new BasicEffect(_graphics.GraphicsDevice);
            texturedEffect.TextureEnabled = true;

            //textured lit
        }

        private void InitializeVertices()
        {
            vertexData = VertexDataFactory.Get(
                VertexDataType.TexturedQuad);
        }

        #endregion Initialization

        #region Load & Unload Content

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        #endregion Load & Unload Content

        #region Update & Draw

        protected override void Update(GameTime gameTime)
        {
            rotationInDegrees += 3;
            rotationInDegrees %= 360;
            base.Update(gameTime);
        }

        private void Draw(GameTime gameTime,
            Matrix world, Matrix view, Matrix projection,
            BasicEffect effect, Texture2D texture,
            IVertexData vertexData)
        {
            //set variables on the shader
            effect.World = world;
            effect.View = view;
            effect.Projection = projection;
            effect.Texture = texture;

            //load the variables (W,V,P) for use in the next draw pass
            effect.CurrentTechnique.Passes[0].Apply();

            //draw the IVertexData object (e.g. x-axis line)
            vertexData.Draw(gameTime, effect);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //back
            Draw(gameTime,
                Matrix.Identity
                * Matrix.CreateScale(new Vector3(worldScale, worldScale, 1))
                * Matrix.CreateTranslation(new Vector3(0, 0, -worldScale / 2)),
                view, projection,
                texturedEffect,
                skyboxBackTexture, vertexData);

            //left
            Draw(gameTime,
                Matrix.Identity
                * Matrix.CreateScale(new Vector3(worldScale, worldScale, 1))
                * Matrix.CreateRotationY(MathHelper.ToRadians(90))
                * Matrix.CreateTranslation(new Vector3(-worldScale / 2, 0, 0)),
                view, projection,
                texturedEffect,
                skyboxLeftTexture, vertexData);

            base.Draw(gameTime);
        }

        #endregion Update & Draw
    }
}