using System;
using System.Collections.Generic;
using System.Data;
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
                Console.WriteLine("let called");
                string name = parts[1];
                string expression = string.Join(" ", parts.Skip(3));

                if (TryEvaluateExpression(expression, out int value))
                {
                    variables[name] = value;
                }
                else
                {
                    Console.WriteLine($"Error evaluating expression for variable {name}");
                }
            }



            else if (parts[0] == "repeat")
            {

                HandleRepeatCommand(parts, pen, canvas);

            }

            else if (parts[0] == "if")
            {
                HandleIfCommand(parts, pen, canvas);
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
            if (parts.Length >= 4 && (parts[2].ToLower() == "circle" || parts[2].ToLower() == "rectangle" || parts[2].ToLower() == "triangle"))
            {
                int size1 = ifVariableOrValue(parts[3]);

                if (int.TryParse(parts[1], out int repeatCount))
                {
                    //repeats the loop -example - repeat 5 (repeats it 5 times)
                    for (int i = 0; i < repeatCount; i++)
                    {
                        // changes the position on the canvas to show its repeating
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
                else if (variables.ContainsKey(parts[1]))
                {
                    // If the loop count is a variable eg. repeat x amount of times
                    int loopCount = variables[parts[1]];
                    for (int i = 0; i < loopCount; i++)
                    {
                        // changes the position on the canvas to show its repeating
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
                    Console.WriteLine("Invalid 'repeat' command syntax. Loop count must be a variable or a numerical value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid 'repeat' command syntax.");
                // syntaxes for incorrect commands
            }
        }



        /// <summary>
        /// Determines whether or not the input is a variable name or a numerical value and retrieves the corresponding value from the variables dictionary.
        /// </summary>
        /// <param name="variableOrValue">The input string representing either a variable name or a numerical value.</param>
        /// <returns>The value corresponding to the variable name or the parsed numerical value.</returns>
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


        /// <summary>
        /// Handles the let command for variable assignment, updating the variables dictionary - let x equals 10
        /// </summary>
        /// <param name="parts">The array of command parts.</param>
        private void HandleVariableAssignment(string[] parts)
        {

            if (parts.Length == 4 && parts[2].ToLower() == "equals")
            {
                string variableName = parts[1];  // Do not convert to lowercase
                int value = Int32.Parse(parts[3]);

                // Updatse the variables dictionary with the assigned value that was inpputed in
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
        /// <summary>
        /// This will try to evaluate the specified numerical expression and retrieves the result for it
        /// </summary>
        /// <param name="expression">The mathematical expression to be evaluated.</param>
        /// <param name="result">The result of the evaluation if successful, otherwise 0.</param>
        /// <returns>True if the expression is successfully evaluated, false otherwise.</returns>
        private bool TryEvaluateExpression(string expression, out int result)
        {
            result = 0;

            foreach (var variable in variables)
            {
                expression = expression.Replace(variable.Key, variable.Value.ToString());
            }

            
            expression = expression.Replace("*", " * ");

            DataTable dt = new DataTable();

            try
            {
                result = Convert.ToInt32(dt.Compute(expression, ""));
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        
    }
        private void HandleIfCommand(string[] parts, Pen pen, MyCanvass canvas)
        {
            //combines the condition back into a single string to be evaluated
            string condition = string.Join(" ", parts.Skip(1).TakeWhile(p => p != "circle" && p != "rectangle" && p != "triangle"));
            bool conditionMet = false;

            if (condition.Contains("equals"))
            {
                string[] conditionParts = condition.Split(new string[] { "equals" }, StringSplitOptions.None);

                string variableName = conditionParts[0].Trim();
                string stringValue = conditionParts[1].Trim();

                //checks wether or not the variable exists in the dictionary and its value mtaches with the condition
                if (variables.TryGetValue(variableName, out int variableValue) && variableValue == int.Parse(stringValue))
                {
                    conditionMet = true;
                }
                
            }
            if (conditionMet)
            {
                //Extracts the command after the condition is done
                string commandToExecute = string.Join(" ", parts.SkipWhile(p => p != "circle" && p != "rectangle" && p != "triangle"));
                new MyCommandParser(commandToExecute, pen, canvas);
            }
        } 


        public string GetLastCommand()
        {
          return lastCommand;
        }
        //returns the last command


    }
    

}

