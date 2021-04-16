using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_DECLARACION_DEPENDIENTES : bll_DECLARACION_DEPENDIENTES
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.NID_DECLARACION; }
        //        }

        //        public Int32 NID_DEPENDIENTE
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTE; }
        //        }


        //        public Int32 NID_TIPO_DEPENDIENTE
        //        {
        //          get { return datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE; }
        //          set { datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value; }
        //        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_NOMBRE
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_NOMBRE))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_NOMBRE);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_NOMBRE = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_NOMBRE = Encripta(value);
            }
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_PRIMER_A
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_PRIMER_A))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_PRIMER_A);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_PRIMER_A = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_PRIMER_A = Encripta(value);
            }
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_SEGUNDO_A
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A = Encripta(value);
            }
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public DateTime F_NACIMIENTO
        {
            get => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO;
            set
            {
                if (value >= DateTime.Today) throw new CustomException("La fecha de nacimiento no puede ser mayor que la fecha actual");
                else
                    datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO = value;
            }

        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_RFC
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_RFC))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_RFC);

                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES.E_RFC;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_RFC = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_RFC = Encripta(value);
            }
        }



        //[StringLength(4000)]
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "El campo  es requerido ")]
        //[DisplayName("")]
        //public String V_COLONIA
        //{
        //    get
        //    {
        //        try
        //        {
        //            if (String.IsNullOrEmpty(V_COLONIA))
        //                return String.Empty;
        //            return DesEncripta(V_COLONIA);

        //        }
        //        catch (Exception)
        //        {
        //            return V_COLONIA;
        //        }
        //    }
        //    set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //            V_COLONIA = String.Empty;
        //        else
        //            V_COLONIA = DesEncripta(value);
        //    }
        //}

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("D O M I C I L I O")]
        new public String E_DOMICILIO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_DOMICILIO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_DOMICILIO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_DOMICILIO = String.Empty;
                else if (value.Length < 15)
                    throw new CustomException("La longitud del domicilio debe ser por lo menos de 15 caractéres");
                else
                    datos_DECLARACION_DEPENDIENTES.E_DOMICILIO = Encripta(value);
            }
        }




        new public String V_NOMBRE_COMPLETO
        {
            get
            {
                try
                {

                    return string.Concat(DesEncripta(E_NOMBRE), ' ', DesEncripta(E_PRIMER_A), ' ', DesEncripta(E_SEGUNDO_A));
                }
                catch (Exception)
                {
                    return string.Concat(E_NOMBRE, ' ', E_PRIMER_A, ' ', E_SEGUNDO_A);
                }
            }

        }



        //     public string V_NOMBRE_COMPLETO => string.Concat(DesEncripta(E_NOMBRE), ' ', DesEncripta(E_PRIMER_A), ' ', DesEncripta(E_SEGUNDO_A));
        public string V_NOMBRE_COMPLETO_TIPO => String.Concat(V_NOMBRE_COMPLETO, " (", V_TIPO_DEPENDIENTE, ")");

        #endregion

        blld_DECLARACION_DEPENDIENTES_PRIVADO _DECLARACION_DEPENDIENTES_PRIVADO { get; set; }

        public blld_DECLARACION_DEPENDIENTES_PRIVADO DECLARACION_DEPENDIENTES_PRIVADO
        {
            get
            {
                try
                {
                    if (_DECLARACION_DEPENDIENTES_PRIVADO == null)
                        _DECLARACION_DEPENDIENTES_PRIVADO = new blld_DECLARACION_DEPENDIENTES_PRIVADO(this.VID_NOMBRE
                                                                                                , this.VID_FECHA
                                                                                                , this.VID_HOMOCLAVE
                                                                                                , this.NID_DECLARACION
                                                                                                , this.NID_DEPENDIENTE);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                        _DECLARACION_DEPENDIENTES_PRIVADO = new blld_DECLARACION_DEPENDIENTES_PRIVADO();
                }
                return _DECLARACION_DEPENDIENTES_PRIVADO;
            }
            set => _DECLARACION_DEPENDIENTES_PRIVADO = value;

        }

        blld_DECLARACION_DEPENDIENTES_PUBLICO _DECLARACION_DEPENDIENTES_PUBLICO { get; set; }

        public blld_DECLARACION_DEPENDIENTES_PUBLICO DECLARACION_DEPENDIENTES_PUBLICO
        {
            get
            {
                try
                {
                    if (_DECLARACION_DEPENDIENTES_PUBLICO == null)
                        _DECLARACION_DEPENDIENTES_PUBLICO = new blld_DECLARACION_DEPENDIENTES_PUBLICO(this.VID_NOMBRE
                                                                                                , this.VID_FECHA
                                                                                                , this.VID_HOMOCLAVE
                                                                                                , this.NID_DECLARACION
                                                                                                , this.NID_DEPENDIENTE);
                }
                catch (Exception ex)
                {
                    if (ex is RowNotFoundException)
                        _DECLARACION_DEPENDIENTES_PUBLICO = new blld_DECLARACION_DEPENDIENTES_PUBLICO();
                }
                return _DECLARACION_DEPENDIENTES_PUBLICO;
            }
            set => _DECLARACION_DEPENDIENTES_PUBLICO = value;

        }




        #region *** Constructores (Extended) ***

        public blld_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String E_DOMICILIO,
            Boolean L_CIUDADANO_EXTRANJERO, String E_CURP
                                                               , Int32 NID_ACTIVIDAD_LABORAL
                                                               , String E_OBSERVACIONES
                                                               , String E_OBSERVACIONES_MARCADO
                                                               , String V_OBSERVACIONES_TESTADO
                                                               , Boolean L_MISMO_DOMICILIO_DECLARANTE
                                                               , String C_CODIGO_POSTAL
                                                               , Int32 NID_PAIS
                                                               , String CID_ENTIDAD_FEDERATIVA
                                                               , String CID_MUNICIPIO
                                                               , String V_COLONIA
                                                               , Int32 NID_AMBITO_SECTOR
                                                               , Int32 NID_NIVEL_GOBIERNO
                                                               , Int32 NID_AMBITO_PUBLICO
                                                               , String V_NOMBRE_ENTE
                                                               , String V_AREA_ADSCRIPCION
                                                               , String V_CARGO
                                                               , String V_FUNCION_PRINCIPAL
                                                               , Decimal M_SALARIO_MENSUAL
                                                               , DateTime F_INGRESO
                                                               , String V_NOMBRE
                                                               , String V_RFC
                                                               , Int32 NID_SECTOR
                                                               , Boolean L_PROVEEDOR
                                                               , Boolean L_PAREJA)
        : base()
        {
            Int32 NID_DEPENDIENTE = dald_DECLARACION_DEPENDIENTES.nNuevo_NID_DEPENDIENTE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            if (F_NACIMIENTO >= DateTime.Today) throw new CustomException("La fecha de nacimiento no puede ser mayor que la fecha actual");

            if (!L_MISMO_DOMICILIO_DECLARANTE)
            {
                if (String.IsNullOrEmpty(E_DOMICILIO))
                    datos_DECLARACION_DEPENDIENTES.E_DOMICILIO = String.Empty;
                else if (E_DOMICILIO.Length < 5)
                    throw new CustomException("La longitud del domicilio debe ser por lo menos de 5 caractéres");
                else
                    E_DOMICILIO = Encripta(E_DOMICILIO);
            }

            if (!String.IsNullOrEmpty(E_NOMBRE))
                E_NOMBRE = Encripta(E_NOMBRE);
            else
                throw new CustomException("El nombre no puede quedar en blanco");

            if (!String.IsNullOrEmpty(E_PRIMER_A))
                E_PRIMER_A = Encripta(E_PRIMER_A);
            else
                throw new CustomException("El primer apellido no puede ser vacío");

            if (!String.IsNullOrEmpty(E_PRIMER_A))
                E_SEGUNDO_A = Encripta(E_SEGUNDO_A);
            else
                E_SEGUNDO_A = String.Empty;

            if (NID_ACTIVIDAD_LABORAL == 0)
                throw new CustomException("Debe seleccionar una actividad laboral");


            NID_ACTIVIDAD_LABORAL = NID_AMBITO_SECTOR;

            datos_DECLARACION_DEPENDIENTES = new dald_DECLARACION_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, Encripta(E_NOMBRE), Encripta(E_PRIMER_A), Encripta(E_SEGUNDO_A), F_NACIMIENTO, Encripta(E_RFC), L_DEPENDE_ECO, E_DOMICILIO, L_CIUDADANO_EXTRANJERO, Encripta(E_CURP)
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , Encripta(E_OBSERVACIONES)
                                                               , Encripta(E_OBSERVACIONES_MARCADO)
                                                               , Encripta(V_OBSERVACIONES_TESTADO)
                                                               , L_MISMO_DOMICILIO_DECLARANTE, true, L_PAREJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);


            if (!L_MISMO_DOMICILIO_DECLARANTE)
            {
                //Guardar datos direccion de dependiente 
                cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                DECLARACION_DEPENDIENTES_DOMICILIO oDep = new DECLARACION_DEPENDIENTES_DOMICILIO();
                oDep.VID_NOMBRE = VID_NOMBRE;
                oDep.VID_FECHA = VID_FECHA;
                oDep.VID_HOMOCLAVE = VID_HOMOCLAVE;
                oDep.NID_DECLARACION = NID_DECLARACION;
                oDep.NID_DEPENDIENTE = NID_DEPENDIENTE;

                oDep.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
                oDep.NID_PAIS = NID_PAIS;
                oDep.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
                oDep.CID_MUNICIPIO = CID_MUNICIPIO;
                oDep.V_COLONIA = Encripta(V_COLONIA);
                oDep.V_DOMICILIO = E_DOMICILIO.ToString();

                db.DECLARACION_DEPENDIENTES_DOMICILIO.Add(oDep);
                db.SaveChanges();
            }

            if (NID_AMBITO_SECTOR != 4)
            {
                if (NID_ACTIVIDAD_LABORAL == 1)
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDECLARACION_DEPENDIENTES_PRIVADO = new blld_DECLARACION_DEPENDIENTES_PRIVADO(
                        VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, V_NOMBRE, V_CARGO, V_RFC, F_INGRESO, NID_SECTOR, M_SALARIO_MENSUAL, L_PROVEEDOR);
                    oDECLARACION_DEPENDIENTES_PRIVADO.update();
                }
                if (NID_ACTIVIDAD_LABORAL == 2)
                {
                    blld_DECLARACION_DEPENDIENTES_PUBLICO dECLARACION_DEPENDIENTES_PUBLICO = new blld_DECLARACION_DEPENDIENTES_PUBLICO(
                        VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, Encripta(V_NOMBRE_ENTE), Encripta(V_AREA_ADSCRIPCION), Encripta(V_CARGO), Encripta(V_FUNCION_PRINCIPAL), M_SALARIO_MENSUAL, F_INGRESO);
                    dECLARACION_DEPENDIENTES_PUBLICO.update();
                }
                if (NID_ACTIVIDAD_LABORAL == 3)
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDECLARACION_DEPENDIENTES_PRIVADO = new blld_DECLARACION_DEPENDIENTES_PRIVADO(
                        VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, V_NOMBRE, V_CARGO, V_RFC, F_INGRESO, NID_SECTOR, M_SALARIO_MENSUAL, L_PROVEEDOR);
                    oDECLARACION_DEPENDIENTES_PRIVADO.update();
                }



            }





        }


        #endregion


        #region *** Metodos (Extended) ***

        new public void delete()
        {
            bll__l_ALTA_INMUEBLE_TITULAR oInmueble = new bll__l_ALTA_INMUEBLE_TITULAR();
            oInmueble.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oInmueble.VID_FECHA = new StringFilter(VID_FECHA);
            oInmueble.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oInmueble.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oInmueble.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oInmueble.select();
            if (oInmueble.lista_ALTA_INMUEBLE_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un inmueble, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_ALTA_MUEBLE_TITULAR oMueble = new blld__l_ALTA_MUEBLE_TITULAR();
            oMueble.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oMueble.VID_FECHA = new StringFilter(VID_FECHA);
            oMueble.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oMueble.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oMueble.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oMueble.select();
            if (oMueble.lista_ALTA_MUEBLE_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un bien mueble, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_ALTA_VEHICULO_TITULAR oVehiculo = new blld__l_ALTA_VEHICULO_TITULAR();
            oVehiculo.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oVehiculo.VID_FECHA = new StringFilter(VID_FECHA);
            oVehiculo.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oVehiculo.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oVehiculo.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oVehiculo.select();
            if (oVehiculo.lista_ALTA_VEHICULO_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un vehículo, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_ALTA_INVERSION_TITULAR oInversion = new blld__l_ALTA_INVERSION_TITULAR();
            oInversion.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oInversion.VID_FECHA = new StringFilter(VID_FECHA);
            oInversion.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oInversion.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oInversion.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oInversion.select();
            if (oInversion.lista_ALTA_INVERSION_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de una inversión, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_ALTA_ADEUDO_TITULAR oAdeudo = new blld__l_ALTA_ADEUDO_TITULAR();
            oAdeudo.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oAdeudo.VID_FECHA = new StringFilter(VID_FECHA);
            oAdeudo.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oAdeudo.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oAdeudo.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oAdeudo.select();
            if (oAdeudo.lista_ALTA_ADEUDO_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un adeudo, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            bll__l_MODIFICACION_INMUEBLE_TITULA oInmuebleAnterior = new bll__l_MODIFICACION_INMUEBLE_TITULA();
            oInmuebleAnterior.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oInmuebleAnterior.VID_FECHA = new StringFilter(VID_FECHA);
            oInmuebleAnterior.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oInmuebleAnterior.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oInmuebleAnterior.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oInmuebleAnterior.select();
            if (oInmuebleAnterior.lista_MODIFICACION_INMUEBLE_TITULA.Any())
                throw new CustomException("El dependiente se encuentra como titular de un inmueble, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_MODIFICACION_MUEBLE_TITULAR oMuebleAnterior = new blld__l_MODIFICACION_MUEBLE_TITULAR();
            oMuebleAnterior.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oMuebleAnterior.VID_FECHA = new StringFilter(VID_FECHA);
            oMuebleAnterior.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oMuebleAnterior.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oMuebleAnterior.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oMuebleAnterior.select();
            if (oMuebleAnterior.lista_MODIFICACION_MUEBLE_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un bien mueble, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_MODIFICACION_VEHICULO_TITU oVehiculoAnterior = new blld__l_MODIFICACION_VEHICULO_TITU();
            oVehiculoAnterior.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oVehiculoAnterior.VID_FECHA = new StringFilter(VID_FECHA);
            oVehiculoAnterior.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oVehiculoAnterior.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oVehiculoAnterior.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oVehiculoAnterior.select();
            if (oVehiculoAnterior.lista_MODIFICACION_VEHICULO_TITU.Any())
                throw new CustomException("El dependiente se encuentra como titular de un vehículo, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_MODIFICACION_INVERSION_TITU oInversionAnterior = new blld__l_MODIFICACION_INVERSION_TITU();
            oInversionAnterior.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oInversionAnterior.VID_FECHA = new StringFilter(VID_FECHA);
            oInversionAnterior.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oInversionAnterior.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oInversionAnterior.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oInversionAnterior.select();
            if (oInversionAnterior.lista_MODIFICACION_INVERSION_TITU.Any())
                throw new CustomException("El dependiente se encuentra como titular de una inversión, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            blld__l_MODIFICACION_ADEUDO_TITULAR oAdeudoAnterior = new blld__l_MODIFICACION_ADEUDO_TITULAR();
            oAdeudoAnterior.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oAdeudoAnterior.VID_FECHA = new StringFilter(VID_FECHA);
            oAdeudoAnterior.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oAdeudoAnterior.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oAdeudoAnterior.NID_DEPENDIENTE = new IntegerFilter(NID_DEPENDIENTE);
            oAdeudoAnterior.select();
            if (oAdeudoAnterior.lista_MODIFICACION_ADEUDO_TITULAR.Any())
                throw new CustomException("El dependiente se encuentra como titular de un adeudo, por lo que antes deberá seleccionar otro titular para poder eliminarlo.");

            base.delete();
        }



        public void DomicilioUpdate(string C_CODIGO_POSTAL, int NID_PAIS, string CID_ENTIDAD_FEDERATIVA, string CID_MUNICIPIO, string V_COLONIA, string V_DOMICILIO)
        {
            try
            {
                DECLARACION_DEPENDIENTES_DOMICILIO registro = new DECLARACION_DEPENDIENTES_DOMICILIO()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_DEPENDIENTE = NID_DEPENDIENTE,
                    C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                    NID_PAIS = NID_PAIS,
                    CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                    CID_MUNICIPIO = CID_MUNICIPIO,
                    V_COLONIA = Encripta(V_COLONIA),
                    V_DOMICILIO = Encripta(V_DOMICILIO)
                };

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

                db.DECLARACION_DEPENDIENTES_DOMICILIO.Add(registro);
                db.Entry(registro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void DomicilioNuevo(string C_CODIGO_POSTAL, int NID_PAIS, string CID_ENTIDAD_FEDERATIVA, string CID_MUNICIPIO, string V_COLONIA, string V_DOMICILIO)
        {
            try
            {
                DECLARACION_DEPENDIENTES_DOMICILIO registro = new DECLARACION_DEPENDIENTES_DOMICILIO()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_DEPENDIENTE = NID_DEPENDIENTE,
                    C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                    NID_PAIS = NID_PAIS,
                    CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                    CID_MUNICIPIO = CID_MUNICIPIO,
                    V_COLONIA = Encripta(V_COLONIA),
                    V_DOMICILIO = Encripta(V_DOMICILIO)
                };

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

                db.DECLARACION_DEPENDIENTES_DOMICILIO.Add(registro);
                //db.Entry(registro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void DomicilioBorra(string C_CODIGO_POSTAL, int NID_PAIS, string CID_ENTIDAD_FEDERATIVA, string CID_MUNICIPIO, string V_COLONIA, string V_DOMICILIO)
        {
            try
            {
                DECLARACION_DEPENDIENTES_DOMICILIO registro = new DECLARACION_DEPENDIENTES_DOMICILIO()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_DEPENDIENTE = NID_DEPENDIENTE,
                    C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                    NID_PAIS = NID_PAIS,
                    CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                    CID_MUNICIPIO = CID_MUNICIPIO,
                    V_COLONIA = Encripta(V_COLONIA),
                    V_DOMICILIO = Encripta(V_DOMICILIO)
                };

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

                db.DECLARACION_DEPENDIENTES_DOMICILIO.Add(registro);
                db.Entry(registro).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }


        #endregion

    }
}
