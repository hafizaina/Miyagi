using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/// <summary>
/// The client program should add an instance of this class to the list of game components.
/// </summary>
/// 
namespace HumanStorm.Miyagi.Framework
{
    public class DrawableMiyagiKeyCard : DrawableGameComponent
    {
        // Attributes

        //   public DrawableGameShape ShapeGamePiece;

        //#########################################
        //Using temporary variable names to follow logic. CHANGE THESE NAMES BACK ACCORDING TO UML!!
        //##########################################
        /// <summary>
        /// Shape block connected to math expression block.
        /// </summary>
        public DrawableGameMathExpression LetterB;

        /// <summary>
        /// Math expression block connected to shape block.
        /// </summary>
        public DrawableGameMathExpression MathExpressionGamePiece;

        /// <summary>
        /// Boolean flag to decide whether the keyblock is being dragged across the screen.
        /// </summary>
        bool dragging = false;

        /// <summary>
        /// Spritebatch needed to instantiate the shape and math expression objects.
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// The previous state of the mouse while dragging is occuring.
        /// </summary>
        MouseState PrevMouseState;

        /// <summary>
        /// Boolean flag to tell if the user specifically clicks on the shape part of the miyagi keycard, and will allow
        /// expansion and dragging of the keyblock to happen accordingly.
        /// </summary>
        private bool LetterBWasClicked;

        /// <summary>
        /// Boolean flag to tell if the user specifically clicks on the math expression part of the miyagi keycard, and will allow
        /// expansion and dragging of the keyblock to happen accordingly.
        /// </summary>
        private bool MathExpressionGamePieceWasClicked;

        /// <summary>
        /// Boolean to tell whether the user left-mouseclicks on the current keycard object.
        /// </summary>
        public bool isSelected;
        // Operations

