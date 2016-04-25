using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline.Locations
{
    public partial class addLocation : Form
    {
        bool isEdit;
        string options;

        public addLocation(bool edit, string loadoptions = "")
        {
            InitializeComponent();
            options = loadoptions;

            if(edit)
            { LoadLoc(); }
        }

        private void LoadLoc()
        {
            throw new NotImplementedException();
        }

        private void NameChanged(object sender, EventArgs e)
        {
            if (name.Text != "")
                OK.Enabled = true;
            else
                OK.Enabled = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {

            if(isEdit)
            {
                //transfer string to edit
                //or
                //add to list & refresh edit
            }
            else
            {
                //add to final list
            }
            Dispose();
        }

        private void selpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Properties.Settings.Default.Picturepath;
            openFileDialog.Filter = "All (*.jpg, *.jpeg, *.png, *.gif, *.bmp, *.wmf)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.wmf|JPG (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|WMF (*.wmf)|*.wmf";
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //check if image is available from resources (also create folder if not existing), else copy
                Properties.Settings.Default.Picturepath = Directory.GetParent(openFileDialog.FileName).ToString();
                Properties.Settings.Default.Save();
                openFileDialog.Dispose();
            }
            else
            {
                return;
            }
        }
    }
}
