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

            if (curCell.ColumnIndex.Equals(1) && e.RowIndex != -1)
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

            if (curCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
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
                row.Cells[1].Value = LaunchContainer.launcher.Games[i].isActive;
                row.Cells[2].Value = LaunchContainer.launcher.Games[i].ExeLoc;
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

            if (LaunchContainer.launcher.Games[row.Index].GameType == "DRM Free")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Title = "Select " + row.Cells[0] + "'s Executable";
                    openFileDialog.Filter = "exe file (*.exe)|*.exe";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        row.Cells[2].Value = openFileDialog.FileName;
                    }
                }
            }

            if (LaunchContainer.launcher.Games[row.Index].GameType == "DRM Free")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Title = "Select " + row.Cells[0] + "'s Executable";
                    openFileDialog.Filter = "exe file (*.exe)|*.exe";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        row.Cells[2].Value = openFileDialog.FileName;
                    }
                }
            }







            return row.Cells[2].Value;
        }
    }
}
