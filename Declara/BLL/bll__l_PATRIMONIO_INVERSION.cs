using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_INVERSION : _bllSistema
    {

        internal dald__l_PATRIMONIO_INVERSION datos_PATRIMONIO_INVERSION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_INVERSION> lista_PATRIMONIO_INVERSION => datos_PATRIMONIO_INVERSION.lista_PATRIMONIO_INVERSIONs;

        protected List<MODELDeclara_V2.PATRIMONIO_INVERSION>  base_PATRIMONIO_INVERSIONs => datos_PATRIMONIO_INVERSION.base_PATRIMONIO_INVERSIONs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_INVERSION.VID_NOMBRE;
          set => datos_PATRIMONIO_INVERSION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_INVERSION.VID_NOMBREs;
          set => datos_PATRIMONIO_INVERSION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_INVERSION.VID_FECHA;
          set => datos_PATRIMONIO_INVERSION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_INVERSION.VID_FECHAs;
          set => datos_PATRIMONIO_INVERSION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_INVERSION.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_INVERSION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_INVERSION.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_INVERSION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_PATRIMONIO_INVERSION.NID_PATRIMONIO;
          set => datos_PATRIMONIO_INVERSION.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_PATRIMONIO_INVERSION.NID_PATRIMONIOs;
          set => datos_PATRIMONIO_INVERSION.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO_INVERSION
        {
          get => datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSION;
          set => datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSION = value;
        }
        public ListFilter<Int32> NID_TIPO_INVERSIONs
        {
          get => datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSIONs;
          set => datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSIONs = value;
        }

        public IntegerFilter NID_SUBTIPO_INVERSION
        {
          get => datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION;
          set => datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION = value;
        }
        public ListFilter<Int32> NID_SUBTIPO_INVERSIONs
        {
          get => datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSIONs;
          set => datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSIONs = value;
        }

        public IntegerFilter NID_INSTITUCION
        {
          get => datos_PATRIMONIO_INVERSION.NID_INSTITUCION;
          set => datos_PATRIMONIO_INVERSION.NID_INSTITUCION = value;
        }
        public ListFilter<Int32> NID_INSTITUCIONs
        {
          get => datos_PATRIMONIO_INVERSION.NID_INSTITUCIONs;
          set => datos_PATRIMONIO_INVERSION.NID_INSTITUCIONs = value;
        }

        public StringFilter E_CUENTA
        {
          get => datos_PATRIMONIO_INVERSION.E_CUENTA;
          set => datos_PATRIMONIO_INVERSION.E_CUENTA = value;
        }
        public ListFilter<String> E_CUENTAs
        {
          get => datos_PATRIMONIO_INVERSION.E_CUENTAs;
          set => datos_PATRIMONIO_INVERSION.E_CUENTAs = value;
        }

        public StringFilter V_CUENTA_CORTO
        {
          get => datos_PATRIMONIO_INVERSION.V_CUENTA_CORTO;
          set => datos_PATRIMONIO_INVERSION.V_CUENTA_CORTO = value;
        }
        public ListFilter<String> V_CUENTA_CORTOs
        {
          get => datos_PATRIMONIO_INVERSION.V_CUENTA_CORTOs;
          set => datos_PATRIMONIO_INVERSION.V_CUENTA_CORTOs = value;
        }

        public StringFilter V_OTRO
        {
          get => datos_PATRIMONIO_INVERSION.V_OTRO;
          set => datos_PATRIMONIO_INVERSION.V_OTRO = value;
        }
        public ListFilter<String> V_OTROs
        {
          get => datos_PATRIMONIO_INVERSION.V_OTROs;
          set => datos_PATRIMONIO_INVERSION.V_OTROs = value;
        }

        public DecimalFilter M_SALDO
        {
          get => datos_PATRIMONIO_INVERSION.M_SALDO;
          set => datos_PATRIMONIO_INVERSION.M_SALDO = value;
        }
        public ListFilter<Decimal> M_SALDOs
        {
          get => datos_PATRIMONIO_INVERSION.M_SALDOs;
          set => datos_PATRIMONIO_INVERSION.M_SALDOs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_PATRIMONIO_INVERSION.NID_PAIS;
          set => datos_PATRIMONIO_INVERSION.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_PATRIMONIO_INVERSION.NID_PAISs;
          set => datos_PATRIMONIO_INVERSION.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA;
          set => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVAs;
          set => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter V_LUGAR
        {
          get => datos_PATRIMONIO_INVERSION.V_LUGAR;
          set => datos_PATRIMONIO_INVERSION.V_LUGAR = value;
        }
        public ListFilter<String> V_LUGARs
        {
          get => datos_PATRIMONIO_INVERSION.V_LUGARs;
          set => datos_PATRIMONIO_INVERSION.V_LUGARs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_INVERSION.OrderByCriterios; 
            set => datos_PATRIMONIO_INVERSION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_INVERSION() => datos_PATRIMONIO_INVERSION = new dald__l_PATRIMONIO_INVERSION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_INVERSION.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_INVERSION.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_INVERSION.single_select();
        }

     #endregion

    }
}
