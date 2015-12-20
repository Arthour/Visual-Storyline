using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VisualStoryline());
        }
    }

    class Variables
    {
        public static string VSL = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Storyline");
        public static string currentPath, currentFolder, currentFile;
        public static string ProgramInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
    }
}
