using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (!System.IO.File.Exists(Variables.VSL))
            {
                System.IO.Directory.CreateDirectory(Variables.VSL);
            }
            New newproject = new New();
            newproject.ShowDialog();
        }

        private void addCondition_Click(object sender, EventArgs e)
        {

        }
    }
}
