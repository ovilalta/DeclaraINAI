using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
// Extended
    public partial class blld_CAT_PUESTO : bll_CAT_PUESTO
    {

        #region *** Atributos (Extended) ***

        //        public Int32 NID_PUESTO
        //        {
        //          get { return datos_CAT_PUESTO.NID_PUESTO; }
        //        }


        //        public String VID_PUESTO
        //        {
        //          get { return datos_CAT_PUESTO.VID_PUESTO; }
        //          set { datos_CAT_PUESTO.VID_PUESTO = value; }
        //        }


        //        public String VID_NIVEL
        //        {
        //          get { return datos_CAT_PUESTO.VID_NIVEL; }
        //          set { datos_CAT_PUESTO.VID_NIVEL = value; }
        //        }


        //        public String V_PUESTO
        //        {
        //          get { return datos_CAT_PUESTO.V_PUESTO; }
        //          set { datos_CAT_PUESTO.V_PUESTO = value; }
        //        }


        //        public Boolean L_ACTIVO
        //        {
        //          get { return datos_CAT_PUESTO.L_ACTIVO; }
        //          set { datos_CAT_PUESTO.L_ACTIVO = value; }
        //        }


        public String V_PUESTO_COMPUESTO => String.Concat(NID_PUESTO," - ",VID_PUESTO, " - ", VID_NIVEL, " - ", V_PUESTO);

     #endregion


        #region *** Constructores (Extended) ***

        public blld_CAT_PUESTO( String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO)
        : base()
        {
            Int32 NID_PUESTO = dald_CAT_PUESTO.nNuevo_NID_PUESTO();
            datos_CAT_PUESTO = new dald_CAT_PUESTO(NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }

        public blld_CAT_PUESTO(String VID_PUESTO, Int32 NID_PUESTO)
      : base()
        {
            blld__l_CAT_PUESTO oBusca = new blld__l_CAT_PUESTO();
            oBusca.VID_PUESTO = new StringFilter(VID_PUESTO);
            oBusca.NID_PUESTO = new IntegerFilter(NID_PUESTO);
            oBusca.L_ACTIVO = true;
            oBusca.select();
            datos_CAT_PUESTO = new dald_CAT_PUESTO(oBusca.lista_CAT_PUESTO.Last().NID_PUESTO);
        }


        #endregion


        #region *** Metodos (Extended) ***

        //public void Reload_DECLARACION_CARGOs()
        //{
        //        _Reload_DECLARACION_CARGOs();
        //}

        //public void Add_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String V_DENOMINACION, Int32 NID_PRIMER_NIVEL, Int32 NID_SEGUNDO_NIVEL, DateTime F_POSESION, DateTime F_INICIO)
        //{
        //    try
        //    {
        //        _Add_DECLARACION_CARGOs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, V_DENOMINACION, NID_PRIMER_NIVEL, NID_SEGUNDO_NIVEL, F_POSESION, F_INICIO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}


     #endregion

    }
}
