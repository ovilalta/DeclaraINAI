using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_EXPERIENCIA_LABORAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_EXPERIENCIA_LABORAL datos_DECLARACION_EXPERIENCIA_LABORAL { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_EXPERIENCIA_LABORAL> lista_DECLARACION_EXPERIENCIA_LABORAL => datos_DECLARACION_EXPERIENCIA_LABORAL.lista_DECLARACION_EXPERIENCIA_LABORALs;
        protected List<MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL> base_DECLARACION_EXPERIENCIA_LABORALs => datos_DECLARACION_EXPERIENCIA_LABORAL.base_DECLARACION_EXPERIENCIA_LABORALs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBREs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHA;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHAs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVEs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACIONs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_EXPERIENCIA_LABORAL
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL = value;
        }
        public ListFilter<Int32> NID_EXPERIENCIA_LABORALs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORALs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORALs = value;
        }

        public IntegerFilter NID_AMBITO_SECTOR
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR = value;
        }
        public ListFilter<Int32> NID_AMBITO_SECTORs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTORs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTORs = value;
        }

        public IntegerFilter NID_NIVEL_GOBIERNO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO = value;
        }
        public ListFilter<Int32> NID_NIVEL_GOBIERNOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNOs = value;
        }

        public IntegerFilter NID_AMBITO_PUBLICO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO = value;
        }
        public ListFilter<Int32> NID_AMBITO_PUBLICOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICOs = value;
        }

        public StringFilter V_NOMBRE
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE = value;
        }
        public ListFilter<String> V_NOMBREs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBREs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBREs = value;
        }

        public StringFilter V_RFC
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC = value;
        }
        public ListFilter<String> V_RFCs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFCs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFCs = value;
        }

        public StringFilter V_AREA_ADSCRIPCION
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION = value;
        }
        public ListFilter<String> V_AREA_ADSCRIPCIONs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCIONs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCIONs = value;
        }

        public StringFilter V_PUESTO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO = value;
        }
        public ListFilter<String> V_PUESTOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTOs = value;
        }

        public StringFilter V_FUNCION_PRINCIPAL
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL = value;
        }
        public ListFilter<String> V_FUNCION_PRINCIPALs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPALs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPALs = value;
        }

        public IntegerFilter NID_SECTOR
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR = value;
        }
        public ListFilter<Int32> NID_SECTORs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTORs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTORs = value;
        }

        public DateTimeFilter F_INGRESO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO = value;
        }

        public DateTimeFilter F_EGRESO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAISs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAISs = value;
        }

        public StringFilter E_OBSERVACIONES
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES = value;
        }
        public ListFilter<String> E_OBSERVACIONESs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONESs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONESs = value;
        }

        public StringFilter E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO = value;
        }
        public ListFilter<String> E_OBSERVACIONES_MARCADOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADOs = value;
        }

        public StringFilter V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO = value;
        }
        public ListFilter<String> V_OBSERVACIONES_TESTADOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADOs = value;
        }

        public IntegerFilter NID_ESTADO_TESTADO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADOs;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.OrderByCriterios;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_EXPERIENCIA_LABORAL() => datos_DECLARACION_EXPERIENCIA_LABORAL = new dald__l_DECLARACION_EXPERIENCIA_LABORAL();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.single_select();
        }

        #endregion

    }
}
