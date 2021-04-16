using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_DOM_PARTICULAR : _bllSistema
    {

        internal dald__l_DECLARACION_DOM_PARTICULAR datos_DECLARACION_DOM_PARTICULAR;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_DOM_PARTICULAR> lista_DECLARACION_DOM_PARTICULAR => datos_DECLARACION_DOM_PARTICULAR.lista_DECLARACION_DOM_PARTICULARs;

        protected List<MODELDeclara_V2.DECLARACION_DOM_PARTICULAR>  base_DECLARACION_DOM_PARTICULARs => datos_DECLARACION_DOM_PARTICULAR.base_DECLARACION_DOM_PARTICULARs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_NOMBRE;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_NOMBREs;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_FECHA;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_FECHAs;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVE;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVEs;
          set => datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACION;
          set => datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACIONs;
          set => datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACIONs = value;
        }

        public StringFilter C_CODIGO_POSTAL
        {
          get => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL;
          set => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL = value;
        }
        public ListFilter<String> C_CODIGO_POSTALs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTALs;
          set => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTALs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_DECLARACION_DOM_PARTICULAR.NID_PAIS;
          set => datos_DECLARACION_DOM_PARTICULAR.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.NID_PAISs;
          set => datos_DECLARACION_DOM_PARTICULAR.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
          set => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVAs;
          set => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
          get => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
          set => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIOs;
          set => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIOs = value;
        }

        public StringFilter V_COLONIA
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_COLONIA;
          set => datos_DECLARACION_DOM_PARTICULAR.V_COLONIA = value;
        }
        public ListFilter<String> V_COLONIAs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_COLONIAs;
          set => datos_DECLARACION_DOM_PARTICULAR.V_COLONIAs = value;
        }

        public StringFilter V_DOMICILIO
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO;
          set => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO = value;
        }
        public ListFilter<String> V_DOMICILIOs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIOs;
          set => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIOs = value;
        }

        public StringFilter V_CORREO
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_CORREO;
          set => datos_DECLARACION_DOM_PARTICULAR.V_CORREO = value;
        }
        public ListFilter<String> V_CORREOs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_CORREOs;
          set => datos_DECLARACION_DOM_PARTICULAR.V_CORREOs = value;
        }

        public StringFilter V_TEL_PARTICULAR
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
          set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = value;
        }
        public ListFilter<String> V_TEL_PARTICULARs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULARs;
          set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULARs = value;
        }

        public StringFilter V_TEL_CELULAR
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
          set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = value;
        }
        public ListFilter<String> V_TEL_CELULARs
        {
          get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULARs;
          set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULARs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_DOM_PARTICULAR.OrderByCriterios; 
            set => datos_DECLARACION_DOM_PARTICULAR.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_DOM_PARTICULAR() => datos_DECLARACION_DOM_PARTICULAR = new dald__l_DECLARACION_DOM_PARTICULAR();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_DOM_PARTICULAR.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_DOM_PARTICULAR.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_DOM_PARTICULAR.single_select();
        }

     #endregion

    }
}
