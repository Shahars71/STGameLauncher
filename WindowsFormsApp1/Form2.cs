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
                openFileDialog.Title = "Select "+LaunchContainer.launcher.ModLoaders[0].Name+"'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[0].Location = openFileDialog.FileName;
                    textBox2.Text = LaunchContainer.launcher.ModLoaders[0].Location;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Set path to SADX Mod Manager's EXE
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select "+ LaunchContainer.launcher.ModLoaders[1].Name+"'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[1].Location = openFileDialog.FileName;
                    textBox7.Text = LaunchContainer.launcher.ModLoaders[1].Location;
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
            textBox2.Text = LaunchContainer.launcher.ModLoaders[0].Location;
            textBox3.Text = LaunchContainer.launcher.ModLoaders[1].Location;
        }

        private void ModLoaderTab_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void button10_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[2].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[2].Location = openFileDialog.FileName;
                    textBox3.Text = LaunchContainer.launcher.ModLoaders[2].Location;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[5].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[5].Location = openFileDialog.FileName;
                    textBox4.Text = LaunchContainer.launcher.ModLoaders[5].Location;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[6].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[6].Location = openFileDialog.FileName;
                    textBox8.Text = LaunchContainer.launcher.ModLoaders[6].Location;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[4].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[4].Location = openFileDialog.FileName;
                    textBox5.Text = LaunchContainer.launcher.ModLoaders[4].Location;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[9].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[9].Location = openFileDialog.FileName;
                    textBox9.Text = LaunchContainer.launcher.ModLoaders[9].Location;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[7].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[7].Location = openFileDialog.FileName;
                    textBox12.Text = LaunchContainer.launcher.ModLoaders[7].Location;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[8].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[8].Location = openFileDialog.FileName;
                    textBox10.Text = LaunchContainer.launcher.ModLoaders[8].Location;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[10].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[10].Location = openFileDialog.FileName;
                    textBox13.Text = LaunchContainer.launcher.ModLoaders[10].Location;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[11].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[11].Location = openFileDialog.FileName;
                    textBox11.Text = LaunchContainer.launcher.ModLoaders[11].Location;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[3].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[3].Location = openFileDialog.FileName;
                    textBox6.Text = LaunchContainer.launcher.ModLoaders[3].Location;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Select " + LaunchContainer.launcher.ModLoaders[2].Name + "'s Executable";
                openFileDialog.Filter = "exe file (*.exe)|*.exe";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LaunchContainer.launcher.ModLoaders[2].Location = openFileDialog.FileName;
                    textBox3.Text = LaunchContainer.launcher.ModLoaders[2].Location;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmulTab_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
