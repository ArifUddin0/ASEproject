using System;
using System.Drawing;
using ASEproject;
namespace aseTest
{
    [TestClass]
    public class aseTest
    {
        [TestMethod]
        public void moveto()
        {
            // Prepare canvas and initialize starting coordinates
            MyCanvass canvas = new MyCanvass(100, 100);

            // Execute MoveTo method
            int moveToX = 30, moveToY = 40;
            canvas.MoveTo(moveToX, moveToY);

            // Access the 'p' property directly from the MyCanvass instance
            Point currentPoint = canvas.p;

            // Assert that the coordinates have changed
            Assert.AreEqual(moveToX, currentPoint.X);
            Assert.AreEqual(moveToY, currentPoint.Y);
        }
    }
}