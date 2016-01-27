using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Storyline
{
    public partial class EditCharacterFields : Form
    {
        public static int highestID = -1;
        private static int Distance = 62;
        public static int deletedID;

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
        }

    private void controlRemoved(object sender, ControlEventArgs e)
        {
            if(deletedID != highestID)
            {
                foreach (Characterfield field in FieldPanel.Controls)
                {
                    if(field.ID > deletedID)
                    {
                        field.ID--;
                        int x = field.Location.X;
                        int y = field.Location.Y;
                        field.Location = new Point(x, y - Distance);
                    }
                }
            }
            highestID--;
            deletedID = -1;
        }
    }
}
