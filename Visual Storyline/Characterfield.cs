using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Storyline
{
    public partial class Characterfield : UserControl
    {
        public int ID;
        public bool isMarked = false;
        public int IDChecker
        {
            get { CheckID();  return ID; }
            set { ID = value; CheckID(); }
        }

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
            if(Type.SelectedIndex == 7)
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
        }

        private void Options_Click(object sender, EventArgs e)
        {
            switch(Type.SelectedIndex)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
                case 4:
                    Console.WriteLine("4");
                    break;
                case 5:
                    Console.WriteLine("5");
                    break;
                case 6:
                    Console.WriteLine("6");
                    break;
                case 7:
                    Console.WriteLine("7");
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
    }
}
