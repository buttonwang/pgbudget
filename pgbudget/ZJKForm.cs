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
    public partial class ZJKForm : Form
    {

        readonly PGDataClassesDataContext db = new PGDataClassesDataContext();

        public ZJKForm()
        {
            InitializeComponent();
        }

        private void ZJKForm_Load(object sender, EventArgs e)
        {
            var query = from zjk in db.zjks orderby zjk.created_time descending select zjk;
            zjkBindingSource.DataSource = query;
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zjk zj = new zjk { name = "新建组件" };
            zjkBindingSource.Add(zj);
            db.zjks.InsertOnSubmit(zj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zjkBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            var phight = (sender as Panel).Height;
            depanel.Height = phight / 3;
            zcpanel.Height = phight / 3;
            sbpanel.Height = phight - (phight / 3) * 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //
        }

        private void button6_Click(object sender, EventArgs e)
        {
            zjk_item1BindingSource.RemoveCurrent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //
        }

        private void button7_Click(object sender, EventArgs e)
        {
            zjk_item2BindingSource.RemoveCurrent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //
        }

        private void button9_Click(object sender, EventArgs e)
        {
            zjk_item3BindingSource.RemoveCurrent();
        }

        

    }
}
