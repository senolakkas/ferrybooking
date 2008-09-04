using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GreenTea.OQL
{
    public sealed class Condition
    {
        private Condition()
        {
            //can not be instantiated
        }

        public static ExpressionCondition Eq(string propertyName, object value)
        {
            return new ExpressionCondition(propertyName, value, ExpressionOP.Eq);
        }

        public static LikeCondition Like(string propertyName, object value)
        {
            return new LikeCondition(propertyName, value);
        }

        public static LikeCondition Like(string propertyName, string value, LikeMode likeMode)
        {
            return new LikeCondition(propertyName, value, likeMode);
        }


        public static ExpressionCondition Gt(string propertyName, object value)
        {
            return new ExpressionCondition(propertyName, value, ExpressionOP.Gt);
        }

        public static ExpressionCondition Lt(string propertyName, object value)
        {
            return new ExpressionCondition(propertyName, value, ExpressionOP.Lt);
        }

        public static ExpressionCondition Le(string propertyName, object value)
        {
            return new ExpressionCondition(propertyName, value, ExpressionOP.Le);
        }

        public static ExpressionCondition Ge(string propertyName, object value)
        {
            return new ExpressionCondition(propertyName, value, ExpressionOP.Ge);
        }

        public static BetweenCondition Between(string propertyName, object lo, object hi)
        {
            return new BetweenCondition(propertyName, lo, hi);
        }

        public static InCondition In(string propertyName, object[] values)
        {
            return new InCondition(propertyName, values);
        }

        public static InCondition In(string propertyName, ICollection values)
        {
            object[] ary = new object[values.Count];
            values.CopyTo(ary, 0);
            return new InCondition(propertyName, ary);
        }


        public static InCondition InG<T>(string propertyName, ICollection<T> values)
		{
			object[] array = new object[values.Count];
			int i = 0;
			foreach (T item in values)
			{
				array[i] = item;
				i++;
			}
            return new InCondition(propertyName, array);
		}


        public static NullCondition IsNull(string propertyName)
        {
            return new NullCondition(propertyName);
        }

        public static PropertyCondition EqProperty(string propertyName, string otherPropertyName)
        {
            return new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Eq);
        }

        public static ICondition NotEqProperty(string propertyName, string otherPropertyName)
        {
            return new NotCondition(new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Eq));
        }

        public static PropertyCondition GtProperty(string propertyName, string otherPropertyName)
        {
            return new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Gt);
        }

        public static PropertyCondition GeProperty(string propertyName, string otherPropertyName)
        {
            return new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Ge);
        }

        public static PropertyCondition LtProperty(string propertyName, string otherPropertyName)
        {
            return new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Lt);
        }

        public static PropertyCondition LeProperty(string propertyName, string otherPropertyName)
        {
            return new PropertyCondition(propertyName, otherPropertyName, ExpressionOP.Le);
        }

        public static NotNullCondition IsNotNull(string propertyName)
        {
            return new NotNullCondition(propertyName);
        }

        public static NotEmptyCondition IsNotEmpty(string propertyName)
        {
            return new NotEmptyCondition(propertyName);
        }

        public static EmptyCondition IsEmpty(string propertyName)
        {
            return new EmptyCondition(propertyName);
        }

        public static LogicalCondition And(ICondition lhs, ICondition rhs)
        {
            return new LogicalCondition(lhs, rhs, LogicalOP.And);
        }

        public static LogicalCondition Or(ICondition lhs, ICondition rhs)
        {
            return new LogicalCondition(lhs, rhs, LogicalOP.Or);
        }

        public static NotCondition Not(ICondition condition)
        {
            return new NotCondition(condition);
        }

        public static JunctionCondition Conjunction()
        {
            return new JunctionCondition( LogicalOP.And );
        }

        public static JunctionCondition Disjunction()
        {
            return new JunctionCondition(LogicalOP.Or);
        }

        public static JunctionCondition AllEq(IDictionary propertyNameValues)
        {
            JunctionCondition conj = Conjunction();

            foreach (DictionaryEntry item in propertyNameValues)
            {
                conj.AddCondition(Eq(item.Key.ToString(), item.Value));
            }

            return conj;
        }

        public static ExampleCondition EqExample(object Entity)
        {
            return new ExampleCondition(Entity, false, LikeMode.Anywhere);
        }

        public static ExampleCondition LikeExample(object Entity)
        {
            return LikeExample(Entity, LikeMode.Start);
        }

        public static ExampleCondition LikeExample(object Entity, LikeMode likeMode)
        {
            return new ExampleCondition(Entity, true, likeMode);
        }
    }
}
