using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
	public partial class blld_DECLARACION : bll_DECLARACION
	{

		#region *** Propiedades ***
		private Lista<blld_DECLARACION_ESCOLARIDAD> _DECLARACION_ESCOLARIDADs { get; set; }
		public Lista<blld_DECLARACION_ESCOLARIDAD> DECLARACION_ESCOLARIDADs
		{
			get
			{
				if (_DECLARACION_ESCOLARIDADs == null)
				{
					_DECLARACION_ESCOLARIDADs = new Lista<blld_DECLARACION_ESCOLARIDAD>();
					Reload_DECLARACION_ESCOLARIDADs();
				}
				return _DECLARACION_ESCOLARIDADs;
			}
		}


		private Lista<blld_DECLARACION_APARTADO> _DECLARACION_APARTADOs { get; set; }
		public Lista<blld_DECLARACION_APARTADO> DECLARACION_APARTADOs
		{
			get
			{
				if (_DECLARACION_APARTADOs == null)
				{
					_DECLARACION_APARTADOs = new Lista<blld_DECLARACION_APARTADO>();
					Reload_DECLARACION_APARTADOs();
				}
				return _DECLARACION_APARTADOs;
			}
		}


		private blld_DECLARACION_CARGO _DECLARACION_CARGO { get; set; }
		public blld_DECLARACION_CARGO DECLARACION_CARGO
		{
			get
			{
				if (_DECLARACION_CARGO == null)
					_DECLARACION_CARGO = new blld_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _DECLARACION_CARGO; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_DECLARACION_CARGO = value;
			}
		}


		private Lista<blld_DECLARACION_DEPENDIENTES> _DECLARACION_DEPENDIENTESs { get; set; }
		public Lista<blld_DECLARACION_DEPENDIENTES> DECLARACION_DEPENDIENTESs
		{
			get
			{
				if (_DECLARACION_DEPENDIENTESs == null)
				{
					_DECLARACION_DEPENDIENTESs = new Lista<blld_DECLARACION_DEPENDIENTES>();
					Reload_DECLARACION_DEPENDIENTESs();
				}
				return _DECLARACION_DEPENDIENTESs;
			}
		}


		private blld_DECLARACION_DOM_LABORAL _DECLARACION_DOM_LABORAL { get; set; }
		public blld_DECLARACION_DOM_LABORAL DECLARACION_DOM_LABORAL
		{
			get
			{
				if (_DECLARACION_DOM_LABORAL == null)
					_DECLARACION_DOM_LABORAL = new blld_DECLARACION_DOM_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _DECLARACION_DOM_LABORAL; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_DECLARACION_DOM_LABORAL = value;
			}
		}


		private blld_DECLARACION_DOM_PARTICULAR _DECLARACION_DOM_PARTICULAR { get; set; }
		public blld_DECLARACION_DOM_PARTICULAR DECLARACION_DOM_PARTICULAR
		{
			get
			{
				if (_DECLARACION_DOM_PARTICULAR == null)
					_DECLARACION_DOM_PARTICULAR = new blld_DECLARACION_DOM_PARTICULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _DECLARACION_DOM_PARTICULAR; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_DECLARACION_DOM_PARTICULAR = value;
			}
		}


		private Lista<blld_DECLARACION_EGRESOS> _DECLARACION_EGRESOSs { get; set; }
		public Lista<blld_DECLARACION_EGRESOS> DECLARACION_EGRESOSs
		{
			get
			{
				if (_DECLARACION_EGRESOSs == null)
				{
					_DECLARACION_EGRESOSs = new Lista<blld_DECLARACION_EGRESOS>();
					Reload_DECLARACION_EGRESOSs();
				}
				return _DECLARACION_EGRESOSs;
			}
		}


		private Lista<blld_DECLARACION_INGRESOS> _DECLARACION_INGRESOSs { get; set; }
		public Lista<blld_DECLARACION_INGRESOS> DECLARACION_INGRESOSs
		{
			get
			{
				if (_DECLARACION_INGRESOSs == null)
				{
					_DECLARACION_INGRESOSs = new Lista<blld_DECLARACION_INGRESOS>();
					Reload_DECLARACION_INGRESOSs();
				}
				return _DECLARACION_INGRESOSs;
			}
		}


		private Lista<blld_DECLARACION_RESTRICCIONES> _DECLARACION_RESTRICCIONESs { get; set; }
		public Lista<blld_DECLARACION_RESTRICCIONES> DECLARACION_RESTRICCIONESs
		{
			get
			{
				if (_DECLARACION_RESTRICCIONESs == null)
				{
					_DECLARACION_RESTRICCIONESs = new Lista<blld_DECLARACION_RESTRICCIONES>();
					Reload_DECLARACION_RESTRICCIONESs();
				}
				return _DECLARACION_RESTRICCIONESs;
			}
		}


		private blld_MODIFICACION _MODIFICACION { get; set; }
		public blld_MODIFICACION MODIFICACION
		{
			get
			{
				if (_MODIFICACION == null)
					_MODIFICACION = new blld_MODIFICACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _MODIFICACION; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_MODIFICACION = value;
			}
		}


		private Lista<blld_DECLARACION_EXPERIENCIA_LABORAL> _DECLARACION_EXPERIENCIA_LABORALs { get; set; }
		public Lista<blld_DECLARACION_EXPERIENCIA_LABORAL> DECLARACION_EXPERIENCIA_LABORALs
		{
			get
			{
				if (_DECLARACION_EXPERIENCIA_LABORALs == null)
				{
					_DECLARACION_EXPERIENCIA_LABORALs = new Lista<blld_DECLARACION_EXPERIENCIA_LABORAL>();
					Reload_DECLARACION_EXPERIENCIA_LABORALs();
				}
				return _DECLARACION_EXPERIENCIA_LABORALs;
			}
		}


		private Lista<blld_DECLARACION_REGIMEN_MATRIMONIAL> _DECLARACION_REGIMEN_MATRIMONIALs { get; set; }
		public Lista<blld_DECLARACION_REGIMEN_MATRIMONIAL> DECLARACION_REGIMEN_MATRIMONIALs
		{
			get
			{
				if (_DECLARACION_REGIMEN_MATRIMONIALs == null)
				{
					_DECLARACION_REGIMEN_MATRIMONIALs = new Lista<blld_DECLARACION_REGIMEN_MATRIMONIAL>();
					Reload_DECLARACION_REGIMEN_MATRIMONIALs();
				}
				return _DECLARACION_REGIMEN_MATRIMONIALs;
			}
		}


		private blld_DECLARACION_CARGO_OTRO _DECLARACION_CARGO_OTRO { get; set; }
		public blld_DECLARACION_CARGO_OTRO DECLARACION_CARGO_OTRO
		{
			get
			{
				if (_DECLARACION_CARGO_OTRO == null)
					_DECLARACION_CARGO_OTRO = new blld_DECLARACION_CARGO_OTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _DECLARACION_CARGO_OTRO; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_DECLARACION_CARGO_OTRO = value;
			}
		}
		
		  private blld_DECLARACION_PERSONALES _DECLARACION_PERSONALES { get; set; }
		public blld_DECLARACION_PERSONALES DECLARACION_PERSONALES
		{
			get
			{
				if (_DECLARACION_PERSONALES == null)
					_DECLARACION_PERSONALES = new blld_DECLARACION_PERSONALES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _DECLARACION_PERSONALES;
			}
			set
			{
				if (
					this.VID_NOMBRE != value.VID_NOMBRE &&
					this.VID_FECHA != value.VID_FECHA &&
					this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
					this.NID_DECLARACION != value.NID_DECLARACION
					)
					throw new Exception("Las llaves no corresponden");
				else
				{
					_DECLARACION_PERSONALES = value;
				}
			}
		}


		private blld_ALTA _ALTA { get; set; }
		public blld_ALTA ALTA
		{
			get
			{
				if (_ALTA == null)
					_ALTA = new blld_ALTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
				return _ALTA; 
			}
			set
			{
				if (this.VID_NOMBRE != value.VID_NOMBRE || this.VID_FECHA != value.VID_FECHA || this.VID_HOMOCLAVE != value.VID_HOMOCLAVE || this.NID_DECLARACION != value.NID_DECLARACION)
					throw new CustomException("Las llaves no corresponden");
				else
					_ALTA = value;
			}
		}


		#endregion


		#region *** Constructores ***
		private blld_DECLARACION() : base()
		{
			_DECLARACION_ESCOLARIDADs = null;
			_DECLARACION_APARTADOs = null;
			_DECLARACION_CARGO = null;
			_DECLARACION_DEPENDIENTESs = null;
			_DECLARACION_DOM_LABORAL = null;
			_DECLARACION_DOM_PARTICULAR = null;
			_DECLARACION_EGRESOSs = null;
			_DECLARACION_INGRESOSs = null;
			_DECLARACION_RESTRICCIONESs = null;
			_MODIFICACION = null;
			_DECLARACION_EXPERIENCIA_LABORALs = null;
			_DECLARACION_REGIMEN_MATRIMONIALs = null;
			_DECLARACION_CARGO_OTRO = null;
			_ALTA = null;
		}
		public blld_DECLARACION(MODELDeclara_V2.DECLARACION DECLARACION) : base(DECLARACION) { }
		public blld_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

//        public blld_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, System.Nullable<DateTime> F_ENVIO, System.Nullable<Boolean> L_CONFLICTO, String V_HASH)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, V_HASH, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

		#endregion


		#region *** Metodos ***
		private void _Reload_DECLARACION_ESCOLARIDADs()
		{
			_DECLARACION_ESCOLARIDADs = new Lista<blld_DECLARACION_ESCOLARIDAD>();
			foreach (MODELDeclara_V2.DECLARACION_ESCOLARIDAD o in datos_DECLARACION._DECLARACION_ESCOLARIDADs)
				_DECLARACION_ESCOLARIDADs.Add(new blld_DECLARACION_ESCOLARIDAD(o));
		}
		private void _Add_DECLARACION_ESCOLARIDADs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES)
		{
			blld_DECLARACION_ESCOLARIDAD oDECLARACION_ESCOLARIDAD = new blld_DECLARACION_ESCOLARIDAD(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_ESCOLARIDAD, V_INSTITUCION_EDUCATIVA, V_CARRERA, NID_ESTADO_ESCOLARIDAD, NID_DOCUMENTO_OBTENIDO, F_OBTENCION, NID_PAIS, E_OBSERVACIONES);
			//if (oDECLARACION_ESCOLARIDAD.lEsNuevoRegistro.Value)
				DECLARACION_ESCOLARIDADs.Add(oDECLARACION_ESCOLARIDAD);
			//DECLARACION_ESCOLARIDADs[FindIndex_DECLARACION_ESCOLARIDADs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD)] = oDECLARACION_ESCOLARIDAD;
		}
		public Int32 FindIndex_DECLARACION_ESCOLARIDADs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD) => DECLARACION_ESCOLARIDADs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_ESCOLARIDAD == NID_ESCOLARIDAD);


		//private void _Reload_DECLARACION_APARTADOs()
		//{
		//    _DECLARACION_APARTADOs = new Lista<blld_DECLARACION_APARTADO>();
		//    foreach (MODELDeclara_V2.DECLARACION_APARTADO o in datos_DECLARACION._DECLARACION_APARTADOs)
		//        _DECLARACION_APARTADOs.Add(new blld_DECLARACION_APARTADO(o));
		//}
		//private void _Add_DECLARACION_APARTADOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO, System.Nullable<Boolean> L_ESTADO)
		//{
		//    blld_DECLARACION_APARTADO oDECLARACION_APARTADO = new blld_DECLARACION_APARTADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO, L_ESTADO);
		//    if (oDECLARACION_APARTADO.lEsNuevoRegistro.Value) DECLARACION_APARTADOs.Add(oDECLARACION_APARTADO);
		//    DECLARACION_APARTADOs[FindIndex_DECLARACION_APARTADOs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO)] = oDECLARACION_APARTADO;
		//}
		//public Int32 FindIndex_DECLARACION_APARTADOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO) => DECLARACION_APARTADOs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_APARTADO == NID_APARTADO);


		//private void _Add_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_FUNCION_PRINCIPAL, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO)
		//{
		//    this.DECLARACION_CARGO = new blld_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_FUNCION_PRINCIPAL, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO);
		//}


		//private void _Reload_DECLARACION_DEPENDIENTESs()
		//{
		//    _DECLARACION_DEPENDIENTESs = new Lista<blld_DECLARACION_DEPENDIENTES>();
		//    foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES o in datos_DECLARACION._DECLARACION_DEPENDIENTESs)
		//        _DECLARACION_DEPENDIENTESs.Add(new blld_DECLARACION_DEPENDIENTES(o));
		//}
		//private void _Add_DECLARACION_DEPENDIENTESs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String E_DOMICILIO, Boolean L_ACTIVO, Boolean L_CIUDADANO_EXTRANJERO, String E_CURP, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Boolean L_MISMO_DOMICILIO_DECLARANTE)
		//{
		//    blld_DECLARACION_DEPENDIENTES oDECLARACION_DEPENDIENTES = new blld_DECLARACION_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, E_DOMICILIO, L_ACTIVO, L_CIUDADANO_EXTRANJERO, E_CURP, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_MISMO_DOMICILIO_DECLARANTE);
		//    if (oDECLARACION_DEPENDIENTES.lEsNuevoRegistro.Value) DECLARACION_DEPENDIENTESs.Add(oDECLARACION_DEPENDIENTES);
		//    DECLARACION_DEPENDIENTESs[FindIndex_DECLARACION_DEPENDIENTESs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE)] = oDECLARACION_DEPENDIENTES;
		//}
		//public Int32 FindIndex_DECLARACION_DEPENDIENTESs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) => DECLARACION_DEPENDIENTESs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_DEPENDIENTE == NID_DEPENDIENTE);


		private void _Add_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL)
		{
			this.DECLARACION_DOM_LABORAL = new blld_DECLARACION_DOM_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO_LABORAL, V_TEL_LABORAL);
		}


		//private void _Add_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO)
		//{
		//    this.DECLARACION_DOM_PARTICULAR = new blld_DECLARACION_DOM_PARTICULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO, V_TEL_PARTICULAR, V_TEL_CELULAR, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO);
		//}


		private void _Reload_DECLARACION_EGRESOSs()
		{
			_DECLARACION_EGRESOSs = new Lista<blld_DECLARACION_EGRESOS>();
			foreach (MODELDeclara_V2.DECLARACION_EGRESOS o in datos_DECLARACION._DECLARACION_EGRESOSs)
				_DECLARACION_EGRESOSs.Add(new blld_DECLARACION_EGRESOS(o));
		}
		private void _Add_DECLARACION_EGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
		{
			blld_DECLARACION_EGRESOS oDECLARACION_EGRESOS = new blld_DECLARACION_EGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL);
			if (oDECLARACION_EGRESOS.lEsNuevoRegistro.Value) DECLARACION_EGRESOSs.Add(oDECLARACION_EGRESOS);
			DECLARACION_EGRESOSs[FindIndex_DECLARACION_EGRESOSs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EGRESO)] = oDECLARACION_EGRESOS;
		}
		public Int32 FindIndex_DECLARACION_EGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO) => DECLARACION_EGRESOSs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_EGRESO == NID_EGRESO);


		private void _Reload_DECLARACION_INGRESOSs()
		{
			_DECLARACION_INGRESOSs = new Lista<blld_DECLARACION_INGRESOS>();
			foreach (MODELDeclara_V2.DECLARACION_INGRESOS o in datos_DECLARACION._DECLARACION_INGRESOSs)
				_DECLARACION_INGRESOSs.Add(new blld_DECLARACION_INGRESOS(o));
		}
		private void _Add_DECLARACION_INGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
		{
			blld_DECLARACION_INGRESOS oDECLARACION_INGRESOS = new blld_DECLARACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL);
			if (oDECLARACION_INGRESOS.lEsNuevoRegistro.Value) DECLARACION_INGRESOSs.Add(oDECLARACION_INGRESOS);
			DECLARACION_INGRESOSs[FindIndex_DECLARACION_INGRESOSs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO)] = oDECLARACION_INGRESOS;
		}
		public Int32 FindIndex_DECLARACION_INGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) => DECLARACION_INGRESOSs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_INGRESO == NID_INGRESO);


		//private void _Reload_DECLARACION_RESTRICCIONESs()
		//{
		//    _DECLARACION_RESTRICCIONESs = new Lista<blld_DECLARACION_RESTRICCIONES>();
		//    foreach (MODELDeclara_V2.DECLARACION_RESTRICCIONES o in datos_DECLARACION._DECLARACION_RESTRICCIONESs)
		//        _DECLARACION_RESTRICCIONESs.Add(new blld_DECLARACION_RESTRICCIONES(o));
		//}
		//private void _Add_DECLARACION_RESTRICCIONESs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION, System.Nullable<Boolean> L_RESPUESTA, Boolean L_AUTO)
		//{
		//    blld_DECLARACION_RESTRICCIONES oDECLARACION_RESTRICCIONES = new blld_DECLARACION_RESTRICCIONES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION, L_RESPUESTA, L_AUTO);
		//    if (oDECLARACION_RESTRICCIONES.lEsNuevoRegistro.Value) DECLARACION_RESTRICCIONESs.Add(oDECLARACION_RESTRICCIONES);
		//    DECLARACION_RESTRICCIONESs[FindIndex_DECLARACION_RESTRICCIONESs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION)] = oDECLARACION_RESTRICCIONES;
		//}
		//public Int32 FindIndex_DECLARACION_RESTRICCIONESs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION) => DECLARACION_RESTRICCIONESs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_RESTRICCION == NID_RESTRICCION);


		//private void _Add_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, System.Nullable<Boolean> L_PRESENTO_DEC, System.Nullable<DateTime> F_INICIO, System.Nullable<DateTime> F_FIN)
		//{
		//    this.MODIFICACION = new blld_MODIFICACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, L_PRESENTO_DEC, F_INICIO, F_FIN);
		//}


		private void _Reload_DECLARACION_EXPERIENCIA_LABORALs()
		{
			_DECLARACION_EXPERIENCIA_LABORALs = new Lista<blld_DECLARACION_EXPERIENCIA_LABORAL>();
			foreach (MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL o in datos_DECLARACION._DECLARACION_EXPERIENCIA_LABORALs)
				_DECLARACION_EXPERIENCIA_LABORALs.Add(new blld_DECLARACION_EXPERIENCIA_LABORAL(o));
		}
		private void _Add_DECLARACION_EXPERIENCIA_LABORALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES)
		{
			blld_DECLARACION_EXPERIENCIA_LABORAL oDECLARACION_EXPERIENCIA_LABORAL = new blld_DECLARACION_EXPERIENCIA_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, V_NOMBRE, V_RFC, V_AREA_ADSCRIPCION, V_PUESTO, V_FUNCION_PRINCIPAL, NID_SECTOR, F_INGRESO, F_EGRESO, NID_PAIS, E_OBSERVACIONES);
			//if (oDECLARACION_EXPERIENCIA_LABORAL.lEsNuevoRegistro.Value)
				DECLARACION_EXPERIENCIA_LABORALs.Add(oDECLARACION_EXPERIENCIA_LABORAL);
			//DECLARACION_EXPERIENCIA_LABORALs[FindIndex_DECLARACION_EXPERIENCIA_LABORALs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL)] = oDECLARACION_EXPERIENCIA_LABORAL;
		}
		public Int32 FindIndex_DECLARACION_EXPERIENCIA_LABORALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL) => DECLARACION_EXPERIENCIA_LABORALs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && p.NID_EXPERIENCIA_LABORAL == NID_EXPERIENCIA_LABORAL);


		private void _Reload_DECLARACION_REGIMEN_MATRIMONIALs()
		{
			_DECLARACION_REGIMEN_MATRIMONIALs = new Lista<blld_DECLARACION_REGIMEN_MATRIMONIAL>();
			foreach (MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL o in datos_DECLARACION._DECLARACION_REGIMEN_MATRIMONIALs)
				_DECLARACION_REGIMEN_MATRIMONIALs.Add(new blld_DECLARACION_REGIMEN_MATRIMONIAL(o));
		}
		//private void _Add_DECLARACION_REGIMEN_MATRIMONIALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN, Int32 NID_REGIMEN_MATRIMONIAL)
		//{
		//    blld_DECLARACION_REGIMEN_MATRIMONIAL oDECLARACION_REGIMEN_MATRIMONIAL = new blld_DECLARACION_REGIMEN_MATRIMONIAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, 1, NID_REGIMEN_MATRIMONIAL);
		//    if (oDECLARACION_REGIMEN_MATRIMONIAL.lEsNuevoRegistro.Value) DECLARACION_REGIMEN_MATRIMONIALs.Add(oDECLARACION_REGIMEN_MATRIMONIAL);
		//    DECLARACION_REGIMEN_MATRIMONIALs[FindIndex_DECLARACION_REGIMEN_MATRIMONIALs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN)] = oDECLARACION_REGIMEN_MATRIMONIAL;
		//}
		public Int32 FindIndex_DECLARACION_REGIMEN_MATRIMONIALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN) => DECLARACION_REGIMEN_MATRIMONIALs.FindIndex(p => p.VID_NOMBRE == VID_NOMBRE && p.VID_FECHA == VID_FECHA && p.VID_HOMOCLAVE == VID_HOMOCLAVE && p.NID_DECLARACION == NID_DECLARACION && 1 == NID_REGIMEN);


		private void _Add_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES)
		{
			this.DECLARACION_CARGO_OTRO = new blld_DECLARACION_CARGO_OTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, VID_NOMBRE_ENTE, V_AREA_ADSCRIPCION, V_CARGO, L_HONORARIOS, V_NIVEL_EMPLEO, V_FUNCION_PRINCIPAL, F_POSESION, V_TEL_LABORAL, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_OBSERVACIONES);
		}


		private void _Add_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
		{
			this.ALTA = new blld_ALTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
		}



		#endregion

	}
}
