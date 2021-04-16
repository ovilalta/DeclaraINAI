using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_RELACION_TRANSMISOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR> lista_CAT_RELACION_TRANSMISORs { get; set; }
        internal List<MODELDeclara_V2.CAT_RELACION_TRANSMISOR> base_CAT_RELACION_TRANSMISORs { get; set; }

        internal IntegerFilter NID_RELACION_TRANSMISOR { get; set; }
        internal ListFilter<Int32> NID_RELACION_TRANSMISORs { get; set; }

        internal StringFilter V_RELACION_TRANSMISOR { get; set; }
        internal ListFilter<String> V_RELACION_TRANSMISORs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_RELACION_TRANSMISOR> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_RELACION_TRANSMISOR()
        {
            NID_RELACION_TRANSMISORs = new ListFilter<Int32>();
            V_RELACION_TRANSMISORs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_RELACION_TRANSMISOR
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_RELACION_TRANSMISOR in db.CAT_RELACION_TRANSMISOR
                    select new Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR
                    {
                        NID_RELACION_TRANSMISOR = qCAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR,
                        V_RELACION_TRANSMISOR = qCAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR,
                    };
        }
        protected void Single_Where()
        {
            if (NID_RELACION_TRANSMISORs.Values.Count > 0) single_query = (NID_RELACION_TRANSMISORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RELACION_TRANSMISORs.Values.Contains(p.NID_RELACION_TRANSMISOR)) : single_query.Where(p => !NID_RELACION_TRANSMISORs.Values.Contains(p.NID_RELACION_TRANSMISOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_RELACION_TRANSMISOR>(NID_RELACION_TRANSMISOR, Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, single_query);

            if (V_RELACION_TRANSMISORs.Values.Count > 0) single_query = (V_RELACION_TRANSMISORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RELACION_TRANSMISORs.Values.Contains(p.V_RELACION_TRANSMISOR)) : single_query.Where(p => !V_RELACION_TRANSMISORs.Values.Contains(p.V_RELACION_TRANSMISOR));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_RELACION_TRANSMISOR>(V_RELACION_TRANSMISOR, Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR, single_query);

        }
        protected void Where()
        {
            if (NID_RELACION_TRANSMISORs.Values.Count > 0) query = (NID_RELACION_TRANSMISORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RELACION_TRANSMISORs.Values.Contains(p.NID_RELACION_TRANSMISOR)) : query.Where(p => !NID_RELACION_TRANSMISORs.Values.Contains(p.NID_RELACION_TRANSMISOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR>(NID_RELACION_TRANSMISOR, Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, query);

            if (V_RELACION_TRANSMISORs.Values.Count > 0) query = (V_RELACION_TRANSMISORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RELACION_TRANSMISORs.Values.Contains(p.V_RELACION_TRANSMISOR)) : query.Where(p => !V_RELACION_TRANSMISORs.Values.Contains(p.V_RELACION_TRANSMISOR));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR>(V_RELACION_TRANSMISOR, Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_RELACION_TRANSMISORs = single_query.AsNoTracking().ToList();
            else
                base_CAT_RELACION_TRANSMISORs = new List<MODELDeclara_V2.CAT_RELACION_TRANSMISOR>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_RELACION_TRANSMISORs = query.AsNoTracking().ToList();
            else
                lista_CAT_RELACION_TRANSMISORs = new List<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_RELACION_TRANSMISOR> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR> r;
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
