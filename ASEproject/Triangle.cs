using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class MyTriangle:MyShape
    {
        protected int sideLength;
       

        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
        {
            Pen myPen = new Pen(myColor, 2);
            Point[] points = new Point[3];
            points[0] = new Point(myPoint.X, myPoint.Y - sideLength); // Represents the top point of the shape
            points[1] = new Point(myPoint.X - (sideLength / 2), myPoint.Y + (sideLength / 2)); // Represents the left point of triangle
            points[2] = new Point(myPoint.X + (sideLength / 2), myPoint.Y + (sideLength / 2)); // Represesnts the right point of traingle

            myGraphics.DrawPolygon(myPen, points);
        }
        public MyTriangle(Color myColor, int myX, int myY, int sideLength) : base(myColor, myX, myY)
        {
            this.sideLength = sideLength;
           

        }
    }
}
