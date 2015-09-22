using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTurtle;

namespace SharpTurtleTest
{
    [TestClass]
    public class TurtleTest
    {
        [TestMethod]
        public void TestForward()
        {
            Turtle t = new Turtle();
            t.Forward(10f);

            Assert.AreEqual(10f, t.X);
            Assert.AreEqual(0f, t.Y);
        }

        [TestMethod]
        public void TestBackward()
        {
            Turtle t = new Turtle();
            t.Backward(10f);

            Assert.AreEqual(-10f, t.X);
            Assert.AreEqual(0f, t.Y);
        }

        [TestMethod]
        public void TestRight()
        {
            Turtle t = new Turtle();
            t.Right(10);

            Assert.AreEqual(350, t.Angle);
        }

        [TestMethod]
        public void TestLeft()
        {
            Turtle t = new Turtle();
            t.Left(10);

            Assert.AreEqual(10, t.Angle);
        }

        [TestMethod]
        public void TestTurnMove()
        {
            Turtle t = new Turtle();
            t.Left(45);
            t.Forward(10);

            Assert.AreEqual(7.07, t.X, 0.002);
            Assert.AreEqual(7.07, t.Y, 0.002);

            t.Undo();
            t.Left(45);
            t.Forward(10);

            Assert.AreEqual(0, t.X, 0.002);
            Assert.AreEqual(10, t.Y);

            t.Undo();
            t.Left(45);
            t.Forward(10);

            Assert.AreEqual(-7.07, t.X, 0.002);
            Assert.AreEqual(7.07, t.Y, 0.002);
        }
    }
}
