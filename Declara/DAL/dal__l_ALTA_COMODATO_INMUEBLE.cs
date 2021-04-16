using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_ALTA_COMODATO_INMUEBLE : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE> lista_ALTA_COMODATO_INMUEBLEs { get; set; }
        internal List<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE> base_ALTA_COMODATO_INMUEBLEs { get; set; }

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

        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal StringFilter C_CODIGO_POSTAL { get; set; }
        internal ListFilter<String> C_CODIGO_POSTALs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter CID_MUNICIPIO { get; set; }
        internal ListFilter<String> CID_MUNICIPIOs { get; set; }

        internal StringFilter V_COLONIA { get; set; }
        internal ListFilter<String> V_COLONIAs { get; set; }

        internal StringFilter V_DOMICILIO { get; set; }
        internal ListFilter<String> V_DOMICILIOs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_ALTA_COMODATO_INMUEBLE()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_COMODATOs = new ListFilter<Int32>();
            NID_TIPOs = new ListFilter<Int32>();
            C_CODIGO_POSTALs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            V_COLONIAs = new ListFilter<String>();
            V_DOMICILIOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.ALTA_COMODATO_INMUEBLE
                           select p;
        }
        protected void Select()
        {
            query = from qALTA_COMODATO_INMUEBLE in db.ALTA_COMODATO_INMUEBLE
                    join qCAT_MUNICIPIO in db.CAT_MUNICIPIO on new { qALTA_COMODATO_INMUEBLE.NID_PAIS, qALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA, qALTA_COMODATO_INMUEBLE.CID_MUNICIPIO } equals new { qCAT_MUNICIPIO.NID_PAIS, qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA, qCAT_MUNICIPIO.CID_MUNICIPIO }
                    join qCAT_TIPO_INMUEBLE in db.CAT_TIPO_INMUEBLE on qALTA_COMODATO_INMUEBLE.NID_TIPO equals qCAT_TIPO_INMUEBLE.NID_TIPO
                    select new Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE
                    {
                        VID_NOMBRE = qALTA_COMODATO_INMUEBLE.VID_NOMBRE,
                        VID_FECHA = qALTA_COMODATO_INMUEBLE.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_COMODATO_INMUEBLE.NID_DECLARACION,
                        NID_COMODATO = qALTA_COMODATO_INMUEBLE.NID_COMODATO,
                        NID_TIPO = qALTA_COMODATO_INMUEBLE.NID_TIPO,
                        C_CODIGO_POSTAL = qALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL,
                        NID_PAIS = qALTA_COMODATO_INMUEBLE.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qALTA_COMODATO_INMUEBLE.CID_MUNICIPIO,
                        V_COLONIA = qALTA_COMODATO_INMUEBLE.V_COLONIA,
                        V_DOMICILIO = qALTA_COMODATO_INMUEBLE.V_DOMICILIO,
                        V_MUNICIPIO = qCAT_MUNICIPIO.V_MUNICIPIO,
                        V_TIPO = qCAT_TIPO_INMUEBLE.V_TIPO,
                        L_ACTIVO = qCAT_TIPO_INMUEBLE.L_ACTIVO,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_DECLARACION, single_query);

            if (NID_COMODATOs.Values.Count > 0) single_query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : single_query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_COMODATO, single_query);

            if (NID_TIPOs.Values.Count > 0) single_query = (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Values.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Values.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(NID_TIPO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_TIPO, single_query);

            if (C_CODIGO_POSTALs.Values.Count > 0) single_query = (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL)) : single_query.Where(p => !C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(C_CODIGO_POSTAL, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.C_CODIGO_POSTAL, single_query);

            if (NID_PAISs.Values.Count > 0) single_query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(NID_PAIS, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_PAIS, single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) single_query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.CID_ENTIDAD_FEDERATIVA, single_query);

            if (CID_MUNICIPIOs.Values.Count > 0) single_query = (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(CID_MUNICIPIO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.CID_MUNICIPIO, single_query);

            if (V_COLONIAs.Values.Count > 0) single_query = (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_COLONIAs.Values.Contains(p.V_COLONIA)) : single_query.Where(p => !V_COLONIAs.Values.Contains(p.V_COLONIA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(V_COLONIA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.V_COLONIA, single_query);

            if (V_DOMICILIOs.Values.Count > 0) single_query = (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DOMICILIOs.Values.Contains(p.V_DOMICILIO)) : single_query.Where(p => !V_DOMICILIOs.Values.Contains(p.V_DOMICILIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>(V_DOMICILIO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.V_DOMICILIO, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_DECLARACION, query);

            if (NID_COMODATOs.Values.Count > 0) query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_COMODATO, query);

            if (NID_TIPOs.Values.Count > 0) query = (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Values.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Values.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(NID_TIPO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_TIPO, query);

            if (C_CODIGO_POSTALs.Values.Count > 0) query = (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL)) : query.Where(p => !C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(C_CODIGO_POSTAL, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.C_CODIGO_POSTAL, query);

            if (NID_PAISs.Values.Count > 0) query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(NID_PAIS, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.NID_PAIS, query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.CID_ENTIDAD_FEDERATIVA, query);

            if (CID_MUNICIPIOs.Values.Count > 0) query = (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(CID_MUNICIPIO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.CID_MUNICIPIO, query);

            if (V_COLONIAs.Values.Count > 0) query = (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_COLONIAs.Values.Contains(p.V_COLONIA)) : query.Where(p => !V_COLONIAs.Values.Contains(p.V_COLONIA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(V_COLONIA, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.V_COLONIA, query);

            if (V_DOMICILIOs.Values.Count > 0) query = (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DOMICILIOs.Values.Contains(p.V_DOMICILIO)) : query.Where(p => !V_DOMICILIOs.Values.Contains(p.V_DOMICILIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>(V_DOMICILIO, Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE.Properties.V_DOMICILIO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_ALTA_COMODATO_INMUEBLEs = single_query.AsNoTracking().ToList();
            else
                base_ALTA_COMODATO_INMUEBLEs = new List<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_ALTA_COMODATO_INMUEBLEs = query.AsNoTracking().ToList();
            else
                lista_ALTA_COMODATO_INMUEBLEs = new List<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE> r;
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
