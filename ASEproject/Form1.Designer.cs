using System;

namespace ASEproject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.syntaxButton = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.graphicPanel = new System.Windows.Forms.Panel();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.openButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Location = new System.Drawing.Point(39, 422);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(124, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // syntaxButton
            // 
            this.syntaxButton.BackColor = System.Drawing.Color.Transparent;
            this.syntaxButton.Location = new System.Drawing.Point(409, 422);
            this.syntaxButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.syntaxButton.Name = "syntaxButton";
            this.syntaxButton.Size = new System.Drawing.Size(116, 52);
            this.syntaxButton.TabIndex = 1;
            this.syntaxButton.Text = "Syntax";
            this.syntaxButton.UseVisualStyleBackColor = false;
            this.syntaxButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(39, 382);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(486, 26);
            this.textBoxCommand.TabIndex = 2;
            this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
            // 
            // graphicPanel
            // 
            this.graphicPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.graphicPanel.Location = new System.Drawing.Point(698, 18);
            this.graphicPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphicPanel.Name = "graphicPanel";
            this.graphicPanel.Size = new System.Drawing.Size(486, 332);
            this.graphicPanel.TabIndex = 3;
            this.graphicPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicPanel_Paint);
            // 
            // commandPanel
            // 
            this.commandPanel.BackColor = System.Drawing.SystemColors.Control;
            this.commandPanel.Location = new System.Drawing.Point(39, 18);
            this.commandPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(488, 332);
            this.commandPanel.TabIndex = 4;
            this.commandPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.commandPanel_Paint);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(171, 422);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(124, 51);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(611, 407);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(135, 67);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "runButton";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1410, 542);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.graphicPanel);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.syntaxButton);
            this.Controls.Add(this.saveButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button syntaxButton;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Panel graphicPanel;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Button openButton;
        private EventHandler form1_Load;

        public EventHandler GetForm1_Load()
        {
            return form1_Load;
        }

        private void SetForm1_Load(EventHandler value)
        {
            form1_Load = value;
        }

        private System.Windows.Forms.Button runButton;
    }
}

