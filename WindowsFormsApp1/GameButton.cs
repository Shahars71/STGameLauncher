using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //Special button that can contain game data
    //Specifically launches form 3 with the game data given to it
    //Thus making a way to get multiple form 3's with different data in them


    public class GameButton :Button
    {
        public Game assignedGame;
        public Form3 gameOps;


        public new event EventHandler<ButtonClickEventArgs> Click;


        public GameButton() { }

        //button creation is done programmatically using GameButton
        //so here I set the properties for a GameButton and the fact
        //that it creates a specific version of form3
        public GameButton(Game assignedGame)
        {
            this.assignedGame = assignedGame;
            this.Text = assignedGame.Meta.Name;
            gameOps = new Form3(assignedGame);
            this.Width = 100;
            this.Height = 50;
        }

        public new void PerformClick()
        {
            PerformClick(false);
        }
        public void PerformClick(bool value)
        {
            OnClick(new ButtonClickEventArgs(value));
        }

        protected override void OnClick(EventArgs e)
        {
            OnClick(new ButtonClickEventArgs(false));
        }

        protected virtual void OnClick(ButtonClickEventArgs e) //Override clicking code to open form3
        {
            gameOps.ShowDialog();
        }
    }
    public class ButtonClickEventArgs : EventArgs
    {
        private bool m_Value;

        public ButtonClickEventArgs(bool value)
        {
            m_Value = value;
        }
        public bool Value
        {
            get { return m_Value; }
        }
    }
}

