using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_BIEN_ENAJENADO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO> lista_CAT_BIEN_ENAJENADOs { get; set; }
        internal List<MODELDeclara_V2.CAT_BIEN_ENAJENADO> base_CAT_BIEN_ENAJENADOs { get; set; }

        internal IntegerFilter NID_BIEN_ENAJENADO { get; set; }
        internal ListFilter<Int32> NID_BIEN_ENAJENADOs { get; set; }

        internal StringFilter V_BIEN_ENAJENADO { get; set; }
        internal ListFilter<String> V_BIEN_ENAJENADOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_BIEN_ENAJENADO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_BIEN_ENAJENADO()
        {
            NID_BIEN_ENAJENADOs = new ListFilter<Int32>();
            V_BIEN_ENAJENADOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_BIEN_ENAJENADO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_BIEN_ENAJENADO in db.CAT_BIEN_ENAJENADO
                    select new Declara_V2.MODELextended.CAT_BIEN_ENAJENADO
                    {
                        NID_BIEN_ENAJENADO = qCAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO,
                        V_BIEN_ENAJENADO = qCAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_BIEN_ENAJENADOs.Values.Count > 0) single_query = (NID_BIEN_ENAJENADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_BIEN_ENAJENADOs.Values.Contains(p.NID_BIEN_ENAJENADO)) : single_query.Where(p => !NID_BIEN_ENAJENADOs.Values.Contains(p.NID_BIEN_ENAJENADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_BIEN_ENAJENADO>(NID_BIEN_ENAJENADO, Declara_V2.MODELextended.CAT_BIEN_ENAJENADO.Properties.NID_BIEN_ENAJENADO, single_query);

            if (V_BIEN_ENAJENADOs.Values.Count > 0) single_query = (V_BIEN_ENAJENADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_BIEN_ENAJENADOs.Values.Contains(p.V_BIEN_ENAJENADO)) : single_query.Where(p => !V_BIEN_ENAJENADOs.Values.Contains(p.V_BIEN_ENAJENADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_BIEN_ENAJENADO>(V_BIEN_ENAJENADO, Declara_V2.MODELextended.CAT_BIEN_ENAJENADO.Properties.V_BIEN_ENAJENADO, single_query);

        }
        protected void Where()
        {
            if (NID_BIEN_ENAJENADOs.Values.Count > 0) query = (NID_BIEN_ENAJENADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_BIEN_ENAJENADOs.Values.Contains(p.NID_BIEN_ENAJENADO)) : query.Where(p => !NID_BIEN_ENAJENADOs.Values.Contains(p.NID_BIEN_ENAJENADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO>(NID_BIEN_ENAJENADO, Declara_V2.MODELextended.CAT_BIEN_ENAJENADO.Properties.NID_BIEN_ENAJENADO, query);

            if (V_BIEN_ENAJENADOs.Values.Count > 0) query = (V_BIEN_ENAJENADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_BIEN_ENAJENADOs.Values.Contains(p.V_BIEN_ENAJENADO)) : query.Where(p => !V_BIEN_ENAJENADOs.Values.Contains(p.V_BIEN_ENAJENADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO>(V_BIEN_ENAJENADO, Declara_V2.MODELextended.CAT_BIEN_ENAJENADO.Properties.V_BIEN_ENAJENADO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_BIEN_ENAJENADOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_BIEN_ENAJENADOs = new List<MODELDeclara_V2.CAT_BIEN_ENAJENADO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_BIEN_ENAJENADOs = query.AsNoTracking().ToList();
            else
                lista_CAT_BIEN_ENAJENADOs = new List<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_BIEN_ENAJENADO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO> r;
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
