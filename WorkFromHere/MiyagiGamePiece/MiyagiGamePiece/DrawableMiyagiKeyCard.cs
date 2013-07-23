// FILE: C:/Users/ginga/Desktop//DrawableMiyagiKeyCard.cs

using Microsoft.Xna.Framework;

/// <summary>
 /// </summary>
/// <summary>
    /// The client program should add an instance of this class to the list of game components.
     /// </summary>
     ///
namespace HumanStorm.Miyagi.Framework
{

    public class DrawableMiyagiKeyCard : DrawableGameComponent
    {
        // Attributes

        //public DrawableGamePiece ShapeGamePiece;

        //public DrawableGamePiece MathExpressionGamePiece;

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
        public override void Update(GameTime time)
        {
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D0A begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D0A end

        }

        /// <summary>
        /// No need to call this method.  
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public override void Draw(GameTime time)
        {
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D0C begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D0C end

        }

        /// <summary>
        /// Implementation details:
        /// 
        /// Add this object, and the ShapeGamePiece and MathExpressionGamePiece to the collection of game componets.  
        /// </summary>
        /// <param name="game">
        /// This should be name of the file that stores the image for this shape.
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
        public DrawableMiyagiKeyCard(Game game, string nameOfShape, string mathExpression, int widthOfThisKeyBlock, int heightOfThisKeyBlock, float xPos, float yPos, float zPos) 
            : base(game)
        {
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D13 begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D13 end

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
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D29 begin
            // section 10-0-0-8-5845b79f:13f0ba8d3fc:-8000:0000000000000D29 end

        }
    } /* end class DrawableMiyagiKeyCard */
}