using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_DOCUMENTO_OBTENIDO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO> lista_CAT_DOCUMENTO_OBTENIDOs { get; set; }
        internal List<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO> base_CAT_DOCUMENTO_OBTENIDOs { get; set; }

        internal IntegerFilter NID_DOCUMENTO_OBTENIDO { get; set; }
        internal ListFilter<Int32> NID_DOCUMENTO_OBTENIDOs { get; set; }

        internal StringFilter V_DOCUMENTO_OBTENIDO { get; set; }
        internal ListFilter<String> V_DOCUMENTO_OBTENIDOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_DOCUMENTO_OBTENIDO()
        {
            NID_DOCUMENTO_OBTENIDOs = new ListFilter<Int32>();
            V_DOCUMENTO_OBTENIDOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_DOCUMENTO_OBTENIDO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_DOCUMENTO_OBTENIDO in db.CAT_DOCUMENTO_OBTENIDO
                    select new Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO
                    {
                        NID_DOCUMENTO_OBTENIDO = qCAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO,
                        V_DOCUMENTO_OBTENIDO = qCAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_DOCUMENTO_OBTENIDOs.Values.Count > 0) single_query = (NID_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO)) : single_query.Where(p => !NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO>(NID_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO.Properties.NID_DOCUMENTO_OBTENIDO, single_query);

            if (V_DOCUMENTO_OBTENIDOs.Values.Count > 0) single_query = (V_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DOCUMENTO_OBTENIDOs.Values.Contains(p.V_DOCUMENTO_OBTENIDO)) : single_query.Where(p => !V_DOCUMENTO_OBTENIDOs.Values.Contains(p.V_DOCUMENTO_OBTENIDO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO>(V_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO.Properties.V_DOCUMENTO_OBTENIDO, single_query);

        }
        protected void Where()
        {
            if (NID_DOCUMENTO_OBTENIDOs.Values.Count > 0) query = (NID_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO)) : query.Where(p => !NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO>(NID_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO.Properties.NID_DOCUMENTO_OBTENIDO, query);

            if (V_DOCUMENTO_OBTENIDOs.Values.Count > 0) query = (V_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DOCUMENTO_OBTENIDOs.Values.Contains(p.V_DOCUMENTO_OBTENIDO)) : query.Where(p => !V_DOCUMENTO_OBTENIDOs.Values.Contains(p.V_DOCUMENTO_OBTENIDO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO>(V_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO.Properties.V_DOCUMENTO_OBTENIDO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_DOCUMENTO_OBTENIDOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_DOCUMENTO_OBTENIDOs = new List<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_DOCUMENTO_OBTENIDOs = query.AsNoTracking().ToList();
            else
                lista_CAT_DOCUMENTO_OBTENIDOs = new List<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_DOCUMENTO_OBTENIDO> r;
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
