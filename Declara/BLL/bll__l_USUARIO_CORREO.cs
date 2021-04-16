using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_USUARIO_CORREO : _bllSistema
    {

        internal dald__l_USUARIO_CORREO datos_USUARIO_CORREO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.USUARIO_CORREO> lista_USUARIO_CORREO => datos_USUARIO_CORREO.lista_USUARIO_CORREOs;

        protected List<MODELDeclara_V2.USUARIO_CORREO>  base_USUARIO_CORREOs => datos_USUARIO_CORREO.base_USUARIO_CORREOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_USUARIO_CORREO.VID_NOMBRE;
          set => datos_USUARIO_CORREO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_USUARIO_CORREO.VID_NOMBREs;
          set => datos_USUARIO_CORREO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_USUARIO_CORREO.VID_FECHA;
          set => datos_USUARIO_CORREO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_USUARIO_CORREO.VID_FECHAs;
          set => datos_USUARIO_CORREO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_USUARIO_CORREO.VID_HOMOCLAVE;
          set => datos_USUARIO_CORREO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_USUARIO_CORREO.VID_HOMOCLAVEs;
          set => datos_USUARIO_CORREO.VID_HOMOCLAVEs = value;
        }

        public StringFilter V_CORREO
        {
          get => datos_USUARIO_CORREO.V_CORREO;
          set => datos_USUARIO_CORREO.V_CORREO = value;
        }
        public ListFilter<String> V_CORREOs
        {
          get => datos_USUARIO_CORREO.V_CORREOs;
          set => datos_USUARIO_CORREO.V_CORREOs = value;
        }

        public System.Nullable<Boolean> L_PRINCIPAL
        {
          get => datos_USUARIO_CORREO.L_PRINCIPAL;
          set => datos_USUARIO_CORREO.L_PRINCIPAL = value;
        }
        public ListFilter<Boolean> L_PRINCIPALs
        {
          get => datos_USUARIO_CORREO.L_PRINCIPALs;
          set => datos_USUARIO_CORREO.L_PRINCIPALs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_USUARIO_CORREO.L_ACTIVO;
          set => datos_USUARIO_CORREO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_USUARIO_CORREO.L_ACTIVOs;
          set => datos_USUARIO_CORREO.L_ACTIVOs = value;
        }

        public System.Nullable<Boolean> L_CONFIRMADO
        {
          get => datos_USUARIO_CORREO.L_CONFIRMADO;
          set => datos_USUARIO_CORREO.L_CONFIRMADO = value;
        }
        public ListFilter<Boolean> L_CONFIRMADOs
        {
          get => datos_USUARIO_CORREO.L_CONFIRMADOs;
          set => datos_USUARIO_CORREO.L_CONFIRMADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_USUARIO_CORREO.OrderByCriterios; 
            set => datos_USUARIO_CORREO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_USUARIO_CORREO() => datos_USUARIO_CORREO = new dald__l_USUARIO_CORREO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_USUARIO_CORREO.select();
        }

        public void clearOrderBy()
        {
            datos_USUARIO_CORREO.clearOrderBy();
        }

        public void Select()
        {
            datos_USUARIO_CORREO.single_select();
        }

     #endregion

    }
}
