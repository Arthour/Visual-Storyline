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
    public partial class Listoptions : Form
    {
        private int ID;
        private bool isNeeded;

        public Listoptions(string options, int ID_Parent, bool EntryNeeded)
        {
            InitializeComponent();
            ID = ID_Parent;
            isNeeded = EntryNeeded;
            try
            {
                XmlDocument option = new XmlDocument();
                option.LoadXml(options);
                if (option.DocumentElement.SelectSingleNode("/options/ms") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/ms").InnerText == "yes")
                        ms_check.Checked = true;
                }
                else { ms_check.Checked = false; }
                if (option.DocumentElement.SelectNodes("/options/elements/element") != null)
                {
                    XmlNodeList xmllist = option.SelectNodes("/options/elements/element");
                    foreach (XmlNode node in xmllist)
                    {
                        if (node.InnerText != "")
                        {
                            listelements_list.Items.Add(node.InnerText);
                        }
                    }
                }
                else { isNeeded = true; }
            }
            catch (Exception)
            {
                ErrorMessages.SomethingWentWrongOptions();
                ErrorMessages.ErrorTitle();
                DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ms_check.Checked = false;
                isNeeded = true;
            }
            CheckOK();
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            if (listelements_list.SelectedItem != null)
            {
                addElement_text.Text = listelements_list.SelectedItem.ToString();
                delete.Enabled = true;
                if (listelements_list.SelectedIndex != 0)
                    move_up.Enabled = true;
                else
                    move_up.Enabled = false;
                if (listelements_list.SelectedIndex != listelements_list.Items.Count - 1)
                    move_down.Enabled = true;
                else
                    move_down.Enabled = false;
                addElement_text.Focus();
                addElement_text.SelectionStart = addElement_text.TextLength;
                addElement_text.SelectionLength = 0;
            }
            else
            {
                delete.Enabled = false;
                move_up.Enabled = false;
                move_down.Enabled = false;
            }
        }

        private void TextFieldChanged(object sender, EventArgs e)
        {
            listelements_list.SelectedIndex = -1;
            bool alreadythere = false;
            foreach (object item in listelements_list.Items)
            {
                if (item.ToString() == addElement_text.Text)
                {
                    alreadythere = true;
                }
            }
            if (alreadythere == true)
            {
                add_Element.Enabled = false;
                listelements_list.SelectedItem = addElement_text.Text;
            }
            else
            {
                add_Element.Enabled = true;
                listelements_list.SelectedIndex = -1;
            }
        }

        private void add_Element_Click(object sender, EventArgs e)
        {
            if (addElement_text.Text != "" && addElement_text.Text != null)
            {
                listelements_list.Items.Add(addElement_text.Text);
                addElement_text.Text = "";
                addElement_text.Focus();
                CheckOK();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            listelements_list.Items.RemoveAt(listelements_list.SelectedIndex);
            delete.Enabled = false;
            move_up.Enabled = false;
            move_down.Enabled = false;
            addElement_text.Text = "";
            addElement_text.Focus();
            CheckOK();
        }

        private void move_up_Click(object sender, EventArgs e)
        {
            int selectedID = listelements_list.SelectedIndex;
            listelements_list.Items.Insert(selectedID - 1, listelements_list.Items[selectedID]);
            listelements_list.Items.RemoveAt(selectedID + 1);
            listelements_list.SelectedIndex = selectedID - 1;
            addElement_text.Focus();
            addElement_text.SelectionStart = addElement_text.TextLength;
            addElement_text.SelectionLength = 0;
        }

        private void move_down_Click(object sender, EventArgs e)
        {
            int selectedID = listelements_list.SelectedIndex;
            listelements_list.Items.Insert(selectedID + 2, listelements_list.Items[selectedID]);
            listelements_list.Items.RemoveAt(selectedID);
            listelements_list.SelectedIndex = selectedID + 1;
            addElement_text.Focus();
            addElement_text.SelectionStart = addElement_text.TextLength;
            addElement_text.SelectionLength = 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (addElement_text.Focused == true)
            {
                if (keyData == Keys.Up)
                {
                    if (listelements_list.SelectedIndex == -1)
                        listelements_list.SelectedIndex = listelements_list.Items.Count - 1;
                    else if (listelements_list.SelectedIndex != -1 && listelements_list.SelectedIndex != 0)
                        listelements_list.SelectedIndex = listelements_list.SelectedIndex - 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    if (listelements_list.SelectedIndex != -1 && listelements_list.SelectedIndex != listelements_list.Items.Count - 1)
                        listelements_list.SelectedIndex = listelements_list.SelectedIndex + 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CheckOK()
        {
            if (listelements_list.Items.Count == 0)
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void FocusEnter(object sender, EventArgs e)
        {
            this.AcceptButton = add_Element;
        }

        private void FocusLeave(object sender, EventArgs e)
        {
            this.AcceptButton = OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (isNeeded == true)
            {
                EditCharacterFields.cancelOptions(ID);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string msset = "no";
            if (ms_check.Checked)
                msset = "yes";
            string eleset = "";
            foreach (object item in listelements_list.Items)
            {
                eleset = eleset + "<element>" + item + "</element>";
            }
            string newoptions;
            newoptions = "<options><ms>" + msset + "</ms><elements>" + eleset + "</elements></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "List";
            EditCharacterFields.tempElements = eleset;
            EditCharacterFields.grabOptions = newoptions;
            this.Dispose();
        }
    }
}
