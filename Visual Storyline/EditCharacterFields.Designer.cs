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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.addField = new System.Windows.Forms.Button();
            this.characterfield7 = new Visual_Storyline.Characterfield();
            this.characterfield6 = new Visual_Storyline.Characterfield();
            this.characterfield5 = new Visual_Storyline.Characterfield();
            this.characterfield4 = new Visual_Storyline.Characterfield();
            this.characterfield3 = new Visual_Storyline.Characterfield();
            this.characterfield2 = new Visual_Storyline.Characterfield();
            this.characterfield1 = new Visual_Storyline.Characterfield();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.characterfield7);
            this.panel1.Controls.Add(this.characterfield6);
            this.panel1.Controls.Add(this.characterfield5);
            this.panel1.Controls.Add(this.characterfield4);
            this.panel1.Controls.Add(this.characterfield3);
            this.panel1.Controls.Add(this.characterfield2);
            this.panel1.Controls.Add(this.characterfield1);
            this.panel1.Name = "panel1";
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
            // 
            // addField
            // 
            resources.ApplyResources(this.addField, "addField");
            this.addField.Name = "addField";
            this.addField.UseVisualStyleBackColor = true;
            // 
            // characterfield7
            // 
            resources.ApplyResources(this.characterfield7, "characterfield7");
            this.characterfield7.Name = "characterfield7";
            // 
            // characterfield6
            // 
            resources.ApplyResources(this.characterfield6, "characterfield6");
            this.characterfield6.Name = "characterfield6";
            // 
            // characterfield5
            // 
            resources.ApplyResources(this.characterfield5, "characterfield5");
            this.characterfield5.Name = "characterfield5";
            // 
            // characterfield4
            // 
            resources.ApplyResources(this.characterfield4, "characterfield4");
            this.characterfield4.Name = "characterfield4";
            // 
            // characterfield3
            // 
            resources.ApplyResources(this.characterfield3, "characterfield3");
            this.characterfield3.Name = "characterfield3";
            // 
            // characterfield2
            // 
            resources.ApplyResources(this.characterfield2, "characterfield2");
            this.characterfield2.Name = "characterfield2";
            // 
            // characterfield1
            // 
            resources.ApplyResources(this.characterfield1, "characterfield1");
            this.characterfield1.Name = "characterfield1";
            this.characterfield1.Load += new System.EventHandler(this.characterfield1_Load);
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
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCharacterFields";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button addField;
        private Characterfield characterfield7;
        private Characterfield characterfield6;
        private Characterfield characterfield5;
        private Characterfield characterfield4;
        private Characterfield characterfield3;
        private Characterfield characterfield2;
        private Characterfield characterfield1;
    }
}