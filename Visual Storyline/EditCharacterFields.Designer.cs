namespace Visual_Storyline
{
    partial class EditCharacterFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCharacterFields));
            this.FieldPanel = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.addField = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FieldPanel
            // 
            resources.ApplyResources(this.FieldPanel, "FieldPanel");
            this.FieldPanel.Name = "FieldPanel";
            this.FieldPanel.Click += new System.EventHandler(this.FormEvent);
            this.FieldPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.controlRemoved);
            this.FieldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.UC_moved);
            this.FieldPanel.Validated += new System.EventHandler(this.FormEvent);
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            resources.ApplyResources(this.OK, "OK");
            this.OK.Name = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // addField
            // 
            resources.ApplyResources(this.addField, "addField");
            this.addField.Name = "addField";
            this.addField.UseVisualStyleBackColor = true;
            this.addField.Click += new System.EventHandler(this.addField_Click);
            // 
            // EditCharacterFields
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.addField);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.FieldPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCharacterFields";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Click += new System.EventHandler(this.FormEvent);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button addField;
        public System.Windows.Forms.Panel FieldPanel;
    }
}