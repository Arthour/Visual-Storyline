namespace Visual_Storyline.Characters.Characterfield_options
{
    partial class Colorpaletteoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Colorpaletteoptions));
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.textcolor = new System.Windows.Forms.CheckBox();
            this.backgroundcolor = new System.Windows.Forms.CheckBox();
            this.colorbox = new System.Windows.Forms.CheckBox();
            this.DefaultColor = new System.Windows.Forms.ColorDialog();
            this.selectDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // textcolor
            // 
            resources.ApplyResources(this.textcolor, "textcolor");
            this.textcolor.Name = "textcolor";
            this.textcolor.UseVisualStyleBackColor = true;
            this.textcolor.CheckedChanged += new System.EventHandler(this.CheckChecked);
            // 
            // backgroundcolor
            // 
            resources.ApplyResources(this.backgroundcolor, "backgroundcolor");
            this.backgroundcolor.Name = "backgroundcolor";
            this.backgroundcolor.UseVisualStyleBackColor = true;
            this.backgroundcolor.CheckedChanged += new System.EventHandler(this.CheckChecked);
            // 
            // colorbox
            // 
            resources.ApplyResources(this.colorbox, "colorbox");
            this.colorbox.Name = "colorbox";
            this.colorbox.UseVisualStyleBackColor = true;
            this.colorbox.CheckedChanged += new System.EventHandler(this.CheckChecked);
            // 
            // DefaultColor
            // 
            this.DefaultColor.FullOpen = true;
            // 
            // selectDefault
            // 
            resources.ApplyResources(this.selectDefault, "selectDefault");
            this.selectDefault.Name = "selectDefault";
            this.selectDefault.UseVisualStyleBackColor = true;
            this.selectDefault.Click += new System.EventHandler(this.selectDefault_Click);
            // 
            // Colorpaletteoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.selectDefault);
            this.Controls.Add(this.colorbox);
            this.Controls.Add(this.backgroundcolor);
            this.Controls.Add(this.textcolor);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Colorpaletteoptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.CheckBox textcolor;
        private System.Windows.Forms.CheckBox backgroundcolor;
        private System.Windows.Forms.CheckBox colorbox;
        private System.Windows.Forms.ColorDialog DefaultColor;
        private System.Windows.Forms.Button selectDefault;
    }
}