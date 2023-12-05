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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            initListView();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCell curCell = dataGridView1.CurrentCell;

            int index=0;

            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
            {
                if ((string)LaunchContainer.launcher.Games[i].GameType == (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value
                    && (string)LaunchContainer.launcher.Games[i].GameName == (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value)
                    index = i;
            }

            Console.WriteLine(index);

            if (curCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
                if (LaunchContainer.launcher.Games[index].isActive)
                {
                    LaunchContainer.launcher.Games[index].deActivate();
                }

                else
                {
                    LaunchContainer.launcher.Games[index].activate();
                }

                dataGridView1.CurrentCell.Value = LaunchContainer.launcher.Games[index].isActive;
                LaunchContainer.launcher.checkActives();
            }

            if (curCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
                try
                {
                    LaunchContainer.launcher.Games[index].ExeLoc = (string)getFilePath(dataGridView1.CurrentRow, index);
                }
                catch 
                {
                }
            }
        }

        
        private void initListView()
        {

            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
            {
                if (LaunchContainer.launcher.Games[i].GameName != "")
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = LaunchContainer.launcher.Games[i].GameName;
                    row.Cells[1].Value = LaunchContainer.launcher.Games[i].GameType;
                    row.Cells[2].Value = LaunchContainer.launcher.Games[i].isActive;
                    row.Cells[3].Value = LaunchContainer.launcher.Games[i].ExeLoc;
                    row.Cells[4].Value = LaunchContainer.launcher.Games[i].EmuArgs;
                    dataGridView1.Rows.Add(row);
                }
            }

            for (int i = 0; i < LaunchContainer.launcher.ModLoaders.Length; i++)
            {
                if (LaunchContainer.launcher.ModLoaders[i].Name != "")
                {
                    DataGridViewRow row2 = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                    row2.Cells[0].Value = "Mod Loader";
                    row2.Cells[1].Value = LaunchContainer.launcher.ModLoaders[i].Name;
                    row2.Cells[2].Value = LaunchContainer.launcher.ModLoaders[i].Location;
                    dataGridView2.Rows.Add(row2);
                }
            }

            for (int i = 0; i < LaunchContainer.launcher.Emulators.Length; i++)
            {
                if (LaunchContainer.launcher.Emulators[i].Name != "")
                {
                    DataGridViewRow row3 = (DataGridViewRow)(dataGridView2.Rows[0].Clone());
                    row3.Cells[0].Value = "Emulator";
                    row3.Cells[1].Value = LaunchContainer.launcher.Emulators[i].Name;
                    row3.Cells[2].Value = LaunchContainer.launcher.Emulators[i].Location;
                    dataGridView2.Rows.Add(row3);
                }
            }


        }

        private void Form4_Leave(object sender, EventArgs e)
        {
            LaunchContainer.launcher.manageGames();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private object getFilePath(DataGridViewRow row, int index)
        {

            switch(LaunchContainer.launcher.Games[index].GameType)
            {
                case "DRM Free":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s Executable";
                        openFileDialog.Filter = "exe file (*.exe)|*.exe";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Sega Mega Drive":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "md file (*.md)|*.md";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Sega Master System":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "sms file (*.sms)|*.sms";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Sega Game Gear":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "gg file (*.gg)|*.gg";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Sega Saturn":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "cue file (*.cue)|*.cue";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Sega Dreamcast":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "gdi file (*.gdi)|*.gdi";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Nintendo GameCube":
                case "Nintendo Wii":
                case "Sony PlayStation 2":
                case "PlayStation Portable":
                case "Microsoft XBox":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ISO file";
                        openFileDialog.Filter = "iso file (*.iso)|*.iso";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Nintendo Wii U":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "rpx file (*.rpx)|*.rpx";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Nintendo Switch":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "nsp file (*.nsp)|*.nsp";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Microsoft XBox 360":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "xex file (*.xex)|*.xex";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Neo Geo Pocket Color":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "ngc file (*.ngc)|*.ngc";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Game Boy Advance":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "gba file (*.gba)|*.gba";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Nintendo DS":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "nds file (*.nds)|*.nds";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Nintendo 3DS":

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[0] + "'s ROM file";
                        openFileDialog.Filter = "3ds file (*.3ds)|*.3ds";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[3].Value = openFileDialog.FileName;
                        }
                    }
                    break;



                case "Steam":
                case "Epic Games Store":
                case "Arcade (MAME)":
                case "Arcade (Sega AM2)":
                case "Sony Playstation 3":
                case "Sega PC Reloaded":

                    MessageBox.Show("No file path needed!");
                    break;









                default:
                    MessageBox.Show("No file path needed!");
                    row.Cells[3].Value = "";
                    break;

            }
            return row.Cells[3].Value;
        }

        private object getProgFilePath(DataGridViewRow row)
        {
            switch (row.Cells[0].Value)
            {
                case "Mod Loader":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[1].Value + "'s Executable";
                        openFileDialog.Filter = "exe file (*.exe)|*.exe";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[2].Value = openFileDialog.FileName;
                        }
                    }
                    break;

                case "Emulator":
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Title = "Select " + row.Cells[1].Value + " emulator";
                        openFileDialog.Filter = "exe file (*.exe)|*.exe";
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            row.Cells[2].Value = openFileDialog.FileName;
                        }
                    }
                    break;
            }

            return row.Cells[2].Value;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dataGridView2.CurrentCell;

            int index = 0;

            if ((string)dataGridView2.Rows[e.RowIndex].Cells[0].Value == "Mod Loader")
            {
                for (int i = 0; i < LaunchContainer.launcher.ModLoaders.Length; i++)
                {
                    if ((string)dataGridView2.Rows[e.RowIndex].Cells[1].Value == (string)LaunchContainer.launcher.ModLoaders[i].Name)
                    {
                        index = i; break;
                    }
                }
            }

            if ((string)dataGridView2.Rows[e.RowIndex].Cells[0].Value == "Emulator")
            {
                for (int i = 0; i < LaunchContainer.launcher.Emulators.Length; i++)
                {
                    if ((string)dataGridView2.Rows[e.RowIndex].Cells[1].Value == (string)LaunchContainer.launcher.Emulators[i].Name)
                    {
                        index = i; break;
                    }
                }
            }

            if (curCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
                if ((string)dataGridView2.Rows[e.RowIndex].Cells[0].Value == "Mod Loader")
                {
                    try
                    {
                        LaunchContainer.launcher.ModLoaders[index].Location = (string)getProgFilePath(dataGridView2.CurrentRow);
                    }
                    catch 
                    {
                        //LaunchContainer.launcher.ModLoaders[index].Location = "";
                    }
                }

                if ((string)dataGridView2.Rows[e.RowIndex].Cells[0].Value == "Emulator")
                {
                    try 
                    { 
                        LaunchContainer.launcher.Emulators[index].Location = (string)getProgFilePath(dataGridView2.CurrentRow);
                    }
                    catch
                    {
                        //LaunchContainer.launcher.Emulators[index].Location = "";
                    }
                }


            }
        }
    }
}
