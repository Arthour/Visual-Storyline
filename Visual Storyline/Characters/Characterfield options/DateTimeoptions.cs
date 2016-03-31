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
using Visual_Storyline.Characters.Characterfield_options;

namespace Visual_Storyline.Characterfield_options
{
    public partial class DateTimeoptions : Form
    {
        private int ID;
        private bool userealcal;
        private int countMonths;
        private int countDays;
        private bool manualOverride;

        internal static int ytm, mtd, dth, htm, mts;

        public DateTimeoptions(string options, int ID_Parent)
        {
            InitializeComponent();
            ID = ID_Parent;
            string temp;
        
            try
            {
                RadioButton[] PreSuffixList = { addPrefix, addSuffix, nothing };
                XmlDocument option = new XmlDocument();
                option.LoadXml(options);
                if(option.DocumentElement.SelectSingleNode("/options/realcal").InnerText == "yes")
                {
                    realcal.Checked = true;
                }
                else if(option.DocumentElement.SelectSingleNode("/options/realcal").InnerText == "no")
                {
                    realcal.Checked = false;
                    temp = option.DocumentElement.SelectSingleNode("/options/presuffixes/selected").InnerText;
                    if (temp == "prefix")
                        addPrefix.Checked = true;
                    else if (temp == "suffix")
                        addSuffix.Checked = true;
                    else
                        nothing.Checked = true;
                    if(!nothing.Checked && PreSuffixList.Any())
                    {
                        XmlNodeList xmlpresuffix = option.SelectNodes("/options/presuffixes/presuffix");
                        foreach (XmlNode node in xmlpresuffix)
                        {
                            presuffix_list.Items.Add(node.InnerText);
                            defaultElement.Items.Add(node.InnerText);
                        }
                        defaultElement.SelectedIndex = Convert.ToInt32(option.SelectSingleNode("/options/presuffixes/default").InnerText);
                    }
                    if (option.DocumentElement.SelectSingleNode("/options/presuffixes/negative").InnerText == "yes")
                        negative.Checked = true;
                    countMonths = 0;
                    if(option.DocumentElement.SelectSingleNode("/options/monthnames").InnerXml != null)
                    {
                        XmlNodeList xmlmonth = option.SelectNodes("/options/monthnames/month");
                        foreach (XmlNode node in xmlmonth)
                        {
                            countMonths++;
                            ListViewItem newItem = new ListViewItem(node.InnerText);
                            newItem.SubItems.Add(countMonths.ToString());
                            monthNames.Items.Add(newItem);
                        }
                    }
                    countDays = 0;
                    if (option.DocumentElement.SelectSingleNode("/options/daynames").InnerXml != null)
                    {
                        XmlNodeList xmlday = option.SelectNodes("/options/daynames/day");
                        foreach (XmlNode node in xmlday)
                        {
                            countDays++;
                            ListViewItem newItem = new ListViewItem(node.InnerText);
                            newItem.SubItems.Add(countDays.ToString());
                            dayNames.Items.Add(newItem);
                        }
                        if (countDays > 0)
                            daysPerWeek.Value = countDays;
                    }
                    ytm = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/timetable/ytm").InnerText);
                    mtd = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/timetable/mtd").InnerText);
                    dth = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/timetable/dth").InnerText);
                    htm = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/timetable/htm").InnerText);
                    mts = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/options/timetable/mts").InnerText);
                }
                if (option.DocumentElement.SelectSingleNode("/options/show/yrs").InnerText == "yes")
                    showYears.Checked = true;
                if (option.DocumentElement.SelectSingleNode("/options/show/mths").InnerText == "yes")
                    showMonths.Checked = true;
                if (option.DocumentElement.SelectSingleNode("/options/show/ds").InnerText == "yes")
                    showDays.Checked = true;
                if (option.DocumentElement.SelectSingleNode("/options/show/hrs").InnerText == "yes")
                    showHours.Checked = true;
                if (option.DocumentElement.SelectSingleNode("/options/show/mins").InnerText == "yes")
                    showMinutes.Checked = true;
                if (option.DocumentElement.SelectSingleNode("/options/show/secs").InnerText == "yes")
                    showSeconds.Checked = true;

                optionChanged();
                presuffixChanged();
            }
            catch (Exception)
            {
                ErrorMessages.SomethingWentWrongOptions();
                ErrorMessages.ErrorTitle();
                DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                realcal.Checked = true;
                showYears.Checked = true;
                showMonths.Checked = true;
                showDays.Checked = true;
            }
        }

