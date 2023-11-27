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
    public class MyCircle : MyShape 
    {
       /// <summary>
       /// radius of circle
       /// </summary>
        protected int myRadius;

        /// <summary>
        /// Draws the circle on the graphics context at the specified position.
        /// </summary>
        /// <param name="myGraphics">The graphics context to draw on.</param>
        /// <param name="myPoint">The position to draw the circle.</param>
      
        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
        {
            Pen myPen = new Pen(myColor, 2);
            myGraphics.DrawEllipse(myPen, myPoint.X, myPoint.Y, myRadius * 2, myRadius * 2);
        }
        /// <summary>
        /// Initializes a new instance of the MyCircle class with the specified color, position, and radius.
        /// </summary>
        /// <param name="myColor">Color of the circle.</param>
        /// <param name="myX">X-coordinate of the circle's position.</param>
        /// <param name="myY">Y-coordinate of the circle's position.</param>
        ///<param name="myRadius">Radius of the circle.</param>
        public MyCircle(Color myColor, int myX, int myY, int myRadius) : base(myColor, myX, myY)
        {
           this.myRadius = myRadius;
        }

    
    }
}
