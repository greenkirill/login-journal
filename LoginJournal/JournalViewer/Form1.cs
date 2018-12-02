using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalViewer {
    public partial class Form1 : Form {

        private string journalPath = @"C:\Журнал";
        private List<Journal.JournalItem> items = new List<Journal.JournalItem>();
        private List<Journal.JournalItem_View> viewItems = new List<Journal.JournalItem_View>();
        private List<string> machines = new List<string>();
        private List<string> users = new List<string>();
        public Form1() {
            InitializeComponent();

            reinit();
        }

        private void button1_Click(object sender, EventArgs e) {
            using (var fbd = new FolderBrowserDialog()) {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    journalPath = fbd.SelectedPath;
                    reinit();
                }
            }
        }

        private void reinit() {
            textBox1.Text = journalPath;
            try {
                var viewer = new Journal.JournalViewer(journalPath);
                items = viewer.GetAllJournals();
                viewItems = Journal.JournalViewer.ItemToView(items);
                reinitMachinesList();
                reinitUsersList();
                reinitMachinesCobobox();
                reinitusersCobobox();
                reinitDatepickers();
                reinitGrid();
            } catch (Exception e) { }
        }

        private void reinitGrid() {
            try {
                journalItemViewBindingSource.Clear();
                foreach (var item in viewItems) {
                    if (machineCheck(item.machineView) && userCheck(item.nameView) && dateCheck(item.from, item.to))
                        journalItemViewBindingSource.Add(item);
                }
            } catch (Exception e) { }
        }

        private bool machineCheck(string machine) {
            return comboBoxMachine.SelectedText == "Все" || comboBoxMachine.SelectedText == "" || comboBoxMachine.SelectedText == machine;
        }
        private bool userCheck(string machine) {
            return comboBoxUser.SelectedText == "Все" || comboBoxUser.SelectedText == "" || comboBoxUser.SelectedText == machine;
        }
        private bool dateCheck(DateTime from, DateTime to) {
            var newto = dateTimePickerTo.Value.Date.AddDays(1);
            var newfrom = dateTimePickerFrom.Value.Date;
            return newfrom <= from.Date && newto > to.Date;
        }

        private void reinitDatepickers() {
            var mindate = DateTime.MaxValue;
            var maxdate = DateTime.MinValue;
            foreach (var itemView in viewItems) {
                if (itemView.from.Date < mindate.Date)
                    mindate = itemView.from.Date;
                if (itemView.to.Date < mindate.Date)
                    mindate = itemView.to.Date;
                if (itemView.from.Date > maxdate.Date)
                    maxdate = itemView.from.Date;
                if (itemView.to.Date > maxdate.Date)
                    maxdate = itemView.to.Date;
            }
            try {
                dateTimePickerFrom.MaxDate = maxdate;
                dateTimePickerFrom.MinDate = mindate;
                dateTimePickerTo.MaxDate = maxdate;
                dateTimePickerTo.MinDate = mindate;
            } catch (Exception e) { }
        }

        private void reinitMachinesList() {
            machines.Clear();
            foreach (var itemView in viewItems) {
                if (!machines.Contains(itemView.machineView)) {
                    machines.Add(itemView.machineView);
                }
            }
        }

        private void reinitUsersList() {
            users.Clear();
            foreach (var itemView in viewItems) {
                if (!users.Contains(itemView.nameView)) {
                    users.Add(itemView.nameView);
                }
            }
        }

        private void reinitMachinesCobobox() {
            comboBoxMachine.Items.Clear();
            foreach (var m in machines) {
                comboBoxMachine.Items.Add(m);
            }
            comboBoxMachine.Items.Add("Все");
        }
        private void reinitusersCobobox() {
            comboBoxUser.Items.Clear();
            foreach (var u in users) {
                comboBoxUser.Items.Add(u);
            }
            comboBoxUser.Items.Add("Все");
        }

        private void comboBoxMachine_SelectedIndexChanged(object sender, EventArgs e) {
            reinitGrid();
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e) {
            reinitGrid();
        }

        private void button2_Click(object sender, EventArgs e) {
            reinitGrid();
        }
    }
}
