// FILE: C:/Users/ginga/Desktop//BaseGamePiece.cs


/// <summary>
    /// This is the base class for creating a node that draws a key-block on the screen.  The idea is that this base class should be framework-independent.  To draw this KeyBlock on the the screen for a specific framework, just create a class(es) that is derived from this class and add the details needed for that specific framework.
     /// </summary>
     /// 
namespace HumanStorm.Miyagi.Framework
{

    public class BaseGamePiece
    {
        // Attributes

        public string NameOfShape;

        public string MathExpressionToDisplay;

        protected int Width;

        protected int Height;

        public bool IsTargeted;

        public float SCALE_FACTOR = 1.2f;

        protected MPoint3D Position;

        public bool IsMathExpression;

        public bool IsSelected;

        // Associations

        /// <summary> 
        /// </summary>
       //public ArrayList assignedPoint;

        // Operations

        /// <summary>
        /// This is either a math expression, or the name of the image file to draw.
        /// </summary>
        /// <param name="contentToDraw">
        /// This either the name of the image file (without a file extension), or a math expression.
        /// </param>
        /// <param name="isContentToDrawAMathExpression">
        /// If this is set to true, then the contentToDraw is a math expression.  Otherwise, it is the name of an image file included for this project.
        /// </param>
        /// <param name="widthOfThisGamePiece">
        /// The width of the container rectangle of this game piece.
        /// </param>
        /// <param name="heightOfGamePiece">
        /// The height of the rectangle enclosing this game-piece.
        /// </param>
        /// <param name="xPos">
        /// The x-coordinate of the top left corner of this GamePiece displayed on the screen.
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public BaseGamePiece(string contentToDraw, bool isContentToDrawAMathExpression, int widthOfThisGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos)
        {
           
        }

        /// <summary>
        ///  An operation that does...
        /// 
        ///  @param firstParam a description of this parameter
        /// </summary>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual void SetPosition(float xPos, float yPos, float zPos)
        {
         

        }

        /// <summary>
        /// Sets the width and height of this image, in pixels, as it is drawn on the screen.
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// </param>
        /// <param name="heightOfThisBlock">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {
          

        }

        /// <summary>
        /// Returns the Width of this object.  If IsTargeted is set to true, then
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWidth()
        {
            return Width;
        }

        /// <summary>
        /// Returns the height of the image to be drawn that represents that this object represents.  If IsTargeted is true, then the width is scaled by the SCALE_FACTOR.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetHeight()
        {
            return Height;
        }

        /// <summary>
        /// Returns the position of this object.
        /// 
        /// Implemenation Details:  declare this virtual (i.e., "public virtual MPoint3D GetPosition")
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual MPoint3D GetPosition()
        {
            return Position;

        }
    } /* end class BaseGamePiece */
}