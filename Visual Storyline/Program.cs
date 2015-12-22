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
        public static string VSL = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Storyline");
        public static string currentPath, currentFolder, currentFile;
        public static string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string Created, Modified, Name, Description, Programversion;
        public static string SaveOptionChar, SaveOptionLoc;
        public static List<string> Characters, Locations, Strands, Ideas, Quests, Relations, Conditions;
    }


}
