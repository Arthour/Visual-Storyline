using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline
{
    public partial class EditCharacterFields : Form
    {
        internal static int highestID = -1;
        internal readonly static int Distance = 62;
        internal static int tempID;
        internal static string eventHappened;
        internal static string tempOptions;
        internal static string tempType;
        internal static string tempElements;
        internal static string grabOptions
        {
            get { return tempOptions; }
            set { tempOptions = value; setOptions(tempID, tempOptions, tempType, tempElements); }
        }

        public static Panel spanel{ get; private set; }

        public EditCharacterFields()
        {
            InitializeComponent();
            highestID = -1;

            if (Variables.CharacterFields.Count != 0)
            {
                foreach (string item in Variables.CharacterFields)
                {
                    highestID++;
                    Characterfield field = new Characterfield(highestID);
                    field.update += new EventHandler(ChildUpdate);
                    field.Top = highestID * Distance;
                    XmlDocument option = new XmlDocument();
                    option.LoadXml(item);
                    field.NameField.Text = option.DocumentElement.SelectSingleNode("/characterfield/name").InnerText;
                    field.Type.SelectedIndex = Convert.ToInt32(option.DocumentElement.SelectSingleNode("/characterfield/type").InnerText);
                    field.optionslist = option.DocumentElement.SelectSingleNode("/characterfield/optionslist").InnerXml;
                    field.oldoptions = option.DocumentElement.SelectSingleNode("/characterfield/oldoptions").InnerXml;
                    field.oldtype = option.DocumentElement.SelectSingleNode("/characterfield/oldtype").InnerText;
                    field.oldelements = option.DocumentElement.SelectSingleNode("/characterfield/oldelements").InnerText;

                    FieldPanel.Controls.Add(field);
                    checkButtons();
                    spanel = FieldPanel;
                    checkOK();
                }
            }
        }

        private void addField_Click(object sender, EventArgs e)
        {
            highestID++;
            Characterfield field = new Characterfield(highestID);
            field.update += new EventHandler(ChildUpdate);
            field.Top = highestID * Distance;
            FieldPanel.Controls.Add(field);
            checkButtons();
            spanel = FieldPanel;
            checkOK();
        }

        private void checkButtons()
        {
            foreach (Characterfield field in FieldPanel.Controls)
            {
                if (field.ID == 0)
                { field.Up.Enabled = false; }
                if (field.ID != 0)
                { field.Up.Enabled = true; }
                if (field.ID == highestID)
                { field.Down.Enabled = false; }
                if (field.ID != highestID)
                { field.Down.Enabled = true; }
            }
        }

        private void controlRemoved(object sender, ControlEventArgs e)
        {
            if(tempID != highestID)
            {
                foreach (Characterfield field in FieldPanel.Controls)
                {
                    if(field.ID > tempID)
                    {
                        field.IDChecker--;
                        int x = field.Location.X;
                        int y = field.Location.Y;
                        field.Location = new Point(x, y - Distance);
                    }
                }
            }
            highestID--;
            tempID = -1;
        }

        private void UC_moved(object sender, PaintEventArgs e)
        {
            switch (eventHappened)
            {
                case "UP":
                    RearrangeUp();
                    break;
                case "DOWN":
                    RearrangeDown();
                    break;
            }
            checkOK();
        }

        public void RearrangeUp()
        {
            foreach (Characterfield field in FieldPanel.Controls)
            {
                if (field.ID == tempID - 1)
                {
                    field.IDChecker++;
                    int x = field.Location.X;
                    int y = field.Location.Y;
                    field.Location = new Point(x, y + Distance);
                }
            }
            foreach (Characterfield field in FieldPanel.Controls)
            {
                if (field.isMarked == true)
                {
                    field.IDChecker--;
                    if (field.ID == 0)
                    { field.Up.Enabled = false; }
                    field.isMarked = false;
                    tempID = -1;
                }
            }
        }

        public void RearrangeDown()
        {
            foreach (Characterfield field in FieldPanel.Controls)
            {
                if (field.ID == tempID + 1)
                {
                    field.IDChecker--;
                    int x = field.Location.X;
                    int y = field.Location.Y;
                    field.Location = new Point(x, y - Distance);
                }
            }
            foreach (Characterfield field in FieldPanel.Controls)
            {
                if (field.isMarked == true)
                {
                    field.IDChecker++;
                    if (field.ID == 0)
                    { field.Up.Enabled = false; }
                    field.isMarked = false;
                    tempID = -1;
                }
            }
        }

        public static void setOptions(int ID, string options, string type, string elements)
        {
            foreach (Characterfield field in spanel.Controls)
            {
                if (field.ID == tempID)
                {
                    field.optionslist = options;
                    field.oldoptions = options;
                    field.oldtype = type;
                    field.oldelements = elements;
                }
            }
        }

        public static void cancelOptions(int ID)
        {
            foreach (Characterfield field in spanel.Controls)
            {
                if (field.ID == tempID)
                {
                    field.Type.SelectedIndex = -1;
                }
            }
        }

        private void FormEvent(object sender, EventArgs e)
        {
            checkOK();
        }

        public void checkOK()
        {
            int count = 0;
            foreach(Characterfield field in FieldPanel.Controls)
            {
                if ((field.NameField.Text == "" && field.Type.SelectedIndex != 7) || field.Type.SelectedIndex == -1)
                    count++;
            }
            if(count == 0)
            {
                OK.Enabled = true;
            }
            else
            {
                OK.Enabled = false;
            }
        }

        private void ChildUpdate(object sender, EventArgs e)
        {
            checkOK();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Variables.CharacterFields.Clear();

            foreach (Characterfield field in FieldPanel.Controls)
            {
                string characterfield = "<characterfield><name>" + field.NameField.Text + "</name><type>" + field.Type.SelectedIndex + "</type><optionslist>" + field.optionslist + "</optionslist><oldoptions>" + field.oldoptions + "</oldoptions><oldtype>" + field.oldtype + "</oldtype><oldelements>" + field.oldelements + "</oldelements></characterfield>";
                Variables.CharacterFields.Add(characterfield);
            }
            this.Dispose();
        }
    }
}
