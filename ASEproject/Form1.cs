using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap = new Bitmap(640, 480);
        Boolean mouseDown = false;
        Pen pen;
        Canvass canvas;
        String command;
        

        public Form1()
        {
            InitializeComponent();
           
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Perform the "Save" action here
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string textToSave = "Command... "; // Replace with command
                    string filePath = saveFileDialog.FileName;
                    System.IO.File.WriteAllText(filePath, textToSave);
                    MessageBox.Show("Command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string commandsToLoad = System.IO.File.ReadAllText(selectedFilePath);
                    textBoxCommand.Text = commandsToLoad;
                }
            }
        }
        private CommandParser commandProcessor = new CommandParser();

        private void runButton_Click(object sender, EventArgs e)
        {
            // Retrieve the command from the textBoxCommand
            string command = textBoxCommand.Text;

            // Create a graphics object for drawing on the graphicPanel
            Graphics g = graphicPanel.CreateGraphics();

            // Takes the command then processes it and executes it
           // commandProcessor.ProcessCommand(command, g);

            g.Dispose();

            // Invalidate the graphicPanel to trigger a repaint
            graphicPanel.Invalidate();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Button 2 pressed");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // get graphics content form
            g.DrawImageUnscaled(myBitmap, 0, 0); //put the off screen bitmap to the form
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;
            Graphics g = Graphics.FromImage(myBitmap); //get graphics context off of screen bitmap
            Refresh(); //system should update the display
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void textBoxCommand_TextChanged(object sender, EventArgs e)
        {
            // Retrieve the command from the text box
            string command = textBoxCommand.Text;

            // Create a graphics object for drawing on the graphicPanel
            Graphics g = graphicPanel.CreateGraphics();

            // Process and execute the command
           // commandProcessor.ProcessCommand(command, g);

            g.Dispose();

            // Invalidate the graphicPanel to trigger a repaint
            graphicPanel.Invalidate();

        }

        private void graphicPanel_Paint(object sender, PaintEventArgs e)
        {
            // Your drawing code using e.Graphics here
            // For example, draw a line from (0, 0) to (100, 100)
            //using (Pen pen = new Pen(Color.Black)) 
            //{
             //   e.Graphics.DrawLine(pen, 0, 0, 100, 100);
          //  }

        }


        private void commandPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}




