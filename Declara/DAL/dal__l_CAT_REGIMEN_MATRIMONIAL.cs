using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_REGIMEN_MATRIMONIAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL> lista_CAT_REGIMEN_MATRIMONIALs { get; set; }
        internal List<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL> base_CAT_REGIMEN_MATRIMONIALs { get; set; }

        internal IntegerFilter NID_REGIMEN_MATRIMONIAL { get; set; }
        internal ListFilter<Int32> NID_REGIMEN_MATRIMONIALs { get; set; }

        internal StringFilter V_REGIMEN_MATRIMONIAL { get; set; }
        internal ListFilter<String> V_REGIMEN_MATRIMONIALs { get; set; }

        private List<Order> _OrderByCriterios;
        internal List<Order> OrderByCriterios
        {
            get
            {
                if (_OrderByCriterios == null) _OrderByCriterios = new List<Order>();
                return _OrderByCriterios;
            }
            set { _OrderByCriterios = value; }
        }
        protected IQueryable<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_REGIMEN_MATRIMONIAL()
        {
            NID_REGIMEN_MATRIMONIALs = new ListFilter<Int32>();
            V_REGIMEN_MATRIMONIALs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_REGIMEN_MATRIMONIAL
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_REGIMEN_MATRIMONIAL in db.CAT_REGIMEN_MATRIMONIAL
                    select new Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL
                    {
                        NID_REGIMEN_MATRIMONIAL = qCAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL,
                        V_REGIMEN_MATRIMONIAL = qCAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL,
                    };
        }
        protected void Single_Where()
        {
            if (NID_REGIMEN_MATRIMONIALs.Values.Count > 0) single_query = (NID_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL)) : single_query.Where(p => !NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL>(NID_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, single_query);

            if (V_REGIMEN_MATRIMONIALs.Values.Count > 0) single_query = (V_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_REGIMEN_MATRIMONIALs.Values.Contains(p.V_REGIMEN_MATRIMONIAL)) : single_query.Where(p => !V_REGIMEN_MATRIMONIALs.Values.Contains(p.V_REGIMEN_MATRIMONIAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL>(V_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL.Properties.V_REGIMEN_MATRIMONIAL, single_query);

        }
        protected void Where()
        {
            if (NID_REGIMEN_MATRIMONIALs.Values.Count > 0) query = (NID_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL)) : query.Where(p => !NID_REGIMEN_MATRIMONIALs.Values.Contains(p.NID_REGIMEN_MATRIMONIAL));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL>(NID_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, query);

            if (V_REGIMEN_MATRIMONIALs.Values.Count > 0) query = (V_REGIMEN_MATRIMONIALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_REGIMEN_MATRIMONIALs.Values.Contains(p.V_REGIMEN_MATRIMONIAL)) : query.Where(p => !V_REGIMEN_MATRIMONIALs.Values.Contains(p.V_REGIMEN_MATRIMONIAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL>(V_REGIMEN_MATRIMONIAL, Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL.Properties.V_REGIMEN_MATRIMONIAL, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_REGIMEN_MATRIMONIALs = single_query.AsNoTracking().ToList();
            else
                base_CAT_REGIMEN_MATRIMONIALs = new List<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_REGIMEN_MATRIMONIALs = query.AsNoTracking().ToList();
            else
                lista_CAT_REGIMEN_MATRIMONIALs = new List<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                single_query = r;
            }
        }
        internal void orderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                query = r;
            }
        }
        internal void clearOrderBy()
        {
            _OrderByCriterios = null;
        }

        #endregion

    }
}
