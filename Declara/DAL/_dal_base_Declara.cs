using System;
using System.Linq;

namespace Declara_V2.DAL
{
    internal class _dal_base_Declara
    {
        protected System.Nullable<Boolean> _lEsNuevoRegistro;
        internal System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return _lEsNuevoRegistro; }
        }



        protected MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
        public _dal_base_Declara()
        {
            _lEsNuevoRegistro = false;
        }


        protected IQueryable<T> StringFilterBuilder<T>(StringFilter Value, String Field, IQueryable<T> query)
        {
            if (Value != null) return query = StringFilter.FilterBuilder<T>(query, Value, Field);
            else return query;
        }

        protected IQueryable<T> StringFilterBuilder<T>(StringFilter Value, Object Field, IQueryable<T> query)
        {
            if (Value != null) return query = StringFilter.FilterBuilder<T>(query, Value, Field.ToString());
            else return query;
        }

        protected IQueryable<T> IntegerFilterBuilder<T>(IntegerFilter Value, String Field, IQueryable<T> query)
        {
            if (Value != null) return query = IntegerFilter.FilterBuilder<T>(query, Value, Field);
            else return query;
        }

        protected IQueryable<T> IntegerFilterBuilder<T>(IntegerFilter Value, Object Field, IQueryable<T> query)
        {
            if (Value != null) return query = IntegerFilter.FilterBuilder<T>(query, Value, Field.ToString());
            else return query;
        }

        protected IQueryable<T> DecimalFilterBuilder<T>(DecimalFilter Value, String Field, IQueryable<T> query)
        {
            if (Value != null) return query = DecimalFilter.FilterBuilder<T>(query, Value, Field);
            else return query;
        }

        protected IQueryable<T> DateTimeFilterBuilder<T>(DateTimeFilter Value, String Field, IQueryable<T> query)
        {
            if (Value != null) return query = DateTimeFilter.FilterBuilder<T>(query, Value, Field);
            else return query;
        }

        protected IQueryable<T> DecimalFilterBuilder<T>(DecimalFilter Value, Object Field, IQueryable<T> query)
        {
            if (Value != null) return query = DecimalFilter.FilterBuilder<T>(query, Value, Field.ToString());
            else return query;
        }

        protected IQueryable<T> DateTimeFilterBuilder<T>(DateTimeFilter Value, Object Field, IQueryable<T> query)
        {
            if (Value != null) return query = DateTimeFilter.FilterBuilder<T>(query, Value, Field.ToString());
            else return query;
        }
    }
}