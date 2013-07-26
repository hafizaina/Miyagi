
/// <summary>
 /// </summary>
/// <summary>
    /// The client program should add an instance of this class to the list of game components.
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
    public class DrawableMiyagiKeyCard : DrawableGameComponent
    {
        // Attributes

        public DrawableGameShape ShapeGamePiece;

        public DrawableGameMathExpression MathExpressionGamePiece;

        public DrawableGameMathExpression Math2;

        SpriteBatch spriteBatch;
        Texture2D backgroundRect;

        // Operations

        /// <summary>
        /// Update the positions of each the ShapeGamePiece and the MathExpressionGamePiece so that one is stacked on top of the other.
        /// 
        /// Implementation Details:
        /// 
        /// When the mouse cursor is over either the top or bottom game piece (ShapeGamePiece and the MathExpressionGamePiece), then IsTargeted should be set to true for both of these objects.  The same goes for "IsSelected."  If one is selected, then both objects should be selected.  
        /// 
        /// When both ShapeGamePiece and MathExpressionGamePiece are enlarged, then position them so that the line of contact between them is positioned so that after both shapes are enlarged, The top block is shift up and the bottom is shifted down so that the top and bottom block make contact at the same location.
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public void Update(GameTime time)
        {   

            int mouseX = Mouse.GetState().X;
            int mouseY = Mouse.GetState().Y;
            int mathBlockWidthBorder = (int)MathExpressionGamePiece.GetPositionWithRespectToViewPort().X+MathExpressionGamePiece.GetWidth();
            int mathBlockHeightBorder = (int)MathExpressionGamePiece.GetPositionWithRespectToViewPort().Y + MathExpressionGamePiece.GetHeight();
            int shapeBlockWidthBorder = (int)ShapeGamePiece.GetPositionWithRespectToViewPort().X + ShapeGamePiece.GetWidth();
            int shapeBlockHeightBorder = (int)ShapeGamePiece.GetPositionWithRespectToViewPort().X + ShapeGamePiece.GetHeight();
           
            //If mouse is over one, set both to true.
            //Mouse has to be between block's x and width, or
            //between block's y and height.

            if(((MathExpressionGamePiece.GetPositionWithRespectToViewPort().X <= mouseX)
                && (mouseX <= mathBlockWidthBorder)))
            {
                MathExpressionGamePiece.IsSelected = true;
                MathExpressionGamePiece.IsTargeted = true;
               ShapeGamePiece.IsSelected = true;
                ShapeGamePiece.IsTargeted = true;
            }
            else if (((MathExpressionGamePiece.GetPositionWithRespectToViewPort().Y <= mouseY)
                && (mouseY <= mathBlockHeightBorder)))
            {
                MathExpressionGamePiece.IsSelected = true;
                MathExpressionGamePiece.IsTargeted = true;
                  ShapeGamePiece.IsSelected = true;
                ShapeGamePiece.IsTargeted = true;
            }
            else if (((ShapeGamePiece.GetPositionWithRespectToViewPort().X <= mouseX)
            && (mouseX <= shapeBlockWidthBorder)))
            {
                MathExpressionGamePiece.IsSelected = true;
                MathExpressionGamePiece.IsTargeted = true;
                  ShapeGamePiece.IsSelected = true;
                ShapeGamePiece.IsTargeted = true;
            }
            else if (((ShapeGamePiece.GetPositionWithRespectToViewPort().Y <= mouseY)
            && (mouseY <= shapeBlockHeightBorder)))
            {
                MathExpressionGamePiece.IsSelected = true;
                MathExpressionGamePiece.IsTargeted = true;
                  ShapeGamePiece.IsSelected = true;
                ShapeGamePiece.IsTargeted = true;
            }
            else
            {
                MathExpressionGamePiece.IsSelected = false;
                MathExpressionGamePiece.IsTargeted = false;
                  ShapeGamePiece.IsSelected = false;
                ShapeGamePiece.IsTargeted = false;
            }
            MathExpressionGamePiece.SetPosition(ShapeGamePiece.GetPosition().X, 
                (ShapeGamePiece.GetPosition().Y + ShapeGamePiece.GetHeight()), 0);
        }

        /// <summary>
        /// No need to call this method.  
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public void Draw(GameTime time)
        {
            base.Draw(time);
        }

        /// <summary>
        /// Implementation details:
        /// 
        /// Add this object, and the ShapeGamePiece and MathExpressionGamePiece to the collection of game componets.  
        /// </summary>
        /// <param name="game">
        /// The game object from the client program.
        /// 
        /// Implementation details:
        /// 
        /// Hint, if the client program is a game, you would pass "this" for this argument. 
        /// </param>
        /// <param name="nameOfShape">
        /// A math expression that will be drawn adjacent to the shape on top of the image of this object.  For example, "-A".
        /// </param>
        /// <param name="mathExpression">
        /// The width in pixels of this image on the screen.
        /// </param>
        /// <param name="widthOfThisKeyBlock">
        /// The height (in pixels) of the image that this object represents
        /// </param>
        /// <param name="heightOfThisKeyBlock">
        /// The x-coordinate where this image will be drawn on the screen.
        /// </param>
        /// <param name="xPos">
        /// The Y position of this object on the screen.
        /// </param>
        /// <param name="yPos">
        /// The z-coordinate (in pixels) where this object will be drawn on the screen.
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public DrawableMiyagiKeyCard(Game game, string nameOfShape, string mathExpression, int widthOfThisKeyBlock, 
            int heightOfThisKeyBlock, float xPos, float yPos, float zPos)
            :base(game)
        {
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            game.Components.Add(this);
        }

        /// <summary>
        /// Implementation Details:  
        /// This method can be empty since the ShapeKey and MathExpressionGamePiece loads their own content.
        /// 
        /// Make sure you prefix this declaration with "protected override void LoadContent()."
        /// 
        /// </summary>
        /// <returns>
        /// </returns>
        protected override void LoadContent()
        {
            backgroundRect = Game.Content.Load<Texture2D>("MovingCircle");


        }

        /// <summary>
        /// Sets the position of the top left corner of this key card.
        /// </summary>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public void SetPosition(float xPos, float yPos, float zPos)
        {
            ShapeGamePiece.SetPosition(xPos,yPos,zPos);
        }

        /// <summary>
        /// Sets the size of this KeyCard.
        /// 
        /// Implementation details:
        /// Remember that this class is built from two smaller visual components (the DrawableGameShape and the MathExpressionGamePiece).   So the height of the individual ShapeGamePiece and MathExpressionGamePiece should be half the height of the DrawableMiyagiKeyCard.
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// </param>
        /// <param name="heightOfThisBlock">
        /// </param>
        /// <returns>
        /// </returns>
        public void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {
            ShapeGamePiece.SetSize(widthOfThisBlock / 2, heightOfThisBlock / 2);
            MathExpressionGamePiece.SetPosition(ShapeGamePiece.GetPosition().X, (ShapeGamePiece.GetPosition().Y + ShapeGamePiece.GetHeight()), 0);
            MathExpressionGamePiece.SetSize(widthOfThisBlock / 2, heightOfThisBlock / 2);
        }
    } /* end class DrawableMiyagiKeyCard */
}