
//THINGS THAT CAUGHT MY ATTENTION:
// 1. nameOfShape is being plugged in as a parameter, though it does not get assigned to any variable.
// 2. the rectangle variables require ints for position. xpos and ypos are floats.
// 3. I have no idea what to do with viewport.
// 4. SharedSpriteBatch is not being assigned correctly.
// 5. Questions about all methods.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

/// <summary>
/// This class Returns the absolute position of the top left corner of this DrawableGamePiece with 
/// respect to the top left-corner of the Graphics Display device.
/// </summary>
/// 
namespace HumanStorm.Miyagi.Framework
{

    public class DrawableGamePiece : BaseGamePiece
    {

        //Attributes

        /// <summary>
        /// The invisible rectangle enclosing this image.  Adjusting the size and position of this rectangle. 
        ///Implementation Details:  The size and the position of this Rectangle stores the size and position of the image.  
        ///So to change the size of the image, change the size of the rectangle.  And to change position of the image, 
        ///change the position of the rectangle.
        /// </summary>
        public Rectangle RectangleEnclosingThisObject;

        /// <summary>
        /// The rectangle that encloses the image drawn on the screen representing a game piece.
        ///Implementation Details:  This is the variable that should have it's position updated and size updated.  
        ///this.RectangleEnclosingThisImage just 
        ///returns a new rectangle whose values are taken from 
        ///the width, height, and position of this variable.
        /// </summary>
        public Rectangle RectangleContainingThisObject;

        /// <summary>
        /// The SpriteBatch to handle drawing on the display device.
        ///Implementation Details:  The constructor should initialize this variable as 
        ///this.SharedSpriteBatch = (SpriteBatch)this.Game.Services.GetService(typeof(SpriteBatch));
        ///This comes from http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.game.services.aspx.
        /// </summary>
        public SpriteBatch SharedSpriteBatch;

        /// <summary>
        /// Returns the Rectangle that represents the ViewPort to display this object in.
        ///Implementation Details:  Just declare this as a property and let the getter return.
        ///(Rectangle)this.Game.Services.GetService(typeof(Rectangle));
        /// </summary>
        public Rectangle ViewPort;

        /// <summary>
        ///The color of the shape, and the color of the math expression, to be drawn on the screen.
        /// </summary>
        public Color ColorOfShape;

