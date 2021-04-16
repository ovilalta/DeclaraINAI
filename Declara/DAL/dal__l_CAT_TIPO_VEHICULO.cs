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
    internal class dal__l_CAT_TIPO_VEHICULO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_TIPO_VEHICULO> lista_CAT_TIPO_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.CAT_TIPO_VEHICULO> base_CAT_TIPO_VEHICULOs { get; set; }


        internal IntegerFilter NID_TIPO_VEHICULO { get; set; }
        internal ListFilter<Int32> NID_TIPO_VEHICULOs { get; set; }

        internal StringFilter V_TIPO_VEHICULO { get; set; }
        internal ListFilter<String> V_TIPO_VEHICULOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_TIPO_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_TIPO_VEHICULO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_TIPO_VEHICULO()
        {
            NID_TIPO_VEHICULOs = new ListFilter<Int32>();
            V_TIPO_VEHICULOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_TIPO_VEHICULO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_TIPO_VEHICULO in db.CAT_TIPO_VEHICULO
                    select new Declara_V2.MODELextended.CAT_TIPO_VEHICULO
                    {
                        NID_TIPO_VEHICULO = qCAT_TIPO_VEHICULO.NID_TIPO_VEHICULO,
                        V_TIPO_VEHICULO = qCAT_TIPO_VEHICULO.V_TIPO_VEHICULO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_TIPO_VEHICULOs.Count > 0) single_query =  (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO)) : single_query.Where(p => !NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_TIPO_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO.ToString(), single_query);

            if (V_TIPO_VEHICULOs.Count > 0) single_query =  (V_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TIPO_VEHICULOs.Contains(p.V_TIPO_VEHICULO)) : single_query.Where(p => !V_TIPO_VEHICULOs.Contains(p.V_TIPO_VEHICULO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_TIPO_VEHICULO>(V_TIPO_VEHICULO, Declara_V2.MODELextended.CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_TIPO_VEHICULOs.Count > 0) query =  (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO)) : query.Where(p => !NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO.ToString(), query);

            if (V_TIPO_VEHICULOs.Count > 0) query =  (V_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TIPO_VEHICULOs.Contains(p.V_TIPO_VEHICULO)) : query.Where(p => !V_TIPO_VEHICULOs.Contains(p.V_TIPO_VEHICULO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_TIPO_VEHICULO>(V_TIPO_VEHICULO, Declara_V2.MODELextended.CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_TIPO_VEHICULOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_TIPO_VEHICULOs = new List<MODELDeclara_V2.CAT_TIPO_VEHICULO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_TIPO_VEHICULOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_TIPO_VEHICULOs = new List<Declara_V2.MODELextended.CAT_TIPO_VEHICULO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_TIPO_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_TIPO_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
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
