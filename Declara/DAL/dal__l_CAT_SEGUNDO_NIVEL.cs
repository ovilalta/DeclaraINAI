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
    internal class dal__l_CAT_SEGUNDO_NIVEL : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL> lista_CAT_SEGUNDO_NIVELs { get; set; }
        internal List<MODELDeclara_V2.CAT_SEGUNDO_NIVEL> base_CAT_SEGUNDO_NIVELs { get; set; }


        internal StringFilter VID_PRIMER_NIVEL { get; set; }
        internal ListFilter<String> VID_PRIMER_NIVELs { get; set; }

        internal StringFilter VID_SEGUNDO_NIVEL { get; set; }
        internal ListFilter<String> VID_SEGUNDO_NIVELs { get; set; }

        internal StringFilter V_SEGUNDO_NIVEL { get; set; }
        internal ListFilter<String> V_SEGUNDO_NIVELs { get; set; }

        internal StringFilter C_INICIO { get; set; }
        internal ListFilter<String> C_INICIOs { get; set; }

        internal StringFilter C_FIN { get; set; }
        internal ListFilter<String> C_FINs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_SEGUNDO_NIVEL> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_SEGUNDO_NIVEL()
        {
            VID_PRIMER_NIVELs = new ListFilter<String>();
            VID_SEGUNDO_NIVELs = new ListFilter<String>();
            V_SEGUNDO_NIVELs = new ListFilter<String>();
            C_INICIOs = new ListFilter<String>();
            C_FINs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_SEGUNDO_NIVEL
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_SEGUNDO_NIVEL in db.CAT_SEGUNDO_NIVEL
                    join qCAT_PRIMER_NIVEL in db.CAT_PRIMER_NIVEL on qCAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL
                                                              equals qCAT_PRIMER_NIVEL.VID_PRIMER_NIVEL
                    select new Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL
                    {
                        VID_PRIMER_NIVEL = qCAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL,
                        VID_SEGUNDO_NIVEL = qCAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL,
                        V_SEGUNDO_NIVEL = qCAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL,
                        C_INICIO = qCAT_SEGUNDO_NIVEL.C_INICIO,
                        C_FIN = qCAT_SEGUNDO_NIVEL.C_FIN,
                        V_PRIMER_NIVEL = qCAT_PRIMER_NIVEL.V_PRIMER_NIVEL,
                    };
        }

        protected void Single_Where()
        {
            if (VID_PRIMER_NIVELs.Count > 0) single_query =  (VID_PRIMER_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL)) : single_query.Where(p => !VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>(VID_PRIMER_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.VID_PRIMER_NIVEL.ToString(), single_query);

            if (VID_SEGUNDO_NIVELs.Count > 0) single_query =  (VID_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL)) : single_query.Where(p => !VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>(VID_SEGUNDO_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.VID_SEGUNDO_NIVEL.ToString(), single_query);

            if (V_SEGUNDO_NIVELs.Count > 0) single_query =  (V_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_SEGUNDO_NIVELs.Contains(p.V_SEGUNDO_NIVEL)) : single_query.Where(p => !V_SEGUNDO_NIVELs.Contains(p.V_SEGUNDO_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>(V_SEGUNDO_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.V_SEGUNDO_NIVEL.ToString(), single_query);

            if (C_INICIOs.Count > 0) single_query =  (C_INICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_INICIOs.Contains(p.C_INICIO)) : single_query.Where(p => !C_INICIOs.Contains(p.C_INICIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>(C_INICIO, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.C_INICIO.ToString(), single_query);

            if (C_FINs.Count > 0) single_query =  (C_FINs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_FINs.Contains(p.C_FIN)) : single_query.Where(p => !C_FINs.Contains(p.C_FIN));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>(C_FIN, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.C_FIN.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_PRIMER_NIVELs.Count > 0) query =  (VID_PRIMER_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL)) : query.Where(p => !VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>(VID_PRIMER_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.VID_PRIMER_NIVEL.ToString(), query);

            if (VID_SEGUNDO_NIVELs.Count > 0) query =  (VID_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL)) : query.Where(p => !VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>(VID_SEGUNDO_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.VID_SEGUNDO_NIVEL.ToString(), query);

            if (V_SEGUNDO_NIVELs.Count > 0) query =  (V_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_SEGUNDO_NIVELs.Contains(p.V_SEGUNDO_NIVEL)) : query.Where(p => !V_SEGUNDO_NIVELs.Contains(p.V_SEGUNDO_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>(V_SEGUNDO_NIVEL, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.V_SEGUNDO_NIVEL.ToString(), query);

            if (C_INICIOs.Count > 0) query =  (C_INICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_INICIOs.Contains(p.C_INICIO)) : query.Where(p => !C_INICIOs.Contains(p.C_INICIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>(C_INICIO, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.C_INICIO.ToString(), query);

            if (C_FINs.Count > 0) query =  (C_FINs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_FINs.Contains(p.C_FIN)) : query.Where(p => !C_FINs.Contains(p.C_FIN));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>(C_FIN, Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL.Properties.C_FIN.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_SEGUNDO_NIVELs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_SEGUNDO_NIVELs = new List<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_SEGUNDO_NIVELs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_SEGUNDO_NIVELs = new List<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_SEGUNDO_NIVEL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL> r;
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