        /// <param name="contentToDraw">
        /// </param>
        /// <param name="isContentToDrawAMathExpression">
        /// </param>
        /// <param name="widthOfThisGamePiece">
        /// </param>
        /// <param name="heightOfGamePiece">
        /// </param>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// The y-coordinate of the top left-hand corner of this GamePiece when it is displayed on the screen.
        /// </param>
        /// <param name="zPos">
        /// The z-coordinate of the top left corner of this game-piece when it is displayed on the screen.
        /// </param>
        /// <returns>
        /// </returns>
        public DrawableGamePiece(Color colorOfGamePiece, SpriteBatch sharedSprite, string nameOfShape, int widthOfThisGamePiece, int
            heightOfGamePiece, float xPos, float yPos, float zPos)
            : base
                (widthOfThisGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {

            this.ColorOfShape = colorOfGamePiece;
            this.RectangleEnclosingThisObject = new Rectangle(0, 0, this.Width, this.Height);
            this.RectangleContainingThisObject = new Rectangle(0, 0, this.Width, this.Height);
            //------------------------ ATTTTTTTTTENNNNNNNNNNNNNNNNNNNNNTTTTTTTTTIIIIIIIIIOOOOOOOONNNNNNNNNN-------------------
            // XPOS AND YPOS DATA TYPES ARE FLOATS. RECTANGLE CONSTRUCTOR ONLY ACCEPTS INTS.
            //GREAT SUGGESTION WOULD BE TO REPLACE RECTANGLE DATA TYPE WITH RECT STRUCTURE DATA TYPE(RECT TAKES DOUBLES AS PARAMETERS).
            //this.RectangleEnclosingThisObject = new Rect(xPos, yPos, this.Width, this.Height);
            //THIS WOULD ALLOW MOVEMENT AS SPECIFIED IN IMPLEMENTATION.
            //STILL DO NOT KNOW HOW TO USE THIS CLASS, THOUGH.
            //-----------------------------------------------------------------------------------------------------------


            this.SharedSpriteBatch = (SpriteBatch)this.Game.Services.GetService(typeof(SpriteBatch));
        }

        /// <summary>
        /// Draws the key-block on the screen.  If IsTargeted is set to true, then the image drawn is scaled such that its width and height 
        /// is now multplied by SCALE_FACTOR.  Otherwise, the image is drawn at its regular size specified by Width and Height.
        /// 
        /// Width - The width of the key-block
        /// Height - The height of the key-block.
        /// xPos - The x-position of the left corner of the key-block.
        /// yPos - The y-position of the left corner of the key-block.
        /// 
        /// Implementation details:  Draw the way you normally would draw in XNA but for the SpriteBatch, use this.SharedSpriteBatch.
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public void Draw(GameTime time)
        {
            if (IsTargeted == true)
            {
                //Draw the game piece with width and height affected by scale-factor. Does this mean make a new rectangle with specs
                //multiplied by scale factor?
            }
            else
            {
                //leave it as is?
            }
        }

        /// <summary>
        /// Checks to determine if the input device is currently hovering over the image that this object displays.  This also updates 
        /// the position of this object as well as 
        /// 
        /// Implementation details:  If the input device is hovering over the image contained by this object, then set 
        /// IsTargeted to true, otherwise false.  
        /// 
        /// Add logic to determine if "IsSelected" should be set to true or false depending on the interaction technique chosen.  
        /// For example, if using the mouse then check to see if the mouse button is pressed over this object.
        /// 
        /// 
        /// This also updates the Position of this object as well as Size.  The Position gets updated only if IsSelected is set to true.
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public void Update(GameTime time)
        {

        }

        /// <summary>
        /// Updates the position of the top left hand corner of this DrawableGamePiece as it is displayed on the screen
        /// With Respect To (WRT) the Viewport.  
        /// 
        /// The GamePiece is not allowed to leave the boundary of the ViewPort.  The Position is constrained so that no 
        /// part of the GamePiece is outside the View Port.
        /// *********************
        /// Implementation details:  This method should override the SetPosition provided by the parent class.  This is how you 
        /// override a method http://msdn.microsoft.com/en-us/library/ebca9ah3.aspx.
        /// In this method, just adjust the position of RectangleEnclosingThisImage with the parameters xPos & yPos.  Then update the 
        /// "Position" from the parent class with the same value of xPos and yPos and zPos (which should be zero) passed to this method.
        /// 
        /// Also this is With Respect to the ViewPort.  To accomplish this, whatever xPos, yPos is, just add the coordinates of 
        /// the top left corner of the RectangleContainingThisObject to the xPos, and yPos, and then set the coordinates 
        /// coordinates everywhere else.
        /// 
        /// </summary>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public override void SetPosition(float xPos, float yPos, float zPos)
        {
            base.SetPosition(xPos, yPos, zPos);
        }

        /// <summary>
        /// Sets the width and height of this image, in pixels, as it is drawn on the screen.
        /// 
        /// Implementation Details:  Set the parent Width and Height to the width and height parameters passed here.  
        /// Set the parent Width and Height.  Then reset the Width and Height of RectangleContainingThisObject to the 
        /// with and height input into this method.
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// </param>
        /// <param name="heightOfThisBlock">
        /// </param>
        /// <returns>
        /// </returns>
        public override void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {
            base.SetSize(widthOfThisBlock, heightOfThisBlock);
            this.RectangleContainingThisObject.Width = widthOfThisBlock;
            this.RectangleContainingThisObject.Height = heightOfThisBlock;
        }

        /// <summary>
        /// Loads the content for this game component.
        /// 
        /// Implementation details:
        /// 
        /// Must declare this as "public override void LoadContent()"
        /// </summary>
        /// <returns>
        /// </returns>
        protected void LoadContent()
        {
        }

        /// <summary>
        /// Returns the current Position of the Mouse Cursor.
        /// </summary>
        /// <returns>
        /// </returns>
        public Vector3 GetScreenCoordinatesOfMouse()
        {
            Vector3 mouseState = new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0);
            return mouseState;
        }

        /// <summary>
        /// Returns the absolute position of the top left corner of this DrawableGamePiece with respect to the top left-corner 
        /// of the Graphics Display device.
        /// </summary>
        /// <returns>
        /// </returns>
        public Vector3 GetPositionWithRespectToViewPort()
        {
            return new Vector3();

        }

        /// <summary>
        /// Returns the position of this DrawableGamePiece With Respect To the top left corner of the ViewPort.
        /// 
        /// Implementation Details.
        /// </summary>
        /// <returns>
        /// </returns>
        public override MPoint3D GetPosition()
        {
            return base.GetPosition();
        }
    } /* end class DrawableGamePiece */
}