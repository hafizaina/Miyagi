using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HumanStorm.Miyagi.Framework;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HumanStorm.Miyagi.Framework.UnitTests
{
    [TestFixture]
    public class DrawableGameMathExpressionTests
    {
        [Test]
        [Description("Tests whether input content is a valid math expression.")] 
        [TestCase( "A", Result = true)]
        [TestCase( "a", Result = false)]
        [TestCase( "Z", Result = true)]
        [TestCase( "b", Result = false)]
        [TestCase( "B", Result = true)]
        [TestCase( "1", Result = false)]
        [TestCase( "1", Result = false)]
        [TestCase( "a", Result = true)]
        [TestCase( "h", Result = true)]
        [TestCase("b", Result = true)]
        [TestCase("z", Result = true)]
        [TestCase("1", Result = false)]
        [TestCase( "G", Result = false)]
        [TestCase("A", Result = true)]
        [TestCase("-A", Result = true)]
        [TestCase( "--A", Result = false)]
        [TestCase( "---A", Result = false)]
        public bool TestMathExpression( String contentName)
        {
            String pattern2 = @"^-?(?i)[A-Z]\z";

            Texture2D testTexture2D;

            Game tempGame = new Game();

            //Just created to satisfy the required parameters of DrawableGameMathExpression
            testTexture2D = new Texture2D(
            tempGame.GraphicsDevice, 
            tempGame.GraphicsDevice.PresentationParameters.BackBufferWidth,
            tempGame.GraphicsDevice.PresentationParameters.BackBufferHeight, 
            true,
            tempGame.GraphicsDevice.PresentationParameters.BackBufferFormat
            );

            //DrawableGameMathExpression TestCard = new DrawableGameMathExpression(testTexture2D, new SpriteBatch(tempGame.GraphicsDevice), sharedSprite, , 20, 20, 0, 0, 0);
            throw new NotImplementedException("This constructor is does not have the valid properties");

            return System.Text.RegularExpressions.Regex.IsMatch(contentName, pattern2); 
        }

        [Test(Description="Verifies that when the mouse is over anywhere in the top half of the keyblock, that the key-card is enlarged.")]
        public void TestInputDeviceCursorOverTopHalfOfKeyCard()
        {
            throw new NotImplementedException();
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
