using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline.Characters.Characterfield_options
{
    public partial class Pictureoptions : Form
    {
        private int ID;
        internal int heightVal, widthVal;
        internal string unitVar;

        public Pictureoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            ID = ID_Parent;

            using (Graphics g = this.CreateGraphics())
            {
                Values.dpix = g.DpiX;
                Values.dpiy = g.DpiY;
            }

            try
            {
                XmlDocument option = new XmlDocument();
                option.LoadXml(options);
                if (option.DocumentElement.SelectSingleNode("/options/fileformat") != null)
                {
                    XmlNode node = option.SelectSingleNode("/options/fileformat");
                    if (node.InnerText.Contains("jpg"))
                        jpg.Checked = true;
                    if (node.InnerText.Contains("png"))
                        png.Checked = true;
                    if (node.InnerText.Contains("gif"))
                        gif.Checked = true;
                    if (node.InnerText.Contains("bmp"))
                        bmp.Checked = true;
                    if (node.InnerText.Contains("wmf"))
                        wmf.Checked = true;
                }
                else { jpg.Checked = true; png.Checked = true; gif.Checked = true; bmp.Checked = true; wmf.Checked = true; }
                if (option.DocumentElement.SelectSingleNode("/options/width") != null)
                {
                    widthVal = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/width").InnerText);
                }
                else { widthVal = 120; }
                if (option.DocumentElement.SelectSingleNode("/options/height") != null)
                {
                    heightVal = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/height").InnerText);
                }
                else { heightVal = 120; }
                if (option.DocumentElement.SelectSingleNode("/options/unit") != null)
                {
                    unit.SelectedItem = option.DocumentElement.SelectSingleNode("/options/unit").InnerText;
                }
                else { unit.SelectedIndex = 0; }
                if (option.DocumentElement.SelectSingleNode("/options/dpm") != null)
                {
                    dpmode.SelectedIndex = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/dpm").InnerText);
                }
                else { dpmode.SelectedIndex = 0; }
            }
                catch (Exception)
                {
                    ErrorMessages.SomethingWentWrongOptions();
                    ErrorMessages.ErrorTitle();
                    DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jpg.Checked = true;
                    png.Checked = true;
                    gif.Checked = true;
                    bmp.Checked = true;
                    wmf.Checked = true;
                    unit.SelectedIndex = 0;
                    widthVal = 120;
                    heightVal = 120;
                    dpmode.SelectedIndex = 0;
                }
            Values.get(this);
            CheckOK();
        }

        private void CheckOK()
        {
            CheckBox[] checkbox = new CheckBox[] { jpg, png, gif, bmp, wmf };
            bool ischecked = false;
            foreach (CheckBox check in checkbox)
            {
                if (check.Checked == true)
                    ischecked = true;
            }

            if (ischecked && width.Text != "" && height.Text != "")
                OK.Enabled = true;
            else
                OK.Enabled = false;
        }

        private void UnitChanged(object sender, EventArgs e)
        {
            unitVar = unit.Text;
            Values.get(this);
        }

        private void CheckSelection(object sender, EventArgs e)
        {
            CheckOK();
        }

        private void CheckText(object sender, EventArgs e)
        {
            if (width.Text.StartsWith(".") || width.Text.StartsWith(","))
            {
                width.Text = "0" + width.Text;
                width.SelectionStart = width.Text.Length - 1;
            }
            if (height.Text.StartsWith(".") || height.Text.StartsWith(","))
            {
                height.Text = "0" + height.Text;
                height.SelectionStart = height.Text.Length - 1;
            }

                CheckOK();
            Values.set(this);
        }

        private void KeyHandle(object sender, KeyPressEventArgs e)
        {
            if(unitVar == "px")
            {
                Regex regex = new Regex(@"\d|[\b]");
                e.Handled = !(regex.IsMatch(e.KeyChar.ToString()));
            }
            else if (unitVar == "in" || unitVar == "cm" || unitVar == "mm")
            {
                Regex regex = new Regex(@"\d|[.,]|[\b]");
                e.Handled = !(regex.IsMatch(e.KeyChar.ToString()));
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string allowedset = "";
            if (jpg.Checked)
                allowedset = "jpg;";
            if (png.Checked)
                allowedset += "png;";
            if (gif.Checked)
                allowedset += "gif;";
            if (bmp.Checked)
                allowedset += "bmp;";
            if (wmf.Checked)
                allowedset += "wmf;";
            string newoptions;
            newoptions = "<options><allowed>" + allowedset + "</allowed><width>" + widthVal + "</width><height>" + heightVal + "</height><unit>" + unitVar + "</unit><dpm>" + dpmode.SelectedIndex + "</dpm></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "Picture";
            EditCharacterFields.grabOptions = newoptions;
            this.Dispose();
        }
    }
    public class Values
    {
        internal static float pxh, pxw;
        internal static float dpix, dpiy;
        private static float inh, inw;
        private static float cmh, cmw;
        private static float mmh, mmw;

        internal static void calc(object sender)
        {
            Pictureoptions p = (Pictureoptions)sender;
            pxh = p.heightVal;
            pxw = p.widthVal;

            inh = pxh / dpix;
            inw = pxw / dpiy;

            cmh = inh * 2.54f;
            cmw = inw * 2.54f;

            mmh = cmh * 10;
            mmw = cmw * 10;
        }
        internal static void set(object sender)
        {
            Pictureoptions p = (Pictureoptions)sender;
            switch (p.unitVar)
            {
                case "px":
                    if (p.width.Text != "")
                        p.widthVal =  (int) Math.Round(Convert.ToSingle(p.width.Text), 0);
                    if (p.height.Text != "")
                        p.heightVal = (int) Math.Round(Convert.ToSingle(p.height.Text), 0);
                    break;
                case "in":
                    if (p.width.Text != "")
                        p.widthVal = (int) Math.Round(Convert.ToSingle(p.width.Text) * dpiy, 0);
                    if (p.height.Text != "")
                        p.heightVal = (int) Math.Round(Convert.ToSingle(p.height.Text) * dpix, 0);
                    break;
                case "cm":
                    if (p.width.Text != "")
                        p.widthVal = (int) Math.Round(Convert.ToSingle(p.width.Text) * dpiy / 2.54f, 0);
                    if (p.height.Text != "")
                        p.heightVal = (int) Math.Round(Convert.ToSingle(p.height.Text) * dpix / 2.54f, 0);
                    break;
                case "mm":
                    if (p.width.Text != "")
                        p.widthVal = (int) Math.Round(Convert.ToSingle(p.width.Text) * dpiy / 25.4f, 0);
                    if (p.height.Text != "")
                        p.heightVal = (int) Math.Round(Convert.ToSingle(p.height.Text) * dpix / 25.4f, 0);
                    break;
            }
        }
        internal static void get(object sender)
        {
            calc(sender);
            Pictureoptions p = (Pictureoptions)sender;
            switch (p.unitVar)
            {
                case "px":
                    p.width.Text = pxw.ToString();
                    p.height.Text = pxh.ToString();
                    break;
                case "in":
                    p.width.Text = Math.Round((decimal)inw, 2).ToString();
                    p.height.Text = Math.Round((decimal)inh, 2).ToString();
                    break;
                case "cm":
                    p.width.Text = Math.Round((decimal)cmw, 2).ToString();
                    p.height.Text = Math.Round((decimal)cmh, 2).ToString();
                    break;
                case "mm":
                    p.width.Text = Math.Round((decimal)mmw, 2).ToString();
                    p.height.Text = Math.Round((decimal)mmh, 2).ToString();
                    break;
            }
        }
    }
}