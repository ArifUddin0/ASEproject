using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// inherits properties from shape.cs
    /// </summary>
    public class MyTriangle: MyShape 
    {
        protected int sideLength;

        /// <summary>
        /// Initializes a new instance of the MyTriangle class.
        /// </summary>
        /// <param name="myColor">The color of the triangle.</param>
        /// <param name="myX">The X-coordinate of the triangle's origin.</param>
        /// <param name="myY">The Y-coordinate of the triangle's origin.</param>
        /// <param name="sideLength">The length of each side of the triangle.</param>
        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
        {
            Pen myPen = new Pen(myColor, 2);
            Point[] points = new Point[3];
            points[0] = new Point(myPoint.X, myPoint.Y - sideLength); 
            points[1] = new Point(myPoint.X - (sideLength / 2), myPoint.Y + (sideLength / 2)); 
            points[2] = new Point(myPoint.X + (sideLength / 2), myPoint.Y + (sideLength / 2)); 

            myGraphics.DrawPolygon(myPen, points);
        }
        /// <summary>
        /// Draws the triangle shape.
        /// </summary>
        /// <param name="myGraphics">The graphics object to draw the triangle.</param>
        /// <param name="myPoint">The point where the triangle is to be drawn.</param>
        public MyTriangle(Color myColor, int myX, int myY, int sideLength) : base(myColor, myX, myY)
        {
            this.sideLength = sideLength;
           

        }
    }
}
