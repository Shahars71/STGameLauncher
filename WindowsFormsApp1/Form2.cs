using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2() //Settings menu
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Set path to Steam, from which I can find all Steam
        {
            DialogResult loc = folderBrowserDialog1.ShowDialog();
            if (loc == DialogResult.OK)
            {
                LaunchContainer.launcher.SteamLoc = folderBrowserDialog1.SelectedPath;
                textBox1.Text = LaunchContainer.launcher.SteamLoc;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Set path to HedgeModManager EXE
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select HedgeModManager's Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.HmmLoc = openFileDialog.FileName;
                    textBox2.Text = LaunchContainer.launcher.HmmLoc;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Set path to SADX Mod Manager's EXE
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select SADX Mod Manager's Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.SadxMMLoc = openFileDialog.FileName;
                    textBox3.Text = LaunchContainer.launcher.SadxMMLoc;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //Save button
        {
            LaunchContainer.launcher.manageGames(); //Update static container with set paths
            SaveHandler.Save();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = LaunchContainer.launcher.SteamLoc;
            textBox2.Text = LaunchContainer.launcher.HmmLoc;
            textBox3.Text = LaunchContainer.launcher.SadxMMLoc;
        }
    }
}
