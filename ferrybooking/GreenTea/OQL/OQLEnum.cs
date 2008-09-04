using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public enum LikeMode
    {
        Exact,
        Start,
        End,
        Anywhere
    }

    public enum ExpressionOP
    {
        Eq,
        Ge,
        Gt,
        Le,
        Lt
    }

    public enum LogicalOP
    {
        And,
        Or
    }

    public enum SubQueryOP
    {
        Exists,
        NotExists,
        PropertyIn,
        PropertyNotIn,
        PropertyEq,
        PropertyNe,
        PropertyGt,
        PropertyLt,
        PropertyGe,
        PropertyLe,
        ValueIn,
        ValueNotIn,
        ValueEq,
        ValueNe,
        ValueGt,
        ValueLt,
        ValueGe,
        ValueLe
    }

    public enum SubQueryQuantifier
    {
        None,
        Some,
        All
    }

    public enum SelectOP
    {
        Column,
        RowCount,
        Sum,
        Avg,
        Max,
        Min,
        GroupBy
    }

    public enum OrderByDirect
    {
        Asc,
        Desc
    }

    public enum JoinMode
    {
        InnerJoin,
        LeftOuterJoin,
        RightOuterJoin,
        FullJoin
    }
    
}
