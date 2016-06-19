using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline
{
    class OpenFile
    {
        private static string fileToOpen;
        private static string dir;
        private static List<string> decoded = new List<string>();

        public static void OpenDialog()
        {
            XmlDocument xml = new XmlDocument();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Properties.Settings.Default.Projectpath;
            openFileDialog.Filter = "Visual Storyline-Files (*.vsl)|*.vsl";
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.FlushVars();
                decoded.Clear();

                fileToOpen = openFileDialog.FileName;
                Variables.currentFile = openFileDialog.FileName;
                Variables.currentFolder = Directory.GetParent(Variables.currentFile).ToString();
                Variables.currentPath = Directory.GetParent(Variables.currentFolder).ToString();
                Properties.Settings.Default.Projectpath = Directory.GetParent(openFileDialog.FileName).ToString();
                Properties.Settings.Default.Save();
                openFileDialog.Dispose();
            }
            else
            {
                return;
            }

            using (StreamReader sr = new StreamReader(fileToOpen))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    decoded.Add(Program.Decode(line));

                }
                xml.LoadXml(decoded.ElementAt(0));

                Variables.Version = xml.DocumentElement.SelectSingleNode("/metadata/version").InnerText;
                Variables.Created = xml.DocumentElement.SelectSingleNode("/metadata/created").InnerText;
                Variables.Modified = xml.DocumentElement.SelectSingleNode("/metadata/modified").InnerText;
                Variables.Name = xml.DocumentElement.SelectSingleNode("/metadata/name").InnerText;
                Variables.Description = xml.DocumentElement.SelectSingleNode("/metadata/description").InnerText;


                xml.LoadXml(decoded.ElementAt(1));

                Variables.SaveOptionChar = Convert.ToInt32(xml.DocumentElement.SelectSingleNode("/saveoptions/characters").InnerText);
                Variables.SaveOptionLoc = Convert.ToInt32(xml.DocumentElement.SelectSingleNode("/saveoptions/locations").InnerText);
                Variables.customColors = Array.ConvertAll<string, int>(xml.DocumentElement.SelectSingleNode("/saveoptions/customcolors").InnerText.Split(','), int.Parse);
            }

            if (Variables.SaveOptionChar == 1)
            {
                dir = Path.Combine(Directory.GetParent(fileToOpen).ToString(), "Savedata", "Characters.dat");
                Variables.characterPictures = Path.Combine(Variables.currentFolder, "Picturedata");
            }
            else if (Variables.SaveOptionChar == 2)
            {
                dir = Path.Combine(Variables.VSL, "GlobalSavedata", "Characters.dat");
                Variables.characterPictures = Path.Combine(Variables.VSL, "GlobalSavedata", "Picturedata");
            }
            if (Variables.SaveOptionLoc == 1)
            {
                Variables.locationPictures = Path.Combine(Variables.currentFolder, "Picturedata");
            }
            else if (Variables.SaveOptionLoc == 2)
            {
                Variables.locationPictures = Path.Combine(Variables.VSL, "GlobalSavedata", "Picturedata");

            }

            if (File.Exists(dir))
            {
                Console.WriteLine(dir);
                using (StreamReader sr = new StreamReader(dir))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        decoded.Add(Program.Decode(line));
                    }

                    xml.LoadXml(decoded.ElementAt(2));
                    Console.WriteLine(xml.InnerXml);
                    XmlNodeList xmllist = xml.SelectNodes("/Characterfields/characterfield");
                    foreach (XmlNode node in xmllist)
                    {
                        Variables.CharacterFields.Add("<characterfield>" + node.InnerXml + "</characterfield>");
                    }
                }
            }
        }
    }
}
