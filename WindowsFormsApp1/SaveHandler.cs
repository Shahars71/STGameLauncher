using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public class SaveHandler
    {
        public static void Save()
        {

            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.NewLineOnAttributes = true;
            settings.OmitXmlDeclaration = true;

            using (XmlWriter xmlwrite = XmlWriter.Create(filename, settings))
            {


                xmlwrite.WriteStartDocument();
                xmlwrite.WriteComment("save data");

                xmlwrite.WriteStartElement("root");

                xmlwrite.WriteStartElement("GameSettings");

                for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
                {
                    Game g = LaunchContainer.launcher.Games[i];

                    if (g.GameName != "")
                    {
                        xmlwrite.WriteStartElement("Game");

                        xmlwrite.WriteElementString("Name", g.GameName);
                        xmlwrite.WriteElementString("Platform", g.GameType);
                        xmlwrite.WriteElementString("Path", g.ExeLoc.ToString());
                        xmlwrite.WriteElementString("IsActive", g.isActive.ToString());
                        xmlwrite.WriteElementString("Arguments", g.EmuArgs.ToString());

                        xmlwrite.WriteEndElement();
                    }
                }

                xmlwrite.WriteEndElement();

                xmlwrite.WriteStartElement("ProgramSettings");

                for (int i = 0; i < LaunchContainer.launcher.ModLoaders.Length; i++)
                {
                    ProgramInfo prog = LaunchContainer.launcher.ModLoaders[i];


                    if (prog.Name != "")
                    {
                        xmlwrite.WriteStartElement("ModLoader");

                        xmlwrite.WriteElementString("Name", prog.Name);
                        xmlwrite.WriteElementString("Path", prog.Location);
                        xmlwrite.WriteEndElement();
                    }
                }

                for (int i = 0; i < LaunchContainer.launcher.Emulators.Length; i++)
                {
                    ProgramInfo prog = LaunchContainer.launcher.Emulators[i];


                    if (prog.Name != "")
                    {
                        xmlwrite.WriteStartElement("Emulator");

                        xmlwrite.WriteElementString("Name", prog.Name);
                        xmlwrite.WriteElementString("Path", prog.Location);
                        xmlwrite.WriteEndElement();
                    }
                }

                xmlwrite.WriteStartElement("DRM");
                xmlwrite.WriteElementString("Name", "Steam");
                xmlwrite.WriteElementString("Path", LaunchContainer.launcher.SteamLoc);
                xmlwrite.WriteEndElement();

                xmlwrite.WriteEndElement();

                xmlwrite.WriteEndElement();


                xmlwrite.WriteEndDocument();
                xmlwrite.Flush();
                xmlwrite.Close();
            }


            

            Console.WriteLine("XML Saved");
        }

        public static void Load()
        {

            string[] charactersToReplace = new string[] { "\t", "\n", "\r", " " };

            try
            {
                using (XmlReader read = XmlReader.Create("config.xml"))
                {

                    while (read.Read())
                    {
                        switch (read.Name)
                        {
                            case "Game":
                                {
                                    if (read.NodeType == XmlNodeType.EndElement) { break; }

                                    read.ReadToFollowing("Name");
                                    read.Read();
                                    string na4 = read.Value;

                                    read.ReadToFollowing("Platform");
                                    read.Read();
                                    string plat4 = read.Value;

                                    read.ReadToFollowing("Path");
                                    read.Read();

                                    string pat4;

                                    if (read.Value[0] != ' ' && read.Value[0] != '\n')
                                    {
                                        pat4 = read.Value;
                                    }
                                    else
                                    {
                                        string text = read.Value;
                                        foreach (string s in charactersToReplace)
                                        {
                                            
                                            text = text.Replace(s, "");
                                        }

                                        pat4 = text;
                                    }
                                    

                                    read.ReadToFollowing("IsActive");
                                    read.Read();
                                    string isa4 = read.Value;

                                    read.ReadToFollowing("Arguments");
                                    read.Read();


                                    string argu4;

                                    if (read.Value[0] != ' ' && read.Value[0] != '\n')
                                    {
                                        argu4 = read.Value;
                                    }
                                    else
                                    {
                                        string text = read.Value;
                                        foreach (string s in charactersToReplace)
                                        {

                                            text = text.Replace(s, "");
                                        }

                                        argu4 = text;
                                    }

                                    saveGameInfo(na4, plat4, pat4, isa4, argu4);
                                }
                                break;
                            
                            case "ModLoader":

                                string typ = read.Name;

                                if (read.NodeType == XmlNodeType.EndElement)
                                    break;

                                read.ReadToFollowing("Name");
                                read.Read();
                                string na = read.Value;

                                read.ReadToFollowing("Path");
                                read.Read();
                                string pat = read.Value;

                                saveProgInfo(na, typ, pat);
                                break;

                            case "Emulator":
                                string typ1 = read.Name;

                                if (read.NodeType == XmlNodeType.EndElement)
                                    break;

                                read.ReadToFollowing("Name");
                                read.Read();
                                string na1 = read.Value;

                                read.ReadToFollowing("Path");
                                read.Read();
                                string pat1 = read.Value;

                                saveProgInfo(na1, typ1, pat1);

                                LaunchContainer.launcher.updateEmuls();

                                break;

                            case "DRM":
                                string typ2 = read.Name;

                                if (read.NodeType == XmlNodeType.EndElement)
                                    break;

                                read.ReadToFollowing("Name");
                                read.Read();
                                string na2 = read.Value;

                                read.ReadToFollowing("Path");
                                read.Read();
                                string pat2 = read.Value;

                                saveProgInfo(na2, typ2, pat2);
                                break;
                        }
                    }


                    read.Close();
                }
                //LaunchContainer.launcher.manageGames();
            }
            catch
            {
                String ftMess = "This is your first time starting this app.\nPlease perform the first time setup.";
                String ftTit = "First Time Setup";
                MessageBoxButtons butts = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(ftMess, ftTit, butts);
                if (result == DialogResult.OK)
                {
                    using (Form4 options = new Form4())
                    {
                        options.ShowDialog();
                    }
                }
                
                Save();
            }
        }

        public static void saveGameInfo(string name, string type, string loc, string act, string args)
        {
            Game[] gms = LaunchContainer.launcher.Games;
            switch (type)
            {
                case "Steam":
                    switch (name)
                    {
                        case "Sonic && Sega All Star Racing":
                            if (act == "True")
                                gms[0].isActive = true;
                            gms[0].EmuArgs = args;
                            break;

                        case "Sega Mega Drive && Genesis Classics":
                            if (act == "True")
                                gms[1].isActive = true;
                            gms[1].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog CD":
                            if (act == "True")
                                gms[2].isActive = true;
                            gms[2].EmuArgs = args;
                            break;

                        case "Sonic Adventure DX":
                            if (act == "True")
                                gms[3].isActive = true;
                            gms[3].EmuArgs = args;
                            break;

                        case "Sonic Adventure 2 Battle":
                            if (act == "True")
                                gms[4].isActive = true;
                            gms[4].EmuArgs = args;
                            break;

                        case "Sonic Generations":
                            if (act == "True")
                                gms[5].isActive = true;
                            gms[5].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode 1":
                            if (act == "True")
                                gms[6].isActive = true;
                            gms[6].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode 2":
                            if (act == "True")
                                gms[7].isActive = true;
                            gms[7].EmuArgs = args;
                            break;

                        case "Sonic && All Stars Racing Transformed":
                            if (act == "True")
                                gms[8].isActive = true;
                            gms[8].EmuArgs = args;
                            break;

                        case "Sonic Lost World":
                            if (act == "True")
                                gms[9].isActive = true;
                            gms[9].EmuArgs = args;
                            break;

                        case "Sonic Mania":
                            if (act == "True")
                                gms[10].isActive = true;
                            gms[10].EmuArgs = args;
                            break;

                        case "Sonic Forces":
                            if (act == "True")
                                gms[11].isActive = true;
                            gms[11].EmuArgs = args;
                            break;

                        case "Team Sonic Racing":
                            if (act == "True")
                                gms[12].isActive = true;
                            gms[12].EmuArgs = args;
                            break;

                        case "Sonic Colors: Ultimate":
                            if (act == "True")
                                gms[13].isActive = true;
                            gms[13].EmuArgs = args;
                            break;

                        case "Sonic Origins":
                            if (act == "True")
                                gms[14].isActive = true;
                            gms[14].EmuArgs = args;
                            break;

                        case "Sonic Frontiers":
                            if (act == "True")
                                gms[15].isActive = true;
                            gms[15].EmuArgs = args;
                            break;

                        case "The Murder of Sonic The Hedgehog":
                            if (act == "True")
                                gms[16].isActive = true;
                            gms[16].EmuArgs = args;
                            break;

                        case "Sonic Superstars":
                            if (act == "True")
                                gms[17].isActive = true;
                            gms[17].EmuArgs = args;
                            break;
                    }
                    break;

                case "Sega Mega Drive":
                    switch (name)
                    {
                        case "Sonic the Hedgehog":
                            gms[38].ExeLoc = loc;

                            if (act == "True")
                                gms[38].isActive = true;

                            gms[38].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2":
                            gms[39].ExeLoc = loc;

                            if (act == "True")
                                gms[39].isActive = true;

                            gms[39].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog CD":
                            gms[40].ExeLoc = loc;

                            if (act == "True")
                                gms[40].isActive = true;

                            gms[40].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 3":
                            gms[41].ExeLoc = loc;

                            if (act == "True")
                                gms[41].isActive = true;

                            gms[41].EmuArgs = args;
                            break;

                        case "Sonic && Knuckles":
                            gms[42].ExeLoc = loc;

                            if (act == "True")
                                gms[42].isActive = true;

                            gms[42].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 3 && Knuckles":
                            gms[43].ExeLoc = loc;

                            if (act == "True")
                                gms[43].isActive = true;

                            gms[43].EmuArgs = args;
                            break;

                        case "Sonic Spinball":
                            gms[44].ExeLoc = loc;

                            if (act == "True")
                                gms[44].isActive = true;

                            gms[44].EmuArgs = args;
                            break;

                        case "Dr. Robotnik's Mean Bean Machine":
                            gms[45].ExeLoc = loc;

                            if (act == "True")
                                gms[45].isActive = true;

                            gms[45].EmuArgs = args;
                            break;

                        case "Knuckles' Chaotix":
                            gms[46].ExeLoc = loc;

                            if (act == "True")
                                gms[46].isActive = true;

                            gms[46].EmuArgs = args;
                            break;

                        case "Knuckles in Sonic 2":
                            gms[47].ExeLoc = loc;

                            if (act == "True")
                                gms[47].isActive = true;

                            gms[47].EmuArgs = args;
                            break;

                        case "Sonic 3D Blast":
                            gms[48].ExeLoc = loc;

                            if (act == "True")
                                gms[48].isActive = true;

                            gms[48].EmuArgs = args;
                            break;

                        case "Sonic Eraser":
                            gms[49].ExeLoc = loc;

                            if (act == "True")
                                gms[49].isActive = true;

                            gms[49].EmuArgs = args;
                            break;

                        case "Sonic Crackers":
                            gms[50].ExeLoc = loc;

                            if (act == "True")
                                gms[50].isActive = true;

                            gms[50].EmuArgs = args;
                            break;

                        case "Blue Spheres":
                            gms[212].ExeLoc = loc;

                            if (act == "True")
                                gms[212].isActive = true;

                            gms[212].EmuArgs = args;
                            break;
                    }
                    break;

                case "Sega Master System":
                    switch (name)
                    {
                        case "Sonic The Hedgehog (8-bit)":
                            gms[51].ExeLoc = loc;

                            if (act == "True")
                                gms[51].isActive = true;

                            gms[51].EmuArgs = args;
                            break;

                        case "Sonic The Hedgehog 2 (8-bit)":
                            gms[52].ExeLoc = loc;

                            if (act == "True")
                                gms[52].isActive = true;

                            gms[52].EmuArgs = args;
                            break;

                        case "Sonic Chaos":
                            gms[53].ExeLoc = loc;

                            if (act == "True")
                                gms[53].isActive = true;

                            gms[53].EmuArgs = args;
                            break;

                        case "Sonic Blast":
                            gms[54].ExeLoc = loc;

                            if (act == "True")
                                gms[54].isActive = true;

                            gms[54].EmuArgs = args;
                            break;

                        case "Sonic Spinball (8-bit)":
                            gms[55].ExeLoc = loc;

                            if (act == "True")
                                gms[55].isActive = true;

                            gms[55].EmuArgs = args;
                            break;

                        case "Dr. Robotnik's Mean Bean Machine (8-bit)":
                            gms[56].ExeLoc = loc;

                            if (act == "True")
                                gms[56].isActive = true;

                            gms[56].EmuArgs = args;
                            break;
                    }
                    break;

                case "Sega Game Gear":
                    switch (name)
                    {
                        case "Sonic The Hedgehog (8-bit)":
                            gms[57].ExeLoc = loc;

                            if (act == "True")
                                gms[57].isActive = true;

                            gms[57].EmuArgs = args;
                            break;

                        case "Sonic The Hedgehog 2 (8-bit)":
                            gms[58].ExeLoc = loc;

                            if (act == "True")
                                gms[58].isActive = true;

                            gms[58].EmuArgs = args;
                            break;

                        case "Sonic Chaos":
                            gms[59].ExeLoc = loc;

                            if (act == "True")
                                gms[59].isActive = true;

                            gms[59].EmuArgs = args;
                            break;

                        case "Sonic Blast":
                            gms[60].ExeLoc = loc;

                            if (act == "True")
                                gms[60].isActive = true;

                            gms[60].EmuArgs = args;
                            break;

                        case "Sonic Spinball (8-bit)":
                            gms[61].ExeLoc = loc;

                            if (act == "True")
                                gms[61].isActive = true;

                            gms[61].EmuArgs = args;
                            break;

                        case "Dr. Robotnik's Mean Bean Machine (8-bit)":
                            gms[62].ExeLoc = loc;

                            if (act == "True")
                                gms[62].isActive = true;

                            gms[62].EmuArgs = args;
                            break;

                        case "Sonic Triple Trouble":
                            gms[63].ExeLoc = loc;

                            if (act == "True")
                                gms[63].isActive = true;

                            gms[63].EmuArgs = args;
                            break;

                        case "Sonic Labyrinth":
                            gms[64].ExeLoc = loc;

                            if (act == "True")
                                gms[64].isActive = true;

                            gms[64].EmuArgs = args;
                            break;

                        case "Sonic Drift":
                            gms[65].ExeLoc = loc;

                            if (act == "True")
                                gms[65].isActive = true;

                            gms[65].EmuArgs = args;
                            break;

                        case "Sonic Drift 2":
                            gms[66].ExeLoc = loc;

                            if (act == "True")
                                gms[66].isActive = true;

                            gms[66].EmuArgs = args;
                            break;

                        case "Tails' Adventure":
                            gms[67].ExeLoc = loc;

                            if (act == "True")
                                gms[67].isActive = true;

                            gms[67].EmuArgs = args;
                            break;

                        case "Tails' Skypatrol":
                            gms[68].ExeLoc = loc;

                            if (act == "True")
                                gms[68].isActive = true;

                            gms[68].EmuArgs = args;
                            break;
                    }
                    break;

                case "Arcade (MAME)":
                    switch (name)
                    {
                        case "SegaSonic The Hedgehog":
                            gms[69].ExeLoc = loc;

                            if (act == "True")
                                gms[69].isActive = true;

                            gms[69].EmuArgs = args;
                            break;

                        case "Waku Waku Sonic Patrol Car":
                            gms[70].ExeLoc = loc;

                            if (act == "True")
                                gms[70].isActive = true;

                            gms[70].EmuArgs = args;
                            break;

                        case "SegaSonic Popcorn Shop":
                            gms[71].ExeLoc = loc;

                            if (act == "True")
                                gms[71].isActive = true;

                            gms[71].EmuArgs = args;
                            break;

                        case "SegaSonic Cosmo Fighter":
                            gms[72].ExeLoc = loc;

                            if (act == "True")
                                gms[72].isActive = true;

                            gms[72].EmuArgs = args;
                            break;

                        case "Sonic The Hedgehog (Mega Play)":
                            gms[73].ExeLoc = loc;

                            if (act == "True")
                                gms[73].isActive = true;

                            gms[73].EmuArgs = args;
                            break;

                        case "Sonic The Hedgehog 2 (Mega Play)":
                            gms[74].ExeLoc = loc;

                            if (act == "True")
                                gms[74].isActive = true;

                            gms[74].EmuArgs = args;
                            break;
                    }
                    break;

                case "Arcade (Sega AM2)":
                    switch(name)
                    {
                        case "Sonic the Fighters":
                            gms[75].ExeLoc = loc;

                            if (act == "True")
                                gms[75].isActive = true;

                            gms[75].EmuArgs = args;
                            break;


                    }
                    break;

                case "Sega Saturn":
                    switch (name)
                    {
                        case "Sonic 3D Blast":
                            gms[76].ExeLoc = loc;

                            if (act == "True")
                                gms[76].isActive = true;

                            gms[76].EmuArgs = args;
                            break;

                        case "Sonic Jam":
                            gms[77].ExeLoc = loc;

                            if (act == "True")
                                gms[77].isActive = true;

                            gms[77].EmuArgs = args;
                            break;

                        case "Sonic R":
                            gms[78].ExeLoc = loc;

                            if (act == "True")
                                gms[78].isActive = true;

                            gms[78].EmuArgs = args;
                            break;


                    }
                    break;

                case "Sega Dreamcast":
                    switch (name)
                    {
                        case "Sonic Adventure":
                            gms[79].ExeLoc = loc;

                            if (act == "True")
                                gms[79].isActive = true;

                            gms[79].EmuArgs = args;
                            break;

                        case "Sonic Adventure 2":
                            gms[80].ExeLoc = loc;

                            if (act == "True")
                                gms[80].isActive = true;

                            gms[80].EmuArgs = args;
                            break;

                        case "Sonic Shuffle":
                            gms[81].ExeLoc = loc;

                            if (act == "True")
                                gms[81].isActive = true;

                            gms[81].EmuArgs = args;
                            break;


                    }
                    break;

                case "Nintendo GameCube":
                    switch(name)
                    {
                        case "Sonic Adventure DX":
                            gms[82].ExeLoc = loc;

                            if (act == "True")
                                gms[82].isActive = true;

                            gms[82].EmuArgs = args;
                            break;

                        case "Sonic Adventure 2 Battle":
                            gms[83].ExeLoc = loc;

                            if (act == "True")
                                gms[83].isActive = true;

                            gms[83].EmuArgs = args;
                            break;

                        case "Sonic Heroes":
                            gms[84].ExeLoc = loc;

                            if (act == "True")
                                gms[84].isActive = true;

                            gms[84].EmuArgs = args;
                            break;

                        case "Sonic Riders":
                            gms[85].ExeLoc = loc;

                            if (act == "True")
                                gms[85].isActive = true;

                            gms[85].EmuArgs = args;
                            break;

                        case "Sonic Mega Collection":
                            gms[86].ExeLoc = loc;

                            if (act == "True")
                                gms[86].isActive = true;

                            gms[86].EmuArgs = args;
                            break;

                        case "Sonic Gems Collection":
                            gms[87].ExeLoc = loc;

                            if (act == "True")
                                gms[87].isActive = true;

                            gms[87].EmuArgs = args;
                            break;

                        case "Shadow the Hedgehog":
                            gms[211].ExeLoc = loc;

                            if (act == "True")
                                gms[211].isActive = true;

                            gms[211].EmuArgs = args;
                            break;
                    }
                    break;

                case "Nintendo Wii":
                    switch (name)
                    {
                        case "Sonic and the Secret Rings":
                            gms[88].ExeLoc = loc;

                            if (act == "True")
                                gms[88].isActive = true;

                            gms[88].EmuArgs = args;
                            break;

                        case "Sonic and the Black Knight":
                            gms[89].ExeLoc = loc;

                            if (act == "True")
                                gms[89].isActive = true;

                            gms[89].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode 1":
                            gms[90].ExeLoc = loc;

                            if (act == "True")
                                gms[90].isActive = true;

                            gms[90].EmuArgs = args;
                            break;

                        case "Sonic Riders: Zero Gravity":
                            gms[91].ExeLoc = loc;

                            if (act == "True")
                                gms[91].isActive = true;

                            gms[91].EmuArgs = args;
                            break;

                        case "Sonic Unleashed":
                            gms[92].ExeLoc = loc;

                            if (act == "True")
                                gms[92].isActive = true;

                            gms[92].EmuArgs = args;
                            break;

                        case "Sonic Colors":
                            gms[93].ExeLoc = loc;

                            if (act == "True")
                                gms[93].isActive = true;

                            gms[93].EmuArgs = args;
                            break;

                        case "Sonic && Sega All Star Racing":
                            gms[94].ExeLoc = loc;

                            if (act == "True")
                                gms[94].isActive = true;

                            gms[94].EmuArgs = args;
                            break;

                        case "Sega Superstars Tennis":
                            gms[95].ExeLoc = loc;

                            if (act == "True")
                                gms[95].isActive = true;

                            gms[95].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the Olympic Games":
                            gms[96].ExeLoc = loc;

                            if (act == "True")
                                gms[96].isActive = true;

                            gms[96].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the Olympic Winter Games":
                            gms[97].ExeLoc = loc;

                            if (act == "True")
                                gms[97].isActive = true;

                            gms[97].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the London 2012 Olympic Games":
                            gms[98].ExeLoc = loc;

                            if (act == "True")
                                gms[98].isActive = true;

                            gms[98].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog (VC)":
                            gms[99].ExeLoc = loc;

                            if (act == "True")
                                gms[99].isActive = true;

                            gms[99].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog (8-bit) (VC)":
                            gms[100].ExeLoc = loc;

                            if (act == "True")
                                gms[100].isActive = true;

                            gms[100].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2 (VC)":
                            gms[101].ExeLoc = loc;

                            if (act == "True")
                                gms[101].isActive = true;

                            gms[101].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2 (8-bit) (VC)":
                            gms[102].ExeLoc = loc;

                            if (act == "True")
                                gms[102].isActive = true;

                            gms[102].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 3 (VC)":
                            gms[103].ExeLoc = loc;

                            if (act == "True")
                                gms[103].isActive = true;

                            gms[103].EmuArgs = args;
                            break;

                        case "Sonic & Knuckles (VC)":
                            gms[104].ExeLoc = loc;

                            if (act == "True")
                                gms[104].isActive = true;

                            gms[104].EmuArgs = args;
                            break;

                        case "Sonic Chaos (VC)":
                            gms[105].ExeLoc = loc;

                            if (act == "True")
                                gms[105].isActive = true;

                            gms[105].EmuArgs = args;
                            break;

                        case "Sonic 3D Blast (VC)":
                            gms[106].ExeLoc = loc;

                            if (act == "True")
                                gms[106].isActive = true;

                            gms[106].EmuArgs = args;
                            break;

                        case "Sonic Spinball (VC)":
                            gms[107].ExeLoc = loc;

                            if (act == "True")
                                gms[107].isActive = true;

                            gms[107].EmuArgs = args;
                            break;

                        case "Dr. Robotnik's Mean Bean Machine (VC)":
                            gms[108].ExeLoc = loc;

                            if (act == "True")
                                gms[108].isActive = true;

                            gms[108].EmuArgs = args;
                            break;


                    }
                    break;

                case "Nintendo Wii U":
                    switch(name)
                    {
                        case "Sonic Lost World":
                            gms[109].ExeLoc = loc;

                            if (act == "True")
                                gms[109].isActive = true;

                            gms[109].EmuArgs = args;
                            break;

                        case "Sonic && All-Stars Racing Transformed":
                            gms[110].ExeLoc = loc;

                            if (act == "True")
                                gms[110].isActive = true;

                            gms[110].EmuArgs = args;
                            break;

                        case "Sonic Boom: Rise of Lyric":
                            gms[111].ExeLoc = loc;

                            if (act == "True")
                                gms[111].isActive = true;

                            gms[111].EmuArgs = args;
                            break;

                        case "Mario & Sonic at the Sochi 2014 Olympic Winter Games":
                            gms[112].ExeLoc = loc;

                            if (act == "True")
                                gms[112].isActive = true;

                            gms[112].EmuArgs = args;
                            break;

                        case "Mario & Sonic at the Rio 2016 Olympic Games":
                            gms[113].ExeLoc = loc;

                            if (act == "True")
                                gms[113].isActive = true;

                            gms[113].EmuArgs = args;
                            break;

                        case "Sonic Advance (VC)":
                            gms[114].ExeLoc = loc;

                            if (act == "True")
                                gms[114].isActive = true;

                            gms[114].EmuArgs = args;
                            break;

                        case "Sonic Advance 2 (VC)":
                            gms[115].ExeLoc = loc;

                            if (act == "True")
                                gms[115].isActive = true;

                            gms[115].EmuArgs = args;
                            break;

                        case "Sonic Advance 3 (VC)":
                            gms[116].ExeLoc = loc;

                            if (act == "True")
                                gms[116].isActive = true;

                            gms[116].EmuArgs = args;
                            break;


                    }
                    break;

                case "Nintendo Switch":
                    switch(name)
                    {
                        case "Sonic Mania":
                            gms[117].ExeLoc = loc;

                            if (act == "True")
                                gms[117].isActive = true;

                            gms[117].EmuArgs = args;
                            break;

                        case "Sonic Forces":
                            gms[118].ExeLoc = loc;

                            if (act == "True")
                                gms[118].isActive = true;

                            gms[118].EmuArgs = args;
                            break;

                        case "Sonic Colours: Ultimate":
                            gms[119].ExeLoc = loc;

                            if (act == "True")
                                gms[119].isActive = true;

                            gms[119].EmuArgs = args;
                            break;

                        case "Sonic Origins":
                            gms[120].ExeLoc = loc;

                            if (act == "True")
                                gms[120].isActive = true;

                            gms[120].EmuArgs = args;
                            break;

                        case "Sonic Frontiers":
                            gms[121].ExeLoc = loc;

                            if (act == "True")
                                gms[121].isActive = true;

                            gms[121].EmuArgs = args;
                            break;

                        case "Sonic Superstars":
                            gms[122].ExeLoc = loc;

                            if (act == "True")
                                gms[122].isActive = true;

                            gms[122].EmuArgs = args;
                            break;

                        case "Team Sonic Racing":
                            gms[123].ExeLoc = loc;

                            if (act == "True")
                                gms[123].isActive = true;

                            gms[123].EmuArgs = args;
                            break;

                        case "Mario & Sonic at the Olympic Games Tokyo 2020":
                            gms[124].ExeLoc = loc;

                            if (act == "True")
                                gms[124].isActive = true;

                            gms[124].EmuArgs = args;
                            break;

                        case "Sega Ages Sonic the Hedgehog":
                            gms[125].ExeLoc = loc;

                            if (act == "True")
                                gms[125].isActive = true;

                            gms[125].EmuArgs = args;
                            break;

                        case "Sega Ages Sonic the Hedgehog 2":
                            gms[126].ExeLoc = loc;

                            if (act == "True")
                                gms[126].isActive = true;

                            gms[126].EmuArgs = args;
                            break;


                    }
                    break;

                case "Sony PlayStation 2":
                    switch(name)
                    {
                        case "Sonic Heroes":
                            gms[127].ExeLoc = loc;

                            if (act == "True")
                                gms[127].isActive = true;

                            gms[127].EmuArgs = args;
                            break;

                        case "Shadow The Hedgehog":
                            gms[128].ExeLoc = loc;

                            if (act == "True")
                                gms[128].isActive = true;

                            gms[128].EmuArgs = args;
                            break;

                        case "Sonic Unleashed":
                            gms[129].ExeLoc = loc;

                            if (act == "True")
                                gms[129].isActive = true;

                            gms[129].EmuArgs = args;
                            break;

                        case "Sonic Riders":
                            gms[130].ExeLoc = loc;

                            if (act == "True")
                                gms[130].isActive = true;

                            gms[130].EmuArgs = args;
                            break;

                        case "Sonic Riders: Zero Gravity":
                            gms[131].ExeLoc = loc;

                            if (act == "True")
                                gms[131].isActive = true;

                            gms[131].EmuArgs = args;
                            break;

                        case "Sonic Mega Collection Plus":
                            gms[132].ExeLoc = loc;

                            if (act == "True")
                                gms[132].isActive = true;

                            gms[132].EmuArgs = args;
                            break;

                        case "Sonic Gems Collection":
                            gms[133].ExeLoc = loc;

                            if (act == "True")
                                gms[133].isActive = true;

                            gms[133].EmuArgs = args;
                            break;

                        case "Sega Superstars":
                            gms[134].ExeLoc = loc;

                            if (act == "True")
                                gms[134].isActive = true;

                            gms[134].EmuArgs = args;
                            break;

                        case "Sega Superstars Tennis":
                            gms[135].ExeLoc = loc;

                            if (act == "True")
                                gms[135].isActive = true;

                            gms[135].EmuArgs = args;
                            break;

                        case "Sega Genesis Collection":
                            gms[136].ExeLoc = loc;

                            if (act == "True")
                                gms[136].isActive = true;

                            gms[136].EmuArgs = args;
                            break;


                    }
                    break;

                case "Sony Playstation 3":
                    switch(name)
                    {
                        case "Sonic the Hedgehog (2006)":
                            gms[137].ExeLoc = loc;

                            if (act == "True")
                                gms[137].isActive = true;

                            gms[137].EmuArgs = args;
                            break;

                        case "Sonic Unleashed":
                            gms[138].ExeLoc = loc;

                            if (act == "True")
                                gms[138].isActive = true;

                            gms[138].EmuArgs = args;
                            break;

                        case "Sonic Generations":
                            gms[139].ExeLoc = loc;

                            if (act == "True")
                                gms[139].isActive = true;

                            gms[139].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode I":
                            gms[140].ExeLoc = loc;

                            if (act == "True")
                                gms[140].isActive = true;

                            gms[140].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode II":
                            gms[141].ExeLoc = loc;

                            if (act == "True")
                                gms[141].isActive = true;

                            gms[141].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog (Sega Vintage Collection)":
                            gms[142].ExeLoc = loc;

                            if (act == "True")
                                gms[142].isActive = true;

                            gms[142].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2 (Sega Vintage Collection)":
                            gms[143].ExeLoc = loc;

                            if (act == "True")
                                gms[143].isActive = true;

                            gms[143].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog CD (2011)":
                            gms[144].ExeLoc = loc;

                            if (act == "True")
                                gms[144].isActive = true;

                            gms[144].EmuArgs = args;
                            break;

                        case "Sonic the Fighters":
                            gms[145].ExeLoc = loc;

                            if (act == "True")
                                gms[145].isActive = true;

                            gms[145].EmuArgs = args;
                            break;

                        case "Sonic Adventure DX":
                            gms[146].ExeLoc = loc;

                            if (act == "True")
                                gms[146].isActive = true;

                            gms[146].EmuArgs = args;
                            break;

                        case "Sonic Adventure 2: Battle":
                            gms[147].ExeLoc = loc;

                            if (act == "True")
                                gms[147].isActive = true;

                            gms[147].EmuArgs = args;
                            break;

                        case "Sonic && Sega All-Stars Racing":
                            gms[148].ExeLoc = loc;

                            if (act == "True")
                                gms[148].isActive = true;

                            gms[148].EmuArgs = args;
                            break;

                        case "Sonic && All-Stars Racing Transformed":
                            gms[149].ExeLoc = loc;

                            if (act == "True")
                                gms[149].isActive = true;

                            gms[149].EmuArgs = args;
                            break;

                        case "Sega Superstars Tennis":
                            gms[150].ExeLoc = loc;

                            if (act == "True")
                                gms[150].isActive = true;

                            gms[150].EmuArgs = args;
                            break;


                    }
                    break;

                case "Microsoft XBox":
                    switch(name)
                    {
                        case "Sonic Heroes":
                            gms[151].ExeLoc = loc;

                            if (act == "True")
                                gms[151].isActive = true;

                            gms[151].EmuArgs = args;
                            break;

                        case "Shadow the Hedgehog":
                            gms[152].ExeLoc = loc;

                            if (act == "True")
                                gms[152].isActive = true;

                            gms[152].EmuArgs = args;
                            break;

                        case "Sonic Riders":
                            gms[153].ExeLoc = loc;

                            if (act == "True")
                                gms[153].isActive = true;

                            gms[153].EmuArgs = args;
                            break;

                        case "Sonic Mega Collection Plus":
                            gms[154].ExeLoc = loc;

                            if (act == "True")
                                gms[154].isActive = true;

                            gms[154].EmuArgs = args;
                            break;


                    }
                    break;

                case "Microsoft XBox 360":
                    switch (name)
                    {
                        case "Sonic the Hedgehog (2006)":
                            gms[155].ExeLoc = loc;

                            if (act == "True")
                                gms[155].isActive = true;

                            gms[155].EmuArgs = args;
                            break;

                        case "Sonic Unleashed":
                            gms[156].ExeLoc = loc;

                            if (act == "True")
                                gms[156].isActive = true;

                            gms[156].EmuArgs = args;
                            break;

                        case "Sonic Generations":
                            gms[157].ExeLoc = loc;

                            if (act == "True")
                                gms[157].isActive = true;

                            gms[157].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode I":
                            gms[158].ExeLoc = loc;

                            if (act == "True")
                                gms[158].isActive = true;

                            gms[158].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 4 Episode II":
                            gms[159].ExeLoc = loc;

                            if (act == "True")
                                gms[159].isActive = true;

                            gms[159].EmuArgs = args;
                            break;

                        case "Sonic Free Riders":
                            gms[160].ExeLoc = loc;

                            if (act == "True")
                                gms[160].isActive = true;

                            gms[160].EmuArgs = args;
                            break;

                        case "Sonic && Sega All-Stars Racing":
                            gms[161].ExeLoc = loc;

                            if (act == "True")
                                gms[161].isActive = true;

                            gms[161].EmuArgs = args;
                            break;

                        case "Sonic & All-Stars Racing Transformed":
                            gms[162].ExeLoc = loc;

                            if (act == "True")
                                gms[162].isActive = true;

                            gms[162].EmuArgs = args;
                            break;

                        case "Sega Superstars Tennis":
                            gms[163].ExeLoc = loc;

                            if (act == "True")
                                gms[163].isActive = true;

                            gms[163].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog (XBLA)":
                            gms[164].ExeLoc = loc;

                            if (act == "True")
                                gms[164].isActive = true;

                            gms[164].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2 (XBLA)":
                            gms[165].ExeLoc = loc;

                            if (act == "True")
                                gms[165].isActive = true;

                            gms[165].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog CD (2011)":
                            gms[166].ExeLoc = loc;

                            if (act == "True")
                                gms[166].isActive = true;

                            gms[166].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 3 (XBLA)":
                            gms[167].ExeLoc = loc;

                            if (act == "True")
                                gms[167].isActive = true;

                            gms[167].EmuArgs = args;
                            break;

                        case "Sonic && Knuckles (XBLA)":
                            gms[168].ExeLoc = loc;

                            if (act == "True")
                                gms[168].isActive = true;

                            gms[168].EmuArgs = args;
                            break;

                        case "Sonic the Fighters":
                            gms[169].ExeLoc = loc;

                            if (act == "True")
                                gms[169].isActive = true;

                            gms[169].EmuArgs = args;
                            break;

                        case "Sonic Adventure":
                            gms[170].ExeLoc = loc;

                            if (act == "True")
                                gms[170].isActive = true;

                            gms[170].EmuArgs = args;
                            break;

                        case "Sonic Adventure 2":
                            gms[171].ExeLoc = loc;

                            if (act == "True")
                                gms[171].isActive = true;

                            gms[171].EmuArgs = args;
                            break;


                    }
                    break;

                case "Neo Geo Pocket Color":
                    switch(name)
                    {
                        case "Sonic the Hedgehog Pocket Adventure":
                            gms[172].ExeLoc = loc;

                            if (act == "True")
                                gms[172].isActive = true;

                            gms[172].EmuArgs = args;
                            break;


                    }
                    break;

                case "Game Boy Advance":
                    switch (name)
                    {
                        case "Sonic Advance":
                            gms[173].ExeLoc = loc;

                            if (act == "True")
                                gms[173].isActive = true;

                            gms[173].EmuArgs = args;
                            break;

                        case "Sonic Advance 2":
                            gms[174].ExeLoc = loc;

                            if (act == "True")
                                gms[174].isActive = true;

                            gms[174].EmuArgs = args;
                            break;

                        case "Sonic Battle":
                            gms[175].ExeLoc = loc;

                            if (act == "True")
                                gms[175].isActive = true;

                            gms[175].EmuArgs = args;
                            break;

                        case "Sonic Advance 3":
                            gms[176].ExeLoc = loc;

                            if (act == "True")
                                gms[176].isActive = true;

                            gms[176].EmuArgs = args;
                            break;

                        case "Sonic Pinball Party":
                            gms[177].ExeLoc = loc;

                            if (act == "True")
                                gms[177].isActive = true;

                            gms[177].EmuArgs = args;
                            break;

                        case "Tiny Chao Garden":
                            gms[178].ExeLoc = loc;

                            if (act == "True")
                                gms[178].isActive = true;

                            gms[178].EmuArgs = args;
                            break;

                        case "Sonic X: A Super Sonic Hero":
                            gms[179].ExeLoc = loc;

                            if (act == "True")
                                gms[179].isActive = true;

                            gms[179].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog Genesis":
                            gms[180].ExeLoc = loc;

                            if (act == "True")
                                gms[180].isActive = true;

                            gms[180].EmuArgs = args;
                            break;


                    }
                    break;

                case "Nintendo DS":
                    switch(name)
                    {
                        case "Sonic Rush":
                            gms[181].ExeLoc = loc;

                            if (act == "True")
                                gms[181].isActive = true;

                            gms[181].EmuArgs = args;
                            break;

                        case "Sonic Rush Adventure":
                            gms[182].ExeLoc = loc;

                            if (act == "True")
                                gms[182].isActive = true;

                            gms[182].EmuArgs = args;
                            break;

                        case "Sonic Colors":
                            gms[183].ExeLoc = loc;

                            if (act == "True")
                                gms[183].isActive = true;

                            gms[183].EmuArgs = args;
                            break;

                        case "Sonic Chronicles: The Dark Brotherhood":
                            gms[184].ExeLoc = loc;

                            if (act == "True")
                                gms[184].isActive = true;

                            gms[184].EmuArgs = args;
                            break;

                        case "Sega Superstars Tennis":
                            gms[185].ExeLoc = loc;

                            if (act == "True")
                                gms[185].isActive = true;

                            gms[185].EmuArgs = args;
                            break;

                        case "Sonic && Sega All-Stars Racing":
                            gms[186].ExeLoc = loc;

                            if (act == "True")
                                gms[186].isActive = true;

                            gms[186].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the Olympic Games":
                            gms[187].ExeLoc = loc;

                            if (act == "True")
                                gms[187].isActive = true;

                            gms[187].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the Olympic Winter Games":
                            gms[188].ExeLoc = loc;

                            if (act == "True")
                                gms[188].isActive = true;

                            gms[188].EmuArgs = args;
                            break;

                        case "Sonic Classic Collection":
                            gms[189].ExeLoc = loc;

                            if (act == "True")
                                gms[189].isActive = true;

                            gms[189].EmuArgs = args;
                            break;


                    }
                    break;

                case "Nintendo 3DS":
                    switch (name)
                    {
                        case "Sonic Generations":
                            gms[190].ExeLoc = loc;

                            if (act == "True")
                                gms[190].isActive = true;

                            gms[190].EmuArgs = args;
                            break;

                        case "Sonic Lost World":
                            gms[191].ExeLoc = loc;

                            if (act == "True")
                                gms[191].isActive = true;

                            gms[191].EmuArgs = args;
                            break;

                        case "Sonic Boom: Shattered Crystal":
                            gms[192].ExeLoc = loc;

                            if (act == "True")
                                gms[192].isActive = true;

                            gms[192].EmuArgs = args;
                            break;

                        case "Sonic Boom: Fire and Ice":
                            gms[193].ExeLoc = loc;

                            if (act == "True")
                                gms[193].isActive = true;

                            gms[193].EmuArgs = args;
                            break;

                        case "Sonic && All-Stars Racing Transformed":
                            gms[194].ExeLoc = loc;

                            if (act == "True")
                                gms[194].isActive = true;

                            gms[194].EmuArgs = args;
                            break;

                        case "Mario && Sonic at the London 2012 Olympic Games":
                            gms[195].ExeLoc = loc;

                            if (act == "True")
                                gms[195].isActive = true;

                            gms[195].EmuArgs = args;
                            break;

                        case "Mario && Sonic - London 2012 Virtual Card Album":
                            gms[196].ExeLoc = loc;

                            if (act == "True")
                                gms[196].isActive = true;

                            gms[196].EmuArgs = args;
                            break;

                        case "Mario & Sonic at the Rio 2016 Olympic Games":
                            gms[197].ExeLoc = loc;

                            if (act == "True")
                                gms[197].isActive = true;

                            gms[197].EmuArgs = args;
                            break;

                        case "3D Sonic the Hedgehog":
                            gms[198].ExeLoc = loc;

                            if (act == "True")
                                gms[198].isActive = true;

                            gms[198].EmuArgs = args;
                            break;

                        case "3D Sonic the Hedgehog 2":
                            gms[199].ExeLoc = loc;

                            if (act == "True")
                                gms[199].isActive = true;

                            gms[199].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog (8-bit) (VC)":
                            gms[200].ExeLoc = loc;

                            if (act == "True")
                                gms[200].isActive = true;

                            gms[200].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog 2 (8-bit) (VC)":
                            gms[201].ExeLoc = loc;

                            if (act == "True")
                                gms[201].isActive = true;

                            gms[201].EmuArgs = args;
                            break;

                        case "Sonic the Hedgehog Triple Trouble (VC)":
                            gms[202].ExeLoc = loc;

                            if (act == "True")
                                gms[202].isActive = true;

                            gms[202].EmuArgs = args;
                            break;

                        case "Sonic Blast (VC)":
                            gms[203].ExeLoc = loc;

                            if (act == "True")
                                gms[203].isActive = true;

                            gms[203].EmuArgs = args;
                            break;

                        case "Sonic Labyrinth (VC)":
                            gms[204].ExeLoc = loc;

                            if (act == "True")
                                gms[204].isActive = true;

                            gms[204].EmuArgs = args;
                            break;

                        case "Sonic Drift 2 (VC)":
                            gms[205].ExeLoc = loc;

                            if (act == "True")
                                gms[205].isActive = true;

                            gms[205].EmuArgs = args;
                            break;

                        case "Dr. Robotnik's Mean Bean Machine (8-bit) (VC)":
                            gms[206].ExeLoc = loc;

                            if (act == "True")
                                gms[206].isActive = true;

                            gms[206].EmuArgs = args;
                            break;

                        case "Tails' Adventures (VC)":
                            gms[207].ExeLoc = loc;

                            if (act == "True")
                                gms[207].isActive = true;

                            gms[207].EmuArgs = args;
                            break;


                    }
                    break;

                case "PlayStation Portable":
                    switch (name)
                    {
                        case "Sonic Rivals":
                            gms[208].ExeLoc = loc;

                            if (act == "True")
                                gms[208].isActive = true;

                            gms[208].EmuArgs = args;
                            break;

                        case "Sonic Rivals 2":
                            gms[209].ExeLoc = loc;

                            if (act == "True")
                                gms[209].isActive = true;

                            gms[209].EmuArgs = args;
                            break;

                        case "Sega Genesis Collection":
                            gms[210].ExeLoc = loc;

                            if (act == "True")
                                gms[210].isActive = true;

                            gms[210].EmuArgs = args;
                            break;


                    }
                    break;

                case "DRM Free":
                    switch (name)
                    {
                        case "Sonic The Hedgehog (Decompilation)":
                            gms[23].ExeLoc = loc;
                            gms[23].EmuArgs = args;
                            if (act == "True")
                                gms[23].isActive = true;

                            break;

                        case "Sonic The Hedgehog 2 (Decompilation)":
                            gms[24].ExeLoc = loc;
                            gms[24].EmuArgs = args;

                            if (act == "True")
                                gms[24].isActive = true;

                            break;

                        case "Sonic The Hedgehog CD":
                            gms[25].ExeLoc = loc;
                            gms[25].EmuArgs = args;
                            if ( act == "True")
                                gms[25].isActive = true;
                            break;

                        

                        case "Sonic The Hedgehog CD (Decompilation)":
                            gms[27].ExeLoc = loc;
                            gms[27].EmuArgs = args;
                            if (act == "True")
                                gms[27].isActive = true;
                            break;

                        case "Sonic && Knuckles Collection":
                            gms[28].ExeLoc = loc;
                            gms[28].EmuArgs = args;
                            if (act == "True")
                                gms[28].isActive = true;
                            break;

                        

                        case "Sonic 3D Blast":
                            gms[30].ExeLoc = loc;
                            gms[30].EmuArgs = args;
                            if (act == "True")
                                gms[30].isActive = true;
                            break;

                        

                        case "Sonic R":
                            gms[32].ExeLoc = loc; 
                            gms[32].EmuArgs = args;
                            if ( act == "True")
                                gms[32].isActive = true;
                            break;

                        case "Sonic Adventure DX":
                            gms[33].ExeLoc = loc;
                            gms[33].EmuArgs = args;
                            if (act == "True")
                                gms[33].isActive = true;
                            break;

                        case "Sonic Heroes":
                            gms[34].ExeLoc = loc;
                            gms[34].EmuArgs = args;
                            if (act == "True")
                                gms[34].isActive=true;
                            break;

                        case "Sonic Mega Collection Plus":
                            gms[35].ExeLoc=loc;
                            gms[35].EmuArgs=args;
                            if (act == "True")
                                gms[35].isActive = true;
                            break;

                        case "Sonic Riders":
                            gms[36].ExeLoc = loc;
                            gms[36].EmuArgs = args;
                            if (act == "True")
                                gms[36].isActive = true;
                            break;

                        case "Sonic Mania (Decompilation)":
                            gms[37].ExeLoc = loc;
                            gms[37].EmuArgs = args;
                            if (act == "True")
                                gms[37].isActive = true;
                            break;
                    }
                    break;

                case "Sega PC Reloaded":
                    switch (name)
                    {
                        case "Sonic CD (Sega PC Reloaded)":
                            gms[26].ExeLoc = loc;
                            gms[26].EmuArgs = args;
                            if (act == "True")
                                gms[26].isActive = true;
                            break;

                        case "Sonic && Knuckles Collection (Sega PC Reloaded)":
                            gms[29].ExeLoc = loc;
                            gms[29].EmuArgs = args;
                            if (act == "True")
                                gms[29].isActive = true;
                            break;

                        case "Sonic 3D Blast (Sega PC Reloaded)":
                            gms[31].ExeLoc = loc;
                            gms[31].EmuArgs = args;
                            if (act == "True")
                                gms[31].isActive = true;
                            break;
                    }
                    break;

            }

            LaunchContainer.launcher.checkActives();
        }

        public static void saveProgInfo(string name, string type, string loc)
        {

            switch (type)
            {
                case "ModLoader":

                    ProgramInfo[] prog = LaunchContainer.launcher.ModLoaders;
                    switch(name)
                    {
                        case "HedgeModManager":
                            prog[0].Location = loc;
                            break;


                        case "SA Mod Loader":
                            prog[1].Location = loc;
                            break;


                        case "SA2 Mod Loader":
                            prog[2].Location = loc;
                            break;


                        case "Mania Mod Loader":
                            prog[3].Location = loc;
                            break;


                        case "Sonic CD Steam Mod Loader":
                            prog[4].Location = loc;
                            break;


                        case "Sonic 4 Mod Loader":
                            prog[5].Location = loc;
                            break;


                        case "Sonic 4 (EP2) Mod Loader":
                            prog[6].Location = loc;
                            break;


                        case "Sonic R Mod Loader":
                            prog[7].Location = loc;
                            break;


                        case "S&K Collection Mod Loader":
                            prog[8].Location = loc;
                            break;


                        case "RSDK Mod Manager":
                            prog[9].Location = loc;
                            break;


                        case "Reloaded 2":
                            prog[10].Location = loc;
                            break;


                        case "Concursus":
                            prog[11].Location = loc;
                            break;



                    }

                    break;

                case "Emulator":
                    ProgramInfo[] emul = LaunchContainer.launcher.Emulators;
                    
                    switch (name)
                    {
                        case "Mega Drive":
                            emul[0].Location = loc;
                            break;


                        case "Master System":
                            emul[1].Location = loc;
                            break;


                        case "Game Gear":
                            emul[2].Location = loc;
                            break;


                        case "Sega Saturn":
                            emul[3].Location = loc;
                            break;


                        case "Dreamcast":
                            emul[4].Location = loc;
                            break;


                        case "Arcade (MAME)":
                            emul[5].Location = loc;
                            break;


                        case "GameCube":
                            emul[6].Location = loc;
                            break;


                        case "Wii":
                            emul[7].Location = loc;
                            break;


                        case "Wii U":
                            emul[8].Location = loc;
                            break;


                        case "Switch":
                            emul[9].Location = loc;
                            break;


                        case "PS2":
                            emul[10].Location = loc;
                            break;


                        case "PS3":
                            emul[11].Location = loc;
                            break;


                        case "XBox":
                            emul[12].Location = loc;
                            break;


                        case "XBox 360":
                            emul[13].Location = loc;
                            break;


                        case "Neo Geo Pocket Color":
                            emul[14].Location = loc;
                            break;


                        case "Game Boy Advance":
                            emul[15].Location = loc;
                            break;


                        case "DS":
                            emul[16].Location = loc;
                            break;


                        case "3DS":
                            emul[17].Location = loc;
                            break;


                        case "PSP":
                            emul[18].Location = loc;
                            break;


                        case "Sega PC Reloaded":
                            emul[19].Location = loc;
                            break;


                        case "Sega AM2":
                            emul[20].Location = loc;
                            break;
                    }
                    break;

                case "DRM":
                    switch (name)
                    {
                        case "Steam":
                            LaunchContainer.launcher.SteamLoc = loc; 
                            break;
                    }
                    break;
            }
        }

        public static void steamDetect()
        {
            if (LaunchContainer.launcher.SteamLoc != "")
            {

                //Sonic & Sega All Star Racing

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic and SEGA All Stars Racing\\Sonic & SEGA All-Stars Racing.exe")))
                {
                    LaunchContainer.launcher.Games[0].activate();
                }


                //Sega Mega Drive & Genesis Classics 

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sega Classics\\SEGAGameRoom.exe")))
                {
                    LaunchContainer.launcher.Games[1].activate();
                }

                //Sonic the Hedgehog CD  

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic CD\\soniccd.exe")))
                {
                    LaunchContainer.launcher.Games[2].activate();
                }

                //Sonic Adventure DX    

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic Adventure DX\\sonic.exe")))
                {
                    LaunchContainer.launcher.Games[3].activate();
                }

                //Sonic Adventure 2 Battle 

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic Adventure 2\\sonic2app.exe")))
                {
                    LaunchContainer.launcher.Games[4].activate();
                }

                //Sonic Generations

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic Generations\\SonicGenerations.exe")))
                {
                    LaunchContainer.launcher.Games[5].activate();
                }

                //Sonic the Hedgehog 4 Episode 1 

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic the Hedgehog 4 EP 1\\SonicLauncher.exe")))
                {
                    LaunchContainer.launcher.Games[6].activate();
                }

                //Sonic the Hedgehog 4 Episode 2

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic the Hedgehog 4 - EP 2\\Launcher.exe")))
                {
                    LaunchContainer.launcher.Games[7].activate();
                }

            
                //Sonic & All Stars Racing Transformed

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic & All - Stars Racing Transformed\\Launcher.exe")))
                {
                    LaunchContainer.launcher.Games[8].activate();
                }

                //Sonic Lost World

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic Lost World\\slw.exe")))
                {
                    LaunchContainer.launcher.Games[9].activate();
                }

                //Sonic Mania

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Sonic Mania\\SonicMania.exe")))
                {
                    LaunchContainer.launcher.Games[10].activate();
                }

                //Sonic Forces

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\SonicForces\\build\\main\\projects\\exec\\Sonic Forces.exe")))
                {
                    LaunchContainer.launcher.Games[11].activate();
                }

                //Team Sonic Racing

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Team Sonic Racing\\GameApp_PcDx11_x64Final.exe")))
                {
                    LaunchContainer.launcher.Games[12].activate();
                }

                //Sonic Origins  

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\SonicOrigins\\build\\main\\projects\\exec\\SonicOrigins.exe")))
                {
                    LaunchContainer.launcher.Games[14].activate();
                }

                //The Murder of Sonic The Hedgehog

                if (File.Exists(Path.Combine(LaunchContainer.launcher.SteamLoc, "steamapps\\common\\Themurderofsonicthehedgehog\\The Murder of Sonic The Hedgehog\\The Murder of Sonic The Hedgehog.exe")))
                {
                    LaunchContainer.launcher.Games[16].activate();
                }
            }
        }

        
    }
}
