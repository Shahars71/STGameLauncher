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

        private int[] showFlags;
        private TabPage[] pages;

        public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            showFlags = new int[tabControl1.TabCount];
            pages = new TabPage[tabControl1.TabCount];


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                pages[i] = tabControl1.TabPages[i];
            }

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
            LaunchContainer.launcher.checkActives();
            handleButtons();
        }

        private void handleButtons()
        {
            Game[] gameList = LaunchContainer.launcher.Games;

            refreshPageCounts();
            LaunchContainer.incrementGameTypes();
            gameTypesToTabs();

            for (int i = 0; i < gameList.Length; i++)
            {
                GameButton b = new GameButton(gameList[i]);

                if (LaunchContainer.launcher.ActiveGames[i])
                {
                    addButtonToSpecificTab(b);
                }
            }



            if (pages != null)
            {

                for (int i = showFlags.Length-1; i >= 0 ;i--)
                {
                    if (showFlags[i] <= 0 && tabControl1.Contains(pages[i]))
                    {
                        tabControl1.Controls.Remove(pages[i]);
                    }
                    if (showFlags[i] > 0)
                    {
                        if (!tabControl1.Controls.Contains(pages[i]))
                        {
                            tabControl1.Controls.Add(pages[i]);
                        }
                    }
                }
            }
        }
        private void refreshPageCounts()
        {
            for (int i = 0; i < showFlags.Length;i++)
            {
                showFlags[i] = 0;
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
        
        private void buttonTickPos(GameButton b)
        {
            var gameType = b.assignedGame.GameType;

            switch (gameType)
            {
                case "Steam":
                    showFlags[0]++;
                    break;

                case "Epic Games Store":
                    showFlags[1]++;
                    break;

                case "Sega PC Reloaded":
                case "DRM Free":
                    showFlags[2]++;
                    break;

                case "Sega Mega Drive":
                    showFlags[3]++;
                    break;

                case "Sega Master System":
                    showFlags[4]++;
                    break;

                case "Sega Game Gear":
                    showFlags[5]++;
                    break;

                case "Sega Saturn":
                    showFlags[6]++;
                    break;

                case "Sega Dreamcast":
                    showFlags[7]++;
                    break;

                case "Arcade (MAME)":
                case "Arcade (Sega AM2)":
                    showFlags[8]++;
                    break;

                case "Nintendo GameCube":
                    showFlags[9]++;
                    break;

                case "Nintendo Wii":
                    showFlags[10]++;
                    break;

                case "Nintendo Wii U":
                    showFlags[11]++;
                    break;

                case "Nintendo Switch":
                    showFlags[12]++;
                    break;

                case "Sony PlayStation 2":
                    showFlags[13]++;
                    break;

                case "Sony Playstation 3":
                    showFlags[14]++;
                    break;

                case "Microsoft XBox":
                    showFlags[15]++;
                    break;

                case "Microsoft XBox 360":
                    showFlags[16]++;
                    break;

                case "Game Boy Advance":
                    showFlags[17]++;
                    break;

                case "Nintendo DS":
                    showFlags[18]++;
                    break;

                case "Nintendo 3DS":
                    showFlags[19]++;
                    break;

                case "Neo Geo Pocket Color":
                case "PlayStation Portable":
                    showFlags[20]++;
                    break;


                default: break;
            }
        }
        private void buttonTickNeg(GameButton b)
        {
            var gameType = b.assignedGame.GameType;

            switch (gameType)
            {
                case "Steam":
                    showFlags[0]--;
                    break;

                case "Epic Games Store":
                    showFlags[1]--;
                    break;

                case "Sega PC Reloaded":
                case "DRM Free":
                    showFlags[2]--;
                    break;

                case "Sega Mega Drive":
                    showFlags[3]--;
                    break;

                case "Sega Master System":
                    showFlags[4]--;
                    break;

                case "Sega Game Gear":
                    showFlags[5]--;
                    break;

                case "Sega Saturn":
                    showFlags[6]--;
                    break;

                case "Sega Dreamcast":
                    showFlags[7]--;
                    break;

                case "Arcade (MAME)":
                case "Arcade (Sega AM2)":
                    showFlags[8]--;
                    break;

                case "Nintendo GameCube":
                    showFlags[9]--;
                    break;

                case "Nintendo Wii":
                    showFlags[10]--;
                    break;

                case "Nintendo Wii U":
                    showFlags[11]--;
                    break;

                case "Nintendo Switch":
                    showFlags[12]--;
                    break;

                case "Sony PlayStation 2":
                    showFlags[13]--;
                    break;

                case "Sony Playstation 3":
                    showFlags[14]--;
                    break;

                case "Microsoft XBox":
                    showFlags[15]--;
                    break;

                case "Microsoft XBox 360":
                    showFlags[16]--;
                    break;

                case "Game Boy Advance":
                    showFlags[17]--;
                    break;

                case "Nintendo DS":
                    showFlags[18]--;
                    break;

                case "Nintendo 3DS":
                    showFlags[19]--;
                    break;

                case "Neo Geo Pocket Color":
                case "PlayStation Portable":
                    showFlags[20]--;
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

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void gameTypesToTabs()
        {
            int[] gt = LaunchContainer.activeGameTypes;

            for (int i = 0; i < LaunchContainer.activeGameTypes.Length;i++)
            {
                switch (i)
                {
                    case 0:
                        if (gt[i] > 0)
                            showFlags[0]++;
                        break;

                    case 1:
                        if (gt[i] > 0)
                            showFlags[1]++;
                        break;

                    case 23:
                    case 2:
                        if (gt[i] > 0)
                            showFlags[2]++;
                        break;

                    case 3:
                        if (gt[i] > 0)
                            showFlags[3]++;
                        break;

                    case 4:
                        if (gt[i] > 0)
                            showFlags[4]++;
                        break;

                    case 5:
                        if (gt[i] > 0)
                            showFlags[5]++;
                        break;

                    case 6:
                        if (gt[i] > 0)
                            showFlags[6]++;
                        break;

                    case 7:
                        if (gt[i] > 0)
                            showFlags[7]++;
                        break;

                    case 8:
                    case 9:
                        if (gt[i] > 0)
                            showFlags[8]++;
                        break;

                    case 10:
                        if (gt[i] > 0)
                            showFlags[9]++;
                        break;

                    case 11:
                        if (gt[i] > 0)
                            showFlags[10]++;
                        break;

                    case 12:
                        if (gt[i] > 0)
                            showFlags[11]++;
                        break;

                    case 13:
                        if (gt[i] > 0)
                            showFlags[12]++;
                        break;

                    case 14:
                        if (gt[i] > 0)
                            showFlags[13]++;
                        break;

                    case 15:
                        if (gt[i] > 0)
                            showFlags[14]++;
                        break;

                    case 16:
                        if (gt[i] > 0)
                            showFlags[15]++;
                        break;

                    case 17:
                        if (gt[i] > 0)
                            showFlags[16]++;
                        break;

                    case 19:
                        if (gt[i] > 0)
                            showFlags[17]++;
                        break;

                    case 20:
                        if (gt[i] > 0)
                            showFlags[18]++;
                        break;

                    case 21:
                        if (gt[i] > 0)
                            showFlags[19]++;
                        break;

                    case 18:
                    case 22:
                        if (gt[i] > 0)
                            showFlags[20]++;
                        break;


                    default: break;
                }
            }

            
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
