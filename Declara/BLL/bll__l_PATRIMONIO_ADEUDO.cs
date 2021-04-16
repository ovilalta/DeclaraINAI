using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_ADEUDO : _bllSistema
    {

        internal dald__l_PATRIMONIO_ADEUDO datos_PATRIMONIO_ADEUDO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_ADEUDO> lista_PATRIMONIO_ADEUDO => datos_PATRIMONIO_ADEUDO.lista_PATRIMONIO_ADEUDOs;

        protected List<MODELDeclara_V2.PATRIMONIO_ADEUDO>  base_PATRIMONIO_ADEUDOs => datos_PATRIMONIO_ADEUDO.base_PATRIMONIO_ADEUDOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_ADEUDO.VID_NOMBRE;
          set => datos_PATRIMONIO_ADEUDO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_ADEUDO.VID_NOMBREs;
          set => datos_PATRIMONIO_ADEUDO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_ADEUDO.VID_FECHA;
          set => datos_PATRIMONIO_ADEUDO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_ADEUDO.VID_FECHAs;
          set => datos_PATRIMONIO_ADEUDO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_PATRIMONIO_ADEUDO.NID_PATRIMONIO;
          set => datos_PATRIMONIO_ADEUDO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_PATRIMONIO_ADEUDO.NID_PATRIMONIOs;
          set => datos_PATRIMONIO_ADEUDO.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_PATRIMONIO_ADEUDO.NID_PAIS;
          set => datos_PATRIMONIO_ADEUDO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_PATRIMONIO_ADEUDO.NID_PAISs;
          set => datos_PATRIMONIO_ADEUDO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA;
          set => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVAs;
          set => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter V_LUGAR
        {
          get => datos_PATRIMONIO_ADEUDO.V_LUGAR;
          set => datos_PATRIMONIO_ADEUDO.V_LUGAR = value;
        }
        public ListFilter<String> V_LUGARs
        {
          get => datos_PATRIMONIO_ADEUDO.V_LUGARs;
          set => datos_PATRIMONIO_ADEUDO.V_LUGARs = value;
        }

        public IntegerFilter NID_INSTITUCION
        {
          get => datos_PATRIMONIO_ADEUDO.NID_INSTITUCION;
          set => datos_PATRIMONIO_ADEUDO.NID_INSTITUCION = value;
        }
        public ListFilter<Int32> NID_INSTITUCIONs
        {
          get => datos_PATRIMONIO_ADEUDO.NID_INSTITUCIONs;
          set => datos_PATRIMONIO_ADEUDO.NID_INSTITUCIONs = value;
        }

        public StringFilter V_OTRA
        {
          get => datos_PATRIMONIO_ADEUDO.V_OTRA;
          set => datos_PATRIMONIO_ADEUDO.V_OTRA = value;
        }
        public ListFilter<String> V_OTRAs
        {
          get => datos_PATRIMONIO_ADEUDO.V_OTRAs;
          set => datos_PATRIMONIO_ADEUDO.V_OTRAs = value;
        }

        public IntegerFilter NID_TIPO_ADEUDO
        {
          get => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO;
          set => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO = value;
        }
        public ListFilter<Int32> NID_TIPO_ADEUDOs
        {
          get => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDOs;
          set => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDOs = value;
        }

        public DecimalFilter M_ORIGINAL
        {
          get => datos_PATRIMONIO_ADEUDO.M_ORIGINAL;
          set => datos_PATRIMONIO_ADEUDO.M_ORIGINAL = value;
        }
        public ListFilter<Decimal> M_ORIGINALs
        {
          get => datos_PATRIMONIO_ADEUDO.M_ORIGINALs;
          set => datos_PATRIMONIO_ADEUDO.M_ORIGINALs = value;
        }

        public DecimalFilter M_SALDO
        {
          get => datos_PATRIMONIO_ADEUDO.M_SALDO;
          set => datos_PATRIMONIO_ADEUDO.M_SALDO = value;
        }
        public ListFilter<Decimal> M_SALDOs
        {
          get => datos_PATRIMONIO_ADEUDO.M_SALDOs;
          set => datos_PATRIMONIO_ADEUDO.M_SALDOs = value;
        }

        public StringFilter E_CUENTA
        {
          get => datos_PATRIMONIO_ADEUDO.E_CUENTA;
          set => datos_PATRIMONIO_ADEUDO.E_CUENTA = value;
        }
        public ListFilter<String> E_CUENTAs
        {
          get => datos_PATRIMONIO_ADEUDO.E_CUENTAs;
          set => datos_PATRIMONIO_ADEUDO.E_CUENTAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_ADEUDO.OrderByCriterios; 
            set => datos_PATRIMONIO_ADEUDO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_ADEUDO() => datos_PATRIMONIO_ADEUDO = new dald__l_PATRIMONIO_ADEUDO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_ADEUDO.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_ADEUDO.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_ADEUDO.single_select();
        }

     #endregion

    }
}
