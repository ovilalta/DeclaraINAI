using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_AMBITO_PUBLICO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO> lista_CAT_AMBITO_PUBLICOs { get; set; }
        internal List<MODELDeclara_V2.CAT_AMBITO_PUBLICO> base_CAT_AMBITO_PUBLICOs { get; set; }

        internal IntegerFilter NID_AMBITO_PUBLICO { get; set; }
        internal ListFilter<Int32> NID_AMBITO_PUBLICOs { get; set; }

        internal StringFilter V_AMBITO_PUBLICO { get; set; }
        internal ListFilter<String> V_AMBITO_PUBLICOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_AMBITO_PUBLICO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_AMBITO_PUBLICO()
        {
            NID_AMBITO_PUBLICOs = new ListFilter<Int32>();
            V_AMBITO_PUBLICOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_AMBITO_PUBLICO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_AMBITO_PUBLICO in db.CAT_AMBITO_PUBLICO
                    select new Declara_V2.MODELextended.CAT_AMBITO_PUBLICO
                    {
                        NID_AMBITO_PUBLICO = qCAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO,
                        V_AMBITO_PUBLICO = qCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_AMBITO_PUBLICOs.Values.Count > 0) single_query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : single_query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_AMBITO_PUBLICO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.CAT_AMBITO_PUBLICO.Properties.NID_AMBITO_PUBLICO, single_query);

            if (V_AMBITO_PUBLICOs.Values.Count > 0) single_query = (V_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_AMBITO_PUBLICOs.Values.Contains(p.V_AMBITO_PUBLICO)) : single_query.Where(p => !V_AMBITO_PUBLICOs.Values.Contains(p.V_AMBITO_PUBLICO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_AMBITO_PUBLICO>(V_AMBITO_PUBLICO, Declara_V2.MODELextended.CAT_AMBITO_PUBLICO.Properties.V_AMBITO_PUBLICO, single_query);

        }
        protected void Where()
        {
            if (NID_AMBITO_PUBLICOs.Values.Count > 0) query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.CAT_AMBITO_PUBLICO.Properties.NID_AMBITO_PUBLICO, query);

            if (V_AMBITO_PUBLICOs.Values.Count > 0) query = (V_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_AMBITO_PUBLICOs.Values.Contains(p.V_AMBITO_PUBLICO)) : query.Where(p => !V_AMBITO_PUBLICOs.Values.Contains(p.V_AMBITO_PUBLICO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO>(V_AMBITO_PUBLICO, Declara_V2.MODELextended.CAT_AMBITO_PUBLICO.Properties.V_AMBITO_PUBLICO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_AMBITO_PUBLICOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_AMBITO_PUBLICOs = new List<MODELDeclara_V2.CAT_AMBITO_PUBLICO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_AMBITO_PUBLICOs = query.AsNoTracking().ToList();
            else
                lista_CAT_AMBITO_PUBLICOs = new List<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_AMBITO_PUBLICO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO> r;
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
