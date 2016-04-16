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

namespace Visual_Storyline.Characterfield_options
{
    public partial class Checkboxoptions : Form
    {
        private int ID;
        private bool isNeeded;

        public Checkboxoptions(string options, int ID_Parent, bool EntryNeeded)
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
                        multiselect_check.Checked = true;
                }
                else { multiselect_check.Checked = false; }
                if (option.DocumentElement.SelectSingleNode("/options/required") != null)
                {
                    if (option.DocumentElement.SelectSingleNode("/options/required").InnerText == "yes")
                        requireselection_check.Checked = true;
                }
                else { requireselection_check.Checked = false; }
                if (option.DocumentElement.SelectNodes("/options/elements/element") != null)
                {
                    XmlNodeList xmllist = option.SelectNodes("/options/elements/element");
                    foreach (XmlNode node in xmllist)
                    {
                        if (node.InnerText != "")
                        {
                            checkboxelements_list.Items.Add(node.InnerText);
                        }
                    }
                }
                else { isNeeded = true; }
            }
            catch(Exception)
            {
                ErrorMessages.SomethingWentWrongOptions();
                ErrorMessages.ErrorTitle();
                DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                multiselect_check.Checked = false;
                requireselection_check.Checked = false;
                isNeeded = true;
            }
            CheckOK();
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            if(checkboxelements_list.SelectedItem != null)
            {
                addElement_text.Text = checkboxelements_list.SelectedItem.ToString();
                delete.Enabled = true;
                if (checkboxelements_list.SelectedIndex != 0)
                    move_up.Enabled = true;
                else
                    move_up.Enabled = false;
                if (checkboxelements_list.SelectedIndex != checkboxelements_list.Items.Count - 1)
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
            checkboxelements_list.SelectedIndex = -1;
            bool alreadythere = false;
            foreach(object item in checkboxelements_list.Items)
            {
                if(item.ToString() == addElement_text.Text)
                {
                    alreadythere = true;
                }
            }
            if (alreadythere == true)
            {
                add_Element.Enabled = false;
                checkboxelements_list.SelectedItem = addElement_text.Text;
            }
            else
            {
                add_Element.Enabled = true;
                checkboxelements_list.SelectedIndex = -1;
            }
        }

        private void add_Element_Click(object sender, EventArgs e)
        {
            if(addElement_text.Text != "" && addElement_text.Text != null)
            {
                checkboxelements_list.Items.Add(addElement_text.Text);
                addElement_text.Text = "";
                addElement_text.Focus();
                CheckOK();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            checkboxelements_list.Items.RemoveAt(checkboxelements_list.SelectedIndex);
            delete.Enabled = false;
            move_up.Enabled = false;
            move_down.Enabled = false;
            addElement_text.Text = "";
            addElement_text.Focus();
            CheckOK();
        }

        private void move_up_Click(object sender, EventArgs e)
        {
            int selectedID = checkboxelements_list.SelectedIndex;
            checkboxelements_list.Items.Insert(selectedID - 1, checkboxelements_list.Items[selectedID]);
            checkboxelements_list.Items.RemoveAt(selectedID + 1);
            checkboxelements_list.SelectedIndex = selectedID - 1;
            addElement_text.Focus();
            addElement_text.SelectionStart = addElement_text.TextLength;
            addElement_text.SelectionLength = 0;
        }

        private void move_down_Click(object sender, EventArgs e)
        {
            int selectedID = checkboxelements_list.SelectedIndex;
            checkboxelements_list.Items.Insert(selectedID + 2, checkboxelements_list.Items[selectedID]);
            checkboxelements_list.Items.RemoveAt(selectedID);
            checkboxelements_list.SelectedIndex = selectedID + 1;
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
                    if (checkboxelements_list.SelectedIndex == -1)
                        checkboxelements_list.SelectedIndex = checkboxelements_list.Items.Count - 1;
                    else if (checkboxelements_list.SelectedIndex != -1 && checkboxelements_list.SelectedIndex != 0)
                        checkboxelements_list.SelectedIndex = checkboxelements_list.SelectedIndex - 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    if (checkboxelements_list.SelectedIndex != -1 && checkboxelements_list.SelectedIndex != checkboxelements_list.Items.Count - 1)
                        checkboxelements_list.SelectedIndex = checkboxelements_list.SelectedIndex + 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CheckOK()
        {
            if (checkboxelements_list.Items.Count == 0)
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string msset = "no";
            if (multiselect_check.Checked)
                msset = "yes";
            string reqset = "no";
            if (requireselection_check.Checked)
                reqset = "yes";
            string eleset = "";
            foreach(object item in checkboxelements_list.Items)
            {
                eleset = eleset + "<element>" + item + "</element>";
            }
            string newoptions;
            newoptions = "<options><ms>" + msset + "</ms><required>" + reqset + "</required><elements>" + eleset + "</elements></options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "Checkbox";
            EditCharacterFields.tempElements = eleset;
            EditCharacterFields.grabOptions = newoptions;
            this.Dispose();
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
    }
}
