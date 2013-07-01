using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RenderTarget
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
#region variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D shape;
        RenderTarget2D renderTarget;
        bool dragging = false;
        MouseState prevMouseState;
#endregion variables


#region Dimensions
        // Normal and scaled container dimensions
        const float CONTAINER_WIDTH = 300f;
        const float CONTAINER_HEIGHT = 200f;
        const float SCALEDCONTAINER_WIDTH = CONTAINER_WIDTH * SCALE;
        const float SCALEDCONTAINER_HEIGHT = CONTAINER_HEIGHT * SCALE;
        const float SHAPE_WIDTH = 150;
        const int SHAPE_HEIGHT = 150;
        const float SCALE = 1.333f;
#endregion Dimensions


#region PositionData
        /// <summary>
        /// X coordinate at center of normal container
        /// </summary>
        private float xCenter;
        /// <summary>
        /// Y coordinate at center of normal container
        /// </summary>
        private float yCenter;
        /// <summary>
        /// Position of normal container
        /// </summary>
        Vector2 cardPosition;
        /// <summary>
        /// X coordinate of enlargened container
        /// </summary>
        private float xScaledPosition;
        /// <summary>
        /// Y coordinate of enlargened container
        /// </summary>
        private float yScaledPosition;
#endregion PositionData


#region Containers
        /// <summary>
        /// The rectangle to hold the image.
        /// </summary>
        Rectangle container = new Rectangle(0, 0, (int)CONTAINER_WIDTH, (int)CONTAINER_HEIGHT);

        /// <summary>
        /// The scaled rectangle to hold the scaled image.
        /// </summary>
        Rectangle ScaledContainerForImage;
#endregion Containers

        /// <summary>
        /// Specifies for background rectangle to scale from the center
        /// </summary>
        private Vector2 ScaleMotion;
        private bool IsScaled;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cardPosition = new Vector2(200, 50);
            ScaledContainerForImage = new Rectangle(0, 0, (int)SCALEDCONTAINER_WIDTH, (int)SCALEDCONTAINER_HEIGHT);
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
            base.IsMouseVisible = true;
            prevMouseState = Mouse.GetState();
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
            renderTarget = new RenderTarget2D(GraphicsDevice, 
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight);
            shape = Content.Load<Texture2D>("circle");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            MouseState ms = Mouse.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //###################################
            // SCALE BACKGROUND RECTANGLE FROM CENTER
            //####################################

            #region SCALE_MOTION_LOGISTICS
            xCenter = cardPosition.X + (.5f * (float) container.Width);
            yCenter = cardPosition.Y + (.5f * (float)container.Height);

            xScaledPosition = xCenter - (.5f * ScaledContainerForImage.Width);
            yScaledPosition = yCenter - (.5f * ScaledContainerForImage.Height);

            ScaleMotion = new Vector2(xScaledPosition, yScaledPosition);

            #endregion SCALED_MOTION_LOGISTICS

            //#####################
            // DRAG THE IMAGE
            //######################
            #region DRAG
            if (dragging == false)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    if (isMouseOver(ms, IsScaled))
                    {
                        dragging = true;
                        cardPosition = new Vector2(ms.X - (container.Height/2), ms.Y - (container.Width/2));
                    }
                }
            }
            else
            {
                cardPosition = new Vector2(ms.X - (container.Height / 2), ms.Y - (container.Width / 2));
                if (ms.LeftButton == ButtonState.Released)
                {
                    dragging = false;
                }
            }
            #endregion DRAG

           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            this.DrawRenderTarget();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (isMouseOver(ms, IsScaled))
            {
                //The new scaled image.
                spriteBatch.Draw((Texture2D)renderTarget, ScaleMotion, ScaledContainerForImage, Color.White);
                IsScaled = true;
            }
            else
            {
                spriteBatch.Draw((Texture2D)renderTarget, cardPosition, container, Color.White);
                IsScaled = false;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // MY NEW METHODS
        private void DrawRenderTarget()
        {
            // Set the device to the render target
            MouseState ms = Mouse.GetState();
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            // *****THIS WORKS!*****
            if (isMouseOver(ms,IsScaled))
            {
                float Xval = ScaledContainerForImage.Width/2 - SHAPE_WIDTH*SCALE/2;
                float Yval = ScaledContainerForImage.Height/2 - SHAPE_HEIGHT*SCALE/2;
                Vector2 pos = new Vector2(Xval, Yval);
                spriteBatch.Draw(shape, pos, null, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);
            }
            else
            {
                float Xval = CONTAINER_WIDTH / 2 - SHAPE_WIDTH / 2;
                float Yval = CONTAINER_HEIGHT / 2 - SHAPE_HEIGHT / 2;
                Vector2 pos = new Vector2(Xval, Yval);
                spriteBatch.Draw(shape, pos, Color.White);
            }
            // *****END THIS WORKS!*****

            spriteBatch.End();

            // Reset the device to the back buffer
            GraphicsDevice.SetRenderTarget(null);
        }


        /// <summary>
        /// Checks to see if mouse is hovering over keycard
        /// </summary>
        /// <param name="mouseState">The state of the mouse.</param>
        /// <returns>true if mouse is over keycard, false otherwise</returns>
        public bool isMouseOver(MouseState mouseState, bool scale)
        {
            if (IsScaled)
            {
                return ((mouseState.X > xScaledPosition) && (mouseState.X < (xScaledPosition + SCALEDCONTAINER_WIDTH)) &&
                (mouseState.Y > yScaledPosition) && (mouseState.Y < (yScaledPosition + SCALEDCONTAINER_HEIGHT)));
            }
            else
            {
                return ((mouseState.X > cardPosition.X) && (mouseState.X < (cardPosition.X + container.Width)) &&
                    (mouseState.Y > cardPosition.Y) && (mouseState.Y < (cardPosition.Y + container.Height)));
            }
        }
    }
}
