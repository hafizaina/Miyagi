using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HumanStorm.Miyagi.Framework;

namespace NUnitTest1
{
    [TestFixture]
    public class BaseGraphicalMiyagiKeycardTests
    {
        [Test(Description = "Test for GetWidth method.")]
        public void TestWidthGetter()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetWidth() == 20);
            
        }

        [Test(Description = "Test for GetHeight method.")]
        public void TestHeightGetter()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetHeight() == 20);

        }



        [Test(Description = "Test for SetSize method.")]
        public void TestSetSize()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            TestCard.SetSize(10, 10);
            Assert.IsTrue(TestCard.GetHeight() == 10);
            Assert.IsTrue(TestCard.GetWidth() == 10);

        }

        [Test(Description = "Test for SetSize method. Should throw an error due to both width and height being negative.")]
        public void TestSetSize2()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(-10,-10); });

        }

        [Test(Description = "Test for SetSize method. Should throw an error due to height being negative.")]
        public void TestSetSize3()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(10, -10); });

        }

        [Test(Description = "Test for SetSize method. Should throw an error due to width being negative.")]
        public void TestSetSize4()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.Throws<ArgumentException>(delegate { TestCard.SetSize(-10, 10); });

        }


        [Test(Description = "Test for SetPosition method.")]
        public void TestSetPosition()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            TestCard.SetPosition(19,13,22);
            MPoint3D NewPosition = new MPoint3D (19,13,22);
            Assert.IsTrue(TestCard.GetPosition().Equals(NewPosition));
        }

        [Test(Description = "Test for GetNameOfShape method.")]
        public void TestGetNameOfShape()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetNameOfShape().Equals("square"));
        }


        [Test(Description = "Test for GetMathExpressionToDisplay method.")]
        public void TestGetMathExpressionToDisplay()
        {
            BaseGraphicalMiyagiKeyCard TestCard = new BaseGraphicalMiyagiKeyCard("square", "+", 20, 20, 0, 0, 0);
            Assert.IsTrue(TestCard.GetMathExpressionToDisplay().Equals("+"));
        }

    }
}
