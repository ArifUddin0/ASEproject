using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASEproject

{
    abstract class MyShape
    {
        protected Color myColor;
        protected int myX, myY;

        public abstract void DrawMyShape(Graphics g, Point point);
        public MyShape(Color color, int x, int y)
        {
            this.myColor = color;
            this.myX = x; this.myY = y;
           
        }

        public override string ToString()
        {
            return base.ToString() + myX + " " + myY;
        }
    }
}
