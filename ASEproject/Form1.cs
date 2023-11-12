using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// Constructor for the main form.
        /// </summary>
        public Form1()
        {
            InitializeComponent(); // Initializes the form component
            pen = new Pen(Color.Red, 5); // Initializes a Pen 
            canvas = new MyCanvass(300, 350); // Initializes the canvas

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Event handler to save the commands written in the text boxes.
        /// </summary>
        public void saveButton_Click(object sender, EventArgs e)
        {
            // Opens a 'Save File' dialog to choose a location to save the commands.
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string textToSave = string.Empty;
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*"; // Filters for files type.

                // If the single line textbox has content
                if (!string.IsNullOrWhiteSpace(textBoxCommand.Text))
                {
                    textToSave = textBoxCommand.Text;  // Assigns the content of the single line textbox.
                    saveFileDialog.ShowDialog(); // Shows the dialog for saving the file.
                    string filePath = saveFileDialog.FileName;  // Gets files path.

                    // If a file path is provided.
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        // Writes the content of the single line textbox to the selected file
                        System.IO.File.WriteAllText(filePath, textToSave); 
                        MessageBox.Show("Command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Shows a confirmation message for saving the command
                    }
                }
                // If the multi-line textbox has content
                else if (!string.IsNullOrWhiteSpace(multiTextBox.Text))
                {
                    textToSave = multiTextBox.Text; // Assigns the content of the multi-line textbox
                    saveFileDialog.ShowDialog();  // Shows the dialog for saving the file
                    string filePath = saveFileDialog.FileName; // Gets the file path

                    if (!string.IsNullOrEmpty(filePath)) // If a file path is provided
                    {
                        // Writes the content of the multi-line textbox to the selected file
                        System.IO.File.WriteAllText(filePath, textToSave); 
                        MessageBox.Show("Multi command saved successfully.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Shows a confirmation message for saving the command
                    }
                }
            }
        }

        /// <summary>
        /// Event handler to open and load commands from a selected text file.
        /// </summary>
        public void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";  // Filter for text files.
                if (openFileDialog.ShowDialog() == DialogResult.OK) // Opens file dialog to select a file.
                {
                    string selectedFilePath = openFileDialog.FileName; // Retrieves the selected file path.
                    string commandsToLoad = System.IO.File.ReadAllText(selectedFilePath); // Reads the content of the selected files.
                    textBoxCommand.Text = commandsToLoad; // Populates the single line textbox with the loaded commands
                    multiTextBox.Text = commandsToLoad; // Populates the multi line textbox with the loaded commands

                }
            }
            
        }

        /// <summary>
        /// Event handler for executing the command that are entered.
        /// </summary>
        private void runButton_Click(object sender, EventArgs e)
        {
            command = textBoxCommand.Text; // Gets the command from a single-line text box.

            MyCommandParser cp = new MyCommandParser(command, pen, canvas); //processes the command.

            Bitmap myBitmap = canvas.GetBitmap();
            pictureBox1.Image = myBitmap; // Updates the image based on the command processed.

            command = multiTextBox.Text;
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Gets the command from multi box text.

            foreach (var cmd in commands)
            {
                MyCommandParser commandprocessor = new MyCommandParser(cmd, pen, canvas); // Processes each multi-line command.
            }
            
        }

        /// <summary>
        /// Event handler for validating commands upon button click.
        /// </summary>
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

        public MemoryStream GetSavedStream()
        {
            // Assuming you've saved the content into a MemoryStream named 'savedStream'
            // Replace this with the actual stream where you save the content in your application.
            // Ensure the stream is accessible or store it in a field in your form.
            MemoryStream savedStream = new MemoryStream();
            return savedStream;
            // retrieve the stream containing the saved content.

            // Return the saved stream

        }
    }
}




