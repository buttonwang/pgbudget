using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pgbudget
{
    public partial class MainForm : Form
    {
        readonly PGDataClassesDataContext db = new PGDataClassesDataContext();

        private project p = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            p = (from project in db.projects
                 where project.id == 5
                 select project).SingleOrDefault();
            if (p == null)
            {
                p = new project { 工程编号 = "new project" };
                db.projects.InsertOnSubmit(p);
            }
            ProjectPropertyGrid.SelectedObject = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {                       
            db.SubmitChanges();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindProjectForm fgForm = new FindProjectForm();
            try
            {
                fgForm.ShowDialog();
            }
            finally
            {
                if (fgForm != null)
                    fgForm.Dispose();
            }
        }


        private void 定额维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictForm deForm = new DictForm();
            try
            {
                deForm.ShowDialog();
            }
            finally
            {
                if (deForm != null)
                    deForm.Dispose();
            }
        }

       
    }
}
