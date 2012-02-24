using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace pgbudget
{
    public partial class DictForm : Form
    {

        private Dict _dict;

        public DictForm()
        {
            InitializeComponent();
        }

        private void DEForm_Load(object sender, EventArgs e)
        {
            //TreeNode topNode = new TreeNode { Text = "全部定额", Tag = 0 };

            //topNode = sytreeView.TopNode;

            //var desys = (from desyb in db.desybs select desyb);

            //foreach (desyb sy in desys)
            //{
            //    Console.WriteLine(sy.BTM);
            //    //sytreeView.
            //}
            _dict = new Dict("定额");
            sytreeView.Nodes.Add(_dict.IndexTree());
            sytreeView.TopNode.Expand();

            drbDataGridView.Dock = DockStyle.Fill;
            drbDataGridView.Visible = true;

            

            drbBindingSource.Dispose();
            //drbBindingSource.DataSource = _dict.DictDataSource("");
            //dictBindingSource = (_dict.DictDataSource("") as System.Data.Linq.DataQuery<pgbudget.drb>);
            
            //drbDataGridView.DataSource = dictBindingSource.DataSource;
        }
        
        private void desybBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            _dict.SaveDict();
        }

        private void sytreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var syId = (sytreeView.SelectedNode.Tag as IDictIndex).IndexValue??"";
            BindingSource bs = new BindingSource();
            bs.DataSource = _dict.DictDataSource(syId);
            dictBindingSource.DataSource = bs;
            drbDataGridView.DataSource = bs;
            dictBindingNavigator.BindingSource = bs;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dictBindingSource.MoveFirst();
        }
    }
}