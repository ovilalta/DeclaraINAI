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
    public partial class blld_ALTA_MUEBLE : bll_ALTA_MUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_MUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_MUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_MUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_MUEBLE.NID_DECLARACION; }
        //        }

        //        public Int32 NID_MUEBLE
        //        {
        //          get { return datos_ALTA_MUEBLE.NID_MUEBLE; }
        //        }


        //        public Int32 NID_TIPO
        //        {
        //          get { return datos_ALTA_MUEBLE.NID_TIPO; }
        //          set { datos_ALTA_MUEBLE.NID_TIPO = value; }
        //        }


        //        public String E_ESPECIFICACION
        //        {
        //          get { return datos_ALTA_MUEBLE.E_ESPECIFICACION; }
        //          set { datos_ALTA_MUEBLE.E_ESPECIFICACION = value; }
        //        }


        //        public Int64 M_VALOR
        //        {
        //          get { return datos_ALTA_MUEBLE.M_VALOR; }
        //          set { datos_ALTA_MUEBLE.M_VALOR = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_ALTA_MUEBLE.NID_PATRIMONIO; }
        //          set { datos_ALTA_MUEBLE.NID_PATRIMONIO = value; }
        //        }


        //        public Boolean L_CREDITO
        //        {
        //          get { return datos_ALTA_MUEBLE.L_CREDITO; }
        //          set { datos_ALTA_MUEBLE.L_CREDITO = value; }
        //        }

        new public String E_ESPECIFICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_MUEBLE.E_ESPECIFICACION))
                    return String.Empty;
                return DesEncripta(datos_ALTA_MUEBLE.E_ESPECIFICACION);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_MUEBLE.E_ESPECIFICACION = String.Empty;
                else
                    datos_ALTA_MUEBLE.E_ESPECIFICACION = Encripta(value);
            }
        }

        new public DateTime F_ADQUISICION
        {
            get => datos_ALTA_MUEBLE.F_ADQUISICION;
            set
            {
                if (value >= DateTime.Now)
                    throw new CustomException("La fecha de adquisición no puede ser mayor que la fecha actual");
                datos_ALTA_MUEBLE.F_ADQUISICION = value;
            }
        }

        public Boolean L_DONACION
        {
            get
            {
                if (datos_ALTA_MUEBLE.NID_FORMA_PAGO == 1)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    datos_ALTA_MUEBLE.NID_FORMA_PAGO = 1;
                else
                    datos_ALTA_MUEBLE.NID_FORMA_PAGO = -1;
            }
        }
        blld_ALTA_MUEBLE_COPROPIETARIO _ALTA_MUEBLE_COPROPIETARIO { get; set; }

        public blld_ALTA_MUEBLE_COPROPIETARIO ALTA_MUEBLE_COPROPIETARIO
        {
            get
            {
                try
                {
                    if (_ALTA_MUEBLE_COPROPIETARIO == null)
                        _ALTA_MUEBLE_COPROPIETARIO = new blld_ALTA_MUEBLE_COPROPIETARIO(this.VID_NOMBRE
                                                                                            , this.VID_FECHA
                                                                                            , this.VID_HOMOCLAVE
                                                                                            , this.NID_DECLARACION
                                                                                            , this.NID_MUEBLE
                                                                                            , 1);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                        _ALTA_MUEBLE_COPROPIETARIO = new blld_ALTA_MUEBLE_COPROPIETARIO();
                }
                return _ALTA_MUEBLE_COPROPIETARIO;
            }
            set => _ALTA_MUEBLE_COPROPIETARIO = value;
        }

        new public String E_NOMBRE_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR = value;
                else
                    datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR = Encripta(value);
            }
        }

        new public String E_RFC_TRANSMISOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_MUEBLE.E_RFC_TRANSMISOR))
                    return String.Empty;

                if (datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    return datos_ALTA_MUEBLE.E_RFC_TRANSMISOR;
                else
                    return DesEncripta(datos_ALTA_MUEBLE.E_RFC_TRANSMISOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_MUEBLE.E_RFC_TRANSMISOR = String.Empty;
                else
                    if (datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR == "M")
                    datos_ALTA_MUEBLE.E_RFC_TRANSMISOR = value;
                else
                    datos_ALTA_MUEBLE.E_RFC_TRANSMISOR = Encripta(value);
            }
        }
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_MUEBLE.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_MUEBLE.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_MUEBLE.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_MUEBLE.E_OBSERVACIONES = Encripta(value);
            }
        }

        // sme

        public String V_FORMA_PAGO => datos_ALTA_MUEBLE.oFormaPago.V_FORMA_PAGO;
        new public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_MUEBLE.NID_FORMA_PAGO;
            set
            {
                if (!value.Equals(datos_ALTA_MUEBLE.NID_FORMA_PAGO))
                {
                    datos_ALTA_MUEBLE._oFormaPago = null;
                }
                datos_ALTA_MUEBLE.NID_FORMA_PAGO = value;
            }
        }

        public String V_FORMA_ADQUISICION => datos_ALTA_MUEBLE.oFormaAdquisicion.V_FORMA_ADQUISICION;
        new public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_MUEBLE.NID_FORMA_ADQUISICION;
            set
            {
                if (!value.Equals(datos_ALTA_MUEBLE.NID_FORMA_ADQUISICION))
                {
                    datos_ALTA_MUEBLE._oFormaAdquisicion = null;
                }
                datos_ALTA_MUEBLE.NID_FORMA_ADQUISICION = value;
            }
        }


        public String V_RELACION_TRANSMISOR => datos_ALTA_MUEBLE.oRelacionTransmisor.V_RELACION_TRANSMISOR;
        new public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_MUEBLE.NID_RELACION_TRANSMISOR;
            set
            {
                if (!value.Equals(datos_ALTA_MUEBLE.NID_RELACION_TRANSMISOR))
                {
                    datos_ALTA_MUEBLE._oRelacionTransmisor = null;
                }
                datos_ALTA_MUEBLE.NID_RELACION_TRANSMISOR = value;
            }
        }

        // sme


        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_MUEBLE(  String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_TIPO
                                , String E_ESPECIFICACION
                                , Decimal M_VALOR
                                , Boolean L_CREDITO
                                , DateTime F_ADQUISICION
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , Int32 NID_FORMA_ADQUISICION
                                , Int32 NID_FORMA_PAGO
                                , String E_OBSERVACIONES
                                , String CID_TIPO_PERSONA
                                , String V_NOMBRE
                                , String V_RFC
                                , List<Int32> ListDependientes
                                )
        : base()
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            if (F_ADQUISICION >= DateTime.Now)
                throw new CustomException("La fecha de adquisición no puede ser mayor que la fecha actual");

            //if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            //{
            //    if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");
            //    if (String.IsNullOrEmpty(V_NOMBRE) || V_NOMBRE.Length < 5) throw new CustomException("Falta especificar el nombre del tercero");
            //    if (!String.IsNullOrEmpty(V_RFC) && ((CID_TIPO_PERSONA == "F" && V_RFC.Length != 13) || (CID_TIPO_PERSONA == "M" && V_RFC.Length != 12))) throw new CustomException("El RFC del tercero es incorrecto");

            //}



            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");

                if (String.IsNullOrEmpty(V_NOMBRE)) throw new CustomException("Falta especificar el nombre del tercero");

                if ((CID_TIPO_PERSONA == "F" && V_NOMBRE.Length < 5)) throw new CustomException("Falta especificar el nombre del tercero");

                if (!String.IsNullOrEmpty(V_RFC))
                {
                    if (CID_TIPO_PERSONA == "F")
                        if (V_RFC.Length != 13)
                            throw new CustomException("El RFC del tercero no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (V_RFC.Length != 12)
                           throw new CustomException("El RFC del tercero no tiene 12 caracteres");
                }


            }


            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA_TRANSMISOR))
            {
                if(CID_TIPO_PERSONA_TRANSMISOR !="0")
                { 
                if (CID_TIPO_PERSONA_TRANSMISOR != "F" && CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");

                if (String.IsNullOrEmpty(E_NOMBRE_TRANSMISOR)) throw new CustomException("Falta especificar el nombre del transmisor");

                if ((CID_TIPO_PERSONA_TRANSMISOR == "F" && E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");

                if (!String.IsNullOrEmpty(E_RFC_TRANSMISOR))
                {
                    if (CID_TIPO_PERSONA_TRANSMISOR == "F")
                        if (E_RFC_TRANSMISOR.Length != 13)
                            throw new CustomException("El RFC del transmisor no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (E_RFC_TRANSMISOR.Length != 12)
                        throw new CustomException("El RFC del transmisor no tiene 12 caracteres");
                }
                }

            }


            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_MUEBLE = dald_ALTA_MUEBLE.nNuevo_NID_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

            if (String.IsNullOrEmpty(E_ESPECIFICACION))
                E_ESPECIFICACION = String.Empty;
            else
            E_ESPECIFICACION = Encripta(E_ESPECIFICACION);



            if (CID_TIPO_PERSONA_TRANSMISOR == "F")
            {
                E_NOMBRE_TRANSMISOR = Encripta(E_NOMBRE_TRANSMISOR);
                E_RFC_TRANSMISOR = Encripta(E_RFC_TRANSMISOR);
            }
            if (CID_TIPO_PERSONA_TRANSMISOR == "0")
            {
                E_NOMBRE_TRANSMISOR = Encripta(E_NOMBRE_TRANSMISOR);
                E_RFC_TRANSMISOR = Encripta(E_RFC_TRANSMISOR);
            }

            E_OBSERVACIONES = Encripta(E_OBSERVACIONES);

            datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE(VID_NOMBRE
                                                    , VID_FECHA, VID_HOMOCLAVE
                                                    , NID_DECLARACION
                                                    , NID_MUEBLE
                                                    , NID_TIPO
                                                    , E_ESPECIFICACION
                                                    , M_VALOR
                                                    , NID_PATRIMONIO
                                                    , L_CREDITO
                                                    , F_ADQUISICION
                                                    , CID_TIPO_PERSONA_TRANSMISOR
                                                    , E_NOMBRE_TRANSMISOR
                                                    , E_RFC_TRANSMISOR
                                                    , NID_RELACION_TRANSMISOR
                                                    , V_TIPO_MONEDA
                                                    , NID_FORMA_ADQUISICION
                                                    , NID_FORMA_PAGO
                                                    , E_OBSERVACIONES
                                                    , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                                                    );

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_MUEBLE_COPROPIETARIO = new blld_ALTA_MUEBLE_COPROPIETARIO(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_MUEBLE
                , 1
                , CID_TIPO_PERSONA
                , V_NOMBRE
                , V_RFC
               );
            }
            if (ListDependientes != null) {
                foreach (Int32 nid_Dependiente in ListDependientes)
                {
                    Add_ALTA_MUEBLE_TITULARs(nid_Dependiente);
                }
            }
        }

        public blld_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_CREDITO, DateTime F_ADQUISICION, Boolean L_DONACION, List<Int32> ListDependientes)
     : base()
        {
            //if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            //if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");
            if (F_ADQUISICION >= DateTime.Now)
                throw new CustomException("La fecha de adquisición no puede ser mayor que la fecha actual");

            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_MUEBLE = dald_ALTA_MUEBLE.nNuevo_NID_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            if (String.IsNullOrEmpty(E_ESPECIFICACION))
                E_ESPECIFICACION = String.Empty;
            else
                E_ESPECIFICACION = Encripta(E_ESPECIFICACION);

            Int32 NID_FORMA_ADQUISICION;
            if (L_DONACION)
                NID_FORMA_ADQUISICION = 1;
            else
                NID_FORMA_ADQUISICION = -1;



            datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_TIPO, E_ESPECIFICACION, M_VALOR, NID_PATRIMONIO, L_CREDITO, F_ADQUISICION,NID_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);

            if (ListDependientes != null) {
                foreach (Int32 nid_Dependiente in ListDependientes)
                {
                    Add_ALTA_MUEBLE_TITULARs(nid_Dependiente);
                }
            }
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_ALTA_MUEBLE_TITULARs()
        {
            _Reload_ALTA_MUEBLE_TITULARs();
        }

        public void Add_ALTA_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_ALTA_MUEBLE_TITULARs(NID_DEPENDIENTE, true);
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

        public void update(List<Int32> ListDependientesMuebles, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
        {
            if (ListDependientesMuebles == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientesMuebles.Count == 0) throw new CustomException("Debe haber al menos un titular");

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                if (CID_TIPO_PERSONA != "F" && CID_TIPO_PERSONA != "M") throw new CustomException("Falta el tipo de persona del tercero");

                if (String.IsNullOrEmpty(V_NOMBRE)) throw new CustomException("Falta especificar el nombre del tercero");

                if ((CID_TIPO_PERSONA == "F" && V_NOMBRE.Length < 5)) throw new CustomException("Falta especificar el nombre del tercero");

                if (!String.IsNullOrEmpty(V_RFC))
                {
                    if (CID_TIPO_PERSONA == "F")
                        if (V_RFC.Length != 13)
                            throw new CustomException("El RFC del tercero no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (V_RFC.Length != 12)
                        throw new CustomException("El RFC del tercero no tiene 12 caracteres");
                }
            }
            if (!String.IsNullOrEmpty(this.CID_TIPO_PERSONA_TRANSMISOR))
            {
                if (this.CID_TIPO_PERSONA_TRANSMISOR != "F" && this.CID_TIPO_PERSONA_TRANSMISOR != "M") throw new CustomException("Falta el tipo de persona del transmisor");

                if (String.IsNullOrEmpty(this.E_NOMBRE_TRANSMISOR)) throw new CustomException("Falta especificar el nombre del transmisor");

                if ((this.CID_TIPO_PERSONA_TRANSMISOR == "F" && this.E_NOMBRE_TRANSMISOR.Length < 5)) throw new CustomException("Falta especificar el nombre del transmisor");

                if (!String.IsNullOrEmpty(this.E_RFC_TRANSMISOR))
                {
                    if (this.CID_TIPO_PERSONA_TRANSMISOR == "F")
                        if (this.E_RFC_TRANSMISOR.Length != 13)
                            throw new CustomException("El RFC del transmisor no tiene 13 caracteres");
                        else
                        { }
                    else
                        if (this.E_RFC_TRANSMISOR.Length != 12)
                        throw new CustomException("El RFC del transmisor no tiene 12 caracteres");
                }


            }
            List<blld_ALTA_MUEBLE_TITULAR> ListAux = new List<blld_ALTA_MUEBLE_TITULAR>();
            foreach (blld_ALTA_MUEBLE_TITULAR o in ALTA_MUEBLE_TITULARs)
            {
                ListAux.Add(o);
            }

            foreach (blld_ALTA_MUEBLE_TITULAR select in ListAux)
            {
                if (!ListDependientesMuebles.Contains(select.NID_DEPENDIENTE))
                    ALTA_MUEBLE_TITULARs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in ListDependientesMuebles)
            {
                Add_ALTA_MUEBLE_TITULARs(nid_Dependiente);
            }

            datos_ALTA_MUEBLE.update();

            if (!String.IsNullOrEmpty(CID_TIPO_PERSONA))
            {
                _ALTA_MUEBLE_COPROPIETARIO = new blld_ALTA_MUEBLE_COPROPIETARIO(
                                                                                      this.VID_NOMBRE
                                                                                    , this.VID_FECHA
                                                                                    , this.VID_HOMOCLAVE
                                                                                    , this.NID_DECLARACION
                                                                                    , this.NID_MUEBLE
                                                                                    , 1
                                                                                    , CID_TIPO_PERSONA
                                                                                    , V_NOMBRE
                                                                                    , V_RFC);
            }
            else
                _ALTA_MUEBLE_COPROPIETARIO.update();
        }


        new public void delete()
        {
            int val = ALTA_MUEBLE_TITULARs.Count - 1;
            for (int i = val; i >= 0; i--)
            {
                try { ALTA_MUEBLE_TITULARs.RemoveAt(i); } catch { };
            }
            base.delete();
        }



        #endregion

    }
}
