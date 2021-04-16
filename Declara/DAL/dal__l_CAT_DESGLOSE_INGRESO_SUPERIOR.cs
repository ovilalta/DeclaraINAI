using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_DESGLOSE_INGRESO_SUPERIOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR> lista_CAT_DESGLOSE_INGRESO_SUPERIORs { get; set; }
        internal List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR> base_CAT_DESGLOSE_INGRESO_SUPERIORs { get; set; }

        internal IntegerFilter NID_INGRESO_SUPERIOR { get; set; }
        internal ListFilter<Int32> NID_INGRESO_SUPERIORs { get; set; }

        internal StringFilter V_INGRESO_SUPERIOR { get; set; }
        internal ListFilter<String> V_INGRESO_SUPERIORs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_DESGLOSE_INGRESO_SUPERIOR()
        {
            NID_INGRESO_SUPERIORs = new ListFilter<Int32>();
            V_INGRESO_SUPERIORs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_DESGLOSE_INGRESO_SUPERIOR
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_DESGLOSE_INGRESO_SUPERIOR in db.CAT_DESGLOSE_INGRESO_SUPERIOR
                    select new Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR
                    {
                        NID_INGRESO_SUPERIOR = qCAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR,
                        V_INGRESO_SUPERIOR = qCAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR,
                    };
        }
        protected void Single_Where()
        {
            if (NID_INGRESO_SUPERIORs.Values.Count > 0) single_query = (NID_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR)) : single_query.Where(p => !NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR>(NID_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR.Properties.NID_INGRESO_SUPERIOR, single_query);

            if (V_INGRESO_SUPERIORs.Values.Count > 0) single_query = (V_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_INGRESO_SUPERIORs.Values.Contains(p.V_INGRESO_SUPERIOR)) : single_query.Where(p => !V_INGRESO_SUPERIORs.Values.Contains(p.V_INGRESO_SUPERIOR));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR>(V_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR.Properties.V_INGRESO_SUPERIOR, single_query);

        }
        protected void Where()
        {
            if (NID_INGRESO_SUPERIORs.Values.Count > 0) query = (NID_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR)) : query.Where(p => !NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR>(NID_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR.Properties.NID_INGRESO_SUPERIOR, query);

            if (V_INGRESO_SUPERIORs.Values.Count > 0) query = (V_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_INGRESO_SUPERIORs.Values.Contains(p.V_INGRESO_SUPERIOR)) : query.Where(p => !V_INGRESO_SUPERIORs.Values.Contains(p.V_INGRESO_SUPERIOR));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR>(V_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR.Properties.V_INGRESO_SUPERIOR, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_DESGLOSE_INGRESO_SUPERIORs = single_query.AsNoTracking().ToList();
            else
                base_CAT_DESGLOSE_INGRESO_SUPERIORs = new List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_DESGLOSE_INGRESO_SUPERIORs = query.AsNoTracking().ToList();
            else
                lista_CAT_DESGLOSE_INGRESO_SUPERIORs = new List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR> r;
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
