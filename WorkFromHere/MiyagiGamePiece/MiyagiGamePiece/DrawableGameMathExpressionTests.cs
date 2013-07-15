using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HumanStorm.Miyagi.Framework;
using System.Text.RegularExpressions;

namespace NUnitTest1
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
            DrawableGameMathExpression TestCard = new DrawableGameMathExpression(20, 20, 0, 0, 0);
            return System.Text.RegularExpressions.Regex.IsMatch(contentName, pattern2); 
        }

    }
}
