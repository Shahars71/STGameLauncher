using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace WindowsFormsApp1
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Drawing;
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
        private String emuArgs;
        private String gameType;
        public bool isActive;
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
        public string EmuArgs { get => emuArgs; set => emuArgs = value; }
        public string GameType { get => gameType; set => gameType = value; }

        public Game(string gameName = null, string exeLoc = null, string modLoaderLoc = null, string modLoaderName = null, string emulatorLoc = null, string emulatorName = null, bool isActive = false, bool hasModLoader = false, bool hasEmulator = false, string emuArgs = null, string gameType = null)
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
            this.emuArgs = emuArgs;
            this.gameType = gameType;
        }

        public Game() :this("","","","","","", false, false, false, "", "") { }
        public void activate () { isActive = true; }
        public void modLoader() { hasModLoader = true; }
        public void emulator() { hasEmulator = true; }
        public void deActivate() { isActive = false; Console.WriteLine(this.gameName + " Has been deactovated!"); }
    }

    [Serializable]
    public class LauncherMainItems //basic management of set paths and games
    {
        private const int numOfGames = 30;
        private const int numOfModLoaders = 12;
        private const int numOfEmulators = 21;
        private const int numOfGameTypes = 24;

        private Game[] games;
        private bool[] activeGames;
        private String steamLoc;
        private String hmmLoc;
        private String sadxMMLoc;
        private String[] gameTypes;
        private ProgramInfo[] modLoaders;
        private ProgramInfo[] emulators;
        private ProgramInfo[] romLocs;



        public LauncherMainItems(Game[] games, string steamLoc, string hmmLoc, string sadxMMLoc, bool[] activeGames, ProgramInfo[] modLoaders = null, ProgramInfo[] emulators = null, ProgramInfo[] romLocs = null, string[] gameTypes = null)
        {
            this.games = games;
            this.steamLoc = steamLoc;
            this.hmmLoc = hmmLoc;
            this.sadxMMLoc = sadxMMLoc;
            this.activeGames = activeGames;
            this.modLoaders = modLoaders;
            this.emulators = emulators;
            this.romLocs = romLocs;
            this.gameTypes = gameTypes;
        }

        public LauncherMainItems()
        {
            games = new Game[numOfGames];
            activeGames = new bool[numOfGames];
            modLoaders = new ProgramInfo[numOfModLoaders];
            emulators = new ProgramInfo[numOfEmulators];
            romLocs = new ProgramInfo[numOfEmulators];
            gameTypes = new string[numOfGameTypes];

            for (int i = 0; i < games.Length; i++)
            {
                games[i] = new Game();
                
            }

            for (int j = 0; j < modLoaders.Length; j++)
            {
                modLoaders[j] = new ProgramInfo();
            }

            for (int i = 0;i < emulators.Length; i++) 
            {
                emulators[i] = new ProgramInfo();
                romLocs[i] = new ProgramInfo();
            }
        

            steamLoc = "";
            hmmLoc = "";
            sadxMMLoc = "";
            ProgramManager.setModLoaders(modLoaders); //names mod loaders
            ProgramManager.setEmulators(emulators);   //names emulated console (for emulators)
            ProgramManager.setEmulators(romLocs);     //names emulated consoles (for roms)
            ProgramManager.setGameTypes(gameTypes);   //names types of games (emulated are per console)
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
        public ProgramInfo[] Emulators { get => emulators; set => emulators = value; }
        public ProgramInfo[] RomLocs { get => romLocs; set => romLocs = value; }
        public string[] GameTypes { get => gameTypes; set => gameTypes = value; }

        public void manageGames()
        {
            //---STEAM---

            games[0].GameName = "Sonic && Sega All Star Racing";
            games[0].ExeLoc = "steam://rungameid/34190";
            games[0].GameType = gameTypes[0];

            games[0].activate();


            games[1].GameName = "Sega Mega Drive && Genesis Classics";
            games[1].ExeLoc = "steam://rungameid/34270";
            games[1].GameType = gameTypes[0];

            //games[1].activate();


            games[2].GameName = "Sonic the Hedgehog CD";
            games[2].ExeLoc = "steam://rungameid/200940";
            games[2].ModLoaderLoc = modLoaders[4].Location;
            games[2].ModLoaderName = modLoaders[4].Name;
            games[2].GameType = gameTypes[0];

            games[2].modLoader();
            games[2].activate();


            games[3].GameName = "Sonic Adventure DX";
            games[3].ExeLoc = "steam://rungameid/71250";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe");
            games[3].ModLoaderLoc = modLoaders[1].Location;
            games[3].ModLoaderName = modLoaders[1].Name;
            games[3].GameType = gameTypes[0];

            games[3].modLoader();
            games[3].activate();


            games[4].GameName = "Sonic Adventure 2 Battle";
            games[4].ExeLoc = "steam://rungameid/213610";
            games[4].ModLoaderLoc = modLoaders[2].Location;
            games[4].ModLoaderName = modLoaders[2].Name;
            games[4].GameType = gameTypes[0];

            games[4].modLoader();
            games[4].activate();


            games[5].GameName = "Sonic Generations";
            games[5].ExeLoc = "steam://rungameid/71340";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe");
            games[5].ModLoaderLoc = modLoaders[0].Location;
            games[5].ModLoaderName = modLoaders[0].Name;
            games[5].GameType = gameTypes[0];

            games[5].modLoader();
            games[5].activate();


            games[6].GameName = "Sonic the Hedgehog 4 Episode 1";
            games[6].ExeLoc = "steam://rungameid/202530";
            games[6].ModLoaderLoc = modLoaders[5].Location;
            games[6].ModLoaderName = modLoaders[5].Name;
            games[6].GameType = gameTypes[0];

            games[6].modLoader();
            games[6].activate();


            games[7].GameName = "Sonic the Hedgehog 4 Episode 2";
            games[7].ExeLoc = "steam://rungameid/203650";
            games[7].ModLoaderLoc = modLoaders[6].Location;
            games[7].ModLoaderName = modLoaders[6].Name;
            games[7].GameType = gameTypes[0];

            games[7].modLoader();
            games[7].activate();


            games[8].GameName = "Sonic && All Stars Racing Transformed";
            games[8].ExeLoc = "steam://rungameid/212480";
            games[8].GameType = gameTypes[0];

            games[8].activate();


            games[9].GameName = "Sonic Lost World";
            games[9].ExeLoc = "steam://rungameid/329440";
            games[9].ModLoaderLoc = modLoaders[0].Location;
            games[9].ModLoaderName = modLoaders[0].Name;
            games[9].GameType = gameTypes[0];

            games[9].activate();


            games[10].GameName = "Sonic Mania";
            games[10].ExeLoc = "steam://rungameid/584400";
            games[10].ModLoaderLoc = modLoaders[3].Location;
            games[10].ModLoaderName = modLoaders[3].Name;
            games[10].GameType = gameTypes[0];

            games[10].modLoader();
            games[10].activate();


            games[11].GameName = "Sonic Forces";
            games[11].ExeLoc = "steam://rungameid/637100";
            games[11].ModLoaderLoc = modLoaders[0].Location;
            games[11].ModLoaderName = modLoaders[0].Name;
            games[11].GameType = gameTypes[0];

            games[11].modLoader();
            games[11].activate();


            games[12].GameName = "Team Sonic Racing";
            games[12].ExeLoc = "steam://rungameid/785260";
            games[12].GameType = gameTypes[0];

            games[12].activate();


            games[13].GameName = "Sonic Colors: Ultimate";
            games[13].ExeLoc = "steam://rungameid/2055290";
            games[13].ModLoaderLoc = modLoaders[0].Location;
            games[13].ModLoaderName = modLoaders[0].Name;
            games[13].GameType = gameTypes[0];

            games[13].modLoader();
            games[13].activate();


            games[14].GameName = "Sonic Origins";
            games[14].ExeLoc = "steam://rungameid/1794960";
            games[14].ModLoaderLoc = modLoaders[0].Location;
            games[14].ModLoaderName = modLoaders[0].Name;
            games[14].GameType = gameTypes[0];

            games[14].modLoader();
            games[14].activate();


            games[15].GameName = "Sonic Frontiers";
            games[15].ExeLoc = "steam://rungameid/1237320";
            games[15].ModLoaderLoc = modLoaders[0].Location;
            games[15].ModLoaderName = modLoaders[0].Name;
            games[15].GameType = gameTypes[0];

            games[15].modLoader();
            games[15].activate();


            games[16].GameName = "The Murder of Sonic The Hedgehog";
            games[16].ExeLoc = "steam://rungameid/2324650";
            games[16].GameType = gameTypes[0];

            games[16].activate();


            games[17].GameName = "Sonic Superstars";
            games[17].ExeLoc = "steam://rungameid/2022670";
            games[17].ModLoaderLoc = modLoaders[11].Location;
            games[17].ModLoaderName = modLoaders[11].Name;
            games[17].GameType = gameTypes[0];

            games[17].modLoader();
            games[17].activate();

            //---EPIC GAMES STORE---


            games[18].GameName = "Sonic Colors: Ultimate";
            games[18].ExeLoc = "com.epicgames.launcher://apps/e5071e19d08c45a6bdda5d92fbd0a03e?action=launch&silent=true";
            games[18].ModLoaderLoc = modLoaders[0].Location;
            games[18].ModLoaderName= modLoaders[0].Name;
            games[18].GameType = gameTypes[1];

            games[18].modLoader();
            games[18].activate();


            games[19].GameName = "Sonic Origins";
            games[19].ExeLoc = "com.epicgames.launcher://apps/5070a8e44cf74ba3b9a4ca0c0dce5cf1?action=launch&silent=true";
            games[19].ModLoaderLoc = modLoaders[0].Location;
            games[19].ModLoaderName = modLoaders[0].Name;
            games[19].GameType = gameTypes[1];

            games[19].modLoader();
            games[19].activate();


            games[20].GameName = "Sonic Mania";
            games[20].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[20].ModLoaderLoc = modLoaders[3].Location;
            games[20].ModLoaderName = modLoaders[3].Name;
            games[20].GameType = gameTypes[1];

            games[20].modLoader();
            games[20].activate();


            games[21].GameName = "Sonic Frontiers";
            games[21].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[21].ModLoaderLoc = modLoaders[0].Location;
            games[21].ModLoaderName = modLoaders[0].Name;
            games[21].GameType = gameTypes[1];

            games[21].modLoader();
            games[21].activate();


            games[22].GameName = "Sonic Superstars";
            games[22].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[22].ModLoaderLoc = modLoaders[11].Location;
            games[22].ModLoaderName = modLoaders[11].Name;
            games[22].GameType = gameTypes[1];

            games[22].modLoader();
            games[22].activate();


            //---DRM FREE---














            /*---MEGA DRIVE---

            games[18].GameName = "Sonic The Hedgehog";
            games[18].EmulatorName = emulators[0].Name;
            games[18].EmulatorLoc = "F:\\Games\\Emulated Games\\Emulators\\Fusion364\\Fusion.exe";
            games[18].EmuArgs = " -gen -auto -fullscreen";
            games[18].ExeLoc = "F:\\Games\\Emulated Games\\Roms\\Consoles\\Mega Drive\\Sonic the Hedgehog (USA, Europe).md";
            games[18].GameType = gameTypes[3];

            games[18].modLoader();
            games[18].emulator();
            games[18].activate();

            */

            for (int i = 0; i < games.Length; i++)
            {
                activeGames[i] = games[i].IsActive;
            }
        }

        public void checkActives()
        {
            for(int i = 0;i < games.Length;i++)
            {
                activeGames[i] = games[i].isActive;
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

        public static void setEmulators(ProgramInfo[] emus)
        {
            emus[0].Name = "Mega Drive";
            emus[1].Name = "Master System";
            emus[2].Name = "Game Gear";
            emus[3].Name = "Sega Saturn";
            emus[4].Name = "Dreamcast";
            emus[5].Name = "Arcade (MAME)";
            emus[6].Name = "GameCube";
            emus[7].Name = "Wii";
            emus[8].Name = "Wii U";
            emus[9].Name = "Switch";
            emus[10].Name = "PS2";
            emus[11].Name = "PS3";
            emus[12].Name = "OG XBox";
            emus[13].Name = "XBox 360";
            emus[14].Name = "Neo Geo Pocket Color";
            emus[15].Name = "Game Boy Advance";
            emus[16].Name = "DS";
            emus[17].Name = "3DS";
            emus[18].Name = "PSP";
            emus[19].Name = "Sega PC Reloaded";
            emus[20].Name = "Arcade (Sega)";
        }

        public static void setGameTypes(string[] type) 
        {
            type[0] = "Steam";
            type[1] = "Epic Games Store";
            type[2] = "DRM Free";
            type[3] = "Sega Mega Drive";
            type[4] = "Sega Master System";
            type[5] = "Sega Game Gear";
            type[6] = "Sega Saturn";
            type[7] = "Sega Dreamcast";
            type[8] = "Arcade (MAME)";
            type[9] = "Arcade (Sega AM2)";
            type[10] = "Nintendo GameCube";
            type[11] = "Nintendo Wii";
            type[12] = "Nintendo Wii U";
            type[13] = "Nintendo Switch";
            type[14] = "Sony PlayStation 2";
            type[15] = "Sony Playstation 3";
            type[16] = "Microsoft XBox";
            type[17] = "Microsoft XBox 360";
            type[18] = "Neo Geo Pocket Color";
            type[19] = "Game Boy Advance";
            type[20] = "Nintendo DS";
            type[21] = "Nintendo 3DS";
            type[22] = "PlayStation Portable";
            type[23] = "Sega PC Reloaded";
        }

        public static void setEmuArgs(string[] args)
        {

        }
    }




}
