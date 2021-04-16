using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_DEPENDIENTES_PUBLICO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_DEPENDIENTES_PUBLICO datos_DECLARACION_DEPENDIENTES_PUBLICO { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO> lista_DECLARACION_DEPENDIENTES_PUBLICO => datos_DECLARACION_DEPENDIENTES_PUBLICO.lista_DECLARACION_DEPENDIENTES_PUBLICOs;
        protected List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO> base_DECLARACION_DEPENDIENTES_PUBLICOs => datos_DECLARACION_DEPENDIENTES_PUBLICO.base_DECLARACION_DEPENDIENTES_PUBLICOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBREs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHAs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVEs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACIONs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTEs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTEs = value;
        }

        public IntegerFilter NID_AMBITO_SECTOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = value;
        }
        public ListFilter<Int32> NID_AMBITO_SECTORs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTORs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTORs = value;
        }

        public IntegerFilter NID_NIVEL_GOBIERNO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO = value;
        }
        public ListFilter<Int32> NID_NIVEL_GOBIERNOs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNOs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNOs = value;
        }

        public IntegerFilter NID_AMBITO_PUBLICO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO = value;
        }
        public ListFilter<Int32> NID_AMBITO_PUBLICOs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICOs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICOs = value;
        }

        public StringFilter V_NOMBRE_ENTE
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = value;
        }
        public ListFilter<String> V_NOMBRE_ENTEs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTEs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTEs = value;
        }

        public StringFilter V_AREA_ADSCRIPCION
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = value;
        }
        public ListFilter<String> V_AREA_ADSCRIPCIONs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCIONs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCIONs = value;
        }

        public StringFilter V_CARGO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = value;
        }
        public ListFilter<String> V_CARGOs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGOs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGOs = value;
        }

        public StringFilter V_FUNCION_PRINCIPAL
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = value;
        }
        public ListFilter<String> V_FUNCION_PRINCIPALs
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPALs;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPALs = value;
        }

        public DecimalFilter M_SALARIO_MENSUAL
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = value;
        }

        public DateTimeFilter F_INGRESO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.OrderByCriterios;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_DEPENDIENTES_PUBLICO() => datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald__l_DECLARACION_DEPENDIENTES_PUBLICO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.single_select();
        }

        #endregion

    }
}
