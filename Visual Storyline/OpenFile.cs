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
        private static List<string> decoded = new List<string>();

        public static void OpenDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Variables.VSL;
            openFileDialog.Filter = "Visual Storyline-Files (*.vsl)|*.vsl";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileToOpen = openFileDialog.FileName;
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
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(decoded.ElementAt(0));
                Console.WriteLine(decoded.ElementAt(0));

                Variables.Created = xml.DocumentElement.SelectSingleNode("/metadata/created").InnerText;
                Console.WriteLine(Variables.Created);
                Variables.Modified = xml.DocumentElement.SelectSingleNode("/metadata/modified").InnerText;
                Console.WriteLine(Variables.Modified);
                Variables.Name = xml.DocumentElement.SelectSingleNode("/metadata/name").InnerText;
                Console.WriteLine(Variables.Name);
                Variables.Description = xml.DocumentElement.SelectSingleNode("/metadata/description").InnerText;
                Console.WriteLine(Variables.Description);
                Variables.Programversion = xml.DocumentElement.SelectSingleNode("/metadata/version").InnerText;
                Console.WriteLine(Variables.Programversion);

                xml.LoadXml(decoded.ElementAt(1));

                Variables.SaveOptionChar = xml.DocumentElement.SelectSingleNode("/saveoptions/characters").InnerText;
                Console.WriteLine(Variables.SaveOptionChar);
                Variables.SaveOptionLoc = xml.DocumentElement.SelectSingleNode("/saveoptions/locations").InnerText;
                Console.WriteLine(Variables.SaveOptionLoc);
            }
        }
    }
}
