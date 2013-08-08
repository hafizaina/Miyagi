

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
    public DrawableGameShape(string NameOfShape, Texture2D backgroundRectColor, Color colorOfGamePiece, SpriteBatch sharedSprite, Rectangle viewPort, int widthOfGamePiece, int heightOfGamePiece, float xPos, float yPos, float zPos) :
        base(backgroundRectColor, colorOfGamePiece, sharedSprite, viewPort, widthOfGamePiece, heightOfGamePiece, xPos, yPos, zPos)
    {
        throw new NotImplementedException();
    }


    public override void Draw(GameTime time)
    {
        throw new NotImplementedException();
    }

    public override void Update(GameTime time)
    {
        throw new NotImplementedException();
    }
} 
}