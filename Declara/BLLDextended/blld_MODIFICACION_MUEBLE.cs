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
    public partial class blld_MODIFICACION_MUEBLE : bll_MODIFICACION_MUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.NID_DECLARACION; }
        //        }

        //        public Int32 NID_MUEBLE
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.NID_MUEBLE; }
        //        }


        //        public Int32 NID_TIPO
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.NID_TIPO; }
        //          set { datos_MODIFICACION_MUEBLE.NID_TIPO = value; }
        //        }


        new public String E_ESPECIFICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_MUEBLE.E_ESPECIFICACION))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_MUEBLE.E_ESPECIFICACION);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_MODIFICACION_MUEBLE.E_ESPECIFICACION = String.Empty;
                else
                datos_MODIFICACION_MUEBLE.E_ESPECIFICACION = Encripta(value);
            }
        }


        //        public Int64 M_VALOR
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.M_VALOR; }
        //          set { datos_MODIFICACION_MUEBLE.M_VALOR = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_MUEBLE.NID_PATRIMONIO; }
        //          set { datos_MODIFICACION_MUEBLE.NID_PATRIMONIO = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION,  Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR, Boolean L_MODIFICADO,DateTime F_ADQUISICION)
        : base()
        {
            Int32 NID_MUEBLE = dald_MODIFICACION_MUEBLE.nNuevo_NID_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            datos_MODIFICACION_MUEBLE = new dald_MODIFICACION_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_TIPO, E_ESPECIFICACION, M_VALOR, L_MODIFICADO,F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_MUEBLE_TITULARs()
        {
                _Reload_MODIFICACION_MUEBLE_TITULARs();
        }

        public void Add_MODIFICACION_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_MUEBLE_TITULARs(NID_DEPENDIENTE, true);
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
            
            List<blld_MODIFICACION_MUEBLE_TITULAR> listAux = new List<blld_MODIFICACION_MUEBLE_TITULAR>();
            foreach (blld_MODIFICACION_MUEBLE_TITULAR o in MODIFICACION_MUEBLE_TITULARs)
            {
                listAux.Add(o);
            }
            foreach (blld_MODIFICACION_MUEBLE_TITULAR select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_MUEBLE_TITULARs.Remove(select);
            }
            foreach (Int32 nid_Dependientes in ListDependientes)
            {
                Add_MODIFICACION_MUEBLE_TITULARs(nid_Dependientes);
            }
            datos_MODIFICACION_MUEBLE.L_MODIFICADO = true;
            datos_MODIFICACION_MUEBLE.update();
        }

        #endregion

    }
}
