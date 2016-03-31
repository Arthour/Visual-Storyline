using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Visual_Storyline.Characterfield_options;

namespace Visual_Storyline
{
    public partial class Characterfield : UserControl
    {
        internal int ID;
        internal bool isMarked = false;
        internal string optionslist;
        internal string oldoptions;
        internal string oldtype;
        internal int IDChecker
        {
            get { CheckID();  return ID; }
            set { ID = value; CheckID(); }
        }
        internal string templist
        {
            get { return optionslist; }
            set { optionslist = value; }
        }

        public event EventHandler update;

        public Characterfield(int Index)
        {
            InitializeComponent();
            ID = Index;
        }

        public void CheckID()
        {
            if (ID == 0)
            { Up.Enabled = false; }
            if (ID != 0)
            { Up.Enabled = true; }
            if (ID == EditCharacterFields.highestID)
            { Down.Enabled = false; }
            if (ID != EditCharacterFields.highestID)
            { Down.Enabled = true; }
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Type.SelectedIndex)
            {
                case 0:     /*Textfield*/
                    if(oldtype == "Text")
                    { optionslist = oldoptions; }
                    else
                    { optionslist = "<options><chars>248</chars><ml>no</ml><input>0;1;2;</input><required>no</required></options>"; }
                    break;
                case 1:     /*RichText-Textfield*/
                    if(oldtype == "Richtext")
                    { optionslist = oldoptions; }
                    else
                    { optionslist = "<options><font>Aral</font><color>yes</color><size>yes</size><bold>yes</bold><italic>yes</italic><underline>yes</underline><bunumb>yes</bunumb><required>no</required><align>left;right;center;justify</align></options>"; }
                    break;
                case 2:     /*Checkbox*/
                    if(oldtype == "Checkbox")
                    { optionslist = oldoptions; }
                    else
                    {
                        optionslist = "<options><ms>no</ms><required>no</required><elements></elements></options>";
                        Checkboxoptions cboptions = new Checkboxoptions(optionslist, ID, true);
                        cboptions.ShowDialog();
                    }
                    break;
                case 3:     /*Date*/
                    if(oldtype == "Date")
                    { optionslist = oldoptions; }
                    else
                    { optionslist = "<options><realcal>yes</realcal><show><yrs>yes</yrs><mths>yes</mths><ds>yes</ds><hrs>no</hrs><mins>no</mins><secs>no</secs></show></options>"; }
                    break;
                case 4:     /*Combobox*/
                    break;
                case 5:     /*List*/
                    break;
                case 6:     /*Picture*/
                    break;
                case 7:     /*Hyphen*/
                    break;
                case 8:     /*Colorpalette*/
                    break;
            }

            if (Type.SelectedIndex == 7)
            {
                NameField.Enabled = false;
            }
            if (Type.SelectedIndex != 7)
            {
                NameField.Enabled = true;
            }
            if (Type.SelectedIndex != -1)
            {
                Options.Enabled = true;
            }
            if (update != null)
                update(this, e);
        }

        private void Options_Click(object sender, EventArgs e)
        {
            switch(Type.SelectedIndex)
            {
                case 0:     /*Textfield*/
                    Textfieldoptions tfoptions = new Textfieldoptions(optionslist, ID);
                    tfoptions.ShowDialog();
                    break;
                case 1:     /*RichText-Textfield*/
                    RichTextboxoptions rtoptions = new RichTextboxoptions(optionslist, ID);
                    rtoptions.ShowDialog();
                    break;
                case 2:     /*Checkbox*/
                    Checkboxoptions cboptions = new Checkboxoptions(optionslist, ID, false);
                    cboptions.ShowDialog();
                    break;
                case 3:     /*Date*/
                    DateTimeoptions dtoptions = new DateTimeoptions(optionslist, ID);
                    dtoptions.ShowDialog();
                    break;
                case 4:     /*Combobox*/
                    break;
                case 5:     /*List*/
                    break;
                case 6:     /*Picture*/
                    break;
                case 7:     /*Hyphen*/
                    break;
                case 8:     /*Colorpalette*/
                    break;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            EditCharacterFields.tempID = ID;
            this.Dispose();
        }

        private void Characterfield_Load(object sender, EventArgs e)
        {
            CheckID();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                int x = this.Location.X;
                int y = this.Location.Y;
                isMarked = true;
                this.Location = new Point(x, y - EditCharacterFields.Distance);
                EditCharacterFields.tempID = ID;
                EditCharacterFields.eventHappened = "UP";
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (ID != EditCharacterFields.highestID)
            {
                int x = this.Location.X;
                int y = this.Location.Y;
                isMarked = true;
                this.Location = new Point(x, y + EditCharacterFields.Distance);
                EditCharacterFields.tempID = ID;
                EditCharacterFields.eventHappened = "DOWN";
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (update != null)
                update(this, e);
        }
    }
}
