using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_INSTRUMENTO_RENDIMIENTO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO> lista_CAT_INSTRUMENTO_RENDIMIENTOs { get; set; }
        internal List<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO> base_CAT_INSTRUMENTO_RENDIMIENTOs { get; set; }

        internal IntegerFilter NID_INSTRUMENTO_RENDIMIENTO { get; set; }
        internal ListFilter<Int32> NID_INSTRUMENTO_RENDIMIENTOs { get; set; }

        internal StringFilter V_INSTRUMENTO_RENDIMIENTO { get; set; }
        internal ListFilter<String> V_INSTRUMENTO_RENDIMIENTOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_INSTRUMENTO_RENDIMIENTO()
        {
            NID_INSTRUMENTO_RENDIMIENTOs = new ListFilter<Int32>();
            V_INSTRUMENTO_RENDIMIENTOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_INSTRUMENTO_RENDIMIENTO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_INSTRUMENTO_RENDIMIENTO in db.CAT_INSTRUMENTO_RENDIMIENTO
                    select new Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO
                    {
                        NID_INSTRUMENTO_RENDIMIENTO = qCAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO,
                        V_INSTRUMENTO_RENDIMIENTO = qCAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_INSTRUMENTO_RENDIMIENTOs.Values.Count > 0) single_query = (NID_INSTRUMENTO_RENDIMIENTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.NID_INSTRUMENTO_RENDIMIENTO)) : single_query.Where(p => !NID_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.NID_INSTRUMENTO_RENDIMIENTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO>(NID_INSTRUMENTO_RENDIMIENTO, Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO.Properties.NID_INSTRUMENTO_RENDIMIENTO, single_query);

            if (V_INSTRUMENTO_RENDIMIENTOs.Values.Count > 0) single_query = (V_INSTRUMENTO_RENDIMIENTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.V_INSTRUMENTO_RENDIMIENTO)) : single_query.Where(p => !V_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.V_INSTRUMENTO_RENDIMIENTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO>(V_INSTRUMENTO_RENDIMIENTO, Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO.Properties.V_INSTRUMENTO_RENDIMIENTO, single_query);

        }
        protected void Where()
        {
            if (NID_INSTRUMENTO_RENDIMIENTOs.Values.Count > 0) query = (NID_INSTRUMENTO_RENDIMIENTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.NID_INSTRUMENTO_RENDIMIENTO)) : query.Where(p => !NID_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.NID_INSTRUMENTO_RENDIMIENTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO>(NID_INSTRUMENTO_RENDIMIENTO, Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO.Properties.NID_INSTRUMENTO_RENDIMIENTO, query);

            if (V_INSTRUMENTO_RENDIMIENTOs.Values.Count > 0) query = (V_INSTRUMENTO_RENDIMIENTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.V_INSTRUMENTO_RENDIMIENTO)) : query.Where(p => !V_INSTRUMENTO_RENDIMIENTOs.Values.Contains(p.V_INSTRUMENTO_RENDIMIENTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO>(V_INSTRUMENTO_RENDIMIENTO, Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO.Properties.V_INSTRUMENTO_RENDIMIENTO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_INSTRUMENTO_RENDIMIENTOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_INSTRUMENTO_RENDIMIENTOs = new List<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_INSTRUMENTO_RENDIMIENTOs = query.AsNoTracking().ToList();
            else
                lista_CAT_INSTRUMENTO_RENDIMIENTOs = new List<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO> r;
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
