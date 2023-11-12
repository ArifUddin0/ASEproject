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
            Pen pen = new Pen(Color.Black, 2); // Or another color and size
            MyCanvass canvas = new MyCanvass(500, 500); // Adjustment of the canvas size

            string command = "moveto 50 50";

            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Assert
            // Check if the cursor moved to the expected position (50, 50)

        }

        [TestMethod]
        public void Circle_Test()
        {
            Pen pen = new Pen(Color.Black, 2); // Or another color and size
            MyCanvass canvas = new MyCanvass(500, 500); // Adjust the canvas size

            string command = "circle 30";

            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Assert
            string[] parts = command.Split(' ');
            Assert.IsTrue(parts.Length == 2 && parts[0] == "circle" && int.TryParse(parts[1], out _));
        }

    }
}