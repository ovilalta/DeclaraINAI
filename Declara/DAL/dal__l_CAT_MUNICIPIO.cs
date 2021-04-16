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
    internal class dal__l_CAT_MUNICIPIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_MUNICIPIO> lista_CAT_MUNICIPIOs { get; set; }
        internal List<MODELDeclara_V2.CAT_MUNICIPIO> base_CAT_MUNICIPIOs { get; set; }


        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter CID_MUNICIPIO { get; set; }
        internal ListFilter<String> CID_MUNICIPIOs { get; set; }

        internal StringFilter V_MUNICIPIO { get; set; }
        internal ListFilter<String> V_MUNICIPIOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_MUNICIPIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_MUNICIPIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_MUNICIPIO()
        {
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            V_MUNICIPIOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_MUNICIPIO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_MUNICIPIO in db.CAT_MUNICIPIO
                    join qCAT_ENTIDAD_FEDERATIVA in db.CAT_ENTIDAD_FEDERATIVA on new { qCAT_MUNICIPIO.NID_PAIS, qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA }
                                                                          equals new { qCAT_ENTIDAD_FEDERATIVA.NID_PAIS, qCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA }
                    select new Declara_V2.MODELextended.CAT_MUNICIPIO
                    {
                        NID_PAIS = qCAT_MUNICIPIO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qCAT_MUNICIPIO.CID_MUNICIPIO,
                        V_MUNICIPIO = qCAT_MUNICIPIO.V_MUNICIPIO,
                        V_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA,
                    };
        }

        protected void Single_Where()
        {
            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_MUNICIPIO>(NID_PAIS, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_MUNICIPIO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (CID_MUNICIPIOs.Count > 0) single_query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_MUNICIPIO>(CID_MUNICIPIO, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.CID_MUNICIPIO.ToString(), single_query);

            if (V_MUNICIPIOs.Count > 0) single_query =  (V_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_MUNICIPIOs.Contains(p.V_MUNICIPIO)) : single_query.Where(p => !V_MUNICIPIOs.Contains(p.V_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_MUNICIPIO>(V_MUNICIPIO, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.V_MUNICIPIO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_MUNICIPIO>(NID_PAIS, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_MUNICIPIO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (CID_MUNICIPIOs.Count > 0) query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_MUNICIPIO>(CID_MUNICIPIO, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.CID_MUNICIPIO.ToString(), query);

            if (V_MUNICIPIOs.Count > 0) query =  (V_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_MUNICIPIOs.Contains(p.V_MUNICIPIO)) : query.Where(p => !V_MUNICIPIOs.Contains(p.V_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_MUNICIPIO>(V_MUNICIPIO, Declara_V2.MODELextended.CAT_MUNICIPIO.Properties.V_MUNICIPIO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_MUNICIPIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_MUNICIPIOs = new List<MODELDeclara_V2.CAT_MUNICIPIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_MUNICIPIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_MUNICIPIOs = new List<Declara_V2.MODELextended.CAT_MUNICIPIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_MUNICIPIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_MUNICIPIO> r;
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
