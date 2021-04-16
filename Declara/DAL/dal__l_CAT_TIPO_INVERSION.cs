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
    internal class dal__l_CAT_TIPO_INVERSION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_INVERSION> lista_CAT_TIPO_INVERSIONs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_INVERSION> base_CAT_TIPO_INVERSIONs { get; set; }


        internal IntegerFilter NID_TIPO_INVERSION { get; set; }
        internal ListFilter<Int32> NID_TIPO_INVERSIONs { get; set; }

        internal StringFilter V_TIPO_INVERSION { get; set; }
        internal ListFilter<String> V_TIPO_INVERSIONs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_INVERSION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_INVERSION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_INVERSION()
        {
            NID_TIPO_INVERSIONs = new ListFilter<Int32>();
            V_TIPO_INVERSIONs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_INVERSION
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_INVERSION in db.CAT_TIPO_INVERSION
                    select new Declara_V2.MODELextended.CAT_TIPO_INVERSION
                    {
                        NID_TIPO_INVERSION = qCAT_TIPO_INVERSION.NID_TIPO_INVERSION,
                        V_TIPO_INVERSION = qCAT_TIPO_INVERSION.V_TIPO_INVERSION,
                        L_ACTIVO = qCAT_TIPO_INVERSION.L_ACTIVO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPO_INVERSIONs.Count > 0) single_query =  (NID_TIPO_INVERSIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_INVERSIONs.Contains(p.NID_TIPO_INVERSION)) : single_query.Where(p => !NID_TIPO_INVERSIONs.Contains(p.NID_TIPO_INVERSION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_INVERSION>(NID_TIPO_INVERSION, Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.NID_TIPO_INVERSION.ToString(), single_query);

            if (V_TIPO_INVERSIONs.Count > 0) single_query =  (V_TIPO_INVERSIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPO_INVERSIONs.Contains(p.V_TIPO_INVERSION)) : single_query.Where(p => !V_TIPO_INVERSIONs.Contains(p.V_TIPO_INVERSION));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_INVERSION>(V_TIPO_INVERSION, Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.V_TIPO_INVERSION.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_TIPO_INVERSION>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (NID_TIPO_INVERSIONs.Count > 0) query =  (NID_TIPO_INVERSIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_INVERSIONs.Contains(p.NID_TIPO_INVERSION)) : query.Where(p => !NID_TIPO_INVERSIONs.Contains(p.NID_TIPO_INVERSION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_INVERSION>(NID_TIPO_INVERSION, Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.NID_TIPO_INVERSION.ToString(), query);

            if (V_TIPO_INVERSIONs.Count > 0) query =  (V_TIPO_INVERSIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPO_INVERSIONs.Contains(p.V_TIPO_INVERSION)) : query.Where(p => !V_TIPO_INVERSIONs.Contains(p.V_TIPO_INVERSION));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_INVERSION>(V_TIPO_INVERSION, Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.V_TIPO_INVERSION.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_TIPO_INVERSION>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_INVERSIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_INVERSIONs = new List<MODELDeclara_V2.CAT_TIPO_INVERSION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_INVERSIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_INVERSIONs = new List<Declara_V2.MODELextended.CAT_TIPO_INVERSION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_INVERSION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_INVERSION> r;
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
