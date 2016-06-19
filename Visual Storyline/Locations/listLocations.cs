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

                    if (doc.DocumentElement.ParentNode.InnerXml != oldoptions)
                    {
                        locations.Items.Add(doc.DocumentElement.SelectSingleNode("/location/name").InnerText);
                    }
                }
                locations.SelectedIndex = 0;
                OK.Enabled = true;
            }
            else { OK.Enabled = false; }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Parentform.GrabSelection(locations.SelectedItem.ToString());
            Dispose();
        }
    }
}
