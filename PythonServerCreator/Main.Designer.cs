
namespace PythonServerCreator
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FunctionNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddedFunctionsListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddedParametersListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ParameterNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ParameterTypeCombox = new System.Windows.Forms.ComboBox();
            this.AddParameterButton = new System.Windows.Forms.Button();
            this.ReturnTypeCombox = new System.Windows.Forms.ComboBox();
            this.GenerateServerButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HostnameTextbox = new System.Windows.Forms.TextBox();
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FunctionNameTextBox
            // 
            this.FunctionNameTextBox.Location = new System.Drawing.Point(28, 45);
            this.FunctionNameTextBox.Name = "FunctionNameTextBox";
            this.FunctionNameTextBox.Size = new System.Drawing.Size(190, 23);
            this.FunctionNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Function name:";
            // 
            // AddedFunctionsListBox
            // 
            this.AddedFunctionsListBox.FormattingEnabled = true;
            this.AddedFunctionsListBox.ItemHeight = 15;
            this.AddedFunctionsListBox.Location = new System.Drawing.Point(28, 193);
            this.AddedFunctionsListBox.Name = "AddedFunctionsListBox";
            this.AddedFunctionsListBox.Size = new System.Drawing.Size(841, 229);
            this.AddedFunctionsListBox.TabIndex = 2;
            this.AddedFunctionsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddedFunctionsListBox_KeyDown);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(28, 102);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(401, 49);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add Function";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(928, 235);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(206, 53);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Return Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(938, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current parameters:";
            // 
            // AddedParametersListBox
            // 
            this.AddedParametersListBox.FormattingEnabled = true;
            this.AddedParametersListBox.ItemHeight = 15;
            this.AddedParametersListBox.Location = new System.Drawing.Point(938, 45);
            this.AddedParametersListBox.Name = "AddedParametersListBox";
            this.AddedParametersListBox.Size = new System.Drawing.Size(184, 139);
            this.AddedParametersListBox.TabIndex = 8;
            this.AddedParametersListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddedParametersListBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Parameter Name:";
            // 
            // ParameterNameTextBox
            // 
            this.ParameterNameTextBox.Location = new System.Drawing.Point(473, 45);
            this.ParameterNameTextBox.Name = "ParameterNameTextBox";
            this.ParameterNameTextBox.Size = new System.Drawing.Size(190, 23);
            this.ParameterNameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(689, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Parameter Type:";
            // 
            // ParameterTypeCombox
            // 
            this.ParameterTypeCombox.FormattingEnabled = true;
            this.ParameterTypeCombox.Location = new System.Drawing.Point(689, 45);
            this.ParameterTypeCombox.Name = "ParameterTypeCombox";
            this.ParameterTypeCombox.Size = new System.Drawing.Size(180, 23);
            this.ParameterTypeCombox.TabIndex = 12;
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(473, 102);
            this.AddParameterButton.Name = "AddParameterButton";
            this.AddParameterButton.Size = new System.Drawing.Size(396, 49);
            this.AddParameterButton.TabIndex = 13;
            this.AddParameterButton.Text = "Add Parameter";
            this.AddParameterButton.UseVisualStyleBackColor = true;
            this.AddParameterButton.Click += new System.EventHandler(this.AddParameterButton_Click);
            // 
            // ReturnTypeCombox
            // 
            this.ReturnTypeCombox.FormattingEnabled = true;
            this.ReturnTypeCombox.Location = new System.Drawing.Point(249, 45);
            this.ReturnTypeCombox.Name = "ReturnTypeCombox";
            this.ReturnTypeCombox.Size = new System.Drawing.Size(180, 23);
            this.ReturnTypeCombox.TabIndex = 14;
            // 
            // GenerateServerButton
            // 
            this.GenerateServerButton.Location = new System.Drawing.Point(928, 339);
            this.GenerateServerButton.Name = "GenerateServerButton";
            this.GenerateServerButton.Size = new System.Drawing.Size(206, 53);
            this.GenerateServerButton.TabIndex = 15;
            this.GenerateServerButton.Text = "Generate Server!";
            this.GenerateServerButton.UseVisualStyleBackColor = true;
            this.GenerateServerButton.Click += new System.EventHandler(this.GenerateServerButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Server settings:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Hostname:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 519);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Port:";
            // 
            // HostnameTextbox
            // 
            this.HostnameTextbox.Location = new System.Drawing.Point(99, 516);
            this.HostnameTextbox.Name = "HostnameTextbox";
            this.HostnameTextbox.Size = new System.Drawing.Size(193, 23);
            this.HostnameTextbox.TabIndex = 19;
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(336, 516);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(91, 23);
            this.PortTextbox.TabIndex = 20;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 565);
            this.Controls.Add(this.PortTextbox);
            this.Controls.Add(this.HostnameTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GenerateServerButton);
            this.Controls.Add(this.ReturnTypeCombox);
            this.Controls.Add(this.AddParameterButton);
            this.Controls.Add(this.ParameterTypeCombox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ParameterNameTextBox);
            this.Controls.Add(this.AddedParametersListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddedFunctionsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionNameTextBox);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FunctionNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AddedFunctionsListBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox AddedParametersListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ParameterNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ParameterTypeCombox;
        private System.Windows.Forms.Button AddParameterButton;
        private System.Windows.Forms.ComboBox ReturnTypeCombox;
        private System.Windows.Forms.Button GenerateServerButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HostnameTextbox;
        private System.Windows.Forms.TextBox PortTextbox;
    }
}

