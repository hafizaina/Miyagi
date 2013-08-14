/// <summary>
///  A class that represents a DrawableGameMathExpression object.
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
    public class DrawableGameMathExpression : BaseDrawableGamePiece
    {
        // Attributes

        public SpriteFont Font;
        public String MathExpression;
        public Vector2 aligned;

        // Operations

        /// <summary>
        ///  An operation that does...
        /// 
        ///  @param firstParam a description of this parameter
        /// </summary>
        /// <param name="sharedSprite">
        /// This is the SpriteBatch from a client program that is used to draw objects onto a graphics display device.
        /// </param>
        /// <param name="colorOfExpression">
        /// The viewport (or 2D rectangle) that this object will be drawn inside of..  This viewport simulates a viewiing window just for this graphical image to display.  If this object is displayed outside this rectangle, then it will not be displayed.
        /// </param>
        /// <param name="viewPort">
        /// The math expression to display (i.e., "-A").
        /// </param>
        /// <param name="mathExpression">
        /// The width of this game piece.
        /// </param>
        /// <param name="widthOfThisGamePiece">
        /// The height of this game piece.
        /// </param>
        /// <param name="heightOfGamePiece">
        /// The x-coordinate of this math expression with respect to the viewport.
        /// </param>
        /// <param name="xPos">
        /// The y-coordinate of this math expression with respect to the viewport.
        /// </param>
        /// <param name="yPos">
        /// The z-coordinate of this math expression.
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public DrawableGameMathExpression(Texture2D backgroundRectColor,SpriteBatch sharedSprite, SpriteFont spriteFont, Color colorOfExpression, Rectangle viewPort, String mathExpression, int widthOfThisGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos)
            : base(backgroundRectColor,colorOfExpression, sharedSprite, viewPort, widthOfThisGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {

            String regularExpressionPattern = @"^-?(?i)[A-Z]\z";

            this.Font = spriteFont;

            if ((System.Text.RegularExpressions.Regex.IsMatch(mathExpression, regularExpressionPattern) == true))
            {
                this.MathExpression = mathExpression;
            }

            else
            {
                throw new System.ArgumentException("This math expression must be a single-letter variable that is positive or negative.");
            }

        }

        public override void Draw(GameTime time)
        {
            this.SharedSpriteBatch.Begin();
            this.SharedSpriteBatch.Draw(backgroundRectangle, ViewPort, Color.Green);
            this.SharedSpriteBatch.Draw(backgroundRectangle, RectangleEnclosingThisObject, Color.Red);
            this.SetMathExpressionPositionAndScale();
            this.SharedSpriteBatch.DrawString(this.Font, this.MathExpression, aligned, Color.Blue, 0.0f, new Vector2(0, 0), 1.0f, new SpriteEffects(), 0.0f);
            this.SharedSpriteBatch.End();
        }
        public void SetMathExpressionPositionAndScale()
        {
            Vector2 letterSize = Font.MeasureString(this.MathExpression);
            float xPos = this.RectangleEnclosingThisObject.X + (this.RectangleEnclosingThisObject.Width/2) - (letterSize.X/2);
            float yPos = this.RectangleEnclosingThisObject.Y + (this.RectangleEnclosingThisObject.Height/2) - (letterSize.Y/2);
            aligned = new Vector2(xPos, yPos);
            //This method is supposed to set two things.
            //1. A Vector3 that will store the pin-point position of the absolute center of the rectangle the letter displays on.
            //2. A float that will give and expand the letter by the scale factor of the rectangle. It has to be 90% of the rectangle,
            // while not going out of the boundaries of the rectangle.
        }


        public override void Update(GameTime time)
        {
        }
    }
}