using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_USUARIO : _bllSistema
    {

        internal dald__l_USUARIO datos_USUARIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.USUARIO> lista_USUARIO => datos_USUARIO.lista_USUARIOs;

        protected List<MODELDeclara_V2.USUARIO>  base_USUARIOs => datos_USUARIO.base_USUARIOs;

        public StringFilter VID_RFC
        {
            get => datos_USUARIO.VID_RFC;
            set => datos_USUARIO.VID_RFC = value;
        }

        public StringFilter V_NOMBRE_COMPLETO_ESTILO1
        {
            get => datos_USUARIO.V_NOMBRE_COMPLETO_ESTILO1;
            set => datos_USUARIO.V_NOMBRE_COMPLETO_ESTILO1 = value;
        }
        public StringFilter V_NOMBRE_COMPLETO_ESTILO2
        {
            get => datos_USUARIO.V_NOMBRE_COMPLETO_ESTILO2;
            set => datos_USUARIO.V_NOMBRE_COMPLETO_ESTILO2 = value;
        }

        public StringFilter VID_NOMBRE
        {
          get => datos_USUARIO.VID_NOMBRE;
          set => datos_USUARIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_USUARIO.VID_NOMBREs;
          set => datos_USUARIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_USUARIO.VID_FECHA;
          set => datos_USUARIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_USUARIO.VID_FECHAs;
          set => datos_USUARIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_USUARIO.VID_HOMOCLAVE;
          set => datos_USUARIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_USUARIO.VID_HOMOCLAVEs;
          set => datos_USUARIO.VID_HOMOCLAVEs = value;
        }

        public StringFilter V_PASSWORD
        {
          get => datos_USUARIO.V_PASSWORD;
          set => datos_USUARIO.V_PASSWORD = value;
        }
        public ListFilter<String> V_PASSWORDs
        {
          get => datos_USUARIO.V_PASSWORDs;
          set => datos_USUARIO.V_PASSWORDs = value;
        }

        public StringFilter V_NOMBRE
        {
          get => datos_USUARIO.V_NOMBRE;
          set => datos_USUARIO.V_NOMBRE = value;
        }
        public ListFilter<String> V_NOMBREs
        {
          get => datos_USUARIO.V_NOMBREs;
          set => datos_USUARIO.V_NOMBREs = value;
        }

        public StringFilter V_PRIMER_A
        {
          get => datos_USUARIO.V_PRIMER_A;
          set => datos_USUARIO.V_PRIMER_A = value;
        }
        public ListFilter<String> V_PRIMER_As
        {
          get => datos_USUARIO.V_PRIMER_As;
          set => datos_USUARIO.V_PRIMER_As = value;
        }

        public StringFilter V_SEGUNDO_A
        {
          get => datos_USUARIO.V_SEGUNDO_A;
          set => datos_USUARIO.V_SEGUNDO_A = value;
        }
        public ListFilter<String> V_SEGUNDO_As
        {
          get => datos_USUARIO.V_SEGUNDO_As;
          set => datos_USUARIO.V_SEGUNDO_As = value;
        }

        public DateTimeFilter F_NACIMIENTO
        {
          get => datos_USUARIO.F_NACIMIENTO;
          set => datos_USUARIO.F_NACIMIENTO = value;
        }
        public ListFilter<DateTime> F_NACIMIENTOs
        {
          get => datos_USUARIO.F_NACIMIENTOs;
          set => datos_USUARIO.F_NACIMIENTOs = value;
        }

        public StringFilter V_ACUSE
        {
          get => datos_USUARIO.V_ACUSE;
          set => datos_USUARIO.V_ACUSE = value;
        }
        public ListFilter<String> V_ACUSEs
        {
          get => datos_USUARIO.V_ACUSEs;
          set => datos_USUARIO.V_ACUSEs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_USUARIO.L_ACTIVO;
          set => datos_USUARIO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_USUARIO.L_ACTIVOs;
          set => datos_USUARIO.L_ACTIVOs = value;
        }

        public DateTimeFilter F_INGRESO_INSTITUTO
        {
          get => datos_USUARIO.F_INGRESO_INSTITUTO;
          set => datos_USUARIO.F_INGRESO_INSTITUTO = value;
        }
        public ListFilter<DateTime> F_INGRESO_INSTITUTOs
        {
          get => datos_USUARIO.F_INGRESO_INSTITUTOs;
          set => datos_USUARIO.F_INGRESO_INSTITUTOs = value;
        }

        public DateTimeFilter F_REGISTRO
        {
          get => datos_USUARIO.F_REGISTRO;
          set => datos_USUARIO.F_REGISTRO = value;
        }
        public ListFilter<DateTime> F_REGISTROs
        {
          get => datos_USUARIO.F_REGISTROs;
          set => datos_USUARIO.F_REGISTROs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_USUARIO.OrderByCriterios; 
            set => datos_USUARIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_USUARIO() => datos_USUARIO = new dald__l_USUARIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_USUARIO.select();
        }

        public void clearOrderBy()
        {
            datos_USUARIO.clearOrderBy();
        }

        public void Select()
        {
            datos_USUARIO.single_select();
        }

     #endregion

    }
}
