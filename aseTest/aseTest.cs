using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ASEproject;
using Moq;

namespace aseTest
{
    [TestClass]
    public class aseTest
    {
        /// <summary>
        /// Test to confirm that a circle command results in a circle being drawn on the canvas.
        /// </summary>
        [TestMethod]
        public void Circle()

        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            string command = "circle 30"; // example/definiton of a command to draw a circle

            // Execute the circle command
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Asserts that least one  of the commands executed draws a circle
            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyCircle")));
        }

        /// <summary>
        /// Test to verify that a rectangle command results in a rectangle being drawn on the canvas.
        /// </summary>
        [TestMethod]
        public void Rectangle_Test()
        {

            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(300, 350);


            string command = "rectangle 30 40"; // Define a command to draw a rectangle

            // Executes the rectangle command
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Assert that at least one command executed draws a rectangle
            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyRectangle")));
        }
        /// <summary>
        /// Test to verify that a triangle command results in a triangle being drawn on the canvas.
        /// </summary>
        [TestMethod]
        public void Triangle_Test()
        {

            Pen pen = new Pen(Color.Green, 5);
            MyCanvass canvas = new MyCanvass(300, 350);

            // Defines a command to draw a triangle
            string command = "triangle 30";

            // Executes the triangle commands
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Assert that at least one command executed draws a triangle
            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyTriangle")));
        }

        /// <summary>
        /// Test to verify the execution of commands when the run button is clicked.
        /// </summary>
        [TestMethod]
        public void RunButton_Test()
        {

            Pen pen = new Pen(Color.Black, 2);
            MyCanvass canvas = new MyCanvass(500, 500);

            // Defines a set of commands separated by new lines as it would be entered into the multiTextBox
            string command = "circle 30" + Environment.NewLine + "rectangle 50 20" + Environment.NewLine + "triangle 40";

            // Emulate the button click and command processing
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var cmd in commands)
            {
                MyCommandParser parser = new MyCommandParser(cmd, pen, canvas);
            }

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Assert that at least one command has been executed
            Assert.IsTrue(executedCommands.Count > 0, "No commands were executed on run button click.");
        }


        /// <summary>
        /// Tests wether or not the cursor has succesfully moved
        /// </summary>
        [TestMethod]
        public void MoveTo_Test()
        {
         
            Pen pen = new Pen(Color.Red, 5); // Set pen properties
            MyCanvass canvas = new MyCanvass(350, 300); // Set up the canvas

            int x = 50;
            int y = 100;
            string command = $"moveto {x} {y}";

            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Act
            canvas.MoveTo(x, y); // Simulate cursor movement

            // Asserts the current location of the cursor if it has moved successfully.
            Point currentLocation = canvas.GetCurrentLocation();

            Assert.AreEqual(new Point(x, y), currentLocation, "Cursor should move to the specified location");
        }

        [TestMethod]
        public void DrawTo_Test()
        {
            // Arrange
            var canvas = new MyCanvass(350, 300);
            int startX = 10, startY = 10;
            int endX = 50, endY = 50;

            // Act
            canvas.MoveTo(startX, startY);
            canvas.DrawTo(endX, endY);

            // Assert
            var currentLocation = canvas.GetCurrentLocation();
            Assert.AreEqual(new Point(endX, endY), currentLocation, "Cursor should move to the specified location");
        }



    }
}