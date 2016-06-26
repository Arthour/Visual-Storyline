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
    public partial class EditLocations : Form
    {
        private int counter = -1;
        private int distance = 170;
        private List<string> locationsTemp = new List<string>();

        public EditLocations()
        {
            InitializeComponent();
            locationsTemp = Variables.Locations;
            if (Variables.Locations.Count != 0)
            {
                foreach (string item in Variables.Locations)
                {
                    counter++;
                    Locationfield field = new Locationfield(item);
                    field.Top = counter * distance;
                    locationPanel.Controls.Add(field);
                    field.update += new EventHandler(update);
                }
            }
        }

        private void update(object sender, EventArgs e)
        {
            bool replaced = false;
            XmlDocument edited = new XmlDocument();
            edited.LoadXml((string)sender);
            foreach(string item in locationsTemp)
            {
                XmlDocument old = new XmlDocument();
                old.LoadXml(item);
                if (old.DocumentElement.SelectSingleNode("/location/guid").InnerText == edited.DocumentElement.SelectSingleNode("/location/guid").InnerText)
                {
                    int index = 0;
                    locationsTemp.Insert(index, (string)sender);
                    locationsTemp.RemoveAt(index);
                    //TODO: replace listitem
                    replaced = true;
                }
            }
            if (!replaced)
                locationsTemp.Add((string)sender);
        }

        private void addLocation_Click(object sender, EventArgs e)
        {
            AddLocation addloc = new AddLocation(false, true);
            addloc.ShowDialog();
        }
    }
}


//TODO: compact mode?