        private void changeMonths()
        {
            if(manualOverride == false)
            {
                if (ytm > countMonths)
                {
                    int i = ytm - countMonths;
                    while (i > 0)
                    {
                        countMonths++;
                        ListViewItem newItem = new ListViewItem("");
                        newItem.SubItems.Add(countMonths.ToString());
                        monthNames.Items.Add(newItem);

                        i--;
                    }
                }
                else if (ytm < countMonths)
                {
                    int i = countMonths - ytm;
                    while (i > 0)
                    {
                        monthNames.Items.RemoveAt(countMonths - 1);
                        countMonths--;

                        i--;
                    }
                }
            }
        }

        private void changeDays()
        {
            if(manualOverride == false)
            {
                if (daysPerWeek.Value > countDays)
                {
                    int i = Convert.ToInt32(daysPerWeek.Value) - countDays;
                    while (i > 0)
                    {
                        countDays++;
                        ListViewItem newItem = new ListViewItem("");
                        newItem.SubItems.Add(countDays.ToString());
                        dayNames.Items.Add(newItem);

                        i--;
                    }
                }
                else if (daysPerWeek.Value < countDays)
                {
                    int i = countDays - Convert.ToInt32(daysPerWeek.Value);
                    while (i > 0)
                    {
                        dayNames.Items.RemoveAt(countDays - 1);
                        countDays--;

                        i--;
                    }
                }
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            optionChanged();
            presuffixChanged();
        }

        private void optionChanged()
        {
            bool ischecked = false;
            RadioButton[] PreSuffixList = { addPrefix, addSuffix, nothing };

            if (showYears.Checked && !userealcal)
            {
                invisYears.Visible = true;
                yearsPanel.Visible = true;
            }
            else
            {
                invisYears.Visible = false;
                yearsPanel.Visible = false;
            }
            if (showMonths.Checked && !userealcal)
            {
                invisMonths.Visible = true;
                monthsPanel.Visible = true;
            }
            else
            {
                invisMonths.Visible = false;
                monthsPanel.Visible = false;
            }
            if (showDays.Checked && !userealcal)
            {
                invisDays.Visible = true;
                daysPanel.Visible = true;
            }
            else
            {
                invisDays.Visible = false;
                daysPanel.Visible = false;
            }

            if (showYears.Checked)
                year.Visible = true;
            else
                year.Visible = false;
            if (showMonths.Checked)
            { monthnr.Visible = true; monthname.Visible = true; }
            else
            { monthnr.Visible = false; monthname.Visible = false; }
            if (showDays.Checked)
            { day.Visible = true; dayofweek.Visible = true; }
            else
            { day.Visible = false; dayofweek.Visible = false; }
            if (showHours.Checked)
            { hour12.Visible = true; hour24.Visible = true; }
            else
            { hour12.Visible = false; hour24.Visible = false; }
            if (showMinutes.Checked)
                minute.Visible = true;
            else
                minute.Visible = false;
            if (showSeconds.Checked)
                second.Visible = true;
            else
                second.Visible = false;

            CheckBox[] TimeOptions = new CheckBox[] { showYears, showMonths, showDays, showHours, showMinutes, showSeconds };
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

        private void dpwChanged(object sender, EventArgs e)
        {
            changeDays();
        }

        private void FocusLeave(object sender, EventArgs e)
        {
            this.AcceptButton = OK;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            CustomButton cb = (CustomButton)sender;

            var insertText = "<" + cb.Text + ">";
            var selectionIndex = Formatfield.SelectionStart;

            Formatfield.Text = Formatfield.Text.Insert(selectionIndex, insertText);
            Formatfield.SelectionLength = insertText.Length;
        }

        private void timetable_Click(object sender, EventArgs e)
        {
            using (DateTimetimetable timetable = new DateTimetimetable(ytm, mtd, dth, htm, mts))
            {
                timetable.ShowDialog();

                ytm = timetable.ytm;
                mtd = timetable.mtd;
                dth = timetable.dth;
                htm = timetable.htm;
                mts = timetable.mts;

                changeMonths();
            }
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
                manualOverride = true;

                if (ytm == 0)
                {
                    ytm = 12;

                    countMonths++;
                    ListViewItem m1 = new ListViewItem(ManualTranslation.Month(1));
                    m1.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m1);
                    countMonths++;
                    ListViewItem m2 = new ListViewItem(ManualTranslation.Month(2));
                    m2.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m2);
                    countMonths++;
                    ListViewItem m3 = new ListViewItem(ManualTranslation.Month(3));
                    m3.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m3);
                    countMonths++;
                    ListViewItem m4 = new ListViewItem(ManualTranslation.Month(4));
                    m4.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m4);
                    countMonths++;
                    ListViewItem m5 = new ListViewItem(ManualTranslation.Month(5));
                    m5.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m5);
                    countMonths++;
                    ListViewItem m6 = new ListViewItem(ManualTranslation.Month(6));
                    m6.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m6);
                    countMonths++;
                    ListViewItem m7 = new ListViewItem(ManualTranslation.Month(7));
                    m7.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m7);
                    countMonths++;
                    ListViewItem m8 = new ListViewItem(ManualTranslation.Month(8));
                    m8.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m8);
                    countMonths++;
                    ListViewItem m9 = new ListViewItem(ManualTranslation.Month(9));
                    m9.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m9);
                    countMonths++;
                    ListViewItem m10 = new ListViewItem(ManualTranslation.Month(10));
                    m10.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m10);
                    countMonths++;
                    ListViewItem m11 = new ListViewItem(ManualTranslation.Month(11));
                    m11.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m11);
                    countMonths++;
                    ListViewItem m12 = new ListViewItem(ManualTranslation.Month(12));
                    m12.SubItems.Add(countMonths.ToString());
                    monthNames.Items.Add(m12);
                }
                if (mtd == 0)
                    mtd = 30;
                if (dth == 0)
                    dth = 24;
                if (htm == 0)
                    htm = 60;
                if (mts == 0)
                    mts = 60;

                if (countDays == 0)
                {
                    daysPerWeek.Value = 7;
                    countDays++;
                    ListViewItem d1 = new ListViewItem(ManualTranslation.Day(1));
                    d1.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d1);
                    countDays++;
                    ListViewItem d2 = new ListViewItem(ManualTranslation.Day(2));
                    d2.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d2);
                    countDays++;
                    ListViewItem d3 = new ListViewItem(ManualTranslation.Day(3));
                    d3.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d3);
                    countDays++;
                    ListViewItem d4 = new ListViewItem(ManualTranslation.Day(4));
                    d4.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d4);
                    countDays++;
                    ListViewItem d5 = new ListViewItem(ManualTranslation.Day(5));
                    d5.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d5);
                    countDays++;
                    ListViewItem d6 = new ListViewItem(ManualTranslation.Day(6));
                    d6.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d6);
                    countDays++;
                    ListViewItem d7 = new ListViewItem(ManualTranslation.Day(7));
                    d7.SubItems.Add(countDays.ToString());
                    dayNames.Items.Add(d7);
                }
            }
            manualOverride = false;
            optionChanged();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string realcalset;
            string inneroptions = "";
            if (realcal.Checked)
            {
                realcalset = "<realcal>yes</realcal>";
            }
            else
            {
                string presuffixset;
                if (addPrefix.Checked)
                    presuffixset = "prefix";
                else if (addSuffix.Checked)
                    presuffixset = "suffix";
                else
                    presuffixset = "nothing";
                string presuffixesset = "";
                foreach (Object item in presuffix_list.Items)
                {
                    presuffixesset = presuffixesset + "<presuffix>" + item + "</presuffix>";
                }
                int defaultset = defaultElement.SelectedIndex;
                string negativeset = "no";
                if (negative.Checked)
                    negativeset = "yes";
                string monthnamesset = "";
                foreach (ListViewItem item in monthNames.Items)
                {
                    monthnamesset = monthnamesset + "<month>" + item.Text + "</month>";
                }
                string daynamesset = "";
                foreach (ListViewItem item in dayNames.Items)
                {
                    daynamesset = daynamesset + "<day>" + item.Text + "</day>";
                }
                realcalset = "<realcal>no</realcal>";
                inneroptions = "<presuffixes><selected>" + presuffixset + "</selected>" + presuffixesset + "<default>" + defaultset + "</default><negative>" + negativeset + "</negative></presuffixes><monthnames>" + monthnamesset + "</monthnames><daynames>" + daynamesset + "</daynames><timetable><ytm>" + ytm + "</ytm><mtd>" + mtd + "</mtd><dth>" + dth + "</dth><htm>" + htm + "</htm><mts>" + mts + "</mts></timetable>";
            }
            string showyearsset = "no";
            if (showYears.Checked)
                showyearsset = "yes";
            string showmonthsset = "no";
            if (showMonths.Checked)
                showmonthsset = "yes";
            string showdaysset = "no";
            if (showDays.Checked)
                showdaysset = "yes";
            string showhoursset = "no";
            if (showHours.Checked)
                showhoursset = "yes";
            string showminutesset = "no";
            if (showMinutes.Checked)
                showminutesset = "yes";
            string showsecondsset = "no";
            if (showSeconds.Checked)
                showsecondsset = "yes";
            string formatset = Formatfield.Text;
            string newoptions;
            newoptions = "<options>" + realcalset + "<show><yrs>" + showyearsset + "</yrs><mths>" + showmonthsset + "</mths><ds>" + showdaysset + "</ds><hrs>" + showhoursset + "</hrs><mins>" + showminutesset + "</mins><secs>" + showsecondsset + "</secs></show><format>" + formatset + "</format>" + inneroptions + "</options>";
            EditCharacterFields.tempID = ID;
            EditCharacterFields.tempType = "Date";
            EditCharacterFields.grabOptions = newoptions;

            this.Dispose();
        }
    }
}