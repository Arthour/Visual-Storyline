namespace Visual_Storyline
{
    partial class New
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New));
            this.charBox = new System.Windows.Forms.GroupBox();
            this.charglobally = new System.Windows.Forms.RadioButton();
            this.charlocally = new System.Windows.Forms.RadioButton();
            this.explorer = new System.Windows.Forms.Button();
            this.ProjectLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LocBox = new System.Windows.Forms.GroupBox();
            this.locglobally = new System.Windows.Forms.RadioButton();
            this.loclocally = new System.Windows.Forms.RadioButton();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.ProjectDescription = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.pw_text = new System.Windows.Forms.TextBox();
            this.encr = new System.Windows.Forms.Label();
            this.pw = new System.Windows.Forms.Label();
            this.encr_check = new System.Windows.Forms.CheckBox();
            this.charBox.SuspendLayout();
            this.LocBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // charBox
            // 
            resources.ApplyResources(this.charBox, "charBox");
            this.charBox.Controls.Add(this.charglobally);
            this.charBox.Controls.Add(this.charlocally);
            this.charBox.Name = "charBox";
            this.charBox.TabStop = false;
            // 
            // charglobally
            // 
            resources.ApplyResources(this.charglobally, "charglobally");
            this.charglobally.Name = "charglobally";
            this.charglobally.TabStop = true;
            this.charglobally.UseVisualStyleBackColor = true;
            this.charglobally.CheckedChanged += new System.EventHandler(this.charglobally_CheckedChanged);
            this.charglobally.Enter += new System.EventHandler(this.propertyChanged);
            // 
            // charlocally
            // 
            resources.ApplyResources(this.charlocally, "charlocally");
            this.charlocally.Checked = true;
            this.charlocally.Name = "charlocally";
            this.charlocally.TabStop = true;
            this.charlocally.UseVisualStyleBackColor = true;
            this.charlocally.CheckedChanged += new System.EventHandler(this.charlocally_CheckedChanged);
            this.charlocally.Enter += new System.EventHandler(this.propertyChanged);
            // 
            // explorer
            // 
            resources.ApplyResources(this.explorer, "explorer");
            this.explorer.Name = "explorer";
            this.explorer.UseVisualStyleBackColor = true;
            this.explorer.Click += new System.EventHandler(this.explorer_Click);
            // 
            // ProjectLocation
            // 
            resources.ApplyResources(this.ProjectLocation, "ProjectLocation");
            this.ProjectLocation.Name = "ProjectLocation";
            this.ProjectLocation.TextChanged += new System.EventHandler(this.propertyChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ProjectName
            // 
            resources.ApplyResources(this.ProjectName, "ProjectName");
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.TextChanged += new System.EventHandler(this.propertyChanged);
            this.ProjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectName_KeyInput);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LocBox
            // 
            resources.ApplyResources(this.LocBox, "LocBox");
            this.LocBox.Controls.Add(this.locglobally);
            this.LocBox.Controls.Add(this.loclocally);
            this.LocBox.Name = "LocBox";
            this.LocBox.TabStop = false;
            // 
            // locglobally
            // 
            resources.ApplyResources(this.locglobally, "locglobally");
            this.locglobally.Name = "locglobally";
            this.locglobally.TabStop = true;
            this.locglobally.UseVisualStyleBackColor = true;
            this.locglobally.CheckedChanged += new System.EventHandler(this.locglobally_CheckedChanged);
            this.locglobally.Enter += new System.EventHandler(this.propertyChanged);
            // 
            // loclocally
            // 
            resources.ApplyResources(this.loclocally, "loclocally");
            this.loclocally.Checked = true;
            this.loclocally.Name = "loclocally";
            this.loclocally.TabStop = true;
            this.loclocally.UseVisualStyleBackColor = true;
            this.loclocally.CheckedChanged += new System.EventHandler(this.loclocally_CheckedChanged);
            this.loclocally.Enter += new System.EventHandler(this.propertyChanged);
            // 
            // OK
            // 
            resources.ApplyResources(this.OK, "OK");
            this.OK.Name = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ProjectDescription
            // 
            this.ProjectDescription.AcceptsReturn = true;
            resources.ApplyResources(this.ProjectDescription, "ProjectDescription");
            this.ProjectDescription.AllowDrop = true;
            this.ProjectDescription.Name = "ProjectDescription";
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            // 
            // pw_text
            // 
            resources.ApplyResources(this.pw_text, "pw_text");
            this.pw_text.Name = "pw_text";
            this.pw_text.UseSystemPasswordChar = true;
            this.pw_text.TextChanged += new System.EventHandler(this.pw_changed);
            // 
            // encr
            // 
            resources.ApplyResources(this.encr, "encr");
            this.encr.Name = "encr";
            // 
            // pw
            // 
            resources.ApplyResources(this.pw, "pw");
            this.pw.Name = "pw";
            // 
            // encr_check
            // 
            resources.ApplyResources(this.encr_check, "encr_check");
            this.encr_check.Name = "encr_check";
            this.encr_check.UseVisualStyleBackColor = true;
            this.encr_check.CheckedChanged += new System.EventHandler(this.encr_checked);
            // 
            // New
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.encr_check);
            this.Controls.Add(this.pw);
            this.Controls.Add(this.encr);
            this.Controls.Add(this.pw_text);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.ProjectDescription);
            this.Controls.Add(this.charBox);
            this.Controls.Add(this.explorer);
            this.Controls.Add(this.ProjectLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocBox);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.New_Load);
            this.charBox.ResumeLayout(false);
            this.charBox.PerformLayout();
            this.LocBox.ResumeLayout(false);
            this.LocBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox charBox;
        private System.Windows.Forms.RadioButton charglobally;
        private System.Windows.Forms.RadioButton charlocally;
        private System.Windows.Forms.Button explorer;
        private System.Windows.Forms.TextBox ProjectLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox LocBox;
        private System.Windows.Forms.RadioButton locglobally;
        private System.Windows.Forms.RadioButton loclocally;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox ProjectDescription;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox pw_text;
        private System.Windows.Forms.Label encr;
        private System.Windows.Forms.Label pw;
        private System.Windows.Forms.CheckBox encr_check;
    }
}