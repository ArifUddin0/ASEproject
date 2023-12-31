﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    /// <summary>
    /// Represents the canvas that is being used for drawing shapes.
    /// </summary>
    public class MyCanvass
    {
        private List<string> executedCommands = new List<string>();
        private Graphics g;
        public Point p;
        private Bitmap myBitmap;
        public Point currentLocation;
        private Color currentPenColor = Color.Red;
        /// <summary>
        /// Draws a shape on the canvas.
        /// </summary>
        /// <param name="shape">The shape to be drawn.</param>
        public void DrawMyShape(MyShape shape)
        {
            shape.DrawMyShape(g, p);
            executedCommands.Add(shape.ToString()); 
            // Storing the command for now, assuming ToString() provides command details
        }
        /// <summary>
        /// Retrives the executed commands
        /// </summary>
        /// <returns></returns>
        public List<string> GetExecutedCommands()
        {
            return executedCommands;
        }
        /// <summary>
        /// Moves the drawing position to a specified location.
        /// </summary>
        /// <param name="x">The X-coordinate of the new position.</param>
        /// <param name="y">The Y-coordinate of the new position.</param>
        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);
            currentLocation = p;
        }
        /// <summary>
        /// Clears the canvas, resetting it to a blank page.
        /// </summary>
        public void Clear()
        {
            myBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);
            g = Graphics.FromImage(myBitmap);
        }
        /// <summary>
        /// Resets the canvas position to 0,0.
        /// </summary>
        public void Reset()
        {
            MoveTo(0, 0);
        }
       
        /// <summary>
        /// Draws a line from the current position to a specified point that you enter.
        /// </summary>
        /// <param name="x">The X-coordinate of the end point.</param>
        /// <param name="y">The Y-coordinate of the end point.</param>
        public void DrawTo(int x, int y)
        {
            Pen myPen = new Pen(currentPenColor, 5);
            g.DrawLine(myPen, p.X, p.Y, x, y);
            p = new Point(x, y);
            currentLocation = p;
        }

        /// <summary>
        /// Initializes a new instance of the MyCanvass class with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the canvas.</param>
        /// <param name="height">The height of the canvas.</param>
        public MyCanvass(int width, int height)
        {
            myBitmap= new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);

        }

        public MyCanvass()
        {
        }

        /// <summary>
        /// Gets the bitmap representation of the canvas.
        /// </summary>
        /// <returns>The bitmap of the canvas.</returns>
        public Bitmap GetBitmap()
        {
            return myBitmap;
        }

        /// <summary>
        /// Gets the current location of cusrsor
        /// </summary>
        /// <returns></returns>
        public Point GetCurrentLocation()
        {
            return currentLocation;
        }
        public void SetCurrentPenColor(Color color)
        {
             currentPenColor = color;
        }
    }
}
