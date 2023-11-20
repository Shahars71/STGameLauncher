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
            var doc = new XDocument();

            try
            {
                doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"));
            }
            catch
            {

            }


        
            
            doc = new XDocument(
                        new XElement("root",

                new XElement("Component", new XAttribute("name", "Steam"),
                    new XElement("path", new XAttribute("value", LaunchContainer.launcher.SteamLoc))),

                new XElement("Component", new XAttribute("name", "HMM"),
                    new XElement("path", new XAttribute("value", LaunchContainer.launcher.HmmLoc))),

                new XElement("Component", new XAttribute("name", "SADXMM"),
                    new XElement("path", new XAttribute("value", LaunchContainer.launcher.SadxMMLoc)))


        ));
            doc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"));
            Console.WriteLine("XML Saved");
        }

        public static void Load()
        {
            try
            {
                XDocument xdoc = XDocument.Load("config.xml");

                var comps = from c in xdoc.Element("root").Elements("Component")
                            select c.Element("path").Attribute("value").Value;

                LaunchContainer.launcher.SteamLoc = comps.ElementAt(0);
                LaunchContainer.launcher.HmmLoc = comps.ElementAt(1);
                LaunchContainer.launcher.SadxMMLoc = comps.ElementAt(2);

                LaunchContainer.launcher.manageGames();
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
    }
}
