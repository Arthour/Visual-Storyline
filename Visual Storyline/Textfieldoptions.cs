﻿using System;
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

namespace Visual_Storyline
{
    public partial class Textfieldoptions : Form
    {
        private int ID;
        private string currentoptions;

        public Textfieldoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            ID = ID_Parent;
            currentoptions = options;
            XmlDocument option = new XmlDocument();
            option.LoadXml(currentoptions);
            if (option.DocumentElement.SelectSingleNode("/options/chars") != null)
                maxchars_text.Text = option.DocumentElement.SelectSingleNode("/options/chars").InnerText;
            if (option.DocumentElement.SelectSingleNode("/options/ml") != null)
            {
                if(option.DocumentElement.SelectSingleNode("/options/ml").InnerText == "yes")
                { allowMultiline_check.Checked = true; }
            }
            if (option.DocumentElement.SelectSingleNode("/options/input") != null)
            {
                string checkeditems = option.DocumentElement.SelectSingleNode("/options/input").InnerText;
                for (int i = 0; i < acceptedinput_groupbox.Items.Count; i++)
                {
                    if (checkeditems.Contains("0") == true)
                        acceptedinput_groupbox.SetItemChecked(0, true);
                    if (checkeditems.Contains("1") == true)
                        acceptedinput_groupbox.SetItemChecked(1, true);
                    if (checkeditems.Contains("2") == true)
                        acceptedinput_groupbox.SetItemChecked(2, true);
                    if (checkeditems.Contains("3") == true)
                        acceptedinput_groupbox.SetItemChecked(3, true);
                }
            }
            checkOK();
        }

        private void Char_KeyInput(object sender, KeyPressEventArgs e)
        {
            var StandardUnicode = new Regex(@"^[^0-9\b]+");
            if (StandardUnicode.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                checkOK();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string charsset = maxchars_text.Text;
            string mlset;
            if (allowMultiline_check.Checked == true)
                mlset = "yes";
            else
                mlset = "no";
            string inputset = "";
            if (acceptedinput_groupbox.GetItemChecked(0) == true)
                inputset = "0;";
            if (acceptedinput_groupbox.GetItemChecked(1) == true)
                inputset = inputset + "1;";
            if (acceptedinput_groupbox.GetItemChecked(2) == true)
                inputset = inputset + "2;";
            if (acceptedinput_groupbox.GetItemChecked(3) == true)
                inputset = inputset + "3;";




            string newoptions;
            newoptions = "<options><chars>" + charsset + "</chars><ml>" + mlset + "</ml><input>" + inputset + "</input></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.grabOptions = newoptions;
            this.Dispose();
        }

        private void FormEvent(object sender, EventArgs e)
        {
            checkOK();
        }

        private void FormEvent(object sender, KeyPressEventArgs e)
        {
            checkOK();
        }

        private void checkOK()
        {
            if (maxchars_text.Text != "" && acceptedinput_groupbox.CheckedIndices.Count != 0)
                OK.Enabled = true;
            if (maxchars_text.Text == "" || acceptedinput_groupbox.CheckedIndices.Count == 0)
                OK.Enabled = false;
        }
    }
}
