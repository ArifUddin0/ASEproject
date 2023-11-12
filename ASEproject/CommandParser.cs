using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASEproject

{
    /// <summary>
    /// Parses and processes different commands for the project.
    /// </summary>
    public class MyCommandParser
    {
        /// <summary>
        /// Initializes a new instance of the MyCommandParser class.
        /// </summary>
        /// <param name="command">The command to be processed.</param>
        /// <param name="pen">The pen used for drawing.</param>
        /// <param name="canvas">The canvas where the shapes are drawn.</param>
        /// 
        private string lastCommand; 
        public MyCommandParser(string command, Pen pen, MyCanvass canvas)
        {

            Console.WriteLine("Processing command: " + command);
                string[] parts = command.Split(' ');
                lastCommand = command;
            // Check the first part of the command to determine its type and process accordingly.

            if (parts[0] == "moveto")
                {
                    int x = Int32.Parse(parts[1]);
                    int y = Int32.Parse(parts[2]);
                    canvas.MoveTo(x, y);

                }
               // moves the cursor to the selected location

                else if (parts[0] == "circle")
                {
                    int radius = Int32.Parse(parts[1]);
                    MyShape circle = new MyCircle(pen.Color, 15, 15, radius);
                    canvas.DrawMyShape(circle);
               
                }
                // draws a circle on the output.

                else if (parts[0] == "rectangle")
                {
                int height = Int32.Parse(parts[1]);
                int width = Int32.Parse(parts[2]);
                MyShape rectangle = new MyRectangle(pen.Color, 15, 15, height, width);
                canvas.DrawMyShape(rectangle);

                 }
                // draws a rectangle on the output.
                else if (parts[0] == "triangle")
                {
                int sideLength = Int32.Parse(parts[1]);
                MyShape triangle = new MyTriangle(pen.Color, 15, 15, sideLength);
                canvas.DrawMyShape(triangle);

                 }
                //draws a triangle on the output.

                 else if (parts[0] == "clear")
                    {
                    canvas.Clear();
                 }
                //clears any drawings from the output - fresh sheet.
                else if (parts[0] == "reset")
                {
                    canvas.Reset();
                  }
                //resets the cursor to 0,0.
                else if (parts[0] == "drawto")
                {
                    int x = Int32.Parse(parts[1]);
                    int y = Int32.Parse(parts[2]);
                    canvas.DrawTo(x, y);
                 }
                //draws a line from the selected points.
                 


        }

        public string GetLastCommand()
        {
          return lastCommand;
        }
        //returns the last command
    }
}

