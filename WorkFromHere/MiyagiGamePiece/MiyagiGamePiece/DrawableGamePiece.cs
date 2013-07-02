// FILE: C:/Users/ginga/Desktop//DrawableGamePiece.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;




// In this section you can add your own using directives
    // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000C8F begin
    // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000C8F end

/// <summary>
    /// This is the XNA framework specific derived class.
     /// </summary>
     /// 
namespace HumanStorm.Miyagi.Framework
{

    public class DrawableGamePiece : BaseGamePiece
    {
        // Attributes

        public Texture2D TextureForShape;

        public Color ColorOfShapeAndMathExpression;

        public Rectangle RectangleEnclosingThisImage;

        public SpriteFont Font;

        public Rectangle RectangleContainingThisObject;

        public SpriteBatch SharedSpriteBatch;

        public Rectangle ViewPort;

        // Operations

        /// <summary>
        /// nameOfShape corresponds to the name of the image to load for the TextureForShape member.
        /// 
        /// mathExpression is the math expression (i.e., "-A") to display on the key-block.
        /// </summary>
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
        public DrawableGamePiece(string contentToDraw, bool isContentToDrawAMathExpression, int widthOfThisGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos)
            : base(contentToDraw, isContentToDrawAMathExpression, widthOfThisGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CA1 begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CA1 end

        }

        /// <summary>
        /// Draws the key-block on the screen.  If IsTargeted is set to true, then the image drawn is scaled such that its width and height is now multplied by SCALE_FACTOR.  Otherwise, the image is drawn at its regular size specified by Width and Height.
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
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CAA begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CAA end

        }

        /// <summary>
        /// Checks to determine if the input device is currently hovering over the image that this object displays.  This also updates the position of this object as well as 
        /// 
        /// Implementation details:  If the input device is hovering over the image contained by this object, then set IsTargeted to true, otherwise false.  
        /// 
        /// Add logic to determine if "IsSelected" should be set to true or false depending on the interaction technique chosen.  For example, if using the mouse then check to see if the mouse button is pressed over this object.
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
            // section -64--88-56-1--5923b67a:13f818d274c:-8000:0000000000000B27 begin
            // section -64--88-56-1--5923b67a:13f818d274c:-8000:0000000000000B27 end

        }

        /// <summary>
        /// Updates the position of the top left hand corner of this DrawableGamePiece as it is displayed on the screen With Respect To (WRT) the Viewport.  
        /// 
        /// The GamePiece is not allowed to leave the boundary of the ViewPort.  The Position is constrained so that no part of the GamePiece is outside the View Port.
        /// *********************
        /// Implementation details:  This method should override the SetPosition provided by the parent class.  This is how you override a method http://msdn.microsoft.com/en-us/library/ebca9ah3.aspx.
        /// In this method, just adjust the position of RectangleEnclosingThisImage with the parameters xPos & yPos.  Then update the "Position" from the parent class with the same value of xPos and yPos and zPos (which should be zero) passed to this method.
        /// 
        /// Also this is With Respect to the ViewPort.  To accomplish this, whatever xPos, yPos is, just add the coordinates of the top left corner of the RectangleContainingThisObject to the xPos, and yPos, and then set the coordinates coordinates everywhere else.
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
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AD6 begin
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AD6 end

        }

        /// <summary>
        /// Sets the width and height of this image, in pixels, as it is drawn on the screen.
        /// 
        /// Implementation Details:  Set the parent Width and Height to the width and height parameters passed here.  Set the parent Width and Height.  Then reset the Width and Height of RectangleContainingThisObject to the with and height input into this method.
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// </param>
        /// <param name="heightOfThisBlock">
        /// </param>
        /// <returns>
        /// </returns>
        public override void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AE1 begin
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AE1 end

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
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AF6 begin
            // section -64--88-56-1-72ba4d10:13f9ac2df4c:-8000:0000000000000AF6 end

        }

        /// <summary>
        /// Returns the current Position of the Mouse Cursor.
        /// </summary>
        /// <returns>
        /// </returns>
        public Vector3 GetScreenCoordinatesOfMouse()
        {
            return new Vector3();

        }

        /// <summary>
        /// Returns the absolute position of the top left corner of this DrawableGamePiece with respect to the top left-corner of the Graphics Display device.
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