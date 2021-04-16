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
    public partial class blld_MODIFICACION_INVERSION : bll_MODIFICACION_INVERSION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_INVERSION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_INVERSION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_INVERSION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_INVERSION.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_INVERSION.NID_PATRIMONIO; }
        //        }


        //        public Decimal M_SALDO_ANTERIOR
        //        {
        //          get { return datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR; }
        //          set { datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR = value; }
        //        }


        public Decimal M_DIFERENCIA
        {
            get => M_SALDO_ANTERIOR - M_SALDO_ACTUAL;  
        }


        //        public Boolean L_CANCELADA
        //        {
        //          get { return datos_MODIFICACION_INVERSION.L_CANCELADA; }
        //          set { datos_MODIFICACION_INVERSION.L_CANCELADA = value; }
        //        }


        //        public Boolean L_MODIFICADA
        //        {
        //          get { return datos_MODIFICACION_INVERSION.L_MODIFICADA; }
        //          set { datos_MODIFICACION_INVERSION.L_MODIFICADA = value; }
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

        public void Reload_MODIFICACION_INVERSION_TITUs()
        {
                _Reload_MODIFICACION_INVERSION_TITUs();
        }

        public void Add_MODIFICACION_INVERSION_TITUs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_INVERSION_TITUs(NID_DEPENDIENTE, false);
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

        public void update(List<Int32> ListDependientes)
        {
            if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            List<blld_MODIFICACION_INVERSION_TITU> listAux = new List<blld_MODIFICACION_INVERSION_TITU>();
            foreach (blld_MODIFICACION_INVERSION_TITU o in MODIFICACION_INVERSION_TITUs)
            {
                listAux.Add(o);
            }

            foreach (blld_MODIFICACION_INVERSION_TITU select in listAux)
            {
                //if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_INVERSION_TITUs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in ListDependientes)
            {

                Add_MODIFICACION_INVERSION_TITUs(nid_Dependiente);

            }
            L_MODIFICADA = true;
            base.update();

        }
        #endregion

    }
}
