namespace Visual_Storyline
{
    partial class VisualStoryline
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualStoryline));
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.New = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripSplitButton();
            this.SaveSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveasSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Characters = new System.Windows.Forms.ToolStripDropDownButton();
            this.addChar = new System.Windows.Forms.ToolStripMenuItem();
            this.editChar = new System.Windows.Forms.ToolStripMenuItem();
            this.editFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Locations = new System.Windows.Forms.ToolStripDropDownButton();
            this.addLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.editLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.Strands = new System.Windows.Forms.ToolStripDropDownButton();
            this.addStrand = new System.Windows.Forms.ToolStripMenuItem();
            this.editStrand = new System.Windows.Forms.ToolStripMenuItem();
            this.Chapters = new System.Windows.Forms.ToolStripDropDownButton();
            this.addChapt = new System.Windows.Forms.ToolStripMenuItem();
            this.editChapt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Featurelist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addQuest = new System.Windows.Forms.ToolStripButton();
            this.addRelation = new System.Windows.Forms.ToolStripButton();
            this.addEvent = new System.Windows.Forms.ToolStripButton();
            this.Settings = new System.Windows.Forms.ToolStripButton();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Save,
            this.Open,
            this.Export,
            this.toolStripSeparator1,
            this.Characters,
            this.Locations,
            this.Strands,
            this.Chapters,
            this.toolStripSeparator2,
            this.Featurelist,
            this.toolStripSeparator3,
            this.addQuest,
            this.addRelation,
            this.addEvent,
            this.Settings});
            resources.ApplyResources(this.Toolbar, "Toolbar");
            this.Toolbar.Name = "Toolbar";
            // 
            // New
            // 
            this.New.Image = global::Visual_Storyline.Properties.Resources.NewRequest_8796;
            resources.ApplyResources(this.New, "New");
            this.New.Name = "New";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Save
            // 
            this.Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSubmenu,
            this.SaveasSubmenu});
            this.Save.Image = global::Visual_Storyline.Properties.Resources.Save_6530;
            resources.ApplyResources(this.Save, "Save");
            this.Save.Name = "Save";
            // 
            // SaveSubmenu
            // 
            this.SaveSubmenu.Name = "SaveSubmenu";
            resources.ApplyResources(this.SaveSubmenu, "SaveSubmenu");
            // 
            // SaveasSubmenu
            // 
            this.SaveasSubmenu.Name = "SaveasSubmenu";
            resources.ApplyResources(this.SaveasSubmenu, "SaveasSubmenu");
            // 
            // Open
            // 
            this.Open.Image = global::Visual_Storyline.Properties.Resources.Open_6529;
            resources.ApplyResources(this.Open, "Open");
            this.Open.Name = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Export
            // 
            this.Export.Image = global::Visual_Storyline.Properties.Resources.PrintSetup_11011;
            resources.ApplyResources(this.Export, "Export");
            this.Export.Name = "Export";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // Characters
            // 
            this.Characters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChar,
            this.editChar,
            this.editFieldsToolStripMenuItem});
            this.Characters.Image = global::Visual_Storyline.Properties.Resources.user_32xLG;
            resources.ApplyResources(this.Characters, "Characters");
            this.Characters.Name = "Characters";
            // 
            // addChar
            // 
            this.addChar.Image = global::Visual_Storyline.Properties.Resources.AddMark_10580;
            this.addChar.Name = "addChar";
            resources.ApplyResources(this.addChar, "addChar");
            // 
            // editChar
            // 
            this.editChar.Image = global::Visual_Storyline.Properties.Resources.EditorZone_6025;
            this.editChar.Name = "editChar";
            resources.ApplyResources(this.editChar, "editChar");
            // 
            // editFieldsToolStripMenuItem
            // 
            this.editFieldsToolStripMenuItem.Image = global::Visual_Storyline.Properties.Resources.Editdatasetwithdesigner_8449;
            this.editFieldsToolStripMenuItem.Name = "editFieldsToolStripMenuItem";
            resources.ApplyResources(this.editFieldsToolStripMenuItem, "editFieldsToolStripMenuItem");
            this.editFieldsToolStripMenuItem.Click += new System.EventHandler(this.editFieldsToolStripMenuItem_Click);
            // 
            // Locations
            // 
            this.Locations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLoc,
            this.editLoc});
            this.Locations.Image = global::Visual_Storyline.Properties.Resources.Area_16xLG;
            resources.ApplyResources(this.Locations, "Locations");
            this.Locations.Name = "Locations";
            // 
            // addLoc
            // 
            this.addLoc.Image = global::Visual_Storyline.Properties.Resources.AddMark_10580;
            this.addLoc.Name = "addLoc";
            resources.ApplyResources(this.addLoc, "addLoc");
            // 
            // editLoc
            // 
            this.editLoc.Image = global::Visual_Storyline.Properties.Resources.EditorZone_6025;
            this.editLoc.Name = "editLoc";
            resources.ApplyResources(this.editLoc, "editLoc");
            // 
            // Strands
            // 
            this.Strands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStrand,
            this.editStrand});
            this.Strands.Image = global::Visual_Storyline.Properties.Resources.thread_16xLG;
            resources.ApplyResources(this.Strands, "Strands");
            this.Strands.Name = "Strands";
            // 
            // addStrand
            // 
            this.addStrand.Image = global::Visual_Storyline.Properties.Resources.AddMark_10580;
            this.addStrand.Name = "addStrand";
            resources.ApplyResources(this.addStrand, "addStrand");
            // 
            // editStrand
            // 
            this.editStrand.Image = global::Visual_Storyline.Properties.Resources.EditorZone_6025;
            this.editStrand.Name = "editStrand";
            resources.ApplyResources(this.editStrand, "editStrand");
            // 
            // Chapters
            // 
            this.Chapters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChapt,
            this.editChapt});
            this.Chapters.Image = global::Visual_Storyline.Properties.Resources.book_Open_16xLG;
            resources.ApplyResources(this.Chapters, "Chapters");
            this.Chapters.Name = "Chapters";
            // 
            // addChapt
            // 
            this.addChapt.Image = global::Visual_Storyline.Properties.Resources.AddMark_10580;
            this.addChapt.Name = "addChapt";
            resources.ApplyResources(this.addChapt, "addChapt");
            // 
            // editChapt
            // 
            this.editChapt.Image = global::Visual_Storyline.Properties.Resources.EditorZone_6025;
            this.editChapt.Name = "editChapt";
            resources.ApplyResources(this.editChapt, "editChapt");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // Featurelist
            // 
            this.Featurelist.Image = global::Visual_Storyline.Properties.Resources.LightBulb_32xLG;
            resources.ApplyResources(this.Featurelist, "Featurelist");
            this.Featurelist.Name = "Featurelist";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // addQuest
            // 
            this.addQuest.Image = global::Visual_Storyline.Properties.Resources.AddButton;
            resources.ApplyResources(this.addQuest, "addQuest");
            this.addQuest.Name = "addQuest";
            // 
            // addRelation
            // 
            this.addRelation.Image = global::Visual_Storyline.Properties.Resources.AddInterface_5537;
            resources.ApplyResources(this.addRelation, "addRelation");
            this.addRelation.Name = "addRelation";
            // 
            // addEvent
            // 
            this.addEvent.Image = global::Visual_Storyline.Properties.Resources.ChangeQueryType_insertvalues_286;
            this.addEvent.Name = "addEvent";
            resources.ApplyResources(this.addEvent, "addEvent");
            this.addEvent.Click += new System.EventHandler(this.addCondition_Click);
            // 
            // Settings
            // 
            this.Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Settings.Image = global::Visual_Storyline.Properties.Resources.gear_32xLG;
            resources.ApplyResources(this.Settings, "Settings");
            this.Settings.Name = "Settings";
            // 
            // VisualStoryline
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Toolbar);
            this.Name = "VisualStoryline";
            this.Load += new System.EventHandler(this.VisualStoryline_Load);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Toolbar;
        private System.Windows.Forms.ToolStripButton New;
        private System.Windows.Forms.ToolStripSplitButton Save;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton Characters;
        private System.Windows.Forms.ToolStripDropDownButton Locations;
        private System.Windows.Forms.ToolStripDropDownButton Strands;
        private System.Windows.Forms.ToolStripDropDownButton Chapters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Featurelist;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton addQuest;
        private System.Windows.Forms.ToolStripButton addRelation;
        private System.Windows.Forms.ToolStripButton addEvent;
        private System.Windows.Forms.ToolStripButton Settings;
        private System.Windows.Forms.ToolStripMenuItem SaveSubmenu;
        private System.Windows.Forms.ToolStripMenuItem SaveasSubmenu;
        private System.Windows.Forms.ToolStripMenuItem addChar;
        private System.Windows.Forms.ToolStripMenuItem editChar;
        private System.Windows.Forms.ToolStripMenuItem addLoc;
        private System.Windows.Forms.ToolStripMenuItem editLoc;
        private System.Windows.Forms.ToolStripMenuItem addStrand;
        private System.Windows.Forms.ToolStripMenuItem editStrand;
        private System.Windows.Forms.ToolStripMenuItem addChapt;
        private System.Windows.Forms.ToolStripMenuItem editChapt;
        private System.Windows.Forms.ToolStripMenuItem editFieldsToolStripMenuItem;
    }
}

