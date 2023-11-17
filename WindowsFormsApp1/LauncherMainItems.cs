using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace WindowsFormsApp1
{
    using System;
    using System.Collections;
    using System.IO;

    [Serializable]
    public class Game //Basic game values, contains all relevant names and paths
    {
        private String gameName;
        private String exeLoc;
        private String modLoaderLoc;
        private String modLoaderName;
        private bool isActive;


        public string GameName { get => gameName; set => gameName = value; }
        public string ExeLoc { get => exeLoc; set => exeLoc = value; }
        public string ModLoaderLoc { get => modLoaderLoc; set => modLoaderLoc = value; }
        public string ModLoaderName { get => modLoaderName; set => modLoaderName = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public Game(String name, String loc, String mlLoc, String mname)
        {
            GameName = name;
            ExeLoc = loc;
            ModLoaderLoc = mlLoc;
            ModLoaderName = mname;
            isActive = false;
        }

        public Game() :this("","","",""){ }
        public void activate () { isActive = true; }
    }

    [Serializable]
    public class LauncherMainItems //basic management of set paths and games
    {
        private const int numOfGames = 18;
        private Game[] games;
        private bool[] activeGames;
        private String steamLoc;
        private String hmmLoc;
        private String sadxMMLoc;


        public LauncherMainItems(Game[] games, string steamLoc, string hmmLoc, string sadxMMLoc, bool[] activeGames)
        {
            this.games = games;
            this.steamLoc = steamLoc;
            this.hmmLoc = hmmLoc;
            this.sadxMMLoc = sadxMMLoc;
            this.activeGames = activeGames;
        }

        public LauncherMainItems()
        {
            games = new Game[numOfGames];
            activeGames = new bool[numOfGames];

            for (int i = 0; i < games.Length; i++)
            {
                games[i] = new Game();
                
            }

            steamLoc = "";
            hmmLoc = "";
            sadxMMLoc = "";
            manageGames();
        }

        public Game[] Games { get => games; set => games = value; }
        public string SteamLoc { get => steamLoc; set => steamLoc = value; }
        public string HmmLoc { get => hmmLoc; set => hmmLoc = value; }
        public string SteamLoc1 { get => steamLoc; set => steamLoc = value; }
        public string HmmLoc1 { get => hmmLoc; set => hmmLoc = value; }
        public string SadxMMLoc { get => sadxMMLoc; set => sadxMMLoc = value; }
        public bool[] ActiveGames { get => activeGames; set => activeGames = value; }

        public void manageGames()
        {
            //---STEAM---

            games[0].GameName = "Sonic & Sega All Star Racing";
            games[0].ExeLoc = "steam://rungameid/34190";
            games[0].ModLoaderLoc = hmmLoc;
            games[0].ModLoaderName = "HedgeMod Manager";
            games[0].activate();

            games[1].GameName = "Sega Mega Drive & Genesis Classics";
            games[1].ExeLoc = "steam://rungameid/34270";
            games[1].ModLoaderLoc = hmmLoc;
            games[1].ModLoaderName = "HedgeMod Manager";
            games[1].activate();

            games[2].GameName = "Sonic the Hedgehog CD";
            games[2].ExeLoc = "steam://rungameid/200940";
            games[2].ModLoaderLoc = hmmLoc;
            games[2].ModLoaderName = "HedgeMod Manager";
            games[2].activate();

            games[3].GameName = "Sonic Adventure DX";
            games[3].ExeLoc = "steam://rungameid/71250";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe");
            games[3].ModLoaderLoc = sadxMMLoc;
            games[3].ModLoaderName = "SADX Mod Manager";
            games[3].activate();

            games[4].GameName = "Sonic Adventure 2 Battle";
            games[4].ExeLoc = "steam://rungameid/213610";
            games[4].ModLoaderLoc = hmmLoc;
            games[4].ModLoaderName = "HedgeMod Manager";
            games[4].activate();

            games[5].GameName = "Sonic Generations";
            games[5].ExeLoc = "steam://rungameid/71340";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe");
            games[5].ModLoaderLoc = hmmLoc;
            games[5].ModLoaderName = "HedgeMod Manager";
            games[5].activate();

            games[6].GameName = "Sonic the Hedgehog 4 Episode 1";
            games[6].ExeLoc = "steam://rungameid/202530";
            games[6].ModLoaderLoc = hmmLoc;
            games[6].ModLoaderName = "HedgeMod Manager";
            games[6].activate();

            games[7].GameName = "Sonic the Hedgehog 4 Episode 2";
            games[7].ExeLoc = "steam://rungameid/203650";
            games[7].ModLoaderLoc = hmmLoc;
            games[7].ModLoaderName = "HedgeMod Manager";
            games[7].activate();

            games[8].GameName = "Sonic & All Stars Racing Transformed";
            games[8].ExeLoc = "steam://rungameid/212480";
            games[8].ModLoaderLoc = hmmLoc;
            games[8].ModLoaderName = "HedgeMod Manager";
            games[8].activate();

            games[9].GameName = "Sonic Lost World";
            games[9].ExeLoc = "steam://rungameid/329440";
            games[9].ModLoaderLoc = hmmLoc;
            games[9].ModLoaderName = "HedgeMod Manager";
            games[9].activate();

            games[10].GameName = "Sonic Mania";
            games[10].ExeLoc = "steam://rungameid/584400";
            games[10].ModLoaderLoc = hmmLoc;
            games[10].ModLoaderName = "HedgeMod Manager";
            games[10].activate();

            games[11].GameName = "Sonic Forces";
            games[11].ExeLoc = "steam://rungameid/637100";
            games[11].ModLoaderLoc = hmmLoc;
            games[11].ModLoaderName = "HedgeMod Manager";
            games[11].activate();

            games[12].GameName = "Team Sonic Racing";
            games[12].ExeLoc = "steam://rungameid/785260";
            games[12].ModLoaderLoc = hmmLoc;
            games[12].ModLoaderName = "HedgeMod Manager";
            games[12].activate();

            games[13].GameName = "Sonic Colors: Ultimate";
            games[13].ExeLoc = "steam://rungameid/2055290";
            games[13].ModLoaderLoc = hmmLoc;
            games[13].ModLoaderName = "HedgeMod Manager";
            games[13].activate();

            games[14].GameName = "Sonic Origins";
            games[14].ExeLoc = "steam://rungameid/1794960";
            games[14].ModLoaderLoc = hmmLoc;
            games[14].ModLoaderName = "HedgeMod Manager";
            games[14].activate();


            games[15].GameName = "Sonic Frontiers";
            games[15].ExeLoc = "steam://rungameid/1237320";
            games[15].ModLoaderLoc = hmmLoc;
            games[15].ModLoaderName = "HedgeMod Manager";
            games[15].activate();


            games[16].GameName = "The Murder of Sonic The Hedgehog";
            games[16].ExeLoc = "steam://rungameid/2324650";
            games[16].ModLoaderLoc = hmmLoc;
            games[16].ModLoaderName = "HedgeMod Manager";
            games[16].activate();


            games[17].GameName = "Sonic Superstars";
            games[17].ExeLoc = "steam://rungameid/2022670";
            games[17].ModLoaderLoc = hmmLoc;
            games[17].ModLoaderName = "HedgeMod Manager";
            games[17].activate();






            for (int i = 0; i < games.Length; i++)
            {
                activeGames[i] = games[i].IsActive;
            }
        }
    }

    [Serializable]
    public static class LaunchContainer //Static version
    {
        public static LauncherMainItems launcher;

        static LaunchContainer() { launcher = new LauncherMainItems(); }
    }

    

}
