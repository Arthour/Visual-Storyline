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

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

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
                Image pic = ImageFast.FromFile(Path.Combine(Variables.locationPictures, pictureName));
                picture.Image = pic;
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackColor = Color.Black;
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
            Variables.Locations.Add(locationset);
            if(viaEdit)
            {
                //TODO: refresh edit
            }

            Console.WriteLine(locationset);

            Dispose();
        }

        private void selpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Properties.Settings.Default.Picturepath;
            openFileDialog.Filter = "All pictures|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|JPG (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|TIFF (*.tiff)|*.tiff";
            openFileDialog.RestoreDirectory = false;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Variables.locationPictures))
                {
                    if (Directory.GetFiles(Variables.locationPictures) != null)
                    {
                        Image selPic = ImageFast.FromFile(openFileDialog.FileName);
                        Bitmap selBM = new Bitmap(selPic);
                        try
                        {
                            string[] files = Directory.GetFiles(Variables.locationPictures);
                            foreach (string pic in files)
                            {
                                try
                                {
                                    Image curPic = ImageFast.FromFile(pic);
                                    Bitmap curBM = new Bitmap(curPic);

                                    if (selPic.Width == curPic.Width && selPic.Height == curPic.Height)
                                    {
                                        if (Compare(selBM, curBM))
                                        {
                                            picture.Image = curPic;
                                            picture.SizeMode = PictureBoxSizeMode.Zoom;
                                            picture.BackColor = Color.Black;
                                            pictureName = Path.GetFileName(pic);

                                            Properties.Settings.Default.Picturepath = Directory.GetParent(openFileDialog.FileName).ToString();
                                            Properties.Settings.Default.Save();

                                            openFileDialog.Dispose();

                                            watch.Stop();
                                            var elapsedMs2 = watch.ElapsedMilliseconds;
                                            Console.WriteLine(elapsedMs2);

                                            return;
                                        }
                                    }
                                }
                                catch(Exception)
                                { }
                            }
                        }
                        catch(UnauthorizedAccessException)
                        { }
                        catch(Exception)
                        { }
                    }

                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(Variables.currentFolder, "Picturedata"));
                }

                picNotExisting(openFileDialog.FileName);

                Properties.Settings.Default.Picturepath = Directory.GetParent(openFileDialog.FileName).ToString();
                Properties.Settings.Default.Save();

                openFileDialog.Dispose();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
            }
            else
            {
                return;
            }
        }

        private static bool Compare (Bitmap b1, Bitmap b2)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bd1scan0 = bd1.Scan0;
                IntPtr bd2scan0 = bd2.Scan0;

                int stride = bd1.Stride;
                int len = stride * b1.Height;

                return memcmp(bd1scan0, bd2scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }

        private void picNotExisting(string sourcePath)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            File.Copy(sourcePath, Path.Combine(Variables.locationPictures, GuidString));

            Image pic = ImageFast.FromFile(Path.Combine(Variables.locationPictures, GuidString));
            picture.Image = pic;
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.BackColor = Color.Black;
            pictureName = GuidString;
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
