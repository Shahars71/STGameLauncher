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
        public void deActivate() { isActive = false; Console.WriteLine(this.gameName + " Has been deactivated!"); }
    }

    [Serializable]
    public class LauncherMainItems //basic management of set paths and games
    {
        private const int numOfGames = 300;
        private const int numOfModLoaders = 15;
        private const int numOfEmulators = 24;
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
            


            games[1].GameName = "Sega Mega Drive && Genesis Classics";
            games[1].ExeLoc = "steam://rungameid/34270";
            games[1].GameType = gameTypes[0];
            


            games[2].GameName = "Sonic the Hedgehog CD";
            games[2].ExeLoc = "steam://rungameid/200940";
            games[2].ModLoaderLoc = modLoaders[4].Location;
            games[2].ModLoaderName = modLoaders[4].Name;
            games[2].GameType = gameTypes[0];
            games[2].modLoader();
            


            games[3].GameName = "Sonic Adventure DX";
            games[3].ExeLoc = "steam://rungameid/71250";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe");
            games[3].ModLoaderLoc = modLoaders[1].Location;
            games[3].ModLoaderName = modLoaders[1].Name;
            games[3].GameType = gameTypes[0];
            games[3].modLoader();
            


            games[4].GameName = "Sonic Adventure 2 Battle";
            games[4].ExeLoc = "steam://rungameid/213610";
            games[4].ModLoaderLoc = modLoaders[2].Location;
            games[4].ModLoaderName = modLoaders[2].Name;
            games[4].GameType = gameTypes[0];
            games[4].modLoader();
            


            games[5].GameName = "Sonic Generations";
            games[5].ExeLoc = "steam://rungameid/71340";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe");
            games[5].ModLoaderLoc = modLoaders[0].Location;
            games[5].ModLoaderName = modLoaders[0].Name;
            games[5].GameType = gameTypes[0];
            games[5].modLoader();
            


            games[6].GameName = "Sonic the Hedgehog 4 Episode 1";
            games[6].ExeLoc = "steam://rungameid/202530";
            games[6].ModLoaderLoc = modLoaders[5].Location;
            games[6].ModLoaderName = modLoaders[5].Name;
            games[6].GameType = gameTypes[0];
            games[6].modLoader();
            


            games[7].GameName = "Sonic the Hedgehog 4 Episode 2";
            games[7].ExeLoc = "steam://rungameid/203650";
            games[7].ModLoaderLoc = modLoaders[6].Location;
            games[7].ModLoaderName = modLoaders[6].Name;
            games[7].GameType = gameTypes[0];
            games[7].modLoader();
            


            games[8].GameName = "Sonic && All Stars Racing Transformed";
            games[8].ExeLoc = "steam://rungameid/212480";
            games[8].GameType = gameTypes[0];
            


            games[9].GameName = "Sonic Lost World";
            games[9].ExeLoc = "steam://rungameid/329440";
            games[9].ModLoaderLoc = modLoaders[0].Location;
            games[9].ModLoaderName = modLoaders[0].Name;
            games[9].GameType = gameTypes[0];
            games[9].modLoader();
            


            games[10].GameName = "Sonic Mania";
            games[10].ExeLoc = "steam://rungameid/584400";
            games[10].ModLoaderLoc = modLoaders[3].Location;
            games[10].ModLoaderName = modLoaders[3].Name;
            games[10].GameType = gameTypes[0];
            games[10].modLoader();
            


            games[11].GameName = "Sonic Forces";
            games[11].ExeLoc = "steam://rungameid/637100";
            games[11].ModLoaderLoc = modLoaders[0].Location;
            games[11].ModLoaderName = modLoaders[0].Name;
            games[11].GameType = gameTypes[0];
            games[11].modLoader();
            


            games[12].GameName = "Team Sonic Racing";
            games[12].ExeLoc = "steam://rungameid/785260";
            games[12].GameType = gameTypes[0];
            


            games[13].GameName = "Sonic Colors: Ultimate";
            games[13].ExeLoc = "steam://rungameid/2055290";
            games[13].ModLoaderLoc = modLoaders[0].Location;
            games[13].ModLoaderName = modLoaders[0].Name;
            games[13].GameType = gameTypes[0];
            games[13].modLoader();
            


            games[14].GameName = "Sonic Origins";
            games[14].ExeLoc = "steam://rungameid/1794960";
            games[14].ModLoaderLoc = modLoaders[0].Location;
            games[14].ModLoaderName = modLoaders[0].Name;
            games[14].GameType = gameTypes[0];
            games[14].modLoader();
            


            games[15].GameName = "Sonic Frontiers";
            games[15].ExeLoc = "steam://rungameid/1237320";
            games[15].ModLoaderLoc = modLoaders[0].Location;
            games[15].ModLoaderName = modLoaders[0].Name;
            games[15].GameType = gameTypes[0];
            games[15].modLoader();
            


            games[16].GameName = "The Murder of Sonic The Hedgehog";
            games[16].ExeLoc = "steam://rungameid/2324650";
            games[16].GameType = gameTypes[0];
            


            games[17].GameName = "Sonic Superstars";
            games[17].ExeLoc = "steam://rungameid/2022670";
            games[17].ModLoaderLoc = modLoaders[11].Location;
            games[17].ModLoaderName = modLoaders[11].Name;
            games[17].GameType = gameTypes[0];
            games[17].modLoader();
            

            //---EPIC GAMES STORE---


            games[18].GameName = "Sonic Colors: Ultimate";
            games[18].ExeLoc = "com.epicgames.launcher://apps/e5071e19d08c45a6bdda5d92fbd0a03e?action=launch&silent=true";
            games[18].ModLoaderLoc = modLoaders[0].Location;
            games[18].ModLoaderName= modLoaders[0].Name;
            games[18].GameType = gameTypes[1];
            games[18].modLoader();
            


            games[19].GameName = "Sonic Origins";
            games[19].ExeLoc = "com.epicgames.launcher://apps/5070a8e44cf74ba3b9a4ca0c0dce5cf1?action=launch&silent=true";
            games[19].ModLoaderLoc = modLoaders[0].Location;
            games[19].ModLoaderName = modLoaders[0].Name;
            games[19].GameType = gameTypes[1];
            games[19].modLoader();
            


            games[20].GameName = "Sonic Mania";
            games[20].ExeLoc = "com.epicgames.launcher://apps/818447bb519b46d48d365d5753362796?action=launch&silent=true";
            games[20].ModLoaderLoc = modLoaders[3].Location;
            games[20].ModLoaderName = modLoaders[3].Name;
            games[20].GameType = gameTypes[1];
            games[20].modLoader();
            


            games[21].GameName = "Sonic Frontiers";
            games[21].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[21].ModLoaderLoc = modLoaders[0].Location;
            games[21].ModLoaderName = modLoaders[0].Name;
            games[21].GameType = gameTypes[1];
            games[21].modLoader();
            


            games[22].GameName = "Sonic Superstars";
            games[22].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[22].ModLoaderLoc = modLoaders[11].Location;
            games[22].ModLoaderName = modLoaders[11].Name;
            games[22].GameType = gameTypes[1];
            games[22].modLoader();
            


            //---DRM FREE---

            games[23].GameName = "Sonic The Hedgehog (Decompilation)";
            games[23].GameType = gameTypes[2];
            games[23].ModLoaderName = modLoaders[9].Name;
            games[23].ModLoaderLoc = modLoaders[9].Location;
            games[23].modLoader();
            


            games[24].GameName = "Sonic The Hedgehog 2 (Decompilation)";
            games[24].GameType = gameTypes[2];
            games[24].ModLoaderName = modLoaders[9].Name;
            games[24].ModLoaderLoc = modLoaders[9].Location;
            games[24].modLoader();
            


            games[25].GameName = "Sonic The Hedgehog CD";
            games[25].GameType = gameTypes[2];
            


            games[26].GameName = "Sonic CD (Sega PC Reloaded)";
            games[26].GameType = gameTypes[23];
            games[26].EmulatorName = emulators[19].Name;
            games[26].EmulatorLoc = emulators[19].Location;
            games[26].EmuArgs = "/launch 2 \"SONICCD.EXE\"";
            games[26].emulator();
            

            games[27].GameName = "Sonic The Hedgehog CD (Decompilation)";
            games[27].GameType = gameTypes[2];
            games[27].ModLoaderName = modLoaders[9].Name;
            games[27].ModLoaderLoc = modLoaders[9].Location;
            games[27].modLoader();
            


            games[28].GameName = "Sonic && Knuckles Collection";
            games[28].GameType = gameTypes[2];
            


            games[29].GameName = "Sonic && Knuckles Collection (Sega PC Reloaded)";
            games[29].GameType = gameTypes[23];
            games[29].ModLoaderName = modLoaders[8].Name;
            games[29].ModLoaderLoc = modLoaders[8].Location;
            games[29].EmulatorName = emulators[19].Name;
            games[29].EmulatorLoc = emulators[19].Location;
            games[29].EmuArgs = "/launch 3 \"SONIC3K.EXE\"";
            games[29].modLoader();
            games[29].emulator();
            


            games[30].GameName = "Sonic 3D Blast";
            games[30].GameType = gameTypes[2];
            


            games[31].GameName = "Sonic 3D Blast (Sega PC Reloaded)";
            games[31].GameType = gameTypes[23];
            games[31].EmulatorName = emulators[19].Name;
            games[31].EmulatorLoc = emulators[19].Location;
            games[31].EmuArgs = "/launch 4 \"PCSONIC.EXE\"";
            games[31].emulator();
            


            games[32].GameName = "Sonic R";
            games[32].GameType = gameTypes[2];
            games[32].ModLoaderName = modLoaders[7].Name;
            games[32].ModLoaderLoc = modLoaders[7].Location;
            games[32].modLoader();
            


            games[33].GameName = "Sonic Adventure DX";
            games[33].GameType = gameTypes[2];
            games[33].ModLoaderName = modLoaders[1].Name;
            games[33].ModLoaderLoc = modLoaders[1].Location;
            games[33].modLoader();
            


            games[34].GameName = "Sonic Heroes";
            games[34].GameType = gameTypes[2];
            games[34].ModLoaderName = modLoaders[10].Name;
            games[34].ModLoaderLoc = modLoaders[10].Location;
            games[34].modLoader();
            


            games[35].GameName = "Sonic Mega Collection Plus";
            games[35].GameType = gameTypes[2];
            


            games[36].GameName = "Sonic Riders";
            games[36].GameType = gameTypes[2];
            games[36].ModLoaderName = modLoaders[10].Name;
            games[36].ModLoaderLoc = modLoaders[10].Location;
            games[36].modLoader();
            


            games[37].GameName = "Sonic Mania (Decompilation)";
            games[37].GameType = gameTypes[2];
            games[37].ModLoaderName = modLoaders[9].Name;
            games[37].ModLoaderLoc = modLoaders[9].Location;
            games[37].modLoader();
            





            //---MEGA DRIVE---

            games[38].GameName = "Sonic the Hedgehog";             
            games[38].EmulatorName = emulators[0].Name;
            games[38].EmulatorLoc = emulators[0].Location;
            games[38].GameType = gameTypes[3];
            games[38].emulator();
            


            games[39].GameName = "Sonic the Hedgehog 2";
            games[39].EmulatorName = emulators[0].Name;
            games[39].EmulatorLoc = emulators[0].Location;
            games[39].GameType = gameTypes[3];
            games[39].emulator();
            


            games[40].GameName = "Sonic the Hedgehog CD";
            games[40].EmulatorName = emulators[0].Name;
            games[40].EmulatorLoc = emulators[0].Location;
            games[40].GameType = gameTypes[3];
            games[40].emulator();
            


            games[41].GameName = "Sonic the Hedgehog 3";
            games[41].EmulatorName = emulators[0].Name;
            games[41].EmulatorLoc = emulators[0].Location;
            games[41].GameType = gameTypes[3];
            games[41].emulator();
            


            games[42].GameName = "Sonic && Knuckles";
            games[42].EmulatorName = emulators[0].Name;
            games[42].EmulatorLoc = emulators[0].Location;
            games[42].GameType = gameTypes[3];
            games[42].emulator();
            


            games[43].GameName = "Sonic the Hedgehog 3 && Knuckles";
            games[43].EmulatorName = emulators[0].Name;
            games[43].EmulatorLoc = emulators[0].Location;
            games[43].GameType = gameTypes[3];
            games[43].emulator();
            


            games[44].GameName = "Sonic Spinball";
            games[44].EmulatorName = emulators[0].Name;
            games[44].EmulatorLoc = emulators[0].Location;
            games[44].GameType = gameTypes[3];
            games[44].emulator();
            


            games[45].GameName = "Dr. Robotnik's Mean Bean Machine";
            games[45].EmulatorName = emulators[0].Name;
            games[45].EmulatorLoc = emulators[0].Location;
            games[45].GameType = gameTypes[3];
            games[45].emulator();
            


            games[46].GameName = "Knuckles' Chaotix";
            games[46].EmulatorName = emulators[0].Name;
            games[46].EmulatorLoc = emulators[0].Location;
            games[46].GameType = gameTypes[3];
            games[46].emulator();
            


            games[47].GameName = "Knuckles in Sonic 2";
            games[47].EmulatorName = emulators[0].Name;
            games[47].EmulatorLoc = emulators[0].Location;
            games[47].GameType = gameTypes[3];
            games[47].emulator();
            


            games[48].GameName = "Sonic 3D Blast";
            games[48].EmulatorName = emulators[0].Name;
            games[48].EmulatorLoc = emulators[0].Location;
            games[48].GameType = gameTypes[3];
            games[48].emulator();
            


            games[49].GameName = "Sonic Eraser";
            games[49].EmulatorName = emulators[0].Name;
            games[49].EmulatorLoc = emulators[0].Location;
            games[49].GameType = gameTypes[3];
            games[49].emulator();
            


            games[50].GameName = "Sonic Crackers";
            games[50].EmulatorName = emulators[0].Name;
            games[50].EmulatorLoc = emulators[0].Location;
            games[50].GameType = gameTypes[3];
            games[50].emulator();
            



            //---Sega Master System---

            games[51].GameName = "Sonic The Hedgehog (8-bit)";
            games[51].EmulatorName = emulators[1].Name;
            games[51].EmulatorLoc = emulators[1].Location;
            games[51].GameType = gameTypes[4];
            games[51].emulator();
            


            games[52].GameName = "Sonic The Hedgehog 2 (8-bit)";
            games[52].EmulatorName = emulators[1].Name;
            games[52].EmulatorLoc = emulators[1].Location;
            games[52].GameType = gameTypes[4];
            games[52].emulator();
            


            games[53].GameName = "Sonic Chaos";
            games[53].EmulatorName = emulators[1].Name;
            games[53].EmulatorLoc = emulators[1].Location;
            games[53].GameType = gameTypes[4];
            games[53].emulator();
            


            games[54].GameName = "Sonic Blast";
            games[54].EmulatorName = emulators[1].Name;
            games[54].EmulatorLoc = emulators[1].Location;
            games[54].GameType = gameTypes[4];
            games[54].emulator();
            


            games[55].GameName = "Sonic Spinball (8-bit)";
            games[55].EmulatorName = emulators[1].Name;
            games[55].EmulatorLoc = emulators[1].Location;
            games[55].GameType = gameTypes[4];
            games[55].emulator();
            


            games[56].GameName = "Dr. Robotnik's Mean Bean Machine (8-bit)";
            games[56].EmulatorName = emulators[1].Name;
            games[56].EmulatorLoc = emulators[1].Location;
            games[56].GameType = gameTypes[4];
            games[56].emulator();
            


            games[57].GameName = "Sonic Edusoft";
            games[57].EmulatorName = emulators[1].Name;
            games[57].EmulatorLoc = emulators[1].Location;
            games[57].GameType = gameTypes[4];
            games[57].emulator();
            



            //---GAME GEAR---

            games[57].GameName = "Sonic The Hedgehog (8-bit)";
            games[57].EmulatorName = emulators[2].Name;
            games[57].EmulatorLoc = emulators[2].Location;
            games[57].GameType = gameTypes[5];
            games[57].emulator();
            


            games[58].GameName = "Sonic The Hedgehog 2 (8-bit)";
            games[58].EmulatorName = emulators[2].Name;
            games[58].EmulatorLoc = emulators[2].Location;
            games[58].GameType = gameTypes[5];
            games[58].emulator();
            


            games[59].GameName = "Sonic Chaos";
            games[59].EmulatorName = emulators[2].Name;
            games[59].EmulatorLoc = emulators[2].Location;
            games[59].GameType = gameTypes[5];
            games[59].emulator();
            


            games[60].GameName = "Sonic Blast";
            games[60].EmulatorName = emulators[2].Name;
            games[60].EmulatorLoc = emulators[2].Location;
            games[60].GameType = gameTypes[5];
            games[60].emulator();
            


            games[61].GameName = "Sonic Spinball (8-bit)";
            games[61].EmulatorName = emulators[2].Name;
            games[61].EmulatorLoc = emulators[2].Location;
            games[61].GameType = gameTypes[5];
            games[61].emulator();
            


            games[62].GameName = "Dr. Robotnik's Mean Bean Machine (8-bit)";
            games[62].EmulatorName = emulators[2].Name;
            games[62].EmulatorLoc = emulators[2].Location;
            games[62].GameType = gameTypes[5];
            games[62].emulator();
            


            games[63].GameName = "Sonic Triple Trouble";
            games[63].EmulatorName = emulators[2].Name;
            games[63].EmulatorLoc = emulators[2].Location;
            games[63].GameType = gameTypes[5];
            games[63].emulator();
            


            games[64].GameName = "Sonic Labyrinth";
            games[64].EmulatorName = emulators[2].Name;
            games[64].EmulatorLoc = emulators[2].Location;
            games[64].GameType = gameTypes[5];
            games[64].emulator();
            


            games[65].GameName = "Sonic Drift";
            games[65].EmulatorName = emulators[2].Name;
            games[65].EmulatorLoc = emulators[2].Location;
            games[65].GameType = gameTypes[5];
            games[65].emulator();
            


            games[66].GameName = "Sonic Drift 2";
            games[66].EmulatorName = emulators[2].Name;
            games[66].EmulatorLoc = emulators[2].Location;
            games[66].GameType = gameTypes[5];
            games[66].emulator();
            


            games[67].GameName = "Tails' Adventure";
            games[67].EmulatorName = emulators[2].Name;
            games[67].EmulatorLoc = emulators[2].Location;
            games[67].GameType = gameTypes[5];
            games[67].emulator();
            


            games[68].GameName = "Tails' Skypatrol";
            games[68].EmulatorName = emulators[2].Name;
            games[68].EmulatorLoc = emulators[2].Location;
            games[68].GameType = gameTypes[5];
            games[68].emulator();
            


            //---ARCADE---

            games[69].GameName = "SegaSonic The Hedgehog";
            games[69].EmulatorName = emulators[5].Name;
            games[69].EmulatorLoc = emulators[5].Location;
            games[69].GameType = gameTypes[8];
            games[69].ExeLoc = "sonic";
            games[69].emulator();
            

            games[70].GameName = "Waku Waku Sonic Patrol Car";
            games[70].EmulatorName = emulators[5].Name;
            games[70].EmulatorLoc = emulators[5].Location;
            games[70].GameType = gameTypes[8];
            games[70].ExeLoc = "soniccar";
            games[70].emulator();
            

            games[71].GameName = "SegaSonic Popcorn Shop";
            games[71].EmulatorName = emulators[5].Name;
            games[71].EmulatorLoc = emulators[5].Location;
            games[71].GameType = gameTypes[8];
            games[71].ExeLoc = "sonicpop";
            games[71].emulator();
            

            games[72].GameName = "SegaSonic Cosmo Fighter";
            games[72].EmulatorName = emulators[5].Name;
            games[72].EmulatorLoc = emulators[5].Location;
            games[72].GameType = gameTypes[8];
            games[72].ExeLoc = "sonicfgt";
            games[72].emulator();
 

            games[73].GameName = "Sonic The Hedgehog (Mega Play)";
            games[73].EmulatorName = emulators[5].Name;
            games[73].EmulatorLoc = emulators[5].Location;
            games[73].GameType = gameTypes[8];
            games[73].ExeLoc = "megaplay mp_sonic";
            games[73].emulator();
            


            games[74].GameName = "Sonic The Hedgehog 2 (Mega Play)";
            games[74].EmulatorName = emulators[5].Name;
            games[74].EmulatorLoc = emulators[5].Location;
            games[74].GameType = gameTypes[8];
            games[74].ExeLoc = "mp_soni2";
            games[74].emulator();
            


            games[75].GameName = "Sonic the Fighters";
            games[75].EmulatorName = emulators[20].Name;
            games[75].EmulatorLoc = emulators[20].Location;
            games[75].GameType = gameTypes[9];
            games[75].emulator();
            


            //---SATURN---

            games[76].GameName = "Sonic 3D Blast";
            games[76].EmulatorName = emulators[3].Name;
            games[76].EmulatorLoc = emulators[3].Location;
            games[76].GameType = gameTypes[6];
            games[76].EmuArgs = "-a";
            games[76].emulator();
            


            games[77].GameName = "Sonic Jam";
            games[77].EmulatorName = emulators[3].Name;
            games[77].EmulatorLoc = emulators[3].Location;
            games[77].GameType = gameTypes[6];
            games[77].EmuArgs = "-a";
            games[77].emulator();
            


            games[78].GameName = "Sonic R";
            games[78].EmulatorName = emulators[3].Name;
            games[78].EmulatorLoc = emulators[3].Location;
            games[78].GameType = gameTypes[6];
            games[78].EmuArgs = "-a";
            games[78].emulator();
            


            //---DREAMCAST---


            games[79].GameName = "Sonic Adventure";
            games[79].EmulatorName = emulators[4].Name;
            games[79].EmulatorLoc = emulators[4].Location;
            games[79].GameType = gameTypes[7];
            games[79].emulator();
            


            games[80].GameName = "Sonic Adventure 2";
            games[80].EmulatorName = emulators[4].Name;
            games[80].EmulatorLoc = emulators[4].Location;
            games[80].GameType = gameTypes[7];
            games[80].emulator();
            


            games[81].GameName = "Sonic Shuffle";
            games[81].EmulatorName = emulators[4].Name;
            games[81].EmulatorLoc = emulators[4].Location;
            games[81].GameType = gameTypes[7];
            games[81].emulator();
            


            //---GAMECUBE---


            games[82].GameName = "Sonic Adventure DX";
            games[82].EmulatorName = emulators[6].Name;
            games[82].EmulatorLoc = emulators[6].Location;
            games[82].GameType = gameTypes[10];
            games[82].emulator();
            


            games[83].GameName = "Sonic Adventure 2 Battle";
            games[83].EmulatorName = emulators[6].Name;
            games[83].EmulatorLoc = emulators[6].Location;
            games[83].GameType = gameTypes[10];
            games[83].emulator();
            


            games[84].GameName = "Sonic Heroes";
            games[84].EmulatorName = emulators[6].Name;
            games[84].EmulatorLoc = emulators[6].Location;
            games[84].GameType = gameTypes[10];
            games[84].emulator();
            


            games[85].GameName = "Sonic Riders";
            games[85].EmulatorName = emulators[6].Name;
            games[85].EmulatorLoc = emulators[6].Location;
            games[85].GameType = gameTypes[10];
            games[85].emulator();
            


            games[86].GameName = "Sonic Mega Collection";
            games[86].EmulatorName = emulators[6].Name;
            games[86].EmulatorLoc = emulators[6].Location;
            games[86].GameType = gameTypes[10];
            games[86].emulator();
            


            games[87].GameName = "Sonic Gems Collection";
            games[87].EmulatorName = emulators[6].Name;
            games[87].EmulatorLoc = emulators[6].Location;
            games[87].GameType = gameTypes[10];
            games[87].emulator();
            


            //---WII---


            games[88].GameName = "Sonic and the Secret Rings";
            games[88].EmulatorName = emulators[7].Name;
            games[88].EmulatorLoc = emulators[7].Location;
            games[88].GameType = gameTypes[11];
            games[88].emulator();
            


            games[89].GameName = "Sonic and the Black Knight";
            games[89].EmulatorName = emulators[7].Name;
            games[89].EmulatorLoc = emulators[7].Location;
            games[89].GameType = gameTypes[11];
            games[89].emulator();
            

            games[90].GameName = "Sonic the Hedgehog 4 Episode 1";
            games[90].EmulatorName = emulators[7].Name;
            games[90].EmulatorLoc = emulators[7].Location;
            games[90].GameType = gameTypes[11];
            games[90].emulator();
            


            games[91].GameName = "Sonic Riders: Zero Gravity";
            games[91].EmulatorName = emulators[7].Name;
            games[91].EmulatorLoc = emulators[7].Location;
            games[91].GameType = gameTypes[11];
            games[91].emulator();
            


            games[92].GameName = "Sonic Unleashed";
            games[92].EmulatorName = emulators[7].Name;
            games[92].EmulatorLoc = emulators[7].Location;
            games[92].GameType = gameTypes[11];
            games[92].emulator();
            


            games[93].GameName = "Sonic Colors";
            games[93].EmulatorName = emulators[7].Name;
            games[93].EmulatorLoc = emulators[7].Location;
            games[93].GameType = gameTypes[11];
            games[93].emulator();
            


            games[94].GameName = "Sonic && Sega All Star Racing";
            games[94].EmulatorName = emulators[7].Name;
            games[94].EmulatorLoc = emulators[7].Location;
            games[94].GameType = gameTypes[11];
            games[94].emulator();
            


            games[95].GameName = "Sega Superstars Tennis";
            games[95].EmulatorName = emulators[7].Name;
            games[95].EmulatorLoc = emulators[7].Location;
            games[95].GameType = gameTypes[11];
            games[95].emulator();
            


            games[96].GameName = "Mario && Sonic at the Olympic Games";
            games[96].EmulatorName = emulators[7].Name;
            games[96].EmulatorLoc = emulators[7].Location;
            games[96].GameType = gameTypes[11];
            games[96].emulator();
            


            games[97].GameName = "Mario && Sonic at the Olympic Winter Games";
            games[97].EmulatorName = emulators[7].Name;
            games[97].EmulatorLoc = emulators[7].Location;
            games[97].GameType = gameTypes[11];
            games[97].emulator();
            


            games[98].GameName = "Mario && Sonic at the London 2012 Olympic Games";
            games[98].EmulatorName = emulators[7].Name;
            games[98].EmulatorLoc = emulators[7].Location;
            games[98].GameType = gameTypes[11];
            games[98].emulator();
            


            games[99].GameName = "Sonic the Hedgehog (VC)";
            games[99].EmulatorName = emulators[7].Name;
            games[99].EmulatorLoc = emulators[7].Location;
            games[99].GameType = gameTypes[11];
            games[99].emulator();
            


            games[100].GameName = "Sonic the Hedgehog (8-bit) (VC)";
            games[100].EmulatorName = emulators[7].Name;
            games[100].EmulatorLoc = emulators[7].Location;
            games[100].GameType = gameTypes[11];
            games[100].emulator();
            


            games[101].GameName = "Sonic the Hedgehog 2 (VC)";
            games[101].EmulatorName = emulators[7].Name;
            games[101].EmulatorLoc = emulators[7 ].Location;
            games[101].GameType = gameTypes[11];
            games[101].emulator();
            


            games[102].GameName = "Sonic the Hedgehog 2 (8-bit) (VC)";
            games[102].EmulatorName = emulators[7].Name;
            games[102].EmulatorLoc = emulators[7].Location;
            games[102].GameType = gameTypes[11];
            games[102].emulator();
            


            games[103].GameName = "Sonic the Hedgehog 3 (VC)";
            games[103].EmulatorName = emulators[7].Name;
            games[103].EmulatorLoc = emulators[7].Location;
            games[103].GameType = gameTypes[11];
            games[103].emulator();
            


            games[104].GameName = "Sonic & Knuckles (VC)";
            games[104].EmulatorName = emulators[7].Name;
            games[104].EmulatorLoc = emulators[7].Location;
            games[104].GameType = gameTypes[11];
            games[104].emulator();
            


            games[105].GameName = "Sonic Chaos (VC)";
            games[105].EmulatorName = emulators[7].Name;
            games[105].EmulatorLoc = emulators[7].Location;
            games[105].GameType = gameTypes[11];
            games[105].emulator();
            


            games[106].GameName = "Sonic 3D Blast (VC)";
            games[106].EmulatorName = emulators[7].Name;
            games[106].EmulatorLoc = emulators[7].Location;
            games[106].GameType = gameTypes[11];
            games[106].emulator();
            


            games[107].GameName = "Sonic Spinball (VC)";
            games[107].EmulatorName = emulators[7].Name;
            games[107].EmulatorLoc = emulators[7].Location;
            games[107].GameType = gameTypes[11];
            games[107].emulator();
            


            games[108].GameName = "Dr. Robotnik's Mean Bean Machine (VC)";
            games[108].EmulatorName = emulators[7].Name;
            games[108].EmulatorLoc = emulators[7].Location;
            games[108].GameType = gameTypes[11];
            games[108].emulator();
            


            //---WII U---

            games[109].GameName = "Sonic Lost World";
            games[109].EmulatorName = emulators[8].Name;
            games[109].EmulatorLoc = emulators[8].Location;
            games[109].GameType = gameTypes[12];
            games[109].emulator();
            


            games[110].GameName = "Sonic && All-Stars Racing Transformed";
            games[110].EmulatorName = emulators[8].Name;
            games[110].EmulatorLoc = emulators[8].Location;
            games[110].GameType = gameTypes[12];
            games[110].emulator();
            


            games[111].GameName = "Sonic Boom: Rise of Lyric";
            games[111].EmulatorName = emulators[8].Name;
            games[111].EmulatorLoc = emulators[8].Location;
            games[111].GameType = gameTypes[12];
            games[111].emulator();
            


            games[112].GameName = "Mario & Sonic at the Sochi 2014 Olympic Winter Games";
            games[112].EmulatorName = emulators[8].Name;
            games[112].EmulatorLoc = emulators[8].Location;
            games[112].GameType = gameTypes[12];
            games[112].emulator();
            


            games[113].GameName = "Mario & Sonic at the Rio 2016 Olympic Games";
            games[113].EmulatorName = emulators[8].Name;
            games[113].EmulatorLoc = emulators[8].Location;
            games[113].GameType = gameTypes[12];
            games[113].emulator();
            


            games[114].GameName = "Sonic Advance (VC)";
            games[114].EmulatorName = emulators[8].Name;
            games[114].EmulatorLoc = emulators[8].Location;
            games[114].GameType = gameTypes[12];
            games[114].emulator();
            


            games[115].GameName = "Sonic Advance 2 (VC)";
            games[115].EmulatorName = emulators[8].Name;
            games[115].EmulatorLoc = emulators[8].Location;
            games[115].GameType = gameTypes[12];
            games[115].emulator();
            


            games[116].GameName = "Sonic Advance 3 (VC)";
            games[116].EmulatorName = emulators[8].Name;
            games[116].EmulatorLoc = emulators[8].Location;
            games[116].GameType = gameTypes[12];
            games[116].emulator();
            


            //---SWITCH---

            games[117].GameName = "Sonic Mania";
            games[117].EmulatorName = emulators[9].Name;
            games[117].EmulatorLoc = emulators[9].Location;
            games[117].GameType = gameTypes[13];
            games[117].emulator();
            


            games[118].GameName = "Sonic Forces";
            games[118].EmulatorName = emulators[9].Name;
            games[118].EmulatorLoc = emulators[9].Location;
            games[118].GameType = gameTypes[13];
            games[118].emulator();
            


            games[119].GameName = "Sonic Colours: Ultimate";
            games[119].EmulatorName = emulators[9].Name;
            games[119].EmulatorLoc = emulators[9].Location;
            games[119].GameType = gameTypes[13];
            games[119].emulator();
            


            games[120].GameName = "Sonic Origins";
            games[120].EmulatorName = emulators[9].Name;
            games[120].EmulatorLoc = emulators[9].Location;
            games[120].GameType = gameTypes[13];
            games[120].emulator();
            


            games[121].GameName = "Sonic Frontiers";
            games[121].EmulatorName = emulators[9].Name;
            games[121].EmulatorLoc = emulators[9].Location;
            games[121].GameType = gameTypes[13];
            games[121].emulator();
            


            games[122].GameName = "Sonic Superstars";
            games[122].EmulatorName = emulators[9].Name;
            games[122].EmulatorLoc = emulators[9].Location;
            games[122].GameType = gameTypes[13];
            games[122].emulator();
            


            games[123].GameName = "Team Sonic Racing";
            games[123].EmulatorName = emulators[9].Name;
            games[123].EmulatorLoc = emulators[9].Location;
            games[123].GameType = gameTypes[13];
            games[123].emulator();
            


            games[124].GameName = "Mario & Sonic at the Olympic Games Tokyo 2020";
            games[124].EmulatorName = emulators[9].Name;
            games[124].EmulatorLoc = emulators[9].Location;
            games[124].GameType = gameTypes[13];
            games[124].emulator();
            


            games[125].GameName = "Sega Ages Sonic the Hedgehog";
            games[125].EmulatorName = emulators[9].Name;
            games[125].EmulatorLoc = emulators[9].Location;
            games[125].GameType = gameTypes[13];
            games[125].emulator();
            


            games[126].GameName = "Sega Ages Sonic the Hedgehog 2";
            games[126].EmulatorName = emulators[9].Name;
            games[126].EmulatorLoc = emulators[9].Location;
            games[126].GameType = gameTypes[13];
            games[126].emulator();
            


            //---PS2---

            games[127].GameName = "Sonic Heroes";
            games[127].EmulatorName = emulators[10].Name;
            games[127].EmulatorLoc = emulators[10].Location;
            games[127].GameType = gameTypes[14];
            games[127].emulator();
            


            games[128].GameName = "Shadow The Hedgehog";
            games[128].EmulatorName = emulators[10].Name;
            games[128].EmulatorLoc = emulators[10].Location;
            games[128].GameType = gameTypes[14];
            games[128].emulator();
            


            games[129].GameName = "Sonic Unleashed";
            games[129].EmulatorName = emulators[10].Name;
            games[129].EmulatorLoc = emulators[10].Location;
            games[129].GameType = gameTypes[14];
            games[129].emulator();
            


            games[130].GameName = "Sonic Riders";
            games[130].EmulatorName = emulators[10].Name;
            games[130].EmulatorLoc = emulators[10].Location;
            games[130].GameType = gameTypes[14];
            games[130].emulator();
            


            games[131].GameName = "Sonic Riders: Zero Gravity";
            games[131].EmulatorName = emulators[10].Name;
            games[131].EmulatorLoc = emulators[10].Location;
            games[131].GameType = gameTypes[14];
            games[131].emulator();
            


            games[132].GameName = "Sonic Mega Collection Plus";
            games[132].EmulatorName = emulators[10].Name;
            games[132].EmulatorLoc = emulators[10].Location;
            games[132].GameType = gameTypes[14];
            games[132].emulator();
            


            games[133].GameName = "Sonic Gems Collection";
            games[133].EmulatorName = emulators[10].Name;
            games[133].EmulatorLoc = emulators[10].Location;
            games[133].GameType = gameTypes[14];
            games[133].emulator();
            


            games[134].GameName = "Sega Superstars";
            games[134].EmulatorName = emulators[10].Name;
            games[134].EmulatorLoc = emulators[10].Location;
            games[134].GameType = gameTypes[14];
            games[134].emulator();
            


            games[135].GameName = "Sega Superstars Tennis";
            games[135].EmulatorName = emulators[10].Name;
            games[135].EmulatorLoc = emulators[10].Location;
            games[135].GameType = gameTypes[14];
            games[135].emulator();
            


            games[136].GameName = "Sega Genesis Collection";
            games[136].EmulatorName = emulators[10].Name;
            games[136].EmulatorLoc = emulators[10].Location;
            games[136].GameType = gameTypes[14];
            games[136].emulator();
            


            //---PS3---
            games[137].GameName = "Sonic the Hedgehog (2006)";
            games[137].EmulatorName = emulators[11].Name;
            games[137].EmulatorLoc = emulators[11].Location;
            games[137].ModLoaderName = ModLoaders[12].Name;
            games[137].ModLoaderLoc = ModLoaders[12].Location;
            games[137].GameType = gameTypes[15];
            games[137].emulator();
            games[137].modLoader();
            


            games[138].GameName = "Sonic Unleashed";
            games[138].EmulatorName = emulators[11].Name;
            games[138].EmulatorLoc = emulators[11].Location;
            games[138].ModLoaderName = ModLoaders[13].Name;
            games[138].ModLoaderLoc= ModLoaders[13].Location;
            games[138].GameType = gameTypes[15];
            games[138].emulator();
            games[138].modLoader();
            


            games[139].GameName = "Sonic Generations";
            games[139].EmulatorName = emulators[11].Name;
            games[139].EmulatorLoc = emulators[11].Location;
            games[139].GameType = gameTypes[15];
            games[139].emulator();
            


            games[140].GameName = "Sonic the Hedgehog 4 Episode I";
            games[140].EmulatorName = emulators[11].Name;
            games[140].EmulatorLoc = emulators[11].Location;
            games[140].GameType = gameTypes[15];
            games[140].emulator();
            


            games[141].GameName = "Sonic the Hedgehog 4 Episode II";
            games[141].EmulatorName = emulators[11].Name;
            games[141].EmulatorLoc = emulators[11].Location;
            games[141].GameType = gameTypes[15];
            games[141].emulator();
            


            games[142].GameName = "Sonic the Hedgehog (Sega Vintage Collection)";
            games[142].EmulatorName = emulators[11].Name;
            games[142].EmulatorLoc = emulators[11].Location;
            games[142].GameType = gameTypes[15];
            games[142].emulator();
            


            games[143].GameName = "Sonic the Hedgehog 2 (Sega Vintage Collection)";
            games[143].EmulatorName = emulators[11].Name;
            games[143].EmulatorLoc = emulators[11].Location;
            games[143].GameType = gameTypes[15];
            games[143].emulator();
            


            games[144].GameName = "Sonic the Hedgehog CD (2011)";
            games[144].EmulatorName = emulators[11].Name;
            games[144].EmulatorLoc = emulators[11].Location;
            games[144].GameType = gameTypes[15];
            games[144].emulator();
            


            games[145].GameName = "Sonic the Fighters";
            games[145].EmulatorName = emulators[11].Name;
            games[145].EmulatorLoc = emulators[11].Location;
            games[145].GameType = gameTypes[15];
            games[145].emulator();
            


            games[146].GameName = "Sonic Adventure DX";
            games[146].EmulatorName = emulators[11].Name;
            games[146].EmulatorLoc = emulators[11].Location;
            games[146].GameType = gameTypes[15];
            games[146].emulator();
            


            games[147].GameName = "Sonic Adventure 2: Battle";
            games[147].EmulatorName = emulators[11].Name;
            games[147].EmulatorLoc = emulators[11].Location;
            games[147].GameType = gameTypes[15];
            games[147].emulator();
            


            games[148].GameName = "Sonic && Sega All-Stars Racing";
            games[148].EmulatorName = emulators[11].Name;
            games[148].EmulatorLoc = emulators[11].Location;
            games[148].GameType = gameTypes[15];
            games[148].emulator();
            


            games[149].GameName = "Sonic && All-Stars Racing Transformed";
            games[149].EmulatorName = emulators[11].Name;
            games[149].EmulatorLoc = emulators[11].Location;
            games[149].GameType = gameTypes[15];
            games[149].emulator();
            


            games[150].GameName = "Sega Superstars Tennis";
            games[150].EmulatorName = emulators[11].Name;
            games[150].EmulatorLoc = emulators[11].Location;
            games[150].GameType = gameTypes[15];
            games[150].emulator();
            


            //---XBOX---

            games[151].GameName = "Sonic Heroes";
            games[151].EmulatorName = emulators[12].Name;
            games[151].EmulatorLoc = emulators[12].Location;
            games[151].GameType = gameTypes[16];
            games[151].emulator();
            


            games[152].GameName = "Shadow the Hedgehog";
            games[152].EmulatorName = emulators[12].Name;
            games[152].EmulatorLoc = emulators[12].Location;
            games[152].GameType = gameTypes[16];
            games[152].emulator();
            


            games[153].GameName = "Sonic Riders";
            games[153].EmulatorName = emulators[12].Name;
            games[153].EmulatorLoc = emulators[12].Location;
            games[153].GameType = gameTypes[16];
            games[153].emulator();
            


            games[154].GameName = "Sonic Mega Collection Plus";
            games[154].EmulatorName = emulators[12].Name;
            games[154].EmulatorLoc = emulators[12].Location;
            games[154].GameType = gameTypes[16];
            games[154].emulator();
            


            //---XBOX 360---

            games[155].GameName = "Sonic the Hedgehog (2006)";
            games[155].EmulatorName = emulators[13].Name;
            games[155].EmulatorLoc = emulators[13].Location;
            games[155].ModLoaderName = ModLoaders[12].Name;
            games[155].ModLoaderLoc = ModLoaders[12].Location;
            games[155].GameType = gameTypes[17];
            games[155].emulator();
            games[155].modLoader();
            


            games[156].GameName = "Sonic Unleashed";
            games[156].EmulatorName = emulators[13].Name;
            games[156].EmulatorLoc = emulators[13].Location;
            games[156].ModLoaderName = ModLoaders[13].Name;
            games[156].ModLoaderLoc = ModLoaders[13].Location;
            games[156].GameType = gameTypes[17];
            games[156].emulator();
            games[156].modLoader();
            


            games[157].GameName = "Sonic Generations";
            games[157].EmulatorName = emulators[13].Name;
            games[157].EmulatorLoc = emulators[13].Location;
            games[157].GameType = gameTypes[17];
            games[157].emulator();
            


            games[158].GameName = "Sonic the Hedgehog 4 Episode I";
            games[158].EmulatorName = emulators[13].Name;
            games[158].EmulatorLoc = emulators[13].Location;
            games[158].GameType = gameTypes[17];
            games[158].emulator();
            


            games[159].GameName = "Sonic the Hedgehog 4 Episode II";
            games[159].EmulatorName = emulators[13].Name;
            games[159].EmulatorLoc = emulators[13].Location;
            games[159].GameType = gameTypes[17];
            games[159].emulator();
            


            games[160].GameName = "Sonic Free Riders";
            games[160].EmulatorName = emulators[13].Name;
            games[160].EmulatorLoc = emulators[13].Location;
            games[160].GameType = gameTypes[17];
            games[160].emulator();
            


            games[161].GameName = "Sonic && Sega All-Stars Racing";
            games[161].EmulatorName = emulators[13].Name;
            games[161].EmulatorLoc = emulators[13].Location;
            games[161].GameType = gameTypes[17];
            games[161].emulator();
            


            games[162].GameName = "Sonic & All-Stars Racing Transformed";
            games[162].EmulatorName = emulators[13].Name;
            games[162].EmulatorLoc = emulators[13].Location;
            games[162].GameType = gameTypes[17];
            games[162].emulator();
            


            games[163].GameName = "Sega Superstars Tennis";
            games[163].EmulatorName = emulators[13].Name;
            games[163].EmulatorLoc = emulators[13].Location;
            games[163].GameType = gameTypes[17];
            games[163].emulator();
            


            games[164].GameName = "Sonic the Hedgehog (XBLA)";
            games[164].EmulatorName = emulators[13].Name;
            games[164].EmulatorLoc = emulators[13].Location;
            games[164].GameType = gameTypes[17];
            games[164].emulator();
            


            games[165].GameName = "Sonic the Hedgehog 2 (XBLA)";
            games[165].EmulatorName = emulators[13].Name;
            games[165].EmulatorLoc = emulators[13].Location;
            games[165].GameType = gameTypes[17];
            games[165].emulator();
            


            games[166].GameName = "Sonic the Hedgehog CD (2011)";
            games[166].EmulatorName = emulators[13].Name;
            games[166].EmulatorLoc = emulators[13].Location;
            games[166].GameType = gameTypes[17];
            games[166].emulator();
            


            games[167].GameName = "Sonic the Hedgehog 3 (XBLA)";
            games[167].EmulatorName = emulators[13].Name;
            games[167].EmulatorLoc = emulators[13].Location;
            games[167].GameType = gameTypes[17];
            games[167].emulator();
            


            games[168].GameName = "Sonic && Knuckles (XBLA)";
            games[168].EmulatorName = emulators[13].Name;
            games[168].EmulatorLoc = emulators[13].Location;
            games[168].GameType = gameTypes[17];
            games[168].emulator();
            


            games[169].GameName = "Sonic the Fighters";
            games[169].EmulatorName = emulators[13].Name;
            games[169].EmulatorLoc = emulators[13].Location;
            games[169].GameType = gameTypes[17];
            games[169].emulator();
            


            games[170].GameName = "Sonic Adventure";
            games[170].EmulatorName = emulators[13].Name;
            games[170].EmulatorLoc = emulators[13].Location;
            games[170].GameType = gameTypes[17];
            games[170].emulator();
            


            games[171].GameName = "Sonic Adventure 2";
            games[171].EmulatorName = emulators[13].Name;
            games[171].EmulatorLoc = emulators[13].Location;
            games[171].GameType = gameTypes[17];
            games[171].emulator();
            


            //---NEO GEO POCKET---

            games[172].GameName = "Sonic the Hedgehog Pocket Adventure";
            games[172].EmulatorName = emulators[14].Name;
            games[172].EmulatorLoc = emulators[14].Location;
            games[172].GameType = gameTypes[18];
            games[172].emulator();
            


            //---GBA---

            games[173].GameName = "Sonic Advance";
            games[173].EmulatorName = emulators[15].Name;
            games[173].EmulatorLoc = emulators[15].Location;
            games[173].GameType = gameTypes[19];
            games[173].emulator();
            


            games[174].GameName = "Sonic Advance 2";
            games[174].EmulatorName = emulators[15].Name;
            games[174].EmulatorLoc = emulators[15].Location;
            games[174].GameType = gameTypes[19];
            games[174].emulator();
            


            games[175].GameName = "Sonic Battle";
            games[175].EmulatorName = emulators[15].Name;
            games[175].EmulatorLoc = emulators[15].Location;
            games[175].GameType = gameTypes[19];
            games[175].emulator();
            


            games[176].GameName = "Sonic Advance 3";
            games[176].EmulatorName = emulators[15].Name;
            games[176].EmulatorLoc = emulators[15].Location;
            games[176].GameType = gameTypes[19];
            games[176].emulator();
            


            games[177].GameName = "Sonic Pinball Party";
            games[177].EmulatorName = emulators[15].Name;
            games[177].EmulatorLoc = emulators[15].Location;
            games[177].GameType = gameTypes[19];
            games[177].emulator();
            


            games[178].GameName = "Tiny Chao Garden";
            games[178].EmulatorName = emulators[15].Name;
            games[178].EmulatorLoc = emulators[15].Location;
            games[178].GameType = gameTypes[19];
            games[178].emulator();
            


            games[179].GameName = "Sonic X: A Super Sonic Hero";
            games[179].EmulatorName = emulators[15].Name;
            games[179].EmulatorLoc = emulators[15].Location;
            games[179].GameType = gameTypes[19];
            games[179].emulator();
            


            games[180].GameName = "Sonic the Hedgehog Genesis";
            games[180].EmulatorName = emulators[15].Name;
            games[180].EmulatorLoc = emulators[15].Location;
            games[180].GameType = gameTypes[19];
            games[180].emulator();
            


            //---DS---

            games[181].GameName = "Sonic Rush";
            games[181].EmulatorName = emulators[16].Name;
            games[181].EmulatorLoc = emulators[16].Location;
            games[181].GameType = gameTypes[20];
            games[181].emulator();
            


            games[182].GameName = "Sonic Rush Adventure";
            games[182].EmulatorName = emulators[16].Name;
            games[182].EmulatorLoc = emulators[16].Location;
            games[182].GameType = gameTypes[20];
            games[182].emulator();
            


            games[183].GameName = "Sonic Colors";
            games[183].EmulatorName = emulators[16].Name;
            games[183].EmulatorLoc = emulators[16].Location;
            games[183].GameType = gameTypes[20];
            games[183].emulator();
            


            games[184].GameName = "Sonic Chronicles: The Dark Brotherhood";
            games[184].EmulatorName = emulators[16].Name;
            games[184].EmulatorLoc = emulators[16].Location;
            games[184].GameType = gameTypes[20];
            games[184].emulator();
            


            games[185].GameName = "Sega Superstars Tennis";
            games[185].EmulatorName = emulators[16].Name;
            games[185].EmulatorLoc = emulators[16].Location;
            games[185].GameType = gameTypes[20];
            games[185].emulator();
            


            games[186].GameName = "Sonic && Sega All-Stars Racing";
            games[186].EmulatorName = emulators[16].Name;
            games[186].EmulatorLoc = emulators[16].Location;
            games[186].GameType = gameTypes[20];
            games[186].emulator();
            


            games[187].GameName = "Mario && Sonic at the Olympic Games";
            games[187].EmulatorName = emulators[16].Name;
            games[187].EmulatorLoc = emulators[16].Location;
            games[187].GameType = gameTypes[20];
            games[187].emulator();
            


            games[188].GameName = "Mario && Sonic at the Olympic Winter Games";
            games[188].EmulatorName = emulators[16].Name;
            games[188].EmulatorLoc = emulators[16].Location;
            games[188].GameType = gameTypes[20];
            games[188].emulator();
            


            games[189].GameName = "Sonic Classic Collection";
            games[189].EmulatorName = emulators[16].Name;
            games[189].EmulatorLoc = emulators[16].Location;
            games[189].GameType = gameTypes[20];
            games[189].emulator();
            


            //---3DS---

            games[190].GameName = "Sonic Generations";
            games[190].EmulatorName = emulators[17].Name;
            games[190].EmulatorLoc = emulators[17].Location;
            games[190].GameType = gameTypes[21];
            games[190].emulator();
            


            games[191].GameName = "Sonic Lost World";
            games[191].EmulatorName = emulators[17].Name;
            games[191].EmulatorLoc = emulators[17].Location;
            games[191].GameType = gameTypes[21];
            games[191].emulator();
            


            games[192].GameName = "Sonic Boom: Shattered Crystal";
            games[192].EmulatorName = emulators[17].Name;
            games[192].EmulatorLoc = emulators[17].Location;
            games[192].GameType = gameTypes[21];
            games[192].emulator();
            


            games[193].GameName = "Sonic Boom: Fire and Ice";
            games[193].EmulatorName = emulators[17].Name;
            games[193].EmulatorLoc = emulators[17].Location;
            games[193].GameType = gameTypes[21];
            games[193].emulator();
            


            games[194].GameName = "Sonic && All-Stars Racing Transformed";
            games[194].EmulatorName = emulators[17].Name;
            games[194].EmulatorLoc = emulators[17].Location;
            games[194].GameType = gameTypes[21];
            games[194].emulator();
            


            games[195].GameName = "Mario && Sonic at the London 2012 Olympic Games";
            games[195].EmulatorName = emulators[17].Name;
            games[195].EmulatorLoc = emulators[17].Location;
            games[195].GameType = gameTypes[21];
            games[195].emulator();
            


            games[196].GameName = "Mario && Sonic - London 2012 Virtual Card Album";
            games[196].EmulatorName = emulators[17].Name;
            games[196].EmulatorLoc = emulators[17].Location;
            games[196].GameType = gameTypes[21];
            games[196].emulator();
            


            games[197].GameName = "Mario & Sonic at the Rio 2016 Olympic Games";
            games[197].EmulatorName = emulators[17].Name;
            games[197].EmulatorLoc = emulators[17].Location;
            games[197].GameType = gameTypes[21];
            games[197].emulator();
            


            games[198].GameName = "3D Sonic the Hedgehog";
            games[198].EmulatorName = emulators[17].Name;
            games[198].EmulatorLoc = emulators[17].Location;
            games[198].GameType = gameTypes[21];
            games[198].emulator();
            


            games[199].GameName = "3D Sonic the Hedgehog 2";
            games[199].EmulatorName = emulators[17].Name;
            games[199].EmulatorLoc = emulators[17].Location;
            games[199].GameType = gameTypes[21];
            games[199].emulator();
            


            games[200].GameName = "Sonic the Hedgehog (8-bit) (VC)";
            games[200].EmulatorName = emulators[17].Name;
            games[200].EmulatorLoc = emulators[17].Location;
            games[200].GameType = gameTypes[21];
            games[200].emulator();
            


            games[201].GameName = "Sonic the Hedgehog 2 (8-bit) (VC)";
            games[201].EmulatorName = emulators[17].Name;
            games[201].EmulatorLoc = emulators[17].Location;
            games[201].GameType = gameTypes[21];
            games[201].emulator();
            


            games[202].GameName = "Sonic the Hedgehog Triple Trouble (VC)";
            games[202].EmulatorName = emulators[17].Name;
            games[202].EmulatorLoc = emulators[17].Location;
            games[202].GameType = gameTypes[21];
            games[202].emulator();
            


            games[203].GameName = "Sonic Blast (VC)";
            games[203].EmulatorName = emulators[17].Name;
            games[203].EmulatorLoc = emulators[17].Location;
            games[203].GameType = gameTypes[21];
            games[203].emulator();
            


            games[204].GameName = "Sonic Labyrinth (VC)";
            games[204].EmulatorName = emulators[17].Name;
            games[204].EmulatorLoc = emulators[17].Location;
            games[204].GameType = gameTypes[21];
            games[204].emulator();
            


            games[205].GameName = "Sonic Drift 2 (VC)";
            games[205].EmulatorName = emulators[17].Name;
            games[205].EmulatorLoc = emulators[17].Location;
            games[205].GameType = gameTypes[21];
            games[205].emulator();
            


            games[206].GameName = "Dr. Robotnik's Mean Bean Machine (8-bit) (VC)";
            games[206].EmulatorName = emulators[17].Name;
            games[206].EmulatorLoc = emulators[17].Location;
            games[206].GameType = gameTypes[21];
            games[206].emulator();
            


            games[207].GameName = "Tails' Adventures (VC)";
            games[207].EmulatorName = emulators[17].Name;
            games[207].EmulatorLoc = emulators[17].Location;
            games[207].GameType = gameTypes[21];
            games[207].emulator();
            


            //---PSP---

            games[208].GameName = "Sonic Rivals";
            games[208].EmulatorName = emulators[18].Name;
            games[208].EmulatorLoc = emulators[18].Location;
            games[208].GameType = gameTypes[22];
            games[208].emulator();
            


            games[209].GameName = "Sonic Rivals 2";
            games[209].EmulatorName = emulators[18].Name;
            games[209].EmulatorLoc = emulators[18].Location;
            games[209].GameType = gameTypes[22];
            games[209].emulator();
            


            games[210].GameName = "Sega Genesis Collection";
            games[210].EmulatorName = emulators[18].Name;
            games[210].EmulatorLoc = emulators[18].Location;
            games[210].GameType = gameTypes[22];
            games[210].emulator();
            


            //Stuff I missed

            games[211].GameName = "Shadow the Hedgehog"; //gamecube
            games[211].EmulatorName = emulators[6].Name;
            games[211].EmulatorLoc = emulators[6].Location;
            games[211].ModLoaderName = ModLoaders[10].Name;
            games[211].ModLoaderLoc = ModLoaders[10].Location;
            games[211].GameType = gameTypes[10];
            games[211].emulator();
            

            games[212].GameName = "Blue Spheres"; //mega drive  
            games[212].EmulatorName = emulators[0].Name;
            games[212].EmulatorLoc = emulators[0].Location;
            games[212].GameType = gameTypes[3];
            games[212].emulator();



            checkActives();


        }

        public void checkActives()
        {
            for(int i = 0;i < games.Length;i++)
            {
                activeGames[i] = games[i].isActive;
            }
        }

        public void updateEmuls()
        {
            for (int i = 0; i < games.Length;i++)
            {
                string emuNa = games[i].EmulatorName;

                switch (emuNa)
                {
                    case "Mega Drive"          :
                        games[i].EmulatorLoc = emulators[0].Location;
                        break;

                    case "Master System"       :
                        games[i].EmulatorLoc = emulators[1].Location;
                        break;

                    case "Game Gear"           :
                        games[i].EmulatorLoc = emulators[2].Location;
                        break;

                    case "Sega Saturn"         :
                        games[i].EmulatorLoc = emulators[3].Location;
                        break;

                    case "Dreamcast"           :
                        games[i].EmulatorLoc = emulators[4].Location;
                        break;

                    case "Arcade (MAME)"       :
                        games[i].EmulatorLoc = emulators[5].Location;
                        break;

                    case "GameCube"            :
                        games[i].EmulatorLoc = emulators[6].Location;
                        break;

                    case "Wii"                 :
                        games[i].EmulatorLoc = emulators[7].Location;
                        break;

                    case "Wii U"               :
                        games[i].EmulatorLoc = emulators[8].Location;
                        break;

                    case "Switch"              :
                        games[i].EmulatorLoc = emulators[9].Location;
                        break;

                    case "PS2"                 :
                        games[i].EmulatorLoc = emulators[10].Location;
                        break;

                    case "PS3"                 :
                        games[i].EmulatorLoc = emulators[11].Location;
                        break;

                    case "XBox"                :
                        games[i].EmulatorLoc = emulators[12].Location;
                        break;

                    case "XBox 360"            :
                        games[i].EmulatorLoc = emulators[13].Location;
                        break;

                    case "Neo Geo Pocket Color":
                        games[i].EmulatorLoc = emulators[14].Location;
                        break;

                    case "Game Boy Advance"    :
                        games[i].EmulatorLoc = emulators[15].Location;
                        break;

                    case "DS"                  :
                        games[i].EmulatorLoc = emulators[16].Location;
                        break;

                    case "3DS"                 :
                        games[i].EmulatorLoc = emulators[17].Location;
                        break;

                    case "PSP"                 :
                        games[i].EmulatorLoc = emulators[18].Location;
                        break;

                    case "Sega PC Reloaded"    :
                        games[i].EmulatorLoc = emulators[19].Location;
                        break;

                    case "Sega AM2"            :
                        games[i].EmulatorLoc = emulators[20].Location;
                        break;
                }

            }
        }

        public ProgramInfo getEmulFromGame(string name, string type)
        {
            ProgramInfo info = null;

            for (int i = 0; i < games.Length; i++)
            {
                if (games[i].GameName == name && games[i].GameType == type)
                {
                    for (int j = 0; j < emulators.Length; j++)
                    {
                        if (emulators[j].Name == games[i].EmulatorName)
                            info = emulators[j];
                    }
                }
            }

            return info;
        }

        public void applyArgs(string emulName, string args)
        {
            for (int i = 0;i < games.Length;i++)
            {
                if (games[i].EmulatorName == emulName)
                    games[i].EmuArgs = args;
            }
        }
    }

    [Serializable]
    public static class LaunchContainer //Static version
    {
        public static LauncherMainItems launcher;
        public static int[] activeGameTypes;

        static LaunchContainer() 
        { 
            launcher = new LauncherMainItems(); 
            activeGameTypes = new int[launcher.GameTypes.Length];
            
            for (int i = 0; i < activeGameTypes.Length; i++)
            {
                activeGameTypes[i] = 0;
            }
        }

        public static void incrementGameTypes()
        {
            int spot=0;

            for (int i = 0; i < activeGameTypes.Length; i++)
            {
                activeGameTypes[i] = 0;
            }

            for (int i = 0;i <launcher.Games.Length;i++)
            {
                if (launcher.Games[i].IsActive)
                {
                    for (int j = 0; j < launcher.GameTypes.Length; j++)
                    {
                        if (launcher.GameTypes[j] == launcher.Games[i].GameType)
                        {
                            spot = j;
                            break;
                        }
                    }

                    activeGameTypes[spot]++;
                }

            }
        }
    }

    [Serializable]
    public class ProgramInfo
    {
        private string name;
        private string location;
        private bool specFlag;
        private string specArgs;

        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public bool SpecFlag { get => specFlag; set => specFlag = value; }
        public string SpecArgs { get => specArgs; set => specArgs = value; }

        public ProgramInfo(string name, string location, bool specFlag = false, string specArgs = null)
        {
            this.name = name;
            this.location = location;
            this.specFlag = specFlag;
            this.specArgs = specArgs;
        }

        public ProgramInfo() : this("", "", false, "") { }
    }

    [Serializable]
    public static class ProgramManager
    {
        public static void setModLoaders(ProgramInfo[] progs)
        {
            progs[0].Name = "HedgeModManager";
            progs[1].Name = "SA Mod Loader";
            progs[2].Name = "SA2 Mod Loader";
            progs[3].Name = "Mania Mod Loader";
            progs[4].Name = "Sonic CD Steam Mod Loader";
            progs[5].Name = "Sonic 4 Mod Loader";
            progs[6].Name = "Sonic 4 (EP2) Mod Loader";
            progs[7].Name = "Sonic R Mod Loader";
            progs[8].Name = "S&K Collection Mod Loader";
            progs[9].Name = "RSDK Mod Manager";
            progs[10].Name = "Reloaded 2";
            progs[11].Name = "Concursus";
            progs[12].Name = "Sonic '06 Mod Manager";
            progs[13].Name = "Sonic Unleashed Mod Manager";
        }

        public static void setEmulators(ProgramInfo[] emus)
        {
            emus[0].Name = "Mega Drive";


            emus[1].Name = "Master System";


            emus[2].Name = "Game Gear";


            emus[3].Name = "Sega Saturn";
            emus[3].SpecFlag = true;
            emus[3].SpecArgs = "-i ";

            emus[4].Name = "Dreamcast";


            emus[5].Name = "Arcade (MAME)";


            emus[6].Name = "GameCube";


            emus[7].Name = "Wii";


            emus[8].Name = "Wii U";
            emus[8].SpecFlag = true;
            emus[8].SpecArgs = "-f -g ";


            emus[9].Name = "Switch";


            emus[10].Name = "PS2";


            emus[11].Name = "PS3";


            emus[12].Name = "XBox";


            emus[13].Name = "XBox 360";


            emus[14].Name = "Neo Geo Pocket Color";


            emus[15].Name = "Game Boy Advance";


            emus[16].Name = "DS";


            emus[17].Name = "3DS";


            emus[18].Name = "PSP";


            emus[19].Name = "Sega PC Reloaded";


            emus[20].Name = "Sega AM2";


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
