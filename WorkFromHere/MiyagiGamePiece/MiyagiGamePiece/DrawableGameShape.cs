

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
        public DrawableGameShape(string NameOfShape, Color colorOfGamePiece, SpriteBatch sharedSprite, Rectangle viewPort, int widthOfGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos):
            base(colorOfGamePiece, sharedSprite, viewPort, widthOfGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {
            this.NameOfShape = NameOfShape;
        }


        public bool IsMouseOver(MouseState mouseState)
        {
            if (IsSelected)
            {
                return ((mouseState.X > xScaledPosition) && (mouseState.X < (xScaledPosition + GetWidth() * SCALE_FACTOR)) &&
                    (mouseState.Y > yScaledPosition) && (mouseState.Y < (yScaledPosition + GetHeight() * SCALE_FACTOR)));
            }
            else
            {
                return ((mouseState.X > GetPosition().X) && (mouseState.X < (GetPosition().X + GetWidth())) &&
                    (mouseState.Y > GetPosition().Y) && (mouseState.Y < (GetPosition().Y + GetHeight())));
            }
        }

        public void DrawBackgroundAndShape()
        {
            MouseState ms = Mouse.GetState();
        }
    } 
}