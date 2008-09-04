using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GreenTea.OQL
{
    [Serializable]
    public abstract class AbstractCondition :ICondition 
    {
        public abstract override string ToString();
        public abstract XmlDocument ToXml();


        #region Operator Overloading

        public static AbstractCondition operator &(AbstractCondition lcdt, AbstractCondition rcdt)
        {
            return new LogicalCondition(lcdt, rcdt,LogicalOP.And);
        }

        public static AbstractCondition operator |(AbstractCondition lcdt, AbstractCondition rcdt)
        {
            return new LogicalCondition(lcdt, rcdt, LogicalOP.Or);
        }
        
        public static AbstractCondition operator !(AbstractCondition cdt)
        {
            return new NotCondition(cdt);
        }

        /// <summary>
        /// See here for details:
        /// http://steve.emxsoftware.com/NET/Overloading+the++and++operators
        /// </summary>
        public static bool operator false(AbstractCondition cdt)
        {
            return false;
        }

        /// <summary>
        /// See here for details:
        /// http://steve.emxsoftware.com/NET/Overloading+the++and++operators
        /// </summary>
        public static bool operator true(AbstractCondition cdt)
        {
            return false;
        }

        #endregion


     

    }

}