        /// <summary>
        /// Update the positions of each the ShapeGamePiece and the MathExpressionGamePiece so that one is stacked on top of the other.
        /// 
        /// Implementation Details:
        /// 
        /// When the mouse cursor is over either the top or bottom game piece (ShapeGamePiece and the MathExpressionGamePiece), 
        /// then IsTargeted should be set to true for both of these objects.  The same goes for "IsSelected."  If one is selected, 
        /// then both objects should be selected.  
        /// 
        /// When both ShapeGamePiece and MathExpressionGamePiece are enlarged, then position them so that the line of contact 
        /// between them is positioned so that after both shapes are enlarged, The top block is shift up and the bottom is shifted 
        /// down so that the top and bottom block make contact at the same location.
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public override void Update(GameTime time)
        {
            MathExpressionGamePiece.Update(time);
            LetterB.Update(time);
            LetterBWasClicked = false;
            MathExpressionGamePieceWasClicked = false;




            //###################################
            // LOGIC TO KEEP BLOCKS POSITIONED ONE OF TOP OF THE OTHER.
            //###################################
            // If the math expression is targeted, then the shape must also be targeted. Therefore,
            // the shape must be anchored below the math expression. This if-conditional allows for the shape
            // to always be anchored below the math expression.
            //Similarly, if the shape is targeted, then the math expression must also be targeted. Therefore,
            // the math expression must be anchored above the shape. This if-conditional allows for the math expression
            // to always be anchored above the shape.
            if (LetterB.IsTargeted == true)
            {

                MathExpressionGamePiece.IsTargeted = true;
                LetterBWasClicked = true;
                MathExpressionGamePieceWasClicked = false;

            }

            else if (MathExpressionGamePiece.IsTargeted == true)
            {

                LetterB.IsTargeted = true;
                MathExpressionGamePieceWasClicked = true;
                LetterBWasClicked = false;

            }

            #region MOUSE DRAG

            int xDisplacement = 0;
            int yDisplacement = 0;

            if (dragging == false)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (MathExpressionGamePiece.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y)
                        || LetterB.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        this.isSelected = true;
                        dragging = true;
                        // On initial click on object, record the mouse state.
                        MouseState currentMouseState = Mouse.GetState();
                        PrevMouseState = currentMouseState;
                    }
                }
            }
            else
            {
                // If dragging is true, keep updating currentMouseState
                this.isSelected = false;
                MouseState currentMouseState = Mouse.GetState();

                // If mouse position has moved, move keycard object by its displacement, and drag based on
                // which part of the keycard (the shape or the math expression) was grabbed specifically.
                if (PrevMouseState.X != currentMouseState.X || PrevMouseState.Y != currentMouseState.Y)
                {
                    xDisplacement = currentMouseState.X - PrevMouseState.X;
                    yDisplacement = currentMouseState.Y - PrevMouseState.Y;
                }

                if (MathExpressionGamePieceWasClicked == true)
                {
                    float xPos = MathExpressionGamePiece.GetPosition().X + xDisplacement;
                    float yPos = MathExpressionGamePiece.GetPosition().Y + yDisplacement;
                    MathExpressionGamePiece.SetPosition(xPos, yPos, 0f);
                }

                else if (LetterBWasClicked == true)
                {
                    float xPos = LetterB.GetPosition().X + xDisplacement;
                    float yPos = LetterB.GetPosition().Y + yDisplacement;
                    LetterB.SetPosition(xPos, yPos, 0f);
                }

                if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    dragging = false;
                }

                // Update placement variables (reset displacement back to 0)

                PrevMouseState = currentMouseState;
                xDisplacement = 0;
                yDisplacement = 0;
            }

            #endregion MOUSE DRAG

            this.SetPositionAuxilary();

            base.Update(time);
        }

        /// <summary>
        /// No need to call this method.  Just calls upon the separate draw methods of the MathExpression and the GameShape.
        /// </summary>
        /// <param name="time">
        /// </param>
        /// <returns>
        /// </returns>
        public override void Draw(GameTime time)
        {

            MathExpressionGamePiece.Draw(time);
            LetterB.Draw(time);
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
        public DrawableMiyagiKeyCard(Game game, Rectangle viewPort, Texture2D backgroundRectangle, string nameOfShape, string mathExpression,
            int widthOfThisKeyBlock,
            int heightOfThisKeyBlock, float xPos, float yPos, float zPos)
            : base(game)
        {
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));

            //Initializes the top math expression in the key-card
            MathExpressionGamePiece = new DrawableGameMathExpression(backgroundRectangle, spriteBatch, game.Content, Color.Red,
                 viewPort, mathExpression, widthOfThisKeyBlock, heightOfThisKeyBlock, xPos, yPos, zPos);


            //Initializes the bottom shape in the key-card
            LetterB = new DrawableGameMathExpression(backgroundRectangle, spriteBatch, game.Content, Color.Red,
                 viewPort, nameOfShape, widthOfThisKeyBlock, heightOfThisKeyBlock, xPos, yPos +
                 MathExpressionGamePiece.GetHeight(), zPos);



            game.Components.Add(this);
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
            MathExpressionGamePiece.SetPosition(xPos, yPos, zPos);
        }

        /// <summary>
        /// The purpose of this method is to constantly set the position of the math expression and the game shape correctly,
        /// no matter which part of the keycard is scrolled over or what part of the keycard the user clicks. This keeps the game
        /// shape anchored below the math expression, and the math expression anchored above the game shape.
        /// </summary>
        public void SetPositionAuxilary()
        {
            #region AnchorsUsedToDecideHowLettersMoveBasedOnWhichIsHighlighted

            //If the mouse scrolls over the math expression part of the keycard, and it is NOT over the shape part
            //of the keycard, then anchor the shape to always be below the math expression.
            if (MathExpressionGamePiece.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y)
                &&
                !(LetterB.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y)))
            {
                LetterB.SetPosition(MathExpressionGamePiece.GetPosition().X, (MathExpressionGamePiece.GetPosition().Y +
                    MathExpressionGamePiece.GetHeight()), 0);
            }

            //Or if the mouse scrolls over the shape part of the keycard, and it is NOT over the math expression part
            //of the keycard, then anchor the math expression to always be above the shape.
            else if (LetterB.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y)
                &&
                !(MathExpressionGamePiece.RectangleEnclosingThisObject.Contains(Mouse.GetState().X, Mouse.GetState().Y)))
            {
                MathExpressionGamePiece.SetPosition(LetterB.GetPosition().X, (LetterB.GetPosition().Y - LetterB.GetHeight()), 0);
            }

            #endregion AnchorsUsedToDecideHowLettersMoveBasedOnWhichIsHighlighted

            #region PositionBasedOnLetterSelection

            //If the math expression was clicked by the user, then make sure the shape
            //de-scales correctly to be below the math expression.
            if (MathExpressionGamePieceWasClicked == true && LetterBWasClicked == false)
            {
                LetterB.SetPosition(MathExpressionGamePiece.GetPosition().X, (MathExpressionGamePiece.GetPosition().Y +
                    MathExpressionGamePiece.HeightBeforeScaling), 0);
            }

            //Or if the shape was clicked by the user, then make sure the math expression
            //de-scales correctly to be above the shape.
            else if (MathExpressionGamePieceWasClicked == false && LetterBWasClicked == true)
            {
                MathExpressionGamePiece.SetPosition(LetterB.GetPosition().X, (LetterB.GetPosition().Y -
                    LetterB.HeightBeforeScaling), 0);
            }

            #endregion PositionBasedOnLetterSelection

        }
        /// <summary>
        /// Sets the size of this KeyCard.
        /// 
        /// Implementation details:
        /// Remember that this class is built from two smaller visual components (the DrawableGameShape and the MathExpressionGamePiece).   
        /// So the height of the individual ShapeGamePiece and MathExpressionGamePiece should be half the height of the DrawableMiyagiKeyCard.
        /// </summary>
        /// <param name="widthOfThisBlock">
        /// </param>
        /// <param name="heightOfThisBlock">
        /// </param>
        /// <returns>
        /// </returns>
        public void SetSize(int widthOfThisBlock, int heightOfThisBlock)
        {
            MathExpressionGamePiece.SetSize(widthOfThisBlock / 2, heightOfThisBlock / 2);

            LetterB.SetPosition(MathExpressionGamePiece.GetPosition().X, (MathExpressionGamePiece.GetPosition().Y +
                MathExpressionGamePiece.GetHeight()), 0);

            LetterB.SetSize(widthOfThisBlock / 2, heightOfThisBlock / 2);
        }


        public override void Initialize()
        {

            base.Initialize();
        }
    } /* end class DrawableMiyagiKeyCard */
}