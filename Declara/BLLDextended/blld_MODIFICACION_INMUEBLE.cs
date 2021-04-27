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
    public partial class blld_MODIFICACION_INMUEBLE : bll_MODIFICACION_INMUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.NID_DECLARACION; }
        //        }

        //        public Int32 NID_INMUEBLE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.NID_INMUEBLE; }
        //        }


        //        public Int32 NID_TIPO
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.NID_TIPO; }
        //          set { datos_MODIFICACION_INMUEBLE.NID_TIPO = value; }
        //        }


        //        public DateTime F_ADQUISICION
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.F_ADQUISICION; }
        //          set { datos_MODIFICACION_INMUEBLE.F_ADQUISICION = value; }
        //        }


        //        public Int32 NID_USO
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.NID_USO; }
        //          set { datos_MODIFICACION_INMUEBLE.NID_USO = value; }
        //        }


        new public String E_UBICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_INMUEBLE.E_UBICACION))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_INMUEBLE.E_UBICACION);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    datos_MODIFICACION_INMUEBLE.E_UBICACION = String.Empty;
                }
                else if (value.Length < 15)
                {
                    throw new CustomException("La longitud de la ubicación debe ser por lo menos de 15 caractéres");
                }
                else
                {
                    if (Encripta(value) != datos_MODIFICACION_INMUEBLE.E_UBICACION)
                    {
                        blld_ALTA_INMUEBLE.ValidaUbicacion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, Encripta(value), NID_DECLARACION);
                        datos_MODIFICACION_INMUEBLE.E_UBICACION = Encripta(value);
                    }
                }
            }
        }


        //        public Decimal N_TERRENO
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.N_TERRENO; }
        //          set { datos_MODIFICACION_INMUEBLE.N_TERRENO = value; }
        //        }


        //        public Decimal N_CONSTRUCCION
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION; }
        //          set { datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION = value; }
        //        }


        //        public Decimal M_VALOR_INMUEBLE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE; }
        //          set { datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE.NID_PATRIMONIO; }
        //          set { datos_MODIFICACION_INMUEBLE.NID_PATRIMONIO = value; }
        //        }

        public decimal M_REPARACIONES_REMODELACIONES
        {
            get
            {
                try
                {
                    blld__l_MODIFICACION_GASTO o = new blld__l_MODIFICACION_GASTO();
                    o.VID_NOMBRE = new StringFilter(this.VID_NOMBRE);
                    o.VID_FECHA = new StringFilter(this.VID_FECHA);
                    o.VID_HOMOCLAVE = new StringFilter(this.VID_HOMOCLAVE);
                    o.NID_DECLARACION = new IntegerFilter(this.NID_DECLARACION);
                    o.NID_PATRIMONIO_ASC = new IntegerFilter(this.NID_PATRIMONIO);
                    o.select();
                    return o.lista_MODIFICACION_GASTO.First().M_GASTO;
                }
                catch 
                {
                    return 0;
                }
            }
            set
            {
                blld_MODIFICACION_GASTO oGasto;
                blld__l_MODIFICACION_GASTO o = new blld__l_MODIFICACION_GASTO();
                o.VID_NOMBRE = new StringFilter(this.VID_NOMBRE);
                o.VID_FECHA = new StringFilter(this.VID_FECHA);
                o.VID_HOMOCLAVE = new StringFilter(this.VID_HOMOCLAVE);
                o.NID_DECLARACION = new IntegerFilter(this.NID_DECLARACION);
                o.NID_PATRIMONIO_ASC = new IntegerFilter(this.NID_PATRIMONIO);
                o.select();
                if (o.lista_MODIFICACION_GASTO.Any())
                {
                    oGasto = new blld_MODIFICACION_GASTO(o.lista_MODIFICACION_GASTO.First());
                }
                else
                {
                    oGasto = null;
                }
                if (value <= 0)
                {
                    if (oGasto!=null)
                    oGasto.delete();
                }
                else
                {
                    if (oGasto != null)
                    {
                        oGasto.M_GASTO = value;
                        oGasto.update();
                    }
                    else
                    {
                        oGasto = new blld_MODIFICACION_GASTO(this.VID_NOMBRE, this.VID_FECHA,this.VID_HOMOCLAVE, this.NID_DECLARACION, 3, "Remodelaciones y Reparaciones", value, false, this.NID_PATRIMONIO);
                    }
                }
            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        : base()
        {
            Int32 NID_INMUEBLE = dald_MODIFICACION_INMUEBLE.nNuevo_NID_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            datos_MODIFICACION_INMUEBLE = new dald_MODIFICACION_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, false, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_INMUEBLE_ADEUDOs()
        {
            _Reload_MODIFICACION_INMUEBLE_ADEUDOs();
        }

        public void Add_MODIFICACION_INMUEBLE_ADEUDOs(Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF)
        {
            try
            {
                _Add_MODIFICACION_INMUEBLE_ADEUDOs(NID_PATRIMONIO_ADEUDO, L_DIF);
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

        public void Reload_MODIFICACION_INMUEBLE_TITULAs()
        {
            _Reload_MODIFICACION_INMUEBLE_TITULAs();
        }

        public void Add_MODIFICACION_INMUEBLE_TITULAs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_MODIFICACION_INMUEBLE_TITULAs(NID_DEPENDIENTE, true);
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
            List<blld_MODIFICACION_INMUEBLE_TITULA> listAux = new List<blld_MODIFICACION_INMUEBLE_TITULA>();
            foreach (blld_MODIFICACION_INMUEBLE_TITULA o in MODIFICACION_INMUEBLE_TITULAs)
            {
                listAux.Add(o);
            }
            foreach (blld_MODIFICACION_INMUEBLE_TITULA select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    MODIFICACION_INMUEBLE_TITULAs.Remove(select);
            }
            foreach (Int32 nid_Dependientes in ListDependientes)
            {
                Add_MODIFICACION_INMUEBLE_TITULAs(nid_Dependientes);
            }
            L_MODIFICADO = true;
            datos_MODIFICACION_INMUEBLE.update();
        }



        #endregion

    }
}
