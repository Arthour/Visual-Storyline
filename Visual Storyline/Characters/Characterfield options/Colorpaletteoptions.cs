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

namespace Visual_Storyline.Characters.Characterfield_options
{
    public partial class Colorpaletteoptions : Form
    {
        private int ID;
        private int defcol;

        public Colorpaletteoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            ID = ID_Parent;

            try
            {
                XmlDocument option = new XmlDocument();
                option.LoadXml(options);
                if (option.DocumentElement.SelectSingleNode("/options/textcolor") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/textcolor").InnerText == "yes")
                    { textcolor.Checked = true; }
                }
                else { textcolor.Checked = false; }
                if (option.DocumentElement.SelectSingleNode("/options/bgcolor") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/bgcolor").InnerText == "yes")
                    { backgroundcolor.Checked = true; }
                }
                else { backgroundcolor.Checked = false; }
                if (option.DocumentElement.SelectSingleNode("/options/colorbox") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/colorbox").InnerText == "yes")
                    { colorbox.Checked = true; }
                }
                else { colorbox.Checked = false; }
                if (option.DocumentElement.SelectSingleNode("/options/defcol") != null)
                {
                    defcol = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/defcol").InnerText);
                }
                else { defcol = -16777216; }
            }
            catch (Exception)
            {
                ErrorMessages.SomethingWentWrongOptions();
                ErrorMessages.ErrorTitle();
                DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textcolor.Checked = false;
                backgroundcolor.Checked = false;
                colorbox.Checked = false;
            }
        }

        private void selectDefault_Click(object sender, EventArgs e)
        {
            DefaultColor.Color = Color.FromArgb(defcol);
            DefaultColor.CustomColors = Variables.customColors;
            if (DefaultColor.ShowDialog() == DialogResult.OK)
            {
                defcol = DefaultColor.Color.ToArgb();
                Variables.customColors = DefaultColor.CustomColors;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string textcolorset = "no";
            if (textcolor.Checked)
                textcolorset = "yes";
            string bgcolorset = "no";
            if (backgroundcolor.Checked)
                bgcolorset = "yes";
            string colorboxset = "no";
            if (colorbox.Checked)
                colorboxset = "yes";

            string newoptions;
            newoptions = "<options><textcolor>" + textcolorset + "</textcolor><bgcolor>" + bgcolorset + "</bgcolor><colorbox>" + colorboxset + "</colorbox><defcol>" + defcol + "</defcol></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "Colorpalette";
            EditCharacterFields.grabOptions = newoptions;
            this.Dispose();
        }

        private void CheckChecked(object sender, EventArgs e)
        {
            CheckBox[] Color = new CheckBox[] { textcolor, backgroundcolor, colorbox };
            bool ischecked = false;
            foreach (CheckBox check in Color)
            {
                if (check.Checked == true)
                    ischecked = true;
            }
            if (ischecked)
            { OK.Enabled = true; }
            else
            { OK.Enabled = false; }
        }
    }
}
