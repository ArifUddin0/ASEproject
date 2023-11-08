using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    internal class MyCanvass
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
