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

            if (curCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
                if (LaunchContainer.launcher.Games[curCell.RowIndex].isActive)
                {
                    LaunchContainer.launcher.Games[curCell.RowIndex].deActivate();
                }

                else
                {
                    LaunchContainer.launcher.Games[curCell.RowIndex].activate();
                }

                dataGridView1.CurrentCell.Value = LaunchContainer.launcher.Games[curCell.RowIndex].isActive;
                LaunchContainer.launcher.checkActives();
            }

            if (curCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
                LaunchContainer.launcher.Games[curCell.RowIndex].ExeLoc = (string)getFilePath(dataGridView1.CurrentRow);
            }
        }

        
        private void initListView()
        {

            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
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

        private void Form4_Leave(object sender, EventArgs e)
        {
            LaunchContainer.launcher.manageGames();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private object getFilePath(DataGridViewRow row)
        {

            switch(LaunchContainer.launcher.Games[row.Index].GameType)
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
    }
}
