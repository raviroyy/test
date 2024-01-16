using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment1
{
    /// <summary>
    /// Created Triangle class which is inherits from Shape class.
    /// This class is responsible for drawing Triangle.
    /// </summary>
    class Triangle : Shape
    {
        //Decleare variable to instantiate
        public int baseValue;
        public int adjacent;
        public int hypotenuse;

        /// <summary>
        ///  constructor to initialize the instance of class
        /// </summary>
        /// <param name="x">x hold hypotenuse value provided by user</param>
        /// <param name="y">y hold base value provided by user</param>
        /// <param name="z">z hold adjacent value provided by user</param>
        public Triangle(int x, int y, int z) : base(x, y)
        {
            hypotenuse = x;
            baseValue = y;
            adjacent = z;
        }

        /// <summary>
        /// This method holds specific Shape(Triangle) to draw or also to fill on Shape
        ///  if Fill is on
        /// </summary>
        /// <param name="myCanvas">myCanvas holds Drawing area</param>
        public override void Drawer(Drawer myCanvas)
        {
            PointF a = new Point(myCanvas.xPos, myCanvas.yPos);
            PointF b = new Point(myCanvas.xPos, myCanvas.yPos + baseValue);
            PointF c = new PointF(myCanvas.xPos + adjacent, myCanvas.yPos + baseValue);
            PointF[] pnt = { a, b, c };

            if (myCanvas.fill)
            {
                myCanvas.g.FillPolygon(myCanvas.brush, pnt);//Draws a filled triangle if fill is true
            }
        }
    }
}