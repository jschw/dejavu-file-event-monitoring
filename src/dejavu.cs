using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dejavu_sharp
{
    public partial class dejavu : Form
    {
        // =====================Bereich für FileWatcher-Aktionen
        public FileSystemWatcher watchfolder1;
        public FileSystemWatcher watchfolder2;
        public FileSystemWatcher watchfolder3;
        private delegate void SetTextMethod(string text);
        private delegate void AddNewRowMethod(object textArray, string path);
        public string last_time;
        public string last_change;
        public string last_path;
        public string last_name;
        public bool isFolder;
        public bool isDelete;
        public bool monitoring_running = false;
        public bool exitAppl = false;
        public Icon[] Icons = new Icon[3];
        // Einstellungsvariablen
        public int number_entries;
        public bool save_log;
        public bool show_notification;
        // Settings Slot1
        public bool slot1_active = false;
        public bool slot1_running = false;
        public string slot1_path = "";
        public bool slot1_subdirs = false;
        // Settings Slot2
        public bool slot2_active = false;
        public bool slot2_running = false;
        public string slot2_path = "";
        public bool slot2_subdirs;
        // Settings Slot3
        public bool slot3_active = false;
        public bool slot3_running = false;
        public string slot3_path = "";
        public bool slot3_subdirs = false;
        // Prüfvariablen für Slot-Zustände
        private bool slot1ok = false;
        private bool slot2ok = false;
        private bool slot3ok = false;

        settings settDialog;
        bool settDialogOpen;
        Point mMainLocation;

        protected override void SetVisibleCore(bool value)
        {
            if (!IsHandleCreated)
            {
                CreateHandle();
                Load_actions();
                value = false;
            }
            base.SetVisibleCore(value);
        }

        public dejavu()
        {
            InitializeComponent();

            watchfolder1 = new FileSystemWatcher();
            watchfolder2 = new FileSystemWatcher();
            watchfolder3 = new FileSystemWatcher();

            watchfolder1.SynchronizingObject = this;
            watchfolder2.SynchronizingObject = this;
            watchfolder3.SynchronizingObject = this;
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // Wenn das Systray-Icon doppelt angeklickt wird -> Hauptfenster öffnen
            Visible = true;
        }

        private void SystrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            // Wenn ein Ballon-Tip angeklickt wird -> Hauptfenster öffnen.
            Visible = true;
        }


        private void insertRow(string[] textArray, string path)
        {
            try
            {
                // watchfolder.EnableRaisingEvents = False
                DGVEvents.Rows.Insert(0, textArray);
                try
                {
                    var Img = new DataGridViewImageCell();
                    if (isFolder == false & isDelete == false)
                    {
                        var icon = Icon.ExtractAssociatedIcon(path);
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[0].Cells[0].Value = Img.Value;
                    }
                    else if (isDelete == true)
                    {
                        var icon = Properties.Resources.delete.ToBitmap();
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[0].Cells[0].Value = Img.Value;
                    }
                    else if (isFolder == true)
                    {
                        var icon = Properties.Resources.folder.ToBitmap();
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[0].Cells[0].Value = Img.Value;
                    }

                    // Ballon-Tip im Systray anzeigen, falls erwünscht
                    if (show_notification)
                    {
                        if (isFolder == false)
                        {
                            // Falls Datei
                            SystrayIcon.ShowBalloonTip(3000, "Änderung festgestellt", "Datei: " + textArray[1] + Constants.vbCrLf + "Änderung: " + textArray[2], ToolTipIcon.Info);

                        }
                        else if (isFolder)
                        {
                            // Falls Ordner
                            SystrayIcon.ShowBalloonTip(3000, "Änderung festgestellt", "Ordner: " + textArray[1] + Constants.vbCrLf + "Änderung: " + textArray[2], ToolTipIcon.Info);

                        }

                    }
                }

                catch (Exception ex)
                {

                }

                foreach (DataGridViewRow row in DGVEvents.Rows)
                    row.Height = 40;
            }
            finally
            {
                // watchfolder.EnableRaisingEvents = True
            }
        }

        private string getTime()
        {
            // Return System.DateTime.Now.Date & " " & System.DateTime.Now.Hour.ToString & ":" & System.DateTime.Now.Minute.ToString
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private string getTimeSeconds()
        {
            return DateTime.Now.Date.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void logchange(object source, FileSystemEventArgs e)
        {

            if (Path.GetExtension(e.FullPath) == ".tmp" | e.Name.Contains("~$"))
            {
                // Signatur für MS-Office Speichervorgänge
                return;
            }
            else if (Path.GetExtension(e.FullPath).Contains("#"))
            {
                // Signatur für LibreOffice/OOo-Speichervorgänge
                return;
            }
            else if (Path.GetExtension(e.FullPath).Contains("lock") | Path.GetExtension(e.FullPath).Contains("lck") | Path.GetExtension(e.FullPath).Contains("lockfile"))
            {
                // Signatur für diverse Temp-/Lockfiles
                return;
            }

            // Dateiname anpassen, falls es sich um einen Ordner in tieferer Ebene handelt
            string chName = "";
            if (e.Name.Contains(@"\"))
            {
                var path_complete = e.Name.Split('\\');
                chName = path_complete[path_complete.Length - 1];
            }
            else
            {
                chName = e.Name;
            }

            if (last_change == e.ChangeType.ToString() && last_path  == e.FullPath.ToString() && last_time == getTimeSeconds())
            {
                return;
            }
            else if (Convert.ToInt32(last_change) == 8 && last_time == getTimeSeconds())
            {
                // Falls der letzte ChangeType eine Umbenennung war
                return;
            }
            else if (Convert.ToInt32(last_change) == 1 && last_time == getTimeSeconds() && last_name == chName)
            {
                // Falls der letzte ChangeType eine Erstellung war
                return;
            }

            // Checken, ob die Datei keine Endung hat und ob es ein Verzeichnis ist und die Änderung nicht löschen war
            if (string.IsNullOrEmpty(Path.GetExtension(e.FullPath)) & !((int)e.ChangeType == 2))
            {
                if (Directory.Exists(e.FullPath))
                {
                    // Wenn es ein Ordner ist, entsprechende Aktion ausführen
                    isFolder = true;
                }
                else
                {
                    // Falls es eine Datei ohne Endung ist, abbrechen
                    return;
                }
            }

            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                // SetText("File " & e.FullPath & " has been modified")
                isDelete = false;
                var array = new string[] { null, chName, "Speicherung", getTime(), e.FullPath, isFolder.ToString(), isDelete.ToString() };
                insertRow(array, e.FullPath);
            }

            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                // SetText("File " & e.FullPath & " has been created")
                if (chName == "Neuer Ordner")
                {
                    isFolder = false;
                    return;
                }

                isDelete = false;
                var array = new string[] { null, chName, "Erstellung", getTime(), e.FullPath, isFolder.ToString(), isDelete.ToString() };
                insertRow(array, e.FullPath);
            }

            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                // SetText("File " & e.FullPath & " has been deleted")
                isDelete = true;
                var array = new string[] { null, chName, "Löschen", getTime(), e.FullPath, isFolder.ToString(), isDelete.ToString() };
                insertRow(array, e.FullPath);
            }

            // aktuelle Werte eintragen
            isFolder = false;
            isDelete = false;
            last_change = e.ChangeType.ToString();
            last_path = e.FullPath;
            last_name = chName;
            last_time = getTimeSeconds();

        }

        public void logrename(object source, RenamedEventArgs e)
        {
            // SetText("File" & e.OldName & " has been renamed to " & e.Name)
            if (Path.GetExtension(e.FullPath) == ".tmp" | e.Name.Contains("~$") | Path.GetExtension(e.OldFullPath) == ".tmp")
            {
                return;
            }

            if (last_change == e.ChangeType.ToString() && last_path  == e.FullPath && last_time == getTimeSeconds())
            {
                return;
            }

            // Checken, ob die Datei keine Endung hat und ob es ein Verzeichnis ist
            if (string.IsNullOrEmpty(Path.GetExtension(e.OldFullPath)))
            {
                if (Directory.Exists(e.FullPath))
                {
                    // Wenn es ein Ordner ist, entsprechende Aktion ausführen
                    isFolder = true;
                }
                else
                {
                    // Falls es eine Datei ohne Endung ist, abbrechen
                    return;
                }
            }

            // Dateiname anpassen, falls es sich um einen Ordner in tieferer Ebene handelt
            string chName = "";
            string chOldName = "";
            if (e.Name.Contains(@"\"))
            {
                var path_complete1 = e.Name.Split('\\');
                chName = path_complete1[path_complete1.Length - 1];
                var path_complete2 = e.OldName.Split('\\');
                chOldName = path_complete2[path_complete2.Length - 1];
            }
            else
            {
                chName = e.Name;
                chOldName = e.OldName;
            }

            if (chOldName == "Neuer Ordner")
            {
                isDelete = false;
                var array1 = new string[] { null, chName, "Erstellung", getTime(), e.FullPath, isFolder.ToString(), isDelete.ToString() };
                insertRow(array1, e.FullPath);
                isFolder = false;
                return;
            }

            isDelete = false;
            var array = new string[] { null, chName, "Umbenennung - alter Name: " + chOldName, getTime(), e.FullPath, isFolder.ToString(), isDelete.ToString() };
            insertRow(array, e.FullPath);

            // aktuelle Werte eintragen
            isFolder = false;
            isDelete = false;
            last_change = ((int)e.ChangeType).ToString();
            last_path = e.FullPath;
            last_time = getTimeSeconds();
        }

        public void start_monitoring()
        {
            if (monitoring_running == false)
            {
                // überprüfen, ob mind. ein Slot aktiv gesetzt wurde
                if (slot1_active | slot2_active | slot3_active)
                {
                    // Falls das Monitoring noch nicht läuft
                    // running-Var auf true setzen und Schalter umbeschriften
                    monitoring_running = true;
                    TSLabelStatus.Image = Properties.Resources.green_light_16.ToBitmap();
                    // Icon in grün ändern
                    SystrayIcon.Icon = Icons[0];
                    Icon = Icons[0];
                    SystrayIcon.Text = "DejaVu - Monitoring aktiv";
                    TSLabelStatus.Text = "Status: Monitoring aktiv für ->";
                    cmdStart.Text = "Monitoring stoppen";
                    menuStartMon.Text = "Monitoring stoppen";

                    // Monitoring für alle aktiven Slots starten
                    // ====Slot1====
                    if (slot1_active)
                    {
                        // überprüfen, ob Ordner existiert
                        if (Directory.Exists(slot1_path))
                        {

                            // this is the path we want to monitor
                            watchfolder1.Path = slot1_path;
                            TSLabelStatus.Text += " Slot1";
                            // Add a list of Filter we want to specify
                            // make sure you use OR for each Filter as we need to
                            // all of those 

                            watchfolder1.NotifyFilter = NotifyFilters.DirectoryName;
                            watchfolder1.NotifyFilter = watchfolder1.NotifyFilter | NotifyFilters.FileName;
                            watchfolder1.NotifyFilter = watchfolder1.NotifyFilter | NotifyFilters.Attributes;

                            // add the handler to each event
                            watchfolder1.Changed += logchange;
                            watchfolder1.Created += logchange;
                            watchfolder1.Deleted += logchange;

                            // add the rename handler as the signature is different
                            watchfolder1.Renamed += logrename;

                            // Set this property to true to start watching
                            watchfolder1.EnableRaisingEvents = true;
                            slot1_running = true;

                            if (slot1_subdirs)
                            {
                                // Unterverzeichnisse mit einbeziehen
                                watchfolder1.IncludeSubdirectories = true;
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Slot 1: Pfad nicht gefunden!", MsgBoxStyle.Critical, "Fehler");
                        }
                    }
                    // ====Slot2====
                    if (slot2_active)
                    {
                        // überprüfen, ob Ordner existiert
                        if (Directory.Exists(slot2_path))
                        {
                            // this is the path we want to monitor
                            watchfolder2.Path = slot2_path;
                            TSLabelStatus.Text += " Slot2";
                            // Add a list of Filter we want to specify
                            // make sure you use OR for each Filter as we need to
                            // all of those 

                            watchfolder2.NotifyFilter = NotifyFilters.DirectoryName;
                            watchfolder2.NotifyFilter = watchfolder2.NotifyFilter | NotifyFilters.FileName;
                            watchfolder2.NotifyFilter = watchfolder2.NotifyFilter | NotifyFilters.Attributes;

                            // add the handler to each event
                            watchfolder2.Changed += logchange;
                            watchfolder2.Created += logchange;
                            watchfolder2.Deleted += logchange;

                            // add the rename handler as the signature is different
                            watchfolder2.Renamed += logrename;

                            // Set this property to true to start watching
                            watchfolder2.EnableRaisingEvents = true;
                            slot2_running = true;

                            if (slot2_subdirs)
                            {
                                // Unterverzeichnisse mit einbeziehen
                                watchfolder2.IncludeSubdirectories = true;
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Slot 2: Pfad nicht gefunden!", MsgBoxStyle.Critical, "Fehler");
                        }
                    }

                    // ====Slot3====
                    if (slot3_active)
                    {
                        // überprüfen, ob Ordner existiert
                        if (Directory.Exists(slot3_path))
                        {
                            // this is the path we want to monitor
                            watchfolder3.Path = slot3_path;
                            TSLabelStatus.Text += " Slot3";
                            // Add a list of Filter we want to specify
                            // make sure you use OR for each Filter as we need to
                            // all of those 

                            watchfolder3.NotifyFilter = NotifyFilters.DirectoryName;
                            watchfolder3.NotifyFilter = watchfolder3.NotifyFilter | NotifyFilters.FileName;
                            watchfolder3.NotifyFilter = watchfolder3.NotifyFilter | NotifyFilters.Attributes;

                            // add the handler to each event
                            watchfolder3.Changed += logchange;
                            watchfolder3.Created += logchange;
                            watchfolder3.Deleted += logchange;

                            // add the rename handler as the signature is different
                            watchfolder3.Renamed += logrename;

                            // Set this property to true to start watching
                            watchfolder3.EnableRaisingEvents = true;
                            slot3_running = true;

                            if (slot3_subdirs)
                            {
                                // Unterverzeichnisse mit einbeziehen
                                watchfolder3.IncludeSubdirectories = true;
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Slot 3: Pfad nicht gefunden!", MsgBoxStyle.Critical, "Fehler");
                        }
                    }
                }

                else
                {
                    Interaction.MsgBox("Um das Monitoring starten zu können, muss unter 'Einstellungen' mind. " + "ein Slot als aktiv markiert werden.", MsgBoxStyle.Information, "Hinweis");
                    return;
                }
            }

            else
            {
                // Stop watching the folders
                if (slot1_running)
                {
                    watchfolder1.EnableRaisingEvents = false;
                    slot1_running = false;
                }
                if (slot2_running)
                {
                    watchfolder2.EnableRaisingEvents = false;
                    slot2_running = false;
                }
                if (slot3_running)
                {
                    watchfolder3.EnableRaisingEvents = false;
                    slot3_running = false;
                }

                TSLabelStatus.Image = Properties.Resources.red_light_16.ToBitmap();
                // Icon in normal ändern
                SystrayIcon.Icon = Icons[1];
                Icon = Icons[1];
                SystrayIcon.Text = "DejaVu - Monitoring inaktiv";
                TSLabelStatus.Text = "Status: Monitoring gestoppt";
                monitoring_running = false;
                // Button umbenennen
                cmdStart.Text = "Monitoring starten";
                menuStartMon.Text = "Monitoring starten";
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            start_monitoring();
        }

        // =======================Bereich FileWatcher-Aktionen Ende

        // =======================Funktionen zum Lesen und Schreiben der Events in eine Datei================

        public void write_events()
        {
            // DGVEvents.CurrentRow.Cells(4).Value
            StreamWriter objStreamWriter;
            objStreamWriter = new StreamWriter("events.log", false, System.Text.Encoding.Default);

            foreach (DataGridViewRow row in DGVEvents.Rows)
                objStreamWriter.WriteLine(row.Cells[1].Value + "/" + row.Cells[2].Value + "/" + row.Cells[3].Value + "/" + row.Cells[4].Value + "/" + row.Cells[5].Value + "/" + row.Cells[6].Value);

            objStreamWriter.Close();
        }

        public void read_events()
        {
            var ObjReader = new StreamReader("events.log");
            string sLine = "";
            var arrText = new ArrayList();

            do
            {
                sLine = ObjReader.ReadLine();
                if (sLine is not null)
                {
                    // arrText.Add(sLine)
                    var str = sLine.Split('/');
                    var Img = new DataGridViewImageCell();

                    if (File.Exists(str[3]))
                    {
                        var textArray = new string[] { null, str[0], str[1], str[2], str[3], str[4], str[5] };
                        DGVEvents.Rows.Add(textArray);
                        var icon = Icon.ExtractAssociatedIcon(str[3]);
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[DGVEvents.RowCount - 1].Cells[0].Value = Img.Value;
                    }
                    else if (str[4] == "True")
                    {
                        var textArray = new string[] { null, str[0], str[1], str[2], str[3], str[4], str[5] };
                        DGVEvents.Rows.Add(textArray);
                        var icon = Properties.Resources.delete.ToBitmap();
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[DGVEvents.RowCount - 1].Cells[0].Value = Img.Value;
                    }
                    else if (str[5] == "True")
                    {
                        var textArray = new string[] { null, str[0], str[1], str[2], str[3], str[4], str[5] };
                        DGVEvents.Rows.Add(textArray);
                        var icon = Properties.Resources.folder.ToBitmap();
                        Img.Value = icon;
                        // Icon in erste Zeile einfügen
                        DGVEvents.Rows[DGVEvents.RowCount - 1].Cells[0].Value = Img.Value;
                    }

                }
            }
            while (!(sLine is null));

            ObjReader.Close();


        }

        public void save_config()
        {
            // Alle Einstellungs-Variablen in XML-Datei speichern

            // Auswahl einer Kodierungsart für die Zeichenablage 
            var enc = new System.Text.UnicodeEncoding();

            // XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            var XMLobj = new System.Xml.XmlTextWriter("settings.conf", enc);


            // Formatierung: 4er-Einzüge verwenden 
            XMLobj.Formatting = System.Xml.Formatting.Indented;
            XMLobj.Indentation = 4;

            XMLobj.WriteStartDocument();

            XMLobj.WriteStartElement("Settings");

            // Alle Grundeinstellungen in die Datei schreiben
            XMLobj.WriteStartElement("General"); // <Slot1
            XMLobj.WriteAttributeString("number_displayed", number_entries.ToString());
            XMLobj.WriteAttributeString("show_notification", show_notification.ToString());
            XMLobj.WriteAttributeString("save_log", save_log.ToString());
            XMLobj.WriteEndElement();

            // Alle Slots in die Datei schreiben 
            XMLobj.WriteStartElement("Slot1"); // <Slot1
            XMLobj.WriteAttributeString("path", slot1_path);
            XMLobj.WriteAttributeString("active", slot1_active.ToString());
            XMLobj.WriteAttributeString("subdirs", slot1_subdirs.ToString());
            XMLobj.WriteEndElement(); // Slot1 /> 

            // Alle Slots in die Datei schreiben 
            XMLobj.WriteStartElement("Slot2"); // <Slot2
            XMLobj.WriteAttributeString("path", slot2_path);
            XMLobj.WriteAttributeString("active", slot2_active.ToString());
            XMLobj.WriteAttributeString("subdirs", slot2_subdirs.ToString());
            XMLobj.WriteEndElement(); // Slot2 /> 

            // Alle Slots in die Datei schreiben 
            XMLobj.WriteStartElement("Slot3"); // <Slot3
            XMLobj.WriteAttributeString("path", slot3_path);
            XMLobj.WriteAttributeString("active", slot3_active.ToString());
            XMLobj.WriteAttributeString("subdirs", slot3_subdirs.ToString());
            XMLobj.WriteEndElement(); // Slot3 /> 


            XMLobj.WriteEndElement(); // </Settings> 


            XMLobj.Close();

        }

        private void DejaVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Falls DejaVu vom Shutdown oder dem Taskmanager beendet wird, Log schreiben, falls erwünscht
            if ((e.CloseReason == CloseReason.WindowsShutDown | e.CloseReason == CloseReason.TaskManagerClosing) & save_log == true)
            {
                write_events();
            }

            if (exitAppl == false)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            // Prüfen, ob Monitoring aktiv
            if (monitoring_running)
            {
                Interaction.MsgBox("Auf die Einstellungen kann nicht bei aktivem Monitoring zugegriffen werden.", MsgBoxStyle.Information, "Hinweis");
                return;
            }
            else
            {
                settDialog = new settings();
                
                settDialog.Owner = this;
                settDialogOpen = true;

                this.mMainLocation = new Point(this.Location.X, this.Location.Y);

                settDialog.OkToProceedChanged += new EventHandler(Settings_OkToProceedChanged);
                settDialog.CancelToProceedChanged += new EventHandler(Settings_CancelToProceedChanged);

                settDialog.comboNumEvents.SelectedItem = number_entries.ToString();
                settDialog.checkSave.Checked = save_log;
                settDialog.checkNotifiaction.Checked = show_notification;

                settDialog.txtPath1.Text = slot1_path;
                settDialog.checkActive1.Checked = slot1_active;
                settDialog.checkSubdirs1.Checked = slot1_subdirs;

                settDialog.txtPath2.Text = slot2_path;
                settDialog.checkActive2.Checked = slot2_active;
                settDialog.checkSubdirs2.Checked = slot2_subdirs;

                settDialog.txtPath3.Text = slot3_path;
                settDialog.checkActive3.Checked = slot3_active;
                settDialog.checkSubdirs3.Checked = slot3_subdirs;

                settDialog.Show();
            }
        }

        public void Load_actions()
        {
            // Icons laden
            System.Reflection.Assembly p;
            p = System.Reflection.Assembly.GetExecutingAssembly();

            var iconHandle = Properties.Resources.Systray_Icon_green2.ToBitmap().GetHicon();
            Icon tmpicon = Icon.FromHandle(iconHandle);
            Icons[0] = new Icon(tmpicon, tmpicon.Size);

            iconHandle = Properties.Resources.Systray_Icon_normal.ToBitmap().GetHicon();
            tmpicon = Icon.FromHandle(iconHandle);
            Icons[1] = new Icon(tmpicon, tmpicon.Size);

            if (File.Exists("settings.conf"))
            {
                // Falls eine settings.conf existiert
                // Settings auslesen und in Variablen übertragen
                System.Xml.XmlReader XMLReader = new System.Xml.XmlTextReader("settings.conf");


                while (XMLReader.Read())
                {
                    // Welche Art von Daten liegt an? 
                    switch (XMLReader.NodeType)
                    {

                        // Ein Element 
                        case System.Xml.XmlNodeType.Element:
                            {

                                // Console.WriteLine("Es folgt ein Element vom Typ " & .Name)

                                switch (XMLReader.Name ?? "")
                                {

                                    case "General":
                                        {
                                            if (XMLReader.AttributeCount > 0)
                                            {
                                                while (XMLReader.MoveToNextAttribute())
                                                {
                                                    if (XMLReader.Name == "number_displayed")
                                                        number_entries = Convert.ToInt32(XMLReader.Value);
                                                    if (XMLReader.Name == "show_notification")
                                                        show_notification = Convert.ToBoolean(XMLReader.Value);
                                                    if (XMLReader.Name == "save_log")
                                                        save_log = Convert.ToBoolean(XMLReader.Value);
                                                }
                                            }

                                            break;
                                        }

                                    case "Slot1":
                                        {
                                            if (XMLReader.AttributeCount > 0)
                                            {
                                                while (XMLReader.MoveToNextAttribute())
                                                {
                                                    if (XMLReader.Name == "path")
                                                        slot1_path = XMLReader.Value;
                                                    if (XMLReader.Name == "active")
                                                        slot1_active = Convert.ToBoolean(XMLReader.Value);
                                                    if (XMLReader.Name == "subdirs")
                                                        slot1_subdirs = Convert.ToBoolean(XMLReader.Value);
                                                }
                                            }

                                            break;
                                        }
                                    case "Slot2":
                                        {
                                            if (XMLReader.AttributeCount > 0)
                                            {
                                                while (XMLReader.MoveToNextAttribute())
                                                {
                                                    if (XMLReader.Name == "path")
                                                        slot2_path = XMLReader.Value;
                                                    if (XMLReader.Name == "active")
                                                        slot2_active = Convert.ToBoolean(XMLReader.Value);
                                                    if (XMLReader.Name == "subdirs")
                                                        slot2_subdirs = Convert.ToBoolean(XMLReader.Value);
                                                }
                                            }

                                            break;
                                        }
                                    case "Slot3":
                                        {
                                            if (XMLReader.AttributeCount > 0)
                                            {
                                                while (XMLReader.MoveToNextAttribute())
                                                {
                                                    if (XMLReader.Name == "path")
                                                        slot3_path = XMLReader.Value;
                                                    if (XMLReader.Name == "active")
                                                        slot3_active = Convert.ToBoolean(XMLReader.Value);
                                                    if (XMLReader.Name == "subdirs")
                                                        slot3_subdirs = Convert.ToBoolean(XMLReader.Value);
                                                }
                                            }

                                            break;
                                        }
                                }

                                break;
                            }

                    }

                }


                XMLReader.Close();
            }
            else
            {
                number_entries = 10;
                save_log = true;
                show_notification = false;
            }

            // Icon einfügen
            // SystrayIcon.Icon = Icons(1)

            // Größe der DGV-Spalten anpassen
            DGVEvents.Columns[0].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.1d);
            DGVEvents.Columns[1].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.35d);
            DGVEvents.Columns[2].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.35d);
            DGVEvents.Columns[3].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.2d);

            // Log einlesen, falls vorhanden
            if (save_log == true & File.Exists("events.log"))
            {
                read_events();
                foreach (DataGridViewRow row in DGVEvents.Rows)
                    row.Height = 40;
            }

            // Slots überprüfen
            CheckSlots();

            // Fenster-Icon = blaues Icon setzen
            this.Icon = Icons[1];
            SystrayIcon.Icon = Icons[1];

            // Monitoring starten, falls ein korrekter Pfad vorhanden ist und der Slot als aktiv markiert ist
            if (slot1ok & slot1_active)
            {
                start_monitoring();
                change_icon();
            }
            else if (slot2ok & slot2_active)
            {
                start_monitoring();
                Refresh();
            }
            else if (slot3ok & slot3_active)
            {
                start_monitoring();
                Refresh();
            }
        }

        public void change_icon()
        {
            SystrayIcon.Icon = Icons[0];
            Icon = Icons[0];
            SystrayIcon.Text = "DejaVu - Monitoring aktiv";
            SystrayIcon.Visible = false;
            SystrayIcon.Visible = true;

        }

        public void CheckSlots()
        {
            // Startknopf aktivieren, falls korrekte Pfade angegeben sind
            cmdStart.Enabled = false;
            menuStartMon.Enabled = false;
            if (string.IsNullOrEmpty(slot1_path) == false)
            {
                if (Directory.Exists(slot1_path))
                {
                    cmdStart.Enabled = true;
                    menuStartMon.Enabled = true;
                    slot1ok = true;
                }
            }
            else if (string.IsNullOrEmpty(slot2_path) == false)
            {
                if (Directory.Exists(slot2_path))
                {
                    cmdStart.Enabled = true;
                    menuStartMon.Enabled = true;
                    slot2ok = true;
                }
            }
            else if (string.IsNullOrEmpty(slot3_path) == false)
            {
                if (Directory.Exists(slot3_path))
                {
                    cmdStart.Enabled = true;
                    menuStartMon.Enabled = true;
                    slot3ok = true;
                }
            }
        }

        private void DejaVu_LocationChanged(object sender, EventArgs e)
        {
            if (settDialogOpen)
            {
                Point relativeChange = new Point(this.Location.X - this.mMainLocation.X, this.Location.Y - this.mMainLocation.Y);
                
                settDialog.Location = new Point(settDialog.Location.X + relativeChange.X, settDialog.Location.Y + relativeChange.Y);

                this.mMainLocation = new Point(this.Location.X, this.Location.Y);
            }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox("Hilfe geklickt!");
        }

        private void DejaVu_Resize(object sender, EventArgs e)
        {
            // Größe der DGV-Spalten anpassen
            DGVEvents.Columns[0].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.1d);
            DGVEvents.Columns[1].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.35d);
            DGVEvents.Columns[2].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.35d);
            DGVEvents.Columns[3].Width = (int)Math.Round((DGVEvents.Width - 2) * 0.2d);

            picHelp.Location = new Point(Width - 61, picHelp.Location.Y);
            cmdClose.Location = new Point(Width - 206, cmdClose.Location.Y);
            cmdSettings.Location = new Point(Width - 312, cmdSettings.Location.Y);
            cmdStart.Location = new Point(Width - 447, cmdStart.Location.Y);
        }

        private void ContextEvents_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Wenn dieses Event ausgelöst wird: überprüfen, ob markierter Eintrag Datei oder Ordner ist,
            // und den Eintrag "Ordner öffnen" einblenden oder verbergen.
            if (DGVEvents.RowCount != 0)
            {

                openFolder.Visible = true;
                open.Visible = true;
                showPath.Visible = true;

                if (DGVEvents.CurrentRow.Cells[5].Value.ToString() == "False")
                {
                    // Wenn aktuell markierte Zeile eine Datei ist
                    openFolder.Visible = true;
                }
                else
                {
                    openFolder.Visible = false;
                }
                // Ausblenden, falls der Eintrag zu einer gelöschten Datei gehört
                if (DGVEvents.CurrentRow.Cells[6].Value.ToString() == "True")
                {
                    openFolder.Visible = false;
                    open.Visible = false;
                    showPath.Visible = false;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            Interaction.Shell("explorer /e," +  DGVEvents.CurrentRow.Cells[4].Value.ToString(), Constants.vbNormalFocus);
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            Interaction.Shell("explorer /e,/select," + DGVEvents.CurrentRow.Cells[4].Value.ToString(), Constants.vbNormalFocus);
        }

        private void deleteEntry_Click(object sender, EventArgs e)
        {
            DGVEvents.Rows.RemoveAt(DGVEvents.CurrentRow.Index);
        }

        private void showPath_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox(DGVEvents.CurrentRow.Cells[4].Value, MsgBoxStyle.Information, "Pfad anzeigen");
        }

        private void DGVEvents_DoubleClick(object sender, EventArgs e)
        {
            if (DGVEvents.CurrentRow.Cells[6].Value.ToString() == "True")
            {
                return;
            }

            Interaction.Shell("explorer /e," + DGVEvents.CurrentRow.Cells[4].Value.ToString(), Constants.vbNormalFocus);
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            if (save_log == true)
            {
                write_events();
            }

            exitAppl = true;
            Close();
        }

        private void menuStartMon_Click(object sender, EventArgs e)
        {
            start_monitoring();
        }

        private void start_click()
        {
            cmdStart.PerformClick();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            // Wenn Öffnen im Systray-Kontext_menü angeklickt wird -> Hauptfenster öffnen
            this.Visible = true;
        }

        private void Settings_CancelToProceedChanged(object sender, EventArgs e)
        {
            settDialogOpen = false;
        }

        private void Settings_OkToProceedChanged(object sender, EventArgs e)
        {
            settDialogOpen = false;

            // Get settings from settings dialog form
            save_log = settDialog.checkSave.Checked;
            show_notification = settDialog.checkNotifiaction.Checked;
            number_entries = Convert.ToInt32(settDialog.comboNumEvents.SelectedItem.ToString());

            slot1_path = settDialog.txtPath1.Text;
            slot2_path = settDialog.txtPath2.Text;
            slot3_path = settDialog.txtPath3.Text;

            slot1_active = settDialog.checkActive1.Checked;
            slot2_active = settDialog.checkActive2.Checked;
            slot3_active = settDialog.checkActive3.Checked;

            slot1_subdirs = settDialog.checkSubdirs1.Checked;
            slot2_subdirs = settDialog.checkSubdirs2.Checked;
            slot3_subdirs = settDialog.checkSubdirs3.Checked;

            // Write config to file
            save_config();

            // Check slots and enable/disable buttons
            CheckSlots();

        }
    }
}