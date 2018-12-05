using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Journal;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace JournalViewer
{
    public partial class Form1 : Form
    {

        private SettingLoader setl = new SettingLoader(AppDomain.CurrentDomain.BaseDirectory);
        private string journalPath = @"C:\Журнал";
        private string namemapPath = @"C:\Журнал";
        private string pcmapPath = @"C:\Журнал";
        private Journal.namemap namemap;
        private Journal.pcmap pcmap;
        private List<Journal.JournalItem> items = new List<Journal.JournalItem>();
        private List<Journal.JournalItem_View> viewItems = new List<Journal.JournalItem_View>();
        private List<string> machines = new List<string>();
        private List<string> users = new List<string>();

        public Form1()
        {
            InitializeComponent();
            journalPath = setl.set.JournalFolder;
            namemapPath = setl.set.NamemapPath;
            namemap = new Journal.namemap(namemapPath);
            pcmap = new Journal.pcmap(pcmapPath);
            pcmapPath = setl.set.PCPath;
            reinit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                InitialDirectory = journalPath,
                IsFolderPicker = true

            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                journalPath = dialog.FileName;
                reinit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = namemapPath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    namemapPath = openFileDialog.FileName;
                    reinit();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = pcmapPath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pcmapPath = openFileDialog.FileName;
                    reinit();
                }
            }
        }

        private void reinit()
        {
            textBox1.Text = journalPath;
            textBox2.Text = namemapPath;
            textBox3.Text = pcmapPath;
            try
            {
                reinitMapAndItems();
                reinitMachinesList();
                reinitUsersList();
                reinitMachinesCobobox();
                reinitusersCobobox();
                reinitDatepickers();
                reinitGrid();
                reinitSettings();
            }
            catch (Exception e) { logger.log("error", e); }
        }

        private void reinitMapAndItems()
        {
            namemap = new Journal.namemap(namemapPath);
            pcmap = new Journal.pcmap(pcmapPath);
            var viewer = new Journal.JournalViewer(journalPath);
            items = viewer.GetAllJournals();
            try
            {
                viewItems = Journal.JournalViewer.ItemToView(items, namemap, pcmap);
            }
            catch (Exception e)
            {
                viewItems = Journal.JournalViewer.ItemToView(items);
            }
        }


        private void reinitSettings()
        {
            setl.set.NamemapPath = namemapPath;
            setl.set.JournalFolder = journalPath;
            setl.set.PCPath = pcmapPath;
            setl.save();
        }
        private void reinitGrid()
        {
            try
            {
                journalItemViewBindingSource.Clear();
                foreach (var item in viewItems)
                {
                    try
                    {
                        if (machineCheck(item.machineView) && userCheck(item.nameView) && dateCheck(item.from, item.to))
                            journalItemViewBindingSource.Add(item);
                    }
                    catch (Exception e) { logger.log("error", e); }
                }
            }
            catch (Exception e) { logger.log("error", e); }
        }

        private bool machineCheck(string machine)
        {
            string v = comboBoxMachine.SelectedIndex >= 0 ? comboBoxMachine.Items[comboBoxMachine.SelectedIndex] as string : "";
            return v == "Все" || v == "" || v == machine;
        }
        private bool userCheck(string username)
        {
            string v = comboBoxUser.SelectedIndex >= 0 ? comboBoxUser.Items[comboBoxUser.SelectedIndex] as string : "";
            return v == "Все" || v == "" || v == username;
        }
        private bool dateCheck(DateTime from, DateTime to)
        {
            var newto = dateTimePickerTo.Value.Date.AddDays(1);
            var newfrom = dateTimePickerFrom.Value.Date;
            return newfrom <= from.Date && newto > to.Date;
        }

        private void reinitDatepickers()
        {
            var mindate = DateTime.MaxValue;
            var maxdate = DateTime.MinValue;
            foreach (var itemView in viewItems)
            {
                if (itemView.from.Date < mindate.Date)
                    mindate = itemView.from.Date;
                if (itemView.to.Date < mindate.Date)
                    mindate = itemView.to.Date;
                if (itemView.from.Date > maxdate.Date)
                    maxdate = itemView.from.Date;
                if (itemView.to.Date > maxdate.Date)
                    maxdate = itemView.to.Date;
            }
            try
            {
                dateTimePickerFrom.MaxDate = maxdate;
                dateTimePickerFrom.MinDate = mindate;
                dateTimePickerTo.MaxDate = maxdate;
                dateTimePickerTo.MinDate = mindate;
            }
            catch (Exception e) { logger.log("error", e); }
        }

        private void reinitMachinesList()
        {
            machines.Clear();
            foreach (var itemView in viewItems)
            {
                var pc = pcmap.GetViewName(itemView.machineView);
                if (!machines.Contains(pc))
                {
                    machines.Add(pc);
                }
            }
        }

        private void reinitUsersList()
        {
            users.Clear();
            foreach (var itemView in viewItems)
            {
                var nm = namemap.GetName(itemView.nameView);
                if (!users.Contains(nm))
                {
                    users.Add(nm);
                }
            }
        }

        private void reinitMachinesCobobox()
        {
            comboBoxMachine.Items.Clear();
            foreach (var m in machines)
            {
                comboBoxMachine.Items.Add(m);
            }
            comboBoxMachine.Items.Add("Все");
        }
        private void reinitusersCobobox()
        {
            comboBoxUser.Items.Clear();
            foreach (var u in users)
            {
                comboBoxUser.Items.Add(u);
            }
            comboBoxUser.Items.Add("Все");
        }

        private void comboBoxMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            reinitGrid();
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            reinitGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reinitMapAndItems();
            reinitGrid();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            reinitGrid();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            reinitGrid();
        }

    }
}
