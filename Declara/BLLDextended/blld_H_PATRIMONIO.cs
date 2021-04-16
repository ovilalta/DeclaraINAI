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
    public partial class blld_H_PATRIMONIO : bll_H_PATRIMONIO
    {

     #region *** Atributos (Extended) ***

//        public String VID_NOMBRE
//        {
//          get { return datos_H_PATRIMONIO.VID_NOMBRE; }
//        }

//        public String VID_FECHA
//        {
//          get { return datos_H_PATRIMONIO.VID_FECHA; }
//        }

//        public String VID_HOMOCLAVE
//        {
//          get { return datos_H_PATRIMONIO.VID_HOMOCLAVE; }
//        }

//        public Int32 NID_PATRIMONIO
//        {
//          get { return datos_H_PATRIMONIO.NID_PATRIMONIO; }
//        }

//        public Int32 NID_HISTORICO
//        {
//          get { return datos_H_PATRIMONIO.NID_HISTORICO; }
//        }


//        public Int32 NID_TIPO
//        {
//          get { return datos_H_PATRIMONIO.NID_TIPO; }
//          set { datos_H_PATRIMONIO.NID_TIPO = value; }
//        }


//        public Decimal M_VALOR
//        {
//          get { return datos_H_PATRIMONIO.M_VALOR; }
//          set { datos_H_PATRIMONIO.M_VALOR = value; }
//        }


//        public Int32 NID_DEC_INCOR
//        {
//          get { return datos_H_PATRIMONIO.NID_DEC_INCOR; }
//          set { datos_H_PATRIMONIO.NID_DEC_INCOR = value; }
//        }


//        public DateTime F_INCORPORACION
//        {
//          get { return datos_H_PATRIMONIO.F_INCORPORACION; }
//          set { datos_H_PATRIMONIO.F_INCORPORACION = value; }
//        }


//        public Int32 NID_DEC_ULT_MOD
//        {
//          get { return datos_H_PATRIMONIO.NID_DEC_ULT_MOD; }
//          set { datos_H_PATRIMONIO.NID_DEC_ULT_MOD = value; }
//        }


//        public DateTime F_MODIFICACION
//        {
//          get { return datos_H_PATRIMONIO.F_MODIFICACION; }
//          set { datos_H_PATRIMONIO.F_MODIFICACION = value; }
//        }


//        public Boolean L_ACTIVO
//        {
//          get { return datos_H_PATRIMONIO.L_ACTIVO; }
//          set { datos_H_PATRIMONIO.L_ACTIVO = value; }
//        }


//        public DateTime F_REGISTRO
//        {
//          get { return datos_H_PATRIMONIO.F_REGISTRO; }
//        }


     #endregion


     #region *** Constructores (Extended) ***

        public blld_H_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO,  Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO)
        : base()
        {
            Int32 NID_HISTORICO = dald_H_PATRIMONIO.nNuevo_NID_HISTORICO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
            datos_H_PATRIMONIO = new dald_H_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***

        public void Add_H_PATRIMONIO_VEHICULO(Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO)
        {
            try
            {
                _Add_H_PATRIMONIO_VEHICULO(NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO);
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
        public void Add_H_PATRIMONIO_ADEUDO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_INSTITUCION, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA)
        {
            try
            {
                _Add_H_PATRIMONIO_ADEUDO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_INSTITUCION, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA);
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
        public void Reload_H_PATRIMONIO_TITULARs()
        {
                _Reload_H_PATRIMONIO_TITULARs();
        }

        public void Add_H_PATRIMONIO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
            try
            {
                _Add_H_PATRIMONIO_TITULARs(NID_DEPENDIENTE, L_DIF);
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

        public void Add_H_PATRIMONIO_MUEBLE(Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR)
        {
            try
            {
                _Add_H_PATRIMONIO_MUEBLE(NID_TIPO, E_ESPECIFICACION, M_VALOR);
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
        public void Add_H_PATRIMONIO_INMUEBLE(Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        {
            try
            {
                _Add_H_PATRIMONIO_INMUEBLE(NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE);
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
        public void Add_H_PATRIMONIO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR)
        {
            try
            {
                _Add_H_PATRIMONIO_INVERSION(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR);
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

     #endregion

    }
}
