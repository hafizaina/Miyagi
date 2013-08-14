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
using NUnit.Framework;


namespace HumanStorm.Miyagi.Framework.UnitTests
{
    [TestFixture]
    public class BaseDrawableGamePieceTests
    {


        [Test(Description = "Tests the constructor and if certain methods work.")]
        public void TestBaseDrawableGamePiece()
        {   
            BaseDrawableGamePiece testPiece = new DrawableGameMathExpression(null, null, null, Color.Red,
                new Rectangle(0, 0, 100, 100), "a", 20, 20, 0, 0, 0);
            
            Assert.IsTrue(testPiece.GetPosition().Equals(new MPoint3D(0, 0, 0)));


        }

        [Test]
        [TestCase(0, 0, 0, 0,0,0)]
        [TestCase(10, 20, 0, 10,20,0)]
        [TestCase(10, 10, 0,10,10,0)]
        [TestCase(4, 80, 0,4,80,0)]
        [TestCase(10, 20, 0,10,20,0)]
        [TestCase(31, 50, 0,31,50,0)]
        [Description("Tests if GetPositionWithRespectToViewport returns the correct coordinates.")]
        public void TestGetPositionWithRespectToViewPort(int xPos, int yPos, int zPos, int correctX, int correctY, int correctZ)
        {
            BaseDrawableGamePiece testPiece = new DrawableGameMathExpression(null, null, null, Color.Red,
                new Rectangle(5, 16, 100, 100), "a", 20, 20, xPos, yPos, zPos);
            Vector3 correctCoord = new Vector3 (correctX,correctY,correctZ);
            Assert.AreEqual(correctCoord,testPiece.GetPositionWithRespectToViewPort());
        }

        [Test]
        [TestCase(0, 0, 0, 5, 16, 0)]
        [TestCase(10, 20, 0, 15, 36, 0)]
        [TestCase(10, 10, 0, 15, 26, 0)]
        [TestCase(4, 80, 0, 9, 96, 0)]
        [TestCase(31, 50, 0, 36, 66, 0)]
        [Description("Tests if GetPosition returns the correct coordinates with respect to the GraphicsDevice.")]
        public void TestGetPosition(int xPos, int yPos, int zPos, int correctX, int correctY, int correctZ)
        {
            BaseDrawableGamePiece testPiece = new DrawableGameMathExpression(null, null, null, Color.Red,
                new Rectangle(5, 16, 100, 100), "a", 20, 20, xPos, yPos, zPos);
            Assert.AreEqual(correctX,testPiece.GetPosition().X );
            Assert.AreEqual(correctY, testPiece.GetPosition().Y);
            Assert.AreEqual(correctZ, testPiece.GetPosition().Z);
        }

        [Test]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(10, 20, 0, 10, 20, 0)]
        [TestCase(10, 10, 0, 10, 10, 0)]
        [TestCase(4, 80, 0, 4, 80, 0)]
        [TestCase(31, 50, 0, 31, 50, 0)]
        [Description("Tests valid numbers to set the position of the keyblock.")]
        public void TestValidSetPosition(int xPos, int yPos, int zPos,int correctX,int correctY, int correctZ)
        {
            BaseDrawableGamePiece testPiece = new DrawableGameMathExpression(null, null, null, Color.Red,
            new Rectangle(5, 16, 100, 100), "a", 20, 20,0,0,0); 
            testPiece.SetPosition(xPos, yPos, zPos);

            Assert.AreEqual(correctX, testPiece.GetPosition().X);
            Assert.AreEqual(correctY, testPiece.GetPosition().Y);
            Assert.AreEqual(correctZ, testPiece.GetPosition().Z);
        }
/*
 * **********TEST FOR THE CLASS WHERE THE VIEWPORT WILL BE ESTABLISHED******************************
        [Test]
        [Description("Tests exception throw when position is outside of the viewport.")]
        [TestCase(-4140, -4310)]
        [TestCase(-4140, 0)]
        [TestCase(0, -4310)]
        [TestCase(-4140, 1)]
        [TestCase(40, -4310)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestInvalidSetPositions(int xPos, int yPos)
        {
            BaseDrawableGamePiece testPiece = new DrawableGameMathExpression(null, null, null, Color.Red,
         new Rectangle(5, 16, 100, 100), "a", 20, 20, 0, 0, 0);
            testPiece.SetPosition(xPos, yPos, 0);
        }
 */
    }
}
