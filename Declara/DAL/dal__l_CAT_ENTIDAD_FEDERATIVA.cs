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
    internal class dal__l_CAT_ENTIDAD_FEDERATIVA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA> lista_CAT_ENTIDAD_FEDERATIVAs { get; set; }
        internal List<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA> base_CAT_ENTIDAD_FEDERATIVAs { get; set; }


        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter V_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> V_ENTIDAD_FEDERATIVAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_ENTIDAD_FEDERATIVA()
        {
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            V_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_ENTIDAD_FEDERATIVA
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_ENTIDAD_FEDERATIVA in db.CAT_ENTIDAD_FEDERATIVA
                    join qCAT_PAIS in db.CAT_PAIS on qCAT_ENTIDAD_FEDERATIVA.NID_PAIS
                                              equals qCAT_PAIS.NID_PAIS
                    select new Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA
                    {
                        NID_PAIS = qCAT_ENTIDAD_FEDERATIVA.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA,
                        V_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA,
                        V_PAIS = qCAT_PAIS.V_PAIS,
                        V_NACIONALIDAD_M = qCAT_PAIS.V_NACIONALIDAD_M,
                        V_NACIONALIDAD_F = qCAT_PAIS.V_NACIONALIDAD_F,
                    };
        }

        protected void Single_Where()
        {
            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA>(NID_PAIS, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (V_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (V_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ENTIDAD_FEDERATIVAs.Contains(p.V_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !V_ENTIDAD_FEDERATIVAs.Contains(p.V_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA>(V_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA>(NID_PAIS, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (V_ENTIDAD_FEDERATIVAs.Count > 0) query =  (V_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ENTIDAD_FEDERATIVAs.Contains(p.V_ENTIDAD_FEDERATIVA)) : query.Where(p => !V_ENTIDAD_FEDERATIVAs.Contains(p.V_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA>(V_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_ENTIDAD_FEDERATIVAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_ENTIDAD_FEDERATIVAs = new List<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_ENTIDAD_FEDERATIVAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_ENTIDAD_FEDERATIVAs = new List<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA> r;
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
