using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_NIVEL_ESCOLARIDAD : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD> lista_CAT_NIVEL_ESCOLARIDADs { get; set; }
        internal List<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD> base_CAT_NIVEL_ESCOLARIDADs { get; set; }

        internal IntegerFilter NID_NIVEL_ESCOLARIDAD { get; set; }
        internal ListFilter<Int32> NID_NIVEL_ESCOLARIDADs { get; set; }

        internal StringFilter V_NIVEL_ESCOLARIDAD { get; set; }
        internal ListFilter<String> V_NIVEL_ESCOLARIDADs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_NIVEL_ESCOLARIDAD()
        {
            NID_NIVEL_ESCOLARIDADs = new ListFilter<Int32>();
            V_NIVEL_ESCOLARIDADs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_NIVEL_ESCOLARIDAD
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_NIVEL_ESCOLARIDAD in db.CAT_NIVEL_ESCOLARIDAD
                    select new Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD
                    {
                        NID_NIVEL_ESCOLARIDAD = qCAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD,
                        V_NIVEL_ESCOLARIDAD = qCAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD,
                    };
        }
        protected void Single_Where()
        {
            if (NID_NIVEL_ESCOLARIDADs.Values.Count > 0) single_query = (NID_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD)) : single_query.Where(p => !NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD>(NID_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD.Properties.NID_NIVEL_ESCOLARIDAD, single_query);

            if (V_NIVEL_ESCOLARIDADs.Values.Count > 0) single_query = (V_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NIVEL_ESCOLARIDADs.Values.Contains(p.V_NIVEL_ESCOLARIDAD)) : single_query.Where(p => !V_NIVEL_ESCOLARIDADs.Values.Contains(p.V_NIVEL_ESCOLARIDAD));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD>(V_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD.Properties.V_NIVEL_ESCOLARIDAD, single_query);

        }
        protected void Where()
        {
            if (NID_NIVEL_ESCOLARIDADs.Values.Count > 0) query = (NID_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD)) : query.Where(p => !NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD>(NID_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD.Properties.NID_NIVEL_ESCOLARIDAD, query);

            if (V_NIVEL_ESCOLARIDADs.Values.Count > 0) query = (V_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NIVEL_ESCOLARIDADs.Values.Contains(p.V_NIVEL_ESCOLARIDAD)) : query.Where(p => !V_NIVEL_ESCOLARIDADs.Values.Contains(p.V_NIVEL_ESCOLARIDAD));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD>(V_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD.Properties.V_NIVEL_ESCOLARIDAD, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_NIVEL_ESCOLARIDADs = single_query.AsNoTracking().ToList();
            else
                base_CAT_NIVEL_ESCOLARIDADs = new List<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_NIVEL_ESCOLARIDADs = query.AsNoTracking().ToList();
            else
                lista_CAT_NIVEL_ESCOLARIDADs = new List<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD> r;
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
