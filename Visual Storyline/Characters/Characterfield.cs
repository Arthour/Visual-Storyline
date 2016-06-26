using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Visual_Storyline.Characterfield_options;
using Visual_Storyline.Characters.Characterfield_options;

namespace Visual_Storyline
{
    public partial class Characterfield : UserControl
    {
        internal int ID;
        internal bool isMarked = false;
        internal string optionslist;
        internal string oldoptions;
        internal string oldtype;
        internal string oldelements;
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
                    { optionslist = "<options><font>Arial</font><color>yes</color><size>yes</size><bold>yes</bold><italic>yes</italic><underline>yes</underline><bunumb>yes</bunumb><required>no</required><align>left;right;center;justify</align></options>"; }
                    break;
                case 2:     /*Checkbox*/
                    if(oldtype == "Checkbox")
                    { optionslist = oldoptions; }
                    else if(oldtype == "List" || oldtype == "Combobox")
                    { optionslist = "<options><ms>no</ms><required>no</required><elements>" + oldelements + "</elements></options>"; }
                    else
                    {
                        optionslist = "<options><ms>no</ms><required>no</required><elements></elements></options>";
                        Checkboxoptions chbooptions = new Checkboxoptions(optionslist, ID, true);
                        chbooptions.ShowDialog();
                    }
                    break;
                case 3:     /*Date*/
                    if(oldtype == "Date")
                    { optionslist = oldoptions; }
                    else
                    {
                        optionslist = "<options><realcal>yes</realcal><show><yrs>yes</yrs><mths>yes</mths><ds>yes</ds><hrs>no</hrs><mins>no</mins><secs>no</secs></show></options>";
                        DateTimeoptions dtoptions = new DateTimeoptions(optionslist, ID, true);
                        dtoptions.ShowDialog();
                    }
                    break;
                case 4:     /*Combobox*/
                    if (oldtype == "Combobox")
                    { optionslist = oldoptions; }
                    else if (oldtype == "Checkbox" || oldtype == "List")
                    { optionslist = "<options><limit>no</limit><elements>" + oldelements + "</elements></options>"; }
                    else
                    {
                        optionslist = "<options><limit>no</limit><elements></elements></options>";
                        Comboboxoptions cobooptions = new Comboboxoptions(optionslist, ID, true);
                        cobooptions.ShowDialog();
                    }
                    break;
                case 5:     /*List*/
                    if (oldtype == "List")
                    { optionslist = oldoptions; }
                    else if (oldtype == "Checkbox" || oldtype == "Combobox")
                    { optionslist = "<options><ms>no</ms><elements>" + oldelements + "</elements></options>"; }
                    else
                    {
                        optionslist = "<options><ms>no</ms><elements></elements></options>";
                        Listoptions loptions = new Listoptions(optionslist, ID, true);
                        loptions.ShowDialog();
                    }
                    break;
                case 6:     /*Picture*/
                    if (oldtype == "Picture")
                    { optionslist = oldoptions; }
                    else
                    { optionslist = "<options><allowed>jpg;png;gif;bmp;wmf;</allowed><width>120</width><height>120</height><unit>px</unit><dpm>0</dpm></options>"; }
                    break;
                case 7:     /*Hyphen*/
                    break;
                case 8:     /*Colorpalette*/
                    if (oldtype == "Colorpalette")
                    { optionslist = oldoptions; }
                    else
                    { optionslist = "<options><textcolor>no</textcolor><bgcolor>no</bgcolor><colorbox>no</colorbox><defcol>-16777216</defcol></options>"; }

                    break;
            }

            if (Type.SelectedIndex == 7)
            {
                NameField.Enabled = false;
                NameField.Text = "";
                Options.Enabled = false;
            }
            if (Type.SelectedIndex != 7)
            {
                NameField.Enabled = true;
            }
            if (Type.SelectedIndex != -1 && Type.SelectedIndex != 7)
            {
                Options.Enabled = true;
            }
            update?.Invoke(this, e);
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
                    Checkboxoptions chbooptions = new Checkboxoptions(optionslist, ID, false);
                    chbooptions.ShowDialog();
                    break;
                case 3:     /*Date*/
                    DateTimeoptions dtoptions = new DateTimeoptions(optionslist, ID, false);
                    dtoptions.ShowDialog();
                    break;
                case 4:     /*Combobox*/
                    Comboboxoptions cobooptions = new Comboboxoptions(optionslist, ID, false);
                    cobooptions.ShowDialog();
                    break;
                case 5:     /*List*/
                    Listoptions loptions = new Listoptions(optionslist, ID, false);
                    loptions.ShowDialog();
                    break;
                case 6:     /*Picture*/
                    Pictureoptions poptions = new Pictureoptions(optionslist, ID);
                    poptions.ShowDialog();
                    break;
                case 7:     /*Hyphen*/
                    break;
                case 8:     /*Colorpalette*/
                    Colorpaletteoptions cpoptions = new Colorpaletteoptions(optionslist, ID);
                    cpoptions.ShowDialog();
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
