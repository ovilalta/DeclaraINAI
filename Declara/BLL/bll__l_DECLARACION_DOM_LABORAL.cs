using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_DOM_LABORAL : _bllSistema
    {

        internal dald__l_DECLARACION_DOM_LABORAL datos_DECLARACION_DOM_LABORAL;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL> lista_DECLARACION_DOM_LABORAL => datos_DECLARACION_DOM_LABORAL.lista_DECLARACION_DOM_LABORALs;

        protected List<MODELDeclara_V2.DECLARACION_DOM_LABORAL>  base_DECLARACION_DOM_LABORALs => datos_DECLARACION_DOM_LABORAL.base_DECLARACION_DOM_LABORALs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_NOMBRE;
          set => datos_DECLARACION_DOM_LABORAL.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_NOMBREs;
          set => datos_DECLARACION_DOM_LABORAL.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_FECHA;
          set => datos_DECLARACION_DOM_LABORAL.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_FECHAs;
          set => datos_DECLARACION_DOM_LABORAL.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVE;
          set => datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVEs;
          set => datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_DOM_LABORAL.NID_DECLARACION;
          set => datos_DECLARACION_DOM_LABORAL.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_DOM_LABORAL.NID_DECLARACIONs;
          set => datos_DECLARACION_DOM_LABORAL.NID_DECLARACIONs = value;
        }

        public StringFilter C_CODIGO_POSTAL
        {
          get => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
          set => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = value;
        }
        public ListFilter<String> C_CODIGO_POSTALs
        {
          get => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTALs;
          set => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTALs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_DECLARACION_DOM_LABORAL.NID_PAIS;
          set => datos_DECLARACION_DOM_LABORAL.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_DECLARACION_DOM_LABORAL.NID_PAISs;
          set => datos_DECLARACION_DOM_LABORAL.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
          set => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVAs;
          set => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
          set => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIOs;
          set => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIOs = value;
        }

        public StringFilter V_COLONIA
        {
          get => datos_DECLARACION_DOM_LABORAL.V_COLONIA;
          set => datos_DECLARACION_DOM_LABORAL.V_COLONIA = value;
        }
        public ListFilter<String> V_COLONIAs
        {
          get => datos_DECLARACION_DOM_LABORAL.V_COLONIAs;
          set => datos_DECLARACION_DOM_LABORAL.V_COLONIAs = value;
        }

        public StringFilter V_DOMICILIO
        {
          get => datos_DECLARACION_DOM_LABORAL.V_DOMICILIO;
          set => datos_DECLARACION_DOM_LABORAL.V_DOMICILIO = value;
        }
        public ListFilter<String> V_DOMICILIOs
        {
          get => datos_DECLARACION_DOM_LABORAL.V_DOMICILIOs;
          set => datos_DECLARACION_DOM_LABORAL.V_DOMICILIOs = value;
        }

        public StringFilter V_CORREO_LABORAL
        {
          get => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;
          set => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = value;
        }
        public ListFilter<String> V_CORREO_LABORALs
        {
          get => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORALs;
          set => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORALs = value;
        }

        public StringFilter V_TEL_LABORAL
        {
          get => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL;
          set => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL = value;
        }
        public ListFilter<String> V_TEL_LABORALs
        {
          get => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORALs;
          set => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORALs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_DOM_LABORAL.OrderByCriterios; 
            set => datos_DECLARACION_DOM_LABORAL.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_DOM_LABORAL() => datos_DECLARACION_DOM_LABORAL = new dald__l_DECLARACION_DOM_LABORAL();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_DOM_LABORAL.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_DOM_LABORAL.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_DOM_LABORAL.single_select();
        }

     #endregion

    }
}
