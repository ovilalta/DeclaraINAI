using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_ESCOLARIDAD datos_DECLARACION_ESCOLARIDAD { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_ESCOLARIDAD> lista_DECLARACION_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.lista_DECLARACION_ESCOLARIDADs;
        protected List<MODELDeclara_V2.DECLARACION_ESCOLARIDAD> base_DECLARACION_ESCOLARIDADs => datos_DECLARACION_ESCOLARIDAD.base_DECLARACION_ESCOLARIDADs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_NOMBRE;
            set => datos_DECLARACION_ESCOLARIDAD.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_NOMBREs;
            set => datos_DECLARACION_ESCOLARIDAD.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_FECHA;
            set => datos_DECLARACION_ESCOLARIDAD.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_FECHAs;
            set => datos_DECLARACION_ESCOLARIDAD.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVE;
            set => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVEs;
            set => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACION;
            set => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACIONs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_ESCOLARIDAD
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD = value;
        }
        public ListFilter<Int32> NID_ESCOLARIDADs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDADs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDADs = value;
        }

        public IntegerFilter NID_NIVEL_ESCOLARIDAD
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
            set => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD = value;
        }
        public ListFilter<Int32> NID_NIVEL_ESCOLARIDADs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDADs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDADs = value;
        }

        public StringFilter V_INSTITUCION_EDUCATIVA
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA;
            set => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA = value;
        }
        public ListFilter<String> V_INSTITUCION_EDUCATIVAs
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVAs;
            set => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVAs = value;
        }

        public StringFilter V_CARRERA
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_CARRERA;
            set => datos_DECLARACION_ESCOLARIDAD.V_CARRERA = value;
        }
        public ListFilter<String> V_CARRERAs
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_CARRERAs;
            set => datos_DECLARACION_ESCOLARIDAD.V_CARRERAs = value;
        }

        public IntegerFilter NID_ESTADO_ESCOLARIDAD
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD = value;
        }
        public ListFilter<Int32> NID_ESTADO_ESCOLARIDADs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDADs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDADs = value;
        }

        public IntegerFilter NID_DOCUMENTO_OBTENIDO
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO;
            set => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO = value;
        }
        public ListFilter<Int32> NID_DOCUMENTO_OBTENIDOs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDOs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDOs = value;
        }

        public DateTimeFilter F_OBTENCION
        {
            get => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION;
            set => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_PAIS;
            set => datos_DECLARACION_ESCOLARIDAD.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_PAISs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_PAISs = value;
        }

        public StringFilter E_OBSERVACIONES
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES = value;
        }
        public ListFilter<String> E_OBSERVACIONESs
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONESs;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONESs = value;
        }

        public StringFilter E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO = value;
        }
        public ListFilter<String> E_OBSERVACIONES_MARCADOs
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADOs;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADOs = value;
        }

        public StringFilter V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO = value;
        }
        public ListFilter<String> V_OBSERVACIONES_TESTADOs
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADOs;
            set => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADOs = value;
        }

        public IntegerFilter NID_ESTADO_TESTADO
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADOs;
            set => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_ESCOLARIDAD.OrderByCriterios;
            set => datos_DECLARACION_ESCOLARIDAD.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_ESCOLARIDAD() => datos_DECLARACION_ESCOLARIDAD = new dald__l_DECLARACION_ESCOLARIDAD();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_ESCOLARIDAD.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_ESCOLARIDAD.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_ESCOLARIDAD.single_select();
        }

        #endregion

    }
}
