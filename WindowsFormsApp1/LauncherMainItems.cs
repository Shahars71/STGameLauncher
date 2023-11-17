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
    using System.Runtime.CompilerServices;

    [Serializable]
    public class Game //Basic game values, contains all relevant names and paths
    {
        private String gameName;
        private String exeLoc;
        private String modLoaderLoc;
        private String modLoaderName;
        private String emulatorLoc;
        private String emulatorName;
        private bool isActive;
        private bool hasModLoader;
        private bool hasEmulator;


        public string GameName { get => gameName; set => gameName = value; }
        public string ExeLoc { get => exeLoc; set => exeLoc = value; }
        public string ModLoaderLoc { get => modLoaderLoc; set => modLoaderLoc = value; }
        public string ModLoaderName { get => modLoaderName; set => modLoaderName = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string EmulatorLoc { get => emulatorLoc; set => emulatorLoc = value; }
        public string EmulatorName { get => emulatorName; set => emulatorName = value; }
        public bool HasModLoader { get => hasModLoader; set => hasModLoader = value; }
        public bool HasEmulator { get => hasEmulator; set => hasEmulator = value; }

        public Game(string gameName = null, string exeLoc = null, string modLoaderLoc = null, string modLoaderName = null, string emulatorLoc = null, string emulatorName = null, bool isActive = false, bool hasModLoader = false, bool hasEmulator = false)
        {
            this.gameName = gameName;
            this.exeLoc = exeLoc;
            this.modLoaderLoc = modLoaderLoc;
            this.modLoaderName = modLoaderName;
            this.emulatorLoc = emulatorLoc;
            this.emulatorName = emulatorName;
            this.isActive = isActive;
            this.hasModLoader = hasModLoader;
            this.hasEmulator = hasEmulator;
        }

        public Game() :this("","","","","","", false, false, false) { }
        public void activate () { isActive = true; }
        public void modLoader() { hasModLoader = true; }
        public void emulator() { hasEmulator = true; }
    }

    [Serializable]
    public class LauncherMainItems //basic management of set paths and games
    {
        private const int numOfGames = 18;
        private const int numOfModLoaders = 10;

        private Game[] games;
        private bool[] activeGames;
        private String steamLoc;
        private String hmmLoc;
        private String sadxMMLoc;
        private ProgramInfo[] modLoaders;


        public LauncherMainItems(Game[] games, string steamLoc, string hmmLoc, string sadxMMLoc, bool[] activeGames, ProgramInfo[] modLoaders = null)
        {
            this.games = games;
            this.steamLoc = steamLoc;
            this.hmmLoc = hmmLoc;
            this.sadxMMLoc = sadxMMLoc;
            this.activeGames = activeGames;
            this.modLoaders = modLoaders;
        }

        public LauncherMainItems()
        {
            games = new Game[numOfGames];
            activeGames = new bool[numOfGames];
            modLoaders = new ProgramInfo[numOfModLoaders];

            for (int i = 0; i < games.Length; i++)
            {
                games[i] = new Game();
                
            }

            steamLoc = "";
            hmmLoc = "";
            sadxMMLoc = "";
            ProgramManager.setModLoaders(modLoaders);
            manageGames();


        }

        public Game[] Games { get => games; set => games = value; }
        public string SteamLoc { get => steamLoc; set => steamLoc = value; }
        public string HmmLoc { get => hmmLoc; set => hmmLoc = value; }
        public string SadxMMLoc { get => sadxMMLoc; set => sadxMMLoc = value; }
        public string SteamLoc1 { get => steamLoc; set => steamLoc = value; }
        public string HmmLoc1 { get => hmmLoc; set => hmmLoc = value; }
        public bool[] ActiveGames { get => activeGames; set => activeGames = value; }
        public ProgramInfo[] ModLoaders { get => modLoaders; set => modLoaders = value; }

        public void manageGames()
        {
            //---STEAM---

            games[0].GameName = "Sonic && Sega All Star Racing";
            games[0].ExeLoc = "steam://rungameid/34190";

            games[0].activate();


            games[1].GameName = "Sega Mega Drive && Genesis Classics";
            games[1].ExeLoc = "steam://rungameid/34270";

            games[1].activate();


            games[2].GameName = "Sonic the Hedgehog CD";
            games[2].ExeLoc = "steam://rungameid/200940";
            games[2].ModLoaderLoc = modLoaders[4].Location;
            games[2].ModLoaderName = modLoaders[4].Name;

            games[2].modLoader();
            games[2].activate();


            games[3].GameName = "Sonic Adventure DX";
            games[3].ExeLoc = "steam://rungameid/71250";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe");
            games[3].ModLoaderLoc = modLoaders[1].Location;
            games[3].ModLoaderName = modLoaders[1].Name;

            games[3].modLoader();
            games[3].activate();


            games[4].GameName = "Sonic Adventure 2 Battle";
            games[4].ExeLoc = "steam://rungameid/213610";
            games[4].ModLoaderLoc = modLoaders[2].Location;
            games[4].ModLoaderName = modLoaders[2].Name;

            games[4].modLoader();
            games[4].activate();


            games[5].GameName = "Sonic Generations";
            games[5].ExeLoc = "steam://rungameid/71340";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe");
            games[5].ModLoaderLoc = modLoaders[0].Location;
            games[5].ModLoaderName = modLoaders[0].Name;

            games[5].modLoader();
            games[5].activate();


            games[6].GameName = "Sonic the Hedgehog 4 Episode 1";
            games[6].ExeLoc = "steam://rungameid/202530";
            games[6].ModLoaderLoc = modLoaders[5].Location;
            games[6].ModLoaderName = modLoaders[5].Name;

            games[6].modLoader();
            games[6].activate();


            games[7].GameName = "Sonic the Hedgehog 4 Episode 2";
            games[7].ExeLoc = "steam://rungameid/203650";
            games[7].ModLoaderLoc = modLoaders[6].Location;
            games[7].ModLoaderName = modLoaders[6].Name;

            games[7].modLoader();
            games[7].activate();


            games[8].GameName = "Sonic && All Stars Racing Transformed";
            games[8].ExeLoc = "steam://rungameid/212480";

            games[8].activate();


            games[9].GameName = "Sonic Lost World";
            games[9].ExeLoc = "steam://rungameid/329440";
            games[9].ModLoaderLoc = modLoaders[0].Location;
            games[9].ModLoaderName = modLoaders[0].Name;

            games[9].activate();


            games[10].GameName = "Sonic Mania";
            games[10].ExeLoc = "steam://rungameid/584400";
            games[10].ModLoaderLoc = modLoaders[3].Location;
            games[10].ModLoaderName = modLoaders[3].Name;

            games[10].modLoader();
            games[10].activate();


            games[11].GameName = "Sonic Forces";
            games[11].ExeLoc = "steam://rungameid/637100";
            games[11].ModLoaderLoc = modLoaders[0].Location;
            games[11].ModLoaderName = modLoaders[0].Name;

            games[11].modLoader();
            games[11].activate();


            games[12].GameName = "Team Sonic Racing";
            games[12].ExeLoc = "steam://rungameid/785260";

            games[12].activate();


            games[13].GameName = "Sonic Colors: Ultimate";
            games[13].ExeLoc = "steam://rungameid/2055290";
            games[13].ModLoaderLoc = modLoaders[0].Location;
            games[13].ModLoaderName = modLoaders[0].Name;

            games[13].modLoader();
            games[13].activate();


            games[14].GameName = "Sonic Origins";
            games[14].ExeLoc = "steam://rungameid/1794960";
            games[14].ModLoaderLoc = modLoaders[0].Location;
            games[14].ModLoaderName = modLoaders[0].Name;

            games[14].modLoader();
            games[14].activate();


            games[15].GameName = "Sonic Frontiers";
            games[15].ExeLoc = "steam://rungameid/1237320";
            games[15].ModLoaderLoc = modLoaders[0].Location;
            games[15].ModLoaderName = modLoaders[0].Name;

            games[15].modLoader();
            games[15].activate();


            games[16].GameName = "The Murder of Sonic The Hedgehog";
            games[16].ExeLoc = "steam://rungameid/2324650";

            games[16].activate();


            games[17].GameName = "Sonic Superstars";
            games[17].ExeLoc = "steam://rungameid/2022670";
            games[17].ModLoaderLoc = modLoaders[11].Location;
            games[17].ModLoaderName = modLoaders[11].Name;

            games[17].modLoader();
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

    [Serializable]
    public class ProgramInfo
    {
        private string name;
        private string location;

        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }

        public ProgramInfo(string name, string location)
        {
            this.name = name;
            this.location = location;
        }

        public ProgramInfo() : this("", "") { }
    }

    [Serializable]
    public static class ProgramManager
    {
        public static void setModLoaders(ProgramInfo[] progs)
        {
            progs[0].Name = "HedgeModManager";
            progs[1].Name = "SADX Mod Loader";
            progs[2].Name = "SA2 Mod Loader";
            progs[3].Name = "Mania Mod Loader";
            progs[4].Name = "Sonic CD Steam Mod Loader";
            progs[5].Name = "Sonic 4 Mod Loader";
            progs[6].Name = "Sonic 4 Mod Loader";
            progs[7].Name = "Sonic R Mod Loader";
            progs[8].Name = "S&K Collection Mod Loader";
            progs[9].Name = "RSDK Mod Manager";
            progs[10].Name = "Reloaded 2";
            progs[11].Name = "Concursus";
        }

    }




}
