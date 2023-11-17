using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game[] gameList = LaunchContainer.launcher.Games;
            
            for (int i=0;i<gameList.Length;i++)
            {
                GameButton b = new GameButton(gameList[i]);

                if (LaunchContainer.launcher.ActiveGames[i])
                {
                    flowLayoutPanel1.Controls.Add(b);
                }
                
            }

            SaveHandler.Load();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 options = new Form2();
            options.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
