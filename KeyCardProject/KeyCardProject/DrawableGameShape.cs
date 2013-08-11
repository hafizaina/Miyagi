/// <summary>
    ///  A class that represents a DrawableGameShape object.
    /// 
    
     /// </summary>
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

namespace HumanStorm.Miyagi.Framework
{
    public class DrawableGameShape : BaseDrawableGamePiece
    {
        // Attributes
        /// <summary>
        /// The Texture2D that corresponds to the shape to display on the key-block.
        /// </summary>
        public Texture2D TextureForShape;

        /// <summary>
        /// The name of the shape that this object will draw on the screen.
        /// </summary>
        public String NameOfShape;

        /// <summary>
        /// Determines if KeyCard is being dragged
        /// </summary>
        bool dragging = false;
        
#region ScalingMotionData
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
#endregion ScalingMotionData

#region Dragging
    private MouseState PrevMouseState;
    int xDisplacement;
    int yDisplacement;
#endregion Dragging

        // Operations

        /// <summary>
        /// Initializes a new DrwableGameShape object.
        /// </summary>
        /// <param name="sharedSprite">
        /// </param>
        /// <param name="NameOfShape">
        /// </param>
        /// <param name="widthOfThisGamePiece">
        /// </param>
        /// <param name="heightOfGamePiece">
        /// </param>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public DrawableGameShape(string NameOfShape, Texture2D backgroundRectColor, Color colorOfGamePiece, SpriteBatch sharedSprite, Rectangle viewPort, int widthOfGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos):
            base(backgroundRectColor, colorOfGamePiece, sharedSprite, viewPort, widthOfGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {
            this.NameOfShape = NameOfShape;
            this.PrevMouseState = Mouse.GetState();
        }

        public void LoadContent(ContentManager content)
        {
            this.TextureForShape = content.Load<Texture2D>(NameOfShape);
        }

        public override void Draw(GameTime time)
        {
            this.SharedSpriteBatch.Begin();
            this.SharedSpriteBatch.Draw(backgroundRectangleColor, ViewPort, Color.Green);
            //this.SharedSpriteBatch.Draw(backgroundRectangleColor, RectangleEnclosingThisObject, Color.Red);
            this.SharedSpriteBatch.Draw(TextureForShape, RectangleEnclosingThisObject, base.ColorOfShape);
            this.SharedSpriteBatch.End();
        }

        public override void Update(GameTime time)
        {
            MouseState ms = Mouse.GetState();
            if (IsMouseOver(ms))
            {
                this.SetColor(Color.Red);
            }
            else if (!(IsMouseOver(ms)))
            {
                this.SetColor(Color.Blue);
            }
        }

        public void SetColor(Color color)
        {
            base.ColorOfShape = color;
        }

        public Vector2 SetPositionOfShape()
        {
            float xPos = base.ViewPort.X + (base.ViewPort.Width / 2) - base.GetWidth() / 2;
            float yPos = base.ViewPort.Y + (base.ViewPort.Height / 2) - base.GetHeight() / 2;
            return new Vector2(xPos, yPos);
        }

        //public void DrawNormalGameShape()
        //{
        //    this.SharedSpriteBatch.Begin();
        //    this.SharedSpriteBatch.Draw(backgroundRectangleColor, ViewPort, Color.Green);
        //    this.SharedSpriteBatch.Draw(backgroundRectangleColor, RectangleEnclosingThisObject, Color.Red);
        //}

        public bool IsMouseOver(MouseState mouseState)
        {
            //if (IsSelected)
            //{
            //    return ((mouseState.X > xScaledPosition) && (mouseState.X < (xScaledPosition + GetWidth() * SCALE_FACTOR)) &&
            //        (mouseState.Y > yScaledPosition) && (mouseState.Y < (yScaledPosition + GetHeight() * SCALE_FACTOR)));
            //}
            //else
            //{
            //    return ((mouseState.X > GetPosition().X) && (mouseState.X < (GetPosition().X + GetWidth())) &&
            //        (mouseState.Y > GetPosition().Y) && (mouseState.Y < (GetPosition().Y + GetHeight())));
            //}
            if (IsSelected)
            {
                return ((mouseState.X > xScaledPosition) && (mouseState.X < (xScaledPosition + GetWidth() * SCALE_FACTOR)) &&
                    (mouseState.Y > yScaledPosition) && (mouseState.Y < (yScaledPosition + GetHeight() * SCALE_FACTOR)));
            }
            else
            {
                return ((mouseState.X > GetPosition().X) && (mouseState.X < (ViewPort.X + ViewPort.Width)) &&
                    (mouseState.Y > GetPosition().Y) && (mouseState.Y < (ViewPort.Y + ViewPort.Height)));
            }
        }
    } 
}