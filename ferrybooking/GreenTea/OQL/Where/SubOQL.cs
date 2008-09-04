using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class SubOQL
    {
        public static AbstractCondition Exists(OQL subOql)
        {
            return new SubOQLCondition( subOql, SubQueryOP.Exists, SubQueryQuantifier.None);
        }

        public static AbstractCondition NotExists(OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.NotExists, SubQueryQuantifier.None);
        }

        public static AbstractCondition PropertyEqAll(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyEq, SubQueryQuantifier.All, propertyName,null);
        }

        public static AbstractCondition PropertyIn(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyIn, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyNotIn(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyNotIn, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyEq(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyEq, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyNe(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyNe, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyGt(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGt, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyLt(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLt, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyGe(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGe, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyLe(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLe, SubQueryQuantifier.None, propertyName, null);
        }

        public static AbstractCondition PropertyGtAll(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGt, SubQueryQuantifier.All, propertyName, null);
        }

        public static AbstractCondition PropertyLtAll(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLt, SubQueryQuantifier.All, propertyName, null);
        }

        public static AbstractCondition PropertyGeAll(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGe, SubQueryQuantifier.All, propertyName, null);
        }

        public static AbstractCondition PropertyLeAll(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLe, SubQueryQuantifier.All, propertyName, null);
        }

        public static AbstractCondition PropertyGtSome(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGt, SubQueryQuantifier.Some, propertyName, null);
        }

        public static AbstractCondition PropertyLtSome(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLt, SubQueryQuantifier.Some, propertyName, null);
        }

        public static AbstractCondition PropertyGeSome(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyGe, SubQueryQuantifier.Some, propertyName, null);
        }

        public static AbstractCondition PropertyLeSome(String propertyName, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.PropertyLe, SubQueryQuantifier.Some, propertyName, null);
        }

        public static AbstractCondition EqAll(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueEq, SubQueryQuantifier.All,null,value);
        }

        public static AbstractCondition In(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueIn, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition NotIn(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueNotIn, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Eq(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueEq, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Gt(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGt, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Lt(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLt, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Ge(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGe, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Le(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLe, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition Ne(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueNe, SubQueryQuantifier.None, null, value);
        }

        public static AbstractCondition GtAll(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGt, SubQueryQuantifier.All, null, value);
        }

        public static AbstractCondition LtAll(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLt, SubQueryQuantifier.All, null, value);
        }

        public static AbstractCondition GeAll(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGe, SubQueryQuantifier.All, null, value);
        }

        public static AbstractCondition LeAll(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLe, SubQueryQuantifier.All, null, value);
        }

        public static AbstractCondition GtSome(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGt, SubQueryQuantifier.Some, null, value);
        }

        public static AbstractCondition LtSome(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLt, SubQueryQuantifier.Some, null, value);
        }

        public static AbstractCondition GeSome(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueGe, SubQueryQuantifier.Some, null, value);
        }

        public static AbstractCondition LeSome(Object value, OQL subOql)
        {
            return new SubOQLCondition(subOql, SubQueryOP.ValueLe, SubQueryQuantifier.Some, null, value);
        }
    }
}
