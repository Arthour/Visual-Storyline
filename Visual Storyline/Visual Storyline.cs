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

namespace Visual_Storyline
{
    public partial class VisualStoryline : Form
    {
        public VisualStoryline()
        {
            InitializeComponent();
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

        private void VisualStoryline_Load(object sender, EventArgs e)
        {

        }
    }
}
