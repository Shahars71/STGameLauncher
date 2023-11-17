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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Game CurGame;
        public Form3(Game curGame) //Individual game menu
        {
            InitializeComponent();
            CurGame = curGame;
            label1.Text = curGame.GameName;
            button1.Text = "Launch " + curGame.ModLoaderName;
            button2.Text = "Launch " + curGame.GameName;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //launch modloader
        {
            System.Diagnostics.Process.Start(CurGame.ModLoaderLoc);
        }

        private void button2_Click(object sender, EventArgs e) //launch game
        {
            //string gamePath = Path.Combine(new[] { LaunchContainer.launcher.SteamLoc, CurGame.ExeLoc });
            System.Diagnostics.Process.Start(CurGame.ExeLoc);
        }
    }
}
