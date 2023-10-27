﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Perform the "Save" action here
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string textToSave = "This is the text you want to save."; // Replace with your text data
                    string filePath = saveFileDialog.FileName;
                    System.IO.File.WriteAllText(filePath, textToSave);
                    MessageBox.Show("Command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        }

        private void graphicPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commandPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
