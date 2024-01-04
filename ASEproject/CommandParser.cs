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
        private Dictionary<string, int> variables = new Dictionary<string, int>();
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
            else if (parts[0] == "vars")
            {
               foreach (KeyValuePair<string, int> kvp in variables)
                { Console.WriteLine("key = {0}, Value = {1}", kvp.Key, kvp.Value); 

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
                HandleVariableAssignment(parts);
            }
        }
        private int ifVariableOrValue(string variableOrValue)
        {
            Console.WriteLine($"Checking variable or value: {variableOrValue}");

           // string key = variableOrValue.ToLower();  // Convert to lowercase for case-insensitive comparison

           // Console.WriteLine($"Lowercased key: {key}");

            if (Int32.TryParse(variableOrValue, out int value))
            {
                Console.WriteLine($"Parsed as integer: {value}");
                return value;
            }
          //  else if (variables.ContainsKey(key))
          //  {
           //     Console.WriteLine($"Found variable: {variables[key]}");
           //     return variables[key];
          //  }
            else
            {
                Console.WriteLine($"Variable or value not found: {variableOrValue}");
                return 0; // or any other default value you want to assign
            }
        }



        private void HandleVariableAssignment(string[] parts)
        {
            Console.WriteLine($"Handling variable assignment. Parts: {string.Join(", ", parts)}");

            if (parts.Length == 4 && parts[2].ToLower() == "equals")
            {
                string variableName = parts[1];  // Do not convert to lowercase
                int value = Int32.Parse(parts[3]);

                //Console.WriteLine($"Variable name: {variableName}, Value: {value}");

                if (variables.ContainsKey(variableName))
                {
                    variables[variableName] = value;
                }
                else
                {
                    variables.Add(variableName, value);
                }

                //Console.WriteLine($"Variable '{variableName}' assigned the value {value}");
            }
            else
            {
               // Console.WriteLine("Invalid variable assignment syntax.");
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

