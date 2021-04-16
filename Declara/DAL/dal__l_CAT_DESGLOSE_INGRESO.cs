using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_DESGLOSE_INGRESO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO> lista_CAT_DESGLOSE_INGRESOs { get; set; }
        internal List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO> base_CAT_DESGLOSE_INGRESOs { get; set; }

        internal IntegerFilter NID_INGRESO_SUPERIOR { get; set; }
        internal ListFilter<Int32> NID_INGRESO_SUPERIORs { get; set; }

        internal IntegerFilter NID_INGRESO { get; set; }
        internal ListFilter<Int32> NID_INGRESOs { get; set; }

        internal StringFilter V_INGRESO { get; set; }
        internal ListFilter<String> V_INGRESOs { get; set; }

        internal System.Nullable<Boolean> L_VIGENTE { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_DESGLOSE_INGRESO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_DESGLOSE_INGRESO()
        {
            NID_INGRESO_SUPERIORs = new ListFilter<Int32>();
            NID_INGRESOs = new ListFilter<Int32>();
            V_INGRESOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_DESGLOSE_INGRESO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_DESGLOSE_INGRESO in db.CAT_DESGLOSE_INGRESO
                    join qCAT_DESGLOSE_INGRESO_SUPERIOR in db.CAT_DESGLOSE_INGRESO_SUPERIOR on qCAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR equals qCAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR
                    select new Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO
                    {
                        NID_INGRESO_SUPERIOR = qCAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR,
                        NID_INGRESO = qCAT_DESGLOSE_INGRESO.NID_INGRESO,
                        V_INGRESO = qCAT_DESGLOSE_INGRESO.V_INGRESO,
                        L_VIGENTE = qCAT_DESGLOSE_INGRESO.L_VIGENTE,
                        V_INGRESO_SUPERIOR = qCAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR,
                    };
        }
        protected void Single_Where()
        {
            if (NID_INGRESO_SUPERIORs.Values.Count > 0) single_query = (NID_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR)) : single_query.Where(p => !NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_DESGLOSE_INGRESO>(NID_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.NID_INGRESO_SUPERIOR, single_query);

            if (NID_INGRESOs.Values.Count > 0) single_query = (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INGRESOs.Values.Contains(p.NID_INGRESO)) : single_query.Where(p => !NID_INGRESOs.Values.Contains(p.NID_INGRESO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_DESGLOSE_INGRESO>(NID_INGRESO, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.NID_INGRESO, single_query);

            if (V_INGRESOs.Values.Count > 0) single_query = (V_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_INGRESOs.Values.Contains(p.V_INGRESO)) : single_query.Where(p => !V_INGRESOs.Values.Contains(p.V_INGRESO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_DESGLOSE_INGRESO>(V_INGRESO, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.V_INGRESO, single_query);

            if (L_VIGENTE.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_DESGLOSE_INGRESO>(p => p.L_VIGENTE == L_VIGENTE);

        }
        protected void Where()
        {
            if (NID_INGRESO_SUPERIORs.Values.Count > 0) query = (NID_INGRESO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR)) : query.Where(p => !NID_INGRESO_SUPERIORs.Values.Contains(p.NID_INGRESO_SUPERIOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO>(NID_INGRESO_SUPERIOR, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.NID_INGRESO_SUPERIOR, query);

            if (NID_INGRESOs.Values.Count > 0) query = (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INGRESOs.Values.Contains(p.NID_INGRESO)) : query.Where(p => !NID_INGRESOs.Values.Contains(p.NID_INGRESO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO>(NID_INGRESO, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.NID_INGRESO, query);

            if (V_INGRESOs.Values.Count > 0) query = (V_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_INGRESOs.Values.Contains(p.V_INGRESO)) : query.Where(p => !V_INGRESOs.Values.Contains(p.V_INGRESO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO>(V_INGRESO, Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO.Properties.V_INGRESO, query);

            if (L_VIGENTE.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO>(p => p.L_VIGENTE == L_VIGENTE);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_DESGLOSE_INGRESOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_DESGLOSE_INGRESOs = new List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_DESGLOSE_INGRESOs = query.AsNoTracking().ToList();
            else
                lista_CAT_DESGLOSE_INGRESOs = new List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_DESGLOSE_INGRESO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO> r;
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
