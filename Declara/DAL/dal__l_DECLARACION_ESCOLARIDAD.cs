using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_ESCOLARIDAD : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD> lista_DECLARACION_ESCOLARIDADs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_ESCOLARIDAD> base_DECLARACION_ESCOLARIDADs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_ESCOLARIDAD { get; set; }
        internal ListFilter<Int32> NID_ESCOLARIDADs { get; set; }

        internal IntegerFilter NID_NIVEL_ESCOLARIDAD { get; set; }
        internal ListFilter<Int32> NID_NIVEL_ESCOLARIDADs { get; set; }

        internal StringFilter V_INSTITUCION_EDUCATIVA { get; set; }
        internal ListFilter<String> V_INSTITUCION_EDUCATIVAs { get; set; }

        internal StringFilter V_CARRERA { get; set; }
        internal ListFilter<String> V_CARRERAs { get; set; }

        internal IntegerFilter NID_ESTADO_ESCOLARIDAD { get; set; }
        internal ListFilter<Int32> NID_ESTADO_ESCOLARIDADs { get; set; }

        internal IntegerFilter NID_DOCUMENTO_OBTENIDO { get; set; }
        internal ListFilter<Int32> NID_DOCUMENTO_OBTENIDOs { get; set; }

        internal DateTimeFilter F_OBTENCION { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_ESCOLARIDAD> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_ESCOLARIDAD()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_ESCOLARIDADs = new ListFilter<Int32>();
            NID_NIVEL_ESCOLARIDADs = new ListFilter<Int32>();
            V_INSTITUCION_EDUCATIVAs = new ListFilter<String>();
            V_CARRERAs = new ListFilter<String>();
            NID_ESTADO_ESCOLARIDADs = new ListFilter<Int32>();
            NID_DOCUMENTO_OBTENIDOs = new ListFilter<Int32>();
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
            single_query = from p in db.DECLARACION_ESCOLARIDAD
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_ESCOLARIDAD in db.DECLARACION_ESCOLARIDAD
                    join qCAT_NIVEL_ESCOLARIDAD in db.CAT_NIVEL_ESCOLARIDAD on qDECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD equals qCAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD
                    join qCAT_ESTADO_ESCOLARIDAD in db.CAT_ESTADO_ESCOLARIDAD on qDECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD equals qCAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD
                    join qCAT_DOCUMENTO_OBTENIDO in db.CAT_DOCUMENTO_OBTENIDO on qDECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO equals qCAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO
                    join qCAT_PAIS in db.CAT_PAIS on qDECLARACION_ESCOLARIDAD.NID_PAIS equals qCAT_PAIS.NID_PAIS
                    select new Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD
                    {
                        VID_NOMBRE = qDECLARACION_ESCOLARIDAD.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_ESCOLARIDAD.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_ESCOLARIDAD.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_ESCOLARIDAD.NID_DECLARACION,
                        NID_ESCOLARIDAD = qDECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD,
                        NID_NIVEL_ESCOLARIDAD = qDECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD,
                        V_INSTITUCION_EDUCATIVA = qDECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA,
                        V_CARRERA = qDECLARACION_ESCOLARIDAD.V_CARRERA,
                        NID_ESTADO_ESCOLARIDAD = qDECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD,
                        NID_DOCUMENTO_OBTENIDO = qDECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO,
                        F_OBTENCION = qDECLARACION_ESCOLARIDAD.F_OBTENCION,
                        NID_PAIS = qDECLARACION_ESCOLARIDAD.NID_PAIS,
                        E_OBSERVACIONES = qDECLARACION_ESCOLARIDAD.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qDECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qDECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO,
                        V_NIVEL_ESCOLARIDAD = qCAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD,
                        V_ESTADO_ESCOLARIDAD = qCAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD,
                        V_DOCUMENTO_OBTENIDO = qCAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO,
                        V_PAIS = qCAT_PAIS.V_PAIS,
                        V_NACIONALIDAD_M = qCAT_PAIS.V_NACIONALIDAD_M,
                        V_NACIONALIDAD_F = qCAT_PAIS.V_NACIONALIDAD_F,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_DECLARACION, single_query);

            if (NID_ESCOLARIDADs.Values.Count > 0) single_query = (NID_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESCOLARIDADs.Values.Contains(p.NID_ESCOLARIDAD)) : single_query.Where(p => !NID_ESCOLARIDADs.Values.Contains(p.NID_ESCOLARIDAD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESCOLARIDAD, single_query);

            if (NID_NIVEL_ESCOLARIDADs.Values.Count > 0) single_query = (NID_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD)) : single_query.Where(p => !NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_NIVEL_ESCOLARIDAD, single_query);

            if (V_INSTITUCION_EDUCATIVAs.Values.Count > 0) single_query = (V_INSTITUCION_EDUCATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_INSTITUCION_EDUCATIVAs.Values.Contains(p.V_INSTITUCION_EDUCATIVA)) : single_query.Where(p => !V_INSTITUCION_EDUCATIVAs.Values.Contains(p.V_INSTITUCION_EDUCATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(V_INSTITUCION_EDUCATIVA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_INSTITUCION_EDUCATIVA, single_query);

            if (V_CARRERAs.Values.Count > 0) single_query = (V_CARRERAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CARRERAs.Values.Contains(p.V_CARRERA)) : single_query.Where(p => !V_CARRERAs.Values.Contains(p.V_CARRERA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(V_CARRERA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_CARRERA, single_query);

            if (NID_ESTADO_ESCOLARIDADs.Values.Count > 0) single_query = (NID_ESTADO_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_ESCOLARIDADs.Values.Contains(p.NID_ESTADO_ESCOLARIDAD)) : single_query.Where(p => !NID_ESTADO_ESCOLARIDADs.Values.Contains(p.NID_ESTADO_ESCOLARIDAD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_ESTADO_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESTADO_ESCOLARIDAD, single_query);

            if (NID_DOCUMENTO_OBTENIDOs.Values.Count > 0) single_query = (NID_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO)) : single_query.Where(p => !NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_DOCUMENTO_OBTENIDO, single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(F_OBTENCION, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.F_OBTENCION, single_query);

            if (NID_PAISs.Values.Count > 0) single_query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_PAIS, single_query);

            if (E_OBSERVACIONESs.Values.Count > 0) single_query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : single_query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.E_OBSERVACIONES, single_query);

            if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) single_query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : single_query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.E_OBSERVACIONES_MARCADO, single_query);

            if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) single_query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : single_query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_OBSERVACIONES_TESTADO, single_query);

            if (NID_ESTADO_TESTADOs.Values.Count > 0) single_query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : single_query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESTADO_TESTADO, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_DECLARACION, query);

            if (NID_ESCOLARIDADs.Values.Count > 0) query = (NID_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESCOLARIDADs.Values.Contains(p.NID_ESCOLARIDAD)) : query.Where(p => !NID_ESCOLARIDADs.Values.Contains(p.NID_ESCOLARIDAD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESCOLARIDAD, query);

            if (NID_NIVEL_ESCOLARIDADs.Values.Count > 0) query = (NID_NIVEL_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD)) : query.Where(p => !NID_NIVEL_ESCOLARIDADs.Values.Contains(p.NID_NIVEL_ESCOLARIDAD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_NIVEL_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_NIVEL_ESCOLARIDAD, query);

            if (V_INSTITUCION_EDUCATIVAs.Values.Count > 0) query = (V_INSTITUCION_EDUCATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_INSTITUCION_EDUCATIVAs.Values.Contains(p.V_INSTITUCION_EDUCATIVA)) : query.Where(p => !V_INSTITUCION_EDUCATIVAs.Values.Contains(p.V_INSTITUCION_EDUCATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(V_INSTITUCION_EDUCATIVA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_INSTITUCION_EDUCATIVA, query);

            if (V_CARRERAs.Values.Count > 0) query = (V_CARRERAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CARRERAs.Values.Contains(p.V_CARRERA)) : query.Where(p => !V_CARRERAs.Values.Contains(p.V_CARRERA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(V_CARRERA, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_CARRERA, query);

            if (NID_ESTADO_ESCOLARIDADs.Values.Count > 0) query = (NID_ESTADO_ESCOLARIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_ESCOLARIDADs.Values.Contains(p.NID_ESTADO_ESCOLARIDAD)) : query.Where(p => !NID_ESTADO_ESCOLARIDADs.Values.Contains(p.NID_ESTADO_ESCOLARIDAD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_ESTADO_ESCOLARIDAD, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESTADO_ESCOLARIDAD, query);

            if (NID_DOCUMENTO_OBTENIDOs.Values.Count > 0) query = (NID_DOCUMENTO_OBTENIDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO)) : query.Where(p => !NID_DOCUMENTO_OBTENIDOs.Values.Contains(p.NID_DOCUMENTO_OBTENIDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_DOCUMENTO_OBTENIDO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_DOCUMENTO_OBTENIDO, query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(F_OBTENCION, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.F_OBTENCION, query);

            if (NID_PAISs.Values.Count > 0) query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_PAIS, query);

            if (E_OBSERVACIONESs.Values.Count > 0) query = (E_OBSERVACIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES)) : query.Where(p => !E_OBSERVACIONESs.Values.Contains(p.E_OBSERVACIONES));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(E_OBSERVACIONES, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.E_OBSERVACIONES, query);

            if (E_OBSERVACIONES_MARCADOs.Values.Count > 0) query = (E_OBSERVACIONES_MARCADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO)) : query.Where(p => !E_OBSERVACIONES_MARCADOs.Values.Contains(p.E_OBSERVACIONES_MARCADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(E_OBSERVACIONES_MARCADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.E_OBSERVACIONES_MARCADO, query);

            if (V_OBSERVACIONES_TESTADOs.Values.Count > 0) query = (V_OBSERVACIONES_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO)) : query.Where(p => !V_OBSERVACIONES_TESTADOs.Values.Contains(p.V_OBSERVACIONES_TESTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(V_OBSERVACIONES_TESTADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.V_OBSERVACIONES_TESTADO, query);

            if (NID_ESTADO_TESTADOs.Values.Count > 0) query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Values.Contains(p.NID_ESTADO_TESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD.Properties.NID_ESTADO_TESTADO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_ESCOLARIDADs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_ESCOLARIDADs = new List<MODELDeclara_V2.DECLARACION_ESCOLARIDAD>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_ESCOLARIDADs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_ESCOLARIDADs = new List<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_ESCOLARIDAD> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD> r;
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
