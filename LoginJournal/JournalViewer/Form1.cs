using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var viewer = new Journal.JournalViewer(@"C:\Users\kirill.gribkov\Documents\LJ\folder");
            var items = viewer.GetAllJournals();
            var view_items = Journal.JournalViewer.ItemToView(items);
            foreach (var item in view_items)
            {
                journalItemViewBindingSource.Add(item);
            }
        }
    }
}
