using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    ///  Created Circle class which is inherits from Shape class.
    /// This class hold method and properties for Drawing Circle
    /// </summary>
    class Circle : Shape
    {
        //Decleare variable to instantiate
        public int radius;

        /// <summary>
        ///  constructor to initialize the instance of class
        /// </summary>
        /// <param name="r">r holds radius of circle</param>
        public Circle(int r) : base(r, 0)
        {
            radius = r;
        }

        /// <summary>
        /// This method holds specific Shape(Circle) to draw or also to fill on Shape
        ///  if Fill is on
        /// </summary>
        /// <param name="myCanvas">myCanvas holds Drawing area</param>
        public override void Drawer(Drawer myCanvas)
        {
            myCanvas.g.DrawEllipse(myCanvas.pen, myCanvas.xPos, myCanvas.yPos, (radius * 2), (radius * 2));

            //if this Expression is true i.e. fill on than circle gets fill with colour provided by user 
            if (myCanvas.fill)
            {
                myCanvas.g.FillEllipse(myCanvas.brush, myCanvas.xPos, myCanvas.yPos, (radius * 2), (radius * 2));
            }
        }
    }
}