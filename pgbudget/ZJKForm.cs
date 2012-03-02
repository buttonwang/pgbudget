using System;
using System.Collections.Generic;
using System.Linq;
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zjk zj = new zjk { name = "新建组件" };
            zjkBindingSource.Add(zj);
            db.zjks.InsertOnSubmit(zj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var zj = zjkBindingSource.Current as zjk;
            if (zj != null)
            {
                zjkBindingSource.RemoveCurrent();
                foreach(var item in zj.zjk_items)
                {
                    //db.zjk_items.DeleteOnSubmit(item);
                }
                zjk_item1BindingSource.Clear();
                zjk_item2BindingSource.Clear();
                zjk_item3BindingSource.Clear();
                RefreshItems();
            }
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
            if ((zjkBindingSource.Current as zjk) == null)
            {
                MessageBox.Show("请先增加组件，然后增加组件项目。");
                return;
            }
            DictForm deForm = new DictForm("定额", 2);
            using (deForm)
            {
            	deForm.ShowDialog();
                if (deForm.selectCode != "")
                {
                    zjk_item deItem = new zjk_item
                    {
                        item_code = deForm.selectCode,
                        item_name = deForm.selectName,
                        item_type = 1,
                        zjk = (zjkBindingSource.Current as zjk)
                    };

                    (zjkBindingSource.Current as zjk).zjk_items.Add(deItem);
                    
                    RefreshItems();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (zjk_item1BindingSource.Current as zjk_item != null)
            {
                var zj = zjkBindingSource.Current as zjk;

                zj.zjk_items.Remove((zjk_item1BindingSource.Current as zjk_item));
                //db.zjk_items.DeleteOnSubmit((zjk_item1BindingSource.Current as zjk_item));
                zjk_item1BindingSource.RemoveCurrent();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((zjkBindingSource.Current as zjk) == null)
            {
                MessageBox.Show("请先增加组件，然后增加组件项目。");
                return;
            }
            DictForm sbForm = new DictForm("设备", 2);
            using (sbForm)
            {
                sbForm.ShowDialog();
                if (sbForm.selectCode != "")
                {
                    zjk_item sbItem = new zjk_item
                    {
                        item_code = sbForm.selectCode,
                        item_name = sbForm.selectName,
                        item_type = 2,
                        zjk = (zjkBindingSource.Current as zjk)
                    };

                    (zjkBindingSource.Current as zjk).zjk_items.Add(sbItem);

                    RefreshItems();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (zjk_item2BindingSource.Current as zjk_item != null)
            {
                var zj = zjkBindingSource.Current as zjk;

                zj.zjk_items.Remove((zjk_item2BindingSource.Current as zjk_item));
                //db.zjk_items.DeleteOnSubmit((zjk_item2BindingSource.Current as zjk_item));
                zjk_item2BindingSource.RemoveCurrent();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if ((zjkBindingSource.Current as zjk) == null)
            {
                MessageBox.Show("请先增加组件，然后增加组件项目。");
                return;
            }
            DictForm zcForm = new DictForm("装材", 2);
            using (zcForm)
            {
                zcForm.ShowDialog();
                if (zcForm.selectCode != "")
                {
                    zjk_item zcItem = new zjk_item
                    {
                        item_code = zcForm.selectCode,
                        item_name = zcForm.selectName,
                        item_type = 3,
                        zjk = (zjkBindingSource.Current as zjk)
                    };

                    (zjkBindingSource.Current as zjk).zjk_items.Add(zcItem);

                    RefreshItems();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (zjk_item3BindingSource.Current as zjk_item != null)
            {
                var zj = zjkBindingSource.Current as zjk;

                zj.zjk_items.Remove((zjk_item3BindingSource.Current as zjk_item));
                //db.zjk_items.DeleteOnSubmit((zjk_item3BindingSource.Current as zjk_item));
                zjk_item3BindingSource.RemoveCurrent();
            }
        }

        private void zjkBindingSource_PositionChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            var zj = zjkBindingSource.Current as zjk;
            if (zj != null)
            {
                zjk_item1BindingSource.DataSource = zj.zjk_items.Where(item => item.item_type == 1);
                zjk_item2BindingSource.DataSource = zj.zjk_items.Where(item => item.item_type == 2);
                zjk_item3BindingSource.DataSource = zj.zjk_items.Where(item => item.item_type == 3);
            }
        }

    }
}