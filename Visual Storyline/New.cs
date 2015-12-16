using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Visual_Storyline
{
    public partial class New : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public New()
        {
            InitializeComponent();
            ProjectLocation.Text = Variables.VSL;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally, locboth };
                RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally, charboth };

                if (ProjectName.Text != "" && ProjectLocation.Text != "" && LocButtons.Any() && CharButtons.Any())
                {
                OK.Enabled = true;
                }
            }
        }

        private void New_Load(object sender, EventArgs e)
        {

        }

        private void ProjectName_KeyInput(object sender, KeyPressEventArgs e)
        {
            var StandardUnicode = new Regex(@"^[^a-zA-Z0-9_\b]*");
            if (StandardUnicode.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void explorer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerdialog = new FolderBrowserDialog();
            explorerdialog.SelectedPath = Variables.VSL;
            if (explorerdialog.ShowDialog() == DialogResult.OK)
            {
                ProjectLocation.Text = explorerdialog.SelectedPath;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void propertyChanged(object sender, EventArgs e)
        {
            RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally, locboth };
            RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally, charboth };
            var StandardUnicode = new Regex(@" ^[a-zA-Z0-9_\b]*");
            if (StandardUnicode.IsMatch(ProjectName.Text) && ProjectLocation.Text != "" && LocButtons.Any() && CharButtons.Any())
            {
                OK.Enabled = true;
            }
            else { OK.Enabled = false; };
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var StandardUnicode = new Regex(@"^[a-zA-Z0-9_\b]+");
            if (StandardUnicode.IsMatch(ProjectName.Text))
            {

            }
        }
    }
}