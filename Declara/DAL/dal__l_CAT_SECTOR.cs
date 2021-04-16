using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_SECTOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_SECTOR> lista_CAT_SECTORs { get; set; }
        internal List<MODELDeclara_V2.CAT_SECTOR> base_CAT_SECTORs { get; set; }

        internal IntegerFilter NID_SECTOR { get; set; }
        internal ListFilter<Int32> NID_SECTORs { get; set; }

        internal StringFilter V_SECTOR { get; set; }
        internal ListFilter<String> V_SECTORs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_SECTOR> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_SECTOR> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_SECTOR()
        {
            NID_SECTORs = new ListFilter<Int32>();
            V_SECTORs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_SECTOR
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_SECTOR in db.CAT_SECTOR
                    select new Declara_V2.MODELextended.CAT_SECTOR
                    {
                        NID_SECTOR = qCAT_SECTOR.NID_SECTOR,
                        V_SECTOR = qCAT_SECTOR.V_SECTOR,
                    };
        }
        protected void Single_Where()
        {
            if (NID_SECTORs.Values.Count > 0) single_query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : single_query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_SECTOR>(NID_SECTOR, Declara_V2.MODELextended.CAT_SECTOR.Properties.NID_SECTOR, single_query);

            if (V_SECTORs.Values.Count > 0) single_query = (V_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_SECTORs.Values.Contains(p.V_SECTOR)) : single_query.Where(p => !V_SECTORs.Values.Contains(p.V_SECTOR));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SECTOR>(V_SECTOR, Declara_V2.MODELextended.CAT_SECTOR.Properties.V_SECTOR, single_query);

        }
        protected void Where()
        {
            if (NID_SECTORs.Values.Count > 0) query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_SECTOR>(NID_SECTOR, Declara_V2.MODELextended.CAT_SECTOR.Properties.NID_SECTOR, query);

            if (V_SECTORs.Values.Count > 0) query = (V_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_SECTORs.Values.Contains(p.V_SECTOR)) : query.Where(p => !V_SECTORs.Values.Contains(p.V_SECTOR));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SECTOR>(V_SECTOR, Declara_V2.MODELextended.CAT_SECTOR.Properties.V_SECTOR, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_SECTORs = single_query.AsNoTracking().ToList();
            else
                base_CAT_SECTORs = new List<MODELDeclara_V2.CAT_SECTOR>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_SECTORs = query.AsNoTracking().ToList();
            else
                lista_CAT_SECTORs = new List<Declara_V2.MODELextended.CAT_SECTOR>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_SECTOR> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_SECTOR> r;
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
