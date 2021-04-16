using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_USUARIO_DOMICILIO : _bllSistema
    {

        internal dald__l_USUARIO_DOMICILIO datos_USUARIO_DOMICILIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.USUARIO_DOMICILIO> lista_USUARIO_DOMICILIO => datos_USUARIO_DOMICILIO.lista_USUARIO_DOMICILIOs;

        protected List<MODELDeclara_V2.USUARIO_DOMICILIO>  base_USUARIO_DOMICILIOs => datos_USUARIO_DOMICILIO.base_USUARIO_DOMICILIOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_USUARIO_DOMICILIO.VID_NOMBRE;
          set => datos_USUARIO_DOMICILIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_USUARIO_DOMICILIO.VID_NOMBREs;
          set => datos_USUARIO_DOMICILIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_USUARIO_DOMICILIO.VID_FECHA;
          set => datos_USUARIO_DOMICILIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_USUARIO_DOMICILIO.VID_FECHAs;
          set => datos_USUARIO_DOMICILIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_USUARIO_DOMICILIO.VID_HOMOCLAVE;
          set => datos_USUARIO_DOMICILIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_USUARIO_DOMICILIO.VID_HOMOCLAVEs;
          set => datos_USUARIO_DOMICILIO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DOMICILIO
        {
          get => datos_USUARIO_DOMICILIO.NID_DOMICILIO;
          set => datos_USUARIO_DOMICILIO.NID_DOMICILIO = value;
        }
        public ListFilter<Int32> NID_DOMICILIOs
        {
          get => datos_USUARIO_DOMICILIO.NID_DOMICILIOs;
          set => datos_USUARIO_DOMICILIO.NID_DOMICILIOs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_USUARIO_DOMICILIO.NID_PAIS;
          set => datos_USUARIO_DOMICILIO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_USUARIO_DOMICILIO.NID_PAISs;
          set => datos_USUARIO_DOMICILIO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA;
          set => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVAs;
          set => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
          get => datos_USUARIO_DOMICILIO.CID_MUNICIPIO;
          set => datos_USUARIO_DOMICILIO.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
          get => datos_USUARIO_DOMICILIO.CID_MUNICIPIOs;
          set => datos_USUARIO_DOMICILIO.CID_MUNICIPIOs = value;
        }

        public StringFilter C_CODIGO_POSTAL
        {
          get => datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL;
          set => datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL = value;
        }
        public ListFilter<String> C_CODIGO_POSTALs
        {
          get => datos_USUARIO_DOMICILIO.C_CODIGO_POSTALs;
          set => datos_USUARIO_DOMICILIO.C_CODIGO_POSTALs = value;
        }

        public StringFilter E_DIRECCION
        {
          get => datos_USUARIO_DOMICILIO.E_DIRECCION;
          set => datos_USUARIO_DOMICILIO.E_DIRECCION = value;
        }
        public ListFilter<String> E_DIRECCIONs
        {
          get => datos_USUARIO_DOMICILIO.E_DIRECCIONs;
          set => datos_USUARIO_DOMICILIO.E_DIRECCIONs = value;
        }

        public IntegerFilter NID_TIPO_DOMICILIO
        {
          get => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO;
          set => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO = value;
        }
        public ListFilter<Int32> NID_TIPO_DOMICILIOs
        {
          get => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIOs;
          set => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_USUARIO_DOMICILIO.L_ACTIVO;
          set => datos_USUARIO_DOMICILIO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_USUARIO_DOMICILIO.L_ACTIVOs;
          set => datos_USUARIO_DOMICILIO.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_USUARIO_DOMICILIO.OrderByCriterios; 
            set => datos_USUARIO_DOMICILIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_USUARIO_DOMICILIO() => datos_USUARIO_DOMICILIO = new dald__l_USUARIO_DOMICILIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_USUARIO_DOMICILIO.select();
        }

        public void clearOrderBy()
        {
            datos_USUARIO_DOMICILIO.clearOrderBy();
        }

        public void Select()
        {
            datos_USUARIO_DOMICILIO.single_select();
        }

     #endregion

    }
}
