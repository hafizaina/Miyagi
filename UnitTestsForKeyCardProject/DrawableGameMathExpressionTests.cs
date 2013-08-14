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
        [TestCase("A", Result = true)]
        [TestCase("a", Result = true)]
        [TestCase("Z", Result = true)]
        [TestCase("b", Result = true)]
        [TestCase("B", Result = true)]
        [TestCase("a", Result = true)]
        [TestCase("h", Result = true)]
        [TestCase("b", Result = true)]
        [TestCase("z", Result = true)]
        [TestCase("G", Result = true)]
        [TestCase("A", Result = true)]
        [TestCase("-A", Result = true)]
        public bool TestValidMathExpressions(String contentName)
        {
            String pattern2 = @"^-?(?i)[A-Z]\z";

            DrawableGameMathExpression TestCard = new DrawableGameMathExpression(null, null,
            null, Color.Red, new Rectangle(10, 10, 0, 0), contentName, 10, 10, 0, 0, 0);

            return System.Text.RegularExpressions.Regex.IsMatch(contentName, pattern2);
        }

        [Test]
        [Description("Tests whether input content is an invalid math expression.")]
        [TestCase("1")]
        [TestCase("--A")]
        [TestCase("---A")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestInvalidMathExpressions(String contentName)
        {
            Game testGame = new Game();
            testGame.Content.RootDirectory = "Content";
            ContentManager testContent = new ContentManager(testGame.Services);
            DrawableGameMathExpression TestCard = new DrawableGameMathExpression(null, null,
            testContent, Color.Red, new Rectangle(10, 10, 0, 0), contentName, 10, 10, 0, 0, 0);
        }

       

    }
}
