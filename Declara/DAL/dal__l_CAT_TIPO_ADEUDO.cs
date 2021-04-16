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
    internal class dal__l_CAT_TIPO_ADEUDO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_ADEUDO> lista_CAT_TIPO_ADEUDOs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_ADEUDO> base_CAT_TIPO_ADEUDOs { get; set; }


        internal IntegerFilter NID_TIPO_ADEUDO { get; set; }
        internal ListFilter<Int32> NID_TIPO_ADEUDOs { get; set; }

        internal StringFilter V_TIPO_ADEUDO { get; set; }
        internal ListFilter<String> V_TIPO_ADEUDOs { get; set; }

        public System.Nullable<Boolean> L_ACTIVO { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_ADEUDO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_ADEUDO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_ADEUDO()
        {
            NID_TIPO_ADEUDOs = new ListFilter<Int32>();
            V_TIPO_ADEUDOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_ADEUDO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_ADEUDO in db.CAT_TIPO_ADEUDO
                    select new Declara_V2.MODELextended.CAT_TIPO_ADEUDO
                    {
                        NID_TIPO_ADEUDO = qCAT_TIPO_ADEUDO.NID_TIPO_ADEUDO,
                        V_TIPO_ADEUDO = qCAT_TIPO_ADEUDO.V_TIPO_ADEUDO,
                        L_ACTIVO = qCAT_TIPO_ADEUDO.L_ACTIVO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPO_ADEUDOs.Count > 0) single_query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : single_query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.CAT_TIPO_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), single_query);

            if (V_TIPO_ADEUDOs.Count > 0) single_query =  (V_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPO_ADEUDOs.Contains(p.V_TIPO_ADEUDO)) : single_query.Where(p => !V_TIPO_ADEUDOs.Contains(p.V_TIPO_ADEUDO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_ADEUDO>(V_TIPO_ADEUDO, Declara_V2.MODELextended.CAT_TIPO_ADEUDO.Properties.V_TIPO_ADEUDO.ToString(), single_query);

           if (L_ACTIVO.HasValue) single_query = single_query.Where(p => p.L_ACTIVO == L_ACTIVO.Value);

        }

        protected void Where()
        {
            if (NID_TIPO_ADEUDOs.Count > 0) query =  (NID_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO)) : query.Where(p => !NID_TIPO_ADEUDOs.Contains(p.NID_TIPO_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_ADEUDO>(NID_TIPO_ADEUDO, Declara_V2.MODELextended.CAT_TIPO_ADEUDO.Properties.NID_TIPO_ADEUDO.ToString(), query);

            if (V_TIPO_ADEUDOs.Count > 0) query =  (V_TIPO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPO_ADEUDOs.Contains(p.V_TIPO_ADEUDO)) : query.Where(p => !V_TIPO_ADEUDOs.Contains(p.V_TIPO_ADEUDO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_ADEUDO>(V_TIPO_ADEUDO, Declara_V2.MODELextended.CAT_TIPO_ADEUDO.Properties.V_TIPO_ADEUDO.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where(p => p.L_ACTIVO == L_ACTIVO.Value);
        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_ADEUDOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_ADEUDOs = new List<MODELDeclara_V2.CAT_TIPO_ADEUDO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_ADEUDOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_ADEUDOs = new List<Declara_V2.MODELextended.CAT_TIPO_ADEUDO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_ADEUDO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_ADEUDO> r;
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
