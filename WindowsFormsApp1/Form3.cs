using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

            if (!(curGame.HasEmulator && curGame.HasModLoader))
            {
                Size = new Size(420, 180);
                button3.Enabled = false;
                button3.Visible = false;
            }

            if (curGame.HasEmulator)
            {
                ComponentButton.Text = "Launch " + curGame.EmulatorName + " Emulator";
            }

            if (curGame.HasModLoader)
            {
                if (button3.Enabled)
                {
                    button3.Text = "Launch " + curGame.ModLoaderName;
                }
                else
                {
                    ComponentButton.Text = "Launch " + curGame.ModLoaderName;
                }
            }

            if (!CurGame.HasEmulator && !CurGame.HasModLoader) 
            {
                ComponentButton.Enabled = false;
                ComponentButton.Visible = false;

                button2.Location = new Point(140, 73);
            }



        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //launch modloader
        {
            start_ModLoader();
        }

        private void button2_Click(object sender, EventArgs e) //launch game
        {
            //string gamePath = Path.Combine(new[] { LaunchContainer.launcher.SteamLoc, CurGame.ExeLoc });
            if (CurGame.HasEmulator)
            {
                start_EmulatedGame();
            }
            else
            {
                start_GameStdExe();
            }
        }

        private void start_ModLoader()
        {
            System.Diagnostics.Process.Start(CurGame.ModLoaderLoc);
        }

        private void start_Emulator()
        {
            System.Diagnostics.Process.Start(CurGame.EmulatorLoc);
        }

        private void start_EmulatedGame()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.Arguments = "\"" + CurGame.ExeLoc + "\"" + CurGame.EmuArgs;
            proc.FileName = CurGame.EmulatorLoc;

            Process.Start(proc);
        }

        private void start_GameStdExe()
        {
            System.Diagnostics.Process.Start(CurGame.ExeLoc);
        }

        private void ComponentButton_Click(object sender, EventArgs e)
        {
            if (CurGame.HasEmulator)
            {
                start_Emulator();
            }
            else if(CurGame.HasModLoader)
            {
                start_ModLoader();
            }
        }
    }
}
