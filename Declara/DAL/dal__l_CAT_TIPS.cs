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
    internal class dal__l_CAT_TIPS : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPS> lista_CAT_TIPSs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPS> base_CAT_TIPSs { get; set; }


        internal IntegerFilter NID_TIP { get; set; }
        internal ListFilter<Int32> NID_TIPs { get; set; }

        internal StringFilter V_TIP { get; set; }
        internal ListFilter<String> V_TIPs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPS> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPS> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPS()
        {
            NID_TIPs = new ListFilter<Int32>();
            V_TIPs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPS
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPS in db.CAT_TIPS
                    select new Declara_V2.MODELextended.CAT_TIPS
                    {
                        NID_TIP = qCAT_TIPS.NID_TIP,
                        V_TIP = qCAT_TIPS.V_TIP,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPs.Count > 0) single_query =  (NID_TIPs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPs.Contains(p.NID_TIP)) : single_query.Where(p => !NID_TIPs.Contains(p.NID_TIP));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPS>(NID_TIP, Declara_V2.MODELextended.CAT_TIPS.Properties.NID_TIP.ToString(), single_query);

            if (V_TIPs.Count > 0) single_query =  (V_TIPs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPs.Contains(p.V_TIP)) : single_query.Where(p => !V_TIPs.Contains(p.V_TIP));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPS>(V_TIP, Declara_V2.MODELextended.CAT_TIPS.Properties.V_TIP.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_TIPs.Count > 0) query =  (NID_TIPs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPs.Contains(p.NID_TIP)) : query.Where(p => !NID_TIPs.Contains(p.NID_TIP));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPS>(NID_TIP, Declara_V2.MODELextended.CAT_TIPS.Properties.NID_TIP.ToString(), query);

            if (V_TIPs.Count > 0) query =  (V_TIPs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPs.Contains(p.V_TIP)) : query.Where(p => !V_TIPs.Contains(p.V_TIP));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPS>(V_TIP, Declara_V2.MODELextended.CAT_TIPS.Properties.V_TIP.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPSs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPSs = new List<MODELDeclara_V2.CAT_TIPS>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPSs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPSs = new List<Declara_V2.MODELextended.CAT_TIPS>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPS> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPS> r;
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
