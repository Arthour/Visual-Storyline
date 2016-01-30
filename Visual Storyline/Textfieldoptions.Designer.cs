namespace Visual_Storyline
{
    partial class Textfieldoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Textfieldoptions));
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.maxchars = new System.Windows.Forms.Label();
            this.maxchars_text = new System.Windows.Forms.TextBox();
            this.allowmultiline = new System.Windows.Forms.Label();
            this.allowMultiline_check = new System.Windows.Forms.CheckBox();
            this.acceptedinput = new System.Windows.Forms.Label();
            this.acceptedinput_groupbox = new System.Windows.Forms.CheckedListBox();
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
            // maxchars
            // 
            resources.ApplyResources(this.maxchars, "maxchars");
            this.maxchars.Name = "maxchars";
            // 
            // maxchars_text
            // 
            resources.ApplyResources(this.maxchars_text, "maxchars_text");
            this.maxchars_text.Name = "maxchars_text";
            this.maxchars_text.Click += new System.EventHandler(this.FormEvent);
            this.maxchars_text.TextChanged += new System.EventHandler(this.FormEvent);
            this.maxchars_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Char_KeyInput);
            // 
            // allowmultiline
            // 
            resources.ApplyResources(this.allowmultiline, "allowmultiline");
            this.allowmultiline.Name = "allowmultiline";
            // 
            // allowMultiline_check
            // 
            resources.ApplyResources(this.allowMultiline_check, "allowMultiline_check");
            this.allowMultiline_check.Name = "allowMultiline_check";
            this.allowMultiline_check.UseVisualStyleBackColor = true;
            // 
            // acceptedinput
            // 
            resources.ApplyResources(this.acceptedinput, "acceptedinput");
            this.acceptedinput.Name = "acceptedinput";
            // 
            // acceptedinput_groupbox
            // 
            this.acceptedinput_groupbox.CheckOnClick = true;
            this.acceptedinput_groupbox.FormattingEnabled = true;
            this.acceptedinput_groupbox.Items.AddRange(new object[] {
            resources.GetString("acceptedinput_groupbox.Items"),
            resources.GetString("acceptedinput_groupbox.Items1"),
            resources.GetString("acceptedinput_groupbox.Items2"),
            resources.GetString("acceptedinput_groupbox.Items3")});
            resources.ApplyResources(this.acceptedinput_groupbox, "acceptedinput_groupbox");
            this.acceptedinput_groupbox.Name = "acceptedinput_groupbox";
            this.acceptedinput_groupbox.Click += new System.EventHandler(this.FormEvent);
            this.acceptedinput_groupbox.SelectedIndexChanged += new System.EventHandler(this.FormEvent);
            this.acceptedinput_groupbox.Validated += new System.EventHandler(this.FormEvent);
            // 
            // Textfieldoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.acceptedinput_groupbox);
            this.Controls.Add(this.acceptedinput);
            this.Controls.Add(this.allowMultiline_check);
            this.Controls.Add(this.allowmultiline);
            this.Controls.Add(this.maxchars_text);
            this.Controls.Add(this.maxchars);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Textfieldoptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label maxchars;
        private System.Windows.Forms.TextBox maxchars_text;
        private System.Windows.Forms.Label allowmultiline;
        private System.Windows.Forms.CheckBox allowMultiline_check;
        private System.Windows.Forms.Label acceptedinput;
        private System.Windows.Forms.CheckedListBox acceptedinput_groupbox;
    }
}