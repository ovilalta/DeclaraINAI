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
    public partial class blld_MODIFICACION_VEHICULO : bll_MODIFICACION_VEHICULO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_VEHICULO
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_VEHICULO; }
        //        }


        //        public Int32 NID_MARCA
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_MARCA; }
        //          set { datos_MODIFICACION_VEHICULO.NID_MARCA = value; }
        //        }


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M O D E L O es requerido ")]
        [DisplayName("M O D E L O")]
        new public String C_MODELO
        {
            get => datos_MODIFICACION_VEHICULO.C_MODELO;
            set
            {
                if ((Convert.ToInt32(value)) > (F_ADQUISICION.Year + 2))
                    throw new CustomException("El modelo no puede ser mayor a la fecha de adquisicion");
                datos_MODIFICACION_VEHICULO.C_MODELO = value;
            }
        }


        //        public String V_DESCRIPCION
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.V_DESCRIPCION; }
        //          set { datos_MODIFICACION_VEHICULO.V_DESCRIPCION = value; }
        //        }


        //        public DateTime F_ADQUISICION
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.F_ADQUISICION; }
        //          set { datos_MODIFICACION_VEHICULO.F_ADQUISICION = value; }
        //        }


        //        public Int32 NID_TIPO_COMPRA
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_TIPO_COMPRA; }
        //          set { datos_MODIFICACION_VEHICULO.NID_TIPO_COMPRA = value; }
        //        }


        //        public Int32 NID_USO
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_USO; }
        //          set { datos_MODIFICACION_VEHICULO.NID_USO = value; }
        //        }


        //        public Decimal M_VALOR_VEHICULO
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.M_VALOR_VEHICULO; }
        //          set { datos_MODIFICACION_VEHICULO.M_VALOR_VEHICULO = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_VEHICULO.NID_PATRIMONIO; }
        //          set { datos_MODIFICACION_VEHICULO.NID_PATRIMONIO = value; }
        //        }

   

        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION,  Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_TIPO_COMPRA, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Int32 NID_PATRIMONIO)
        : base()
        {
        //    Int32 NID_VEHICULO = dald_MODIFICACION_VEHICULO.nNuevo_NID_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
        //    datos_MODIFICACION_VEHICULO = new dald_MODIFICACION_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_TIPO_COMPRA, NID_USO, M_VALOR_VEHICULO, NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_VEHICULO_TITUs()
        {
                _Reload_MODIFICACION_VEHICULO_TITUs();
        }

        public void Add_MODIFICACION_VEHICULO_TITUs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_VEHICULO_TITUs(NID_DEPENDIENTE, true);
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

            List<blld_MODIFICACION_VEHICULO_TITU > listAux = new List<blld_MODIFICACION_VEHICULO_TITU>();
            foreach (blld_MODIFICACION_VEHICULO_TITU o in MODIFICACION_VEHICULO_TITUs)
            {
                listAux.Add(o);
            }
            foreach (blld_MODIFICACION_VEHICULO_TITU select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_VEHICULO_TITUs.Remove(select);
            }
            foreach (Int32 nid_Dependientes in ListDependientes)
            {
                Add_MODIFICACION_VEHICULO_TITUs(nid_Dependientes);
            }
            datos_MODIFICACION_VEHICULO.L_MODIFICADO = true;
            datos_MODIFICACION_VEHICULO.update();
        }

        #endregion

    }
}
