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
        public Metadata meta;


        public String exeLoc;
        public String modLoaderLoc;
        public String modLoaderName;
        public String emuArgs;
        public bool isActive;
        public bool hasModLoader;
        public bool hasEmulator;

        public Metadata Meta { get => meta; set => meta = value; }
        public string ExeLoc { get => exeLoc; set => exeLoc = value; }
        public string ModLoaderLoc { get => modLoaderLoc; set => modLoaderLoc = value; }
        public string ModLoaderName { get => modLoaderName; set => modLoaderName = value; }
        public string EmuArgs { get => emuArgs; set => emuArgs = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool HasModLoader { get => hasModLoader; set => hasModLoader = value; }
        public bool HasEmulator { get => hasEmulator; set => hasEmulator = value; }
        public bool HasEmulator1 { get => hasEmulator; set => hasEmulator = value; }

        public Game(Metadata meta = null, string exeLoc = "", string modLoaderLoc = "", string modLoaderName = "", string emuArgs = "", bool isActive = false, bool hasModLoader = false, bool hasEmulator = false)
        {
            if (meta == null)
            {
                meta = new Metadata();
            }

            this.meta = meta;
            this.exeLoc = exeLoc;
            this.modLoaderLoc = modLoaderLoc;
            this.modLoaderName = modLoaderName;
            this.emuArgs = emuArgs;
            this.isActive = isActive;
            this.hasModLoader = hasModLoader;
            this.hasEmulator = hasEmulator;
        }

        public void activate () { isActive = true; }
        public void modLoader() { hasModLoader = true; }
        public void emulator() { hasEmulator = true; }
        public void deActivate() { isActive = false; Console.WriteLine(this.meta.Name + " Has been deactivated!"); }
    }

    [Serializable]
    public class LauncherMainItems //basic management of set paths and games
    {
        private const int numOfGames = 300;
        private const int numOfModLoaders = 15;
        private const int numOfEmulators = 30;
        private const int numOfGameTypes = 24;

        private Game[] games;
        private bool[] activeGames;
        private String steamLoc;

        private String[] gameTypes;
        private ProgramInfo[] modLoaders;
        private ProgramInfo[] emulators;




        public LauncherMainItems(Game[] games, string steamLoc, bool[] activeGames, ProgramInfo[] modLoaders = null, ProgramInfo[] emulators = null, string[] gameTypes = null)
        {
            this.games = games;
            this.steamLoc = steamLoc;
            this.activeGames = activeGames;
            this.modLoaders = modLoaders;
            this.emulators = emulators;
            this.gameTypes = gameTypes;
        }

        public LauncherMainItems()
        {
            games = new Game[numOfGames];
            activeGames = new bool[numOfGames];
            modLoaders = new ProgramInfo[numOfModLoaders];
            emulators = new ProgramInfo[numOfEmulators];
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
            }
        

            steamLoc = "";
            ProgramManager.setModLoaders(modLoaders); //names mod loaders
            ProgramManager.setEmulators(emulators);   //names emulated console (for emulators)
            ProgramManager.setGameTypes(gameTypes);   //names types of games (emulated are per console)
            manageGames();
            addEmus();
        }

        public Game[] Games { get => games; set => games = value; }
        public string SteamLoc { get => steamLoc; set => steamLoc = value; }
        public bool[] ActiveGames { get => activeGames; set => activeGames = value; }
        public ProgramInfo[] ModLoaders { get => modLoaders; set => modLoaders = value; }
        public ProgramInfo[] Emulators { get => emulators; set => emulators = value; }
        public string[] GameTypes { get => gameTypes; set => gameTypes = value; }

        public void manageGames()
        {
            //---STEAM---

            games[0].Meta.Name = "Sonic && Sega All Star Racing";
            games[0].ExeLoc = "steam://rungameid/34190";
            games[0].Meta.GameType = gameTypes[0];
            games[0].Meta.Year = 2010;
            


            games[1].Meta.Name = "Sega Mega Drive && Genesis Classics";
            games[1].ExeLoc = "steam://rungameid/34270";
            games[1].Meta.GameType = gameTypes[0];
            games[1].Meta.Year = 2010;


            games[2].Meta.Name = "Sonic the Hedgehog CD";
            games[2].ExeLoc = "steam://rungameid/200940";
            games[2].ModLoaderLoc = modLoaders[4].Location;
            games[2].ModLoaderName = modLoaders[4].Name;
            games[2].Meta.GameType = gameTypes[0];
            games[2].modLoader();
            games[2].Meta.Year = 2012;


            games[3].Meta.Name = "Sonic Adventure DX";
            games[3].ExeLoc = "steam://rungameid/71250";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe");
            games[3].ModLoaderLoc = modLoaders[1].Location;
            games[3].ModLoaderName = modLoaders[1].Name;
            games[3].Meta.GameType = gameTypes[0];
            games[3].modLoader();
            games[3].Meta.Year = 2011;


            games[4].Meta.Name = "Sonic Adventure 2 Battle";
            games[4].ExeLoc = "steam://rungameid/213610";
            games[4].ModLoaderLoc = modLoaders[2].Location;
            games[4].ModLoaderName = modLoaders[2].Name;
            games[4].Meta.GameType = gameTypes[0];
            games[4].modLoader();
            games[4].Meta.Year = 2012;


            games[5].Meta.Name = "Sonic Generations";
            games[5].ExeLoc = "steam://rungameid/71340";//Path.Combine(this.steamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe");
            games[5].ModLoaderLoc = modLoaders[0].Location;
            games[5].ModLoaderName = modLoaders[0].Name;
            games[5].Meta.GameType = gameTypes[0];
            games[5].modLoader();
            games[5].Meta.Year = 2011;


            games[6].Meta.Name = "Sonic the Hedgehog 4 Episode 1";
            games[6].ExeLoc = "steam://rungameid/202530";
            games[6].ModLoaderLoc = modLoaders[5].Location;
            games[6].ModLoaderName = modLoaders[5].Name;
            games[6].Meta.GameType = gameTypes[0];
            games[6].modLoader();
            games[6].Meta.Year = 2012;


            games[7].Meta.Name = "Sonic the Hedgehog 4 Episode 2";
            games[7].ExeLoc = "steam://rungameid/203650";
            games[7].ModLoaderLoc = modLoaders[6].Location;
            games[7].ModLoaderName = modLoaders[6].Name;
            games[7].Meta.GameType = gameTypes[0];
            games[7].modLoader();
            games[7].Meta.Year = 2012;


            games[8].Meta.Name = "Sonic && All Stars Racing Transformed";
            games[8].ExeLoc = "steam://rungameid/212480";
            games[8].Meta.GameType = gameTypes[0];
            games[8].Meta.Year = 2013;


            games[9].Meta.Name = "Sonic Lost World";
            games[9].ExeLoc = "steam://rungameid/329440";
            games[9].ModLoaderLoc = modLoaders[0].Location;
            games[9].ModLoaderName = modLoaders[0].Name;
            games[9].Meta.GameType = gameTypes[0];
            games[9].modLoader();
            games[9].Meta.Year = 2015;


            games[10].Meta.Name = "Sonic Mania";
            games[10].ExeLoc = "steam://rungameid/584400";
            games[10].ModLoaderLoc = modLoaders[3].Location;
            games[10].ModLoaderName = modLoaders[3].Name;
            games[10].Meta.GameType = gameTypes[0];
            games[10].modLoader();
            games[10].Meta.Year = 2017;


            games[11].Meta.Name = "Sonic Forces";
            games[11].ExeLoc = "steam://rungameid/637100";
            games[11].ModLoaderLoc = modLoaders[0].Location;
            games[11].ModLoaderName = modLoaders[0].Name;
            games[11].Meta.GameType = gameTypes[0];
            games[11].modLoader();
            games[11].Meta.Year = 2017;


            games[12].Meta.Name = "Team Sonic Racing";
            games[12].ExeLoc = "steam://rungameid/785260";
            games[12].Meta.GameType = gameTypes[0];
            games[12].Meta.Year = 2019;


            games[13].Meta.Name = "Sonic Colors: Ultimate";
            games[13].ExeLoc = "steam://rungameid/2055290";
            games[13].ModLoaderLoc = modLoaders[0].Location;
            games[13].ModLoaderName = modLoaders[0].Name;
            games[13].Meta.GameType = gameTypes[0];
            games[13].modLoader();
            games[13].Meta.Year = 2023;


            games[14].Meta.Name = "Sonic Origins";
            games[14].ExeLoc = "steam://rungameid/1794960";
            games[14].ModLoaderLoc = modLoaders[0].Location;
            games[14].ModLoaderName = modLoaders[0].Name;
            games[14].Meta.GameType = gameTypes[0];
            games[14].modLoader();
            games[14].Meta.Year = 2022;



            games[15].Meta.Name = "Sonic Frontiers";
            games[15].ExeLoc = "steam://rungameid/1237320";
            games[15].ModLoaderLoc = modLoaders[0].Location;
            games[15].ModLoaderName = modLoaders[0].Name;
            games[15].Meta.GameType = gameTypes[0];
            games[15].modLoader();
            games[15].Meta.Year = 2022;



            games[16].Meta.Name = "The Murder of Sonic The Hedgehog";
            games[16].ExeLoc = "steam://rungameid/2324650";
            games[16].Meta.GameType = gameTypes[0];
            games[16].Meta.Year = 2023;



            games[17].Meta.Name = "Sonic Superstars";
            games[17].ExeLoc = "steam://rungameid/2022670";
            games[17].ModLoaderLoc = modLoaders[11].Location;
            games[17].ModLoaderName = modLoaders[11].Name;
            games[17].Meta.GameType = gameTypes[0];
            games[17].modLoader();
            games[17].Meta.Year = 2023;


            //---EPIC GAMES STORE---


            games[18].Meta.Name = "Sonic Colors: Ultimate";
            games[18].ExeLoc = "com.epicgames.launcher://apps/e5071e19d08c45a6bdda5d92fbd0a03e?action=launch&silent=true";
            games[18].ModLoaderLoc = modLoaders[0].Location;
            games[18].ModLoaderName= modLoaders[0].Name;
            games[18].Meta.GameType = gameTypes[1];
            games[18].modLoader();
            games[18].Meta.Year = 2021;



            games[19].Meta.Name = "Sonic Origins";
            games[19].ExeLoc = "com.epicgames.launcher://apps/5070a8e44cf74ba3b9a4ca0c0dce5cf1?action=launch&silent=true";
            games[19].ModLoaderLoc = modLoaders[0].Location;
            games[19].ModLoaderName = modLoaders[0].Name;
            games[19].Meta.GameType = gameTypes[1];
            games[19].modLoader();
            games[19].Meta.Year = 2022;



            games[20].Meta.Name = "Sonic Mania";
            games[20].ExeLoc = "com.epicgames.launcher://apps/818447bb519b46d48d365d5753362796?action=launch&silent=true";
            games[20].ModLoaderLoc = modLoaders[3].Location;
            games[20].ModLoaderName = modLoaders[3].Name;
            games[20].Meta.GameType = gameTypes[1];
            games[20].modLoader();
            games[20].Meta.Year = 2021;



            games[21].Meta.Name = "Sonic Frontiers";
            games[21].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[21].ModLoaderLoc = modLoaders[0].Location;
            games[21].ModLoaderName = modLoaders[0].Name;
            games[21].Meta.GameType = gameTypes[1];
            games[21].modLoader();
            games[21].Meta.Year = 2023;



            games[22].Meta.Name = "Sonic Superstars";
            games[22].ExeLoc = "com.epicgames.launcher://apps/  ?action=launch&silent=true";
            games[22].ModLoaderLoc = modLoaders[11].Location;
            games[22].ModLoaderName = modLoaders[11].Name;
            games[22].Meta.GameType = gameTypes[1];
            games[22].modLoader();
            games[22].Meta.Year = 2023;



            //---DRM FREE---

            games[23].Meta.Name = "Sonic The Hedgehog (Decompilation)";
            games[23].Meta.GameType = gameTypes[2];
            games[23].ModLoaderName = modLoaders[9].Name;
            games[23].ModLoaderLoc = modLoaders[9].Location;
            games[23].modLoader();
            games[23].Meta.Year = 2013;



            games[24].Meta.Name = "Sonic The Hedgehog 2 (Decompilation)";
            games[24].Meta.GameType = gameTypes[2];
            games[24].ModLoaderName = modLoaders[9].Name;
            games[24].ModLoaderLoc = modLoaders[9].Location;
            games[24].modLoader();
            games[24].Meta.Year = 2013;



            games[25].Meta.Name = "Sonic The Hedgehog CD";
            games[25].Meta.GameType = gameTypes[2];
            games[25].Meta.Year = 1996;



            games[26].Meta.Name = "Sonic CD (Sega PC Reloaded)";
            games[26].Meta.GameType = gameTypes[23];
            games[26].EmuArgs = "/launch 2 \"SONICCD.EXE\"";
            games[26].emulator();
            games[26].Meta.Year = 1996;


            games[27].Meta.Name = "Sonic The Hedgehog CD (Decompilation)";
            games[27].Meta.GameType = gameTypes[2];
            games[27].ModLoaderName = modLoaders[9].Name;
            games[27].ModLoaderLoc = modLoaders[9].Location;
            games[27].modLoader();
            games[27].Meta.Year = 2011;



            games[28].Meta.Name = "Sonic && Knuckles Collection";
            games[28].Meta.GameType = gameTypes[2];
            games[28].Meta.Year = 1997;



            games[29].Meta.Name = "Sonic && Knuckles Collection (Sega PC Reloaded)";
            games[29].Meta.GameType = gameTypes[23];
            games[29].ModLoaderName = modLoaders[8].Name;
            games[29].ModLoaderLoc = modLoaders[8].Location;
            games[29].EmuArgs = "/launch 3 \"SONIC3K.EXE\"";
            games[29].modLoader();
            games[29].emulator();
            games[29].Meta.Year = 1997;



            games[30].Meta.Name = "Sonic 3D Blast";
            games[30].Meta.GameType = gameTypes[2];
            games[30].Meta.Year = 1997;



            games[31].Meta.Name = "Sonic 3D Blast (Sega PC Reloaded)";
            games[31].Meta.GameType = gameTypes[23];
            games[31].EmuArgs = "/launch 4 \"PCSONIC.EXE\"";
            games[31].emulator();
            games[31].Meta.Year = 1997;



            games[32].Meta.Name = "Sonic R";
            games[32].Meta.GameType = gameTypes[2];
            games[32].ModLoaderName = modLoaders[7].Name;
            games[32].ModLoaderLoc = modLoaders[7].Location;
            games[32].modLoader();
            games[32].Meta.Year = 1998;



            games[33].Meta.Name = "Sonic Adventure DX";
            games[33].Meta.GameType = gameTypes[2];
            games[33].ModLoaderName = modLoaders[1].Name;
            games[33].ModLoaderLoc = modLoaders[1].Location;
            games[33].modLoader();
            games[33].Meta.Year = 2003;



            games[34].Meta.Name = "Sonic Heroes";
            games[34].Meta.GameType = gameTypes[2];
            games[34].ModLoaderName = modLoaders[10].Name;
            games[34].ModLoaderLoc = modLoaders[10].Location;
            games[34].modLoader();
            games[34].Meta.Year = 2004;



            games[35].Meta.Name = "Sonic Mega Collection Plus";
            games[35].Meta.GameType = gameTypes[2];
            games[35].Meta.Year = 2007;


            games[36].Meta.Name = "Sonic Riders";
            games[36].Meta.GameType = gameTypes[2];
            games[36].ModLoaderName = modLoaders[10].Name;
            games[36].ModLoaderLoc = modLoaders[10].Location;
            games[36].modLoader();
            games[36].Meta.Year = 2006;


            games[37].Meta.Name = "Sonic Mania (Decompilation)";
            games[37].Meta.GameType = gameTypes[2];
            games[37].ModLoaderName = modLoaders[9].Name;
            games[37].ModLoaderLoc = modLoaders[9].Location;
            games[37].modLoader();
            games[37].Meta.Year = 2017;





            //---MEGA DRIVE---

            games[38].Meta.Name = "Sonic the Hedgehog";             
            games[38].Meta.GameType = gameTypes[3];
            games[38].emulator();
            games[38].Meta.Year = 1991; 
            


            games[39].Meta.Name = "Sonic the Hedgehog 2";
            games[39].Meta.GameType = gameTypes[3];
            games[39].emulator();
            games[39].Meta.Year = 1992;
            


            games[40].Meta.Name = "Sonic the Hedgehog CD";
            games[40].Meta.GameType = gameTypes[3];
            games[40].emulator();
            games[40].Meta.Year = 1993;
            


            games[41].Meta.Name = "Sonic the Hedgehog 3";
            games[41].Meta.GameType = gameTypes[3];
            games[41].emulator();
            games[41].Meta.Year = 1994;
            


            games[42].Meta.Name = "Sonic && Knuckles";
            games[42].Meta.GameType = gameTypes[3];
            games[42].emulator();
            games[42].Meta.Year = 1994;


            games[43].Meta.Name = "Sonic the Hedgehog 3 && Knuckles";
            games[43].Meta.GameType = gameTypes[3];
            games[43].emulator();
            games[43].Meta.Year = 1994;
            


            games[44].Meta.Name = "Sonic Spinball";
            games[44].Meta.GameType = gameTypes[3];
            games[44].emulator();
            games[44].Meta.Year = 1993;


            games[45].Meta.Name = "Dr. Robotnik's Mean Bean Machine";
            games[45].Meta.GameType = gameTypes[3];
            games[45].emulator();
            games[45].Meta.Year = 1993;
            


            games[46].Meta.Name = "Knuckles' Chaotix";
            games[46].Meta.GameType = gameTypes[3];
            games[46].emulator();
            games[46].Meta.Year = 1995;


            games[47].Meta.Name = "Knuckles in Sonic 2";
            games[47].Meta.GameType = gameTypes[3];
            games[47].emulator();
            games[47].Meta.Year = 1994;
            


            games[48].Meta.Name = "Sonic 3D Blast";
            games[48].Meta.GameType = gameTypes[3];
            games[48].emulator();
            games[48].Meta.Year = 1996;


            games[49].Meta.Name = "Sonic Eraser";
            games[49].Meta.GameType = gameTypes[3];
            games[49].emulator();
            games[49].Meta.Year = 1991;


            games[50].Meta.Name = "Sonic Crackers";
            games[50].Meta.GameType = gameTypes[3];
            games[50].emulator();
            games[50].Meta.Year = 1994;



            //---Sega Master System---

            games[51].Meta.Name = "Sonic The Hedgehog (8-bit)";
            games[51].Meta.GameType = gameTypes[4];
            games[51].emulator();
            games[51].Meta.Year = 1991;


            games[52].Meta.Name = "Sonic The Hedgehog 2 (8-bit)";
            games[52].Meta.GameType = gameTypes[4];
            games[52].emulator();
            games[52].Meta.Year = 1992;


            games[53].Meta.Name = "Sonic Chaos";
            games[53].Meta.GameType = gameTypes[4];
            games[53].emulator();
            games[53].Meta.Year = 1993;


            games[54].Meta.Name = "Sonic Blast";
            games[54].Meta.GameType = gameTypes[4];
            games[54].emulator();
            games[54].Meta.Year = 1997;


            games[55].Meta.Name = "Sonic Spinball (8-bit)";
            games[55].Meta.GameType = gameTypes[4];
            games[55].emulator();
            games[55].Meta.Year = 1994;
            


            games[56].Meta.Name = "Dr. Robotnik's Mean Bean Machine (8-bit)";
            games[56].Meta.GameType = gameTypes[4];
            games[56].emulator();
            games[56].Meta.Year = 1994;


            games[57].Meta.Name = "Sonic Edusoft";
            games[57].Meta.GameType = gameTypes[4];
            games[57].emulator();
            games[57].Meta.Year = 1991;



            //---GAME GEAR---

            games[57].Meta.Name = "Sonic The Hedgehog (8-bit)";
            games[57].Meta.GameType = gameTypes[5];
            games[57].emulator();
            games[57].Meta.Year = 1991;


            games[58].Meta.Name = "Sonic The Hedgehog 2 (8-bit)";
            games[58].Meta.GameType = gameTypes[5];
            games[58].emulator();
            games[58].Meta.Year = 1992;


            games[59].Meta.Name = "Sonic Chaos";
            games[59].Meta.GameType = gameTypes[5];
            games[59].emulator();
            games[59].Meta.Year = 1993;
            


            games[60].Meta.Name = "Sonic Blast";
            games[60].Meta.GameType = gameTypes[5];
            games[60].emulator();
            games[60].Meta.Year = 1996;


            games[61].Meta.Name = "Sonic Spinball (8-bit)";
            games[61].Meta.GameType = gameTypes[5];
            games[61].emulator();
            games[61].Meta.Year = 1994;


            games[62].Meta.Name = "Dr. Robotnik's Mean Bean Machine (8-bit)";
            games[62].Meta.GameType = gameTypes[5];
            games[62].emulator();
            games[62].Meta.Year = 1993;


            games[63].Meta.Name = "Sonic Triple Trouble";
            games[63].Meta.GameType = gameTypes[5];
            games[63].emulator();
            games[63].Meta.Year = 1994;


            games[64].Meta.Name = "Sonic Labyrinth";
            games[64].Meta.GameType = gameTypes[5];
            games[64].emulator();
            games[64].Meta.Year = 1995;


            games[65].Meta.Name = "Sonic Drift";
            games[65].Meta.GameType = gameTypes[5];
            games[65].emulator();
            games[65].Meta.Year = 1994;


            games[66].Meta.Name = "Sonic Drift 2";
            games[66].Meta.GameType = gameTypes[5];
            games[66].emulator();
            games[66].Meta.Year = 1995;


            games[67].Meta.Name = "Tails' Adventure";
            games[67].Meta.GameType = gameTypes[5];
            games[67].emulator();
            games[67].Meta.Year = 1995;


            games[68].Meta.Name = "Tails' Skypatrol";
            games[68].Meta.GameType = gameTypes[5];
            games[68].emulator();
            games[68].Meta.Year = 1995;


            //---ARCADE---

            games[69].Meta.Name = "SegaSonic The Hedgehog";
            games[69].Meta.GameType = gameTypes[8];
            games[69].ExeLoc = "sonic";
            games[69].emulator();
            games[69].Meta.Year = 1993;

            games[70].Meta.Name = "Waku Waku Sonic Patrol Car";
            games[70].Meta.GameType = gameTypes[8];
            games[70].ExeLoc = "soniccar";
            games[70].emulator();
            games[70].Meta.Year = 1991;
            

            games[71].Meta.Name = "SegaSonic Popcorn Shop";
            games[71].Meta.GameType = gameTypes[8];
            games[71].ExeLoc = "sonicpop";
            games[71].emulator();
            games[71].Meta.Year = 1993;


            games[72].Meta.Name = "SegaSonic Cosmo Fighter";
            games[72].Meta.GameType = gameTypes[8];
            games[72].ExeLoc = "sonicfgt";
            games[72].emulator();
            games[72].Meta.Year = 1993;


            games[73].Meta.Name = "Sonic The Hedgehog (Mega Play)";
            games[73].Meta.GameType = gameTypes[8];
            games[73].ExeLoc = "megaplay mp_sonic";
            games[73].emulator();
            games[73].Meta.Year = 1991;



            games[74].Meta.Name = "Sonic The Hedgehog 2 (Mega Play)";
            games[74].Meta.GameType = gameTypes[8];
            games[74].ExeLoc = "mp_soni2";
            games[74].emulator();
            games[74].Meta.Year = 1993;



            games[75].Meta.Name = "Sonic the Fighters";
            games[75].Meta.GameType = gameTypes[9];
            games[75].emulator();
            games[76].Meta.Year = 1996;



            //---SATURN---

            games[76].Meta.Name = "Sonic 3D Blast";
            games[76].Meta.GameType = gameTypes[6];
            games[76].EmuArgs = "-a";
            games[76].emulator();
            games[76].Meta.Year = 1999;



            games[77].Meta.Name = "Sonic Jam";
            games[77].Meta.GameType = gameTypes[6];
            games[77].EmuArgs = "-a";
            games[77].emulator();
            games[77].Meta.Year = 1997;



            games[78].Meta.Name = "Sonic R";
            games[78].Meta.GameType = gameTypes[6];
            games[78].EmuArgs = "-a";
            games[78].emulator();
            games[78].Meta.Year = 1997;



            //---DREAMCAST---


            games[79].Meta.Name = "Sonic Adventure";
            games[79].Meta.GameType = gameTypes[7];
            games[79].emulator();
            games[79].Meta.Year = 1998;



            games[80].Meta.Name = "Sonic Adventure 2";
            games[80].Meta.GameType = gameTypes[7];
            games[80].emulator();
            games[80].Meta.Year = 2001;



            games[81].Meta.Name = "Sonic Shuffle";
            games[81].Meta.GameType = gameTypes[7];
            games[81].emulator();
            games[81].Meta.Year = 2000;



            //---GAMECUBE---


            games[82].Meta.Name = "Sonic Adventure DX";
            games[82].Meta.GameType = gameTypes[10];
            games[82].emulator();
            games[82].Meta.Year = 2003;


            games[83].Meta.Name = "Sonic Adventure 2 Battle";
            games[83].Meta.GameType = gameTypes[10];
            games[83].emulator();
            games[83].Meta.Year = 2001;



            games[84].Meta.Name = "Sonic Heroes";
            games[84].Meta.GameType = gameTypes[10];
            games[84].emulator();
            games[84].Meta.Year = 2003;



            games[85].Meta.Name = "Sonic Riders";
            games[85].Meta.GameType = gameTypes[10];
            games[85].emulator();
            games[85].Meta.Year = 2006;



            games[86].Meta.Name = "Sonic Mega Collection";
            games[86].Meta.GameType = gameTypes[10];
            games[86].emulator();
            games[86].Meta.Year = 2002;



            games[87].Meta.Name = "Sonic Gems Collection";
            games[87].Meta.GameType = gameTypes[10];
            games[87].emulator();
            games[87].Meta.Year = 2005;



            //---WII---


            games[88].Meta.Name = "Sonic and the Secret Rings";
            games[88].Meta.GameType = gameTypes[11];
            games[88].emulator();
            games[88].Meta.Year = 2007;


            games[89].Meta.Name = "Sonic and the Black Knight";
            games[89].Meta.GameType = gameTypes[11];
            games[89].emulator();
            games[89].Meta.Year = 2009;


            games[90].Meta.Name = "Sonic the Hedgehog 4 Episode 1";
            games[90].Meta.GameType = gameTypes[11];
            games[90].emulator();
            games[90].Meta.Year = 2010;



            games[91].Meta.Name = "Sonic Riders: Zero Gravity";
            games[91].Meta.GameType = gameTypes[11];
            games[91].emulator();
            games[91].Meta.Year = 2008;



            games[92].Meta.Name = "Sonic Unleashed";
            games[92].Meta.GameType = gameTypes[11];
            games[92].emulator();
            games[92].Meta.Year = 2008;



            games[93].Meta.Name = "Sonic Colors";
            games[93].Meta.GameType = gameTypes[11];
            games[93].emulator();
            games[93].Meta.Year = 2010;



            games[94].Meta.Name = "Sonic && Sega All Star Racing";
            games[94].Meta.GameType = gameTypes[11];
            games[94].emulator();
            games[94].Meta.Year = 2010;



            games[95].Meta.Name = "Sega Superstars Tennis";
            games[95].Meta.GameType = gameTypes[11];
            games[95].emulator();
            games[95].Meta.Year = 2008;



            games[96].Meta.Name = "Mario && Sonic at the Olympic Games";
            games[96].Meta.GameType = gameTypes[11];
            games[96].emulator();
            games[96].Meta.Year = 2007;



            games[97].Meta.Name = "Mario && Sonic at the Olympic Winter Games";
            games[97].Meta.GameType = gameTypes[11];
            games[97].emulator();
            games[97].Meta.Year = 2009;



            games[98].Meta.Name = "Mario && Sonic at the London 2012 Olympic Games";
            games[98].Meta.GameType = gameTypes[11];
            games[98].emulator();
            games[98].Meta.Year = 2011;



            games[99].Meta.Name = "Sonic the Hedgehog (VC)";
            games[99].Meta.GameType = gameTypes[11];
            games[99].emulator();
            games[99].Meta.Year = 2006;



            games[100].Meta.Name = "Sonic the Hedgehog (8-bit) (VC)";
            games[100].Meta.GameType = gameTypes[11];
            games[100].emulator();
            games[100].Meta.Year = 2008;



            games[101].Meta.Name = "Sonic the Hedgehog 2 (VC)";
            games[101].Meta.GameType = gameTypes[11];
            games[101].emulator();
            games[101].Meta.Year = 2007;



            games[102].Meta.Name = "Sonic the Hedgehog 2 (8-bit) (VC)";
            games[102].Meta.GameType = gameTypes[11];
            games[102].emulator();
            games[102].Meta.Year = 2008;



            games[103].Meta.Name = "Sonic the Hedgehog 3 (VC)";
            games[103].Meta.GameType = gameTypes[11];
            games[103].emulator();
            games[103].Meta.Year = 2007;



            games[104].Meta.Name = "Sonic & Knuckles (VC)";
            games[104].Meta.GameType = gameTypes[11];
            games[104].emulator();
            games[104].Meta.Year = 2009;



            games[105].Meta.Name = "Sonic Chaos (VC)";
            games[105].Meta.GameType = gameTypes[11];
            games[105].emulator();
            games[105].Meta.Year = 2009;



            games[106].Meta.Name = "Sonic 3D Blast (VC)";
            games[106].Meta.GameType = gameTypes[11];
            games[106].emulator();
            games[106].Meta.Year = 2007;



            games[107].Meta.Name = "Sonic Spinball (VC)";
            games[107].Meta.GameType = gameTypes[11];
            games[107].emulator();
            games[107].Meta.Year = 2007;



            games[108].Meta.Name = "Dr. Robotnik's Mean Bean Machine (VC)";
            games[108].Meta.GameType = gameTypes[11];
            games[108].emulator();
            games[108].Meta.Year = 2006;



            //---WII U---

            games[109].Meta.Name = "Sonic Lost World";
            games[109].Meta.GameType = gameTypes[12];
            games[109].emulator();
            games[109].Meta.Year = 2013;



            games[110].Meta.Name = "Sonic && All-Stars Racing Transformed";
            games[110].Meta.GameType = gameTypes[12];
            games[110].emulator();
            games[110].Meta.Year = 2012;



            games[111].Meta.Name = "Sonic Boom: Rise of Lyric";
            games[111].Meta.GameType = gameTypes[12];
            games[111].emulator();
            games[111].Meta.Year = 2014;



            games[112].Meta.Name = "Mario && Sonic at the Sochi 2014 Olympic Winter Games";
            games[112].Meta.GameType = gameTypes[12];
            games[112].emulator();
            games[112].Meta.Year = 2013;



            games[113].Meta.Name = "Mario && Sonic at the Rio 2016 Olympic Games";
            games[113].Meta.GameType = gameTypes[12];
            games[113].emulator();
            games[113].Meta.Year = 2016;



            games[114].Meta.Name = "Sonic Advance (VC)";
            games[114].Meta.GameType = gameTypes[12];
            games[114].emulator();
            games[114].Meta.Year = 2015;



            games[115].Meta.Name = "Sonic Advance 2 (VC)";
            games[115].Meta.GameType = gameTypes[12];
            games[115].emulator();
            games[115].Meta.Year = 2016;



            games[116].Meta.Name = "Sonic Advance 3 (VC)";
            games[116].Meta.GameType = gameTypes[12];
            games[116].emulator();
            games[116].Meta.Year = 2016;



            //---SWITCH---

            games[117].Meta.Name = "Sonic Mania";
            games[117].Meta.GameType = gameTypes[13];
            games[117].emulator();
            games[117].Meta.Year = 2017;



            games[118].Meta.Name = "Sonic Forces";
            games[118].Meta.GameType = gameTypes[13];
            games[118].emulator();
            games[118].Meta.Year = 2017;



            games[119].Meta.Name = "Sonic Colours: Ultimate";
            games[119].Meta.GameType = gameTypes[13];
            games[119].emulator();
            games[119].Meta.Year = 2021;



            games[120].Meta.Name = "Sonic Origins";
            games[120].Meta.GameType = gameTypes[13];
            games[120].emulator();
            games[120].Meta.Year = 2022;



            games[121].Meta.Name = "Sonic Frontiers";
            games[121].Meta.GameType = gameTypes[13];
            games[121].emulator();
            games[121].Meta.Year = 2022;



            games[122].Meta.Name = "Sonic Superstars";
            games[122].Meta.GameType = gameTypes[13];
            games[122].emulator();
            games[122].Meta.Year = 2023;



            games[123].Meta.Name = "Team Sonic Racing";
            games[123].Meta.GameType = gameTypes[13];
            games[123].emulator();
            games[123].Meta.Year = 2019;



            games[124].Meta.Name = "Mario && Sonic at the Olympic Games Tokyo 2020";
            games[124].Meta.GameType = gameTypes[13];
            games[124].emulator();
            games[124].Meta.Year = 2019;



            games[125].Meta.Name = "Sega Ages Sonic the Hedgehog";
            games[125].Meta.GameType = gameTypes[13];
            games[125].emulator();
            games[125].Meta.Year = 2018;



            games[126].Meta.Name = "Sega Ages Sonic the Hedgehog 2";
            games[126].Meta.GameType = gameTypes[13];
            games[126].emulator();
            games[126].Meta.Year = 2020;



            //---PS2---

            games[127].Meta.Name = "Sonic Heroes";
            games[127].Meta.GameType = gameTypes[14];
            games[127].emulator();
            games[127].Meta.Year = 2003;



            games[128].Meta.Name = "Shadow The Hedgehog";
            games[128].Meta.GameType = gameTypes[14];
            games[128].emulator();
            games[128].Meta.Year = 2005;



            games[129].Meta.Name = "Sonic Unleashed";
            games[129].Meta.GameType = gameTypes[14];
            games[129].emulator();
            games[129].Meta.Year = 2008;



            games[130].Meta.Name = "Sonic Riders";
            games[130].Meta.GameType = gameTypes[14];
            games[130].emulator();
            games[130].Meta.Year = 2006;



            games[131].Meta.Name = "Sonic Riders: Zero Gravity";
            games[131].Meta.GameType = gameTypes[14];
            games[131].emulator();
            games[131].Meta.Year = 2008;



            games[132].Meta.Name = "Sonic Mega Collection Plus";
            games[132].Meta.GameType = gameTypes[14];
            games[132].emulator();
            games[132].Meta.Year = 2004;



            games[133].Meta.Name = "Sonic Gems Collection";
            games[133].Meta.GameType = gameTypes[14];
            games[133].emulator();
            games[133].Meta.Year = 2005;



            games[134].Meta.Name = "Sega Superstars";
            games[134].Meta.GameType = gameTypes[14];
            games[134].emulator();
            games[134].Meta.Year = 2004;



            games[135].Meta.Name = "Sega Superstars Tennis";
            games[135].Meta.GameType = gameTypes[14];
            games[135].emulator();
            games[135].Meta.Year = 2008;



            games[136].Meta.Name = "Sega Genesis Collection";
            games[136].Meta.GameType = gameTypes[14];
            games[136].emulator();
            games[136].Meta.Year = 2006;



            //---PS3---
            games[137].Meta.Name = "Sonic the Hedgehog (2006)";
            games[137].ModLoaderName = ModLoaders[12].Name;
            games[137].ModLoaderLoc = ModLoaders[12].Location;
            games[137].Meta.GameType = gameTypes[15];
            games[137].emulator();
            games[137].modLoader();
            games[137].Meta.Year = 2006;



            games[138].Meta.Name = "Sonic Unleashed";
            games[138].ModLoaderName = ModLoaders[13].Name;
            games[138].ModLoaderLoc= ModLoaders[13].Location;
            games[138].Meta.GameType = gameTypes[15];
            games[138].emulator();
            games[138].modLoader();
            games[138].Meta.Year = 2008;



            games[139].Meta.Name = "Sonic Generations";
            games[139].Meta.GameType = gameTypes[15];
            games[139].emulator();
            games[139].Meta.Year = 2011;



            games[140].Meta.Name = "Sonic the Hedgehog 4 Episode I";
            games[140].Meta.GameType = gameTypes[15];
            games[140].emulator();
            games[140].Meta.Year = 2010;



            games[141].Meta.Name = "Sonic the Hedgehog 4 Episode II";
            games[141].Meta.GameType = gameTypes[15];
            games[141].emulator();
            games[141].Meta.Year = 2012;



            games[142].Meta.Name = "Sonic the Hedgehog (Sega Vintage Collection)";
            games[142].Meta.GameType = gameTypes[15];
            games[142].emulator();
            games[142].Meta.Year = 2007;



            games[143].Meta.Name = "Sonic the Hedgehog 2 (Sega Vintage Collection)";
            games[143].Meta.GameType = gameTypes[15];
            games[143].emulator();
            games[143].Meta.Year = 2007;



            games[144].Meta.Name = "Sonic the Hedgehog CD (2011)";
            games[144].Meta.GameType = gameTypes[15];
            games[144].emulator();
            games[144].Meta.Year = 2011;
            


            games[145].Meta.Name = "Sonic the Fighters";
            games[145].Meta.GameType = gameTypes[15];
            games[145].emulator();
            games[145].Meta.Year = 2012;



            games[146].Meta.Name = "Sonic Adventure DX";
            games[146].Meta.GameType = gameTypes[15];
            games[146].emulator();
            games[146].Meta.Year = 2010;



            games[147].Meta.Name = "Sonic Adventure 2: Battle";
            games[147].Meta.GameType = gameTypes[15];
            games[147].emulator();
            games[147].Meta.Year = 2012;



            games[148].Meta.Name = "Sonic && Sega All-Stars Racing";
            games[148].Meta.GameType = gameTypes[15];
            games[148].emulator();
            games[148].Meta.Year = 2010;



            games[149].Meta.Name = "Sonic && All-Stars Racing Transformed";
            games[149].Meta.GameType = gameTypes[15];
            games[149].emulator();
            games[149].Meta.Year = 2012;



            games[150].Meta.Name = "Sega Superstars Tennis";
            games[150].Meta.GameType = gameTypes[15];
            games[150].emulator();
            games[150].Meta.Year = 2008;



            //---XBOX---

            games[151].Meta.Name = "Sonic Heroes";
            games[151].Meta.GameType = gameTypes[16];
            games[151].emulator();
            games[151].Meta.Year = 2003;



            games[152].Meta.Name = "Shadow the Hedgehog";
            games[152].Meta.GameType = gameTypes[16];
            games[152].emulator();
            games[152].Meta.Year = 2005;



            games[153].Meta.Name = "Sonic Riders";
            games[153].Meta.GameType = gameTypes[16];
            games[153].emulator();
            games[153].Meta.Year = 2006;



            games[154].Meta.Name = "Sonic Mega Collection Plus";
            games[154].Meta.GameType = gameTypes[16];
            games[154].emulator();
            games[154].Meta.Year = 2004;



            //---XBOX 360---

            games[155].Meta.Name = "Sonic the Hedgehog (2006)";
            games[155].ModLoaderName = ModLoaders[12].Name;
            games[155].ModLoaderLoc = ModLoaders[12].Location;
            games[155].Meta.GameType = gameTypes[17];
            games[155].emulator();
            games[155].modLoader();
            games[155].Meta.Year = 2006;



            games[156].Meta.Name = "Sonic Unleashed";
            games[156].ModLoaderName = ModLoaders[13].Name;
            games[156].ModLoaderLoc = ModLoaders[13].Location;
            games[156].Meta.GameType = gameTypes[17];
            games[156].emulator();
            games[156].modLoader();
            games[156].Meta.Year = 2008;



            games[157].Meta.Name = "Sonic Generations";
            games[157].Meta.GameType = gameTypes[17];
            games[157].emulator();
            games[157].Meta.Year = 2011;



            games[158].Meta.Name = "Sonic the Hedgehog 4 Episode I";
            games[158].Meta.GameType = gameTypes[17];
            games[158].emulator();
            games[158].Meta.Year = 2010;



            games[159].Meta.Name = "Sonic the Hedgehog 4 Episode II";
            games[159].Meta.GameType = gameTypes[17];
            games[159].emulator();
            games[159].Meta.Year = 2012;



            games[160].Meta.Name = "Sonic Free Riders";
            games[160].Meta.GameType = gameTypes[17];
            games[160].emulator();
            games[160].Meta.Year = 2010;



            games[161].Meta.Name = "Sonic && Sega All-Stars Racing";
            games[161].Meta.GameType = gameTypes[17];
            games[161].emulator();
            games[161].Meta.Year = 2010;



            games[162].Meta.Name = "Sonic && All-Stars Racing Transformed";
            games[162].Meta.GameType = gameTypes[17];
            games[162].emulator();
            games[162].Meta.Year = 2012;



            games[163].Meta.Name = "Sega Superstars Tennis";
            games[163].Meta.GameType = gameTypes[17];
            games[163].emulator();
            games[163].Meta.Year = 2008;



            games[164].Meta.Name = "Sonic the Hedgehog (XBLA)";
            games[164].Meta.GameType = gameTypes[17];
            games[164].emulator();
            games[164].Meta.Year = 2007;



            games[165].Meta.Name = "Sonic the Hedgehog 2 (XBLA)";
            games[165].Meta.GameType = gameTypes[17];
            games[165].emulator();
            games[165].Meta.Year = 2007;



            games[166].Meta.Name = "Sonic the Hedgehog CD (2011)";
            games[166].Meta.GameType = gameTypes[17];
            games[166].emulator();
            games[166].Meta.Year = 2011;
            


            games[167].Meta.Name = "Sonic the Hedgehog 3 (XBLA)";
            games[167].Meta.GameType = gameTypes[17];
            games[167].emulator();
            games[167].Meta.Year = 2009;



            games[168].Meta.Name = "Sonic && Knuckles (XBLA)";
            games[168].Meta.GameType = gameTypes[17];
            games[168].emulator();
            games[168].Meta.Year = 2009;



            games[169].Meta.Name = "Sonic the Fighters";
            games[169].Meta.GameType = gameTypes[17];
            games[169].emulator();
            games[169].Meta.Year = 2012;



            games[170].Meta.Name = "Sonic Adventure";
            games[170].Meta.GameType = gameTypes[17];
            games[170].emulator();
            games[170].Meta.Year = 2010;



            games[171].Meta.Name = "Sonic Adventure 2";
            games[171].Meta.GameType = gameTypes[17];
            games[171].emulator();
            games[171].Meta.Year = 2007;



            //---NEO GEO POCKET---

            games[172].Meta.Name = "Sonic the Hedgehog Pocket Adventure";
            games[172].Meta.GameType = gameTypes[18];
            games[172].emulator();
            games[172].Meta.Year = 1999;




            //---GBA---

            games[173].Meta.Name = "Sonic Advance";
            games[173].Meta.GameType = gameTypes[19];
            games[173].emulator();
            games[173].Meta.Year = 2001;



            games[174].Meta.Name = "Sonic Advance 2";
            games[174].Meta.GameType = gameTypes[19];
            games[174].emulator();
            games[174].Meta.Year = 2002;



            games[175].Meta.Name = "Sonic Battle";
            games[175].Meta.GameType = gameTypes[19];
            games[175].emulator();
            games[175].Meta.Year = 2003;



            games[176].Meta.Name = "Sonic Advance 3";
            games[176].Meta.GameType = gameTypes[19];
            games[176].emulator();
            games[176].Meta.Year = 2004;



            games[177].Meta.Name = "Sonic Pinball Party";
            games[177].Meta.GameType = gameTypes[19];
            games[177].emulator();
            games[177].Meta.Year = 2003;



            games[178].Meta.Name = "Tiny Chao Garden";
            games[178].Meta.GameType = gameTypes[19];
            games[178].emulator();
            games[178].Meta.Year = 2001;



            games[179].Meta.Name = "Sonic X: A Super Sonic Hero";
            games[179].Meta.GameType = gameTypes[19];
            games[179].emulator();
            games[179].Meta.Year = 2004;



            games[180].Meta.Name = "Sonic the Hedgehog Genesis";
            games[180].Meta.GameType = gameTypes[19];
            games[180].emulator();
            games[180].Meta.Year = 2006;



            //---DS---

            games[181].Meta.Name = "Sonic Rush";
            games[181].Meta.GameType = gameTypes[20];
            games[181].emulator();
            games[181].Meta.Year = 2005;



            games[182].Meta.Name = "Sonic Rush Adventure";
            games[182].Meta.GameType = gameTypes[20];
            games[182].emulator();
            games[182].Meta.Year = 2007;



            games[183].Meta.Name = "Sonic Colors";
            games[183].Meta.GameType = gameTypes[20];
            games[183].emulator();
            games[183].Meta.Year = 2010;



            games[184].Meta.Name = "Sonic Chronicles: The Dark Brotherhood";
            games[184].Meta.GameType = gameTypes[20];
            games[184].emulator();
            games[184].Meta.Year = 2008;



            games[185].Meta.Name = "Sega Superstars Tennis";
            games[185].Meta.GameType = gameTypes[20];
            games[185].emulator();
            games[185].Meta.Year = 2008;



            games[186].Meta.Name = "Sonic && Sega All-Stars Racing";
            games[186].Meta.GameType = gameTypes[20];
            games[186].emulator();
            games[186].Meta.Year = 2010;



            games[187].Meta.Name = "Mario && Sonic at the Olympic Games";
            games[187].Meta.GameType = gameTypes[20];
            games[187].emulator();
            games[187].Meta.Year = 2008;



            games[188].Meta.Name = "Mario && Sonic at the Olympic Winter Games";
            games[188].Meta.GameType = gameTypes[20];
            games[188].emulator();
            games[188].Meta.Year = 2009;



            games[189].Meta.Name = "Sonic Classic Collection";
            games[189].Meta.GameType = gameTypes[20];
            games[189].emulator();
            games[189].Meta.Year = 2010;



            //---3DS---

            games[190].Meta.Name = "Sonic Generations";
            games[190].Meta.GameType = gameTypes[21];
            games[190].emulator();
            games[190].Meta.Year = 2011;



            games[191].Meta.Name = "Sonic Lost World";
            games[191].Meta.GameType = gameTypes[21];
            games[191].emulator();
            games[191].Meta.Year = 2013;



            games[192].Meta.Name = "Sonic Boom: Shattered Crystal";
            games[192].Meta.GameType = gameTypes[21];
            games[192].emulator();
            games[192].Meta.Year = 2014;



            games[193].Meta.Name = "Sonic Boom: Fire and Ice";
            games[193].Meta.GameType = gameTypes[21];
            games[193].emulator();
            games[193].Meta.Year = 2016;



            games[194].Meta.Name = "Sonic && All-Stars Racing Transformed";
            games[194].Meta.GameType = gameTypes[21];
            games[194].emulator();
            games[195].Meta.Year = 2012;



            games[195].Meta.Name = "Mario && Sonic at the London 2012 Olympic Games";
            games[195].Meta.GameType = gameTypes[21];
            games[195].emulator();
            games[195].Meta.Year = 2012;



            games[196].Meta.Name = "Mario && Sonic - London 2012 Virtual Card Album";
            games[196].Meta.GameType = gameTypes[21];
            games[196].emulator();
            games[196].Meta.Year = 2012;



            games[197].Meta.Name = "Mario & Sonic at the Rio 2016 Olympic Games";
            games[197].Meta.GameType = gameTypes[21];
            games[197].emulator();
            games[197].Meta.Year = 2016;



            games[198].Meta.Name = "3D Sonic the Hedgehog";
            games[198].Meta.GameType = gameTypes[21];
            games[198].emulator();
            games[198].Meta.Year = 2013;



            games[199].Meta.Name = "3D Sonic the Hedgehog 2";
            games[199].Meta.GameType = gameTypes[21];
            games[199].emulator();
            games[199].Meta.Year = 2015;



            games[200].Meta.Name = "Sonic the Hedgehog (8-bit) (VC)";
            games[200].Meta.GameType = gameTypes[21];
            games[200].emulator();
            games[200].Meta.Year = 2013;



            games[201].Meta.Name = "Sonic the Hedgehog 2 (8-bit) (VC)";
            games[201].Meta.GameType = gameTypes[21];
            games[201].emulator();
            games[201].Meta.Year = 2012;



            games[202].Meta.Name = "Sonic the Hedgehog Triple Trouble (VC)";
            games[202].Meta.GameType = gameTypes[21];
            games[202].emulator();
            games[202].Meta.Year = 2012;



            games[203].Meta.Name = "Sonic Blast (VC)";
            games[203].Meta.GameType = gameTypes[21];
            games[203].emulator();
            games[203].Meta.Year = 2012;



            games[204].Meta.Name = "Sonic Labyrinth (VC)";
            games[204].Meta.GameType = gameTypes[21];
            games[204].emulator();
            games[204].Meta.Year = 2012;



            games[205].Meta.Name = "Sonic Drift 2 (VC)";
            games[205].Meta.GameType = gameTypes[21];
            games[205].emulator();
            games[205].Meta.Year = 2012;



            games[206].Meta.Name = "Dr. Robotnik's Mean Bean Machine (8-bit) (VC)";
            games[206].Meta.GameType = gameTypes[21];
            games[206].emulator();
            games[206].Meta.Year = 2013;



            games[207].Meta.Name = "Tails' Adventures (VC)";
            games[207].Meta.GameType = gameTypes[21];
            games[207].emulator();
            games[207].Meta.Year = 2013;



            //---PSP---

            games[208].Meta.Name = "Sonic Rivals";
            games[208].Meta.GameType = gameTypes[22];
            games[208].emulator();
            games[208].Meta.Year = 2006;



            games[209].Meta.Name = "Sonic Rivals 2";
            games[209].Meta.GameType = gameTypes[22];
            games[209].emulator();
            games[209].Meta.Year = 2007;



            games[210].Meta.Name = "Sega Genesis Collection";
            games[210].Meta.GameType = gameTypes[22];
            games[210].emulator();
            games[210].Meta.Year = 2006;



            //Stuff I missed

            games[211].Meta.Name = "Shadow the Hedgehog"; //gamecube
            games[211].ModLoaderName = ModLoaders[10].Name;
            games[211].ModLoaderLoc = ModLoaders[10].Location;
            games[211].Meta.GameType = gameTypes[10];
            games[211].emulator();
            games[211].Meta.Year = 2005;


            games[212].Meta.Name = "Blue Spheres"; //mega drive  
            games[212].Meta.GameType = gameTypes[3];
            games[212].emulator();
            games[212].Meta.Year = 1994;

            games[213].Meta.Name = "Flicky"; //mega drive
            games[213].Meta.GameType = gameTypes[3];
            games[213].emulator();
            games[213].Meta.Year = 1994;

            games[214].Meta.Name = "Flicky"; //Arcade
            games[214].Meta.GameType = gameTypes[8];
            games[214].ExeLoc = "flicky";
            games[214].emulator();
            games[214].Meta.Year = 1984;

            games[215].Meta.Name = "Wacky Worlds Creativity Studio"; //Mega Drive
            games[215].Meta.GameType = gameTypes[3];
            games[215].emulator();
            games[215].Meta.Year = 1994;

            games[216].Meta.Name = "Sonic Compilation"; //mega drive
            games[216].Meta.GameType = gameTypes[3];
            games[216].emulator();
            games[216].Meta.Year = 1995;

            games[217].Meta.Name = "Mega 6 Volume 3"; //mega drive
            games[217].Meta.GameType = gameTypes[3];
            games[217].emulator();
            games[217].Meta.Year = 1995;

            games[218].Meta.Name = "6-Pak"; //mega drive
            games[218].Meta.GameType = gameTypes[3];
            games[218].emulator();
            games[218].Meta.Year = 1995;

            games[219].Meta.Name = "Sonic 2 in 1"; //game gear
            games[219].Meta.GameType = gameTypes[5];
            games[219].emulator();
            games[219].Meta.Year = 1995;

            games[220].Meta.Name = "Sega Smash Pack Volume 1"; //dreamcast
            games[220].Meta.GameType = gameTypes[7];
            games[220].emulator();
            games[220].Meta.Year = 2001;

            games[221].Meta.Name = "Sega Smash Pack "; //gba
            games[221].Meta.GameType = gameTypes[19];
            games[221].emulator();
            games[221].Meta.Year = 2002;

            games[222].Meta.Name = "Sega 3D Classics Collection"; //3ds
            games[222].Meta.GameType = gameTypes[21];
            games[222].emulator();
            games[222].Meta.Year = 2015;

            games[223].Meta.Name = "Sega 3D Fukkoku Archives 3: Final Stage"; //3ds
            games[223].Meta.GameType = gameTypes[21];
            games[223].emulator();
            games[223].Meta.Year = 2016;

            games[224].Meta.Name = "Sonic's Ultimate Genesis Collection"; //ps3
            games[224].Meta.GameType = gameTypes[15];
            games[224].emulator();
            games[224].Meta.Year = 2009;

            games[225].Meta.Name = "Sonic's Ultimate Genesis Collection"; //xbox 360
            games[225].Meta.GameType = gameTypes[17];
            games[225].emulator();
            games[225].Meta.Year = 2009;

            games[226].Meta.Name = "Sonic Heroes"; //ps3
            games[226].Meta.GameType = gameTypes[15];
            games[226].emulator();
            games[226].Meta.Year = 2012;

            games[227].Meta.Name = "Shadow the Hedgehog"; //ps3
            games[227].Meta.GameType = gameTypes[15];
            games[227].emulator();
            games[227].Meta.Year = 2013;

            games[228].Meta.Name = "Dreamcast Collection"; //xbox 360
            games[228].Meta.GameType = gameTypes[17];
            games[228].emulator();
            games[228].Meta.Year = 2011;

            games[229].Meta.Name = "Sega Mega Drive Classics"; //nintendo switch
            games[229].Meta.GameType = gameTypes[13];
            games[229].emulator();
            games[229].Meta.Year = 2018;

            games[230].Meta.Name = "Sonic the Hedgehog 2"; //nintendo switch
            games[230].Meta.GameType = gameTypes[13];
            games[230].emulator();
            games[230].Meta.Year = 2021;

            games[231].Meta.Name = "Sonic Spinball"; //nintendo switch
            games[231].Meta.GameType = gameTypes[13];
            games[231].emulator();
            games[231].Meta.Year = 2022;

            games[232].Meta.Name = "Dr. Robotnik's Mean Bean Machine"; //nintendo switch
            games[232].Meta.GameType = gameTypes[13];
            games[232].emulator();
            games[232].Meta.Year = 2021;

            games[233].Meta.Name = "Flicky"; //nintendo switch
            games[233].Meta.GameType = gameTypes[13];
            games[233].emulator();
            games[233].Meta.Year = 2023;





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
                games[i].Meta.resetEmu();
            }

            addEmus();
        }

        public ProgramInfo getEmulFromGame(string name, string type)
        {
            ProgramInfo info = null;

            for (int i = 0; i < games.Length; i++)
            {
                if (games[i].Meta.Name == name && games[i].Meta.GameType == type)
                {
                    for (int j = 0; j < emulators.Length; j++)
                    {
                        if (emulators[j].Name == games[i].Meta.Emus[games[i].Meta.SelectedIndex].Name)
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
                if (games[i].Meta.Emus[games[i].Meta.SelectedIndex].Name == emulName)
                    games[i].EmuArgs = args;
            }
        }

        public void addEmus()
        {
            for (int i = 0; i <games.Length ; i++) 
            {

                switch(games[i].Meta.GameType)
                {
                    case "Sega Mega Drive":

                        games[i].meta.addEmu(emulators[1]);     // Genesis Plus GX
                        games[i].meta.addEmu(emulators[0]);     // Kega Fusion
                        games[i].meta.addEmu(emulators[2]);     // PicoDrive
                        games[i].meta.addEmu(emulators[3]);     // Ares
                        games[i].meta.addEmu(emulators[10]);    // MAME
                        games[i].meta.addEmu(emulators[6]);     // Mednafen
                        break;

                    case "Sega Master System":
                        games[i].meta.addEmu(emulators[1]);     // Genesis Plus GX
                        games[i].meta.addEmu(emulators[0]);     // Kega Fusion
                        games[i].meta.addEmu(emulators[10]);    // MAME
                        games[i].meta.addEmu(emulators[3]);     // Ares
                        games[i].meta.addEmu(emulators[2]);     // PicoDrive
                        games[i].meta.addEmu(emulators[4]);     // Emulicious

                        break;

                    case "Sega Game Gear":
                        games[i].meta.addEmu(emulators[1]);     // Genesis Plus GX
                        games[i].meta.addEmu(emulators[0]);     // Kega Fusion
                        games[i].meta.addEmu(emulators[10]);    // MAME
                        games[i].meta.addEmu(emulators[3]);     // Ares
                        games[i].meta.addEmu(emulators[2]);     // PicoDrive
                        games[i].meta.addEmu(emulators[6]);     // Mednafen
                        games[i].meta.addEmu(emulators[4]);     // Emulicious


                        break;

                    case "Sega Saturn":
                        games[i].meta.addEmu(emulators[5]);     // Yabause
                        games[i].meta.addEmu(emulators[6]);     // Mednafen
                        games[i].meta.addEmu(emulators[7]);     // Kronos
                        break;

                    case "Sega Dreamcast":
                        games[i].meta.addEmu(emulators[8]);     // Flycast
                        games[i].meta.addEmu(emulators[9]);     // Redream
                        break;

                    case "Arcade (MAME)":
                        games[i].meta.addEmu(emulators[10]);    // MAME
                        break;

                    case "Arcade (Sega AM2)":
                        games[i].meta.addEmu(emulators[11]);    // Model 2 Emulator
                        break;

                    case "Nintendo GameCube":
                    case "Nintendo Wii":
                        games[i].meta.addEmu(emulators[12]);    // Dolphin
                        break;

                    case "Nintendo Wii U":
                        games[i].meta.addEmu(emulators[13]);    // Cemu
                        break;

                    case "Nintendo Switch":
                        games[i].meta.addEmu(emulators[14]);    // Yuzu
                        games[i].meta.addEmu(emulators[15]);    // Ryujinx
                        break;

                    case "Sony PlayStation 2":
                        games[i].meta.addEmu(emulators[16]);    // PCSX2
                        break;

                    case "Sony Playstation 3":
                        games[i].meta.addEmu(emulators[17]);    // RPCS3
                        break;

                    case "Microsoft XBox":
                        games[i].meta.addEmu(emulators[18]);    // Xemu
                        break;

                    case "Microsoft XBox 360":
                        games[i].meta.addEmu(emulators[19]);    // Xenia
                        break;

                    case "Neo Geo Pocket Color":
                        games[i].meta.addEmu(emulators[3]);     // Ares
                        games[i].meta.addEmu(emulators[6]);     // Mednafen
                        games[i].meta.addEmu(emulators[10]);    // MAME
                        break;

                    case "Game Boy Advance":
                        games[i].meta.addEmu(emulators[20]);     // mGBA
                        games[i].meta.addEmu(emulators[21]);     // Visual Boy Advance
                        games[i].meta.addEmu(emulators[3]);      // Ares
                        break;

                    case "Nintendo DS":
                        games[i].meta.addEmu(emulators[22]);     // DeSmuME
                        games[i].meta.addEmu(emulators[23]);     // MelonDS
                        break;

                    case "Nintendo 3DS":
                        games[i].meta.addEmu(emulators[24]);     // Citra
                        break;

                    case "PlayStation Portable":
                        games[i].meta.addEmu(emulators[25]);     // PPSSPP
                        break;

                    case "Sega PC Reloaded":
                        games[i].meta.addEmu(emulators[26]);     // Sega PC Reloaded
                        break;


                }
            }
        }

        internal void updateModLoaders()
        {
            for (int i = 0; i < games.Length; i++)
            {
                if (games[i].HasModLoader)
                {
                    for (int j = 0; j < ModLoaders.Length; j++)
                    {
                        if (ModLoaders[j].Name == games[i].modLoaderName)
                        {
                            games[i].modLoaderLoc = ModLoaders[j].Location; 
                            continue;
                        }
                    }

                }
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
                        if (launcher.GameTypes[j] == launcher.Games[i].Meta.GameType)
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
            //Mega Drive
            emus[0].Name = "Kega Fusion";

            emus[1].Name = "Genesis Plus GX";

            emus[2].Name = "PicoDrive";

            emus[3].Name = "ares";

            //Master System / Game Gear
            emus[4].Name = "Emulicious";

            //Saturn
            emus[5].Name = "Yabause";
            emus[5].SpecFlag = true;
            emus[5].SpecArgs = "-i ";

            emus[6].Name = "Mednafen";
            emus[7].Name = "Kronos";

            //Dreamcast
            emus[8].Name = "Flycast";
            emus[9].Name = "Redream";

            //Arcade
            emus[10].Name = "MAME";
            emus[11].Name = "Model 2 Emulator";

            //Gamecube / Wii / Wii U
            emus[12].Name = "Dolphin";

            emus[13].Name = "Cemu";
            emus[13].SpecFlag = true;
            emus[13].SpecArgs = "-f -g ";

            //Switch
            emus[14].Name = "Yuzu";
            emus[15].Name = "Ryujinx";

            //PS2
            emus[16].Name = "PCSX2";

            //PS3
            emus[17].Name = "RPCS3";

            //XBox
            emus[18].Name = "Xemu";

            //XBox 360
            emus[19].Name = "Xenia";

            //Game Boy Advance
            emus[20].Name = "mGBA";
            emus[21].Name = "Visual Boy Advance";

            //DS
            emus[22].Name = "DeSmuMe";
            emus[23].Name = "melonDS";

            //3DS
            emus[24].Name = "Citra";

            //PSP
            emus[25].Name = "PPSSPP";

            emus[26].Name = "Sega PC Reloaded";

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
