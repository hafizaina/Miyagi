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
    public class GraphicalMiyagiKeyCardForXNA : KeyValueCard.BaseGraphicalMiyagiKeyCard
    {
        public GraphicalMiyagiKeyCardForXNA(string nameOfShape, /*string mathExpression,*/ int width, int height,
            float xPos, float yPos, float zPos)
            : base(nameOfShape, /*mathExpression,*/ /*width, height,*/ xPos, yPos, zPos)
        {
            base.LoadContent(nameOfShape);
            base.IsMouseVisible = true;           
            Content.RootDirectory = "Content";
        }

        public void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            MouseState ms = Mouse.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            ms = Mouse.GetState();
            if (dragging == false)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    if (isMouseOver(ms))
                    {
                        dragging = true;
                        position = new MPoint3D(ms.X - (container.Height / 2), ms.Y - (container.Width / 2), 0);
                    }
                }
            }
            else
            {
                position = new MPoint3D(ms.X - (container.Height / 2), ms.Y - (container.Width / 2), 0);
                if (ms.LeftButton == ButtonState.Released)
                {
                    dragging = false;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            DrawRenderTarget();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // ****** THIS WORKS!!!*****
            if (isMouseOver(ms))
            {
                spriteBatch.Draw((Texture2D)renderTarget, new Vector2(position.X, position.Y), scaledContainer, Color.White);
            }
            else
            {
                spriteBatch.Draw((Texture2D)renderTarget, new Vector2(position.X, position.Y), container, Color.White);
            }
            spriteBatch.End();
            // ***** END THIS WOKRS!!! *****

            base.Draw(gameTime);
        }


    }
}
