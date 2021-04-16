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
    public partial class blld_ALTA_VEHICULO_ADEUDO : bll_ALTA_VEHICULO_ADEUDO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_VEHICULO
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULO; }
        //        }


        //        public Int32 NID_ADEUDO
        //        {
        //          get { return datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO; }
        //          set { datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_VEHICULO_ADEUDO(string VID_NOMBRE, string VID_FECHA, string VID_HOMOCLAVE, int NID_DECLARACION, int NID_VEHICULO,Int32 NID_PAIS, string cID_ENTIDAD_FEDERATIVA, string v_LUGAR, int nID_INSTITUCION, string v_OTRA, int nID_TIPO_ADEUDO, DateTime f_ADEUDO, decimal m_ORIGINAL, decimal m_SALDO, string e_CUENTA, List<int> nID_TITULARs) 
         :  base()
        {
            blld_ALTA_ADEUDO oAdeudo = new blld_ALTA_ADEUDO( VID_NOMBRE,  VID_FECHA,  VID_HOMOCLAVE,  NID_DECLARACION, NID_PAIS,  cID_ENTIDAD_FEDERATIVA,  v_LUGAR,  nID_INSTITUCION,  v_OTRA,  nID_TIPO_ADEUDO,  f_ADEUDO,  m_ORIGINAL,  m_SALDO,  e_CUENTA, nID_TITULARs, NID_VEHICULO,Convert.ToInt16(2));
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
