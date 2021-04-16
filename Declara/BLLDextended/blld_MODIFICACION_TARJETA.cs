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
    public partial class blld_MODIFICACION_TARJETA : bll_MODIFICACION_TARJETA
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_TARJETA.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_TARJETA.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_TARJETA.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_TARJETA.NID_DECLARACION; }
        //        }

        new public String E_NUMERO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_TARJETA.E_NUMERO))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_TARJETA.E_NUMERO);
            }
        }


        //new public String V_NUMERO_CORTO => E_NUMERO;
        new public String V_NUMERO_CORTO => String.Concat('*', String.Concat("00000", E_NUMERO).Substring((E_NUMERO.Length + 1), 4));


        //        public Decimal M_PAGOS
        //        {
        //          get { return datos_MODIFICACION_TARJETA.M_PAGOS; }
        //          set { datos_MODIFICACION_TARJETA.M_PAGOS = value; }
        //        }


        //        public Decimal M_GASTOS
        //        {
        //          get { return datos_MODIFICACION_TARJETA.M_GASTOS; }
        //          set { datos_MODIFICACION_TARJETA.M_GASTOS = value; }
        //        }


        //        public String E_NUMERO_ASOCIACION
        //        {
        //          get { return datos_MODIFICACION_TARJETA.E_NUMERO_ASOCIACION; }
        //          set { datos_MODIFICACION_TARJETA.E_NUMERO_ASOCIACION = value; }
        //        }


        //        public Boolean L_ACTIVA
        //        {
        //          get { return datos_MODIFICACION_TARJETA.L_ACTIVA; }
        //          set { datos_MODIFICACION_TARJETA.L_ACTIVA = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_SALDO, Boolean L_ACTIVA, List<Int32> ListDependientes)
        :base()
        {

            if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            if (String.IsNullOrEmpty(E_NUMERO))
                throw new CustomException("El número de tarjeta no puede ser vacío");

            E_NUMERO = Encripta(E_NUMERO);

            E_NUMERO_ASOCIACION = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE).ToString();

            datos_MODIFICACION_TARJETA = new dald_MODIFICACION_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_SALDO, E_NUMERO_ASOCIACION, L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);

            foreach (Int32 nid_Dependiente in ListDependientes)
            {
                Add_MODIFICACION_TARJETA_TITUs(nid_Dependiente);
            }
        }

        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_TARJETA_TITUs()
        {
            _Reload_MODIFICACION_TARJETA_TITUs();
        }

        public void Add_MODIFICACION_TARJETA_TITUs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_TARJETA_TITUs(NID_DEPENDIENTE, true);
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

        new private void update()
        {
            datos_MODIFICACION_TARJETA.update();
        }

        public void update(List<Int32> ListDependientes)
        {
            if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            List<blld_MODIFICACION_TARJETA_TITU> listAux = new List<blld_MODIFICACION_TARJETA_TITU>();
            foreach (blld_MODIFICACION_TARJETA_TITU o in MODIFICACION_TARJETA_TITUs)
            {
                listAux.Add(o);
            }

            foreach (blld_MODIFICACION_TARJETA_TITU select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_TARJETA_TITUs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in ListDependientes)
            {
                Add_MODIFICACION_TARJETA_TITUs(nid_Dependiente);
            }

            datos_MODIFICACION_TARJETA.update();
        }

        #endregion

    }
}
