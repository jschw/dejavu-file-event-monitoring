using System.Diagnostics;

namespace dejavu_sharp
{
    partial class settings
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

        // Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        // Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        // Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.checkNotifiaction = new System.Windows.Forms.CheckBox();
            this.comboNumEvents = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.checkSave = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdAbbr = new System.Windows.Forms.Button();
            this.checkSubdirs1 = new System.Windows.Forms.CheckBox();
            this.checkActive1 = new System.Windows.Forms.CheckBox();
            this.cmdPath1 = new System.Windows.Forms.Button();
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.checkSubdirs2 = new System.Windows.Forms.CheckBox();
            this.checkActive2 = new System.Windows.Forms.CheckBox();
            this.cmdPath2 = new System.Windows.Forms.Button();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.checkSubdirs3 = new System.Windows.Forms.CheckBox();
            this.checkActive3 = new System.Windows.Forms.CheckBox();
            this.cmdPath3 = new System.Windows.Forms.Button();
            this.txtPath3 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSlot1 = new System.Windows.Forms.TabPage();
            this.tabSlot2 = new System.Windows.Forms.TabPage();
            this.tabSlot3 = new System.Windows.Forms.TabPage();
            this.GroupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSlot1.SuspendLayout();
            this.tabSlot2.SuspendLayout();
            this.tabSlot3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 162);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(578, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Zur Verzeichnisüberwachung stehen insgesamt 3 voneinander unabhängige Monitoring-" +
    "Slots zur Verfügung.";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.checkNotifiaction);
            this.GroupBox1.Controls.Add(this.comboNumEvents);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.checkSave);
            this.GroupBox1.Location = new System.Drawing.Point(18, 15);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Size = new System.Drawing.Size(620, 129);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Allgemeine Einstellungen";
            // 
            // checkNotifiaction
            // 
            this.checkNotifiaction.AutoSize = true;
            this.checkNotifiaction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkNotifiaction.Location = new System.Drawing.Point(10, 93);
            this.checkNotifiaction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkNotifiaction.Name = "checkNotifiaction";
            this.checkNotifiaction.Size = new System.Drawing.Size(321, 19);
            this.checkNotifiaction.TabIndex = 3;
            this.checkNotifiaction.Text = "Meldung im Infobereich bei neuen Ereignissen anzeigen";
            this.checkNotifiaction.UseVisualStyleBackColor = true;
            // 
            // comboNumEvents
            // 
            this.comboNumEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNumEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboNumEvents.FormattingEnabled = true;
            this.comboNumEvents.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.comboNumEvents.Location = new System.Drawing.Point(226, 27);
            this.comboNumEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboNumEvents.Name = "comboNumEvents";
            this.comboNumEvents.Size = new System.Drawing.Size(87, 23);
            this.comboNumEvents.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 30);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(188, 15);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Anzahl der angezeigten Ereignisse:";
            // 
            // checkSave
            // 
            this.checkSave.AutoSize = true;
            this.checkSave.Checked = true;
            this.checkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkSave.Location = new System.Drawing.Point(10, 68);
            this.checkSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkSave.Name = "checkSave";
            this.checkSave.Size = new System.Drawing.Size(325, 19);
            this.checkSave.TabIndex = 0;
            this.checkSave.Text = "Aktivitäten-Log bei Herunterfahren/Abmelden speichern";
            this.checkSave.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.ForeColor = System.Drawing.Color.White;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(18, 455);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(91, 27);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click_1);
            // 
            // cmdAbbr
            // 
            this.cmdAbbr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdAbbr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbbr.ForeColor = System.Drawing.Color.White;
            this.cmdAbbr.Location = new System.Drawing.Point(134, 455);
            this.cmdAbbr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdAbbr.Name = "cmdAbbr";
            this.cmdAbbr.Size = new System.Drawing.Size(91, 27);
            this.cmdAbbr.TabIndex = 7;
            this.cmdAbbr.Text = "Abbrechen";
            this.cmdAbbr.UseVisualStyleBackColor = false;
            this.cmdAbbr.Click += new System.EventHandler(this.cmdAbbr_Click_1);
            // 
            // checkSubdirs1
            // 
            this.checkSubdirs1.AutoSize = true;
            this.checkSubdirs1.Location = new System.Drawing.Point(10, 88);
            this.checkSubdirs1.Name = "checkSubdirs1";
            this.checkSubdirs1.Size = new System.Drawing.Size(192, 19);
            this.checkSubdirs1.TabIndex = 10;
            this.checkSubdirs1.Text = "Unterverzeichnisse überwachen";
            this.checkSubdirs1.UseVisualStyleBackColor = true;
            // 
            // checkActive1
            // 
            this.checkActive1.AutoSize = true;
            this.checkActive1.Location = new System.Drawing.Point(10, 17);
            this.checkActive1.Name = "checkActive1";
            this.checkActive1.Size = new System.Drawing.Size(159, 19);
            this.checkActive1.TabIndex = 9;
            this.checkActive1.Text = "Slot 1 als aktiv markieren.";
            this.checkActive1.UseVisualStyleBackColor = true;
            this.checkActive1.CheckedChanged += new System.EventHandler(this.checkActive1_CheckedChanged);
            // 
            // cmdPath1
            // 
            this.cmdPath1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdPath1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPath1.ForeColor = System.Drawing.Color.White;
            this.cmdPath1.Location = new System.Drawing.Point(373, 48);
            this.cmdPath1.Name = "cmdPath1";
            this.cmdPath1.Size = new System.Drawing.Size(107, 27);
            this.cmdPath1.TabIndex = 8;
            this.cmdPath1.Text = "Ordner wählen";
            this.cmdPath1.UseVisualStyleBackColor = false;
            this.cmdPath1.Click += new System.EventHandler(this.cmdPath1_Click);
            // 
            // txtPath1
            // 
            this.txtPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath1.Enabled = false;
            this.txtPath1.Location = new System.Drawing.Point(10, 49);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.ReadOnly = true;
            this.txtPath1.Size = new System.Drawing.Size(348, 23);
            this.txtPath1.TabIndex = 1;
            // 
            // checkSubdirs2
            // 
            this.checkSubdirs2.AutoSize = true;
            this.checkSubdirs2.Location = new System.Drawing.Point(10, 88);
            this.checkSubdirs2.Name = "checkSubdirs2";
            this.checkSubdirs2.Size = new System.Drawing.Size(192, 19);
            this.checkSubdirs2.TabIndex = 14;
            this.checkSubdirs2.Text = "Unterverzeichnisse überwachen";
            this.checkSubdirs2.UseVisualStyleBackColor = true;
            // 
            // checkActive2
            // 
            this.checkActive2.AutoSize = true;
            this.checkActive2.Location = new System.Drawing.Point(10, 17);
            this.checkActive2.Name = "checkActive2";
            this.checkActive2.Size = new System.Drawing.Size(159, 19);
            this.checkActive2.TabIndex = 13;
            this.checkActive2.Text = "Slot 2 als aktiv markieren.";
            this.checkActive2.UseVisualStyleBackColor = true;
            this.checkActive2.CheckedChanged += new System.EventHandler(this.checkActive2_CheckedChanged);
            // 
            // cmdPath2
            // 
            this.cmdPath2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdPath2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPath2.ForeColor = System.Drawing.Color.White;
            this.cmdPath2.Location = new System.Drawing.Point(373, 48);
            this.cmdPath2.Name = "cmdPath2";
            this.cmdPath2.Size = new System.Drawing.Size(107, 27);
            this.cmdPath2.TabIndex = 12;
            this.cmdPath2.Text = "Ordner wählen";
            this.cmdPath2.UseVisualStyleBackColor = false;
            this.cmdPath2.Click += new System.EventHandler(this.cmdPath2_Click);
            // 
            // txtPath2
            // 
            this.txtPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath2.Enabled = false;
            this.txtPath2.Location = new System.Drawing.Point(10, 49);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.ReadOnly = true;
            this.txtPath2.Size = new System.Drawing.Size(348, 23);
            this.txtPath2.TabIndex = 11;
            // 
            // checkSubdirs3
            // 
            this.checkSubdirs3.AutoSize = true;
            this.checkSubdirs3.Location = new System.Drawing.Point(10, 88);
            this.checkSubdirs3.Name = "checkSubdirs3";
            this.checkSubdirs3.Size = new System.Drawing.Size(192, 19);
            this.checkSubdirs3.TabIndex = 14;
            this.checkSubdirs3.Text = "Unterverzeichnisse überwachen";
            this.checkSubdirs3.UseVisualStyleBackColor = true;
            // 
            // checkActive3
            // 
            this.checkActive3.AutoSize = true;
            this.checkActive3.Location = new System.Drawing.Point(10, 17);
            this.checkActive3.Name = "checkActive3";
            this.checkActive3.Size = new System.Drawing.Size(159, 19);
            this.checkActive3.TabIndex = 13;
            this.checkActive3.Text = "Slot 3 als aktiv markieren.";
            this.checkActive3.UseVisualStyleBackColor = true;
            this.checkActive3.CheckedChanged += new System.EventHandler(this.checkActive3_CheckedChanged);
            // 
            // cmdPath3
            // 
            this.cmdPath3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdPath3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPath3.ForeColor = System.Drawing.Color.White;
            this.cmdPath3.Location = new System.Drawing.Point(373, 48);
            this.cmdPath3.Name = "cmdPath3";
            this.cmdPath3.Size = new System.Drawing.Size(107, 27);
            this.cmdPath3.TabIndex = 12;
            this.cmdPath3.Text = "Ordner wählen";
            this.cmdPath3.UseVisualStyleBackColor = false;
            this.cmdPath3.Click += new System.EventHandler(this.cmdPath3_Click);
            // 
            // txtPath3
            // 
            this.txtPath3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath3.Enabled = false;
            this.txtPath3.Location = new System.Drawing.Point(10, 49);
            this.txtPath3.Name = "txtPath3";
            this.txtPath3.ReadOnly = true;
            this.txtPath3.Size = new System.Drawing.Size(348, 23);
            this.txtPath3.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSlot1);
            this.tabControl1.Controls.Add(this.tabSlot2);
            this.tabControl1.Controls.Add(this.tabSlot3);
            this.tabControl1.Location = new System.Drawing.Point(14, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 256);
            this.tabControl1.TabIndex = 8;
            // 
            // tabSlot1
            // 
            this.tabSlot1.Controls.Add(this.checkActive1);
            this.tabSlot1.Controls.Add(this.txtPath1);
            this.tabSlot1.Controls.Add(this.cmdPath1);
            this.tabSlot1.Controls.Add(this.checkSubdirs1);
            this.tabSlot1.Location = new System.Drawing.Point(4, 24);
            this.tabSlot1.Name = "tabSlot1";
            this.tabSlot1.Padding = new System.Windows.Forms.Padding(3);
            this.tabSlot1.Size = new System.Drawing.Size(616, 228);
            this.tabSlot1.TabIndex = 0;
            this.tabSlot1.Text = "Slot 1";
            this.tabSlot1.UseVisualStyleBackColor = true;
            // 
            // tabSlot2
            // 
            this.tabSlot2.Controls.Add(this.checkActive2);
            this.tabSlot2.Controls.Add(this.txtPath2);
            this.tabSlot2.Controls.Add(this.cmdPath2);
            this.tabSlot2.Controls.Add(this.checkSubdirs2);
            this.tabSlot2.Location = new System.Drawing.Point(4, 24);
            this.tabSlot2.Name = "tabSlot2";
            this.tabSlot2.Padding = new System.Windows.Forms.Padding(3);
            this.tabSlot2.Size = new System.Drawing.Size(616, 228);
            this.tabSlot2.TabIndex = 1;
            this.tabSlot2.Text = "Slot 2";
            this.tabSlot2.UseVisualStyleBackColor = true;
            // 
            // tabSlot3
            // 
            this.tabSlot3.Controls.Add(this.checkActive3);
            this.tabSlot3.Controls.Add(this.txtPath3);
            this.tabSlot3.Controls.Add(this.cmdPath3);
            this.tabSlot3.Controls.Add(this.checkSubdirs3);
            this.tabSlot3.Location = new System.Drawing.Point(4, 24);
            this.tabSlot3.Name = "tabSlot3";
            this.tabSlot3.Padding = new System.Windows.Forms.Padding(3);
            this.tabSlot3.Size = new System.Drawing.Size(616, 228);
            this.tabSlot3.TabIndex = 2;
            this.tabSlot3.Text = "Slot 3";
            this.tabSlot3.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 495);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdAbbr);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSlot1.ResumeLayout(false);
            this.tabSlot1.PerformLayout();
            this.tabSlot2.ResumeLayout(false);
            this.tabSlot2.PerformLayout();
            this.tabSlot3.ResumeLayout(false);
            this.tabSlot3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Label Label1;
        internal GroupBox GroupBox1;
        internal ComboBox comboNumEvents;
        internal Label Label2;
        internal CheckBox checkSave;
        internal Button cmdOK;
        internal Button cmdAbbr;
        internal CheckBox checkNotifiaction;
        internal CheckBox checkSubdirs1;
        internal CheckBox checkActive1;
        internal Button cmdPath1;
        internal TextBox txtPath1;
        internal CheckBox checkSubdirs2;
        internal CheckBox checkActive2;
        internal Button cmdPath2;
        internal TextBox txtPath2;
        internal CheckBox checkSubdirs3;
        internal CheckBox checkActive3;
        internal Button cmdPath3;
        internal TextBox txtPath3;
        private TabControl tabControl1;
        private TabPage tabSlot1;
        private TabPage tabSlot2;
        private TabPage tabSlot3;
    }

    #endregion
}