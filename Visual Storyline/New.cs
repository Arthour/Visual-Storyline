using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Security;

namespace Visual_Storyline
{
    public partial class New : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public New()
        {
            InitializeComponent();
            ProjectLocation.Text = Variables.VSL;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally, locboth };
                RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally, charboth };

                if (ProjectName.Text != "" && ProjectLocation.Text != "" && LocButtons.Any() && CharButtons.Any())
                {
                OK.Enabled = true;
                }
            }
        }

        private void New_Load(object sender, EventArgs e)
        {

        }

        private void ProjectName_KeyInput(object sender, KeyPressEventArgs e)
        {
            var StandardUnicode = new Regex(@"^[^a-zA-Z0-9_\b]+");
            if (StandardUnicode.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void explorer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerdialog = new FolderBrowserDialog();
            explorerdialog.SelectedPath = Variables.VSL;
            if (explorerdialog.ShowDialog() == DialogResult.OK)
            {
                ProjectLocation.Text = explorerdialog.SelectedPath;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void propertyChanged(object sender, EventArgs e)
        {
            RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally, locboth };
            RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally, charboth };
            var StandardUnicode = new Regex(@"^[a-zA-Z0-9_\b]+");
            if (StandardUnicode.IsMatch(ProjectName.Text) && ProjectLocation.Text != "" && LocButtons.Any() && CharButtons.Any())
            {
                OK.Enabled = true;
            }
            else
            {
                OK.Enabled = false;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string ProjectPath = Path.GetFullPath(ProjectLocation.Text);
            string ProjectFolder = Path.Combine(ProjectPath, ProjectName.Text);
            DirectoryInfo dirinfo = new DirectoryInfo(ProjectFolder);

            var StandardUnicode = new Regex(@"^[a-zA-Z0-9_\b]+");
            if (StandardUnicode.IsMatch(ProjectName.Text))
            {
                Console.WriteLine("ProjectName accepted: {0}", ProjectName.Text);
                try
                {
                    Path.GetFullPath(ProjectLocation.Text);
                    Console.WriteLine("ProjectLocation accepted: {0}, Input was: {1}", ProjectPath, ProjectLocation.Text);
                    if (Directory.Exists(Path.GetFullPath(ProjectLocation.Text)))
                    {
                        Console.WriteLine("Directory already exists, proceeding");
                    }
                    else
                    {
                        Directory.CreateDirectory(ProjectPath);
                        Console.WriteLine("Trying to create the directory");
                    }
                    if (Directory.Exists(ProjectFolder) && Directory.EnumerateFileSystemEntries(ProjectFolder).Any())
                    {
                        ErrorMessages.FolderExistsWarning();
                        ErrorMessages.WarningTitle();
                        DialogResult result = MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        Console.WriteLine("Folder exists with files warning");
                        if (result == DialogResult.Yes)
                        {
                            Console.WriteLine("User chose to continue, {0}", ProjectFolder);

                            foreach (FileInfo file in dirinfo.GetFiles())
                            {
                                file.Delete();
                            }
                            foreach (DirectoryInfo dir in dirinfo.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (Directory.Exists(ProjectFolder) && !Directory.EnumerateFileSystemEntries(ProjectFolder).Any())
                    {
                        Console.WriteLine("Folder exists without files");
                    }
                    else if (!Directory.Exists(ProjectFolder))
                    {
                        Directory.CreateDirectory(Path.Combine(Path.GetFullPath(ProjectLocation.Text), ProjectName.Text));
                        Console.WriteLine("Trying to create the project folder");
                    }
                }
                catch (ArgumentException)
                {
                    ErrorMessages.ArgumentError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Argument Exception");
                }
                catch (SecurityException)
                {
                    ErrorMessages.SecurityError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Security Exception");
                }
                catch (NotSupportedException)
                {
                    ErrorMessages.NotSupportedError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Not supported Exception");
                }
                catch (PathTooLongException)
                {
                    ErrorMessages.TooLongError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Too long exception");
                }
                catch (IOException)
                {
                    ErrorMessages.IOError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("IO Exception");
                }
                catch (UnauthorizedAccessException)
                {
                    ErrorMessages.UnauthorizedError();
                    ErrorMessages.ErrorTitle();
                    MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Unauthorized Access Exception");
                }
            }
            else
            {
                ErrorMessages.NameError();
                ErrorMessages.ErrorTitle();
                MessageBox.Show(ErrorMessages.Message, ErrorMessages.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Name Error");
            }
        }
    }
}