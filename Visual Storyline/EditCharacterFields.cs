using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Storyline
{
    public partial class EditCharacterFields : Form
    {
        public static int highestID = -1;
        public readonly static int Distance = 62;
        public static int tempID;
        public static string eventHappened;

        public EditCharacterFields()
        {
            InitializeComponent();
        }

        private void addField_Click(object sender, EventArgs e)
        {
            highestID++;
            Characterfield field = new Characterfield(highestID);
            field.Top = highestID * Distance;
            FieldPanel.Controls.Add(field);
            checkButtons();
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

    }
}
