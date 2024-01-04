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
                switch (CurGame.EmulatorName)
                {
                    case "Arcade (MAME)":
                        start_EmulatedGameMame();
                        break;

                    case "Sega PC Reloaded":
                        start_GameSPCR();
                        break;


                    default:
                        ProgramInfo emu = LaunchContainer.launcher.getEmulFromGame(CurGame.GameName, CurGame.GameType);

                        if (emu.SpecFlag)
                        {
                            start_SpecEmulatedGame();
                        }
                        else
                        {
                            start_EmulatedGame();
                        }
                        break;
                }

            }
            else
            {
                start_GameStdExe();
            }
        }

        private void start_ModLoader()
        {
            try
            {
                System.Diagnostics.Process.Start(CurGame.ModLoaderLoc);
            }
            catch
            {
                MessageBox.Show("Mod Loader not found!\nMake sure you put the right file path!");
            }

        }

        private void start_Emulator()
        {
            try
            {
                System.Diagnostics.Process.Start(CurGame.EmulatorLoc);
            }
            catch
            {
                MessageBox.Show("Emulator not found!\nMake sure you put the right file path!");
            }
        }

        private void start_EmulatedGame()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Arguments = " \"" + CurGame.ExeLoc + "\" " + CurGame.EmuArgs;
                proc.FileName = CurGame.EmulatorLoc;
                proc.WorkingDirectory = CurGame.EmulatorLoc;

                Process.Start(proc);
            }
            catch
            {
                if (CurGame.EmulatorLoc == "")
                {
                    MessageBox.Show(CurGame.EmulatorName+" Emulator not found!");
                }
            }

        }

        private void start_GameSPCR()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();

                proc.Arguments = CurGame.EmuArgs;
                proc.FileName = CurGame.EmulatorLoc;
                proc.WorkingDirectory = CurGame.ExeLoc;

                Process.Start(proc);
            }
            catch
            {
                if (CurGame.EmulatorLoc == "")
                {
                    MessageBox.Show("Sega PC Reloaded not found!");
                }
            }

        }

        private void start_GameStdExe()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Arguments = CurGame.EmuArgs;
                proc.FileName = CurGame.ExeLoc;
                proc.WorkingDirectory = Path.GetDirectoryName(CurGame.ExeLoc);

                System.Diagnostics.Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Can't find exe file!");
            }
        }

        private void start_SpecEmulatedGame()
        {
            try
            {

                ProgramInfo emul = LaunchContainer.launcher.getEmulFromGame(CurGame.GameName, CurGame.GameType);


                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Arguments = " " + emul.SpecArgs + " \"" + CurGame.ExeLoc + "\" " + CurGame.EmuArgs;
                proc.FileName = CurGame.EmulatorLoc;
                proc.WorkingDirectory = CurGame.EmulatorLoc;

                Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Emulator not found!");
            }
        }

        private void start_EmulatedGameMame()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Arguments = /* "\"" + */ CurGame.ExeLoc /* + "\" "*/ + CurGame.EmuArgs;
                proc.FileName = CurGame.EmulatorLoc;
                proc.WorkingDirectory = CurGame.EmulatorLoc;

                Process.Start(proc);
            }
            catch
            {
                if (CurGame.EmulatorLoc == "")
                {
                    MessageBox.Show(CurGame.EmulatorName + " Emulator not found!");
                }
            }
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
