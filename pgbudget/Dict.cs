using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pgbudget
{
    //摘要：
    //     项目中用到的字典表
    class Dict
    {

        private TreeNode findNode;

        public String DictSYName { get; set; }
        public String DictName {get; set;}
        public String DictCNName { get; set;}

        PGDataClassesDataContext db = new PGDataClassesDataContext();

        private TreeNode FindRecursive(TreeNode treeNode, string level)
        {
            if ((treeNode.Tag as desyb).NodeId == level) findNode = treeNode;

            foreach (TreeNode tn in treeNode.Nodes)
            {
                if ((tn.Tag as desyb).NodeId == level) findNode = tn; 
                else FindRecursive(tn, level);
            }

            return findNode;
        }
        
        public Dict(string Name)
        {
            switch (Name)
            {
                case "定额": DictName = "deb"; DictSYName = "desyb"; break;
                case "设备": DictName = "sbb"; DictSYName = "sbsyb"; break;
            }
            DictCNName = Name;
        }

        public TreeNode IndexTree()
        {
            
            if (DictSYName == "desyb")
            {
                //top node
                var node = new TreeNode { Text = "定额表", Tag = new desyb {NodeId=""} }; 
                 
                var query = from desyb in db.desybs orderby desyb.NodeId select desyb;
                
                foreach (var desyb in query)
                {
                    findNode = null; 
                    FindRecursive(node, desyb.NodeId.Substring(0, desyb.NodeId.Length - 4));
                    if (findNode != null) findNode.Nodes.Add(new TreeNode { Text = desyb.BTM, Tag = desyb });
                }

                return node;
            }
            else if (DictSYName == "sbsysb")
            {
            }

            return null;
        }

        public object DictDataSource(string syId)
        {
            if (DictSYName == "desyb")
            {
                var query = from drb in db.drbs 
                            where syId=="" || drb.sybh ==syId
                            select drb;
                return query;
            }

            return null;
        }

        public void SaveDict() { db.SubmitChanges(); }



    }
}
