using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_CARGO_OTRO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO> lista_DECLARACION_CARGO_OTROs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_CARGO_OTRO> base_DECLARACION_CARGO_OTROs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_NIVEL_GOBIERNO { get; set; }
        internal ListFilter<Int32> NID_NIVEL_GOBIERNOs { get; set; }

        internal IntegerFilter NID_AMBITO_PUBLICO { get; set; }
        internal ListFilter<Int32> NID_AMBITO_PUBLICOs { get; set; }

        internal StringFilter VID_NOMBRE_ENTE { get; set; }
        internal ListFilter<String> VID_NOMBRE_ENTEs { get; set; }

        internal StringFilter V_AREA_ADSCRIPCION { get; set; }
        internal ListFilter<String> V_AREA_ADSCRIPCIONs { get; set; }

        internal StringFilter V_CARGO { get; set; }
        internal ListFilter<String> V_CARGOs { get; set; }

        internal System.Nullable<Boolean> L_HONORARIOS { get; set; }

        internal StringFilter V_NIVEL_EMPLEO { get; set; }
        internal ListFilter<String> V_NIVEL_EMPLEOs { get; set; }

        internal StringFilter V_FUNCION_PRINCIPAL { get; set; }
        internal ListFilter<String> V_FUNCION_PRINCIPALs { get; set; }

        internal DateTimeFilter F_POSESION { get; set; }

        internal StringFilter V_TEL_LABORAL { get; set; }
        internal ListFilter<String> V_TEL_LABORALs { get; set; }

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

        internal StringFilter V_OBSERVACIONES { get; set; }
        internal ListFilter<String> V_OBSERVACIONESs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_CARGO_OTRO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_CARGO_OTRO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_NIVEL_GOBIERNOs = new ListFilter<Int32>();
            NID_AMBITO_PUBLICOs = new ListFilter<Int32>();
            VID_NOMBRE_ENTEs = new ListFilter<String>();
            V_AREA_ADSCRIPCIONs = new ListFilter<String>();
            V_CARGOs = new ListFilter<String>();
            V_NIVEL_EMPLEOs = new ListFilter<String>();
            V_FUNCION_PRINCIPALs = new ListFilter<String>();
            V_TEL_LABORALs = new ListFilter<String>();
            C_CODIGO_POSTALs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            V_COLONIAs = new ListFilter<String>();
            V_DOMICILIOs = new ListFilter<String>();
            V_OBSERVACIONESs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_CARGO_OTRO
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_CARGO_OTRO in db.DECLARACION_CARGO_OTRO
                    join qCAT_NIVEL_GOBIERNO in db.CAT_NIVEL_GOBIERNO on qDECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO equals qCAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO
                    join qCAT_MUNICIPIO in db.CAT_MUNICIPIO on new { qDECLARACION_CARGO_OTRO.NID_PAIS, qDECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA, qDECLARACION_CARGO_OTRO.CID_MUNICIPIO } equals new { qCAT_MUNICIPIO.NID_PAIS, qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA, qCAT_MUNICIPIO.CID_MUNICIPIO }
                    join qCAT_NIVEL_GOBIERNO2 in db.CAT_NIVEL_GOBIERNO on qDECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO equals qCAT_NIVEL_GOBIERNO2.NID_NIVEL_GOBIERNO
                    join qCAT_AMBITO_PUBLICO in db.CAT_AMBITO_PUBLICO on qDECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO equals qCAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO
                    select new Declara_V2.MODELextended.DECLARACION_CARGO_OTRO
                    {
                        VID_NOMBRE = qDECLARACION_CARGO_OTRO.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_CARGO_OTRO.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_CARGO_OTRO.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_CARGO_OTRO.NID_DECLARACION,
                        NID_NIVEL_GOBIERNO = qDECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO,
                        NID_AMBITO_PUBLICO = qDECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO,
                        VID_NOMBRE_ENTE = qDECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE,
                        V_AREA_ADSCRIPCION = qDECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION,
                        V_CARGO = qDECLARACION_CARGO_OTRO.V_CARGO,
                        L_HONORARIOS = qDECLARACION_CARGO_OTRO.L_HONORARIOS,
                        V_NIVEL_EMPLEO = qDECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO,
                        V_FUNCION_PRINCIPAL = qDECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL,
                        F_POSESION = qDECLARACION_CARGO_OTRO.F_POSESION,
                        V_TEL_LABORAL = qDECLARACION_CARGO_OTRO.V_TEL_LABORAL,
                        C_CODIGO_POSTAL = qDECLARACION_CARGO_OTRO.C_CODIGO_POSTAL,
                        NID_PAIS = qDECLARACION_CARGO_OTRO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qDECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qDECLARACION_CARGO_OTRO.CID_MUNICIPIO,
                        V_COLONIA = qDECLARACION_CARGO_OTRO.V_COLONIA,
                        V_DOMICILIO = qDECLARACION_CARGO_OTRO.V_DOMICILIO,
                        V_OBSERVACIONES = qDECLARACION_CARGO_OTRO.V_OBSERVACIONES,
                        V_NIVEL_GOBIERNO = qCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO,
                        V_MUNICIPIO = qCAT_MUNICIPIO.V_MUNICIPIO,
                        V_NIVEL_GOBIERNO_CAT_NIVEL_GOBIERNO = qCAT_NIVEL_GOBIERNO2.V_NIVEL_GOBIERNO,
                        V_AMBITO_PUBLICO = qCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_DECLARACION, single_query);

            if (NID_NIVEL_GOBIERNOs.Values.Count > 0) single_query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : single_query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_NIVEL_GOBIERNO, single_query);

            if (NID_AMBITO_PUBLICOs.Values.Count > 0) single_query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : single_query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_AMBITO_PUBLICO, single_query);

            if (VID_NOMBRE_ENTEs.Values.Count > 0) single_query = (VID_NOMBRE_ENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBRE_ENTEs.Values.Contains(p.VID_NOMBRE_ENTE)) : single_query.Where(p => !VID_NOMBRE_ENTEs.Values.Contains(p.VID_NOMBRE_ENTE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(VID_NOMBRE_ENTE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_NOMBRE_ENTE, single_query);

            if (V_AREA_ADSCRIPCIONs.Values.Count > 0) single_query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : single_query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_AREA_ADSCRIPCION, single_query);

            if (V_CARGOs.Values.Count > 0) single_query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : single_query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_CARGO, single_query);

            if (L_HONORARIOS.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(p => p.L_HONORARIOS == L_HONORARIOS);

            if (V_NIVEL_EMPLEOs.Values.Count > 0) single_query = (V_NIVEL_EMPLEOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NIVEL_EMPLEOs.Values.Contains(p.V_NIVEL_EMPLEO)) : single_query.Where(p => !V_NIVEL_EMPLEOs.Values.Contains(p.V_NIVEL_EMPLEO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_NIVEL_EMPLEO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_NIVEL_EMPLEO, single_query);

            if (V_FUNCION_PRINCIPALs.Values.Count > 0) single_query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : single_query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_FUNCION_PRINCIPAL, single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(F_POSESION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.F_POSESION, single_query);

            if (V_TEL_LABORALs.Values.Count > 0) single_query = (V_TEL_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TEL_LABORALs.Values.Contains(p.V_TEL_LABORAL)) : single_query.Where(p => !V_TEL_LABORALs.Values.Contains(p.V_TEL_LABORAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_TEL_LABORAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_TEL_LABORAL, single_query);

            if (C_CODIGO_POSTALs.Values.Count > 0) single_query = (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL)) : single_query.Where(p => !C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(C_CODIGO_POSTAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.C_CODIGO_POSTAL, single_query);

            if (NID_PAISs.Values.Count > 0) single_query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_PAIS, single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) single_query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.CID_ENTIDAD_FEDERATIVA, single_query);

            if (CID_MUNICIPIOs.Values.Count > 0) single_query = (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(CID_MUNICIPIO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.CID_MUNICIPIO, single_query);

            if (V_COLONIAs.Values.Count > 0) single_query = (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_COLONIAs.Values.Contains(p.V_COLONIA)) : single_query.Where(p => !V_COLONIAs.Values.Contains(p.V_COLONIA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_COLONIA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_COLONIA, single_query);

            if (V_DOMICILIOs.Values.Count > 0) single_query = (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DOMICILIOs.Values.Contains(p.V_DOMICILIO)) : single_query.Where(p => !V_DOMICILIOs.Values.Contains(p.V_DOMICILIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_DOMICILIO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_DOMICILIO, single_query);

            if (V_OBSERVACIONESs.Values.Count > 0) single_query = (V_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OBSERVACIONESs.Values.Contains(p.V_OBSERVACIONES)) : single_query.Where(p => !V_OBSERVACIONESs.Values.Contains(p.V_OBSERVACIONES));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO_OTRO>(V_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_OBSERVACIONES, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_DECLARACION, query);

            if (NID_NIVEL_GOBIERNOs.Values.Count > 0) query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_NIVEL_GOBIERNO, query);

            if (NID_AMBITO_PUBLICOs.Values.Count > 0) query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_AMBITO_PUBLICO, query);

            if (VID_NOMBRE_ENTEs.Values.Count > 0) query = (VID_NOMBRE_ENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBRE_ENTEs.Values.Contains(p.VID_NOMBRE_ENTE)) : query.Where(p => !VID_NOMBRE_ENTEs.Values.Contains(p.VID_NOMBRE_ENTE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(VID_NOMBRE_ENTE, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.VID_NOMBRE_ENTE, query);

            if (V_AREA_ADSCRIPCIONs.Values.Count > 0) query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_AREA_ADSCRIPCION, query);

            if (V_CARGOs.Values.Count > 0) query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_CARGO, query);

            if (L_HONORARIOS.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(p => p.L_HONORARIOS == L_HONORARIOS);

            if (V_NIVEL_EMPLEOs.Values.Count > 0) query = (V_NIVEL_EMPLEOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NIVEL_EMPLEOs.Values.Contains(p.V_NIVEL_EMPLEO)) : query.Where(p => !V_NIVEL_EMPLEOs.Values.Contains(p.V_NIVEL_EMPLEO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_NIVEL_EMPLEO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_NIVEL_EMPLEO, query);

            if (V_FUNCION_PRINCIPALs.Values.Count > 0) query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_FUNCION_PRINCIPAL, query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(F_POSESION, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.F_POSESION, query);

            if (V_TEL_LABORALs.Values.Count > 0) query = (V_TEL_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TEL_LABORALs.Values.Contains(p.V_TEL_LABORAL)) : query.Where(p => !V_TEL_LABORALs.Values.Contains(p.V_TEL_LABORAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_TEL_LABORAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_TEL_LABORAL, query);

            if (C_CODIGO_POSTALs.Values.Count > 0) query = (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL)) : query.Where(p => !C_CODIGO_POSTALs.Values.Contains(p.C_CODIGO_POSTAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(C_CODIGO_POSTAL, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.C_CODIGO_POSTAL, query);

            if (NID_PAISs.Values.Count > 0) query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.NID_PAIS, query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.CID_ENTIDAD_FEDERATIVA, query);

            if (CID_MUNICIPIOs.Values.Count > 0) query = (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Values.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(CID_MUNICIPIO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.CID_MUNICIPIO, query);

            if (V_COLONIAs.Values.Count > 0) query = (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_COLONIAs.Values.Contains(p.V_COLONIA)) : query.Where(p => !V_COLONIAs.Values.Contains(p.V_COLONIA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_COLONIA, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_COLONIA, query);

            if (V_DOMICILIOs.Values.Count > 0) query = (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DOMICILIOs.Values.Contains(p.V_DOMICILIO)) : query.Where(p => !V_DOMICILIOs.Values.Contains(p.V_DOMICILIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_DOMICILIO, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_DOMICILIO, query);

            if (V_OBSERVACIONESs.Values.Count > 0) query = (V_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OBSERVACIONESs.Values.Contains(p.V_OBSERVACIONES)) : query.Where(p => !V_OBSERVACIONESs.Values.Contains(p.V_OBSERVACIONES));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>(V_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_CARGO_OTRO.Properties.V_OBSERVACIONES, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_CARGO_OTROs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_CARGO_OTROs = new List<MODELDeclara_V2.DECLARACION_CARGO_OTRO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_CARGO_OTROs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_CARGO_OTROs = new List<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_CARGO_OTRO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO> r;
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
