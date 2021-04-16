using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_CAT_SECCION_INGRESO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.CAT_SECCION_INGRESO> lista_CAT_SECCION_INGRESOs { get; set; }
        internal List<MODELDeclara_V2.CAT_SECCION_INGRESO> base_CAT_SECCION_INGRESOs { get; set; }

        internal IntegerFilter NID_SECCION { get; set; }
        internal ListFilter<Int32> NID_SECCIONs { get; set; }

        internal IntegerFilter NID_RUBRO { get; set; }
        internal ListFilter<Int32> NID_RUBROs { get; set; }

        internal StringFilter V_RUBRO { get; set; }
        internal ListFilter<String> V_RUBROs { get; set; }

        internal System.Nullable<Boolean> L_VIGENTE { get; set; }

        internal StringFilter CID_TIPO { get; set; }
        internal ListFilter<String> CID_TIPOs { get; set; }

        internal IntegerFilter NID_RUBRO_SUMA { get; set; }
        internal ListFilter<Int32> NID_RUBRO_SUMAs { get; set; }

        internal StringFilter C_TITULAR { get; set; }
        internal ListFilter<String> C_TITULARs { get; set; }

        internal StringFilter V_CATALOGO { get; set; }
        internal ListFilter<String> V_CATALOGOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.CAT_SECCION_INGRESO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_SECCION_INGRESO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_CAT_SECCION_INGRESO()
        {
            NID_SECCIONs = new ListFilter<Int32>();
            NID_RUBROs = new ListFilter<Int32>();
            V_RUBROs = new ListFilter<String>();
            CID_TIPOs = new ListFilter<String>();
            NID_RUBRO_SUMAs = new ListFilter<Int32>();
            C_TITULARs = new ListFilter<String>();
            V_CATALOGOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.CAT_SECCION_INGRESO
                           select p;
        }
        protected void Select()
        {
            query = from qCAT_SECCION_INGRESO in db.CAT_SECCION_INGRESO
                    select new Declara_V2.MODELextended.CAT_SECCION_INGRESO
                    {
                        NID_SECCION = qCAT_SECCION_INGRESO.NID_SECCION,
                        NID_RUBRO = qCAT_SECCION_INGRESO.NID_RUBRO,
                        V_RUBRO = qCAT_SECCION_INGRESO.V_RUBRO,
                        L_VIGENTE = qCAT_SECCION_INGRESO.L_VIGENTE,
                        CID_TIPO = qCAT_SECCION_INGRESO.CID_TIPO,
                        NID_RUBRO_SUMA = qCAT_SECCION_INGRESO.NID_RUBRO_SUMA,
                        C_TITULAR = qCAT_SECCION_INGRESO.C_TITULAR,
                        V_CATALOGO = qCAT_SECCION_INGRESO.V_CATALOGO,
                    };
        }
        protected void Single_Where()
        {
            if (NID_SECCIONs.Values.Count > 0) single_query = (NID_SECCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_SECCIONs.Values.Contains(p.NID_SECCION)) : single_query.Where(p => !NID_SECCIONs.Values.Contains(p.NID_SECCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(NID_SECCION, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_SECCION, single_query);

            if (NID_RUBROs.Values.Count > 0) single_query = (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RUBROs.Values.Contains(p.NID_RUBRO)) : single_query.Where(p => !NID_RUBROs.Values.Contains(p.NID_RUBRO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(NID_RUBRO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_RUBRO, single_query);

            if (V_RUBROs.Values.Count > 0) single_query = (V_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RUBROs.Values.Contains(p.V_RUBRO)) : single_query.Where(p => !V_RUBROs.Values.Contains(p.V_RUBRO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(V_RUBRO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.V_RUBRO, single_query);

            if (L_VIGENTE.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_SECCION_INGRESO>(p => p.L_VIGENTE == L_VIGENTE);

            if (CID_TIPOs.Values.Count > 0) single_query = (CID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_TIPOs.Values.Contains(p.CID_TIPO)) : single_query.Where(p => !CID_TIPOs.Values.Contains(p.CID_TIPO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(CID_TIPO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.CID_TIPO, single_query);

            if (NID_RUBRO_SUMAs.Values.Count > 0) single_query = (NID_RUBRO_SUMAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RUBRO_SUMAs.Values.Contains(p.NID_RUBRO_SUMA)) : single_query.Where(p => !NID_RUBRO_SUMAs.Values.Contains(p.NID_RUBRO_SUMA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(NID_RUBRO_SUMA, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_RUBRO_SUMA, single_query);

            if (C_TITULARs.Values.Count > 0) single_query = (C_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_TITULARs.Values.Contains(p.C_TITULAR)) : single_query.Where(p => !C_TITULARs.Values.Contains(p.C_TITULAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(C_TITULAR, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.C_TITULAR, single_query);

            if (V_CATALOGOs.Values.Count > 0) single_query = (V_CATALOGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CATALOGOs.Values.Contains(p.V_CATALOGO)) : single_query.Where(p => !V_CATALOGOs.Values.Contains(p.V_CATALOGO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_SECCION_INGRESO>(V_CATALOGO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.V_CATALOGO, single_query);

        }
        protected void Where()
        {
            if (NID_SECCIONs.Values.Count > 0) query = (NID_SECCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_SECCIONs.Values.Contains(p.NID_SECCION)) : query.Where(p => !NID_SECCIONs.Values.Contains(p.NID_SECCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(NID_SECCION, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_SECCION, query);

            if (NID_RUBROs.Values.Count > 0) query = (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RUBROs.Values.Contains(p.NID_RUBRO)) : query.Where(p => !NID_RUBROs.Values.Contains(p.NID_RUBRO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(NID_RUBRO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_RUBRO, query);

            if (V_RUBROs.Values.Count > 0) query = (V_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RUBROs.Values.Contains(p.V_RUBRO)) : query.Where(p => !V_RUBROs.Values.Contains(p.V_RUBRO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(V_RUBRO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.V_RUBRO, query);

            if (L_VIGENTE.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(p => p.L_VIGENTE == L_VIGENTE);

            if (CID_TIPOs.Values.Count > 0) query = (CID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_TIPOs.Values.Contains(p.CID_TIPO)) : query.Where(p => !CID_TIPOs.Values.Contains(p.CID_TIPO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(CID_TIPO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.CID_TIPO, query);

            if (NID_RUBRO_SUMAs.Values.Count > 0) query = (NID_RUBRO_SUMAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RUBRO_SUMAs.Values.Contains(p.NID_RUBRO_SUMA)) : query.Where(p => !NID_RUBRO_SUMAs.Values.Contains(p.NID_RUBRO_SUMA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(NID_RUBRO_SUMA, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.NID_RUBRO_SUMA, query);

            if (C_TITULARs.Values.Count > 0) query = (C_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_TITULARs.Values.Contains(p.C_TITULAR)) : query.Where(p => !C_TITULARs.Values.Contains(p.C_TITULAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(C_TITULAR, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.C_TITULAR, query);

            if (V_CATALOGOs.Values.Count > 0) query = (V_CATALOGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CATALOGOs.Values.Contains(p.V_CATALOGO)) : query.Where(p => !V_CATALOGOs.Values.Contains(p.V_CATALOGO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_SECCION_INGRESO>(V_CATALOGO, Declara_V2.MODELextended.CAT_SECCION_INGRESO.Properties.V_CATALOGO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_CAT_SECCION_INGRESOs = single_query.AsNoTracking().ToList();
            else
                base_CAT_SECCION_INGRESOs = new List<MODELDeclara_V2.CAT_SECCION_INGRESO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_CAT_SECCION_INGRESOs = query.AsNoTracking().ToList();
            else
                lista_CAT_SECCION_INGRESOs = new List<Declara_V2.MODELextended.CAT_SECCION_INGRESO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_SECCION_INGRESO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_SECCION_INGRESO> r;
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
