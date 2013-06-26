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

namespace KeyValueCard
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BaseGraphicalMiyagiKeyCard : Microsoft.Xna.Framework.Game
    {
        public string nameOfShape;
        //public string mathExpressionToDisplay;
        //protected int width;
        //protected int height;
        public bool isTargeted;
        public const float SCALE_FACTOR = 1.333f;
        protected MPoint3D position;

        // Vairables needed to construct the keycard
        //GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        Texture2D shape;
        public RenderTarget2D renderTarget;
        protected bool dragging = false;
        //Vector2 cardPosition;

        // Container dimensions
        protected const float CONTAINER_WIDTH = 300f;
        protected const float CONTAINER_HEIGHT = 200f;
        protected const float CONTAINER2_WIDTH = CONTAINER_WIDTH * SCALE;
        protected const float CONTAINER2_HEIGHT = CONTAINER_HEIGHT * SCALE;
        protected const float SHAPE_WIDTH = 150;
        protected const int SHAPE_HEIGHT = 150;
        protected const float SCALE = 1.333f;
        protected Rectangle container = new Rectangle(0, 0, (int)CONTAINER_WIDTH, (int)CONTAINER_HEIGHT);
        protected Rectangle scaledContainer = new Rectangle(0, 0, (int)CONTAINER2_WIDTH, (int)CONTAINER2_HEIGHT);

        public BaseGraphicalMiyagiKeyCard(string name, /*string mathExpression,*/ /*int width, 
            int height,*/ float xPos, float yPos, float zPos)
        {
            this.nameOfShape = name;
            //this.mathExpressionToDisplay = mathExpression;
            //this.width = width;
            //this.height = height;
            position = new MPoint3D(xPos, yPos, zPos);
        }

        public void SetPosition(float xPos, float yPos, float zPos)
        {
            position.SetPosition(xPos, yPos, zPos);
        }

        //public void SetSize(int width, int height)
        //{
        //    this.width = width;
        //    this.height = height;
        //}

        //public int GetWidth()
        //{
        //    return this.width;
        //}

        //public int GetHeight()
        //{
        //    return this.height;
        //}

        protected void LoadContent(String shapeName)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight);
            shape = Content.Load<Texture2D>(shapeName);
            //rectangle = new Texture2D(GraphicsDevice, 1, 1);
            //rectangle.SetData(new[] { Color.White }); // What does this mean???
            // TODO: use this.Content to load your game content here
        }

        public MPoint3D GetPosition()
        {
            return position.GetPosition();
        }

        protected void DrawRenderTarget()
        {
            // Set the device to the render target
            MouseState ms = Mouse.GetState();
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            // *****THIS WORKS!*****
            if (isMouseOver(ms))
            {
                float Xval = CONTAINER_WIDTH * SCALE / 2 - SHAPE_WIDTH * SCALE / 2;
                float Yval = CONTAINER_HEIGHT * SCALE / 2 - SHAPE_HEIGHT * SCALE / 2;
                MPoint3D pos = new MPoint3D(Xval, Yval, 0);
                spriteBatch.Draw(shape, new Vector2(pos.X, pos.Y), null, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);
            }
            else
            {
                float Xval = CONTAINER_WIDTH / 2 - SHAPE_WIDTH / 2;
                float Yval = CONTAINER_HEIGHT / 2 - SHAPE_HEIGHT / 2;
                //Vector2 pos = new Vector2(Xval, Yval);
                MPoint3D pos = new MPoint3D(Xval, Yval, 0);
                spriteBatch.Draw(shape, new Vector2(pos.X, pos.Y), Color.White);
            }
            // *****END THIS WORKS!*****

            spriteBatch.End();

            // Reset the device to the back buffer
            GraphicsDevice.SetRenderTarget(null);
        }

        public bool isMouseOver(MouseState mouseState)
        {
            if ((mouseState.X > position.X) && (mouseState.X < (position.X + container.Width)) &&
                (mouseState.Y > position.Y) && (mouseState.Y < (position.Y + container.Height)))
            {
                return true;
            }
            return false;
        }


    }
}
