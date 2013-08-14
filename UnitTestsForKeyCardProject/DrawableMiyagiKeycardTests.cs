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
        public void TestInputDeviceCursorOverTopHalfOfKeyCard()
        {
            Game testGame = new Game();
            Rectangle testViewPort = new Rectangle(20,20,500,505);
            DrawableMiyagiKeyCard testCard = new DrawableMiyagiKeyCard (testGame, testViewPort,  
        }





        [Test(Description = "Verifies that when the mouse is over anywhere in the bottom half of the keyblock, that the key-card is enlarged.")]
        public void TestInputDeviceCursorOverBottomHalfOfKeyCard()
        {
            throw new NotImplementedException();
        }

        [Test(Description = "Verifies that when the mouse is NOT over either key-block, that the key-card is NOT enlarged.")]
        public void TestInputDeviceCursorNotOverTopPartOfKeyCard()
        {
            throw new NotImplementedException();
        }
    }
}
