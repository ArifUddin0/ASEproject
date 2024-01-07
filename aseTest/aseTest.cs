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


            canvas.MoveTo(x, y); // Simulate cursor movement

            // Asserts the current location of the cursor if it has moved successfully.
            Point currentLocation = canvas.GetCurrentLocation();

            Assert.AreEqual(new Point(x, y), currentLocation, "Cursor should move to the specified location");
        }

        /// <summary>
        /// Tests wether or not the cursor has drawn to a specific location
        /// </summary>

        [TestMethod]
        public void DrawTo_Test()
        {
            // Define initial and final coordinates for the line
            var canvas = new MyCanvass(350, 300);
            int startX = 10, startY = 10;
            int endX = 50, endY = 50;

            // Move the cursor to the starting position
            // Draw a line to the ending position
            canvas.MoveTo(startX, startY);
            canvas.DrawTo(endX, endY);

            // Check if the cursor is at the expected location
            var currentLocation = canvas.GetCurrentLocation();
            Assert.AreEqual(new Point(endX, endY), currentLocation, "Cursor should move to the specified location");
        }
        /// <summary>
        /// Tests if the canvass has been cleared
        /// </summary>
        [TestMethod]
        public void Clear_Test()
        {

            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(359, 300); // Adjust the canvas size


            canvas.MoveTo(50, 100); // Simulates the cursor movement
            canvas.DrawTo(100, 150); // Simulates the drawing action
            canvas.Clear(); // Simulates the clear action

            // Gets the canvas commands which should now be empty
            List<string> executedCommands = canvas.GetExecutedCommands();
            Assert.IsTrue(executedCommands.Count == 0, "Canvas should have no executed commands after clearing");
        }
        /// <summary>
        /// Tests to see wether or not the cursor has been reset to 0,0
        /// </summary>
        [TestMethod]
        public void Reset_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);


            canvas.MoveTo(50, 100); // Simulates the cursor movement
            canvas.Reset(); // Simulatss thee reset action

            // gets the current location of the cursor to see if it has returned to 0,0
            Point currentLocation = canvas.GetCurrentLocation();
            Assert.AreEqual(new Point(0, 0), currentLocation, "Cursor should reset to the original location at 0,0");
        }

        /// <summary>
        /// This tests to confirm wether or not the pens color has changed successfully.
        /// </summary>
        [TestMethod]
        public void ChangePenColor_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Define a command to change the pen color to blue
            string command = "colour blue"; 

            // Execute the color command
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the pen color after the command is executed
            Color updatedPenColor = pen.Color;

            // Assert that the pen color has been changed successfully to blue
            Assert.AreEqual(Color.Blue, updatedPenColor, "Pen color should be changed to blue.");
        }

        /// <summary>
        /// This tests checks wether ir not a shape has repeatedly drawn itself on the canvass
        /// </summary>
        [TestMethod]
        public void Repeat_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Defines a command for repeat to repeat 3 circles with a radius of 30 on them
            string command = "repeat 3 circle 30";

            // Executes the command for repeat
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Displays the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Check if there is atleast three commands that were executed each drawing a circle
            Assert.AreEqual(3, executedCommands.Count, "Expected 3 circles to be drawn.");
            Assert.IsTrue(executedCommands.TrueForAll(command => command.Contains("MyCircle")), "All executed commands should be circles.");
        }
        /// <summary>
        /// Test to verify that a variable is assigned successfully to a number
        /// </summary>
        [TestMethod]
        public void VariableAssignment_Test()
        {
            
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Defines a command that will assign a value to the variable s
            string command = "let x equals 10";

            // Executes the given command
            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Checks the dictionary to see the variables assigned 
            Assert.IsTrue(MyCommandParser.variables.ContainsKey("x"), "Variable 'x' should be in the variables dictionary.");
            Assert.AreEqual(10, MyCommandParser.variables["x"], "Variable 'x' should have the value 10.");
        }

        /// <summary>
        /// Tests to verify wether or not the execution of an expression has happened 
        /// </summary>
        [TestMethod]
        public void Expression_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Assigns a value to the variable counts
            string command1 = "let count equals 5";
            MyCommandParser parser1 = new MyCommandParser(command1, pen, canvas);

            // Defines an expression that uses the variable count
            string command2 = "let size equals count * 10";
            MyCommandParser parser2 = new MyCommandParser(command2, pen, canvas);

            // checks if that the variable size has the correct value after the expression is executed
            Assert.IsTrue(MyCommandParser.variables.ContainsKey("size"), "Variable 'size' should be in the variables dictionary.");
            Assert.AreEqual(50, MyCommandParser.variables["size"], "Variable 'size' should have the value 50.");
        }

        /// <summary>
        /// Tests to verify that the repeat command uses a variable successfully as a number of loops
        /// </summary>
        [TestMethod]
        public void RepeatWithVariable_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Assign a value to the variable x
            string assignmentCommand = "let x equals 3";
            MyCommandParser assignmentParser = new MyCommandParser(assignmentCommand, pen, canvas);

            // An example of a command that uses the variable x in the repeat loop count
            string repeatCommand = "repeat x circle 10";
            MyCommandParser repeatParser = new MyCommandParser(repeatCommand, pen, canvas);

            // Gets the list of executed commands completed
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Displasy the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Checks if the variable x is in the variables dictionary
            Assert.IsTrue(MyCommandParser.variables.ContainsKey("x"), "Variable 'x' should be in the variables dictionary.");

            // Checks if the repeat loop has been executed the expected number of times
            Assert.AreEqual(3, executedCommands.Count(command => command.Contains("MyCircle")), "Expected 3 circles to be drawn.");
        }

        /// <summary>
        /// Test to verify that the 'if' statement correctly executes the command based on the condition.
        /// </summary>
        [TestMethod]
        public void IfStatement_Test()
        {
            Pen pen = new Pen(Color.Red, 5);
            MyCanvass canvas = new MyCanvass(350, 300);

            // Assign a value to the variable 'x'
            string assignmentCommand = "let x equals 5";
            MyCommandParser assignmentParser = new MyCommandParser(assignmentCommand, pen, canvas);

            // Define an 'if' statement with a condition that evaluates to true
            string ifCommand = "if x equals 5 circle 10";
            MyCommandParser ifParser = new MyCommandParser(ifCommand, pen, canvas);

            // Get the list of executed commands
            List<string> executedCommands = canvas.GetExecutedCommands();

            // Display the executed commands 
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            // Check if the circle is drawn as the condition is true
            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyCircle")), "Circle should be drawn based on the 'if' condition.");
        }





    }
}