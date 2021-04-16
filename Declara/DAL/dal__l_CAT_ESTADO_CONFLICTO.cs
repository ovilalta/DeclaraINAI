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
    internal class dal__l_CAT_ESTADO_CONFLICTO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO> lista_CAT_ESTADO_CONFLICTOs { get; set; }
        internal List<MODELDeclara_V2.CAT_ESTADO_CONFLICTO> base_CAT_ESTADO_CONFLICTOs { get; set; }


        internal IntegerFilter NID_ESTADO_CONFLICTO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_CONFLICTOs { get; set; }

        internal StringFilter V_ESTADO_CONFLICTO { get; set; }
        internal ListFilter<String> V_ESTADO_CONFLICTOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_ESTADO_CONFLICTO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_ESTADO_CONFLICTO()
        {
            NID_ESTADO_CONFLICTOs = new ListFilter<Int32>();
            V_ESTADO_CONFLICTOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_ESTADO_CONFLICTO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_ESTADO_CONFLICTO in db.CAT_ESTADO_CONFLICTO
                    select new Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO
                    {
                        NID_ESTADO_CONFLICTO = qCAT_ESTADO_CONFLICTO.NID_ESTADO_CONFLICTO,
                        V_ESTADO_CONFLICTO = qCAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_ESTADO_CONFLICTOs.Count > 0) single_query =  (NID_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO)) : single_query.Where(p => !NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_ESTADO_CONFLICTO>(NID_ESTADO_CONFLICTO, Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO.Properties.NID_ESTADO_CONFLICTO.ToString(), single_query);

            if (V_ESTADO_CONFLICTOs.Count > 0) single_query =  (V_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ESTADO_CONFLICTOs.Contains(p.V_ESTADO_CONFLICTO)) : single_query.Where(p => !V_ESTADO_CONFLICTOs.Contains(p.V_ESTADO_CONFLICTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ESTADO_CONFLICTO>(V_ESTADO_CONFLICTO, Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO.Properties.V_ESTADO_CONFLICTO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_ESTADO_CONFLICTOs.Count > 0) query =  (NID_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO)) : query.Where(p => !NID_ESTADO_CONFLICTOs.Contains(p.NID_ESTADO_CONFLICTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO>(NID_ESTADO_CONFLICTO, Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO.Properties.NID_ESTADO_CONFLICTO.ToString(), query);

            if (V_ESTADO_CONFLICTOs.Count > 0) query =  (V_ESTADO_CONFLICTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ESTADO_CONFLICTOs.Contains(p.V_ESTADO_CONFLICTO)) : query.Where(p => !V_ESTADO_CONFLICTOs.Contains(p.V_ESTADO_CONFLICTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO>(V_ESTADO_CONFLICTO, Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO.Properties.V_ESTADO_CONFLICTO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_ESTADO_CONFLICTOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_ESTADO_CONFLICTOs = new List<MODELDeclara_V2.CAT_ESTADO_CONFLICTO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_ESTADO_CONFLICTOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_ESTADO_CONFLICTOs = new List<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_ESTADO_CONFLICTO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_ESTADO_CONFLICTO> r;
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
