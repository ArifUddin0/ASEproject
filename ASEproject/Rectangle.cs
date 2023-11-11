using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// </summary>
    ///inherits properties from shape.cs
    /// </summary>
    public class MyRectangle:MyShape ///inherits properties from shape.cs
    {
        /// </summary>
        /// The height and width of the rectangle
        /// </summary>

        protected int height;
          protected int width;

        /// </summary>
        /// Draws the rectangle on the provided graphics with specified dimensions.
        /// </summary>
        /// <param name="myGraphics">The graphics of object to draw on.</param>
        /// <param name="myPoint">The position of rectangle.</param>
        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
            {
                Pen myPen = new Pen(myColor, 2);
                myGraphics.DrawRectangle(myPen, myPoint.X, myPoint.Y, height, width);
            }

        /// </summary>
        /// Initializes a new instance of the MyRectangle class with a specified color, position, height, and width.
        /// </summary>
        /// <param name="myColor">The color of the rectangle.</param>
        /// <param name="myX">The X-coordinate of the rectangle's position.</param>
        /// <param name="myY">The Y-coordinate of the rectangle's position.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        public MyRectangle(Color myColor, int myX, int myY, int height, int width) : base(myColor, myX, myY)
        {
            this.height = height;
            this.width = width;
                
        }


        }
    }

