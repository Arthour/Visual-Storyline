namespace Visual_Storyline.Characters.Characterfield_options
{
    partial class Listoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listoptions));
            this.delete = new System.Windows.Forms.Button();
            this.move_down = new System.Windows.Forms.Button();
            this.move_up = new System.Windows.Forms.Button();
            this.add_Element = new System.Windows.Forms.Button();
            this.addElement_text = new System.Windows.Forms.TextBox();
            this.listelements = new System.Windows.Forms.Label();
            this.listelements_list = new System.Windows.Forms.ListBox();
            this.ms_check = new System.Windows.Forms.CheckBox();
            this.ms = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Image = global::Visual_Storyline.Properties.Resources.action_Cancel_16xSM;
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // move_down
            // 
            resources.ApplyResources(this.move_down, "move_down");
            this.move_down.Image = global::Visual_Storyline.Properties.Resources.GlyphDown;
            this.move_down.Name = "move_down";
            this.move_down.UseVisualStyleBackColor = true;
            this.move_down.Click += new System.EventHandler(this.move_down_Click);
            // 
            // move_up
            // 
            resources.ApplyResources(this.move_up, "move_up");
            this.move_up.Image = global::Visual_Storyline.Properties.Resources.GlyphUp;
            this.move_up.Name = "move_up";
            this.move_up.UseVisualStyleBackColor = true;
            this.move_up.Click += new System.EventHandler(this.move_up_Click);
            // 
            // add_Element
            // 
            resources.ApplyResources(this.add_Element, "add_Element");
            this.add_Element.Image = global::Visual_Storyline.Properties.Resources.AddMark_10580;
            this.add_Element.Name = "add_Element";
            this.add_Element.UseVisualStyleBackColor = true;
            this.add_Element.Click += new System.EventHandler(this.add_Element_Click);
            // 
            // addElement_text
            // 
            resources.ApplyResources(this.addElement_text, "addElement_text");
            this.addElement_text.Name = "addElement_text";
            this.addElement_text.TextChanged += new System.EventHandler(this.TextFieldChanged);
            this.addElement_text.Enter += new System.EventHandler(this.FocusEnter);
            this.addElement_text.Leave += new System.EventHandler(this.FocusLeave);
            // 
            // listelements
            // 
            resources.ApplyResources(this.listelements, "listelements");
            this.listelements.Name = "listelements";
            // 
            // listelements_list
            // 
            resources.ApplyResources(this.listelements_list, "listelements_list");
            this.listelements_list.FormattingEnabled = true;
            this.listelements_list.Name = "listelements_list";
            this.listelements_list.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // ms_check
            // 
            resources.ApplyResources(this.ms_check, "ms_check");
            this.ms_check.Name = "ms_check";
            this.ms_check.UseVisualStyleBackColor = true;
            // 
            // ms
            // 
            resources.ApplyResources(this.ms, "ms");
            this.ms.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ms.Name = "ms";
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
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Listoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.move_down);
            this.Controls.Add(this.move_up);
            this.Controls.Add(this.add_Element);
            this.Controls.Add(this.addElement_text);
            this.Controls.Add(this.listelements);
            this.Controls.Add(this.listelements_list);
            this.Controls.Add(this.ms_check);
            this.Controls.Add(this.ms);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Listoptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listelements;
        private System.Windows.Forms.ListBox listelements_list;
        private System.Windows.Forms.CheckBox ms_check;
        private System.Windows.Forms.Label ms;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox addElement_text;
        private System.Windows.Forms.Button add_Element;
        private System.Windows.Forms.Button move_up;
        private System.Windows.Forms.Button move_down;
        private System.Windows.Forms.Button delete;
    }
}