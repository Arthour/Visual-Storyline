using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline.Locations
{
    public partial class ListLocations : Form
    {
        private AddLocation Parentform;
        private List<string> guids = new List<string>();

        public ListLocations(object sender, string oldoptions = "")
        {
            InitializeComponent();

            Parentform = (AddLocation)sender;

            if(Variables.Locations.Count > 0)
            {
                foreach (string item in Variables.Locations)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(item);

                    XmlDocument old = new XmlDocument();
                    if (oldoptions != "")
                        old.LoadXml(oldoptions);

                    if (doc.DocumentElement.ParentNode.InnerXml != oldoptions)
                    {
                        if(oldoptions != "")
                        {
                            if (doc.DocumentElement.SelectSingleNode("/location/guid").InnerText != old.DocumentElement.SelectSingleNode("/location/linked").InnerText)
                            {
                                locations.Items.Add(doc.DocumentElement.SelectSingleNode("/location/name").InnerText);
                                guids.Add(doc.DocumentElement.SelectSingleNode("/location/guid").InnerText);
                            }
                        }
                        else
                        {
                            locations.Items.Add(doc.DocumentElement.SelectSingleNode("/location/name").InnerText);
                            guids.Add(doc.DocumentElement.SelectSingleNode("/location/guid").InnerText);
                        }
                    }
                }
                locations.SelectedIndex = 0;
                OK.Enabled = true;
            }
            else { OK.Enabled = false; }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Parentform.GrabSelection(guids[locations.SelectedIndex]);
            Dispose();
        }
    }
}
