using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STGameLauncher
{
    public partial class SpecSettingsForm : Form
    {
        public SpecSettingsForm()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedEmu = comboBox1.Text;
            string args = textBox1.Text;

            if (selectedEmu == "")
                MessageBox.Show("Please select an emulated console!");
            else
                LaunchContainer.launcher.applyArgs(selectedEmu, args);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
            {
                if (LaunchContainer.launcher.Games[i].Meta.GameType == cmb_console.SelectedItem.ToString())
                {
                    LaunchContainer.launcher.Games[i].Meta.SelectedIndex = cmb_emul.SelectedIndex;
                }
            }
        }

        private void fillComboBox()
        {
            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
            {
                if (LaunchContainer.launcher.Games[i].hasEmulator)
                {
                    if (!cmb_console.Items.Contains(LaunchContainer.launcher.Games[i].meta.GameType))
                    {
                        cmb_console.Items.Add(LaunchContainer.launcher.Games[i].meta.GameType);
                    }
                }
            }

            cmb_console.SelectedIndex = 0;
        }

        private void cmb_console_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_emul.Items.Clear();

            for (int i = 0; i < LaunchContainer.launcher.Games.Length;i++)
            {
                if (LaunchContainer.launcher.Games[i].Meta.GameType == cmb_console.SelectedItem.ToString())
                {
                    for (int j = 0; j < LaunchContainer.launcher.Games[i].Meta.Emus.Length; j++)
                    {
                        if (LaunchContainer.launcher.Games[i].Meta.Emus[j].Name != "")
                        {
                            cmb_emul.Items.Add(LaunchContainer.launcher.Games[i].Meta.Emus[j].Name);
                        }
                    }
                    break;
                }
            }

            cmb_emul.SelectedIndex = 0;
        }

        private void cmb_emul_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }                
}
