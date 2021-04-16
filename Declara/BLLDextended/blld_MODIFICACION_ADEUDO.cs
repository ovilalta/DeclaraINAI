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
    public partial class blld_MODIFICACION_ADEUDO : bll_MODIFICACION_ADEUDO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.NID_PATRIMONIO; }
        //        }


        //        public Decimal M_PAGOS
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.M_PAGOS; }
        //          set { datos_MODIFICACION_ADEUDO.M_PAGOS = value; }
        //        }


        //        public Decimal M_SALDOS
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.M_SALDOS; }
        //          set { datos_MODIFICACION_ADEUDO.M_SALDOS = value; }
        //        }


        //        public Boolean L_CANCELADO
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.L_CANCELADO; }
        //          set { datos_MODIFICACION_ADEUDO.L_CANCELADO = value; }
        //        }


        //        public Boolean L_MODIFICADO
        //        {
        //          get { return datos_MODIFICACION_ADEUDO.L_MODIFICADO; }
        //          set { datos_MODIFICACION_ADEUDO.L_MODIFICADO = value; }
        //        }

        private blld_PATRIMONIO _PATRIMONIO;

        public blld_PATRIMONIO PATRIMONIO
        {
            get
            {
                if (_PATRIMONIO == null)
                    _PATRIMONIO = new blld_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO;
            }
        }


     #endregion


     #region *** Constructores (Extended) ***


     #endregion


     #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_ADEUDO_TITULARs()
        {
                _Reload_MODIFICACION_ADEUDO_TITULARs();
        }

        public void Add_MODIFICACION_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_ADEUDO_TITULARs(NID_DEPENDIENTE, false);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }


        public void update(List<Int32> nID_TITULARs)
        {
            if (nID_TITULARs == null) throw new CustomException("Debe haber al menos un titular");
            if (nID_TITULARs.Count == 0) throw new CustomException("Debe haber al menos un titular");

            List<blld_MODIFICACION_ADEUDO_TITULAR> listAux = new List<blld_MODIFICACION_ADEUDO_TITULAR>();
            foreach (blld_MODIFICACION_ADEUDO_TITULAR o in MODIFICACION_ADEUDO_TITULARs)
            {
                listAux.Add(o);
            }

            foreach (blld_MODIFICACION_ADEUDO_TITULAR select in listAux)
            {
                //if (!nID_TITULARs.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_ADEUDO_TITULARs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in nID_TITULARs)
            {
                Add_MODIFICACION_ADEUDO_TITULARs(nid_Dependiente);
            }
            L_MODIFICADO = true;
            base.update();

        }
        #endregion

    }
}
