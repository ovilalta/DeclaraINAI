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
    internal class dal__l_CAT_TIPO_DECLARACION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_DECLARACION> lista_CAT_TIPO_DECLARACIONs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_DECLARACION> base_CAT_TIPO_DECLARACIONs { get; set; }


        internal IntegerFilter NID_TIPO_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_TIPO_DECLARACIONs { get; set; }

        internal StringFilter V_TIPO_DECLARACION { get; set; }
        internal ListFilter<String> V_TIPO_DECLARACIONs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_DECLARACION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_DECLARACION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_DECLARACION()
        {
            NID_TIPO_DECLARACIONs = new ListFilter<Int32>();
            V_TIPO_DECLARACIONs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_DECLARACION
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_DECLARACION in db.CAT_TIPO_DECLARACION
                    select new Declara_V2.MODELextended.CAT_TIPO_DECLARACION
                    {
                        NID_TIPO_DECLARACION = qCAT_TIPO_DECLARACION.NID_TIPO_DECLARACION,
                        V_TIPO_DECLARACION = qCAT_TIPO_DECLARACION.V_TIPO_DECLARACION,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPO_DECLARACIONs.Count > 0) single_query =  (NID_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION)) : single_query.Where(p => !NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_DECLARACION>(NID_TIPO_DECLARACION, Declara_V2.MODELextended.CAT_TIPO_DECLARACION.Properties.NID_TIPO_DECLARACION.ToString(), single_query);

            if (V_TIPO_DECLARACIONs.Count > 0) single_query =  (V_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPO_DECLARACIONs.Contains(p.V_TIPO_DECLARACION)) : single_query.Where(p => !V_TIPO_DECLARACIONs.Contains(p.V_TIPO_DECLARACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_DECLARACION>(V_TIPO_DECLARACION, Declara_V2.MODELextended.CAT_TIPO_DECLARACION.Properties.V_TIPO_DECLARACION.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_TIPO_DECLARACIONs.Count > 0) query =  (NID_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION)) : query.Where(p => !NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_DECLARACION>(NID_TIPO_DECLARACION, Declara_V2.MODELextended.CAT_TIPO_DECLARACION.Properties.NID_TIPO_DECLARACION.ToString(), query);

            if (V_TIPO_DECLARACIONs.Count > 0) query =  (V_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPO_DECLARACIONs.Contains(p.V_TIPO_DECLARACION)) : query.Where(p => !V_TIPO_DECLARACIONs.Contains(p.V_TIPO_DECLARACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_DECLARACION>(V_TIPO_DECLARACION, Declara_V2.MODELextended.CAT_TIPO_DECLARACION.Properties.V_TIPO_DECLARACION.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_DECLARACIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_DECLARACIONs = new List<MODELDeclara_V2.CAT_TIPO_DECLARACION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_DECLARACIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_DECLARACIONs = new List<Declara_V2.MODELextended.CAT_TIPO_DECLARACION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_DECLARACION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_DECLARACION> r;
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
