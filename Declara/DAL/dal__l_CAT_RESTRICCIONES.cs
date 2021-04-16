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
    internal class dal__l_CAT_RESTRICCIONES : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_RESTRICCIONES> lista_CAT_RESTRICCIONESs { get; set; }
        internal List<MODELDeclara_V2.CAT_RESTRICCIONES> base_CAT_RESTRICCIONESs { get; set; }


        internal IntegerFilter NID_RESTRICCION { get; set; }
        internal ListFilter<Int32> NID_RESTRICCIONs { get; set; }

        internal StringFilter V_RESTRICCION { get; set; }
        internal ListFilter<String> V_RESTRICCIONs { get; set; }

        internal System.Nullable<Boolean> L_VIGENTE { get; set; }
        internal ListFilter<Boolean> L_VIGENTEs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_RESTRICCIONES> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_RESTRICCIONES> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_RESTRICCIONES()
        {
            NID_RESTRICCIONs = new ListFilter<Int32>();
            V_RESTRICCIONs = new ListFilter<String>();
            L_VIGENTEs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_RESTRICCIONES
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_RESTRICCIONES in db.CAT_RESTRICCIONES
                    select new Declara_V2.MODELextended.CAT_RESTRICCIONES
                    {
                        NID_RESTRICCION = qCAT_RESTRICCIONES.NID_RESTRICCION,
                        V_RESTRICCION = qCAT_RESTRICCIONES.V_RESTRICCION,
                        L_VIGENTE = qCAT_RESTRICCIONES.L_VIGENTE,
                    };
        }

        protected void Single_Where()
        {
            if (NID_RESTRICCIONs.Count > 0) single_query =  (NID_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RESTRICCIONs.Contains(p.NID_RESTRICCION)) : single_query.Where(p => !NID_RESTRICCIONs.Contains(p.NID_RESTRICCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_RESTRICCIONES>(NID_RESTRICCION, Declara_V2.MODELextended.CAT_RESTRICCIONES.Properties.NID_RESTRICCION.ToString(), single_query);

            if (V_RESTRICCIONs.Count > 0) single_query =  (V_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RESTRICCIONs.Contains(p.V_RESTRICCION)) : single_query.Where(p => !V_RESTRICCIONs.Contains(p.V_RESTRICCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_RESTRICCIONES>(V_RESTRICCION, Declara_V2.MODELextended.CAT_RESTRICCIONES.Properties.V_RESTRICCION.ToString(), single_query);

            if (L_VIGENTE.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_RESTRICCIONES>(p => p.L_VIGENTE == L_VIGENTE );

        }

        protected void Where()
        {
            if (NID_RESTRICCIONs.Count > 0) query =  (NID_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RESTRICCIONs.Contains(p.NID_RESTRICCION)) : query.Where(p => !NID_RESTRICCIONs.Contains(p.NID_RESTRICCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_RESTRICCIONES>(NID_RESTRICCION, Declara_V2.MODELextended.CAT_RESTRICCIONES.Properties.NID_RESTRICCION.ToString(), query);

            if (V_RESTRICCIONs.Count > 0) query =  (V_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RESTRICCIONs.Contains(p.V_RESTRICCION)) : query.Where(p => !V_RESTRICCIONs.Contains(p.V_RESTRICCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_RESTRICCIONES>(V_RESTRICCION, Declara_V2.MODELextended.CAT_RESTRICCIONES.Properties.V_RESTRICCION.ToString(), query);

            if (L_VIGENTE.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_RESTRICCIONES>(p => p.L_VIGENTE == L_VIGENTE );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_RESTRICCIONESs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_RESTRICCIONESs = new List<MODELDeclara_V2.CAT_RESTRICCIONES>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_RESTRICCIONESs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_RESTRICCIONESs = new List<Declara_V2.MODELextended.CAT_RESTRICCIONES>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_RESTRICCIONES> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_RESTRICCIONES> r;
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
