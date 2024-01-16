using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    /// <summary>
    /// Created FormA class which inherits from Form 
    /// This class holds methods and properties for a bitmap, slider, Menu bar, and Enter event on command prompt
    /// </summary>
    public partial class Form1 : Form
    {
        // Instance data for slide show
        int pnl_SlideWidth;
        bool Hided;

        // Bitmap to draw which will display on pictureBox
        const int bitmapX = 640;
        const int bitmapY = 480;
        public Bitmap myBitmap = new Bitmap(bitmapX, bitmapY);
        public Graphics g;

        Drawer myCanvas;

        public Form1()
        {
            InitializeComponent();
            myCanvas = new Drawer(Graphics.FromImage(myBitmap));
        }

        private void commandPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtainInstruction(); // Call ObtainInstruction Method
            }
        }

        public void ObtainInstruction()
        {
            String readCommand = commandPrompt.Text.Trim().ToLower(); // Fetch input of a single-line text field 
            String readMultiCommand1 = commandPannel1.Text.Trim().ToLower(); // Fetch input of the first multi-line text field 
            String readMultiCommand2 = commandPannel2.Text.Trim().ToLower(); // Fetch input of the second multi-line text field 
            CommandParser cmdSetup = new CommandParser();  // Creating object of Parser
            cmdSetup.CmdParse(readCommand, readMultiCommand1, myCanvas); // Calling a method of Parser and passing both text fields' input and also object of canvas
            cmdSetup.CmdParse(readCommand, readMultiCommand2, myCanvas); // Calling a method of Parser and passing both text fields' input and also object of canvas
            Refresh();
        }

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImageUnscaled(myBitmap, 0, 0);
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            ObtainInstruction();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                Canvas.Load(openFileDialog1.FileName);
            }
            catch (Exception)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                myBitmap.Save(saveFileDialog1.FileName);
            }
            catch (Exception)
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Application gets exited 
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This App helps us to draw shapes like " +
                   "\n" +
                   "\n" +
                  "circle, rectangle and triangle. " +
                   "\n" +
                   "\n" +
                  "Ravi Prakash Yadav  ©Copyright all right reserved" +
                   "\n" +
                   "\n" +
                  "", "About");
        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an application that lets you draw some basic shapes\n" +
                "Such as Circle, Rectangle and Triangle", "About");
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Terminate Application 
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Canvas.InitialImage = null;
            // Clear the canvas
            myCanvas.Clear();

            // Clear text in both command panels
            commandPannel1.Clear();
            commandPannel2.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("Manual of this application: \n" +
               "\n" +
              "\n" +

              "For Circle, Type circle <radius>  \n" +
               "\n" +
                 "\n" +

              "For Rectangle , Type  rectangle <width>, <height> \n" +
              "\n" +
                "\n" +

              "For pen or brush color type pen <colour>   \n" +
               "\n" +
                 "\n" +
              "To fill or unfill shapes type fill <on/off>\n" +
               "\n" +
                 "\n" +

              "To move write moveTo x y \n" +
               "\n" +
                 "\n" +
              "Write clear in textbox to clear drawing \n" +
               "\n" +
                 "\n" +

              "Write reset to move pen to initial position at the top of the screen", "Help");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void Canvas_Click_1(object sender, EventArgs e)
        {

        }
    }
}
