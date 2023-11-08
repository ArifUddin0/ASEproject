using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASEproject

{
    internal class MyCommandParser
    {
        public void ProcessCommand(string command, Pen pen, MyCanvass canvas)
        {
            Console.WriteLine("Processing command: " + command);
            string[] parts = command.Split(' ');

            if (parts[0] == "circle")
            {
                 int radius = Int32.Parse(parts[1]);
                 MyShape circle = new MyCircle(pen.Color, 15, 15, radius);

                 canvas.DrawMyShape(circle);
            }
        }
    }
}

