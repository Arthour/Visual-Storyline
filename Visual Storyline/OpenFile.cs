using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline
{
    class OpenFile
    {
        private static string fileToOpen;

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

            using (StreamReader sr = new StreamReader(fileToOpen))
            {

            }
        }
    }
}
