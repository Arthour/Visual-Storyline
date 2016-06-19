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
using Visual_Storyline.Locations;

namespace Visual_Storyline
{
    public partial class VisualStoryline : Form
    {
        int neededSize;

        public VisualStoryline()
        {
            InitializeComponent();
            neededSize = New.Width + Save.Width + Open.Width + Export.Width + toolStripSeparator1.Width + Characters.Width + Locations.Width + Strands.Width + Chapters.Width + toolStripSeparator2.Width + Featurelist.Width + toolStripSeparator3.Width + addQuest.Width + addRelation.Width + addEvent.Width + Settings.Width + 20;
        }

        private void New_Click(object sender, EventArgs e)
        {
            //Create Dir if it does not already exist
            if (!Directory.Exists(Variables.VSL))
            {
                Directory.CreateDirectory(Variables.VSL);
            }
            New newproject = new New();
            newproject.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                //Create Dir if it does not already exist
                if (!Directory.Exists(Variables.VSL))
                {
                    Directory.CreateDirectory(Variables.VSL);
                }
                New newproject = new New();
                newproject.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                OpenFile.OpenDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void addCondition_Click(object sender, EventArgs e)
        {

        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFile.OpenDialog();
        }

        private void editFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCharacterFields editfields = new EditCharacterFields();
            editfields.ShowDialog();
        }

        private void Save_ButtonClick(object sender, EventArgs e)
        {
            SaveFile.Save();
        }

        private void FormResized(object sender, EventArgs e)
        {

            Console.WriteLine(neededSize);
            Console.WriteLine(ClientSize.Width);
            if (neededSize > this.ClientSize.Width)
            {
                New.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Open.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Export.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Characters.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Locations.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Strands.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Chapters.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Featurelist.DisplayStyle = ToolStripItemDisplayStyle.Image;
                addQuest.DisplayStyle = ToolStripItemDisplayStyle.Image;
                addRelation.DisplayStyle = ToolStripItemDisplayStyle.Image;
                addEvent.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Settings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
            else if (neededSize <= this.ClientSize.Width)
            {
                New.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Save.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Open.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Export.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Characters.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Locations.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Strands.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Chapters.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Featurelist.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                addQuest.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                addRelation.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                addEvent.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Settings.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        private void addLoc_Click(object sender, EventArgs e)
        {
            AddLocation addloc = new AddLocation(false);
            addloc.ShowDialog();
        }
    }
}
