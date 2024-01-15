using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Metadata
    {
        String name;
        int year;
        string gameType;
        ProgramInfo[] emus;
        int lastIndex;
        int selectedIndex;

        public Metadata(string name, int year, string gameType, ProgramInfo[] emus, int lastIndex = 0, int selectedIndex = 0)
        {
            this.name = name;
            this.year = year;
            this.gameType = gameType;
            this.emus = emus;
            this.lastIndex = lastIndex;
            this.selectedIndex = selectedIndex;
        }

        public Metadata()
        {
            this.name = "";
            this.year=0;
            this.gameType = "";
            this.emus = new ProgramInfo[10];
            this.lastIndex=0;
            this.selectedIndex = 0;

            for (int i = 0; i < this.emus.Length; i++)
            {
                this.emus[i] = new ProgramInfo();
            }
        }

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string GameType { get => gameType; set => gameType = value; }
        public ProgramInfo[] Emus { get => emus; set => emus = value; }
        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        public void addEmu(ProgramInfo emu) 
        {
            this.emus[lastIndex] = emu;
            lastIndex++;
        }
    }
}
