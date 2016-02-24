using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline.Characterfield_options
{
    public partial class DateTimeoptions : Form
    {
        private int ID;
        private bool userealcal;

        public DateTimeoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            optionChanged();
            presuffixChanged();

            //ListViewItem newItem = new ListViewItem("Test");
            //newItem.SubItems.Add("1");
            //monthNames.Items.Add(newItem);
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            optionChanged();
            presuffixChanged();
        }

        private void optionChanged()
        {
            bool ischecked = false;

            if (showYears.Checked == true && userealcal == false)
            {
                invisYears.Visible = true;
                yearsPanel.Visible = true;
            }
            else
            {
                invisYears.Visible = false;
                yearsPanel.Visible = false;
            }
            if (showMonths.Checked == true && userealcal == false)
            {
                invisMonths.Visible = true;
                monthsPanel.Visible = true;
            }
            else
            {
                invisMonths.Visible = false;
                monthsPanel.Visible = false;
            }
            if (showDays.Checked == true && userealcal == false)
            {
                invisDays.Visible = true;
                daysPanel.Visible = true;
            }
            else
            {
                invisDays.Visible = false;
                daysPanel.Visible = false;
            }

            CheckBox[] TimeOptions = new CheckBox[] { showYears, showMonths, showDays, showHours, showMinutes, showSeconds};
            foreach (CheckBox check in TimeOptions)
            {
                if (check.Checked == true)
                    ischecked = true;
            }
            if (ischecked == true)
            {
                OK.Enabled = true;
            }
            else
            {
                OK.Enabled = false;
            }
        }

        private void presuffixChanged()
        {
            if (addPrefix.Checked || addSuffix.Checked)
            {
                presuffix_list.Enabled = true;
                addElement_text.Enabled = true;
                delete.Enabled = true;
                add_Element.Enabled = true;
                defaultElement.Enabled = true;
            }
            else
            {
                presuffix_list.Enabled = false;
                addElement_text.Enabled = false;
                delete.Enabled = false;
                add_Element.Enabled = false;
                defaultElement.Enabled = false;
            }
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            if (presuffix_list.SelectedItem != null)
            {
                addElement_text.Text = presuffix_list.SelectedItem.ToString();
                delete.Enabled = true;
                addElement_text.Focus();
                addElement_text.SelectionStart = addElement_text.TextLength;
                addElement_text.SelectionLength = 0;
            }
            else
            {
                delete.Enabled = false;
            }
        }

        private void TextFieldChanged(object sender, EventArgs e)
        {
            presuffix_list.SelectedIndex = -1;
            bool alreadythere = false;
            foreach (object item in presuffix_list.Items)
            {
                if (item.ToString() == addElement_text.Text)
                {
                    alreadythere = true;
                }
            }
            if (alreadythere == true)
            {
                add_Element.Enabled = false;
                presuffix_list.SelectedItem = addElement_text.Text;
            }
            else if(addElement_text.Text == "none" || addElement_text.Text == "keines")
            {
                add_Element.Enabled = false;
            }
            else
            {
                add_Element.Enabled = true;
                presuffix_list.SelectedIndex = -1;
            }
        }

        private void add_Element_Click(object sender, EventArgs e)
        {
            if (addElement_text.Text != "" && addElement_text.Text != null)
            {
                presuffix_list.Items.Add(addElement_text.Text);
                defaultElement.Items.Add(addElement_text.Text);
                addElement_text.Text = "";
                addElement_text.Focus();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (defaultElement.SelectedItem.ToString() == addElement_text.Text)
                defaultElement.SelectedIndex = 0;
            defaultElement.Items.RemoveAt(presuffix_list.SelectedIndex + 1);
            presuffix_list.Items.RemoveAt(presuffix_list.SelectedIndex);
            delete.Enabled = false;
            addElement_text.Text = "";
            addElement_text.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (addElement_text.Focused == true)
            {
                if (keyData == Keys.Up)
                {
                    if (presuffix_list.SelectedIndex == -1)
                        presuffix_list.SelectedIndex = presuffix_list.Items.Count - 1;
                    else if (presuffix_list.SelectedIndex != -1 && presuffix_list.SelectedIndex != 0)
                        presuffix_list.SelectedIndex = presuffix_list.SelectedIndex - 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    if (presuffix_list.SelectedIndex != -1 && presuffix_list.SelectedIndex != presuffix_list.Items.Count - 1)
                        presuffix_list.SelectedIndex = presuffix_list.SelectedIndex + 1;
                    addElement_text.SelectionStart = addElement_text.TextLength;
                    addElement_text.SelectionLength = 0;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FocusEnter(object sender, EventArgs e)
        {
            this.AcceptButton = add_Element;
        }

        private void FocusLeave(object sender, EventArgs e)
        {
            this.AcceptButton = OK;
        }

        private void timetable_Click(object sender, EventArgs e)
        {
            DateTimetimetable timetable = new DateTimetimetable();
            timetable.ShowDialog();
        }

        private void realCalendarChecked(object sender, EventArgs e)
        {
            if (realcal.Checked)
            {
                userealcal = true;
                timetable.Enabled = false;
            }
            else
            {
                userealcal = false;
                timetable.Enabled = true;
            }

            optionChanged();
        }
    }
}
