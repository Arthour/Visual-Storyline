using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Storyline
{
    class SaveFile
    {
        private static string Metadata;
        private static string Main;
        private static string CLoc;
        private static string LLoc;

        //Projectfile
        private static string ProjectFolder = Variables.currentFolder;
        private static string ProjectFile = Variables.currentFile;
        private static string Version = Variables.Version;
        private static string Created = Variables.Created;
        private static string Modified = System.DateTime.UtcNow.ToString();
        private static string Name = Variables.Name;
        private static string Description = Variables.Description;
        private static int SOC = Variables.SaveOptionChar;
        private static int SOL = Variables.SaveOptionLoc;
        private static string Colors;

        //Characters
        private static List<string> Characterfields = new List<string>(Variables.CharacterFields);

        internal static void Save()
        {
            Colors = "";
            foreach (int value in Variables.customColors)
            {
                Colors += value.ToString();
                Colors += ",";
            }
            Colors = Colors.Remove(Colors.Length - 1);

            Metadata = "<metadata><version>" + Version + "</version><created>" + Created + "</created><modified>" + Modified + "</modified><name>" + Name + "</name><description>" + Description + "</description></metadata>";
            Main = "<saveoptions><characters>" + SOC + "</characters><locations>" + SOL + "</locations><customcolors>" + Colors + "</customcolors></saveoptions>";

            using (StreamWriter sw = new StreamWriter(ProjectFile, false))
            {
                sw.WriteLine(Program.Encode(Metadata));
                sw.WriteLine(Program.Encode(Main));
                sw.Close();
            }

            if (SOC == 1)
            {
                if (!Directory.Exists(Path.Combine(ProjectFolder, "Savedata")))
                    Directory.CreateDirectory(Path.Combine(ProjectFolder, "Savedata"));
                CLoc = Path.Combine(ProjectFolder, "Savedata", "Characters.dat");
            }
            else if (SOC == 2)
            {
                if (!Directory.Exists(Path.Combine(Variables.VSL, "GlobalSavedata")))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Path.Combine(Variables.VSL, "GlobalSavedata"));
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                CLoc = Path.Combine(Variables.VSL, "GlobalSavedata", "Characters.dat");
            }
            using (StreamWriter sw = new StreamWriter(CLoc, false))
            {
                string Cfs = "<Characterfields>";
                if (Characterfields.Count != 0)
                {
                    foreach (string item in Characterfields)
                        Cfs += item;
                }
                Cfs += "</Characterfields>";
                sw.WriteLine(Program.Encode(Cfs));
                sw.Close();
            }
        }
    }
}

                    //if (LocSave == 1)
                    //{
                    //    if (!Directory.Exists(Path.Combine(ProjectFolder, "Savedata")))
                    //    {
                    //        Directory.CreateDirectory(Path.Combine(ProjectFolder, "Savedata"));
                    //    }
                    //    File.Create(Path.Combine(ProjectFolder, "Savedata", "Locations.dat"));
                    //}
                    //if (LocSave == 2)
                    //{
                    //    if (!Directory.Exists(Path.Combine(Variables.VSL, "$GlobalSavedata")))
                    //    {
                    //        Directory.CreateDirectory(Path.Combine(Variables.VSL, "$GlobalSavedata"));
                    //    }
                    //    if (!File.Exists(Path.Combine(Variables.VSL, "$GlobalSavedata", "Locations.dat")))
                    //    {
                    //        File.Create(Path.Combine(Variables.VSL, "$GlobalSavedata", "Locations.dat"));
                    //    }

