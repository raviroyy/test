using Assignment1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public class TestProject
    {
        //Component 1
        [TestMethod]
        public void MultiLineParseTest()
        {

            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("run", "drawto 100,50", myDraw);
        }

        [TestMethod]
        public void MoveToTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("moveto 100,200", "", myDraw);

        }

        [TestMethod]
        public void RectangleTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("rectangle 20,50", "", myDraw);
            cmdSetup.CmdParse("square 10", "", myDraw);
        }


        // Component 2
        [TestMethod]
        public void VarStoreTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();
            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer MyDraws = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("value = 5", "", MyDraws);
        }

        [TestMethod]
        public void VarAppendTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();
            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;
            Assignment1.Drawer MyDraws = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("value = value + 2", "", MyDraws);
            cmdSetup.CmdParse("value = value - 2", "", MyDraws);
            cmdSetup.CmdParse("value = value / 2", "", MyDraws);
            cmdSetup.CmdParse("value = value * 2", "", MyDraws);
        }
        [TestMethod]
        public void CircleTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("circle 10", "", myDraw);
        }
        [TestMethod]
        public void ColorTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("pen black", "", myDraw);
        }
        [TestMethod]
        public void FillTest()
        {
            Assignment1.Form1 form = new Assignment1.Form1();

            Assignment1.CommandParser cmdSetup = new Assignment1.CommandParser();
            Bitmap outBitmap = form.myBitmap;

            Assignment1.Drawer myDraw = new Assignment1.Drawer(Graphics.FromImage(outBitmap));
            cmdSetup.CmdParse("fill on", "", myDraw);
        }
    }
}