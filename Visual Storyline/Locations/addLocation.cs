using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline.Locations
{
    public partial class AddLocation : Form
    {
        bool viaEdit;
        string options;
        string pictureName;
        Guid guid, linked;
        public event EventHandler update;

        public AddLocation(bool isEdit, bool viaEdit, string loadoptions = "")
        {
            InitializeComponent();
            options = loadoptions;
            this.viaEdit = viaEdit;

            if(isEdit)
                LoadLoc(); 
        }

        private void LoadLoc()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(options);

            guid = Guid.Parse(doc.DocumentElement.SelectSingleNode("/location/guid").InnerText);
            name.Text = doc.DocumentElement.SelectSingleNode("/location/name").InnerText;
            description.Text = doc.DocumentElement.SelectSingleNode("/location/description").InnerText;
            pictureName = doc.DocumentElement.SelectSingleNode("/location/picture").InnerText;
            parentLocation.Text = doc.DocumentElement.SelectSingleNode("/location/parent").InnerText;
            linked = Guid.Parse(doc.DocumentElement.SelectSingleNode("/location/linked").InnerText);


            if (pictureName != "")
            {
                ImageHandler.load(Variables.locationPictures, pictureName, picture);
            }
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
            if(guid == Guid.Empty)
                guid = Guid.NewGuid();
            string locationset = "<location><guid>" + guid + "</guid><name>" + name.Text + "</name><description>" + description.Text + "</description><picture>" + pictureName + "</picture><parent>" + parentLocation.Text + "</parent><linked>" + linked + "</linked></location>";

            if(!viaEdit)
                Variables.Locations.Add(locationset);
            if(viaEdit)
            {
                update?.Invoke(locationset, e);
            }

            Dispose();
        }

        private void selpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Properties.Settings.Default.Picturepath;
            openFileDialog.Filter = "All pictures|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|JPG (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|TIFF (*.tiff)|*.tiff";
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureName = ImageHandler.startComparison(Variables.locationPictures, openFileDialog.FileName, picture);
                Console.WriteLine(pictureName);
                Properties.Settings.Default.Picturepath = Directory.GetParent(openFileDialog.FileName).ToString();
                Properties.Settings.Default.Save();

                openFileDialog.Dispose();
            }
            else
            {
                return;
            }
        }

        private void selpar_Click(object sender, EventArgs e)
        {
            ListLocations lloc = new ListLocations(this, options);
            lloc.ShowDialog();
        }

        private void Keyboardentry(object sender, KeyPressEventArgs e)
        {
            linked = Guid.Empty;
        }

        internal void GrabSelection(string selectedLoc)
        {
            linked = Guid.Parse(selectedLoc);

            XmlDocument doc = new XmlDocument();
            foreach (string item in Variables.Locations)
            {
                doc.LoadXml(item);
                if (doc.DocumentElement.SelectSingleNode("/location/guid").InnerText == selectedLoc)
                    parentLocation.Text = doc.DocumentElement.SelectSingleNode("/location/name").InnerText;
            }
        }
    }
}
