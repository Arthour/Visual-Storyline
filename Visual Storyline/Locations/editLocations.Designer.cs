namespace Visual_Storyline.Locations
{
    partial class EditLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLocations));
            this.addLocation = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // addLocation
            // 
            resources.ApplyResources(this.addLocation, "addLocation");
            this.addLocation.Name = "addLocation";
            this.addLocation.UseVisualStyleBackColor = true;
            this.addLocation.Click += new System.EventHandler(this.addLocation_Click);
            // 
            // OK
            // 
            resources.ApplyResources(this.OK, "OK");
            this.OK.Name = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // locationPanel
            // 
            resources.ApplyResources(this.locationPanel, "locationPanel");
            this.locationPanel.Name = "locationPanel";
            // 
            // EditLocations
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.addLocation);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLocations";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addLocation;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Panel locationPanel;
    }
}