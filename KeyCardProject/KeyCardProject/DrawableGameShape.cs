/// <summary>
    ///  A class that represents a DrawableGameShape object.
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
    public class DrawableGameShape : BaseDrawableGamePiece
    {
        // Attributes
        /// <summary>
        /// The Texture2D that corresponds to the shape to display on the key-block.
        /// </summary>
        public Texture2D TextureForShape;

        /// <summary>
        /// The name of the shape that this object will draw on the screen.
        /// </summary>
        public String NameOfShape;

        /// <summary>
        /// Determines if KeyCard is being dragged
        /// </summary>
        bool dragging = false;

        /// <summary>
        /// The scaled width of RectangleEnclosingThisObject based on the scale factor
        /// </summary>
        Rectangle ScaledRectangleEnclosingThisObject;

        /// <summary>
        /// Percentage to scale game shape with respect to container dimensions
        /// </summary>
        private const float PERCENTAGE_SIZE_OF_CONTAINER_RECTANGLE_TO_MAKE_SIZE_OF_GAME_SHAPE = .5f;
        
#region ScalingMotionData
    /// <summary>
    /// X coordinate at center of normal container
    /// </summary>
    private float xCenter;
    /// <summary>
    /// Y coordinate at center of normal container
    /// </summary>
    private float yCenter;
    /// <summary>
    /// Position of normal container
    /// </summary>
    Vector2 cardPosition;
    /// <summary>
    /// X coordinate of enlargened container
    /// </summary>
    private float xScaledPosition;
    /// <summary>
    /// Y coordinate of enlargened container
    /// </summary>
    private float yScaledPosition;
#endregion ScalingMotionData

#region Dragging
    private MouseState PrevMouseState;
    int xDisplacement;
    int yDisplacement;
#endregion Dragging

#region TextureData
    private int TextureWidth;
    private int TextureHeight;
    private int TextureX;
    private int TextureY;
#endregion TextureData

    // Operations

        /// <summary>
        /// Initializes a new DrwableGameShape object.
        /// </summary>
        /// <param name="sharedSprite">
        /// </param>
        /// <param name="NameOfShape">
        /// </param>
        /// <param name="widthOfThisGamePiece">
        /// </param>
        /// <param name="heightOfGamePiece">
        /// </param>
        /// <param name="xPos">
        /// </param>
        /// <param name="yPos">
        /// </param>
        /// <param name="zPos">
        /// </param>
        /// <returns>
        /// </returns>
        public DrawableGameShape(string NameOfShape, Texture2D backgroundRectColor, Color colorOfGamePiece, SpriteBatch sharedSprite, Rectangle viewPort, int widthOfGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos):
            base(backgroundRectColor, colorOfGamePiece, sharedSprite, viewPort, widthOfGamePiece, heightOfGamePiece, xPos, yPos, zPos)
        {
            this.NameOfShape = NameOfShape;
            this.PrevMouseState = Mouse.GetState();
            TextureWidth = RectangleEnclosingThisObject.Width / 2;
            TextureHeight = RectangleEnclosingThisObject.Height / 2;
            ScaledRectangleEnclosingThisObject = new Rectangle(RectangleEnclosingThisObject.X, RectangleEnclosingThisObject.Y,
                    (int)(RectangleEnclosingThisObject.Width * SCALE_FACTOR), (int)(RectangleEnclosingThisObject.Height * SCALE_FACTOR)); ;
        }

        public void LoadContent(ContentManager content)
        {
            this.TextureForShape = content.Load<Texture2D>(NameOfShape);
        }

        public override void Draw(GameTime time)
        {
            if (IsTargeted)
            {
                int ScaledTextureWidth = ScaledRectangleEnclosingThisObject.Width / 2;
                int ScaledTextureHeight = ScaledRectangleEnclosingThisObject.Height / 2;
                TextureX = (int)(xScaledPosition + ScaledRectangleEnclosingThisObject.Width / 2 - ScaledTextureWidth / 2);
                TextureY = (int)(yScaledPosition + ScaledRectangleEnclosingThisObject.Height / 2 - ScaledTextureHeight / 2);
                this.SharedSpriteBatch.Begin();
                this.SharedSpriteBatch.Draw(backgroundRectangle, SetGameShapePositionAndScale(),ScaledRectangleEnclosingThisObject, Color.Green);
                this.SharedSpriteBatch.Draw(TextureForShape, new Rectangle(TextureX, TextureY, ScaledTextureWidth, ScaledTextureHeight), base.ColorOfShape);
                this.SharedSpriteBatch.End();

            }
            else
            {
                TextureX = RectangleEnclosingThisObject.X + RectangleEnclosingThisObject.Width / 2 - TextureWidth / 2;
                TextureY = RectangleEnclosingThisObject.Y + RectangleEnclosingThisObject.Height / 2 - TextureHeight / 2;
                this.SharedSpriteBatch.Begin();
                this.SharedSpriteBatch.Draw(backgroundRectangle, RectangleEnclosingThisObject, Color.Green);
                this.SharedSpriteBatch.Draw(TextureForShape, new Rectangle(TextureX, TextureY, TextureWidth, TextureHeight), base.ColorOfShape);
                this.SharedSpriteBatch.End();
            }
        }

        public override void Update(GameTime time)
        {
            if (this.RectangleEnclosingThisObject.Contains((int)this.GetScreenCoordinatesOfMouse().X,
                (int)this.GetScreenCoordinatesOfMouse().Y) || this.ScaledRectangleEnclosingThisObject.Contains((int)this.GetScreenCoordinatesOfMouse().X,
                (int)this.GetScreenCoordinatesOfMouse().Y))
            {
                //if the mouse hovers over the rectangle, expand the rectangle to scaled size from its center.
                this.SetColor(Color.Red);
                Vector2 originalRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                this.IsSelected = true;
                this.IsTargeted = true;

                Vector2 scaledRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                Vector2 displacement = Vector2.Subtract(scaledRectangleCenter, originalRectangleCenter);

                this.SetPosition(this.Position.X - displacement.X, this.Position.Y - displacement.Y);
            }

            else
            {

                //But if not, draw the original rectangle on the screen and de-scale it from the center.
                this.SetColor(Color.Blue);
                Vector2 scaledRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                this.IsSelected = false;
                this.IsTargeted = false;

                Vector2 originalRectangleCenter = new Vector2(this.RectangleEnclosingThisObject.Center.X,
                    this.RectangleEnclosingThisObject.Center.Y);

                Vector2 displacement = Vector2.Subtract(originalRectangleCenter, scaledRectangleCenter);

                this.SetPosition(this.Position.X - displacement.X, this.Position.Y - displacement.Y);
            }

        }

        public Vector2 SetGameShapePositionAndScale()
        {
            xCenter = RectangleEnclosingThisObject.X + (.5f * (float)RectangleEnclosingThisObject.Width);
            yCenter = RectangleEnclosingThisObject.Y + (.5f * (float)RectangleEnclosingThisObject.Height);

            xScaledPosition = xCenter - (.5f * ScaledRectangleEnclosingThisObject.Width);
            yScaledPosition = yCenter - (.5f * ScaledRectangleEnclosingThisObject.Height);

            return new Vector2(xScaledPosition, yScaledPosition);
        }

        public void SetColor(Color color)
        {
            base.ColorOfShape = color;
        }

        public Vector2 SetPositionOfShape()
        {
            float xPos = base.ViewPort.X + (base.ViewPort.Width / 2) - base.GetWidth() / 2;
            float yPos = base.ViewPort.Y + (base.ViewPort.Height / 2) - base.GetHeight() / 2;
            return new Vector2(xPos, yPos);
        }

        public bool IsMouseOver(MouseState mouseState)
        {
            if (IsSelected)
            {
                return ((mouseState.X > xScaledPosition) && (mouseState.X < (xScaledPosition + GetWidth() * SCALE_FACTOR)) &&
                    (mouseState.Y > yScaledPosition) && (mouseState.Y < (yScaledPosition + GetHeight() * SCALE_FACTOR)));
            }
            else
            {
                return ((mouseState.X > GetPosition().X) && (mouseState.X < (ViewPort.X + ViewPort.Width)) &&
                    (mouseState.Y > GetPosition().Y) && (mouseState.Y < (ViewPort.Y + ViewPort.Height)));
            }
        }
    } 
}