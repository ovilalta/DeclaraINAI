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
    internal class dal__l_CAT_TIPO_DOMICILIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO> lista_CAT_TIPO_DOMICILIOs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_DOMICILIO> base_CAT_TIPO_DOMICILIOs { get; set; }


        internal IntegerFilter NID_TIPO_DOMICILIO { get; set; }
        internal ListFilter<Int32> NID_TIPO_DOMICILIOs { get; set; }

        internal StringFilter V_TIPO_DOMICILIO { get; set; }
        internal ListFilter<String> V_TIPO_DOMICILIOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_DOMICILIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_DOMICILIO()
        {
            NID_TIPO_DOMICILIOs = new ListFilter<Int32>();
            V_TIPO_DOMICILIOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_DOMICILIO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_DOMICILIO in db.CAT_TIPO_DOMICILIO
                    select new Declara_V2.MODELextended.CAT_TIPO_DOMICILIO
                    {
                        NID_TIPO_DOMICILIO = qCAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO,
                        V_TIPO_DOMICILIO = qCAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPO_DOMICILIOs.Count > 0) single_query =  (NID_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO)) : single_query.Where(p => !NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_DOMICILIO>(NID_TIPO_DOMICILIO, Declara_V2.MODELextended.CAT_TIPO_DOMICILIO.Properties.NID_TIPO_DOMICILIO.ToString(), single_query);

            if (V_TIPO_DOMICILIOs.Count > 0) single_query =  (V_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPO_DOMICILIOs.Contains(p.V_TIPO_DOMICILIO)) : single_query.Where(p => !V_TIPO_DOMICILIOs.Contains(p.V_TIPO_DOMICILIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_DOMICILIO>(V_TIPO_DOMICILIO, Declara_V2.MODELextended.CAT_TIPO_DOMICILIO.Properties.V_TIPO_DOMICILIO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_TIPO_DOMICILIOs.Count > 0) query =  (NID_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO)) : query.Where(p => !NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO>(NID_TIPO_DOMICILIO, Declara_V2.MODELextended.CAT_TIPO_DOMICILIO.Properties.NID_TIPO_DOMICILIO.ToString(), query);

            if (V_TIPO_DOMICILIOs.Count > 0) query =  (V_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPO_DOMICILIOs.Contains(p.V_TIPO_DOMICILIO)) : query.Where(p => !V_TIPO_DOMICILIOs.Contains(p.V_TIPO_DOMICILIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO>(V_TIPO_DOMICILIO, Declara_V2.MODELextended.CAT_TIPO_DOMICILIO.Properties.V_TIPO_DOMICILIO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_DOMICILIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_DOMICILIOs = new List<MODELDeclara_V2.CAT_TIPO_DOMICILIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_DOMICILIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_DOMICILIOs = new List<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_DOMICILIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO> r;
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
