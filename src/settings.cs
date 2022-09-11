using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dejavu_sharp
{
    public partial class settings : Form
    {
        Point parentOffset = Point.Empty;
        bool wasShown = false;

        public event EventHandler OkToProceedChanged;
        public event EventHandler CancelToProceedChanged;

        public settings()
        {
            InitializeComponent();
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Left = (int)Math.Round((double)dejavu_sharp.dejavu.ActiveForm.Width / 2d + (double)dejavu_sharp.dejavu.ActiveForm.Left - Width / 2d);
            Top = (int)Math.Round((double)dejavu_sharp.dejavu.ActiveForm.Height / 2d + (double)dejavu_sharp.dejavu.ActiveForm.Top - Height / 2d);
            // Werte von Variablen übertragen
            //comboNumEvents.SelectedItem = dejavu.My.MyProject.Forms.DejaVu.number_entries.ToString();
            //checkSave.Checked = dejavu.My.MyProject.Forms.DejaVu.save_log;
            //checkNotifiaction.Checked = dejavu.My.MyProject.Forms.DejaVu.show_notification;

            //txtPath1.Text = dejavu.My.MyProject.Forms.DejaVu.slot1_path;
            //checkActive1.Checked = dejavu.My.MyProject.Forms.DejaVu.slot1_active;
            //checkSubdirs1.Checked = dejavu.My.MyProject.Forms.DejaVu.slot1_subdirs;

            //txtPath2.Text = dejavu.My.MyProject.Forms.DejaVu.slot2_path;
            //checkActive2.Checked = dejavu.My.MyProject.Forms.DejaVu.slot2_active;
            //checkSubdirs2.Checked = dejavu.My.MyProject.Forms.DejaVu.slot2_subdirs;

            //txtPath3.Text = dejavu.My.MyProject.Forms.DejaVu.slot3_path;
            //checkActive3.Checked = dejavu.My.MyProject.Forms.DejaVu.slot3_active;
            //checkSubdirs3.Checked = dejavu.My.MyProject.Forms.DejaVu.slot3_subdirs;

            this.Owner.Enabled = true;
        }

        private void cmdOK_Click_1(object sender, EventArgs e)
        {
            //// Allgemeine Einstellungen übertragen
            //dejavu_sharp.dejavu.ActiveForm. number_entries = Convert.ToInt32(comboNumEvents.SelectedItem.ToString());
            //if (checkSave.Checked)
            //{
            //    dejavu.My.MyProject.Forms.DejaVu.save_log = true;
            //}
            //else
            //{
            //    dejavu.My.MyProject.Forms.DejaVu.save_log = false;
            //}
            //if (checkNotifiaction.Checked)
            //{
            //    dejavu.My.MyProject.Forms.DejaVu.show_notification = true;
            //}
            //else
            //{
            //    dejavu.My.MyProject.Forms.DejaVu.show_notification = false;
            //}

            //// Pfade übertragen
            //dejavu.My.MyProject.Forms.DejaVu.slot1_path = txtPath1.Text;
            //dejavu.My.MyProject.Forms.DejaVu.slot2_path = txtPath2.Text;
            //dejavu.My.MyProject.Forms.DejaVu.slot3_path = txtPath3.Text;

            //// Aktiv-Markierungen übertragen
            //if (checkActive1.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot1_active = true;
            //if (checkActive1.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot1_active = false;

            //if (checkActive2.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot2_active = true;
            //if (checkActive2.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot2_active = false;

            //if (checkActive3.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot3_active = true;
            //if (checkActive3.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot3_active = false;

            //// Unterverzeichnis-Einstellungen übertragen
            //if (checkSubdirs1.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot1_subdirs = true;
            //if (checkSubdirs1.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot1_subdirs = false;

            //if (checkSubdirs2.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot2_subdirs = true;
            //if (checkSubdirs2.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot2_subdirs = false;

            //if (checkSubdirs3.Checked)
            //    dejavu.My.MyProject.Forms.DejaVu.slot3_subdirs = true;
            //if (checkSubdirs3.Checked == false)
            //    dejavu.My.MyProject.Forms.DejaVu.slot3_subdirs = false;

            //// Speichern veranlassen
            //dejavu.My.MyProject.Forms.DejaVu.save_config();

            //// Slots überprüfen + Button freischalten falls mögl.
            //dejavu.My.MyProject.Forms.DejaVu.CheckSlots();

            //// Einstellungsfenster schließen
            ///
            EventHandler eh = OkToProceedChanged;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }

            Close();
        }

        private void cmdAbbr_Click_1(object sender, EventArgs e)
        {
            EventHandler eh = CancelToProceedChanged;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }

            Close();
        }

        private void checkActive1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActive1.Checked)
            {
                if (!string.IsNullOrEmpty(txtPath1.Text))
                {
                    //groupSlot1.CaptionColor = Color.Green;
                }
                else
                {
                    Interaction.MsgBox("Bevor der Slot als aktiv markiert werden kann, muss ein zu überwachender Ordner ausgewählt werden.", MsgBoxStyle.Information, "Hinweis");
                    checkActive1.Checked = false;
                    return;
                }
            }
            else
            {
                //groupSlot1.CaptionColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void checkActive2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActive2.Checked)
            {
                if (!string.IsNullOrEmpty(txtPath2.Text))
                {
                    //groupSlot2.CaptionColor = Color.Green;
                }
                else
                {
                    Interaction.MsgBox("Bevor der Slot als aktiv markiert werden kann, muss ein zu überwachender Ordner ausgewählt werden.", MsgBoxStyle.Information, "Hinweis");
                    checkActive2.Checked = false;
                    return;
                }
            }
            else
            {
                //groupSlot2.CaptionColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void checkActive3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActive3.Checked)
            {
                if (!string.IsNullOrEmpty(txtPath3.Text))
                {
                    //groupSlot3.CaptionColor = Color.Green;
                }
                else
                {
                    Interaction.MsgBox("Bevor der Slot als aktiv markiert werden kann, muss ein zu überwachender Ordner ausgewählt werden.", MsgBoxStyle.Information, "Hinweis");
                    checkActive3.Checked = false;
                    return;
                }
            }
            else
            {
                //groupSlot3.CaptionColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void cmdPath1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = @"C:\";
            dialog.Description = "Ordner zur Überwachung für Slot 1 auswählen:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath1.Text = dialog.SelectedPath;
            }
        }

        private void cmdPath2_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = @"C:\";
            dialog.Description = "Ordner zur Überwachung für Slot 2 auswählen:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath2.Text = dialog.SelectedPath;
            }
        }

        private void cmdPath3_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = @"C:\";
            dialog.Description = "Ordner zur Überwachung für Slot 3 auswählen:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath3.Text = dialog.SelectedPath;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            parentOffset = new Point(this.Left - this.Owner.Left, this.Top - this.Owner.Top);
            wasShown = true;
            base.OnShown(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (wasShown)
            {
                this.Owner.Location = new Point(this.Left - parentOffset.X, this.Top - parentOffset.Y);
            }
            base.OnLocationChanged(e);
        }



    }
}
