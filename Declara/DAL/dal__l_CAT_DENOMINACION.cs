using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_DENOMINACION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_DENOMINACION> lista_CAT_DENOMINACIONs { get; set; }
        internal List<MODELDeclara_V2.CAT_DENOMINACION> base_CAT_DENOMINACIONs { get; set; }


        internal IntegerFilter NID_DENOMINACION { get; set; }
        internal ListFilter<Int32> NID_DENOMINACIONs { get; set; }

        internal StringFilter V_DENOMINACION { get; set; }
        internal ListFilter<String> V_DENOMINACIONs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_DENOMINACION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_DENOMINACION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_DENOMINACION()
        {
            NID_DENOMINACIONs = new ListFilter<Int32>();
            V_DENOMINACIONs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_DENOMINACION
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_DENOMINACION in db.CAT_DENOMINACION
                    select new Declara_V2.MODELextended.CAT_DENOMINACION
                    {
                        NID_DENOMINACION = qCAT_DENOMINACION.NID_DENOMINACION,
                        V_DENOMINACION = qCAT_DENOMINACION.V_DENOMINACION,
                    };
        }

        protected void Single_Where()
        {
            if (NID_DENOMINACIONs.Count > 0) single_query =  (NID_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DENOMINACIONs.Contains(p.NID_DENOMINACION)) : single_query.Where(p => !NID_DENOMINACIONs.Contains(p.NID_DENOMINACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_DENOMINACION>(NID_DENOMINACION, Declara_V2.MODELextended.CAT_DENOMINACION.Properties.NID_DENOMINACION.ToString(), single_query);

            if (V_DENOMINACIONs.Count > 0) single_query =  (V_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DENOMINACIONs.Contains(p.V_DENOMINACION)) : single_query.Where(p => !V_DENOMINACIONs.Contains(p.V_DENOMINACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_DENOMINACION>(V_DENOMINACION, Declara_V2.MODELextended.CAT_DENOMINACION.Properties.V_DENOMINACION.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_DENOMINACIONs.Count > 0) query =  (NID_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DENOMINACIONs.Contains(p.NID_DENOMINACION)) : query.Where(p => !NID_DENOMINACIONs.Contains(p.NID_DENOMINACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_DENOMINACION>(NID_DENOMINACION, Declara_V2.MODELextended.CAT_DENOMINACION.Properties.NID_DENOMINACION.ToString(), query);

            if (V_DENOMINACIONs.Count > 0) query =  (V_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DENOMINACIONs.Contains(p.V_DENOMINACION)) : query.Where(p => !V_DENOMINACIONs.Contains(p.V_DENOMINACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_DENOMINACION>(V_DENOMINACION, Declara_V2.MODELextended.CAT_DENOMINACION.Properties.V_DENOMINACION.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_DENOMINACIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_DENOMINACIONs = new List<MODELDeclara_V2.CAT_DENOMINACION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_DENOMINACIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_DENOMINACIONs = new List<Declara_V2.MODELextended.CAT_DENOMINACION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_DENOMINACION> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_DENOMINACION> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
