using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_TITULAR : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_TITULAR> lista_CAT_TITULARs { get; set; }
        internal List<MODELDeclara_V2.CAT_TITULAR> base_CAT_TITULARs { get; set; }

        internal IntegerFilter NID_TITULAR { get; set; }
        internal ListFilter<Int32> NID_TITULARs { get; set; }

        internal StringFilter V_TITULAR { get; set; }
        internal ListFilter<String> V_TITULARs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_TITULAR> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TITULAR> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_TITULAR()
        {
            NID_TITULARs = new ListFilter<Int32>();
            V_TITULARs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_TITULAR
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_TITULAR in db.CAT_TITULAR
                    select new Declara_V2.MODELextended.CAT_TITULAR
                    {
                        NID_TITULAR = qCAT_TITULAR.NID_TITULAR,
                        V_TITULAR = qCAT_TITULAR.V_TITULAR,
                    };
        }
        protected void Single_Where()
        {
            if (NID_TITULARs.Values.Count > 0) single_query = (NID_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TITULARs.Values.Contains(p.NID_TITULAR)) : single_query.Where(p => !NID_TITULARs.Values.Contains(p.NID_TITULAR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TITULAR>(NID_TITULAR, Declara_V2.MODELextended.CAT_TITULAR.Properties.NID_TITULAR, single_query);

            if (V_TITULARs.Values.Count > 0) single_query = (V_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TITULARs.Values.Contains(p.V_TITULAR)) : single_query.Where(p => !V_TITULARs.Values.Contains(p.V_TITULAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TITULAR>(V_TITULAR, Declara_V2.MODELextended.CAT_TITULAR.Properties.V_TITULAR, single_query);

        }
        protected void Where()
        {
            if (NID_TITULARs.Values.Count > 0) query = (NID_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TITULARs.Values.Contains(p.NID_TITULAR)) : query.Where(p => !NID_TITULARs.Values.Contains(p.NID_TITULAR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TITULAR>(NID_TITULAR, Declara_V2.MODELextended.CAT_TITULAR.Properties.NID_TITULAR, query);

            if (V_TITULARs.Values.Count > 0) query = (V_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TITULARs.Values.Contains(p.V_TITULAR)) : query.Where(p => !V_TITULARs.Values.Contains(p.V_TITULAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TITULAR>(V_TITULAR, Declara_V2.MODELextended.CAT_TITULAR.Properties.V_TITULAR, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_TITULARs = single_query.AsNoTracking().ToList();
            else
                base_CAT_TITULARs = new List<MODELDeclara_V2.CAT_TITULAR>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_TITULARs = query.AsNoTracking().ToList();
            else
                lista_CAT_TITULARs = new List<Declara_V2.MODELextended.CAT_TITULAR>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TITULAR> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TITULAR> r;
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
