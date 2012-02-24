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
    public partial class FindProjectForm : Form
    {
        PGDataClassesDataContext db = new PGDataClassesDataContext();

        private void FindProjectForm_Load(object sender, EventArgs e)
        {
            projectBindingSource.DataSource = (from projects in db.projects 
                                               orderby projects.创建日期 descending 
                                               select projects);
           
        }

        public FindProjectForm()
        {
            InitializeComponent();
        }

        private void FindProjectForm_Activated(object sender, EventArgs e)
        {
            findtextBox.Focus();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("open...");
        }
        
        private void findtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.KeyCode == Keys.Enter) && (findtextBox.Text.Trim() != "" ))
            //{                
            //    projectBindingSource.DataSource = (from projects in pgContext.projects
           //                                        where projects.工程编号.Contains(findtextBox.Text)
            //                                       orderby projects.创建日期 descending
           //                                        select projects);
           // }
        }

        private void findtextBox_TextChanged(object sender, EventArgs e)
        {
            if (findtextBox.Text.Trim() != "")
            {
                projectBindingSource.DataSource = (from projects in db.projects
                                                   where (
                                                    projects.工程编号.Contains(findtextBox.Text) ||
                                                    projects.工程名称.Contains(findtextBox.Text)
                                                    )
                                                   orderby projects.创建日期 descending
                                                   select projects);
            }
            else
            {
                projectBindingSource.DataSource = (from projects in db.projects
                                                   //where projects.工程编号.Contains(findtextBox.Text)
                                                   orderby projects.创建日期 descending
                                                   select projects);
            }
        }




    }
}
