namespace Visual_Storyline
{
    partial class Characterfield
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Characterfield));
            this.NameField = new System.Windows.Forms.TextBox();
            this.Type = new System.Windows.Forms.ComboBox();
            this.Options = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameField
            // 
            resources.ApplyResources(this.NameField, "NameField");
            this.NameField.Name = "NameField";
            this.NameField.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // Type
            // 
            this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type.Items.AddRange(new object[] {
            resources.GetString("Type.Items"),
            resources.GetString("Type.Items1"),
            resources.GetString("Type.Items2"),
            resources.GetString("Type.Items3"),
            resources.GetString("Type.Items4"),
            resources.GetString("Type.Items5"),
            resources.GetString("Type.Items6"),
            resources.GetString("Type.Items7"),
            resources.GetString("Type.Items8")});
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.SelectedIndexChanged += new System.EventHandler(this.Type_SelectedIndexChanged);
            // 
            // Options
            // 
            resources.ApplyResources(this.Options, "Options");
            this.Options.Name = "Options";
            this.Options.UseVisualStyleBackColor = true;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // Delete
            // 
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete.Image = global::Visual_Storyline.Properties.Resources.action_Cancel_16xSM;
            resources.ApplyResources(this.Delete, "Delete");
            this.Delete.Name = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Down
            // 
            this.Down.Image = global::Visual_Storyline.Properties.Resources.GlyphDown;
            resources.ApplyResources(this.Down, "Down");
            this.Down.Name = "Down";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // Up
            // 
            this.Up.Image = global::Visual_Storyline.Properties.Resources.GlyphUp;
            resources.ApplyResources(this.Up, "Up");
            this.Up.Name = "Up";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Characterfield
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.DoubleBuffered = true;
            this.Name = "Characterfield";
            this.Load += new System.EventHandler(this.Characterfield_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox NameField;
        public System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Button Options;
        private System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button Up;
        public System.Windows.Forms.Button Down;
    }
}
