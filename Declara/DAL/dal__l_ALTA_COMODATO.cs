using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_ALTA_COMODATO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.ALTA_COMODATO> lista_ALTA_COMODATOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_COMODATO> base_ALTA_COMODATOs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_COMODATO { get; set; }
        internal ListFilter<Int32> NID_COMODATOs { get; set; }

        internal StringFilter CID_TIPO_PERSONA { get; set; }
        internal ListFilter<String> CID_TIPO_PERSONAs { get; set; }

        internal StringFilter E_TITULAR { get; set; }
        internal ListFilter<String> E_TITULARs { get; set; }

        internal StringFilter E_RFC { get; set; }
        internal ListFilter<String> E_RFCs { get; set; }

        internal IntegerFilter NID_TIPO_RELACION { get; set; }
        internal ListFilter<Int32> NID_TIPO_RELACIONs { get; set; }

        internal StringFilter E_OBSERVACIONES { get; set; }
        internal ListFilter<String> E_OBSERVACIONESs { get; set; }

        internal StringFilter E_OBSERVACIONES_MARCADO { get; set; }
        internal ListFilter<String> E_OBSERVACIONES_MARCADOs { get; set; }

        internal StringFilter V_OBSERVACIONES_TESTADO { get; set; }
        internal ListFilter<String> V_OBSERVACIONES_TESTADOs { get; set; }

        internal IntegerFilter NID_ESTADO_TESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_TESTADOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.ALTA_COMODATO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_COMODATO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_ALTA_COMODATO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_COMODATOs = new ListFilter<Int32>();
            CID_TIPO_PERSONAs = new ListFilter<String>();
            E_TITULARs = new ListFilter<String>();
            E_RFCs = new ListFilter<String>();
            NID_TIPO_RELACIONs = new ListFilter<Int32>();
            E_OBSERVACIONESs = new ListFilter<String>();
            E_OBSERVACIONES_MARCADOs = new ListFilter<String>();
            V_OBSERVACIONES_TESTADOs = new ListFilter<String>();
            NID_ESTADO_TESTADOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.ALTA_COMODATO
                           select p;
        }
        protected void Select()
        {
            query = from qALTA_COMODATO in db.ALTA_COMODATO
                    select new Declara_V2.MODELextended.ALTA_COMODATO
                    {
                        VID_NOMBRE = qALTA_COMODATO.VID_NOMBRE,
                        VID_FECHA = qALTA_COMODATO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_COMODATO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_COMODATO.NID_DECLARACION,
                        NID_COMODATO = qALTA_COMODATO.NID_COMODATO,
                        CID_TIPO_PERSONA = qALTA_COMODATO.CID_TIPO_PERSONA,
                        E_TITULAR = qALTA_COMODATO.E_TITULAR,
                        E_RFC = qALTA_COMODATO.E_RFC,
                        NID_TIPO_RELACION = qALTA_COMODATO.NID_TIPO_RELACION,
                        E_OBSERVACIONES = qALTA_COMODATO.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qALTA_COMODATO.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qALTA_COMODATO.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qALTA_COMODATO.NID_ESTADO_TESTADO,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_DECLARACION, single_query);

            if (NID_COMODATOs.Values.Count > 0) single_query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : single_query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_COMODATO, single_query);

            if (CID_TIPO_PERSONAs.Values.Count > 0) single_query = (CID_TIPO_PERSONAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA)) : single_query.Where(p => !CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(CID_TIPO_PERSONA, Declara_V2.MODELextended.ALTA_COMODATO.Properties.CID_TIPO_PERSONA, single_query);

            if (E_TITULARs.Values.Count > 0) single_query = (E_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_TITULARs.Values.Contains(p.E_TITULAR)) : single_query.Where(p => !E_TITULARs.Values.Contains(p.E_TITULAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(E_TITULAR, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_TITULAR, single_query);

            if (E_RFCs.Values.Count > 0) single_query = (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_RFCs.Values.Contains(p.E_RFC)) : single_query.Where(p => !E_RFCs.Values.Contains(p.E_RFC));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(E_RFC, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_RFC, single_query);

            if (NID_TIPO_RELACIONs.Values.Count > 0) single_query = (NID_TIPO_RELACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_RELACIONs.Values.Contains(p.NID_TIPO_RELACION)) : single_query.Where(p => !NID_TIPO_RELACIONs.Values.Contains(p.NID_TIPO_RELACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(NID_TIPO_RELACION, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_TIPO_RELACION, single_query);

            if (E_OBSERVACIONESs.Values.Count > 0) single_query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : single_query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(E_OBSERVACIONES, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_OBSERVACIONES, single_query);

            if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) single_query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : single_query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_OBSERVACIONES_MARCADO, single_query);

            if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) single_query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : single_query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.V_OBSERVACIONES_TESTADO, single_query);

            if (NID_ESTADO_TESTADOs.Values.Count > 0) single_query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : single_query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_ESTADO_TESTADO, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_DECLARACION, query);

            if (NID_COMODATOs.Values.Count > 0) query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_COMODATO, query);

            if (CID_TIPO_PERSONAs.Values.Count > 0) query = (CID_TIPO_PERSONAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA)) : query.Where(p => !CID_TIPO_PERSONAs.Values.Contains(p.CID_TIPO_PERSONA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(CID_TIPO_PERSONA, Declara_V2.MODELextended.ALTA_COMODATO.Properties.CID_TIPO_PERSONA, query);

            if (E_TITULARs.Values.Count > 0) query = (E_TITULARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_TITULARs.Values.Contains(p.E_TITULAR)) : query.Where(p => !E_TITULARs.Values.Contains(p.E_TITULAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(E_TITULAR, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_TITULAR, query);

            if (E_RFCs.Values.Count > 0) query = (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_RFCs.Values.Contains(p.E_RFC)) : query.Where(p => !E_RFCs.Values.Contains(p.E_RFC));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(E_RFC, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_RFC, query);

            if (NID_TIPO_RELACIONs.Values.Count > 0) query = (NID_TIPO_RELACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_RELACIONs.Values.Contains(p.NID_TIPO_RELACION)) : query.Where(p => !NID_TIPO_RELACIONs.Values.Contains(p.NID_TIPO_RELACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(NID_TIPO_RELACION, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_TIPO_RELACION, query);

            if (E_OBSERVACIONESs.Values.Count > 0) query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(E_OBSERVACIONES, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_OBSERVACIONES, query);

            if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.E_OBSERVACIONES_MARCADO, query);

            if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.V_OBSERVACIONES_TESTADO, query);

            if (NID_ESTADO_TESTADOs.Values.Count > 0) query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.ALTA_COMODATO.Properties.NID_ESTADO_TESTADO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_ALTA_COMODATOs = single_query.AsNoTracking().ToList();
            else
                base_ALTA_COMODATOs = new List<MODELDeclara_V2.ALTA_COMODATO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_ALTA_COMODATOs = query.AsNoTracking().ToList();
            else
                lista_ALTA_COMODATOs = new List<Declara_V2.MODELextended.ALTA_COMODATO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_COMODATO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_COMODATO> r;
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
