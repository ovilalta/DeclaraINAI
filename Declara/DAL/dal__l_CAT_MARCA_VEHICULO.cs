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
    internal class dal__l_CAT_MARCA_VEHICULO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_MARCA_VEHICULO> lista_CAT_MARCA_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.CAT_MARCA_VEHICULO> base_CAT_MARCA_VEHICULOs { get; set; }


        internal IntegerFilter NID_MARCA { get; set; }
        internal ListFilter<Int32> NID_MARCAs { get; set; }

        internal StringFilter V_MARCA { get; set; }
        internal ListFilter<String> V_MARCAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_MARCA_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_MARCA_VEHICULO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_MARCA_VEHICULO()
        {
            NID_MARCAs = new ListFilter<Int32>();
            V_MARCAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_MARCA_VEHICULO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_MARCA_VEHICULO in db.CAT_MARCA_VEHICULO
                    select new Declara_V2.MODELextended.CAT_MARCA_VEHICULO
                    {
                        NID_MARCA = qCAT_MARCA_VEHICULO.NID_MARCA,
                        V_MARCA = qCAT_MARCA_VEHICULO.V_MARCA,
                    };
        }

        protected void Single_Where()
        {
            if (NID_MARCAs.Count > 0) single_query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : single_query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_MARCA_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.CAT_MARCA_VEHICULO.Properties.NID_MARCA.ToString(), single_query);

            if (V_MARCAs.Count > 0) single_query =  (V_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_MARCAs.Contains(p.V_MARCA)) : single_query.Where(p => !V_MARCAs.Contains(p.V_MARCA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_MARCA_VEHICULO>(V_MARCA, Declara_V2.MODELextended.CAT_MARCA_VEHICULO.Properties.V_MARCA.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_MARCAs.Count > 0) query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_MARCA_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.CAT_MARCA_VEHICULO.Properties.NID_MARCA.ToString(), query);

            if (V_MARCAs.Count > 0) query =  (V_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_MARCAs.Contains(p.V_MARCA)) : query.Where(p => !V_MARCAs.Contains(p.V_MARCA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_MARCA_VEHICULO>(V_MARCA, Declara_V2.MODELextended.CAT_MARCA_VEHICULO.Properties.V_MARCA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_MARCA_VEHICULOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_MARCA_VEHICULOs = new List<MODELDeclara_V2.CAT_MARCA_VEHICULO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_MARCA_VEHICULOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_MARCA_VEHICULOs = new List<Declara_V2.MODELextended.CAT_MARCA_VEHICULO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_MARCA_VEHICULO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_MARCA_VEHICULO> r;
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
