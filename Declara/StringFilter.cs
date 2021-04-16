using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2
{
  
    public class StringFilter
    {
        public enum FilterType
        {
            equal,
            distinct,
            like,
            likeBegins,
            likeEnds,
            likeNot,
            likeNotBegins,
            likeNotEnds,
        }

        private String _Value;
        public String Value
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

        private Boolean _CaseSensitive;
        public Boolean CaseSensitive
        {
            get { return _CaseSensitive; }
            set { _CaseSensitive = value; }
        }

        //private Boolean _AccentSensitive;
        //private Boolean AccentSensitive
        //{
        //    get { return _AccentSensitive; }
        //    set { _AccentSensitive = value; }
        //}

        private StringFilter()
        {
        }

        public StringFilter(String Value, FilterType FilterCondition, Boolean CaseSensitive)
        {
            this._Value = Value.Trim();
            this._FilterCondition = FilterCondition;
            this._CaseSensitive = CaseSensitive;
            // this._AccentSensitive = false;
        }

        public StringFilter(String Value, FilterType FilterCondition)
            : this(Value, FilterCondition, false) { }

        public StringFilter(String Value, Boolean CaseSensitive)
            : this(Value, FilterType.equal, CaseSensitive) { }

        public StringFilter(String Value)
            : this(Value, FilterType.equal, false) { }

        internal static IQueryable<T> FilterBuilder<T>(IQueryable<T> query, StringFilter sf, String field)
        {
            String value = sf.Value;
            if (!String.IsNullOrEmpty(value))
            {
                ParameterExpression param = Expression.Parameter(typeof(T), field);
                Expression member = Expression.Property(param, typeof(T).GetProperty(field));
                Expression memberExpresion;
                MethodInfo method = null;
                MethodCallExpression filter = null;
                LambdaExpression predicate = null;
                MethodCallExpression expression = null;
                ConstantExpression constant;
                //StringComparison comparisonRule;

                value = (!sf.CaseSensitive) ? value.ToLower() : value;
                constant = Expression.Constant(value, System.Type.GetType("System.String"));

                if (sf.CaseSensitive)
                {
                    //if (sf.AccentSensitive)
                    //{
                    //    comparisonRule = StringComparison.CurrentCulture;
                    memberExpresion = member;
                    //}
                    //else
                    //{
                    //    comparisonRule = StringComparison.InvariantCulture;
                    //    memberExpresion = member;
                    //}
                }
                else
                {
                    //if (sf.AccentSensitive)
                    //{
                    //    comparisonRule = StringComparison.CurrentCultureIgnoreCase;
                    //    method = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
                    //    memberExpresion = MemberExpression.Call(member, method);
                    //}
                    //else
                    //{
                    //comparisonRule = StringComparison.InvariantCultureIgnoreCase;
                    method = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
                    memberExpresion = MemberExpression.Call(member, method);
                    //}
                }

                switch (sf.FilterCondition)
                {
                    case FilterType.equal:
                        method = typeof(String).GetMethod("Equals", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.distinct:
                        method = typeof(String).GetMethod("Equals", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(Expression.Not(filter), param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.like:
                        method = typeof(String).GetMethod("Contains", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.likeBegins:
                         method = typeof(String).GetMethod("StartsWith", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.likeEnds:
                        method = typeof(String).GetMethod("EndsWith", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(filter, param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.likeNot:
                        method = typeof(String).GetMethod("Contains", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(Expression.Not(filter), param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.likeNotBegins:
                        method = typeof(String).GetMethod("StartsWith", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(Expression.Not(filter), param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    case FilterType.likeNotEnds:
                        method = typeof(String).GetMethod("EndsWith", new[] { typeof(String) });
                        filter = Expression.Call(memberExpresion, method, constant);
                        predicate = Expression.Lambda(Expression.Not(filter), param);
                        expression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, predicate);
                        break;
                    default:
                        break;
                }

                query = query.Provider.CreateQuery<T>(expression);
                return query;
            }
            else
            {
                return query;
            }
        }


    }

    public static class StringExtension
    {
        public static String RemoveDiacritics(this String value)
        {
            String normalizedString = value.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}
