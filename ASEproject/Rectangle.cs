using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    internal class MyRectangle:MyShape
    {
         
          protected int height;
          protected int width;

        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
            {
                Pen myPen = new Pen(myColor, 2);
                myGraphics.DrawRectangle(myPen, myPoint.X, myPoint.Y, height, width);
            }
          public MyRectangle(Color myColor, int myX, int myY, int height, int width) : base(myColor, myX, myY)
        {
            this.height = height;
            this.width = width;
                
        }


        }
    }

