using BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void LoadInfo()
        {
            dgvMainGrid.DataSource = clsContact.GetAllContacts();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditFrom frm = new EditFrom(-1);
            frm.ShowDialog();
            LoadInfo();
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditFrom frm = new EditFrom((int)dgvMainGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            LoadInfo();
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsContact.DeleteContact((int)dgvMainGrid.CurrentRow.Cells[0].Value)) 
            {
                MessageBox.Show("Deleted","The UserContact Deleted Successfully..",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR!", "Cannot Delete the UserContact", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            LoadInfo();
        }
    }
}
