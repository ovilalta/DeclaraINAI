using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.BLLD
{
    public class Lista<T> : List<T>
    {
        internal new void Add(T item)
        {
            base.Add(item);
        }

        public new void Remove(T item)
        {
            typeof(T).GetMethod("delete").Invoke(item, null);
            base.Remove(item);
        }

        public new void RemoveAt(Int32 Index)
        {
            typeof(T).GetMethod("delete").Invoke(base[Index], null);
            base.RemoveAt(Index);
        }

        public void delete(T item)
        {
            typeof(T).GetMethod("delete").Invoke(item, null);
            base.Remove(item);
        }

        //public int FindIndex(params Object[] keys)
        //{
        //    Expression<Func<T, bool>> predicate;

        //    MethodInfo method = null;
        //    MethodCallExpression filter = null;
        //    LambdaExpression predicate = null;
        //    MethodCallExpression expression = null;

        //    MemberExpression member = Expression.Property(param, typeof(T).GetProperty(field));
        //    ConstantExpression constant = Expression.Constant(value, System.Type.GetType("System.Int32"));


        //    foreach (Object o in keys)
        //    {
        //        ParameterExpression param = Expression.Parameter(typeof(T), field);
        //        method = typeof(string).GetMethod("Equals", new[] { typeof(string) });
        //        filter = Expression.Call(member, method, constant);
        //        predicate = Expression.Lambda(filter, param);
        //    }
        //}

    }
}
