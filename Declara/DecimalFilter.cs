using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2
{
    public class DecimalFilter
    {
         public enum FilterType
        {
            equal,
            distinct
        }

        private Decimal _Value;
        public Decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private FilterType _FilterCondition;
        public FilterType FilterCondition
        {
            get { return _FilterCondition; }
            set { _FilterCondition = value; }
        }


        private DecimalFilter()
        {
        }

        public DecimalFilter(Decimal Value, FilterType FilterCondition)
        {
            this._Value = Value;
            this._FilterCondition = FilterCondition;
        }

        public DecimalFilter(Decimal Value)
        {
            this._Value = Value;
            this._FilterCondition = FilterType.equal;
        }

        internal static IQueryable<T> FilterBuilder<T>(IQueryable<T> query, DecimalFilter inf, String field)
        {
            Decimal value = inf.Value;
            MethodInfo method = null;
            MethodCallExpression filter = null;
            LambdaExpression predicate = null;
            MethodCallExpression expression = null;
            ParameterExpression param = Expression.Parameter(typeof(T), field);
            MemberExpression member = Expression.Property(param, typeof(T).GetProperty(field));
            ConstantExpression constant = Expression.Constant(value, System.Type.GetType("System.Decimal"));

            switch (inf.FilterCondition)
            {
                case FilterType.equal:
                    method = typeof(string).GetMethod("Equals", new[] { typeof(string) });
                    filter = Expression.Call(member, method, constant);
                    predicate = Expression.Lambda(filter, param);
                    expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                    break;
                case FilterType.distinct:
                    method = typeof(string).GetMethod("Equals", new[] { typeof(string) });
                    filter = Expression.Call(member, method, constant);
                    predicate = Expression.Lambda(Expression.Not(filter), param);
                    expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                    break;
                default:
                    break;
            }
            query = query.Provider.CreateQuery<T>(expression);
            return query;
        }
    }
}
