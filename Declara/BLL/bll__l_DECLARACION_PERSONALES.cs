using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_PERSONALES : _bllSistema
    {

        internal dald__l_DECLARACION_PERSONALES datos_DECLARACION_PERSONALES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_PERSONALES> lista_DECLARACION_PERSONALES => datos_DECLARACION_PERSONALES.lista_DECLARACION_PERSONALESs;

        protected List<MODELDeclara_V2.DECLARACION_PERSONALES>  base_DECLARACION_PERSONALESs => datos_DECLARACION_PERSONALES.base_DECLARACION_PERSONALESs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_PERSONALES.VID_NOMBRE;
          set => datos_DECLARACION_PERSONALES.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_PERSONALES.VID_NOMBREs;
          set => datos_DECLARACION_PERSONALES.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_PERSONALES.VID_FECHA;
          set => datos_DECLARACION_PERSONALES.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_PERSONALES.VID_FECHAs;
          set => datos_DECLARACION_PERSONALES.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_PERSONALES.VID_HOMOCLAVE;
          set => datos_DECLARACION_PERSONALES.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_PERSONALES.VID_HOMOCLAVEs;
          set => datos_DECLARACION_PERSONALES.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_PERSONALES.NID_DECLARACION;
          set => datos_DECLARACION_PERSONALES.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_PERSONALES.NID_DECLARACIONs;
          set => datos_DECLARACION_PERSONALES.NID_DECLARACIONs = value;
        }

        public StringFilter C_GENERO
        {
          get => datos_DECLARACION_PERSONALES.C_GENERO;
          set => datos_DECLARACION_PERSONALES.C_GENERO = value;
        }
        public ListFilter<String> C_GENEROs
        {
          get => datos_DECLARACION_PERSONALES.C_GENEROs;
          set => datos_DECLARACION_PERSONALES.C_GENEROs = value;
        }

        public StringFilter C_CURP
        {
          get => datos_DECLARACION_PERSONALES.C_CURP;
          set => datos_DECLARACION_PERSONALES.C_CURP = value;
        }
        public ListFilter<String> C_CURPs
        {
          get => datos_DECLARACION_PERSONALES.C_CURPs;
          set => datos_DECLARACION_PERSONALES.C_CURPs = value;
        }

        public IntegerFilter NID_PAIS
        {
          get => datos_DECLARACION_PERSONALES.NID_PAIS;
          set => datos_DECLARACION_PERSONALES.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_DECLARACION_PERSONALES.NID_PAISs;
          set => datos_DECLARACION_PERSONALES.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
          get => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA;
          set => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
          get => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVAs;
          set => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public IntegerFilter NID_NACIONALIDAD
        {
          get => datos_DECLARACION_PERSONALES.NID_NACIONALIDAD;
          set => datos_DECLARACION_PERSONALES.NID_NACIONALIDAD = value;
        }
        public ListFilter<Int32> NID_NACIONALIDADs
        {
          get => datos_DECLARACION_PERSONALES.NID_NACIONALIDADs;
          set => datos_DECLARACION_PERSONALES.NID_NACIONALIDADs = value;
        }

        public IntegerFilter NID_ESTADO_CIVIL
        {
          get => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVIL;
          set => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVIL = value;
        }
        public ListFilter<Int32> NID_ESTADO_CIVILs
        {
          get => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVILs;
          set => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVILs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_PERSONALES.OrderByCriterios; 
            set => datos_DECLARACION_PERSONALES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_PERSONALES() => datos_DECLARACION_PERSONALES = new dald__l_DECLARACION_PERSONALES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_PERSONALES.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_PERSONALES.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_PERSONALES.single_select();
        }

     #endregion

    }
}
