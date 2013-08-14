using NUnit.Framework;
using HumanStorm.Miyagi.Framework;

namespace HumanStorm.Miyagi.Framework.UnitTests
{
    [TestFixture]
    public class BaseGamePieceTests
    {
        [Test]
        [TestCase(20, false, 1.2f, Result = 20)]
        [TestCase(40, false, 1.2f, Result = 40)]
        [TestCase(1, true, 1.2f, Result = 1)]
        [TestCase(6, true, 1.2f, Result = 7)]
        [TestCase(7, false, 1.2f, Result = 7)]
        [TestCase(145, false, 1.2f, Result = 145)]
        [TestCase(152, true, 1.2f, Result = 182)]
        [TestCase(541, false, 1.2f, Result = 541)]
        [Description("Tests if getter returns actual width.")]
        public int TestWidthGetter(int width, bool isTargeted, float scaleFactor)
        {
            BaseGamePiece TestCard = new BaseGamePiece(width, 20, 0, 0, 0);
            TestCard.IsTargeted = isTargeted;
            TestCard.SCALE_FACTOR = scaleFactor;
            return TestCard.GetWidth();
        }

        [Test]
        [TestCase(20, false, 1.2f, Result = 20)]
        [TestCase(40, false, 1.2f, Result = 40)]
        [TestCase(1, true, 1.2f, Result = 1)]
        [TestCase(6, true, 1.2f, Result = 7)]
        [TestCase(7, false, 1.2f, Result = 7)]
        [TestCase(145, false, 1.2f, Result = 145)]
        [TestCase(152, true, 1.2f, Result = 182)]
        [TestCase(541, false, 1.2f, Result = 541)]
        [Description("Tests if getter returns actual height.")]
        public int TestHeightGetter(int height, bool isTargeted, float scaleFactor)
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, height, 0, 0, 0);
            TestCard.IsTargeted = isTargeted;
            TestCard.SCALE_FACTOR = scaleFactor;
            return TestCard.GetHeight();
        }



        [Test]
        [TestCase(40, 40, false, 1.2f, 40, 40)]
        [TestCase(450, 340, true, 1.2f, 540, 408)]
        [TestCase(450, 420, false, 1.2f, 450, 420)]
        [TestCase(410, 140, true, 1.2f, 492, 168)]
        [TestCase(401, 4560, false, 1.2f, 401, 4560)]
        [TestCase(410, 450, true, 1.2f, 492, 540)]
        [TestCase(4140, 4310, false, 1.2f, 4140, 4310)]
        [Description("Tests if size sets correctly.")]
        public void TestValidSetSize(int widthToSet, int heightToSet, bool isTargeted,
            float scaleFactor, int newWidth, int newHeight)
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            TestCard.SetSize(widthToSet, heightToSet);
            TestCard.IsTargeted = isTargeted;
            TestCard.SCALE_FACTOR = scaleFactor;
            Assert.AreEqual(TestCard.GetHeight(), newHeight);
            Assert.AreEqual(TestCard.GetWidth(), newWidth);
        }

        [Test]
        [Description("Tests exception throw when width and height are negative numbers.")]
        [TestCase(-4140, -4310)]
        [TestCase(-4140, 0)]
        [TestCase(0, -4310)]
        [TestCase(-4140, 1)]
        [TestCase(40, -4310)]
        [TestCase(0, 0)]
        [TestCase(0, 01)]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestInvalidSetSizes(int invalidWidth, int invalidHeight)
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            TestCard.SetSize(invalidWidth, invalidHeight);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 20, 430)]
        [TestCase(10, 10, 10)]
        [TestCase(-20, 80, -90)]
        [TestCase(10, -20, 0)]
        [TestCase(-10, -50, 0)]
        [Description("Tests if position is set and is returned by its getter correctly.")]
        public void TestGetAndSetPosition(int xPos, int yPos, int zPos)
        {
            BaseGamePiece TestCard = new BaseGamePiece(20, 20, 0, 0, 0);
            TestCard.SetPosition(xPos, yPos, zPos);
            MPoint3D NewPosition = TestCard.GetPosition();
            Assert.AreEqual(NewPosition.X, xPos);
            Assert.AreEqual(NewPosition.Y, yPos);
            Assert.AreEqual(NewPosition.Z, zPos);
        }


    }

}
