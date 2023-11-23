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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Game game)
        {
            InitializeComponent();
            this.GameNameLbl.Text = game.GameName;
            this.radioButton1.Checked = game.IsActive;
            this.textBox1.Text = game.ExeLoc;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
