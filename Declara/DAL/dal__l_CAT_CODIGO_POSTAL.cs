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
    internal class dal__l_CAT_CODIGO_POSTAL : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_CODIGO_POSTAL> lista_CAT_CODIGO_POSTALs { get; set; }
        internal List<MODELDeclara_V2.CAT_CODIGO_POSTAL> base_CAT_CODIGO_POSTALs { get; set; }


        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter CID_MUNICIPIO { get; set; }
        internal ListFilter<String> CID_MUNICIPIOs { get; set; }

        internal StringFilter CID_CODIGO_POSTAL { get; set; }
        internal ListFilter<String> CID_CODIGO_POSTALs { get; set; }

        internal IntegerFilter NID_COLONIA { get; set; }
        internal ListFilter<Int32> NID_COLONIAs { get; set; }

        internal StringFilter V_COLONIA { get; set; }
        internal ListFilter<String> V_COLONIAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_CODIGO_POSTAL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_CODIGO_POSTAL> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_CODIGO_POSTAL()
        {
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            CID_CODIGO_POSTALs = new ListFilter<String>();
            NID_COLONIAs = new ListFilter<Int32>();
            V_COLONIAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_CODIGO_POSTAL
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_CODIGO_POSTAL in db.CAT_CODIGO_POSTAL
                    join qCAT_MUNICIPIO in db.CAT_MUNICIPIO on new { qCAT_CODIGO_POSTAL.NID_PAIS, qCAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA, qCAT_CODIGO_POSTAL.CID_MUNICIPIO }
                                                        equals new { qCAT_MUNICIPIO.NID_PAIS, qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA, qCAT_MUNICIPIO.CID_MUNICIPIO }
                    select new Declara_V2.MODELextended.CAT_CODIGO_POSTAL
                    {
                        NID_PAIS = qCAT_CODIGO_POSTAL.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qCAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qCAT_CODIGO_POSTAL.CID_MUNICIPIO,
                        CID_CODIGO_POSTAL = qCAT_CODIGO_POSTAL.CID_CODIGO_POSTAL,
                        NID_COLONIA = qCAT_CODIGO_POSTAL.NID_COLONIA,
                        V_COLONIA = qCAT_CODIGO_POSTAL.V_COLONIA,
                        V_MUNICIPIO = qCAT_MUNICIPIO.V_MUNICIPIO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(NID_PAIS, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (CID_MUNICIPIOs.Count > 0) single_query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(CID_MUNICIPIO, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_MUNICIPIO.ToString(), single_query);

            if (CID_CODIGO_POSTALs.Count > 0) single_query =  (CID_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_CODIGO_POSTALs.Contains(p.CID_CODIGO_POSTAL)) : single_query.Where(p => !CID_CODIGO_POSTALs.Contains(p.CID_CODIGO_POSTAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(CID_CODIGO_POSTAL, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_CODIGO_POSTAL.ToString(), single_query);

            if (NID_COLONIAs.Count > 0) single_query =  (NID_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_COLONIAs.Contains(p.NID_COLONIA)) : single_query.Where(p => !NID_COLONIAs.Contains(p.NID_COLONIA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(NID_COLONIA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.NID_COLONIA.ToString(), single_query);

            if (V_COLONIAs.Count > 0) single_query =  (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_COLONIAs.Contains(p.V_COLONIA)) : single_query.Where(p => !V_COLONIAs.Contains(p.V_COLONIA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CODIGO_POSTAL>(V_COLONIA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.V_COLONIA.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(NID_PAIS, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (CID_MUNICIPIOs.Count > 0) query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(CID_MUNICIPIO, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_MUNICIPIO.ToString(), query);

            if (CID_CODIGO_POSTALs.Count > 0) query =  (CID_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_CODIGO_POSTALs.Contains(p.CID_CODIGO_POSTAL)) : query.Where(p => !CID_CODIGO_POSTALs.Contains(p.CID_CODIGO_POSTAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(CID_CODIGO_POSTAL, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.CID_CODIGO_POSTAL.ToString(), query);

            if (NID_COLONIAs.Count > 0) query =  (NID_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_COLONIAs.Contains(p.NID_COLONIA)) : query.Where(p => !NID_COLONIAs.Contains(p.NID_COLONIA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(NID_COLONIA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.NID_COLONIA.ToString(), query);

            if (V_COLONIAs.Count > 0) query =  (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_COLONIAs.Contains(p.V_COLONIA)) : query.Where(p => !V_COLONIAs.Contains(p.V_COLONIA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>(V_COLONIA, Declara_V2.MODELextended.CAT_CODIGO_POSTAL.Properties.V_COLONIA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_CODIGO_POSTALs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_CODIGO_POSTALs = new List<MODELDeclara_V2.CAT_CODIGO_POSTAL>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_CODIGO_POSTALs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_CODIGO_POSTALs = new List<Declara_V2.MODELextended.CAT_CODIGO_POSTAL>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_CODIGO_POSTAL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_CODIGO_POSTAL> r;
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
