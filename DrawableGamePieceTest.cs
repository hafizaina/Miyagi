using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HumanStorm.Miyagi.Framework.UnitTest
{
    [TestFixture, Description("This is a test for the DrawableGamePiece Class")]
    public class DrawableGamePieceTest
    {
        DrawableGamePiece GamePiece = new DrawableGamePiece("circle", false, 150, 150, 4.5f, 4.5f, 4.5f);

        [Test, Description("Test DrawableGamePiece class constructor")]
        public void InitializationTest()
        {
            // Checking some of the initialized variables
            Assert.AreEqual(false, GamePiece.IsMathExpression, "The 'IsMathExpression' variable does not match.");
            Assert.AreEqual("circle", GamePiece.ContentToDraw, "Initiliazed contentToDraw value is incorrect.");
            Assert.AreEqual(150, GamePiece.GetWidth(), "Initialized width value is incorrect.");
            Assert.AreEqual(150, GamePiece.GetHeight(), "Initialized height value is incorrect.");

            // Checking the initialized position values.
            float[] actualPositionValues = {GamePiece.GetPosition().X, GamePiece.GetPosition().Y, GamePiece.GetPosition().Z};
            float[] givenPositionValues = { 4.5f, 4.5f, 4.5f};
            for (int i = 0; i < actualPositionValues.Length; i++ )
            {
                Assert.AreEqual(givenPositionValues[i], actualPositionValues[i], "The initialized position values are not correct.");
            }
        }

        [Test, Description("Test DrawableGamePiece SetPosition() method")]
        public void TestSetPosition()
        {
            GamePiece.SetPosition(5, 5, 5);
            Assert.AreEqual(5, GamePiece.GetPosition().X, "SetPosition() values are incorrect.");
            Assert.AreEqual(5, GamePiece.GetPosition().Y, "SetPosition() values are incorrect.");
            Assert.AreEqual(5, GamePiece.GetPosition().Z, "SetPosition() values are incorrect.");
        }

        [Test, Description("Test DrawableGamePiece SetSize() method")]
        public void TestSetSize()
        {
            GamePiece.SetSize(200, 200);
            Assert.AreEqual(200, GamePiece.GetWidth(), "SetSize() values are incorrect.");
            Assert.AreEqual(200, GamePiece.GetHeight(), "SetSize() values are incorrect.");
        }

        [Test, Description("Test GetScreenCoordinatesOfMouse() method")]
        public void TestGetScreenCoordinatesOfMouse()
        {
            // implementation of test
        }

        [Test, Description("Test GetPositionWithRespectToViewPort() method")]
        public void TestGetPositionWithRespectToViewPort()
        {
            // implementation of test
        }

        [Test, Description("Test returned values of GetPosition() method")]
        public void TestGetPosition()
        {
            GamePiece.SetPosition(3, 3, 3);
            MPoint3D currentPos = GamePiece.GetPosition();
            Assert.AreEqual(3, currentPos.X, "GetPosition() method values are incorrect.");
            Assert.AreEqual(3, currentPos.Y, "GetPosition() method values are incorrect.");
            Assert.AreEqual(3, currentPos.Z, "GetPosition() method values are incorrect.");
        }
    }
}
