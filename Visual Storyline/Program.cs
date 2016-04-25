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
        public static string currentPath, currentFolder, currentFile;
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
        public static List<string> Characters, Locations, Strands, Ideas, Quests, Relations, Conditions;
        /// <summary>
        /// Character save-file
        /// </summary>
        public static List<string> CharacterFields = new List<string>();
    }
}
