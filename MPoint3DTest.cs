using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

// NOTE TO SELF: Find a way to condense the test code

namespace KeyValueCard
{
    [TestFixture]
    class MPoint3DTest
    {
        MPoint3D loc = new MPoint3D();

        [Test]
        public void TestDefaultConstructor()
        {
            Assert.AreEqual(loc.X, 0f, "The X pos. is off");
            Assert.AreEqual(loc.Y, 0f, "The Y pos. is off");
            Assert.AreEqual(loc.Z, 0f, "The Z pos. is off");
        }

        [Test]
        public void TestSetPosition()
        {
            loc.SetPosition(3.5f, 4.5f, 5.5f);
            Assert.AreEqual(loc.X, 3.5f, "The X pos.(SetLocation) is off");
            Assert.AreEqual(loc.Y, 4.8f, "The Y pos.(SetLocation) is off");
            Assert.AreEqual(loc.Z, 5.5f, "The Z pos.(SetLocation) is off");
        }

        [Test]
        public void TestGetPosition()
        {

            MPoint3D loc2 = loc.GetPosition();
            Assert.AreEqual(loc.X, loc2.X, "The X pos.(GetLocation) is off");
            Assert.AreEqual(loc.Y, loc2.Y, "The Y pos.(GetLocation) is off");
            Assert.AreEqual(loc.Z, loc2.Z, "The Z pos.(GetLocation) is off");
        }
    }
}
