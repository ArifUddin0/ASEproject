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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.multiTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Location = new System.Drawing.Point(171, 10);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // syntaxButton
            // 
            this.syntaxButton.BackColor = System.Drawing.Color.Transparent;
            this.syntaxButton.Location = new System.Drawing.Point(119, 508);
            this.syntaxButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.syntaxButton.Name = "syntaxButton";
            this.syntaxButton.Size = new System.Drawing.Size(138, 119);
            this.syntaxButton.TabIndex = 1;
            this.syntaxButton.Text = "Syntax";
            this.syntaxButton.UseVisualStyleBackColor = false;
            this.syntaxButton.Click += new System.EventHandler(this.syntaxButton_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(2, 462);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(666, 26);
            this.textBoxCommand.TabIndex = 2;
            this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(675, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(826, 625);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(403, 11);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(85, 51);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(403, 508);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(142, 121);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // multiTextBox
            // 
            this.multiTextBox.Location = new System.Drawing.Point(13, 74);
            this.multiTextBox.Multiline = true;
            this.multiTextBox.Name = "multiTextBox";
            this.multiTextBox.Size = new System.Drawing.Size(656, 359);
            this.multiTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1502, 631);
            this.Controls.Add(this.multiTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.openButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button syntaxButton;
        private System.Windows.Forms.TextBox textBoxCommand;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox multiTextBox;
    }
}

