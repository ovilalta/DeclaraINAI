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
    public partial class blld_USUARIO_DOMICILIO : bll_USUARIO_DOMICILIO
    {

     #region *** Atributos (Extended) ***

//        public String VID_NOMBRE
//        {
//          get { return datos_USUARIO_DOMICILIO.VID_NOMBRE; }
//        }

//        public String VID_FECHA
//        {
//          get { return datos_USUARIO_DOMICILIO.VID_FECHA; }
//        }

//        public String VID_HOMOCLAVE
//        {
//          get { return datos_USUARIO_DOMICILIO.VID_HOMOCLAVE; }
//        }

//        public Int32 NID_DOMICILIO
//        {
//          get { return datos_USUARIO_DOMICILIO.NID_DOMICILIO; }
//        }


//        public Int32 NID_PAIS
//        {
//          get { return datos_USUARIO_DOMICILIO.NID_PAIS; }
//          set { datos_USUARIO_DOMICILIO.NID_PAIS = value; }
//        }


//        public String CID_ENTIDAD_FEDERATIVA
//        {
//          get { return datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA; }
//          set { datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA = value; }
//        }


//        public String CID_MUNICIPIO
//        {
//          get { return datos_USUARIO_DOMICILIO.CID_MUNICIPIO; }
//          set { datos_USUARIO_DOMICILIO.CID_MUNICIPIO = value; }
//        }


//        public String C_CODIGO_POSTAL
//        {
//          get { return datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL; }
//          set { datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL = value; }
//        }


//        public String E_DIRECCION
//        {
//          get { return datos_USUARIO_DOMICILIO.E_DIRECCION; }
//          set { datos_USUARIO_DOMICILIO.E_DIRECCION = value; }
//        }


//        public Int32 NID_TIPO_DOMICILIO
//        {
//          get { return datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO; }
//          set { datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO = value; }
//        }


//        public Boolean L_ACTIVO
//        {
//          get { return datos_USUARIO_DOMICILIO.L_ACTIVO; }
//          set { datos_USUARIO_DOMICILIO.L_ACTIVO = value; }
//        }


     #endregion


     #region *** Constructores (Extended) ***

        public blld_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE,  Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO)
        : base()
        {
            Int32 NID_DOMICILIO = dald_USUARIO_DOMICILIO.nNuevo_NID_DOMICILIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            datos_USUARIO_DOMICILIO = new dald_USUARIO_DOMICILIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***


     #endregion

    }
}
