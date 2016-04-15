using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline.Characterfield_options
{
    public partial class RichTextboxoptions : Form
    {
        private int ID;
        InstalledFontCollection fontsCollection = new InstalledFontCollection();

        public RichTextboxoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            ID = ID_Parent;
            FontFamily[] fontFamilies = fontsCollection.Families;
            foreach (FontFamily font in fontFamilies)
            {
                font_box.Items.Add(font.Name);
            }
            try
            {
                XmlDocument option = new XmlDocument();
                option.LoadXml(options);
                bool fontExists = false;
                foreach (FontFamily fontfamily in fontFamilies)
                {
                    if (fontfamily.Name.ToString() == option.DocumentElement.SelectSingleNode("/options/font").InnerText)
                        fontExists = true;
                }
                if (option.DocumentElement.SelectSingleNode("/options/font") != null && fontExists)
                    font_box.SelectedItem = option.DocumentElement.SelectSingleNode("/options/font").InnerText;
                else
                {
                    font_box.SelectedItem = "Arial";
                    ErrorMessages.FontMissing(option.DocumentElement.SelectSingleNode("/options/font").InnerText);
                    ErrorMessages.WarningTitle();
                    DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (option.DocumentElement.SelectSingleNode("/options/color") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/color").InnerText == "yes")
                        color_check.Checked = true;
                }
                else { color_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/size") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/size").InnerText == "yes")
                        fontsize_check.Checked = true;
                }
                else { fontsize_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/bold") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/bold").InnerText == "yes")
                        bold_check.Checked = true;
                }
                else { bold_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/italic") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/italic").InnerText == "yes")
                        italic_check.Checked = true;
                }
                else { italic_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/underline") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/underline").InnerText == "yes")
                        underlined_check.Checked = true;
                }
                else { underlined_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/bunumb") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/bunumb").InnerText == "yes")
                        bunumb_check.Checked = true;
                }
                else { bunumb_check.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/required") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/required").InnerText == "yes")
                        required_check.Checked = true;
                }
                else { required_check.Checked = false; }
                if (option.DocumentElement.SelectSingleNode("/options/align") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/align").InnerText.Contains("left") == true)
                        align_left.Checked = true;
                    if (option.DocumentElement.SelectSingleNode("/options/align").InnerText.Contains("center") == true)
                        align_center.Checked = true;
                    if (option.DocumentElement.SelectSingleNode("/options/align").InnerText.Contains("right") == true)
                        align_right.Checked = true;
                    if (option.DocumentElement.SelectSingleNode("/options/align").InnerText.Contains("justify") == true)
                        align_justify.Checked = true;
                }
                else { align_left.Checked = true; align_center.Checked = true; align_right.Checked = true; align_justify.Checked = true; }
            }
            catch(Exception)
            {
                ErrorMessages.SomethingWentWrongOptions();
                ErrorMessages.ErrorTitle();
                DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                font_box.SelectedItem = "Arial";
                color_check.Checked = true;
                fontsize_check.Checked = true;
                bold_check.Checked = true;
                italic_check.Checked = true;
                underlined_check.Checked = true;
                bunumb_check.Checked = true;
                required_check.Checked = false;
                align_left.Checked = true;
                align_center.Checked = true;
                align_right.Checked = true;
                align_justify.Checked = true;
            }
        }

        private void FrameEvent(object sender, EventArgs e)
        {
            FontFamily[] fontFamilies = fontsCollection.Families;
            CheckBox[] Align = new CheckBox[] { align_left, align_center, align_right, align_justify };
            bool ischecked = false;
            foreach(CheckBox check in Align)
            {
                if (check.Checked == true)
                    ischecked = true;
            }
            bool fontExists = false;
            foreach(Object item in font_box.Items)
            {
                if (item.ToString().ToLower() == font_box.Text.ToLower())
                    fontExists = true;
            }
            if (font_box.Text != "" && fontExists == true && ischecked == true)
            {
                OK.Enabled = true;
            }
            else { OK.Enabled = false; }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string fontset = font_box.Text;
            string colorset = "no";
            if (color_check.Checked)
                colorset = "yes";
            string sizeset = "no";
            if (fontsize_check.Checked)
                sizeset = "yes";
            string boldset = "no";
            if (bold_check.Checked)
                boldset = "yes";
            string italicset = "no";
            if (italic_check.Checked)
                italicset = "yes";
            string underlineset = "no";
            if (underlined_check.Checked)
                underlineset = "yes";
            string bunumbset = "no";
            if (bunumb_check.Checked)
                bunumbset = "yes";
            string requiredset = "no";
            if (required_check.Checked)
                requiredset = "yes";
            string alignset = "";
            if (align_left.Checked)
                alignset = "left;";
            if (align_center.Checked)
                alignset += "center;";
            if (align_right.Checked)
                alignset += "right;";
            if (align_justify.Checked)
                alignset += "justify;";

            string newoptions;
            newoptions = "<options><font>" + fontset + "</font><color>" + colorset + "</color><size>" + sizeset + "</size><bold>" + boldset + "</bold><italic>" + italicset + "</italic><underline>" + underlineset + "</underline><bunumb>" + bunumbset + "</bunumb><required>" + requiredset + "</required><align>" + alignset + "</align></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "Richtext";
            EditCharacterFields.grabOptions = newoptions;

            this.Dispose();
        }
    }
}
