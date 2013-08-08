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
    public class BaseGamePieceTests
    {
        [Test]
        [Description("Tests if getter returns actual width.")]
        public void TestWidthGetter()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetWidth() == 20);

        }

        [Test]
        [Description("Tests if getter returns actual height.")]
        public void TestHeightGetter()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetHeight() == 20);

        }



        [Test]
        [Description("Tests if size sets correctly.")]
        public void TestSetSize()
        {
            BaseGamePiece TestCard = new BaseGamePiece( 20, 20, 0, 0, 0);
            TestCard.SetSize(10, 10);
            Assert.IsTrue(TestCard.GetHeight() == 10);
            Assert.IsTrue(TestCard.GetWidth() == 10);

        }

        [Test]
        [Description("Tests exception throw when width and height are negative numbers.")]
        public void TestSetSize2()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(-10, -10); });

        }

        [Test]
        [Description("Tests exception throw when height is a negative number.")]
        public void TestSetSize3()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(10, -10); });

        }

        [Test]
        [Description("Tests exception throw when width is a negative number.")]
        public void TestSetSize4()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(-10, 10); });

        }


        [Test]
        [Description("Tests if position is set correctly.")]
        public void TestSetPosition()
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            TestCard.SetPosition(19, 13, 22);
            MPoint3D NewPosition = new MPoint3D(19, 13, 22);
            Assert.IsTrue(TestCard.GetPosition().Equals(NewPosition));
        }

        [Test]
        [Description("Tests whether input content is a valid math expression.")]
        // THESE TESTS ARE FOR IMPLEMENTATION FOR DRAWABLEGAMEMATHEXPRESSION. THEY HOLD NO RELEVANCE TO BASEGAMEPIECE!!!
        [TestCase(@"[A-Z]","A", Result = true)]
        [TestCase(@"[A-Z]", "a", Result = false)]
        [TestCase(@"[A-Z]", "Z", Result = true)]
        [TestCase(@"[A-Z]", "b", Result = false)]
        [TestCase(@"[A-Z]", "B", Result = true)]
        [TestCase(@"[A-Z]", "1", Result = false)]
        [TestCase(@"[a-z]", "1", Result = false)]
        [TestCase(@"[a-z]", "a", Result = true)]
        [TestCase(@"[a-z]", "h", Result = true)]
        [TestCase(@"[a-z]", "b", Result = true)]
        [TestCase(@"[a-z]", "z", Result = true)]
        [TestCase(@"[a-z]", "1", Result = false)]
        [TestCase(@"[a-z]", "G", Result = false)]
        [TestCase(@"-?", "A", Result = true)]
        [TestCase(@"-?", "-A", Result = true)]
        [TestCase(@"-?", "--A", Result = false)]
        [TestCase(@"-?", "---A", Result = false)]
        public bool TestMathExpression(String pattern, String contentName)
        {
            int count = 0;
            char[] checker = contentName.ToCharArray();
            foreach (char a in checker){
                if (a.Equals('-'))
                {
                    count++;
                }
            }

            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            if ((System.Text.RegularExpressions.Regex.IsMatch(contentName, pattern) == true) && (count <= 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
