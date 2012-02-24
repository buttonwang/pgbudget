using System;
namespace pgbudget
{

    public interface IDictIndex
    {
        string IndexValue { get; }
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
            get
            {
                return this.syID;
            }
        }
    }
}
