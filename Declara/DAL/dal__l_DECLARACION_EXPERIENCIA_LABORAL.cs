using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_EXPERIENCIA_LABORAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL> lista_DECLARACION_EXPERIENCIA_LABORALs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL> base_DECLARACION_EXPERIENCIA_LABORALs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_EXPERIENCIA_LABORAL { get; set; }
        internal ListFilter<Int32> NID_EXPERIENCIA_LABORALs { get; set; }

        internal IntegerFilter NID_AMBITO_SECTOR { get; set; }
        internal ListFilter<Int32> NID_AMBITO_SECTORs { get; set; }

        internal IntegerFilter NID_NIVEL_GOBIERNO { get; set; }
        internal ListFilter<Int32> NID_NIVEL_GOBIERNOs { get; set; }

        internal IntegerFilter NID_AMBITO_PUBLICO { get; set; }
        internal ListFilter<Int32> NID_AMBITO_PUBLICOs { get; set; }

        internal StringFilter V_NOMBRE { get; set; }
        internal ListFilter<String> V_NOMBREs { get; set; }

        internal StringFilter V_RFC { get; set; }
        internal ListFilter<String> V_RFCs { get; set; }

        internal StringFilter V_AREA_ADSCRIPCION { get; set; }
        internal ListFilter<String> V_AREA_ADSCRIPCIONs { get; set; }

        internal StringFilter V_PUESTO { get; set; }
        internal ListFilter<String> V_PUESTOs { get; set; }

        internal StringFilter V_FUNCION_PRINCIPAL { get; set; }
        internal ListFilter<String> V_FUNCION_PRINCIPALs { get; set; }

        internal IntegerFilter NID_SECTOR { get; set; }
        internal ListFilter<Int32> NID_SECTORs { get; set; }

        internal DateTimeFilter F_INGRESO { get; set; }

        internal DateTimeFilter F_EGRESO { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_EXPERIENCIA_LABORAL()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_EXPERIENCIA_LABORALs = new ListFilter<Int32>();
            NID_AMBITO_SECTORs = new ListFilter<Int32>();
            NID_NIVEL_GOBIERNOs = new ListFilter<Int32>();
            NID_AMBITO_PUBLICOs = new ListFilter<Int32>();
            V_NOMBREs = new ListFilter<String>();
            V_RFCs = new ListFilter<String>();
            V_AREA_ADSCRIPCIONs = new ListFilter<String>();
            V_PUESTOs = new ListFilter<String>();
            V_FUNCION_PRINCIPALs = new ListFilter<String>();
            NID_SECTORs = new ListFilter<Int32>();
            NID_PAISs = new ListFilter<Int32>();
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
            single_query = from p in db.DECLARACION_EXPERIENCIA_LABORAL
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_EXPERIENCIA_LABORAL in db.DECLARACION_EXPERIENCIA_LABORAL
                    join qCAT_PAIS in db.CAT_PAIS on qDECLARACION_EXPERIENCIA_LABORAL.NID_PAIS equals qCAT_PAIS.NID_PAIS
                    join qCAT_ESTADO_TESTADO in db.CAT_ESTADO_TESTADO on qDECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO equals qCAT_ESTADO_TESTADO.NID_ESTADO_TESTADO
                    join qCAT_SECTOR in db.CAT_SECTOR on qDECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR equals qCAT_SECTOR.NID_SECTOR
                    join qCAT_AMBITO_SECTOR in db.CAT_AMBITO_SECTOR on qDECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR equals qCAT_AMBITO_SECTOR.NID_AMBITO_SECTOR
                    join qCAT_NIVEL_GOBIERNO in db.CAT_NIVEL_GOBIERNO on qDECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO equals qCAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO
                    join qCAT_AMBITO_PUBLICO in db.CAT_AMBITO_PUBLICO on qDECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO equals qCAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO
                    select new Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL
                    {
                        VID_NOMBRE = qDECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_EXPERIENCIA_LABORAL.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION,
                        NID_EXPERIENCIA_LABORAL = qDECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL,
                        NID_AMBITO_SECTOR = qDECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR,
                        NID_NIVEL_GOBIERNO = qDECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO,
                        NID_AMBITO_PUBLICO = qDECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO,
                        V_NOMBRE = qDECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE,
                        V_RFC = qDECLARACION_EXPERIENCIA_LABORAL.V_RFC,
                        V_AREA_ADSCRIPCION = qDECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION,
                        V_PUESTO = qDECLARACION_EXPERIENCIA_LABORAL.V_PUESTO,
                        V_FUNCION_PRINCIPAL = qDECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL,
                        NID_SECTOR = qDECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR,
                        F_INGRESO = qDECLARACION_EXPERIENCIA_LABORAL.F_INGRESO,
                        F_EGRESO = qDECLARACION_EXPERIENCIA_LABORAL.F_EGRESO,
                        NID_PAIS = qDECLARACION_EXPERIENCIA_LABORAL.NID_PAIS,
                        E_OBSERVACIONES = qDECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qDECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qDECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO,
                        V_PAIS = qCAT_PAIS.V_PAIS,
                        V_NACIONALIDAD_M = qCAT_PAIS.V_NACIONALIDAD_M,
                        V_NACIONALIDAD_F = qCAT_PAIS.V_NACIONALIDAD_F,
                        V_ESTADO_TESTADO = qCAT_ESTADO_TESTADO.V_ESTADO_TESTADO,
                        V_SECTOR = qCAT_SECTOR.V_SECTOR,
                        V_AMBITO_SECTOR = qCAT_AMBITO_SECTOR.V_AMBITO_SECTOR,
                        V_NIVEL_GOBIERNO = qCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO,
                        V_AMBITO_PUBLICO = qCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO,
                    };
        }
        protected void Single_Where()
        {
        //    if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_NOMBRE, single_query);

        //    if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_FECHA, single_query);

        //    if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_HOMOCLAVE, single_query);

        //    if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_DECLARACION, single_query);

        //    if (NID_EXPERIENCIA_LABORALs.Values.Count > 0) single_query = (NID_EXPERIENCIA_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_EXPERIENCIA_LABORALs.Values.Contains(p.NID_EXPERIENCIA_LABORAL)) : single_query.Where(p => !NID_EXPERIENCIA_LABORALs.Values.Contains(p.NID_EXPERIENCIA_LABORAL));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_EXPERIENCIA_LABORAL, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_EXPERIENCIA_LABORAL, single_query);

        //    if (NID_AMBITO_SECTORs.Values.Count > 0) single_query = (NID_AMBITO_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR)) : single_query.Where(p => !NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_AMBITO_SECTOR, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_AMBITO_SECTOR, single_query);

        //    if (NID_NIVEL_GOBIERNOs.Values.Count > 0) single_query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : single_query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_NIVEL_GOBIERNO, single_query);

        //    if (NID_AMBITO_PUBLICOs.Values.Count > 0) single_query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : single_query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_AMBITO_PUBLICO, single_query);

        //    if (V_NOMBREs.Values.Count > 0) single_query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : single_query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_NOMBRE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_NOMBRE, single_query);

        //    if (V_RFCs.Values.Count > 0) single_query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : single_query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_RFC, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_RFC, single_query);

        //    if (V_AREA_ADSCRIPCIONs.Values.Count > 0) single_query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : single_query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_AREA_ADSCRIPCION, single_query);

        //    if (V_PUESTOs.Values.Count > 0) single_query = (V_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_PUESTOs.Values.Contains(p.V_PUESTO)) : single_query.Where(p => !V_PUESTOs.Values.Contains(p.V_PUESTO));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_PUESTO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_PUESTO, single_query);

        //    if (V_FUNCION_PRINCIPALs.Values.Count > 0) single_query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : single_query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_FUNCION_PRINCIPAL, single_query);

        //    if (NID_SECTORs.Values.Count > 0) single_query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : single_query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_SECTOR, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_SECTOR, single_query);

        //    single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.F_INGRESO, single_query);

        //    single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(F_EGRESO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.F_EGRESO, single_query);

        //    if (NID_PAISs.Values.Count > 0) single_query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_PAIS, single_query);

        //    if (E_OBSERVACIONESs.Values.Count > 0) single_query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : single_query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.E_OBSERVACIONES, single_query);

        //    if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) single_query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : single_query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.E_OBSERVACIONES_MARCADO, single_query);

        //    if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) single_query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : single_query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
        //    single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_OBSERVACIONES_TESTADO, single_query);

        //    if (NID_ESTADO_TESTADOs.Values.Count > 0) single_query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : single_query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
        //    single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_ESTADO_TESTADO, single_query);

        }
        protected void Where()
        {
            //if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_NOMBRE, query);

            //if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_FECHA, query);

            //if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.VID_HOMOCLAVE, query);

            //if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_DECLARACION, query);

            //if (NID_EXPERIENCIA_LABORALs.Values.Count > 0) query = (NID_EXPERIENCIA_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_EXPERIENCIA_LABORALs.Values.Contains(p.NID_EXPERIENCIA_LABORAL)) : query.Where(p => !NID_EXPERIENCIA_LABORALs.Values.Contains(p.NID_EXPERIENCIA_LABORAL));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_EXPERIENCIA_LABORAL, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_EXPERIENCIA_LABORAL, query);

            //if (NID_AMBITO_SECTORs.Values.Count > 0) query = (NID_AMBITO_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR)) : query.Where(p => !NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_AMBITO_SECTOR, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_AMBITO_SECTOR, query);

            //if (NID_NIVEL_GOBIERNOs.Values.Count > 0) query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_NIVEL_GOBIERNO, query);

            //if (NID_AMBITO_PUBLICOs.Values.Count > 0) query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_AMBITO_PUBLICO, query);

            //if (V_NOMBREs.Values.Count > 0) query = (V_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NOMBREs.Values.Contains(p.V_NOMBRE)) : query.Where(p => !V_NOMBREs.Values.Contains(p.V_NOMBRE));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_NOMBRE, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_NOMBRE, query);

            //if (V_RFCs.Values.Count > 0) query = (V_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RFCs.Values.Contains(p.V_RFC)) : query.Where(p => !V_RFCs.Values.Contains(p.V_RFC));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_RFC, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_RFC, query);

            //if (V_AREA_ADSCRIPCIONs.Values.Count > 0) query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_AREA_ADSCRIPCION, query);

            //if (V_PUESTOs.Values.Count > 0) query = (V_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_PUESTOs.Values.Contains(p.V_PUESTO)) : query.Where(p => !V_PUESTOs.Values.Contains(p.V_PUESTO));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_PUESTO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_PUESTO, query);

            //if (V_FUNCION_PRINCIPALs.Values.Count > 0) query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_FUNCION_PRINCIPAL, query);

            //if (NID_SECTORs.Values.Count > 0) query = (NID_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_SECTORs.Values.Contains(p.NID_SECTOR)) : query.Where(p => !NID_SECTORs.Values.Contains(p.NID_SECTOR));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_SECTOR, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_SECTOR, query);

            //query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.F_INGRESO, query);

            //query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(F_EGRESO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.F_EGRESO, query);

            //if (NID_PAISs.Values.Count > 0) query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_PAIS, query);

            //if (E_OBSERVACIONESs.Values.Count > 0) query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.E_OBSERVACIONES, query);

            //if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.E_OBSERVACIONES_MARCADO, query);

            //if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
            //query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.V_OBSERVACIONES_TESTADO, query);

            //if (NID_ESTADO_TESTADOs.Values.Count > 0) query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL.Properties.NID_ESTADO_TESTADO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_EXPERIENCIA_LABORALs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_EXPERIENCIA_LABORALs = new List<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_EXPERIENCIA_LABORALs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_EXPERIENCIA_LABORALs = new List<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL> r;
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
