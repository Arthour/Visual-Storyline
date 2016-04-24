namespace Visual_Storyline.Characterfield_options
{
    partial class RichTextboxoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RichTextboxoptions));
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.font = new System.Windows.Forms.Label();
            this.color_check = new System.Windows.Forms.CheckBox();
            this.font_box = new System.Windows.Forms.ComboBox();
            this.color = new System.Windows.Forms.Label();
            this.fontsize = new System.Windows.Forms.Label();
            this.fontsize_check = new System.Windows.Forms.CheckBox();
            this.bold = new System.Windows.Forms.Label();
            this.bold_check = new System.Windows.Forms.CheckBox();
            this.italic = new System.Windows.Forms.Label();
            this.italic_check = new System.Windows.Forms.CheckBox();
            this.underlined = new System.Windows.Forms.Label();
            this.underlined_check = new System.Windows.Forms.CheckBox();
            this.bunumb = new System.Windows.Forms.Label();
            this.bunumb_check = new System.Windows.Forms.CheckBox();
            this.group_align = new System.Windows.Forms.GroupBox();
            this.align_justify = new System.Windows.Forms.CheckBox();
            this.align_right = new System.Windows.Forms.CheckBox();
            this.align_center = new System.Windows.Forms.CheckBox();
            this.align_left = new System.Windows.Forms.CheckBox();
            this.required = new System.Windows.Forms.Label();
            this.required_check = new System.Windows.Forms.CheckBox();
            this.group_align.SuspendLayout();
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
            // font
            // 
            resources.ApplyResources(this.font, "font");
            this.font.Name = "font";
            // 
            // color_check
            // 
            resources.ApplyResources(this.color_check, "color_check");
            this.color_check.Name = "color_check";
            this.color_check.UseVisualStyleBackColor = true;
            // 
            // font_box
            // 
            this.font_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.font_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.font_box.FormattingEnabled = true;
            resources.ApplyResources(this.font_box, "font_box");
            this.font_box.Name = "font_box";
            this.font_box.TextUpdate += new System.EventHandler(this.FrameEvent);
            // 
            // color
            // 
            resources.ApplyResources(this.color, "color");
            this.color.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.color.Name = "color";
            // 
            // fontsize
            // 
            resources.ApplyResources(this.fontsize, "fontsize");
            this.fontsize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fontsize.Name = "fontsize";
            // 
            // fontsize_check
            // 
            resources.ApplyResources(this.fontsize_check, "fontsize_check");
            this.fontsize_check.Name = "fontsize_check";
            this.fontsize_check.UseVisualStyleBackColor = true;
            // 
            // bold
            // 
            resources.ApplyResources(this.bold, "bold");
            this.bold.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bold.Name = "bold";
            // 
            // bold_check
            // 
            resources.ApplyResources(this.bold_check, "bold_check");
            this.bold_check.Name = "bold_check";
            this.bold_check.UseVisualStyleBackColor = true;
            // 
            // italic
            // 
            resources.ApplyResources(this.italic, "italic");
            this.italic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.italic.Name = "italic";
            // 
            // italic_check
            // 
            resources.ApplyResources(this.italic_check, "italic_check");
            this.italic_check.Name = "italic_check";
            this.italic_check.UseVisualStyleBackColor = true;
            // 
            // underlined
            // 
            resources.ApplyResources(this.underlined, "underlined");
            this.underlined.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.underlined.Name = "underlined";
            // 
            // underlined_check
            // 
            resources.ApplyResources(this.underlined_check, "underlined_check");
            this.underlined_check.Name = "underlined_check";
            this.underlined_check.UseVisualStyleBackColor = true;
            // 
            // bunumb
            // 
            resources.ApplyResources(this.bunumb, "bunumb");
            this.bunumb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunumb.Name = "bunumb";
            // 
            // bunumb_check
            // 
            resources.ApplyResources(this.bunumb_check, "bunumb_check");
            this.bunumb_check.Name = "bunumb_check";
            this.bunumb_check.UseVisualStyleBackColor = true;
            // 
            // group_align
            // 
            this.group_align.Controls.Add(this.align_justify);
            this.group_align.Controls.Add(this.align_right);
            this.group_align.Controls.Add(this.align_center);
            this.group_align.Controls.Add(this.align_left);
            resources.ApplyResources(this.group_align, "group_align");
            this.group_align.Name = "group_align";
            this.group_align.TabStop = false;
            // 
            // align_justify
            // 
            resources.ApplyResources(this.align_justify, "align_justify");
            this.align_justify.Name = "align_justify";
            this.align_justify.UseVisualStyleBackColor = true;
            this.align_justify.CheckedChanged += new System.EventHandler(this.FrameEvent);
            // 
            // align_right
            // 
            resources.ApplyResources(this.align_right, "align_right");
            this.align_right.Name = "align_right";
            this.align_right.UseVisualStyleBackColor = true;
            this.align_right.CheckedChanged += new System.EventHandler(this.FrameEvent);
            // 
            // align_center
            // 
            resources.ApplyResources(this.align_center, "align_center");
            this.align_center.Name = "align_center";
            this.align_center.UseVisualStyleBackColor = true;
            this.align_center.CheckedChanged += new System.EventHandler(this.FrameEvent);
            // 
            // align_left
            // 
            resources.ApplyResources(this.align_left, "align_left");
            this.align_left.Name = "align_left";
            this.align_left.UseVisualStyleBackColor = true;
            this.align_left.CheckedChanged += new System.EventHandler(this.FrameEvent);
            // 
            // required
            // 
            resources.ApplyResources(this.required, "required");
            this.required.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.required.Name = "required";
            // 
            // required_check
            // 
            resources.ApplyResources(this.required_check, "required_check");
            this.required_check.Name = "required_check";
            this.required_check.UseVisualStyleBackColor = true;
            // 
            // RichTextboxoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.required);
            this.Controls.Add(this.required_check);
            this.Controls.Add(this.group_align);
            this.Controls.Add(this.bunumb);
            this.Controls.Add(this.bunumb_check);
            this.Controls.Add(this.underlined);
            this.Controls.Add(this.underlined_check);
            this.Controls.Add(this.italic);
            this.Controls.Add(this.italic_check);
            this.Controls.Add(this.bold);
            this.Controls.Add(this.bold_check);
            this.Controls.Add(this.fontsize);
            this.Controls.Add(this.fontsize_check);
            this.Controls.Add(this.color);
            this.Controls.Add(this.font_box);
            this.Controls.Add(this.color_check);
            this.Controls.Add(this.font);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RichTextboxoptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.group_align.ResumeLayout(false);
            this.group_align.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label font;
        private System.Windows.Forms.CheckBox color_check;
        private System.Windows.Forms.ComboBox font_box;
        private System.Windows.Forms.Label color;
        private System.Windows.Forms.Label fontsize;
        private System.Windows.Forms.CheckBox fontsize_check;
        private System.Windows.Forms.Label bold;
        private System.Windows.Forms.CheckBox bold_check;
        private System.Windows.Forms.Label italic;
        private System.Windows.Forms.CheckBox italic_check;
        private System.Windows.Forms.Label underlined;
        private System.Windows.Forms.CheckBox underlined_check;
        private System.Windows.Forms.Label bunumb;
        private System.Windows.Forms.CheckBox bunumb_check;
        private System.Windows.Forms.GroupBox group_align;
        private System.Windows.Forms.CheckBox align_justify;
        private System.Windows.Forms.CheckBox align_right;
        private System.Windows.Forms.CheckBox align_center;
        private System.Windows.Forms.CheckBox align_left;
        private System.Windows.Forms.Label required;
        private System.Windows.Forms.CheckBox required_check;
    }
}