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
    internal class dal__l_CAT_ESTADO_CIVIL : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_ESTADO_CIVIL> lista_CAT_ESTADO_CIVILs { get; set; }
        internal List<MODELDeclara_V2.CAT_ESTADO_CIVIL> base_CAT_ESTADO_CIVILs { get; set; }


        internal IntegerFilter NID_ESTADO_CIVIL { get; set; }
        internal ListFilter<Int32> NID_ESTADO_CIVILs { get; set; }

        internal StringFilter V_ESTADO_CIVIL { get; set; }
        internal ListFilter<String> V_ESTADO_CIVILs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_ESTADO_CIVIL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_ESTADO_CIVIL> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_ESTADO_CIVIL()
        {
            NID_ESTADO_CIVILs = new ListFilter<Int32>();
            V_ESTADO_CIVILs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_ESTADO_CIVIL
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_ESTADO_CIVIL in db.CAT_ESTADO_CIVIL
                    select new Declara_V2.MODELextended.CAT_ESTADO_CIVIL
                    {
                        NID_ESTADO_CIVIL = qCAT_ESTADO_CIVIL.NID_ESTADO_CIVIL,
                        V_ESTADO_CIVIL = qCAT_ESTADO_CIVIL.V_ESTADO_CIVIL,
                    };
        }

        protected void Single_Where()
        {
            if (NID_ESTADO_CIVILs.Count > 0) single_query =  (NID_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL)) : single_query.Where(p => !NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_ESTADO_CIVIL>(NID_ESTADO_CIVIL, Declara_V2.MODELextended.CAT_ESTADO_CIVIL.Properties.NID_ESTADO_CIVIL.ToString(), single_query);

            if (V_ESTADO_CIVILs.Count > 0) single_query =  (V_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ESTADO_CIVILs.Contains(p.V_ESTADO_CIVIL)) : single_query.Where(p => !V_ESTADO_CIVILs.Contains(p.V_ESTADO_CIVIL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ESTADO_CIVIL>(V_ESTADO_CIVIL, Declara_V2.MODELextended.CAT_ESTADO_CIVIL.Properties.V_ESTADO_CIVIL.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_ESTADO_CIVILs.Count > 0) query =  (NID_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL)) : query.Where(p => !NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_CIVIL>(NID_ESTADO_CIVIL, Declara_V2.MODELextended.CAT_ESTADO_CIVIL.Properties.NID_ESTADO_CIVIL.ToString(), query);

            if (V_ESTADO_CIVILs.Count > 0) query =  (V_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ESTADO_CIVILs.Contains(p.V_ESTADO_CIVIL)) : query.Where(p => !V_ESTADO_CIVILs.Contains(p.V_ESTADO_CIVIL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_CIVIL>(V_ESTADO_CIVIL, Declara_V2.MODELextended.CAT_ESTADO_CIVIL.Properties.V_ESTADO_CIVIL.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_ESTADO_CIVILs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_ESTADO_CIVILs = new List<MODELDeclara_V2.CAT_ESTADO_CIVIL>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_ESTADO_CIVILs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_ESTADO_CIVILs = new List<Declara_V2.MODELextended.CAT_ESTADO_CIVIL>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_ESTADO_CIVIL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_ESTADO_CIVIL> r;
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
