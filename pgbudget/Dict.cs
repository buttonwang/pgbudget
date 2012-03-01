using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pgbudget
{
    //摘要：
    //     项目中用到的字典表
    class Dict
    {

        public String DictSYName { get; set; }
        public String DictName {get; set;}
        public String DictCNName { get; set;}

        private TreeNode findNode;

        private int _levelLength = 4;   //索引层级长度

        readonly PGDataClassesDataContext db = new PGDataClassesDataContext();

        private TreeNode FindRecursive(TreeNode treeNode, string level)
        {
            if ((treeNode.Tag as IDictIndex).NodeValue == level) findNode = treeNode;

            foreach (TreeNode tn in treeNode.Nodes)
            {
                if ((tn.Tag as IDictIndex).NodeValue == level) findNode = tn; 
                else FindRecursive(tn, level);
            }

            return findNode;
        }
        
        public Dict(string Name)
        {
            switch (Name)
            {
                case "定额": DictName = "deb";
                             DictSYName = "desyb"; 
                             break;
                case "材机": DictName = "cjb";
                             DictSYName = "cjsyb";
                             break;
                case "设备": DictName = "sbb"; 
                             DictSYName = "sbsyb";
                             _levelLength = 3;
                             break;
                case "装材": DictName = "zcb";
                             DictSYName = "zcsyb";
                             _levelLength = 3;
                             break;
            }
            DictCNName = Name;
        }

        public TreeNode IndexTree()
        {
            
            if (DictSYName == "desyb")
            {                
                var node = new TreeNode { Text = "定额表", Tag = new desyb {NodeId=""} }; 
                 
                var query = from desyb in db.desybs orderby desyb.NodeId select desyb;
                
                foreach (var desyb in query)
                {
                    findNode = null;
                    FindRecursive(node, desyb.NodeId.Substring(0, desyb.NodeId.Length - _levelLength));
                    if (findNode != null) findNode.Nodes.Add(new TreeNode { Text = desyb.BTM, Tag = desyb });
                }

                return node;
            }
            else if (DictSYName == "cjsyb")
            {
                var node = new TreeNode { Text = "材机表", Tag = new cjsyb { NodeId = "" } };

                var query = from cjsyb in db.cjsybs orderby cjsyb.NodeId select cjsyb;

                foreach (var cjsyb in query)
                {
                    findNode = null;
                    FindRecursive(node, cjsyb.NodeId.Substring(0, cjsyb.NodeId.Length - _levelLength));
                    if (findNode != null) findNode.Nodes.Add(new TreeNode { Text = cjsyb.BTM, Tag = cjsyb });
                }

                return node;
            }
            else if (DictSYName == "sbsyb")
            {
                var node = new TreeNode { Text = "设备表", Tag = new sbsyb { LAYER = "" } };

                var query = from sbsyb in db.sbsybs orderby sbsyb.LAYER select sbsyb;

                foreach (var sbsyb in query)
                {
                    findNode = null;
                    FindRecursive(node, sbsyb.LAYER.Substring(0, sbsyb.LAYER.Length - _levelLength));
                    if (findNode != null) findNode.Nodes.Add(new TreeNode { Text = sbsyb.NAME , Tag = sbsyb });
                }

                return node;
            }
            else if (DictSYName == "zcsyb")
            {
                var node = new TreeNode { Text = "装材表", Tag = new zcsyb { LAYER = "" } };

                var query = from zcsyb in db.zcsybs orderby zcsyb.LAYER select zcsyb;

                foreach (var zcsyb in query)
                {
                    findNode = null;
                    FindRecursive(node, zcsyb.LAYER.Substring(0, zcsyb.LAYER.Length - _levelLength));
                    if (findNode != null) findNode.Nodes.Add(new TreeNode { Text = zcsyb.NAME, Tag = zcsyb });
                }

                return node;
            }

            return null;
        }

        public object DictDataSource(string syId)
        {
            if (syId == "0") syId = "";

            if (DictSYName == "desyb")
            {
                var query = from deb in db.debs
                            where syId=="" || deb.sybh == syId
                            select deb;
                return query;
            }
            else if (DictSYName == "cjsyb")
            {
                var query = from cjb in db.cjbs 
                            where syId=="" || cjb.sybh == syId
                            select cjb;
                return query;
            }
            else if (DictSYName == "sbsyb")
            {
                var query = from sbb in db.sbbs
                            where syId == "" || sbb.Category.ToString() == syId
                            orderby sbb.SORTID
                            select sbb;
                return query;
            }
            else if (DictSYName == "zcsyb")
            {
                var query = from zcb in db.zcbs
                            where syId == "" || zcb.Category.ToString() == syId
                            orderby zcb.SORTID
                            select zcb;
                return query;
            }

            return null;
        }

        public object SearchDataSource(string keyword)
        {           

            if (DictSYName == "desyb")
            {
                var query = from deb in db.debs
                            where deb.deh.Contains(keyword) || deb.mc.Contains(keyword) 
                            select deb;
                return query;
            }
            else if (DictSYName == "cjsyb")
            {
                var query = from cjb in db.cjbs
                            where cjb.cjid.Contains(keyword) || cjb.mc.Contains(keyword) 
                            select cjb;
                return query;
            }
            else if (DictSYName == "sbsyb")
            {
                var query = from sbb in db.sbbs
                            where sbb.CODE.Contains(keyword) || sbb.NAME.Contains(keyword) 
                            orderby sbb.SORTID
                            select sbb;
                return query;
            }
            else if (DictSYName == "zcsyb")
            {
                var query = from zcb in db.zcbs
                            where zcb.CODE.Contains(keyword) || zcb.NAME.Contains(keyword) 
                            orderby zcb.SORTID
                            select zcb;
                return query;
            }

            return null;
        }

        public void SaveDict() { db.SubmitChanges(); }

    }

}
