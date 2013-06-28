// FILE: C:/Users/Delante/Desktop/GitHub Dev/BaseGraphicalMiyagiKeycardClass//BaseGraphicalMiyagiKeyCard.cs

// In this section you can add your own using directives
// section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CB6 begin
// section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000CB6 end

/// <summary>
/// This is the base class for creating a node that draws a key-block on the screen.  The idea is that this base class should be framework-independent.  To draw this KeyBlock on the the screen for a specific framework, just create a class(es) that is derived from this class and add the details needed for that specific framework.
/// </summary>

using System.Collections;

namespace HumanStorm.Miyagi.Framework
{
    //TODO change this class name to foo
    public class BaseGraphicalMiyagiKeyCard
    {
        // Attributes

        /// <summary>
        /// Describes the name of the shape to be drawn on the screen.
        /// </summary>
        private string NameOfShape;
        /// <summary>
        /// The expression to display adjacent to the shape (i.e., "-A").
        /// </summary>
        private string MathExpressionToDisplay;
        /// <summary>
        /// The width of this block.
        /// </summary>
        protected int Width;
        /// <summary>
        /// The height of this key-block
        /// </summary>
        protected int Height;
        /// <summary>
        /// If this is set to true, then the size of the image is enlarged such that the
        /// resulting size is the original size MULTIPLIED by the SCALE_FACTOR.  
        /// For example, if SCALE_FACTOR = 1.2f
        /// </summary>
        public bool IsTargeted;
        /// <summary>
        /// The factor to multiply the Width and the Height by in order make the image 
        /// enlarge when the input device (i.e., mouse cursor) is hovering over the shape.
        /// </summary>
        public float SCALE_FACTOR = 1.2f;
        protected MPoint3D Position;

        // Associations

        /// <summary> 
        /// </summary>
        public ArrayList assignedPoint;

        // Operations

        /// <summary>
        ///  An operation that creates a new BaseGraphicalMiyagiKeyCard object.
        /// 
        ///  @param firstParam a description of this parameter
        /// </summary>
        /// <param name="nameOfShape">
        /// The name of the shape to display.
        /// </param>
        /// <param name="mathExpression">
        /// The expression to display adjacent to the shape (i.e., "-A").
        /// </param>
        /// <param name="widthOfThisKeyBlock">
        /// The width of this block.
        /// </param>
        /// <param name="heightOfThisKeyBlock">
        /// The height of this block.
        /// </param>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// BaseGraphicalMiyagiKeyCard.
        /// </returns>
        public BaseGraphicalMiyagiKeyCard(string nameOfShape, string mathExpression, int widthOfThisKeyBlock, int heightOfThisKeyBlock, float xPos, float yPos, float zPos)
        {
            this.NameOfShape = nameOfShape;
            this.MathExpressionToDisplay = mathExpression;
            this.Position = new MPoint3D(xPos, yPos, zPos);

            if((widthOfThisKeyBlock <= 0) || (heightOfThisKeyBlock <= 0)){
                throw new System.ArgumentException("Height or Width of block cannot be less than 0.");
            }
            this.Width = widthOfThisKeyBlock;
            this.Height = heightOfThisKeyBlock;
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
        public void SetPosition(float xPos, float yPos, float zPos)
        {
            this.Position = new MPoint3D(xPos, yPos, zPos);

        }

        /// <summary>
        ///  An operation that sets the size of the block.
        /// 
        ///  @param firstParam a description of this parameter
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// The width of this key-block.
        /// </param>
        /// <param name="heightOfThisBlock">
        /// The height of this key-block.
        /// </param>
        /// <returns>
        /// </returns>
        public void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {   

            // Exception implemented to ensure negative or 0 sizes are not allowed.
            if ((widthOfThisBlock <= 0) || (heightOfThisBlock <= 0))
            {
                throw new System.ArgumentException("Height or Width of block cannot be less than 0.");
            }
            this.Width = widthOfThisBlock;
            this.Height = heightOfThisBlock;

        }

        /// <summary>
        /// Returns the Width of this object.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWidth()
        {

            return this.Width;
        }

        /// <summary>
        /// Returns the height of the image to be drawn that represents that this object represents.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetHeight()
        {
            return this.Height;
        }

        public string GetNameOfShape()
        {
            return this.NameOfShape;
        }

        public string GetMathExpressionToDisplay()
        {
            return this.MathExpressionToDisplay;
        }


        /// <summary>
        /// Returns the position of this object.
        /// </summary>
        /// <returns>
        /// </returns>
        public MPoint3D GetPosition()
        {
            return this.Position;

        }
    } /* end class BaseGraphicalMiyagiKeyCard */
}