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
       
        public MyCommandParser(string command, Pen pen, MyCanvass canvas)
        {
            Console.WriteLine("Processing command: " + command);
                string[] parts = command.Split(' ');

                if (parts[0] == "moveto")
                {
                    int x = Int32.Parse(parts[1]);
                    int y = Int32.Parse(parts[2]);
                    canvas.MoveTo(x, y);

                }

                else if (parts[0] == "circle")
                {
                    int radius = Int32.Parse(parts[1]);
                    MyShape circle = new MyCircle(pen.Color, 15, 15, radius);
                    canvas.DrawMyShape(circle);

                }

                else if (parts[0] == "clear")
                {
                    canvas.Clear();
                }
                else if (parts[0] == "reset")
                {
                    canvas.Reset();
                }
                else if (parts[0] == "drawto")
                {
                    int x = Int32.Parse(parts[1]);
                    int y = Int32.Parse(parts[2]);
                    canvas.DrawTo(x, y);
                }


        }
    }
}

