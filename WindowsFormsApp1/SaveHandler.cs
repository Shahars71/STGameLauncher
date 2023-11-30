using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class SaveHandler
    {
        public static void Save()
        {
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config1.xml");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.NewLineOnAttributes = true;
            settings.OmitXmlDeclaration = true;

            XmlWriter xmlwrite = XmlWriter.Create(filename,settings);


            xmlwrite.WriteStartDocument();
            xmlwrite.WriteComment("save data");


            xmlwrite.WriteStartElement("GameSettings");

            for (int i = 0; i < LaunchContainer.launcher.Games.Length; i++)
            {
                Game g = LaunchContainer.launcher.Games[i];

                xmlwrite.WriteStartElement("Game");

                xmlwrite.WriteElementString("Name", g.GameName);
                xmlwrite.WriteElementString("Platform", g.GameType);
                xmlwrite.WriteElementString("Path", g.ExeLoc);
                xmlwrite.WriteElementString("IsActive",g.isActive.ToString());
                xmlwrite.WriteElementString("Arguments", g.EmuArgs);

                xmlwrite.WriteEndElement();
            }

            xmlwrite.WriteEndElement();

            xmlwrite.WriteStartElement("ProgramSettings");

            for (int i = 0;i < LaunchContainer.launcher.ModLoaders.Length;i++)
            {
                ProgramInfo prog = LaunchContainer.launcher.ModLoaders[i];

                xmlwrite.WriteStartElement("ModLoader");

                xmlwrite.WriteElementString("Name", prog.Name);
                xmlwrite.WriteElementString("Path", prog.Location); 
                xmlwrite.WriteEndElement();
            }

            for (int i = 0; i < LaunchContainer.launcher.Emulators.Length; i++) 
            {
                ProgramInfo prog = LaunchContainer.launcher.Emulators[i];
                xmlwrite.WriteStartElement("Emulator");

                xmlwrite.WriteElementString("Name", prog.Name);
                xmlwrite.WriteElementString("Path", prog.Location);
                xmlwrite.WriteEndElement();
            }

            xmlwrite.WriteEndElement();


            xmlwrite.WriteEndDocument();
            xmlwrite.Flush();
            xmlwrite.Close();





            Console.WriteLine("XML Saved");
        }

        public static void Load()
        {
            try
            {
                XmlReader read = XmlReader.Create("config1.xml");

                while (read.Read())
                {

                    switch (read.Name)
                    {
                        case "GameSettings":
                            read.ReadToDescendant("Game");

                            read.ReadToDescendant("Name");
                            string na = read.GetAttribute("Name");
                            string plat = read.ReadToDescendant("Platform").ToString();
                            string pat = read.ReadToDescendant("Path").ToString();
                            string isa = read.ReadToDescendant("IsActive").ToString();
                            string argu = read.ReadToDescendant("Arguments").ToString();

                            saveGameInfo(na, plat,pat,isa, argu);

                            break;
                    }
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
                    Form2 options = new Form2();
                    options.Show();
                }
            }
        }

        public static void saveGameInfo(string name, string type, string loc, string act, string args)
        {
            Game[] gms = LaunchContainer.launcher.Games;


            switch (type)
            {
                case "Sega Mega Drive":
                    switch (name)
                    {
                        case "Sonic the Hedgehog":
                            gms[38].ExeLoc = loc;

                            if (act == "True")
                                gms[38].isActive = true;

                            gms[38].EmuArgs = args;
                            break;
                    }

                    break;
            }
        }


    }
}
