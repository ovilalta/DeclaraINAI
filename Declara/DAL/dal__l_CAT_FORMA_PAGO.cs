using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_FORMA_PAGO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_FORMA_PAGO> lista_CAT_FORMA_PAGOs { get; set; }
        internal List<MODELDeclara_V2.CAT_FORMA_PAGO> base_CAT_FORMA_PAGOs { get; set; }

        internal IntegerFilter NID_FORMA_PAGO { get; set; }
        internal ListFilter<Int32> NID_FORMA_PAGOs { get; set; }

        internal StringFilter V_FORMA_PAGO { get; set; }
        internal ListFilter<String> V_FORMA_PAGOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_FORMA_PAGO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_FORMA_PAGO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_FORMA_PAGO()
        {
            NID_FORMA_PAGOs = new ListFilter<Int32>();
            V_FORMA_PAGOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_FORMA_PAGO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_FORMA_PAGO in db.CAT_FORMA_PAGO
                    select new Declara_V2.MODELextended.CAT_FORMA_PAGO
                    {
                        NID_FORMA_PAGO = qCAT_FORMA_PAGO.NID_FORMA_PAGO,
                        V_FORMA_PAGO = qCAT_FORMA_PAGO.V_FORMA_PAGO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_FORMA_PAGOs.Values.Count > 0) single_query = (NID_FORMA_PAGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_FORMA_PAGOs.Values.Contains(p.NID_FORMA_PAGO)) : single_query.Where(p => !NID_FORMA_PAGOs.Values.Contains(p.NID_FORMA_PAGO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_FORMA_PAGO>(NID_FORMA_PAGO, Declara_V2.MODELextended.CAT_FORMA_PAGO.Properties.NID_FORMA_PAGO, single_query);

            if (V_FORMA_PAGOs.Values.Count > 0) single_query = (V_FORMA_PAGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_FORMA_PAGOs.Values.Contains(p.V_FORMA_PAGO)) : single_query.Where(p => !V_FORMA_PAGOs.Values.Contains(p.V_FORMA_PAGO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_FORMA_PAGO>(V_FORMA_PAGO, Declara_V2.MODELextended.CAT_FORMA_PAGO.Properties.V_FORMA_PAGO, single_query);

        }
        protected void Where()
        {
            if (NID_FORMA_PAGOs.Values.Count > 0) query = (NID_FORMA_PAGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_FORMA_PAGOs.Values.Contains(p.NID_FORMA_PAGO)) : query.Where(p => !NID_FORMA_PAGOs.Values.Contains(p.NID_FORMA_PAGO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_FORMA_PAGO>(NID_FORMA_PAGO, Declara_V2.MODELextended.CAT_FORMA_PAGO.Properties.NID_FORMA_PAGO, query);

            if (V_FORMA_PAGOs.Values.Count > 0) query = (V_FORMA_PAGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_FORMA_PAGOs.Values.Contains(p.V_FORMA_PAGO)) : query.Where(p => !V_FORMA_PAGOs.Values.Contains(p.V_FORMA_PAGO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_FORMA_PAGO>(V_FORMA_PAGO, Declara_V2.MODELextended.CAT_FORMA_PAGO.Properties.V_FORMA_PAGO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_FORMA_PAGOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_FORMA_PAGOs = new List<MODELDeclara_V2.CAT_FORMA_PAGO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_FORMA_PAGOs = query.AsNoTracking().ToList();
            else
                lista_CAT_FORMA_PAGOs = new List<Declara_V2.MODELextended.CAT_FORMA_PAGO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_FORMA_PAGO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_FORMA_PAGO> r;
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
