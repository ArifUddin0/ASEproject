using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    public class MyCanvass
    {
        private Graphics g;
        private Point p;
        private Bitmap myBitmap;

        public void DrawMyShape(MyShape shape)
        {
            shape.DrawMyShape(g, p);
        }
        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);    
        }
        public void Clear()
        {
            myBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);
            g = Graphics.FromImage(myBitmap);
        }
        public void Reset()
        {
            MoveTo(0, 0);
        }
        public void DrawTo(int x, int y)
        {
            Pen myPen = new Pen(Color.Red, 5);
            g.DrawLine(myPen, p.X, p.Y, x, y);
            p = new Point(x, y);
        }
        public MyCanvass(int width, int height)
        {
            myBitmap= new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);
        }
        public Bitmap GetBitmap()
        {
            return myBitmap;
        }

        

    }
}
