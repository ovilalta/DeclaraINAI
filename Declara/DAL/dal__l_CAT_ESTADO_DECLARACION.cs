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
    internal class dal__l_CAT_ESTADO_DECLARACION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION> lista_CAT_ESTADO_DECLARACIONs { get; set; }
        internal List<MODELDeclara_V2.CAT_ESTADO_DECLARACION> base_CAT_ESTADO_DECLARACIONs { get; set; }


        internal IntegerFilter NID_ESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADOs { get; set; }

        internal StringFilter V_ESTADO { get; set; }
        internal ListFilter<String> V_ESTADOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_ESTADO_DECLARACION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_ESTADO_DECLARACION()
        {
            NID_ESTADOs = new ListFilter<Int32>();
            V_ESTADOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_ESTADO_DECLARACION
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_ESTADO_DECLARACION in db.CAT_ESTADO_DECLARACION
                    select new Declara_V2.MODELextended.CAT_ESTADO_DECLARACION
                    {
                        NID_ESTADO = qCAT_ESTADO_DECLARACION.NID_ESTADO,
                        V_ESTADO = qCAT_ESTADO_DECLARACION.V_ESTADO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_ESTADOs.Count > 0) single_query =  (NID_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADOs.Contains(p.NID_ESTADO)) : single_query.Where(p => !NID_ESTADOs.Contains(p.NID_ESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_ESTADO_DECLARACION>(NID_ESTADO, Declara_V2.MODELextended.CAT_ESTADO_DECLARACION.Properties.NID_ESTADO.ToString(), single_query);

            if (V_ESTADOs.Count > 0) single_query =  (V_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ESTADOs.Contains(p.V_ESTADO)) : single_query.Where(p => !V_ESTADOs.Contains(p.V_ESTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ESTADO_DECLARACION>(V_ESTADO, Declara_V2.MODELextended.CAT_ESTADO_DECLARACION.Properties.V_ESTADO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_ESTADOs.Count > 0) query =  (NID_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADOs.Contains(p.NID_ESTADO)) : query.Where(p => !NID_ESTADOs.Contains(p.NID_ESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION>(NID_ESTADO, Declara_V2.MODELextended.CAT_ESTADO_DECLARACION.Properties.NID_ESTADO.ToString(), query);

            if (V_ESTADOs.Count > 0) query =  (V_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ESTADOs.Contains(p.V_ESTADO)) : query.Where(p => !V_ESTADOs.Contains(p.V_ESTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION>(V_ESTADO, Declara_V2.MODELextended.CAT_ESTADO_DECLARACION.Properties.V_ESTADO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_ESTADO_DECLARACIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_ESTADO_DECLARACIONs = new List<MODELDeclara_V2.CAT_ESTADO_DECLARACION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_ESTADO_DECLARACIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_ESTADO_DECLARACIONs = new List<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_ESTADO_DECLARACION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_ESTADO_DECLARACION> r;
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
