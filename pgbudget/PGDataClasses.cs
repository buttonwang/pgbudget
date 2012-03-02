using System;

namespace pgbudget
{

    public interface IDictIndex
    {
        string IndexValue { get; }

        string NodeValue { get; }
    }

    public partial class project
    {
    }

    public partial class PGDataClassesDataContext
    {
    }

    public partial class desyb : IDictIndex
    {
        string IDictIndex.IndexValue
        {
            get { return this.syID; }
        }

        string IDictIndex.NodeValue
        {
            get { return this.NodeId ;}   
        }
    }

    public partial class cjsyb : IDictIndex
    {
        string IDictIndex.IndexValue
        {
            get { return this.syID; }
        }

        string IDictIndex.NodeValue
        {
            get { return this.NodeId; }
        }
    }

    public partial class sbsyb : IDictIndex
    {
        string IDictIndex.IndexValue
        {
            get { return this.ID.ToString(); }
        }

        string IDictIndex.NodeValue
        {
            get { return this.LAYER; }
        }
    }

    public partial class zcsyb : IDictIndex
    {
        string IDictIndex.IndexValue
        {
            get { return this.ID.ToString(); }
        }

        string IDictIndex.NodeValue
        {
            get { return this.LAYER; }
        }
    }

}