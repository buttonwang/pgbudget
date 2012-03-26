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
            
            InitProject();

            InitJZGC();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void InitProject()
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

        private void InitJZGC()
        {
            var jzgcList = from jzgc in db.jzgcs                 
                 select new {mc=jzgc.mc, mc2=jzgc.dw, ID=jzgc.id, ParentID = jzgc.pid};

            treeList1.ParentFieldName = "ParentID"; 
            treeList1.DataSource = jzgcList;
            treeList1.ExpandAll();
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
            DictForm deForm = new DictForm("定额");
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

        private void 材机维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictForm cjForm = new DictForm("材机");
            try
            {
                cjForm.ShowDialog();
            }
            finally
            {
                if (cjForm != null)
                    cjForm.Dispose();
            }
        }

        private void 设备维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictForm sbForm = new DictForm("设备");
            try
            {
                sbForm.ShowDialog();
            }
            finally
            {
                if (sbForm != null)
                    sbForm.Dispose();
            }
        }

        private void 装材维护ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DictForm zcForm = new DictForm("装材");
            try
            {
                zcForm.ShowDialog();
            }
            finally
            {
                if (zcForm != null)
                    zcForm.Dispose();
            }
        }

        private void 组件库维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZJKForm zjkForm = new ZJKForm();
            try
            {
                zjkForm.ShowDialog();
            }
            finally
            {
                if (zjkForm != null)
                    zjkForm.Dispose();
            }
        }
       
    }
}