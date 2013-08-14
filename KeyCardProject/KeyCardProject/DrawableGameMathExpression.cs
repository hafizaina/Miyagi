using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
/// <summary>
///  A class that represents a DrawableGameMathExpression object.
/// </summary>


namespace HumanStorm.Miyagi.Framework
{
    public class DrawableGameMathExpression : BaseDrawableGamePiece
    {
        // Attributes
        /// <summary>
        /// The ContentManager object associated with the game that this object is part of.
        /// </summary>
        private ContentManager contentForGame;

        /// <summary>
        /// The math expression to be drawn on the key-block.
        /// </summary>
        public String MathExpression;

        /// <summary>
        /// This boolean prevents LoadContent from being called more than once. It is set to false once in the constructor, and then
        /// it is set to true in the Draw() method once it needs to be called. Successive calls to Draw() will prevent LoadContent()
        /// from being called more than once.
        /// </summary>
        private bool hasLoadContentBeenCalled;

        /// <summary>
        /// Spritefont object pulled from the ContentManager. This allows the font to not be an issue in object instantiation, only becoming
        /// needed once Draw() is called.
        /// </summary>
        private SpriteFont Font;
        
        /// <summary>
        /// The scale factor needed to make sure the math expression letters are a good portion of the key-block it exists on.
        /// </summary>
        public float ScaleFactor;


        /// <summary>
        /// A constant variable that corresponds to the percentage of how much space the math expression takes up on the keycard.
        /// </summary>
        private const float PERCENTAGE_SIZE_OF_MATH_EXPRESSION_RECTANGLE_TO_MAKE_SIZE_OF_MATH_EXPRESSION = .55f;

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
        /// The viewport (or 2D rectangle) that this object will be drawn inside of..  This viewport simulates a viewiing window just 
        /// for this graphical image to display.  If this object is displayed outside this rectangle, then it will not be displayed.
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
        public DrawableGameMathExpression(Texture2D backgroundRectColor, SpriteBatch sharedSprite, ContentManager gameContent,
            Color colorOfExpression, Rectangle viewPort, String mathExpression, int widthOfThisGamePiece, int heightOfGamePiece,
            float xPos, float yPos, float zPos)
            : base(backgroundRectColor, colorOfExpression, sharedSprite,
                viewPort, widthOfThisGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {

            //Regular Expression pattern to disallow the user from putting in more than one letter or more than one (-) sign 
            //in the expression.
            //It does allow for upper-case and lower-case letters.
            String regularExpressionPattern = @"^-?(?i)[A-Z]\z";
            
            this.hasLoadContentBeenCalled = false;
            
            this.contentForGame = gameContent;

            if ((System.Text.RegularExpressions.Regex.IsMatch(mathExpression, regularExpressionPattern) == true))
            {
                this.MathExpression = mathExpression;
            }

            else
            {
                throw new System.ArgumentException("This math expression must be a single-letter variable that is positive or negative.");
            }

        }

        /// <summary>
        /// This method draws the given math expression onto the game screen and loads the content needed to do so if it has not been
        /// called already.
        /// </summary>
        /// <param name="time"></param>
        public override void Draw(GameTime time)
        {
            if (this.hasLoadContentBeenCalled == false)
            {

                this.LoadContent();
                hasLoadContentBeenCalled = true;
            }
            this.SharedSpriteBatch.Draw(backgroundRectangle, RectangleEnclosingThisObject, Color.Red);

            this.SharedSpriteBatch.DrawString(this.Font, this.MathExpression, this.SetMathExpressionPositionAndScale(), Color.Blue, 0.0f,
                new Vector2(0, 0), ScaleFactor, new SpriteEffects(), 0.0f);
        }

        /// <summary>
        /// This method is to set the letter, no matter its size, to the absolute center of the keycard. It also takes into account
        /// the size of the letter being drawn on the screen.
        /// </summary>
        /// <returns></returns>
        public Vector2 SetMathExpressionPositionAndScale()
        {
            Vector2 letterSize = Font.MeasureString(this.MathExpression);

            ScaleFactor = (PERCENTAGE_SIZE_OF_MATH_EXPRESSION_RECTANGLE_TO_MAKE_SIZE_OF_MATH_EXPRESSION *
                this.RectangleEnclosingThisObject.Width) / letterSize.X;

            Vector2 actualSizeDrawnOnScreen = Vector2.Multiply(letterSize, ScaleFactor);

            float xPos = this.RectangleEnclosingThisObject.X + (this.RectangleEnclosingThisObject.Width / 2) -
                ((actualSizeDrawnOnScreen.X) / 2);

            float yPos = this.RectangleEnclosingThisObject.Y + (this.RectangleEnclosingThisObject.Height / 2) -
                ((actualSizeDrawnOnScreen.Y) / 2);

            return new Vector2(xPos, yPos);
        }

        /// <summary>
        /// This update method covers the expansion and shrinkage of the keycard only.
        /// </summary>
        /// <param name="time"></param>
        public override void Update(GameTime time)
        {


            #region LogicToCoverScalingRectangleFromCenter

            if (this.RectangleEnclosingThisObject.Contains((int)this.GetScreenCoordinatesOfMouse().X,
                (int)this.GetScreenCoordinatesOfMouse().Y))
            {

                //if the mouse hovers over the rectangle, expand the rectangle to scaled size from its center.


                Vector2 originalRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                this.IsSelected = true;
                this.IsTargeted = true;

                Vector2 scaledRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                Vector2 displacement = Vector2.Subtract(scaledRectangleCenter, originalRectangleCenter);

                this.SetPosition(this.Position.X - displacement.X, this.Position.Y - displacement.Y);
            }

            #endregion LogicToCoverScalingRectangleFromCenter

            #region LogicToCoverDescalingRectangleFromCenter

            else
            {

                //But if not, draw the original rectangle on the screen and de-scale it from the center.

                Vector2 scaledRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                this.IsSelected = false;
                this.IsTargeted = false;

                Vector2 originalRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                Vector2 displacement = Vector2.Subtract(originalRectangleCenter, scaledRectangleCenter);

                this.SetPosition(this.Position.X - displacement.X, this.Position.Y - displacement.Y);
            }

            #endregion LogicToCoverDescalingRectangleFromCenter
        }


        /// <summary>
        /// This method was implemented in order to allow us to create a MathExpression object and be able to instantiate it in our unit
        /// tests. It was needed because we could not access the Spritefont file from outside our game class, nor could we
        /// get an outside GraphicsDevice to instantiate. (8/14/2013)
        /// </summary>
        private void LoadContent()
        {
            Font = contentForGame.Load<SpriteFont>("Spritey");
        }
    }
}