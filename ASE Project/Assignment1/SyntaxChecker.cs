using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Assignment1
{

    public class SyntaxChecker
    {


        public void parseCheck(Drawer myCanvas, int num, int x)
        {
            //create font for Error message
            Font errortxtFont = new Font("Arial", 10);
            //create Solid brush for Error message with color black
            SolidBrush errortxtBrush = new SolidBrush(Color.Black);
            num++;
            if (num != 0)
            {
                if (x == 0)
                {
                    //Reset Draw if error not found
                    myCanvas.Reset();
                }
                 //Display Error if parse on particular line does not exit
                 // myCanvas.g.DrawString("parse on line " + (num) + " does not exist", errortxtFont, errortxtBrush, 0, 0 + x);
            }
            else
            {
                //Display Error if parse does not exit
                myCanvas.g.DrawString("parse does not exist", errortxtFont, errortxtBrush, 0, 0);
            }
            //sets the error to true
            myCanvas.error = true;

        }



        public void ParameterCheck(bool parameter, String data, int num, Drawer myCanvas, int x)
        {
            //Gives error message when entered Parameter will be Invalid
            if (!parameter)
            {
                Font errortxtFont = new Font("Arial", 10);
                SolidBrush errortxtBrush = new SolidBrush(Color.Black);
                if (x == 0)
                {
                    //Reset Draw if error not found
                    myCanvas.Reset();
                }
                if ((num + 1) == 0)
                {
                    //Display Error if parameter are Invalid
                    myCanvas.g.DrawString("Paramater " + data + " is invalid", errortxtFont, errortxtBrush, 0, 0 + x);
                }
                else
                {
                    //Display Error if parameter are Invalid for Multi line parse
                    myCanvas.g.DrawString("Paramater " + data + " on line " + (num + 1) + " is invalid", errortxtFont, errortxtBrush, 0, 0 + x);
                }
                //Sets the Error to true
                myCanvas.error = true;
            }
        }


        public void ParameterCheck(Exception e, int num, Drawer myCanvas, int x)
        {
            Font errortxtFont = new Font("Arial", 10);
            SolidBrush errortxtBrush = new SolidBrush(Color.Black);

            if (x == 0)
            {
                //Reset Draw if error not found
                myCanvas.Reset();
            }
            if ((num + 1) == 0)
            {
                //displays Error if number of parameters are invalid
                myCanvas.g.DrawString("Parameter entered is not valid on line", errortxtFont, errortxtBrush, 0, 0 + x);
            }
            else
            {
                //displays Error if number of parameters are invalid
                myCanvas.g.DrawString("Parameter entered is not valid on line" + (num + 1), errortxtFont, errortxtBrush, 0, 0 + x);
            }
            //sets the err to true
            myCanvas.error = true;
        }
    }
}