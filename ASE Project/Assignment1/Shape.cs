using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    abstract class Shape
    {
        //Decleare variable to instantiate
        int height;
        int width;

        public Shape(int x, int y)
        {
            height = x;
            width = y;
        }


        public abstract void Drawer(Drawer myCanvas);

    }
}