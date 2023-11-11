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
                string textToSave = string.Empty;
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*";

                if (!string.IsNullOrWhiteSpace(textBoxCommand.Text))
                {
                    textToSave = textBoxCommand.Text;
                    saveFileDialog.ShowDialog();
                    string filePath = saveFileDialog.FileName;

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        System.IO.File.WriteAllText(filePath, textToSave);
                        MessageBox.Show("Command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(multiTextBox.Text))
                {
                    textToSave = multiTextBox.Text;
                    saveFileDialog.ShowDialog();
                    string filePath = saveFileDialog.FileName;

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        System.IO.File.WriteAllText(filePath, textToSave);
                        MessageBox.Show("Multi command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    multiTextBox.Text = commandsToLoad;

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
            string codeSingle = textBoxCommand.Text; //gets code from the single line text box
            string codeMulti = multiTextBox.Text; //gets code from the multi line text box
            string[] codeList = { codeSingle, codeMulti }; //combination of both of them

            StringBuilder validationResults = new StringBuilder(); // starting a string builder to hold the validation reults 
            foreach (string code in codeList) //Goes through the commands given
            {
                string[] parts = code.Split(' '); // Command is split up into parts

                if (parts.Length > 0) //here it checks if commands contain any parts
                {
                    string command = parts[0];

                    try
                    {
                      

                        switch (command) //checking the command type 
                        {
                            case "moveto":
                                if (parts.Length == 3)
                                {
                                    if (int.TryParse(parts[1], out _) && int.TryParse(parts[2], out _)) //checks if the command is valid with correct parameters
                                    {
                                        validationResults.AppendLine("Valid 'moveto' command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter types for 'moveto'");
                                    }
                                }
                                else
                                {
                                    validationResults.AppendLine("Incorrect number of parameters for 'moveto'");
                                }
                                break;

                              case "circle":
                                if (parts.Length >= 2 && int.TryParse(parts[1], out _))
                                {
                                    validationResults.AppendLine("Valid 'circle' command");
                                }
                                else
                                {
                                    validationResults.AppendLine("Invalid 'circle' command or missing/invalid parameter");
                                }
                                break;

                            case "rectangle":
                                if (parts.Length == 3)
                                {
                                    if (int.TryParse(parts[1], out _) && int.TryParse(parts[2], out _))
                                    {
                                        validationResults.AppendLine("Valid 'rectangle' command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter(s) for 'rectangle' command");
                                    }
                                }
                              

                                    break;

                            case "triangle":
                                if (parts.Length == 2)
                                {
                                    if (int.TryParse(parts[1], out _))
                                    {
                                        validationResults.AppendLine("Valid 'triangle' command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter(s) for 'triangle' command");
                                    }
                                }
                                
                                break;


                            case "clear":

                                break;

                            case "reset":

                                break;

                            case "drawto":

                                if (parts.Length == 3)
                                {
                                    if (int.TryParse(parts[1], out _) && int.TryParse(parts[2], out _)) //checking if its valid command with correct parameters
                                    {
                                        validationResults.AppendLine("Valid 'drawto' command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter types for 'drawto'");
                                    }
                                }
                                else
                                {
                                    validationResults.AppendLine("Incorrect number of parameters for 'drawto'");
                                }
                                break;


                            default:
                                validationResults.AppendLine("Unrecognized command");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        validationResults.AppendLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    validationResults.AppendLine("Empty or invalid command");
                }
            }

            MessageBox.Show(validationResults.ToString(), "Syntax Validation Results"); //displays a message box wiht the validation results
        

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




