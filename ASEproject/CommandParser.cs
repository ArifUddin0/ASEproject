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
        public static Dictionary<string, int> variables = new Dictionary<string, int>();
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
                if (parts.Length == 2)
                {
                    int radius = ifVariableOrValue(parts[1]);
                    MyShape circle = new MyCircle(pen.Color, canvas.GetCurrentLocation().X, canvas.GetCurrentLocation().Y, radius);
                    canvas.DrawMyShape(circle);
                }
                else
                {
                    Console.WriteLine("Invalid 'circle' command syntax.");
                }

            }


            // draws a circle on the output.

            else if (parts[0] == "rectangle")
            {
                if (parts.Length == 3)
                {
                    int width = ifVariableOrValue(parts[1]);
                    int height = ifVariableOrValue(parts[2]);
                    MyShape rectangle = new MyRectangle(pen.Color, 15, 15, width, height);
                    canvas.DrawMyShape(rectangle);
                }
                else
                {
                    Console.WriteLine("Invalid 'rectangle' command syntax.");
                }
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

            else if (parts[0] == "colour")
            {
                HandleColorCommand(parts, pen);
            }
            else if (parts[0] == "let")
            {
                // HandleVariableAssignment(parts);
                Console.WriteLine("let called");
                string name = parts[1];
                if (!Int32.TryParse(parts[3], out int value))
                {
                    Console.WriteLine("Value not assigned to" + name);
                }
                variables[name] = value;
            }
            else if (parts[0] == "vars")
            {
                Console.WriteLine("vars called");
                foreach (var item in variables)
                { Console.WriteLine(item); }
            }
        

            else if (parts[0] == "repeat")
            {

                HandleRepeatCommand(parts, pen, canvas);

            }
        }

        /// <summary>
        /// Handles the 'repeat' command to loop the shapes multiple times on the canvas.
        /// </summary>
        /// <param name="parts">The array of command parts.</param>
        /// <param name="pen">The Pen object used for drawing.</param>
        /// <param name="canvas">The canvas where the shapes are drawn.</param>
        private void HandleRepeatCommand(string[] parts, Pen pen, MyCanvass canvas)
        {
            // Checking for valid amount of parts in command
            if (parts.Length >= 4 && int.TryParse(parts[1], out int repeatCount) && (parts[2].ToLower() == "circle" || parts[2].ToLower() == "rectangle" || parts[2].ToLower() == "triangle"))
            {
                    //size for the command -example - circle 10
                    int size1 = ifVariableOrValue(parts[3]);

                //repeats the loop -example - repeat 5 (repeats it 5 times)
                for (int i = 0; i < repeatCount; i++)
                {
                    //changes position on canvass so you can see the shapes loop poeprly 
                    int newX = canvas.GetCurrentLocation().X + i * 5; 
                    int newY = canvas.GetCurrentLocation().Y + i * 5; 
                    canvas.MoveTo(newX, newY);

                    if (parts[2].ToLower() == "circle")
                    {
                        MyShape circle = new MyCircle(pen.Color, newX, newY, size1);
                        canvas.DrawMyShape(circle);
                    }
                    else if (parts[2].ToLower() == "rectangle")
                    {
                        if (parts.Length >= 5)
                        {
                            int size2 = ifVariableOrValue(parts[4]);
                            MyShape rectangle = new MyRectangle(pen.Color, newX, newY, size1, size2);
                            canvas.DrawMyShape(rectangle);
                        }
                        
                    }
                    else if (parts[2].ToLower() == "triangle" && parts.Length >= 5)
                    {
                        int size2 = ifVariableOrValue(parts[4]);
                        MyShape triangle = new MyTriangle(pen.Color, newX, newY, size1);
                        canvas.DrawMyShape(triangle);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid 'repeat' command syntax.");
            }
        }


        private int ifVariableOrValue(string variableOrValue)
        {
            if (variables.ContainsKey(variableOrValue))
            { return variables[variableOrValue];
            }
            else if (Int32.TryParse(variableOrValue, out int value))
                {  return value; 
            }
            else
            {
                Console.WriteLine($"Variable or value not found: {variableOrValue}");
                return 0; 
            }
        }



        private void HandleVariableAssignment(string[] parts)
        {

            if (parts.Length == 4 && parts[2].ToLower() == "equals")
            {
                string variableName = parts[1];  // Do not convert to lowercase
                int value = Int32.Parse(parts[3]);


                if (variables.ContainsKey(variableName))
                {
                    variables[variableName] = value;
                }
                else
                {
                    variables.Add(variableName, value);
                }

            }
        }

        /// <summary>
        /// Handles the 'colour' command to set the pen color based on the specified color name.
        /// </summary>
        /// <param name="parts">The array of command parts.</param>
        /// <param name="pen">The Pen object whose color will be set.</param>
        private void HandleColorCommand(string[] parts, Pen pen)
        {
            if (parts.Length > 1)
            {
                switch (parts[1].ToLower())
                {
                    case "blue":
                        pen.Color = Color.Blue;
                        break;
                    case "green":
                        pen.Color = Color.Green;
                        break;
                    case "yellow":
                        pen.Color = Color.Yellow;
                        break;
                    default:
                        Console.WriteLine($"Invalid color: {parts[1]}");
                        break;
                }
                
            }

           
        }


        public string GetLastCommand()
        {
          return lastCommand;
        }
        //returns the last command
    }
}

