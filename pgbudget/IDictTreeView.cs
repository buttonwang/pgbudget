using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pgbudget
{
    // 摘要:
    //     形成定额、机材等字段表的Tree型试图。
    internal interface IDictTreeView
    {
        TreeNode DataToTreeView();
    }

}
 