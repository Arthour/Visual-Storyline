﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline.Locations
{
    public partial class EditLocations : Form
    {
        public EditLocations()
        {
            InitializeComponent();
        }

        private void addLocation_Click(object sender, EventArgs e)
        {
            AddLocation addloc = new AddLocation(false, true);
            addloc.ShowDialog();
        }
    }
}
