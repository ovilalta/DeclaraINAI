using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_DIARIA : _bllSistema
    {

        internal dald__l_DECLARACION_DIARIA datos_DECLARACION_DIARIA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_DIARIA> lista_DECLARACION_DIARIA => datos_DECLARACION_DIARIA.lista_DECLARACION_DIARIAs;

        protected List<MODELDeclara_V2.DECLARACION> base_DECLARACIONS => datos_DECLARACION_DIARIA.base_DECLARACIONs;

        public StringFilter V_RFC
        {
            get => datos_DECLARACION_DIARIA.V_RFC;
            set => datos_DECLARACION_DIARIA.V_RFC = value;
        }

        public StringFilter V_NOMBRE_COMPLETO
        {
            get => datos_DECLARACION_DIARIA.V_NOMBRE_COMPLETO;
            set => datos_DECLARACION_DIARIA.V_NOMBRE_COMPLETO = value;
        }

        public StringFilter V_NOMBRE_COMPLETO_ESTILO2
        {
            get => datos_DECLARACION_DIARIA.V_NOMBRE_COMPLETO_ESTILO2;
            set => datos_DECLARACION_DIARIA.V_NOMBRE_COMPLETO_ESTILO2 = value;
        }
        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_DIARIA.VID_NOMBRE;
          set => datos_DECLARACION_DIARIA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_DIARIA.VID_NOMBREs;
          set => datos_DECLARACION_DIARIA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_DIARIA.VID_FECHA;
          set => datos_DECLARACION_DIARIA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_DIARIA.VID_FECHAs;
          set => datos_DECLARACION_DIARIA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_DIARIA.VID_HOMOCLAVE;
          set => datos_DECLARACION_DIARIA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_DIARIA.VID_HOMOCLAVEs;
          set => datos_DECLARACION_DIARIA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_DIARIA.NID_DECLARACION;
          set => datos_DECLARACION_DIARIA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_DIARIA.NID_DECLARACIONs;
          set => datos_DECLARACION_DIARIA.NID_DECLARACIONs = value;
        }

        public StringFilter C_EJERCICIO
        {
          get => datos_DECLARACION_DIARIA.C_EJERCICIO;
          set => datos_DECLARACION_DIARIA.C_EJERCICIO = value;
        }
        public ListFilter<String> C_EJERCICIOs
        {
          get => datos_DECLARACION_DIARIA.C_EJERCICIOs;
          set => datos_DECLARACION_DIARIA.C_EJERCICIOs = value;
        }

        public IntegerFilter NID_TIPO_DECLARACION
        {
          get => datos_DECLARACION_DIARIA.NID_TIPO_DECLARACION;
          set => datos_DECLARACION_DIARIA.NID_TIPO_DECLARACION = value;
        }
        public ListFilter<Int32> NID_TIPO_DECLARACIONs
        {
          get => datos_DECLARACION_DIARIA.NID_TIPO_DECLARACIONs;
          set => datos_DECLARACION_DIARIA.NID_TIPO_DECLARACIONs = value;
        }

        public IntegerFilter NID_ESTADO
        {
          get => datos_DECLARACION_DIARIA.NID_ESTADO;
          set => datos_DECLARACION_DIARIA.NID_ESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADOs
        {
          get => datos_DECLARACION_DIARIA.NID_ESTADOs;
          set => datos_DECLARACION_DIARIA.NID_ESTADOs = value;
        }

        public IntegerFilter NID_ESTADO_TESTADO
        {
            get => datos_DECLARACION_DIARIA.NID_ESTADO_TESTADO;
            set => datos_DECLARACION_DIARIA.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
            get => datos_DECLARACION_DIARIA.NID_ESTADO_TESTADOs;
            set => datos_DECLARACION_DIARIA.NID_ESTADO_TESTADOs = value;
        }

        public DateTimeFilter F_REGISTRO
        {
          get => datos_DECLARACION_DIARIA.F_REGISTRO;
          set => datos_DECLARACION_DIARIA.F_REGISTRO = value;
        }
        public ListFilter<DateTime> F_REGISTROs
        {
          get => datos_DECLARACION_DIARIA.F_REGISTROs;
          set => datos_DECLARACION_DIARIA.F_REGISTROs = value;
        }

        public DateTimeFilter F_ENVIO
        {
          get => datos_DECLARACION_DIARIA.F_ENVIO;
          set => datos_DECLARACION_DIARIA.F_ENVIO = value;
        }
        public ListFilter<DateTime> F_ENVIOs
        {
          get => datos_DECLARACION_DIARIA.F_ENVIOs;
          set => datos_DECLARACION_DIARIA.F_ENVIOs = value;
        }


        public IntegerFilter NID_ENVIO_DIA
        {
            get => datos_DECLARACION_DIARIA.NID_ENVIO_DIA;
            set => datos_DECLARACION_DIARIA.NID_ENVIO_DIA = value;
        }
        
        public IntegerFilter NID_ENVIO_MES
        {
            get => datos_DECLARACION_DIARIA.NID_ENVIO_MES;
            set => datos_DECLARACION_DIARIA.NID_ENVIO_MES = value;
        }

        public ListFilter<Int32> NID_ENVIO_MESs
        {
            get => datos_DECLARACION_DIARIA.NID_ENVIO_MESs;
            set => datos_DECLARACION_DIARIA.NID_ENVIO_MESs = value;
        }

        public IntegerFilter NID_ENVIO_ANIO
        {
            get => datos_DECLARACION_DIARIA.NID_ENVIO_ANIO;
            set => datos_DECLARACION_DIARIA.NID_ENVIO_ANIO = value;
        }

        public System.Nullable<Boolean> L_AUTORIZA_PUBLICAR
        {
            get => datos_DECLARACION_DIARIA.L_AUTORIZA_PUBLICAR;
            set => datos_DECLARACION_DIARIA.L_AUTORIZA_PUBLICAR = value;
        }


        #endregion


        #region *** Constructores ***

        public bll__l_DECLARACION_DIARIA() => datos_DECLARACION_DIARIA = new dald__l_DECLARACION_DIARIA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_DIARIA.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_DIARIA.clearOrderBy();
        }
 

     #endregion

    }
}
