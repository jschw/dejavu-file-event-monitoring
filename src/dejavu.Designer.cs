using System.Diagnostics;

namespace dejavu_sharp
{
    partial class dejavu
    {
        // Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;

        // Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        // Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        // Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dejavu));
            this.SystrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartMon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdStart = new System.Windows.Forms.Button();
            this.DGVEvents = new System.Windows.Forms.DataGridView();
            this.fileicon = new System.Windows.Forms.DataGridViewImageColumn();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aenderung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.showPath = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.TSLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ContextSysTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEvents)).BeginInit();
            this.ContextEvents.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // SystrayIcon
            // 
            this.SystrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SystrayIcon.BalloonTipText = "Test\r\n";
            this.SystrayIcon.ContextMenuStrip = this.ContextSysTray;
            this.SystrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SystrayIcon.Icon")));
            this.SystrayIcon.Text = "DejaVu - Monitoring inaktiv";
            this.SystrayIcon.Visible = true;
            this.SystrayIcon.BalloonTipClicked += new System.EventHandler(this.SystrayIcon_BalloonTipClicked);
            this.SystrayIcon.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // ContextSysTray
            // 
            this.ContextSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuStartMon,
            this.menuQuit});
            this.ContextSysTray.Name = "ContextMenuStrip1";
            this.ContextSysTray.Size = new System.Drawing.Size(174, 70);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(173, 22);
            this.menuOpen.Text = "Öffnen";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuStartMon
            // 
            this.menuStartMon.Name = "menuStartMon";
            this.menuStartMon.Size = new System.Drawing.Size(173, 22);
            this.menuStartMon.Text = "Monitoring starten";
            this.menuStartMon.Click += new System.EventHandler(this.menuStartMon_Click);
            // 
            // menuQuit
            // 
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(173, 22);
            this.menuQuit.Text = "Beenden";
            this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdStart.Enabled = false;
            this.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStart.ForeColor = System.Drawing.Color.White;
            this.cmdStart.Location = new System.Drawing.Point(379, 21);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(127, 27);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Monitoring starten";
            this.cmdStart.UseVisualStyleBackColor = false;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // DGVEvents
            // 
            this.DGVEvents.AllowUserToAddRows = false;
            this.DGVEvents.AllowUserToDeleteRows = false;
            this.DGVEvents.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.DGVEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileicon,
            this.fname,
            this.aenderung,
            this.zeit,
            this.fullpath,
            this.folderflag,
            this.deleteflag});
            this.DGVEvents.ContextMenuStrip = this.ContextEvents;
            this.DGVEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVEvents.Location = new System.Drawing.Point(0, 67);
            this.DGVEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVEvents.Name = "DGVEvents";
            this.DGVEvents.ReadOnly = true;
            this.DGVEvents.RowHeadersVisible = false;
            this.DGVEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVEvents.Size = new System.Drawing.Size(810, 496);
            this.DGVEvents.TabIndex = 5;
            this.DGVEvents.DoubleClick += new System.EventHandler(this.DGVEvents_DoubleClick);
            // 
            // fileicon
            // 
            this.fileicon.HeaderText = "Dateityp";
            this.fileicon.Name = "fileicon";
            this.fileicon.ReadOnly = true;
            this.fileicon.Width = 70;
            // 
            // fname
            // 
            this.fname.HeaderText = "Dateiname";
            this.fname.Name = "fname";
            this.fname.ReadOnly = true;
            this.fname.Width = 200;
            // 
            // aenderung
            // 
            this.aenderung.HeaderText = "Änderung";
            this.aenderung.Name = "aenderung";
            this.aenderung.ReadOnly = true;
            this.aenderung.Width = 250;
            // 
            // zeit
            // 
            this.zeit.HeaderText = "Zeit";
            this.zeit.Name = "zeit";
            this.zeit.ReadOnly = true;
            // 
            // fullpath
            // 
            this.fullpath.HeaderText = "Gesamter Pfad";
            this.fullpath.Name = "fullpath";
            this.fullpath.ReadOnly = true;
            this.fullpath.Visible = false;
            // 
            // folderflag
            // 
            this.folderflag.HeaderText = "Folder-Flag";
            this.folderflag.Name = "folderflag";
            this.folderflag.ReadOnly = true;
            this.folderflag.Visible = false;
            // 
            // deleteflag
            // 
            this.deleteflag.HeaderText = "Gelöscht-Flag";
            this.deleteflag.Name = "deleteflag";
            this.deleteflag.ReadOnly = true;
            this.deleteflag.Visible = false;
            // 
            // ContextEvents
            // 
            this.ContextEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.openFolder,
            this.showPath,
            this.deleteEntry});
            this.ContextEvents.Name = "ContextEvents";
            this.ContextEvents.Size = new System.Drawing.Size(210, 92);
            this.ContextEvents.Opening += new System.ComponentModel.CancelEventHandler(this.ContextEvents_Opening);
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(209, 22);
            this.open.Text = "Öffnen";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openFolder
            // 
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(209, 22);
            this.openFolder.Text = "Ordner öffnen";
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // showPath
            // 
            this.showPath.Name = "showPath";
            this.showPath.Size = new System.Drawing.Size(209, 22);
            this.showPath.Text = "Völlständigen Pfad zeigen";
            this.showPath.Click += new System.EventHandler(this.showPath_Click);
            // 
            // deleteEntry
            // 
            this.deleteEntry.Name = "deleteEntry";
            this.deleteEntry.Size = new System.Drawing.Size(209, 22);
            this.deleteEntry.Text = "Eintrag entfernen";
            this.deleteEntry.Click += new System.EventHandler(this.deleteEntry_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.ForeColor = System.Drawing.Color.White;
            this.cmdSettings.Location = new System.Drawing.Point(514, 21);
            this.cmdSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(98, 27);
            this.cmdSettings.TabIndex = 6;
            this.cmdSettings.Text = "Einstellungen";
            this.cmdSettings.UseVisualStyleBackColor = false;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.picHelp);
            this.Panel1.Controls.Add(this.cmdClose);
            this.Panel1.Controls.Add(this.cmdSettings);
            this.Panel1.Controls.Add(this.cmdStart);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(810, 67);
            this.Panel1.TabIndex = 7;
            // 
            // Panel2
            // 
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Panel2.Location = new System.Drawing.Point(4, 2);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(128, 62);
            this.Panel2.TabIndex = 9;
            // 
            // picHelp
            // 
            this.picHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHelp.BackgroundImage")));
            this.picHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelp.Location = new System.Drawing.Point(765, 21);
            this.picHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(29, 27);
            this.picHelp.TabIndex = 8;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(620, 21);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(139, 27);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Fenster Schließen";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSLabelStatus});
            this.StatusBar.Location = new System.Drawing.Point(0, 563);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(810, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 8;
            this.StatusBar.Text = "StatusStrip1";
            // 
            // TSLabelStatus
            // 
            this.TSLabelStatus.ForeColor = System.Drawing.Color.White;
            this.TSLabelStatus.Name = "TSLabelStatus";
            this.TSLabelStatus.Size = new System.Drawing.Size(155, 17);
            this.TSLabelStatus.Text = "Status: Monitoring gestoppt";
            // 
            // dejavu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 585);
            this.Controls.Add(this.DGVEvents);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(826, 623);
            this.Name = "dejavu";
            this.Text = "DéjàVu Filemonitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DejaVu_FormClosing);
            this.LocationChanged += new System.EventHandler(this.DejaVu_LocationChanged);
            this.Resize += new System.EventHandler(this.DejaVu_Resize);
            this.ContextSysTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEvents)).EndInit();
            this.ContextEvents.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal NotifyIcon SystrayIcon;
        internal ContextMenuStrip ContextSysTray;
        internal ToolStripMenuItem menuOpen;
        internal Button cmdStart;
        internal DataGridView DGVEvents;
        internal ToolStripMenuItem menuStartMon;
        internal ToolStripMenuItem menuQuit;
        internal Button cmdSettings;
        internal Panel Panel1;
        internal Button cmdClose;
        internal StatusStrip StatusBar;
        internal ToolStripStatusLabel TSLabelStatus;
        internal PictureBox picHelp;
        internal DataGridViewImageColumn fileicon;
        internal DataGridViewTextBoxColumn fname;
        internal DataGridViewTextBoxColumn aenderung;
        internal DataGridViewTextBoxColumn zeit;
        internal DataGridViewTextBoxColumn fullpath;
        internal DataGridViewTextBoxColumn folderflag;
        internal DataGridViewTextBoxColumn deleteflag;
        internal ContextMenuStrip ContextEvents;
        internal ToolStripMenuItem open;
        internal ToolStripMenuItem openFolder;
        internal ToolStripMenuItem deleteEntry;
        internal ToolStripMenuItem showPath;
        internal Panel Panel2;

    }
}