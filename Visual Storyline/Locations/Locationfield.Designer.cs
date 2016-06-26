namespace Visual_Storyline.Locations
{
    partial class Locationfield
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Locationfield));
            this.name_label = new System.Windows.Forms.Label();
            this.locname = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.partof_label = new System.Windows.Forms.Label();
            this.partof = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // name_label
            // 
            resources.ApplyResources(this.name_label, "name_label");
            this.name_label.Name = "name_label";
            // 
            // locname
            // 
            resources.ApplyResources(this.locname, "locname");
            this.locname.Name = "locname";
            // 
            // description_label
            // 
            resources.ApplyResources(this.description_label, "description_label");
            this.description_label.Name = "description_label";
            // 
            // description
            // 
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // partof_label
            // 
            resources.ApplyResources(this.partof_label, "partof_label");
            this.partof_label.Name = "partof_label";
            // 
            // partof
            // 
            resources.ApplyResources(this.partof, "partof");
            this.partof.Name = "partof";
            // 
            // delete
            // 
            this.delete.Image = global::Visual_Storyline.Properties.Resources.action_Cancel_16xSM;
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            this.edit.Image = global::Visual_Storyline.Properties.Resources.EditorZone_6025;
            resources.ApplyResources(this.edit, "edit");
            this.edit.Name = "edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.HighlightText;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picture, "picture");
            this.picture.Name = "picture";
            this.picture.TabStop = false;
            // 
            // Locationfield
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.partof);
            this.Controls.Add(this.partof_label);
            this.Controls.Add(this.description);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.locname);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.picture);
            this.DoubleBuffered = true;
            this.Name = "Locationfield";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        public System.Windows.Forms.Label locname;
        public System.Windows.Forms.Label partof_label;
        public System.Windows.Forms.Label partof;
        public System.Windows.Forms.PictureBox picture;
        public System.Windows.Forms.TextBox description;
    }
}
