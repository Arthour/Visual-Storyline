﻿using System;
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
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    string privateKey = RSA.ToXmlString(true);
/*
*   SAVE PRIVATE KEY (in Keychain)
*/
                    string publicKey= RSA.ToXmlString(false);
                    Console.WriteLine("Created encryption keys");
                    using (StreamWriter sw = new StreamWriter(ProjectFile, true))
                    {
                        sw.WriteLine("<{0}><{1}><{2}><{3}>", System.DateTime.UtcNow, System.DateTime.UtcNow, ProjectName.Text, Variables.ProgramInfo);
                        sw.WriteLine(publicKey);
                        sw.Close();
                    }
                    Console.WriteLine("Created project file and saved basic data");
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