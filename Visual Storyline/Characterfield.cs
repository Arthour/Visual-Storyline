using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Storyline
{
    public partial class Characterfield : UserControl
    {
        public int ID;

        public Characterfield(int Index)
        {
            InitializeComponent();
            ID = Index;
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
            EditCharacterFields.deletedID = ID;
            this.Dispose();
        }
    }
}
