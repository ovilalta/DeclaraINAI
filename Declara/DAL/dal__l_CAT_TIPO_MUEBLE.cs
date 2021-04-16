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
    internal class dal__l_CAT_TIPO_MUEBLE : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_MUEBLE> lista_CAT_TIPO_MUEBLEs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_MUEBLE> base_CAT_TIPO_MUEBLEs { get; set; }


        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal StringFilter V_TIPO { get; set; }
        internal ListFilter<String> V_TIPOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_MUEBLE> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_MUEBLE> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_MUEBLE()
        {
            NID_TIPOs = new ListFilter<Int32>();
            V_TIPOs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_MUEBLE
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_MUEBLE in db.CAT_TIPO_MUEBLE
                    select new Declara_V2.MODELextended.CAT_TIPO_MUEBLE
                    {
                        NID_TIPO = qCAT_TIPO_MUEBLE.NID_TIPO,
                        V_TIPO = qCAT_TIPO_MUEBLE.V_TIPO,
                        L_ACTIVO = qCAT_TIPO_MUEBLE.L_ACTIVO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.CAT_TIPO_MUEBLE.Properties.NID_TIPO.ToString(), single_query);

            if (V_TIPOs.Count > 0) single_query =  (V_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPOs.Contains(p.V_TIPO)) : single_query.Where(p => !V_TIPOs.Contains(p.V_TIPO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_MUEBLE>(V_TIPO, Declara_V2.MODELextended.CAT_TIPO_MUEBLE.Properties.V_TIPO.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_TIPO_MUEBLE>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.CAT_TIPO_MUEBLE.Properties.NID_TIPO.ToString(), query);

            if (V_TIPOs.Count > 0) query =  (V_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPOs.Contains(p.V_TIPO)) : query.Where(p => !V_TIPOs.Contains(p.V_TIPO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_MUEBLE>(V_TIPO, Declara_V2.MODELextended.CAT_TIPO_MUEBLE.Properties.V_TIPO.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_TIPO_MUEBLE>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_MUEBLEs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_MUEBLEs = new List<MODELDeclara_V2.CAT_TIPO_MUEBLE>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_MUEBLEs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_MUEBLEs = new List<Declara_V2.MODELextended.CAT_TIPO_MUEBLE>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_MUEBLE> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_MUEBLE> r;
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
