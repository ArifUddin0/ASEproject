using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    internal class MyCircle : MyShape
    {
       
        protected int myRadius;

        public override void DrawMyShape(Graphics myGraphics, Point myPoint)
        {
            Pen myPen = new Pen(myColor, 2);
            myGraphics.DrawEllipse(myPen, myPoint.X, myPoint.Y, myRadius * 2, myRadius * 2);
        }
        public MyCircle(Color myColor, int myX, int myY, int myRadius) : base(myColor, myX, myY)
        {
           this.myRadius = myRadius;
        }

    
    }
}
