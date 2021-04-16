using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2
{
    public class IntegerFilter
    {
        public enum FilterType
        {
            Equal,
            NotEqual,
            GreaterThanOrEqual,
            LessThanOrEqual,
        }

        private System.Nullable<Int32> _Value;
        public System.Nullable<Int32> Value
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


        private IntegerFilter()
        {
        }

        public IntegerFilter(System.Nullable<Int32> Value, FilterType FilterCondition)
        {
            this._Value = Value;
            this._FilterCondition = FilterCondition;
        }

        public IntegerFilter(System.Nullable<Int32> Value)
        {
            this._Value = Value;
            this._FilterCondition = FilterType.Equal;
        }

        internal static IQueryable<T> FilterBuilder<T>(IQueryable<T> query, IntegerFilter inf, String field)
        {
            String Where = "Where";
            System.Nullable<Int32> value = inf.Value;
            if (value.HasValue || typeof(T).GetProperty(field).PropertyType == typeof(Nullable<>))
            {
                BinaryExpression filter = null;
                LambdaExpression predicate = null;
                Expression expression = null;
                ParameterExpression param = Expression.Parameter(typeof(T), field);
                MemberExpression member = Expression.Property(param, typeof(T).GetProperty(field));
                ConstantExpression constant = Expression.Constant(value, typeof(T).GetProperty(field).PropertyType);
                //constant = (typeof(T).GetProperty(field).PropertyType == typeof(Nullable<>)) ? Expression.Constant(value, typeof(T).GetProperty(field).PropertyType) : Expression.Constant(value, inf.Value.Value.GetType());

                switch (inf.FilterCondition)
                {
                    case FilterType.Equal:
                        filter = Expression.Equal(member, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.NotEqual:
                        filter = Expression.NotEqual(member, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.GreaterThanOrEqual:
                        filter = Expression.GreaterThanOrEqual(member, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.LessThanOrEqual:
                        filter = Expression.LessThanOrEqual(member, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    default:
                        break;
                }
                query = query.Provider.CreateQuery<T>(expression);
            }
            return query;
        }
    }
}
