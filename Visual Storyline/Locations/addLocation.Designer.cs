namespace Visual_Storyline.Locations
{
    partial class AddLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLocation));
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selpic = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.TextBox();
            this.parentLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.TextChanged += new System.EventHandler(this.NameChanged);
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Name = "label2";
            // 
            // selpic
            // 
            resources.ApplyResources(this.selpic, "selpic");
            this.selpic.Name = "selpic";
            this.selpic.UseVisualStyleBackColor = true;
            this.selpic.Click += new System.EventHandler(this.selpic_Click);
            // 
            // description
            // 
            this.description.AcceptsReturn = true;
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            // 
            // parentLocation
            // 
            resources.ApplyResources(this.parentLocation, "parentLocation");
            this.parentLocation.Name = "parentLocation";
            this.parentLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keyboardentry);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Name = "label3";
            // 
            // selpar
            // 
            resources.ApplyResources(this.selpar, "selpar");
            this.selpar.Name = "selpar";
            this.selpar.UseVisualStyleBackColor = true;
            this.selpar.Click += new System.EventHandler(this.selpar_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Name = "label4";
            // 
            // picture
            // 
            resources.ApplyResources(this.picture, "picture");
            this.picture.BackColor = System.Drawing.SystemColors.HighlightText;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Name = "picture";
            this.picture.TabStop = false;
            // 
            // AddLocation
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selpar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parentLocation);
            this.Controls.Add(this.description);
            this.Controls.Add(this.selpic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLocation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selpic;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox parentLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selpar;
        private System.Windows.Forms.Label label4;
    }
}