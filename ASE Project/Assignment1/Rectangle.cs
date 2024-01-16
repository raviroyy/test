using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Created Rectangle class which is inherits from Shape class
    /// </summary>
    class Rectangle : Shape
    {
        //Decleare variable to instantiate
        public int height;
        public int width;

        /// <summary>
        /// constructor to initialize the instance of class
        /// </summary>
        /// <param name="x">x assign value on height</param>
        /// <param name="y">x assign value on width</param>
        public Rectangle(int x, int y) : base(x, y)
        {
            height = x;
            width = y;
        }

        /// <summary>
        /// This method holds specific Shape(Rectangle) to draw or also to fill on Shape
        ///  if Fill is on
        /// </summary>
        /// <param name="myCanvas">myCanvas holds Drawing area</param>
        public override void Drawer(Drawer myCanvas)
        {
            myCanvas.g.DrawRectangle(myCanvas.pen, myCanvas.xPos, myCanvas.yPos, width, height);

            //if this Expression is true i.e. fill on than Rectangle gets fill with colour provided by user 
            if (myCanvas.fill)
            {
                myCanvas.g.FillRectangle(myCanvas.brush, myCanvas.xPos, myCanvas.yPos, width, height);
            }
        }
    }
}