using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VisualStoryline());

            if (!Directory.Exists(Path.Combine(Variables.VSL, "GlobalSavedata")))
            {
                DirectoryInfo di = Directory.CreateDirectory(Path.Combine(Variables.VSL, "GlobalSavedata"));
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (Properties.Settings.Default.Projectpath == "")
                Properties.Settings.Default.Projectpath = Variables.VSL;
            if (Properties.Settings.Default.Picturepath == "")
                Properties.Settings.Default.Picturepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static string Encode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(inputBytes);
        }

        public static string Decode(string input)
        {
            var encodedBytes = System.Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(encodedBytes);
        }

        public static void FlushVars()
        {
            Variables.currentPath = default(string);
            Variables.currentFolder = default(string);
            Variables.currentFile = default(string);
            Variables.characterPictures = default(string);
            Variables.locationPictures = default(string);
            Variables.Version = default(string);
            Variables.Created = default(string);
            Variables.Modified = default(string);
            Variables.Name = default(string);
            Variables.Description = default(string);
            Variables.SaveOptionChar = default(int);
            Variables.SaveOptionLoc = default(int);
            Variables.customColors = default(int[]);
            Variables.Characters.Clear();
            Variables.Locations.Clear();
            Variables.Strands.Clear();
            Variables.Ideas.Clear();
            Variables.Quests.Clear();
            Variables.Relations.Clear();
            Variables.Conditions.Clear();
            Variables.CharacterFields.Clear();

        }

        //TODO: write comments
        //TODO: try loading
        //TODO: tutorial
    }

    class Variables
    {
        //Main save-file
        /// <summary>
        /// Program-Folder
        /// </summary>
        public static string VSL = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Storyline");
        /// <summary>
        /// Current file paths
        /// </summary>
        public static string currentPath, currentFolder, currentFile, characterPictures, locationPictures;
        /// <summary>
        /// Metadata
        /// </summary>
        public static string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        /// Metadata
        /// </summary>
        public static string Created, Modified, Name, Description;
        /// <summary>
        /// Main save-file
        /// </summary>
        public static int SaveOptionChar, SaveOptionLoc;
        /// <summary>
        /// Main save-file
        /// </summary>
        public static int[] customColors = new int[16] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        
        //Secondary save-files
        /// <summary>
        /// Secondary save-files
        /// </summary>
        public static List<string> Characters = new List<string>(), Locations = new List<string>(), Strands = new List<string>(), Ideas = new List<string>(), Quests = new List<string>(), Relations = new List<string>(), Conditions = new List<string>();
        /// <summary>
        /// Character save-file
        /// </summary>
        public static List<string> CharacterFields = new List<string>();
    }
}
