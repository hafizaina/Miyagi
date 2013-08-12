
/// <summary>
/// This is the base class for creating a node that draws a key-block on the screen.  The idea is that this base class should be 
/// framework-independent.  To draw this KeyBlock on the the screen for a specific framework, just create a class(es) that is derived 
/// from this class and add the details needed for that specific framework.
/// </summary>
/// 
namespace HumanStorm.Miyagi.Framework
{

    public class BaseGamePiece
    {
        // Attributes

        /// <summary>
        /// The width of this block.
        /// </summary>
        protected int Width;

        /// <summary>
        /// The height of this key-block.
        /// </summary>
        protected int Height;

        /// <summary>
        /// The original Width provided before scaling.  
        /// </summary>
        /// <remarks>
        /// When <see cref="this.IsTargeted"/> is set to true, the width is scaled by <see cref=" SCALE_FACTOR"/> so
        /// <see cref="this.GetWidth()"/> does not always return the original size that was last set via <see cref="this.SetSize"/>.  
        /// <para>
        /// This property just returns the original Width that was set (before scaling).
        /// </para>
        /// </remarks>
        public int WidthBeforeScaling
        {
            get { return this.Width; }
        }

        /// <summary>
        /// The original Height provided before scaling.
        /// </summary>
        /// <remarks>
        /// When <see cref="this.IsTargeted"/> is set to true, the height is scaled by <see cref=" SCALE_FACTOR"/> so
        /// <see cref="this.GetHeight()"/> does not always return the original size that was last set via <see cref="this.SetSize"/>.  
        /// <para>
        /// This property just returns the original Height that was set (before scaling).
        /// </para>
        /// </remarks>
        public int HeightBeforeScaling
        {
            get { return this.Height; }
        }

        /// <summary>
        /// If this is set to true, then the size of the image is enlarged such that the resulting size is the original size 
        /// MULTIPLIED by the SCALE_FACTOR.  For example, if SCALE_FACTOR = 1.2f, then the width and height will both be multiplied
        /// by 1.2f.
        /// </summary>
        public bool IsTargeted;

        /// <summary>
        /// The factor to multiply the Width and the Height by in order 
        /// make the image enlarge when the input device (i.e., mouse cursor) is hovering over the shape.
        /// </summary>
        public float SCALE_FACTOR = 1.2f;

        /// <summary>
        /// Stores the position of the block.
        /// </summary>
        protected MPoint3D Position;

        /// <summary>
        /// True if the current object is selected, and false otherwise.
        /// </summary>
        public bool IsSelected;

        // Associations


        // Operations

        /// <summary>
        /// This is either a math expression, or the name of the image file to draw.
        /// </summary>
        /// <param name="contentToDraw">
        /// This either the name of the image file (without a file extension), or a math expression.
        /// </param>
        /// <param name="isContentToDrawAMathExpression">
        /// If this is set to true, then the contentToDraw is a math expression.  Otherwise, it is the name of an image 
        /// file included for this project.
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
        /// The y-coordinate of the top left corner of this GamePiece displayed on the screen.
        /// </param>
        /// <param name="zPos">
        /// The z-coordinate of the top left corner of this GamePiece displayed on the screen.
        /// </param>
        /// <returns>
        /// </returns>
        public BaseGamePiece(int widthOfThisGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos)
        {
            this.Position = new MPoint3D(xPos, yPos, zPos);

            if ((widthOfThisGamePiece <= 0) || (heightOfGamePiece <= 0))
            {
                throw new System.ArgumentException("Height or Width of block cannot be less than 0.");
            }

            this.Width = widthOfThisGamePiece;
            this.Height = heightOfGamePiece;
        }

        /// <summary>
        ///  An operation that sets the position of the block.
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
            this.Position = new MPoint3D(xPos, yPos, zPos);

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

            if ((widthOfThisBlock <= 0) || (heightOfThisBlock <= 0))
            {
                throw new System.ArgumentException("Height or Width of block cannot be less than 0.");
            }

            this.Width = widthOfThisBlock;
            this.Height = heightOfThisBlock;

        }

        /// <summary>
        /// Returns the Width of this object.  If IsTargeted is set to true, then the returned width should be multiplied by the SCALE_FACTOR.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWidth()
        {
            float widthOfBlock;
            if (this.IsTargeted == true)
            {
                widthOfBlock = this.Width * SCALE_FACTOR;
            }
            else
            {

                widthOfBlock = this.Width;
            }
            return (int)widthOfBlock;
        }

        /// <summary>
        /// Returns the height of the image to be drawn that represents that this object represents.  If IsTargeted is true, 
        /// then the height is scaled by the SCALE_FACTOR.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetHeight()
        {
            float heightOfBlock;
            if (this.IsTargeted == true)
            {

                heightOfBlock = this.Height * SCALE_FACTOR;
            }
            else
            {
                heightOfBlock = this.Height;
            }
            return (int)heightOfBlock;
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
            return this.Position;

        }


    } /* end class BaseGamePiece */
}