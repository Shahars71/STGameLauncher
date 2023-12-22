using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveHandler.Load();
            handleButtons();
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

        private void games_Click(object sender, EventArgs e)
        {
            using (var newFrm = new Form4())
            {
                newFrm.ShowDialog();
            }

            SaveHandler.Save();

            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel2.Controls.Clear();
            this.flowLayoutPanel3.Controls.Clear();
            this.flowLayoutPanel4.Controls.Clear();
            this.flowLayoutPanel5.Controls.Clear();
            this.flowLayoutPanel6.Controls.Clear();
            this.flowLayoutPanel7.Controls.Clear();
            this.flowLayoutPanel8.Controls.Clear();
            this.flowLayoutPanel9.Controls.Clear();
            this.flowLayoutPanel10.Controls.Clear();
            this.flowLayoutPanel11.Controls.Clear();
            this.flowLayoutPanel12.Controls.Clear();
            this.flowLayoutPanel13.Controls.Clear();
            this.flowLayoutPanel14.Controls.Clear();
            this.flowLayoutPanel15.Controls.Clear();
            this.flowLayoutPanel16.Controls.Clear();
            this.flowLayoutPanel17.Controls.Clear();
            this.flowLayoutPanel18.Controls.Clear();
            this.flowLayoutPanel19.Controls.Clear();
            this.flowLayoutPanel20.Controls.Clear();
            this.flowLayoutPanel21.Controls.Clear();


            handleButtons();


        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            handleButtons();
        }

        private void handleButtons()
        {
            Game[] gameList = LaunchContainer.launcher.Games;

            for (int i = 0; i < gameList.Length; i++)
            {
                GameButton b = new GameButton(gameList[i]);

                if (LaunchContainer.launcher.ActiveGames[i])
                {
                    addButtonToSpecificTab(b);
                }

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void addButtonToSpecificTab(GameButton b)
        {
            var gameType = b.assignedGame.GameType;

            switch (gameType)
            {
                case "Steam":
                    flowLayoutPanel1.Controls.Add(b);
                    break;

                case "Epic Games Store":
                    flowLayoutPanel2.Controls.Add(b);
                    break;

                case "Sega PC Reloaded":
                case "DRM Free":
                    flowLayoutPanel3.Controls.Add(b);
                    break;

                case "Sega Mega Drive":
                    flowLayoutPanel4.Controls.Add(b);
                    break;

                case "Sega Master System":
                    flowLayoutPanel5.Controls.Add(b);
                    break;

                case "Sega Game Gear":
                    flowLayoutPanel6.Controls.Add(b);
                    break;

                case "Sega Saturn":
                    flowLayoutPanel7.Controls.Add(b);
                    break;

                case "Sega Dreamcast":
                    flowLayoutPanel8.Controls.Add(b);
                    break;

                case "Arcade (MAME)":
                case "Arcade (Sega AM2)":
                    flowLayoutPanel9.Controls.Add(b);
                    break;

                case "Nintendo GameCube":
                    flowLayoutPanel10.Controls.Add(b);
                    break;

                case "Nintendo Wii":
                    flowLayoutPanel11.Controls.Add(b);
                    break;

                case "Nintendo Wii U":
                    flowLayoutPanel12.Controls.Add(b);
                    break;

                case "Nintendo Switch":
                    flowLayoutPanel13.Controls.Add(b);
                    break;

                case "Sony PlayStation 2":
                    flowLayoutPanel14.Controls.Add(b);
                    break;

                case "Sony Playstation 3":
                    flowLayoutPanel15.Controls.Add(b);
                    break;

                case "Microsoft XBox":
                    flowLayoutPanel16.Controls.Add(b);
                    break;

                case "Microsoft XBox 360":
                    flowLayoutPanel17.Controls.Add(b);
                    break;

                case "Game Boy Advance":
                    flowLayoutPanel18.Controls.Add(b);
                    break;

                case "Nintendo DS":
                    flowLayoutPanel19.Controls.Add(b);
                    break;

                case "Nintendo 3DS":
                    flowLayoutPanel20.Controls.Add(b);
                    break;

                case "Neo Geo Pocket Color":
                case "PlayStation Portable":
                    flowLayoutPanel21.Controls.Add(b);
                    break;


                default: break;
            }
        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (Form6 specOps = new Form6())
            {
                specOps.ShowDialog();
            }
            SaveHandler.Save();
        }

        /*
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //handleButtons();
        }
        */
    }
}
