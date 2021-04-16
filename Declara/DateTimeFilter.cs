using Declara_V2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2
{
    public class DateTimeFilter
    {
        private const String Where = "Where";
        public enum FilterType
        {
            MoreThan,
            LessThan
        }

        private System.Nullable<DateTime> _InitialValue;
        public System.Nullable<DateTime> InitialValue
        {
            get { return _InitialValue; }
            set { _InitialValue = value; }
        }

        private System.Nullable<DateTime> _FinallValue;
        public System.Nullable<DateTime> FinalValue
        {
            get { return _FinallValue; }
            set { _FinallValue = value; }
        }

        private FilterType _FilterCondition;
        public FilterType FilterCondition
        {
            get { return _FilterCondition; }
            set { _FilterCondition = value; }
        }


        private DateTimeFilter()
        {
        }

        public DateTimeFilter(DateTime InitialValue, DateTime FinalValue)
        {
            this._InitialValue = InitialValue;
            this._FinallValue = FinalValue;
        }

        public DateTimeFilter(DateTime InitialValue, FilterType FilterCondition)
        {
            this._InitialValue = InitialValue;
            this.FinalValue = null;
            this._FilterCondition = FilterCondition;
        }

        public DateTimeFilter(DateTime InitialValue)
        {
            this._InitialValue = InitialValue;
            this.FinalValue = null;
            this._FilterCondition = FilterType.MoreThan;
        }

        internal static IQueryable<T> FilterBuilder<T>(IQueryable<T> query, DateTimeFilter inf, String field)
        {
            if (inf != null)
            {
                System.Nullable<DateTime> InitialValue = inf.InitialValue;
                if (InitialValue.HasValue)
                {
                    System.Nullable<DateTime> FinalValue = inf.FinalValue;
                    ParameterExpression parameter = Expression.Parameter(typeof(T), field);
                    MemberExpression member = Expression.Property(parameter, typeof(T).GetProperty(field)); //x.Id
                    ConstantExpression Initialconstant;
                    ConstantExpression Finalconstant;
                    BinaryExpression body;
                    Expression expression;
                    LambdaExpression predicate;

                    if (InitialValue.HasValue && FinalValue.HasValue)
                    {
                        if (InitialValue.Value > FinalValue.Value)
                            throw new CustomException("La fecha inicial no puede ser mayor que la fecha final");
                        Initialconstant = Expression.Constant(InitialValue.Value);
                        if (FinalValue.Value.Hour == 0 && FinalValue.Value.Minute == 0 && FinalValue.Value.Second == 0)
                            FinalValue = FinalValue.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                        Finalconstant = Expression.Constant(FinalValue.Value);

                        body = Expression.GreaterThanOrEqual(member, Initialconstant);
                        predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        query = query.Provider.CreateQuery<T>(expression);
                        body = Expression.LessThanOrEqual(member, Finalconstant);
                        predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
                        expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                        query = query.Provider.CreateQuery<T>(expression);
                    }
                    else
                    {
                        switch (inf.FilterCondition)
                        {
                            case FilterType.MoreThan:
                                Initialconstant = Expression.Constant(InitialValue.Value);
                                body = Expression.GreaterThanOrEqual(member, Initialconstant);
                                predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
                                expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                                query = query.Provider.CreateQuery<T>(expression);
                                break;
                            case FilterType.LessThan:
                                Initialconstant = Expression.Constant(InitialValue.Value);
                                body = Expression.LessThanOrEqual(member, Initialconstant);
                                predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
                                expression = Expression.Call(typeof(Queryable), Where, new Type[] { query.ElementType }, query.Expression, predicate);
                                query = query.Provider.CreateQuery<T>(expression);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                       
                    }
                }
            }
            
            return query;
        }
    }
}
