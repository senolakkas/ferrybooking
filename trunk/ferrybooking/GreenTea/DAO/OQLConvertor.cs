using System;
using System.Collections.Generic;
using System.Text;
using GreenTea.OQL;
using NHibernate;
using NHibernate.Expression;
using System.Data;

namespace GreenTea.DAO
{
    public class OQLConvertor
    {
        private OQLConvertor()
        {
        }

        private static MatchMode ConvertLikeMode2NHMatchMode(LikeMode likeMode)
        {
            switch (likeMode)
            {
                case LikeMode.Exact:
                    return MatchMode.Exact;
                case LikeMode.Start:
                    return MatchMode.Start;
                case LikeMode.End:
                    return MatchMode.End;
                case LikeMode.Anywhere:
                    return MatchMode.Anywhere;
                default:
                    return null;
            }
        }

        private static ICriterion ConvertCondition2NHCriterion(ICondition condition)
        {
            if (condition is ExampleCondition)
            {
                ExampleCondition ec = (ExampleCondition)condition;
                Example e = Example.Create(ec.Entity);
                e.ExcludeZeroes();
                e.ExcludeProperty("ID");
                if(ec.IsLikeEnabled)
                {
                    e.EnableLike(ConvertLikeMode2NHMatchMode(ec.LikeMode));
                }
                return e;
            }
            if (condition is LikeCondition)
            {
                LikeCondition lc = (LikeCondition)condition;
                return Expression.Like(lc.PropertyName, lc.Value.ToString(), ConvertLikeMode2NHMatchMode(lc.LikeMode));
            }
            if (condition is NotNullCondition)
            {
                NotNullCondition nnc = (NotNullCondition)condition;
                return Expression.IsNotNull(nnc.PropertyName);
            }
            if (condition is SubOQLCondition)
            {
                SubOQLCondition sc = (SubOQLCondition)condition;
                switch (sc.SubQueryOP)
                {
                    case SubQueryOP.Exists:
                        return Subqueries.Exists(ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.NotExists:
                        return Subqueries.NotExists(ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyIn:
                        return Subqueries.PropertyIn(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyNotIn:
                        return Subqueries.PropertyNotIn(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyEq:
                        return Subqueries.PropertyEq(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyNe:
                        return Subqueries.PropertyNe(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyGt:
                        return Subqueries.PropertyGt(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyLt:
                        return Subqueries.PropertyLt(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyGe:
                        return Subqueries.PropertyGe(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.PropertyLe:
                        return Subqueries.PropertyLe(sc.Propertyname, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueIn:
                        return Subqueries.In(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueNotIn:
                        return Subqueries.NotIn(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueEq:
                        return Subqueries.Eq(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueNe:
                        return Subqueries.Ne(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueGt:
                        return Subqueries.Gt(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueLt:
                        return Subqueries.Lt(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueGe:
                        return Subqueries.Ge(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    case SubQueryOP.ValueLe:
                        return Subqueries.Le(sc.Value, ConvertOQL2NHCriteria(sc.SubOQL));
                    default:
                        return null;
                }
            }
            if (condition is ExpressionCondition)
            {
                ExpressionCondition ec = (ExpressionCondition)condition;
                switch (ec.ExpressionOP)
                {
                    case ExpressionOP.Eq:
                        return Expression.Eq(ec.PropertyName, ec.Value);
                    case ExpressionOP.Ge:
                        return Expression.Ge(ec.PropertyName, ec.Value);
                    case ExpressionOP.Gt:
                        return Expression.Gt(ec.PropertyName, ec.Value);
                    case ExpressionOP.Le:
                        return Expression.Le(ec.PropertyName, ec.Value);
                    case ExpressionOP.Lt:
                        return Expression.Lt(ec.PropertyName, ec.Value);
                    default:
                        return null;
                }
            }

            if (condition is LogicalCondition)
            {
                LogicalCondition lc = (LogicalCondition)condition;
                switch (lc.Op)
                {
                    case LogicalOP.And:
                        return Expression.And(ConvertCondition2NHCriterion(lc.LeftHandSide),ConvertCondition2NHCriterion(lc.RightHandSide));
                    case LogicalOP.Or:
                        return Expression.Or(ConvertCondition2NHCriterion(lc.LeftHandSide), ConvertCondition2NHCriterion(lc.RightHandSide));
                    default:
                        return null;
                }
            }

            if (condition is NullCondition)
            {
                NullCondition nc = (NullCondition)condition;
                return Expression.IsNull(nc.PropertyName);
            }

            if (condition is BetweenCondition)
            {
                BetweenCondition bc = (BetweenCondition)condition;
                return Expression.Between(bc.PropertyName, bc.LowValue, bc.HightValue);
            }

            if (condition is InCondition)
            {
                InCondition ic = (InCondition)condition;
                return Expression.In(ic.PropertyName,ic.Values);
            }

            if (condition is NotCondition)
            {
                NotCondition nc = (NotCondition)condition;
                return Expression.Not(ConvertCondition2NHCriterion(nc.Condition));
            }

            if (condition is PropertyCondition)
            {
                PropertyCondition pc = (PropertyCondition)condition;
                switch (pc.ExpressionOP)
                {
                    case ExpressionOP.Eq:
                        return Expression.EqProperty(pc.LHSPropertyName, pc.RHSPropertyName);
                    case ExpressionOP.Ge:
                        return Expression.GeProperty(pc.LHSPropertyName, pc.RHSPropertyName);
                    case ExpressionOP.Gt:
                        return Expression.GtProperty(pc.LHSPropertyName, pc.RHSPropertyName);
                    case ExpressionOP.Le:
                        return Expression.LeProperty(pc.LHSPropertyName, pc.RHSPropertyName);
                    case ExpressionOP.Lt:
                        return Expression.LtProperty(pc.LHSPropertyName, pc.RHSPropertyName);
                    default:
                        return null;
                }

            }

            if (condition is EmptyCondition)
            {
                EmptyCondition ec = (EmptyCondition)condition;
                return Expression.IsEmpty(ec.PropertyName);
            }

            if (condition is JunctionCondition)
            {
                JunctionCondition jc = (JunctionCondition)condition;
                Junction j = null;
                switch (jc.LogicalOP)
                {
                    case LogicalOP.And:
                        j = Expression.Conjunction();
                        break;
                    case LogicalOP.Or:
                        j = Expression.Disjunction();
                        break;
                    default:
                        j = null;
                        break;
                }
                foreach (ICondition c in jc.Conditions)
                {
                    j.Add(ConvertCondition2NHCriterion(c));
                }
                return j;

            }

            if (condition is NotEmptyCondition)
            {
                NotEmptyCondition nec = (NotEmptyCondition)condition;
                return Expression.IsNotEmpty(nec.PropertyName);
            }

            return null;

        }

        public static DetachedCriteria ConvertOQL2NHCriteria(GreenTea.OQL.OQL oql)
        {
            DetachedCriteria dc = DetachedCriteria.For(oql.DomainObjectType);
            
            ProjectionList projectionList = Projections.ProjectionList();
            foreach (SelectColumn selectCol in oql.SelectColumns)
            {
                switch (selectCol.SelectOP)
                {
                    case SelectOP.Column:
                        if (string.IsNullOrEmpty(selectCol.Alias))
                        {
                            if (oql.IsDistinct && projectionList.Length == 0)
                            {
                                projectionList.Add(Projections.Distinct(Projections.Property(selectCol.PropertyName)));
                            }
                            projectionList.Add(Projections.Property(selectCol.PropertyName));
                        }
                        else
                        {
                            if (oql.IsDistinct && projectionList.Length == 0)
                            {
                                projectionList.Add(Projections.Distinct(Projections.Property(selectCol.PropertyName).As(selectCol.Alias)));
                            }
                            projectionList.Add(Projections.Property(selectCol.PropertyName).As(selectCol.Alias));
                        }
                        break;
                    case SelectOP.RowCount:
                        if (string.IsNullOrEmpty(selectCol.PropertyName))
                        {
                            projectionList.Add(Projections.RowCount());
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(selectCol.Alias))
                            {
                                if (selectCol.IsDistinct)
                                    projectionList.Add(Projections.CountDistinct(selectCol.PropertyName));
                                else
                                    projectionList.Add(Projections.Count(selectCol.PropertyName));
                            }
                            else
                            {
                                if (selectCol.IsDistinct)
                                    projectionList.Add(Projections.CountDistinct(selectCol.PropertyName).As(selectCol.Alias));
                                else
                                    projectionList.Add(Projections.Count(selectCol.PropertyName).As(selectCol.Alias));
                            }
                        }
                        break;
                    case SelectOP.Sum:
                        if (string.IsNullOrEmpty(selectCol.Alias))
                        {
                            projectionList.Add(Projections.Sum(selectCol.PropertyName));
                        }
                        else
                        {
                            projectionList.Add(Projections.Sum(selectCol.PropertyName).As(selectCol.Alias));
                        }
                        break;
                    case SelectOP.Avg:
                        if (string.IsNullOrEmpty(selectCol.Alias))
                        {
                            projectionList.Add(Projections.Avg(selectCol.PropertyName));
                        }
                        else
                        {
                            projectionList.Add(Projections.Avg(selectCol.PropertyName).As(selectCol.Alias));
                        }
                        break;
                    case SelectOP.Max:
                        if (string.IsNullOrEmpty(selectCol.Alias))
                        {
                            projectionList.Add(Projections.Max(selectCol.PropertyName));
                        }
                        else
                        {
                            projectionList.Add(Projections.Max(selectCol.PropertyName).As(selectCol.Alias));
                        }
                        break;
                    case SelectOP.Min:
                        if (string.IsNullOrEmpty(selectCol.Alias))
                        {
                            projectionList.Add(Projections.Min(selectCol.PropertyName));
                        }
                        else
                        {
                            projectionList.Add(Projections.Min(selectCol.PropertyName).As(selectCol.Alias));
                        }
                        break;
                    default:
                        break;
                }
            }
           

            foreach (SelectColumn groupbyCol in oql.GroupByColumns)
            {
                projectionList.Add(Projections.GroupProperty(groupbyCol.PropertyName));
            }

            if (projectionList.Length > 0)
            {
                dc.SetProjection(projectionList);
            }

            
            foreach (Association asso in oql.Associations)
            {
                NHibernate.SqlCommand.JoinType joinType;
                switch (asso.JoinMode)
                {
                    case JoinMode.InnerJoin:
                        joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                        break;
                    case JoinMode.LeftOuterJoin:
                        joinType = NHibernate.SqlCommand.JoinType.LeftOuterJoin;
                        break;
                    case JoinMode.RightOuterJoin:
                        joinType = NHibernate.SqlCommand.JoinType.RightOuterJoin;
                        break;
                    case JoinMode.FullJoin:
                        joinType = NHibernate.SqlCommand.JoinType.FullJoin;
                        break;
                    default:
                        joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                        break;
                }
                if (string.IsNullOrEmpty(asso.Alias))
                    dc.CreateAlias(asso.AssociationName, asso.AssociationName, joinType);
                else
                    dc.CreateAlias(asso.AssociationName, asso.Alias, joinType);
            }

            foreach (ICondition condition in oql.Conditions)
            {
                dc.Add(ConvertCondition2NHCriterion(condition));
            }

            foreach (OrderByColumn oc in oql.OrderByColumns)
            {
                switch (oc.OrderByDirect)
                {
                    case OrderByDirect.Asc:
                        dc.AddOrder(Order.Asc(oc.PropertyName));
                        break;
                    case OrderByDirect.Desc:
                        dc.AddOrder(Order.Desc(oc.PropertyName));
                        break;
                    default:
                        break;
                }
            }

            return dc;

        }

        public static string TestConvert(GreenTea.OQL.OQL oql)
        {
            return ConvertOQL2NHCriteria(oql).ToString();
        }


    }
}
