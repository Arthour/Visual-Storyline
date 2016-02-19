namespace Visual_Storyline.Characterfield_options
{
    partial class DateTimeoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateTimeoptions));
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.showYears = new System.Windows.Forms.CheckBox();
            this.invisYears = new System.Windows.Forms.Panel();
            this.yearsPanel = new System.Windows.Forms.Panel();
            this.negative = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultElement = new System.Windows.Forms.ComboBox();
            this.nothing = new System.Windows.Forms.RadioButton();
            this.addSuffix = new System.Windows.Forms.RadioButton();
            this.addPrefix = new System.Windows.Forms.RadioButton();
            this.delete = new System.Windows.Forms.Button();
            this.add_Element = new System.Windows.Forms.Button();
            this.addElement_text = new System.Windows.Forms.TextBox();
            this.presuffix_list = new System.Windows.Forms.ListBox();
            this.showMonths = new System.Windows.Forms.CheckBox();
            this.invisMonths = new System.Windows.Forms.Panel();
            this.monthsPanel = new System.Windows.Forms.Panel();
            this.showDays = new System.Windows.Forms.CheckBox();
            this.invisDays = new System.Windows.Forms.Panel();
            this.daysPanel = new System.Windows.Forms.Panel();
            this.showHours = new System.Windows.Forms.CheckBox();
            this.invisHours = new System.Windows.Forms.Panel();
            this.hoursPanel = new System.Windows.Forms.Panel();
            this.showMinutes = new System.Windows.Forms.CheckBox();
            this.invisMinutes = new System.Windows.Forms.Panel();
            this.minutesPanel = new System.Windows.Forms.Panel();
            this.showSeconds = new System.Windows.Forms.CheckBox();
            this.invisSeconds = new System.Windows.Forms.Panel();
            this.secondsPanel = new System.Windows.Forms.Panel();
            this.FormatPanel = new System.Windows.Forms.Panel();
            this.timetable = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.yearsPanel.SuspendLayout();
            this.SuspendLayout();
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
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.showYears);
            this.flowLayoutPanel2.Controls.Add(this.invisYears);
            this.flowLayoutPanel2.Controls.Add(this.yearsPanel);
            this.flowLayoutPanel2.Controls.Add(this.showMonths);
            this.flowLayoutPanel2.Controls.Add(this.invisMonths);
            this.flowLayoutPanel2.Controls.Add(this.monthsPanel);
            this.flowLayoutPanel2.Controls.Add(this.showDays);
            this.flowLayoutPanel2.Controls.Add(this.invisDays);
            this.flowLayoutPanel2.Controls.Add(this.daysPanel);
            this.flowLayoutPanel2.Controls.Add(this.showHours);
            this.flowLayoutPanel2.Controls.Add(this.invisHours);
            this.flowLayoutPanel2.Controls.Add(this.hoursPanel);
            this.flowLayoutPanel2.Controls.Add(this.showMinutes);
            this.flowLayoutPanel2.Controls.Add(this.invisMinutes);
            this.flowLayoutPanel2.Controls.Add(this.minutesPanel);
            this.flowLayoutPanel2.Controls.Add(this.showSeconds);
            this.flowLayoutPanel2.Controls.Add(this.invisSeconds);
            this.flowLayoutPanel2.Controls.Add(this.secondsPanel);
            this.flowLayoutPanel2.Controls.Add(this.FormatPanel);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // showYears
            // 
            resources.ApplyResources(this.showYears, "showYears");
            this.flowLayoutPanel2.SetFlowBreak(this.showYears, true);
            this.showYears.Name = "showYears";
            this.showYears.UseVisualStyleBackColor = true;
            this.showYears.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisYears
            // 
            resources.ApplyResources(this.invisYears, "invisYears");
            this.invisYears.Name = "invisYears";
            // 
            // yearsPanel
            // 
            resources.ApplyResources(this.yearsPanel, "yearsPanel");
            this.yearsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.yearsPanel.Controls.Add(this.negative);
            this.yearsPanel.Controls.Add(this.label1);
            this.yearsPanel.Controls.Add(this.defaultElement);
            this.yearsPanel.Controls.Add(this.nothing);
            this.yearsPanel.Controls.Add(this.addSuffix);
            this.yearsPanel.Controls.Add(this.addPrefix);
            this.yearsPanel.Controls.Add(this.delete);
            this.yearsPanel.Controls.Add(this.add_Element);
            this.yearsPanel.Controls.Add(this.addElement_text);
            this.yearsPanel.Controls.Add(this.presuffix_list);
            this.flowLayoutPanel2.SetFlowBreak(this.yearsPanel, true);
            this.yearsPanel.Name = "yearsPanel";
            // 
            // negative
            // 
            resources.ApplyResources(this.negative, "negative");
            this.negative.Name = "negative";
            this.negative.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // defaultElement
            // 
            resources.ApplyResources(this.defaultElement, "defaultElement");
            this.defaultElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultElement.FormattingEnabled = true;
            this.defaultElement.Items.AddRange(new object[] {
            resources.GetString("defaultElement.Items")});
            this.defaultElement.Name = "defaultElement";
            // 
            // nothing
            // 
            resources.ApplyResources(this.nothing, "nothing");
            this.nothing.Name = "nothing";
            this.nothing.TabStop = true;
            this.nothing.UseVisualStyleBackColor = true;
            this.nothing.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // addSuffix
            // 
            resources.ApplyResources(this.addSuffix, "addSuffix");
            this.addSuffix.Name = "addSuffix";
            this.addSuffix.TabStop = true;
            this.addSuffix.UseVisualStyleBackColor = true;
            this.addSuffix.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // addPrefix
            // 
            resources.ApplyResources(this.addPrefix, "addPrefix");
            this.addPrefix.Name = "addPrefix";
            this.addPrefix.TabStop = true;
            this.addPrefix.UseVisualStyleBackColor = true;
            this.addPrefix.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Image = global::Visual_Storyline.Properties.Resources.action_Cancel_16xSM;
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
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
            // presuffix_list
            // 
            resources.ApplyResources(this.presuffix_list, "presuffix_list");
            this.presuffix_list.FormattingEnabled = true;
            this.presuffix_list.Name = "presuffix_list";
            this.presuffix_list.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // showMonths
            // 
            resources.ApplyResources(this.showMonths, "showMonths");
            this.flowLayoutPanel2.SetFlowBreak(this.showMonths, true);
            this.showMonths.Name = "showMonths";
            this.showMonths.UseVisualStyleBackColor = true;
            this.showMonths.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisMonths
            // 
            resources.ApplyResources(this.invisMonths, "invisMonths");
            this.invisMonths.Name = "invisMonths";
            // 
            // monthsPanel
            // 
            resources.ApplyResources(this.monthsPanel, "monthsPanel");
            this.monthsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel2.SetFlowBreak(this.monthsPanel, true);
            this.monthsPanel.Name = "monthsPanel";
            // 
            // showDays
            // 
            resources.ApplyResources(this.showDays, "showDays");
            this.flowLayoutPanel2.SetFlowBreak(this.showDays, true);
            this.showDays.Name = "showDays";
            this.showDays.UseVisualStyleBackColor = true;
            this.showDays.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisDays
            // 
            resources.ApplyResources(this.invisDays, "invisDays");
            this.invisDays.Name = "invisDays";
            // 
            // daysPanel
            // 
            resources.ApplyResources(this.daysPanel, "daysPanel");
            this.daysPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel2.SetFlowBreak(this.daysPanel, true);
            this.daysPanel.Name = "daysPanel";
            // 
            // showHours
            // 
            resources.ApplyResources(this.showHours, "showHours");
            this.flowLayoutPanel2.SetFlowBreak(this.showHours, true);
            this.showHours.Name = "showHours";
            this.showHours.UseVisualStyleBackColor = true;
            this.showHours.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisHours
            // 
            resources.ApplyResources(this.invisHours, "invisHours");
            this.invisHours.Name = "invisHours";
            // 
            // hoursPanel
            // 
            resources.ApplyResources(this.hoursPanel, "hoursPanel");
            this.hoursPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel2.SetFlowBreak(this.hoursPanel, true);
            this.hoursPanel.Name = "hoursPanel";
            // 
            // showMinutes
            // 
            resources.ApplyResources(this.showMinutes, "showMinutes");
            this.flowLayoutPanel2.SetFlowBreak(this.showMinutes, true);
            this.showMinutes.Name = "showMinutes";
            this.showMinutes.UseVisualStyleBackColor = true;
            this.showMinutes.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisMinutes
            // 
            resources.ApplyResources(this.invisMinutes, "invisMinutes");
            this.invisMinutes.Name = "invisMinutes";
            // 
            // minutesPanel
            // 
            resources.ApplyResources(this.minutesPanel, "minutesPanel");
            this.minutesPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel2.SetFlowBreak(this.minutesPanel, true);
            this.minutesPanel.Name = "minutesPanel";
            // 
            // showSeconds
            // 
            resources.ApplyResources(this.showSeconds, "showSeconds");
            this.flowLayoutPanel2.SetFlowBreak(this.showSeconds, true);
            this.showSeconds.Name = "showSeconds";
            this.showSeconds.UseVisualStyleBackColor = true;
            this.showSeconds.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // invisSeconds
            // 
            resources.ApplyResources(this.invisSeconds, "invisSeconds");
            this.invisSeconds.Name = "invisSeconds";
            // 
            // secondsPanel
            // 
            resources.ApplyResources(this.secondsPanel, "secondsPanel");
            this.secondsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel2.SetFlowBreak(this.secondsPanel, true);
            this.secondsPanel.Name = "secondsPanel";
            // 
            // FormatPanel
            // 
            resources.ApplyResources(this.FormatPanel, "FormatPanel");
            this.FormatPanel.BackColor = System.Drawing.Color.Red;
            this.FormatPanel.Name = "FormatPanel";
            // 
            // timetable
            // 
            resources.ApplyResources(this.timetable, "timetable");
            this.timetable.Name = "timetable";
            this.timetable.UseVisualStyleBackColor = true;
            this.timetable.Click += new System.EventHandler(this.timetable_Click);
            // 
            // DateTimeoptions
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ControlBox = false;
            this.Controls.Add(this.timetable);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateTimeoptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.yearsPanel.ResumeLayout(false);
            this.yearsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox showYears;
        private System.Windows.Forms.CheckBox showMonths;
        private System.Windows.Forms.Panel invisMonths;
        private System.Windows.Forms.Panel monthsPanel;
        private System.Windows.Forms.CheckBox showDays;
        private System.Windows.Forms.Panel invisDays;
        private System.Windows.Forms.Panel daysPanel;
        private System.Windows.Forms.CheckBox showHours;
        private System.Windows.Forms.Panel invisHours;
        private System.Windows.Forms.Panel hoursPanel;
        private System.Windows.Forms.Panel yearsPanel;
        private System.Windows.Forms.Panel invisYears;
        private System.Windows.Forms.CheckBox showMinutes;
        private System.Windows.Forms.CheckBox showSeconds;
        private System.Windows.Forms.Panel invisSeconds;
        private System.Windows.Forms.Panel secondsPanel;
        private System.Windows.Forms.Panel invisMinutes;
        private System.Windows.Forms.Panel minutesPanel;
        private System.Windows.Forms.Panel FormatPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox defaultElement;
        private System.Windows.Forms.RadioButton nothing;
        private System.Windows.Forms.RadioButton addSuffix;
        private System.Windows.Forms.RadioButton addPrefix;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add_Element;
        private System.Windows.Forms.TextBox addElement_text;
        private System.Windows.Forms.ListBox presuffix_list;
        private System.Windows.Forms.CheckBox negative;
        private System.Windows.Forms.Button timetable;
    }
}