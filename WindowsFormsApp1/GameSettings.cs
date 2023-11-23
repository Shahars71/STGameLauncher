using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class GameSettings
    {
        private System.Windows.Forms.Label name;
        private RadioButton active;
        private TextBox path;
        private Point startPos;

        public System.Windows.Forms.Label Name { get => name; set => name = value; }
        public RadioButton Active { get => active; set => active = value; }
        public TextBox Path { get => path; set => path = value; }

        public GameSettings(System.Windows.Forms.Label name, RadioButton active, TextBox path)
        {
            this.name = name;
            this.active = active;
            this.path = path;
        }

        public GameSettings(Game game)
        {
            name = new System.Windows.Forms.Label();
            active = new RadioButton();
            path = new TextBox();


            name.Text = game.GameName;
            active.Checked = game.IsActive;
        }
    }
}
