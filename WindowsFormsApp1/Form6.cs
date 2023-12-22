using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedEmu = comboBox1.Text;
            string args = textBox1.Text;

            if (selectedEmu == "")
                MessageBox.Show("Please select an emulated console!");
            else
                LaunchContainer.launcher.applyArgs(selectedEmu, args);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }                
}
