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
    internal class dal__l_CAT_USO_VEHICULO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_USO_VEHICULO> lista_CAT_USO_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.CAT_USO_VEHICULO> base_CAT_USO_VEHICULOs { get; set; }


        internal IntegerFilter NID_USO { get; set; }
        internal ListFilter<Int32> NID_USOs { get; set; }

        internal StringFilter V_USO { get; set; }
        internal ListFilter<String> V_USOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.CAT_USO_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_USO_VEHICULO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_USO_VEHICULO()
        {
            NID_USOs = new ListFilter<Int32>();
            V_USOs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_USO_VEHICULO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_USO_VEHICULO in db.CAT_USO_VEHICULO
                    select new Declara_V2.MODELextended.CAT_USO_VEHICULO
                    {
                        NID_USO = qCAT_USO_VEHICULO.NID_USO,
                        V_USO = qCAT_USO_VEHICULO.V_USO,
                        L_ACTIVO = qCAT_USO_VEHICULO.L_ACTIVO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_USOs.Count > 0) single_query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_USOs.Contains(p.NID_USO)) : single_query.Where(p => !NID_USOs.Contains(p.NID_USO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_USO_VEHICULO>(NID_USO, Declara_V2.MODELextended.CAT_USO_VEHICULO.Properties.NID_USO.ToString(), single_query);

            if (V_USOs.Count > 0) single_query =  (V_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_USOs.Contains(p.V_USO)) : single_query.Where(p => !V_USOs.Contains(p.V_USO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_USO_VEHICULO>(V_USO, Declara_V2.MODELextended.CAT_USO_VEHICULO.Properties.V_USO.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_USO_VEHICULO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (NID_USOs.Count > 0) query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_USOs.Contains(p.NID_USO)) : query.Where(p => !NID_USOs.Contains(p.NID_USO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_USO_VEHICULO>(NID_USO, Declara_V2.MODELextended.CAT_USO_VEHICULO.Properties.NID_USO.ToString(), query);

            if (V_USOs.Count > 0) query =  (V_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_USOs.Contains(p.V_USO)) : query.Where(p => !V_USOs.Contains(p.V_USO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_USO_VEHICULO>(V_USO, Declara_V2.MODELextended.CAT_USO_VEHICULO.Properties.V_USO.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_USO_VEHICULO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_USO_VEHICULOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_USO_VEHICULOs = new List<MODELDeclara_V2.CAT_USO_VEHICULO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_USO_VEHICULOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_USO_VEHICULOs = new List<Declara_V2.MODELextended.CAT_USO_VEHICULO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_USO_VEHICULO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_USO_VEHICULO> r;
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
