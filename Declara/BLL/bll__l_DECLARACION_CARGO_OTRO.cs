using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_CARGO_OTRO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_CARGO_OTRO datos_DECLARACION_CARGO_OTRO { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_CARGO_OTRO> lista_DECLARACION_CARGO_OTRO => datos_DECLARACION_CARGO_OTRO.lista_DECLARACION_CARGO_OTROs;
        protected List<MODELDeclara_V2.DECLARACION_CARGO_OTRO> base_DECLARACION_CARGO_OTROs => datos_DECLARACION_CARGO_OTRO.base_DECLARACION_CARGO_OTROs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE;
            set => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_NOMBREs;
            set => datos_DECLARACION_CARGO_OTRO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_FECHA;
            set => datos_DECLARACION_CARGO_OTRO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_FECHAs;
            set => datos_DECLARACION_CARGO_OTRO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_HOMOCLAVE;
            set => datos_DECLARACION_CARGO_OTRO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_HOMOCLAVEs;
            set => datos_DECLARACION_CARGO_OTRO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_DECLARACION;
            set => datos_DECLARACION_CARGO_OTRO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_DECLARACIONs;
            set => datos_DECLARACION_CARGO_OTRO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_NIVEL_GOBIERNO
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO;
            set => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO = value;
        }
        public ListFilter<Int32> NID_NIVEL_GOBIERNOs
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNOs;
            set => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNOs = value;
        }

        public IntegerFilter NID_AMBITO_PUBLICO
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO;
            set => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO = value;
        }
        public ListFilter<Int32> NID_AMBITO_PUBLICOs
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICOs;
            set => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICOs = value;
        }

        public StringFilter VID_NOMBRE_ENTE
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE;
            set => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE = value;
        }
        public ListFilter<String> VID_NOMBRE_ENTEs
        {
            get => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTEs;
            set => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTEs = value;
        }

        public StringFilter V_AREA_ADSCRIPCION
        {
            get => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION;
            set => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION = value;
        }
        public ListFilter<String> V_AREA_ADSCRIPCIONs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCIONs;
            set => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCIONs = value;
        }

        public StringFilter V_CARGO
        {
            get => datos_DECLARACION_CARGO_OTRO.V_CARGO;
            set => datos_DECLARACION_CARGO_OTRO.V_CARGO = value;
        }
        public ListFilter<String> V_CARGOs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_CARGOs;
            set => datos_DECLARACION_CARGO_OTRO.V_CARGOs = value;
        }

        public System.Nullable<Boolean> L_HONORARIOS
        {
            get => datos_DECLARACION_CARGO_OTRO.L_HONORARIOS;
            set => datos_DECLARACION_CARGO_OTRO.L_HONORARIOS = value;
        }

        public StringFilter V_NIVEL_EMPLEO
        {
            get => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO;
            set => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO = value;
        }
        public ListFilter<String> V_NIVEL_EMPLEOs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEOs;
            set => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEOs = value;
        }

        public StringFilter V_FUNCION_PRINCIPAL
        {
            get => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL;
            set => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL = value;
        }
        public ListFilter<String> V_FUNCION_PRINCIPALs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPALs;
            set => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPALs = value;
        }

        public DateTimeFilter F_POSESION
        {
            get => datos_DECLARACION_CARGO_OTRO.F_POSESION;
            set => datos_DECLARACION_CARGO_OTRO.F_POSESION = value;
        }

        public StringFilter V_TEL_LABORAL
        {
            get => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORAL;
            set => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORAL = value;
        }
        public ListFilter<String> V_TEL_LABORALs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORALs;
            set => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORALs = value;
        }

        public StringFilter C_CODIGO_POSTAL
        {
            get => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL;
            set => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL = value;
        }
        public ListFilter<String> C_CODIGO_POSTALs
        {
            get => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTALs;
            set => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTALs = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_PAIS;
            set => datos_DECLARACION_CARGO_OTRO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_DECLARACION_CARGO_OTRO.NID_PAISs;
            set => datos_DECLARACION_CARGO_OTRO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA;
            set => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
            get => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVAs;
            set => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
            get => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIO;
            set => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
            get => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIOs;
            set => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIOs = value;
        }

        public StringFilter V_COLONIA
        {
            get => datos_DECLARACION_CARGO_OTRO.V_COLONIA;
            set => datos_DECLARACION_CARGO_OTRO.V_COLONIA = value;
        }
        public ListFilter<String> V_COLONIAs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_COLONIAs;
            set => datos_DECLARACION_CARGO_OTRO.V_COLONIAs = value;
        }

        public StringFilter V_DOMICILIO
        {
            get => datos_DECLARACION_CARGO_OTRO.V_DOMICILIO;
            set => datos_DECLARACION_CARGO_OTRO.V_DOMICILIO = value;
        }
        public ListFilter<String> V_DOMICILIOs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_DOMICILIOs;
            set => datos_DECLARACION_CARGO_OTRO.V_DOMICILIOs = value;
        }

        public StringFilter V_OBSERVACIONES
        {
            get => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONES;
            set => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONES = value;
        }
        public ListFilter<String> V_OBSERVACIONESs
        {
            get => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONESs;
            set => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONESs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_CARGO_OTRO.OrderByCriterios;
            set => datos_DECLARACION_CARGO_OTRO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_CARGO_OTRO() => datos_DECLARACION_CARGO_OTRO = new dald__l_DECLARACION_CARGO_OTRO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_CARGO_OTRO.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_CARGO_OTRO.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_CARGO_OTRO.single_select();
        }

        #endregion

    }
}
