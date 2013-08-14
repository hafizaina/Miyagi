using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HumanStorm.Miyagi.Framework.UnitTests
{
    [TestFixture]
    public class DrawableMiyagiKeycardTests
    {
        [Test]
        [Description("Verifies that when the mouse is over anywhere in the top half of the keyblock, that the key-card is enlarged.")]
        public void MouseOverTopHalfOfKeycard()
        {
            Game1 testGame = new Game1();
            Rectangle testViewPort = new Rectangle(0,0,500,505);
            DrawableMiyagiKeyCard testCard = new DrawableMiyagiKeyCard(testGame, testViewPort, null, "a", "B", 20, 20, 0, 0, 0);
            Mouse.SetPosition(5, 5);
            testCard.Update(new GameTime());
            Assert.True(testCard.MathExpressionGamePiece.IsTargeted,"Checks if the top half of the keycard was highlighted over with the mouse.");
        }





        [Test(Description = "Verifies that when the mouse is over anywhere in the bottom half of the keyblock, that the key-card is enlarged.")]
        public void TestInputDeviceCursorOverBottomHalfOfKeyCard()
        {
            Game1 testGame = new Game1();
            Rectangle testViewPort = new Rectangle(0, 0, 500, 505);
            DrawableMiyagiKeyCard testCard = new DrawableMiyagiKeyCard(testGame, testViewPort, null, "a", "B", 20, 20, 0, 0, 0);
            Mouse.SetPosition(19, 19);
            testCard.Update(new GameTime());
            Assert.True(testCard.LetterB.IsTargeted, "Checks if the bottom half of the keycard was highlighted over with the mouse.");
        }

        [Test(Description = "Verifies that when the mouse is NOT over either key-block, that the key-card is NOT enlarged.")]
        public void TestInputDeviceCursorNotOverTopPartOfKeyCard()
        {
            Game1 testGame = new Game1();
            Rectangle testViewPort = new Rectangle(0, 0, 500, 505);
            DrawableMiyagiKeyCard testCard = new DrawableMiyagiKeyCard(testGame, testViewPort, null, "a", "B", 20, 20, 0, 0, 0);
            Mouse.SetPosition(91, 91);
            testCard.Update(new GameTime());
            Assert.True(testCard.LetterB.IsTargeted == false, "Checks if the keycard is not highlighted over with the mouse.");
        }
    }
}
