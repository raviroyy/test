using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment1
{
    /// <summary>
    /// This class hold method and properties that is required during drawing. The initial position of pen and 
    /// some useful method.
    /// </summary>
    public class Drawer
    {

        /// <summary>
        /// Create Instance data graphics
        /// </summary>
        public Graphics g;

        /// <summary>
        /// Create Instance for SoildBrush
        /// </summary>
        public SolidBrush brush;

        /// <summary>
        /// Create Instance for fill
        /// </summary>
        public bool fill = false;

        /// <summary>
        /// Create Instance for SyntaxChecker
        /// </summary>
        public SyntaxChecker checkSyntax;

        /// <summary>
        /// Create Instance for StoreMethod
        /// </summary>
        public StoreMethod storeMethod;

        /// <summary>
        /// Create Instance for VariableStorer
        /// </summary>
        public VariableStorer storeVariable;

        /// <summary>
        /// Create Instance for error
        /// </summary>
        public bool error = false;

        /// <summary>
        /// Create Instance for pen
        /// </summary>
        public Pen pen;

        /// <summary>
        /// public variable for xPos, yPos
        /// </summary>
        public int xPos, yPos;


        /// <summary>
        ///  constructor to initialize the instance of class
        /// </summary>
        /// <param name="g">g holds methods and properties to draw and fill graphics objects</param>
        public Drawer(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            storeVariable = new VariableStorer();
            storeMethod = new StoreMethod();
            checkSyntax = new SyntaxChecker();
            pen = new Pen(Color.Black, 1);//default pen with color and width
            g.DrawRectangle(pen, xPos, yPos, 1, 1);
            brush = new SolidBrush(Color.Black);
        }

        /// <summary>
        /// Draw line from current pen posiion
        /// </summary>
        /// <param name="toX">Position to draw</param>
        /// <param name="toY">Position to draw</param>
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(pen, xPos, yPos, toX, toY);//drawing line
            xPos = toX;
            yPos = toY; //pen position is moved at the end of line
        }

        /// <summary>
        /// Move from current position to given position
        /// </summary>
        /// <param name="toX">position to draw</param>
        /// <param name="toY">position to draw</param>
        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
            g.DrawRectangle(pen, xPos, yPos, 1, 1); //draw square
        }

        /// <summary>
        /// This method hold hold pen color that is Provided by user through parse
        /// </summary>
        /// <param name="colour">colour hold pen color that is given by user</param>
        public void Set_Pen_Color(Color colour)
        {
            pen = new Pen(colour, 1);
            brush = new SolidBrush(colour);
        }

        /// <summary>
        /// Reset Drawing area
        /// </summary>
        public void Reset()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);//default pen with constants
            g.Clear(SystemColors.Control);
            g.DrawRectangle(pen, xPos, yPos, 1, 1);
            storeVariable.Reset();
            storeMethod.Reset();
            error = false;
            fill = false;
        }

        /// <summary>
        /// Clear Drawing area
        /// </summary>
        public void Clear()
        {
            g.Clear(SystemColors.Control);
        }

    }


}