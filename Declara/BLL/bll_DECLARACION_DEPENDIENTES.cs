using Declara_V2.DALD;
using Declara_V2.Exceptions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_DEPENDIENTES : _bllSistema
    {

        internal dald_DECLARACION_DEPENDIENTES datos_DECLARACION_DEPENDIENTES;

        #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_DECLARACION_DEPENDIENTES.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_DECLARACION_DEPENDIENTES.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_DECLARACION_DEPENDIENTES.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E P E N D I E N T E es requerido ")]
        [DisplayName("I D_ D E P E N D I E N T E")]
        public Int32 NID_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTE;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O_ D E P E N D I E N T E es requerido ")]
        [DisplayName("I D_ T I P O_ D E P E N D I E N T E")]
        public Int32 NID_TIPO_DEPENDIENTE
        {
            get => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
            set => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo N O M B R E es requerido ")]
        [DisplayName("N O M B R E")]
        public String E_NOMBRE
        {
            get => datos_DECLARACION_DEPENDIENTES.E_NOMBRE;
            set => datos_DECLARACION_DEPENDIENTES.E_NOMBRE = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo P R I M E R_ A es requerido ")]
        [DisplayName("P R I M E R_ A")]
        public String E_PRIMER_A
        {
            get => datos_DECLARACION_DEPENDIENTES.E_PRIMER_A;
            set => datos_DECLARACION_DEPENDIENTES.E_PRIMER_A = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo S E G U N D O_ A es requerido ")]
        [DisplayName("S E G U N D O_ A")]
        public String E_SEGUNDO_A
        {
            get => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A;
            set => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo N A C I M I E N T O es requerido ")]
        [DisplayName("N A C I M I E N T O")]
        public DateTime F_NACIMIENTO
        {
            get => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO;
            set => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO = value;
        }

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("R F C")]
        public String E_RFC
        {
            get => datos_DECLARACION_DEPENDIENTES.E_RFC;
            set => datos_DECLARACION_DEPENDIENTES.E_RFC = value;
        }

        [Required(ErrorMessage = "El campo D E P E N D E_ E C O es requerido ")]
        [DisplayName("D E P E N D E_ E C O")]
        public Boolean L_DEPENDE_ECO
        {
            get => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECO;
            set => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECO = value;
        }
        public Boolean L_PAREJA
        {
            get => datos_DECLARACION_DEPENDIENTES.L_PAREJA;
            set => datos_DECLARACION_DEPENDIENTES.L_PAREJA = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("D O M I C I L I O")]
        public String E_DOMICILIO
        {
            get => datos_DECLARACION_DEPENDIENTES.E_DOMICILIO;
            set => datos_DECLARACION_DEPENDIENTES.E_DOMICILIO = value;
        }

        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO
        {
            get => datos_DECLARACION_DEPENDIENTES.L_ACTIVO;
            set => datos_DECLARACION_DEPENDIENTES.L_ACTIVO = value;
        }


        public Boolean L_MISMO_DOMICILIO_DECLARANTE
        {
            get => datos_DECLARACION_DEPENDIENTES.L_MISMO_DOMICILIO_DECLARANTE;
            set => datos_DECLARACION_DEPENDIENTES.L_MISMO_DOMICILIO_DECLARANTE = value;
        }


        public Boolean L_CIUDADANO_EXTRANJERO
        {
            get => datos_DECLARACION_DEPENDIENTES.L_CIUDADANO_EXTRANJERO;
            set => datos_DECLARACION_DEPENDIENTES.L_CIUDADANO_EXTRANJERO = value;
        }

        public String E_CURP
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_CURP))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_CURP);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES.E_CURP;
                }

            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_CURP = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_CURP = Encripta(value);
            }
        }
        public Int32 NID_ACTIVIDAD_LABORAL
        {
            get => datos_DECLARACION_DEPENDIENTES.NID_ACTIVIDAD_LABORAL;
            set => datos_DECLARACION_DEPENDIENTES.NID_ACTIVIDAD_LABORAL = value;
        }
        public String E_OBSERVACIONES
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES;
                }

            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES = Encripta(value);
            }
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES_MARCADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES_MARCADO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES_MARCADO = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.E_OBSERVACIONES_MARCADO = Encripta(value);
            }
        }

        public String V_OBSERVACIONES_TESTADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES.V_OBSERVACIONES_TESTADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_DEPENDIENTES.V_OBSERVACIONES_TESTADO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES.V_OBSERVACIONES_TESTADO = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES.V_OBSERVACIONES_TESTADO = Encripta(value);
            }
        }

        public int NID_ESTADO_TESTADO
        {
            get => datos_DECLARACION_DEPENDIENTES.NID_ESTADO_TESTADO;
            set => datos_DECLARACION_DEPENDIENTES.NID_ESTADO_TESTADO = value;
        }



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_DEPENDIENTES.lEsNuevoRegistro; }
        }

        #endregion




        //private void _Reload_DECLARACION_DEPENDIENTES_PRIVADOs()
        //{
        //    _DECLARACION_DEPENDIENTES_PRIVADOs = new Lista<blld_DECLARACION_DEPENDIENTES_PRIVADO>();
        //    foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO o in datos_DECLARACION._DECLARACION_DEPENDIENTES_PRIVADOs)
        //    {
        //        _DECLARACION_DEPENDIENTES_PRIVADOs.Add(new blld_DECLARACION_DEPENDIENTES_PRIVADO(o));
        //    }
        //}







        #endregion


        #region *** Constructores ***

        public bll_DECLARACION_DEPENDIENTES() => datos_DECLARACION_DEPENDIENTES = new dald_DECLARACION_DEPENDIENTES();

        public bll_DECLARACION_DEPENDIENTES(MODELDeclara_V2.DECLARACION_DEPENDIENTES DECLARACION_DEPENDIENTES) => datos_DECLARACION_DEPENDIENTES = new dald_DECLARACION_DEPENDIENTES(DECLARACION_DEPENDIENTES);

        public bll_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) => datos_DECLARACION_DEPENDIENTES = new dald_DECLARACION_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);

        public bll_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String E_DOMICILIO, Boolean L_CIUDADANO_EXTRANJERO, String E_CURP
                                                               , Int32 NID_ACTIVIDAD_LABORAL
                                                               , String E_OBSERVACIONES
                                                               , String E_OBSERVACIONES_MARCADO
                                                               , String V_OBSERVACIONES_TESTADO
                                                               , Boolean L_MISMO_DOMICILIO_DECLARANTE, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION_DEPENDIENTES = new dald_DECLARACION_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, E_DOMICILIO, L_CIUDADANO_EXTRANJERO, E_CURP
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , E_OBSERVACIONES
                                                               , E_OBSERVACIONES_MARCADO
                                                               , V_OBSERVACIONES_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE, L_ACTIVO, L_PAREJA, lOpcionesRegistroExistente);

        #endregion


        #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION_DEPENDIENTES.update();
        }

        public void delete()
        {
            datos_DECLARACION_DEPENDIENTES.delete();
        }

        public void reload()
        {
            datos_DECLARACION_DEPENDIENTES.reload();
        }

        #endregion

    }
}
