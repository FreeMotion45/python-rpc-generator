using PythonServerCreator.Declaration;
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

namespace PythonServerCreator
{
    public partial class Main : Form
    {
        private readonly string _framework_path = @"D:\Local\Programming\C#\python-rpc-generator\PythonCodeBase\";
        private readonly Dictionary<string, string> _typeMap;

        public Main()
        {
            InitializeComponent();            

            _typeMap = new Dictionary<string, string>()
            {
                { "none", "None" },
                { "integer", "int" },
                { "long", "int" },
                { "float", "float" },
                { "double", "float" },
                { "string", "str" },
                { "boolean", "bool" }
            };
            PopulateParameterTypes();
        }

        private void PopulateParameterTypes()
        {
            string[] types = _typeMap.Keys.ToArray();

            ParameterTypeCombox.Items.AddRange(types);
            ReturnTypeCombox.Items.AddRange(types);            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string functionName = FunctionNameTextBox.Text;
            if (IsStringEmpty(functionName))
            {
                return;
            }    

            string returnType = (string)ReturnTypeCombox.SelectedItem;
            if (returnType == null)
            {
                return;
            }

            FunctionParameter[] functionParameters = new FunctionParameter[AddedParametersListBox.Items.Count];
            for (int i = 0; i < AddedParametersListBox.Items.Count; i++)
            {
                functionParameters[i] = (FunctionParameter)AddedParametersListBox.Items[i];
            }

            FunctionDeclaration functionDecleration = new FunctionDeclaration(functionName, returnType, functionParameters);
            AddedFunctionsListBox.Items.Add(functionDecleration);

            FunctionNameTextBox.Text = "";
            ParameterNameTextBox.Text = "";
            AddedParametersListBox.Items.Clear();
        }

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            string parameterName = ParameterNameTextBox.Text;
            if (IsStringEmpty(parameterName))
            {
                return;
            }

            string selectedType = (string)ParameterTypeCombox.SelectedItem;
            if (selectedType == null)
            {
                return;
            }

            FunctionParameter parameter = new FunctionParameter(selectedType, parameterName);
            AddedParametersListBox.Items.Add(parameter);

            ParameterNameTextBox.Text = "";
        }

        private bool IsStringEmpty(string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }

        private void AddedParametersListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                AddedParametersListBox.Items.RemoveAt(AddedParametersListBox.SelectedIndex);
            }
        }

        private void AddedFunctionsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                AddedFunctionsListBox.Items.RemoveAt(AddedFunctionsListBox.SelectedIndex);
            }
        }

        private void GenerateServerButton_Click(object sender, EventArgs e)
        {
            FunctionDeclaration[] functionDeclarations = new FunctionDeclaration[AddedFunctionsListBox.Items.Count];
            for (int i = 0; i < AddedFunctionsListBox.Items.Count; i++)
            {
                functionDeclarations[i] = (FunctionDeclaration)AddedFunctionsListBox.Items[i];
            }

            CodeGenerator cg = new CodeGenerator(functionDeclarations, _typeMap);
            cg.GenerateServer(_framework_path, Path.Combine(Directory.GetCurrentDirectory(), "GeneratedServer"));
        }
    }
}
