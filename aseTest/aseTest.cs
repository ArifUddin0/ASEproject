using System;
using System.Drawing;
using ASEproject;
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
            // Create a pen and a canvas
            Pen pen = new Pen(Color.Green, 5);
            MyCanvass canvas = new MyCanvass(300, 350);

            // Define a command to draw a triangle
            string command = "triangle 30"; // You might need additional parameters for triangle drawing

            // Execute the triangle command
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands (for verification, can be removed in final implementation)
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Assert that at least one command executed draws a triangle
            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyTriangle")), "A triangle should be drawn on executing the command.");
        }

    }
    
}