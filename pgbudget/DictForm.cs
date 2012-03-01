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

        private readonly string _dictName;

        private DataGridView _selectGrid;

        public String  selectCode;

        public String  selectName;

        //1: 正常模式；2: 只读模式
        public int mode;

        public DictForm(string dictName)
        {
            InitializeComponent();
            _dictName = dictName;
        }

        private void DEForm_Load(object sender, EventArgs e)
        {
            _dict = new Dict(_dictName);
            sytreeView.Nodes.Add(_dict.IndexTree());
            sytreeView.TopNode.Expand();


            foreach (Control ctl in gridpanel.Controls)
            {
                if ((ctl is DataGridView) && (ctl.Name == _dict.DictName + "DataGridView"))
                {
                    ctl.Dock = DockStyle.Fill;
                    ctl.Visible = true;
                    _selectGrid = (ctl as DataGridView);
                    _selectGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    _selectGrid.CellDoubleClick += this.DataGridView_CellDoubleClick;
                }
            }
        }

        private void sytreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var syId = (sytreeView.SelectedNode.Tag as IDictIndex).IndexValue ?? "";           
            BindingSource bs = new BindingSource() { DataSource = _dict.DictDataSource(syId) };
            dictBindingSource.DataSource = bs;
            dictBindingNavigator.BindingSource = bs;
            _selectGrid.DataSource = bs;
        }

        private void desybBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            _dict.SaveDict();
        }        

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            selectCode = _selectGrid.CurrentRow.Cells[0].Value.ToString();
            selectName = _selectGrid.CurrentRow.Cells[1].Value.ToString();
            MessageBox.Show(selectCode);
        }

        private void searchButton1_Click(object sender, EventArgs e)
        {
            var keyword = keywordTextBox.Text.Trim();
            BindingSource bs = new BindingSource() { DataSource = _dict.SearchDataSource(keyword) };
            dictBindingSource.DataSource = bs;
            dictBindingNavigator.BindingSource = bs;
            _selectGrid.DataSource = bs;
        }

        private void DictForm_Activated(object sender, EventArgs e)
        {
            keywordTextBox.Focus();
        }

        private void keywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (keywordTextBox.Text.Trim() != ""))
            {
                searchButton1_Click(keywordTextBox, null);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}