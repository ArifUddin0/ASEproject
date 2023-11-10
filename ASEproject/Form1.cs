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
        Pen pen;
        MyCanvass canvas;
        String command;
        

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Red, 5);
            canvas = new MyCanvass(300, 350);
           
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Perform the "Save" action here
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string textToSave = textBoxCommand.Text;
                    string filePath = saveFileDialog.FileName;
                    System.IO.File.WriteAllText(filePath, textToSave);
                    MessageBox.Show("Command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
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
        

        private void runButton_Click(object sender, EventArgs e)
        {
            command = textBoxCommand.Text;

            MyCommandParser cp = new MyCommandParser(command, pen, canvas);

            Bitmap myBitmap = canvas.GetBitmap();
            pictureBox1.Image = myBitmap;

            command = multiTextBox.Text;
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var cmd in commands)
            {
                MyCommandParser commandprocessor = new MyCommandParser(cmd, pen, canvas);
            }
            
        }

        private void syntaxButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button 2 pressed");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
          
        }

        private void textBoxCommand_TextChanged(object sender, EventArgs e)
        {
         

        }

        

        
    }
}




