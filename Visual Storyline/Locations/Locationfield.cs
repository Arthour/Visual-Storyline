using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Visual_Storyline.Locations
{
    public partial class Locationfield : UserControl
    {
        string options;
        public event EventHandler update;


        public Locationfield(string options)
        {
            InitializeComponent();

            this.options = options;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(options);

            locname.Text = doc.DocumentElement.SelectSingleNode("/location/name").InnerText;
            description.Text = doc.DocumentElement.SelectSingleNode("/location/description").InnerText;
            if (Guid.Parse(doc.DocumentElement.SelectSingleNode("/location/linked").InnerText) != Guid.Empty)
            {
                XmlDocument par = new XmlDocument();
                foreach (string item in Variables.Locations)
                {
                    par.LoadXml(item);
                    if (par.DocumentElement.SelectSingleNode("/location/guid").InnerText == doc.DocumentElement.SelectSingleNode("/location/linked").InnerText)
                        partof.Text = par.DocumentElement.SelectSingleNode("/location/name").InnerText;
                }
            }
            else if(doc.DocumentElement.SelectSingleNode("/location/parent").InnerText != "")
                partof.Text = doc.DocumentElement.SelectSingleNode("/location/parent").InnerText;
            else
            {
                partof_label.Visible = false;
                partof.Visible = false;
            }
            if(doc.DocumentElement.SelectSingleNode("/location/picture").InnerText != "")
            {
                Image pic = ImageFast.FromFile(Path.Combine(Variables.locationPictures, doc.DocumentElement.SelectSingleNode("/location/picture").InnerText));
                picture.Image = pic;
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackColor = Color.Black;
            }


        }

        private void edit_Click(object sender, EventArgs e)
        {
            AddLocation loc = new AddLocation(true, true, options);
            loc.update += new EventHandler(updateField);

        }

        private void updateField(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml((string)sender);

            locname.Text = doc.DocumentElement.SelectSingleNode("/location/name").InnerText;
            description.Text = doc.DocumentElement.SelectSingleNode("/location/description").InnerText;
            if (Guid.Parse(doc.DocumentElement.SelectSingleNode("/location/linked").InnerText) != Guid.Empty)
            {
                XmlDocument par = new XmlDocument();
                foreach (string item in Variables.Locations)
                {
                    par.LoadXml(item);
                    if (par.DocumentElement.SelectSingleNode("/location/guid").InnerText == doc.DocumentElement.SelectSingleNode("/location/linked").InnerText)
                        partof.Text = par.DocumentElement.SelectSingleNode("/location/name").InnerText;
                }
            }
            else if (doc.DocumentElement.SelectSingleNode("/location/parent").InnerText != "")
                partof.Text = doc.DocumentElement.SelectSingleNode("/location/parent").InnerText;
            else
            {
                partof_label.Visible = false;
                partof.Visible = false;
            }
            if (doc.DocumentElement.SelectSingleNode("/location/picture").InnerText != "")
            {
                Image pic = ImageFast.FromFile(Path.Combine(Variables.locationPictures, doc.DocumentElement.SelectSingleNode("/location/picture").InnerText));
                picture.Image = pic;
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackColor = Color.Black;
            }

            update?.Invoke(sender, e);
        }
    }
}
