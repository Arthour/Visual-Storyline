namespace Visual_Storyline.Characters.Characterfield_options
{
    partial class Pictureoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pictureoptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tiff = new System.Windows.Forms.CheckBox();
            this.bmp = new System.Windows.Forms.CheckBox();
            this.gif = new System.Windows.Forms.CheckBox();
            this.png = new System.Windows.Forms.CheckBox();
            this.jpg = new System.Windows.Forms.CheckBox();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.height = new System.Windows.Forms.TextBox();
            this.dpmode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unit = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tiff);
            this.groupBox1.Controls.Add(this.bmp);
            this.groupBox1.Controls.Add(this.gif);
            this.groupBox1.Controls.Add(this.png);
            this.groupBox1.Controls.Add(this.jpg);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tiff
            // 
            resources.ApplyResources(this.tiff, "tiff");
            this.tiff.Name = "tiff";
            this.tiff.UseVisualStyleBackColor = true;
            this.tiff.CheckedChanged += new System.EventHandler(this.CheckSelection);
            // 
            // bmp
            // 
            resources.ApplyResources(this.bmp, "bmp");
            this.bmp.Name = "bmp";
            this.bmp.UseVisualStyleBackColor = true;
            this.bmp.CheckedChanged += new System.EventHandler(this.CheckSelection);
            // 
            // gif
            // 
            resources.ApplyResources(this.gif, "gif");
            this.gif.Name = "gif";
            this.gif.UseVisualStyleBackColor = true;
            this.gif.CheckedChanged += new System.EventHandler(this.CheckSelection);
            // 
            // png
            // 
            resources.ApplyResources(this.png, "png");
            this.png.Name = "png";
            this.png.UseVisualStyleBackColor = true;
            this.png.CheckedChanged += new System.EventHandler(this.CheckSelection);
            // 
            // jpg
            // 
            resources.ApplyResources(this.jpg, "jpg");
            this.jpg.Name = "jpg";
            this.jpg.UseVisualStyleBackColor = true;
            this.jpg.CheckedChanged += new System.EventHandler(this.CheckSelection);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.height);
            this.groupBox2.Controls.Add(this.dpmode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.width);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.unit);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // height
            // 
            resources.ApplyResources(this.height, "height");
            this.height.Name = "height";
            this.height.TextChanged += new System.EventHandler(this.CheckText);
            this.height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyHandle);
            // 
            // dpmode
            // 
            this.dpmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpmode.FormattingEnabled = true;
            this.dpmode.Items.AddRange(new object[] {
            resources.GetString("dpmode.Items"),
            resources.GetString("dpmode.Items1"),
            resources.GetString("dpmode.Items2"),
            resources.GetString("dpmode.Items3")});
            resources.ApplyResources(this.dpmode, "dpmode");
            this.dpmode.Name = "dpmode";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // width
            // 
            resources.ApplyResources(this.width, "width");
            this.width.Name = "width";
            this.width.TextChanged += new System.EventHandler(this.CheckText);
            this.width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyHandle);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // unit
            // 
            this.unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit.FormattingEnabled = true;
            this.unit.Items.AddRange(new object[] {
            resources.GetString("unit.Items"),
            resources.GetString("unit.Items1"),
            resources.GetString("unit.Items2"),
            resources.GetString("unit.Items3")});
            resources.ApplyResources(this.unit, "unit");
            this.unit.Name = "unit";
            this.unit.SelectedIndexChanged += new System.EventHandler(this.UnitChanged);
            // 
            // Pictureoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pictureoptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox tiff;
        private System.Windows.Forms.CheckBox bmp;
        private System.Windows.Forms.CheckBox gif;
        private System.Windows.Forms.CheckBox png;
        private System.Windows.Forms.CheckBox jpg;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox height;
        private System.Windows.Forms.ComboBox dpmode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox unit;
    }
}