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
using System.Security.Cryptography;
using System.Xml;

namespace Visual_Storyline
{
    public partial class New : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int CharSave = 1, LocSave = 1;

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
                RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally };
                RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally };

                if (ProjectName.Text != "" && ProjectLocation.Text != "" && LocButtons.Any() && CharButtons.Any())
                {
                OK.Enabled = true;
                }
            }
        }

        private void New_Load(object sender, EventArgs e)
        {

        }

        private void OK_Check()
        {
            if(encr_check.Checked)
            {
                if (pw_text.Text == "")
                    OK.Enabled = false;
                else if (pw_text.Text != "")
                    OK.Enabled = true;
            }
            else { OK.Enabled = true; }
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
            explorerdialog.SelectedPath = Properties.Settings.Default.Projectpath;
            if (explorerdialog.ShowDialog() == DialogResult.OK)
            {
                ProjectLocation.Text = explorerdialog.SelectedPath;
                Properties.Settings.Default.Projectpath = explorerdialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void propertyChanged(object sender, EventArgs e)
        {
            RadioButton[] LocButtons = new RadioButton[] { loclocally, locglobally };
            RadioButton[] CharButtons = new RadioButton[] { charlocally, charglobally };
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
            Variables.currentPath = ProjectPath;
            string ProjectFolder = Path.Combine(ProjectPath, ProjectName.Text);
            Variables.currentFolder = ProjectFolder;
            string ProjectFile = ProjectFolder + "\\" + ProjectName.Text + ".vsl";
            Variables.currentFile = ProjectFile;
            DirectoryInfo dirinfo = new DirectoryInfo(ProjectFolder);


            var StandardUnicode = new Regex(@"^[a-zA-Z0-9_\b]+");
            if (StandardUnicode.IsMatch(ProjectName.Text))
            {
                Console.WriteLine("ProjectName accepted: {0}", ProjectName.Text);
                try
                {
                    Path.GetFullPath(ProjectLocation.Text);
                    Console.WriteLine("ProjectLocation accepted: {0}, Input was: {1}", ProjectPath, ProjectLocation.Text);
                    if (Directory.Exists(ProjectPath))
                    {
                        Console.WriteLine("Directory already exists, proceeding");
                    }
                    else
                    {
                        Console.WriteLine("Trying to create the directory");
                        Directory.CreateDirectory(ProjectPath);
                        Console.WriteLine("Success");
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
                            Console.WriteLine("User chose to cancel overwriting");
                            return;
                        }
                    }
                    else if (Directory.Exists(ProjectFolder) && !Directory.EnumerateFileSystemEntries(ProjectFolder).Any())
                    {
                        Console.WriteLine("Folder exists without files");
                    }
                    else if (!Directory.Exists(ProjectFolder))
                    {
                        Console.WriteLine("Trying to create the project folder");
                        Directory.CreateDirectory(ProjectFolder);
                        Console.WriteLine("Success");
                    }

                    Variables.SaveOptionChar = CharSave;
                    Variables.SaveOptionLoc = LocSave;

                    string metadata = "<metadata><version>" + Variables.Version + @"</version><created>" + System.DateTime.UtcNow + @"</created><modified>" + System.DateTime.UtcNow + @"</modified><name>" + ProjectName.Text + @"</name><description>" + ProjectDescription.Text + @"</description></metadata>";
                    string saveoptions = "<saveoptions><characters>" + CharSave + @"</characters><locations>" + LocSave + @"</locations><customcolors>1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1</customcolors></saveoptions>";
                    using (StreamWriter sw = new StreamWriter(ProjectFile, true))
                    {
                        sw.WriteLine(Program.Encode(metadata));
                        sw.WriteLine(Program.Encode(saveoptions));
                        sw.Close();
                    }
                    Console.WriteLine("Created project file and saved basic data");
                    this.Dispose();
                    Console.WriteLine("Project creation form closed");
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

            if (CharSave == 2)
            {
                if (!Directory.Exists(Path.Combine(Variables.VSL, "GlobalSavedata")))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Path.Combine(Variables.VSL, "GlobalSavedata"));
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                else if(File.Exists(Path.Combine(Variables.VSL, "GlobalSavedata", "Characters.dat")))
                {
                    string line;
                    XmlDocument xml = new XmlDocument();
                    Variables.CharacterFields.Clear();
                    using (StreamReader sr = new StreamReader(Path.Combine(Variables.VSL, "GlobalSavedata", "Characters.dat")))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            xml.LoadXml(Program.Decode(line));
                            XmlNodeList xmllist = xml.SelectNodes("/Characterfields/characterfield");
                            foreach (XmlNode node in xmllist)
                            { Variables.CharacterFields.Add("<characterfield>" + node.InnerXml + "</characterfield>"); }
                        }
                    }
                }
            }
        }

        private void charlocally_CheckedChanged(object sender, EventArgs e)
        {
            CharSave = 1;
        }

        private void charglobally_CheckedChanged(object sender, EventArgs e)
        {
            CharSave = 2;
        }

        private void loclocally_CheckedChanged(object sender, EventArgs e)
        {
            LocSave = 1;
        }

        private void locglobally_CheckedChanged(object sender, EventArgs e)
        {
            LocSave = 2;
        }

        private void pw_changed(object sender, EventArgs e)
        {
            OK_Check();
        }

        private void encr_checked(object sender, EventArgs e)
        {
            if (encr_check.Checked)
            {
                pw_text.Enabled = true;
            }
            else { pw_text.Enabled = false; }
            OK_Check();
        }

    }
}