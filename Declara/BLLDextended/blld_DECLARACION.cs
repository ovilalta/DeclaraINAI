using AjaxControIToolkit;
using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;




namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_DECLARACION : bll_DECLARACION
    {

        
        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION.NID_DECLARACION; }
        //        }


        //        public String C_EJERCICIO
        //        {
        //          get { return datos_DECLARACION.C_EJERCICIO; }
        //          set { datos_DECLARACION.C_EJERCICIO = value; }
        //        }


        //        public Int32 NID_TIPO_DECLARACION
        //        {
        //          get { return datos_DECLARACION.NID_TIPO_DECLARACION; }
        //          set { datos_DECLARACION.NID_TIPO_DECLARACION = value; }
        //        }


        //        public Int32 NID_ESTADO
        //        {
        //          get { return datos_DECLARACION.NID_ESTADO; }
        //        }

        #region * CAT_ESTADO_TESTADO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ESTADO_TESTADO => datos_DECLARACION.V_ESTADO_TESTADO;

        #endregion * CAT_ESTADO_TESTADO *

        new public String V_HASH
        {
            get => datos_DECLARACION.V_HASH;

            private set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION.V_HASH = String.Empty;
                else
                    datos_DECLARACION.V_HASH = Encripta(value, TextBox.MMCL, TextBox.codigo);
            }
        }

        public String V_HASH_CLEAR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION.V_HASH))
                    return String.Empty;
                else
                    return DesEncripta(datos_DECLARACION.V_HASH, TextBox.MMCL, TextBox.codigo);
            }
        }


        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION.E_OBSERVACIONES = Encripta(value);
            }
        }
        new public String E_OBSERVACIONES_MARCADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION.E_OBSERVACIONES_MARCADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION.E_OBSERVACIONES_MARCADO);
            }
            set
            {
                switch (NID_ESTADO_TESTADO)
                {
                    case 0:
                        throw new CustomException("No se puede cambiar el testado de una declaración sin observaciones");
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        throw new CustomException("No se puede cambiar el testado de una declaración con testado aprobado");
                    default:
                        throw new CustomException("No definido");
                }

                if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
                {
                    datos_DECLARACION.E_OBSERVACIONES_MARCADO = String.Empty;
                    datos_DECLARACION.V_OBSERVACIONES_TESTADO = String.Empty;
                }
                else
                {
                    datos_DECLARACION.E_OBSERVACIONES_MARCADO = Encripta(value);

                    Boolean pipe = false;
                    Int32 contador = 0;
                    String asing = String.Empty;
                    Char caracterAnterior = '0';
                    Boolean ModoReplace = false;

                    foreach (char caracter in value)
                    {
                        if (caracter == '|' && !pipe)
                        {
                            pipe = true;
                        }
                        else if (caracter == '|' && pipe)
                        {
                            contador++;
                            pipe = false;
                        }

                    }

                    if (contador % 2 != 0)
                        throw new CustomException("El numero de auxiliares (||) de apertura y cierre no coinciden");

                    for (int x = 0; x < value.Length; x++)
                    {

                        if (x >= 1)
                            caracterAnterior = value[x - 1];
                        if (caracterAnterior == '|' && value[x] == '|')
                            ModoReplace = !ModoReplace;
                        if (value[x] != '|' && value[x] != ' ')
                            asing += (!ModoReplace) ? value[x].ToString() : "█";
                        else
                            if (caracterAnterior != '|')
                            asing += ' ';
                    }

                    datos_DECLARACION.V_OBSERVACIONES_TESTADO = asing;

                }
            }
        }


        new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_DECLARACION.V_OBSERVACIONES_TESTADO) ? String.Empty : datos_DECLARACION.V_OBSERVACIONES_TESTADO.Replace("¦", "█");
        new public System.Nullable<Boolean> L_AUTORIZA_PUBLICAR
        {
            get { return datos_DECLARACION.L_AUTORIZA_PUBLICAR; }
            set { datos_DECLARACION.L_AUTORIZA_PUBLICAR = value.Value; }
        }


        //        public DateTime F_REGISTRO
        //        {
        //          get { return datos_DECLARACION.F_REGISTRO; }
        //        }


        //        public System.Nullable<DateTime> F_ENVIO
        //        {
        //          get { return datos_DECLARACION.F_ENVIO; }
        //          set { datos_DECLARACION.F_ENVIO = value; }
        //        }


        //        public System.Nullable<Boolean> L_CONFLICTO
        //        {
        //          get { return datos_DECLARACION.L_CONFLICTO; }
        //          set { datos_DECLARACION.L_CONFLICTO = value; }
        //        }



        List<Int32> EstadosOK = new List<int>() { 2, 3 };
        public Int32 NID_ULTIMA_DECLARACION { get; private set; }

        public List<MODELextended.fn_BalanzaEgresos> BalanzaEgresos => datos_DECLARACION.BalanzaEgresos;

        public List<MODELextended.fn_BalanzaIngresos> BalanzaIngresos => datos_DECLARACION.BalanzaIngresos;


        public List<MODELextended.fn_BalanzaEgresos> BalanzaEgresosSinCeros => this.BalanzaEgresos.Where(p => p.M_TOTAL > 0).ToList();

        public List<MODELextended.fn_BalanzaIngresos> BalanzaIngresosSinCeros => this.BalanzaIngresos.Where(p => p.M_TOTAL > 0).ToList();

        public Decimal mIngresosTotales => this.BalanzaIngresos.Where(p => p.N_NIVEL == 1).First().M_TOTAL.Value;

        public Decimal mEgresosTotales => this.BalanzaEgresos.Where(p => p.N_NIVEL == 1).First().M_TOTAL.Value;

        public Decimal mDiferencia => Math.Ceiling(mIngresosTotales - mEgresosTotales);

        public Int32 lInclinacion
        {
            get
            {
                if (mDiferencia > 1)
                    return 1;
                else if (mDiferencia < -1)
                    return -1;
                else return 0;
            }
        }

        public Decimal mPorcentajeDiferencia
        {

            get
            {
                return Convert.ToDecimal(100) - ((mEgresosTotales * Convert.ToDecimal(100) / mIngresosTotales));
            }
        }


        public String vDiferencia
        {
            get
            {
                return String.Concat("$", mDiferencia.ToString("N0"));
            }
        }

        public String vPorcentajeDiferencia
        {
            get
            {
                return String.Concat(mPorcentajeDiferencia.ToString("N3"), "%");
            }
        }

        public String V_ESTADO => datos_DECLARACION.oEstadoDeclaracion.V_ESTADO;
        new public Int32 NID_ESTADO
        {
            get => datos_DECLARACION.NID_ESTADO;
            set
            {
                if (!value.Equals(datos_DECLARACION.NID_ESTADO))
                {
                    datos_DECLARACION._oEstadoDeclaracion = null;
                }
                datos_DECLARACION.NID_ESTADO = value;
            }
        }

        public String V_TIPO => datos_DECLARACION.oTipoDeclaracion.V_TIPO_DECLARACION;
        public Int32 NID_TIPO
        {
            get => datos_DECLARACION.NID_TIPO_DECLARACION;
            set
            {
                if (!value.Equals(datos_DECLARACION.NID_TIPO_DECLARACION))
                {
                    datos_DECLARACION._oTipoDeclaracion = null;
                }
                datos_DECLARACION.NID_TIPO_DECLARACION = value;
            }
        }

        #endregion


        #region *** Constructores (Extended) ***

       

        public blld_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_TIPO_DECLARACION, Boolean lDif)
            : base()
        {
            String C_EJERCICIO;
            Int32 NID_ESTADO = 1;
            String E_OBSERVACIONES = String.Empty;
            String E_OBSERVACIONES_MARCADO = String.Empty;
            String V_OBSERVACIONES_TESTADO = String.Empty;
            Int32 NID_ESTADO_TESTADO = 0;
            Boolean L_AUTORIZA_PUBLICAR = true;
            System.Nullable<DateTime> F_ENVIO = null;
            System.Nullable<Boolean> L_CONFLICTO = null;
            String RFC = VID_NOMBRE + VID_FECHA + VID_HOMOCLAVE;
            //String Anio_Compara = C_EJERCICIO;
            blld__l_DECLARACION oBusquedaDeclaracion = new blld__l_DECLARACION();
            oBusquedaDeclaracion.VID_NOMBRE = new Declara_V2.StringFilter(VID_NOMBRE);
            oBusquedaDeclaracion.VID_FECHA = new Declara_V2.StringFilter(VID_FECHA);
            oBusquedaDeclaracion.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_HOMOCLAVE);
            oBusquedaDeclaracion.NID_ESTADOs.Add(6);
            oBusquedaDeclaracion.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
            oBusquedaDeclaracion.OrderByCriterios.Add(new Declara_V2.Order(MODELextended.DECLARACION.Properties.NID_DECLARACION));
            oBusquedaDeclaracion.select();

            switch (NID_TIPO_DECLARACION)
            {
                case 1:
                    C_EJERCICIO = DateTime.Today.Year.ToString();
                    if (oBusquedaDeclaracion.lista_DECLARACION.Any())
                    {
                        blld_DECLARACION oDeclaracion = new blld_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());

                        switch (oDeclaracion.NID_TIPO_DECLARACION)
                        {
                            case 1:
                                if (oDeclaracion.NID_ESTADO == 1)
                                {
                                    datos_DECLARACION = new dald_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                                    checkHASH();
                                }
                                else if (oDeclaracion.NID_ESTADO == 6)
                                    datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                else
                                    throw new CustomException("Ya se ha presentado una declaración inicial");
                                break;
                            case 2:
                                throw new CustomException("La última declaración es de modificación, no se puede presentar una declaración inicial");
                            case 3:
                                if (oDeclaracion.NID_ESTADO != 1)
                                    datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                else if (oDeclaracion.NID_ESTADO == 1)
                                    throw new CustomException("Existe una declaración de conclusión pendiente de envío,no se puede presentar una declaración inicial");
                                //else if (oDeclaracion.NID_ESTADO == 6)
                                //   datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                else
                                    throw new CustomException("Tipo no reconocido");
                                break;
                            default:
                                throw new CustomException("Tipo no reconocido");
                        }
                    }
                    else
                        datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                    break;
                case 2:
                    //Aqui hay que meter la condicion de las excepciones para que se brinque esta validacion
                    
                   
                    string line;
                    bool excep = false;
                    var buildDir = HttpRuntime.AppDomainAppPath;
                    var filePath = buildDir + @"\Formas\Administrador\ObligadosModificacion.txt";
                    StreamReader file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (RFC.Equals(line))
                        {
                            excep = true;
                        }
                    }
                    file.Close();

                    //OEVM - Validacion para permitirle a los ingresos del year pasado y que hicieron este anio inicial puedan hacer modificacion
                    

                        if (!oBusquedaDeclaracion.lista_DECLARACION.Any())
                        {
                            throw new CustomException("No se ha presentado una declaración de inicio");
                        }
                        else
                        {
                            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                            C_EJERCICIO = (Convert.ToInt32(oDeclaracion.C_EJERCICIO)).ToString();
                            switch (oDeclaracion.NID_TIPO_DECLARACION)
                            {
                                case 1:
                                if (excep == false) {
                                    ValidaMes(C_EJERCICIO);
                                    if (oDeclaracion.C_EJERCICIO == (DateTime.Now.Year).ToString())
                                        throw new CustomException("Su Declaración Patrimonial Inicial  fue presentada este año, y por reglamento no le corresponde presentar declaración de modificación este año. En caso de alguna duda, puede llamar a las extensiones 3435, 2307 y 2461");
                                }
                                if (oDeclaracion.NID_ESTADO == 1)
                                        throw new CustomException("Existe una declaración de inicio pendiente de envio");
                                     int ejercicio = Convert.ToInt32( C_EJERCICIO) - 1;
                                    datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, Convert.ToString(ejercicio), NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                    break;
                                case 2:
                                    if (oDeclaracion.C_EJERCICIO == (DateTime.Now.Year).ToString() & oDeclaracion.NID_ESTADO != 1)
                                        throw new CustomException("La declaración de modificación ya fue presentada este año");
                                    if (oDeclaracion.NID_ESTADO == 1)
                                    {
                                        datos_DECLARACION = new dald_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                                        checkHASH();
                                    }
                                    else
                                    {
                                        C_EJERCICIO = (Convert.ToInt32(oDeclaracion.C_EJERCICIO) + 1).ToString();
                                        ValidaMes(C_EJERCICIO);
                                        datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                    }
                                    break;
                                case 3:
                                    if (oDeclaracion.NID_ESTADO == 1)
                                        throw new CustomException("Existe una declaración de conclusión pendiente de envío");
                                    else
                                        throw new CustomException("No se ha presentado una declaración de inicio");
                                default:
                                    throw new CustomException("Tipo no reconocido");
                            }
                        }
                    
                    break;
                case 3:
                    if (!oBusquedaDeclaracion.lista_DECLARACION.Any())
                    {
                        throw new CustomException("No se ha presentado una declaración de inicio");
                    }
                    else
                    {
                        blld_DECLARACION oDeclaracion = new blld_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                        C_EJERCICIO = DateTime.Today.Year.ToString();

                        switch (oDeclaracion.NID_TIPO_DECLARACION)
                        {
                            case 1:
                                if (oDeclaracion.NID_ESTADO == 1)
                                    throw new CustomException("Existe una declaración de inicio pendiente de envio");
                                else
                                    datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                break;
                            case 2:
                                if (oDeclaracion.NID_ESTADO == 1)
                                    throw new CustomException("Existe una declaración de modificación pendiente de envio");
                                else
                                    datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                                break;
                            case 3:
                                if (oDeclaracion.NID_ESTADO == 1)
                                    datos_DECLARACION = new dald_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                                else
                                    throw new CustomException("No se puede presentar una declaración de conclusión cuando le precede una declaracion de conclusión.");
                                break;
                            default:
                                throw new CustomException("Tipo no reconocido");
                        }
                    }
                    break;
                default:
                    break;
            }
        }



        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_DECLARACION_APARTADOs()
        {
            _Reload_DECLARACION_APARTADOs();
        }

        public void Add_DECLARACION_APARTADOs(Int32 NID_APARTADO, Boolean L_ESTADO)
        {
            try
            {
                _Add_DECLARACION_APARTADOs(NID_APARTADO, L_ESTADO);
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

        public void enviar(Boolean L_AUTORIZA_PUBLICAR)
        {
            datos_DECLARACION.Enviar();
            datos_DECLARACION.L_AUTORIZA_PUBLICAR = L_AUTORIZA_PUBLICAR;
            base.update();
            this.V_HASH = String.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, '|', Convert.ToInt16(L_AUTORIZA_PUBLICAR).ToString(), '|', F_REGISTRO, '|', F_ENVIO);
            this.update();
        }

        public void checkHASH()
        {
            if (string.IsNullOrEmpty(V_HASH) && EstadosOK.Contains(base.NID_ESTADO))
            {
                this.V_HASH = string.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, '|', Convert.ToInt16(L_AUTORIZA_PUBLICAR).ToString(), '|', F_REGISTRO, '|', F_ENVIO);
                base.update();
            }
        }

        new public void update()
        {
            if (base.NID_ESTADO == 1)
                datos_DECLARACION.update();
        }

        public void CambiarEjercicio(String C_EJERCICIO)
        {
            if (base.NID_ESTADO == 1 && NID_TIPO_DECLARACION == 1 && !string.IsNullOrEmpty(C_EJERCICIO))
            {
                try
                {
                    if (C_EJERCICIO.Length == 4 && Convert.ToInt32(C_EJERCICIO) >= 2018 && Convert.ToInt32(C_EJERCICIO) <= DateTime.Now.Year)
                    {
                        datos_DECLARACION.C_EJERCICIO = C_EJERCICIO;
                        datos_DECLARACION.update();
                    }
                    else
                    {
                        throw new CustomException("El ejercicio no es válido");
                    }
                }
                catch
                {

                }
            }
            else
            {
            }
        }

        public void Cancelar()
        {
            if (base.NID_ESTADO == 1)
            {
                datos_DECLARACION.NID_ESTADO = 6;
                datos_DECLARACION.update();
            }
            else
            {
                throw new CustomException("Sólo se pueden cancelar declaraciones que no han sido enviadas");
            }
        }

        private void ValidaMes(string C_EJERCICIO)
        {
            if (C_EJERCICIO == (DateTime.Today.Year - 1).ToString())
            {
                if (DateTime.Today.Month <= clsSistema.nMesBloqueoDeclaracion)
                    throw new CustomException("La declaración de modificación " + C_EJERCICIO + " se presenta a partir del mes de mayo");
            }
            else
            {
                //do nothing
            }
        }

        public void GuardarTestado()
        {
            switch (NID_ESTADO_TESTADO)
            {
                case 0:
                    throw new CustomException("No se puede cambiar el testado de una declaración sin observaciones");
                case 1:
                    datos_DECLARACION.NID_ESTADO_TESTADO = 2;
                    datos_DECLARACION.Reload_CAT_ESTADO_TESTADO();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    throw new CustomException("No se puede cambiar el testado de una declaración con testado aprobado");
                default:
                    throw new CustomException("No definido");
            }
            base.update();
        }

        public void FinalizarTestado()
        {
            switch (NID_ESTADO_TESTADO)
            {
                case 0:
                    throw new CustomException("No se puede cambiar el testado de una declaración sin observaciones");
                case 1:
                    datos_DECLARACION.NID_ESTADO_TESTADO = 3;
                    datos_DECLARACION.Reload_CAT_ESTADO_TESTADO();
                    break;
                case 2:
                    datos_DECLARACION.NID_ESTADO_TESTADO = 3;
                    datos_DECLARACION.Reload_CAT_ESTADO_TESTADO();
                    break;
                case 3:
                    throw new CustomException("El testado ya se encuentra en estado finalizado");
                case 4:
                    throw new CustomException("No se puede cambiar el testado de una declaración con testado aprobado");
                default:
                    throw new CustomException("No definido");
            }
            base.update();
        }

        public void AprobarTestado()
        {
            switch (NID_ESTADO_TESTADO)
            {
                case 0:
                    throw new CustomException("No se puede cambiar el testado de una declaración sin observaciones");
                case 1:
                    throw new CustomException("Se debe finalizar el testado antes de aprobarlo");
                case 2:
                    throw new CustomException("Se debe finalizar el testado antes de aprobarlo");
                case 3:
                    datos_DECLARACION.NID_ESTADO_TESTADO = 4;
                    datos_DECLARACION.Reload_CAT_ESTADO_TESTADO();
                    break;
                case 4:
                    throw new CustomException("No se puede cambiar el testado de una declaración con testado aprobado");
                default:
                    throw new CustomException("No definido");
            }
            base.update();
        }

        public void Add_DECLARACION_CARGO(Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, DateTime F_POSESION, DateTime F_INICIO)
        {
            try
            {
                _Add_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, F_POSESION, F_INICIO);
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
        public void Add_ALTA()
        {
            try
            {
                _Add_ALTA();
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
        public void Reload_DECLARACION_DEPENDIENTESs()
        {
            _Reload_DECLARACION_DEPENDIENTESs();
        }

        public void Add_DECLARACION_DEPENDIENTESs(Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO

                                                               , Boolean L_CIUDADANO_EXTRANJERO
                                                               , String E_CURP
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
                                                               , String V_DOMICILIO
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
                                                               , Boolean L_PAREJA
                                                )


        {
            try
            {
                _Add_DECLARACION_DEPENDIENTESs(NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO,
                                                                    V_DOMICILIO
                                                               , L_CIUDADANO_EXTRANJERO
                                                               , E_CURP
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , E_OBSERVACIONES
                                                               , E_OBSERVACIONES_MARCADO
                                                               , V_OBSERVACIONES_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE
                                                               , C_CODIGO_POSTAL
                                                               , NID_PAIS
                                                               , CID_ENTIDAD_FEDERATIVA
                                                               , CID_MUNICIPIO
                                                               , V_COLONIA

                                                               , NID_AMBITO_SECTOR
                                                               , NID_NIVEL_GOBIERNO
                                                               , NID_AMBITO_PUBLICO
                                                               , V_NOMBRE_ENTE
                                                               , V_AREA_ADSCRIPCION
                                                               , V_CARGO
                                                               , V_FUNCION_PRINCIPAL
                                                               , M_SALARIO_MENSUAL
                                                               , F_INGRESO
                                                               , V_NOMBRE
                                                               , V_RFC
                                                               , NID_SECTOR
                                                               , L_PROVEEDOR
                                                               , L_PAREJA
                                                               );
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

        public void Reload_DECLARACION_RESTRICCIONESs()
        {
            _Reload_DECLARACION_RESTRICCIONESs();
        }

        //public void Add_DECLARACION_RESTRICCIONES(Boolean L_RESPUESTA, Boolean L_AUTO)
        //{
        //    try
        //    {
        //        _Add_DECLARACION_RESTRICCIONES(L_RESPUESTA, L_AUTO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}
        //public void Add_DECLARACION_PERSONALES(Int32 NID_DOMICILIO_LABORAL, Int32 NID_DOMICILIO_PARTICULAR, String V_TELEFONO_LABORAL, String V_TELEFONO_PARTICULAR, String V_CORREO, Int32 NID_PAIS)
        //{
        //    try
        //    {
        //        _Add_DECLARACION_PERSONALES(NID_DOMICILIO_LABORAL, NID_DOMICILIO_PARTICULAR, V_TELEFONO_LABORAL, V_TELEFONO_PARTICULAR, V_CORREO, NID_PAIS);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}
        public void Add_MODIFICACION(Boolean L_PRESENTO_DEC)
        {
            try
            {
                _Add_MODIFICACION(L_PRESENTO_DEC);
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


        #region creo que con esto se arregla

        private void _Reload_DECLARACION_APARTADOs()
        {
            _DECLARACION_APARTADOs = new Lista<blld_DECLARACION_APARTADO>();
            foreach (MODELDeclara_V2.DECLARACION_APARTADO o in datos_DECLARACION._DECLARACION_APARTADOs)
            {
                _DECLARACION_APARTADOs.Add(new blld_DECLARACION_APARTADO(o));
            }
        }

        private void _Add_DECLARACION_APARTADOs(Int32 NID_APARTADO, Boolean L_ESTADO)
        {
            blld_DECLARACION_APARTADO oDECLARACION_APARTADO = new blld_DECLARACION_APARTADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO, L_ESTADO);
            if (oDECLARACION_APARTADO.lEsNuevoRegistro.Value) DECLARACION_APARTADOs.Add(oDECLARACION_APARTADO);
            _DECLARACION_APARTADOs[FindIndex_DECLARACION_APARTADOs(NID_APARTADO)] = oDECLARACION_APARTADO;
        }

        public Int32 FindIndex_DECLARACION_APARTADOs(Int32 NID_APARTADO)
        {
            return DECLARACION_APARTADOs.FindIndex(p =>
                              p.NID_APARTADO == NID_APARTADO
                                                   );
        }

        private void _Add_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, DateTime F_POSESION, DateTime F_INICIO)
        {
            this._DECLARACION_CARGO = new blld_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL);
        }
        private void _Add_ALTA()
        {
            this._ALTA = new blld_ALTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
        }
        private void _Reload_DECLARACION_RESTRICCIONESs()
        {
            _DECLARACION_RESTRICCIONESs = new Lista<blld_DECLARACION_RESTRICCIONES>();
            foreach (MODELDeclara_V2.DECLARACION_RESTRICCIONES o in datos_DECLARACION._DECLARACION_RESTRICCIONESs)
            {
                _DECLARACION_RESTRICCIONESs.Add(new blld_DECLARACION_RESTRICCIONES(o));
            }
        }

        private void _Add_DECLARACION_RESTRICCIONESs(Int32 NID_RESTRICCION, Boolean L_RESPUESTA, Boolean L_AUTO)
        {
            blld_DECLARACION_RESTRICCIONES oDECLARACION_RESTRICCIONES = new blld_DECLARACION_RESTRICCIONES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION, L_RESPUESTA, L_AUTO);
            if (oDECLARACION_RESTRICCIONES.lEsNuevoRegistro.Value) DECLARACION_RESTRICCIONESs.Add(oDECLARACION_RESTRICCIONES);
            DECLARACION_RESTRICCIONESs[FindIndex_DECLARACION_RESTRICCIONESs(NID_RESTRICCION)] = oDECLARACION_RESTRICCIONES;
        }

        public Int32 FindIndex_DECLARACION_RESTRICCIONESs(Int32 NID_RESTRICCION)
        {
            return DECLARACION_RESTRICCIONESs.FindIndex(p =>
                              p.NID_RESTRICCION == NID_RESTRICCION
                                                   );
        }

        private void _Reload_DECLARACION_DEPENDIENTESs()
        {
            _DECLARACION_DEPENDIENTESs = new Lista<blld_DECLARACION_DEPENDIENTES>();
            foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES o in datos_DECLARACION._DECLARACION_DEPENDIENTESs)
            {
                _DECLARACION_DEPENDIENTESs.Add(new blld_DECLARACION_DEPENDIENTES(o));
            }
        }

        private void _Add_DECLARACION_DEPENDIENTESs(Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO
                                                                 , String E_DOMICILIO
                                                                 , Boolean L_CIUDADANO_EXTRANJERO
                                                                 , String E_CURP
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
                                                                 , Boolean L_PAREJA




              )
        {
            blld_DECLARACION_DEPENDIENTES oDECLARACION_DEPENDIENTES = new blld_DECLARACION_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, E_DOMICILIO, L_CIUDADANO_EXTRANJERO
                                                                               , E_CURP
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , E_OBSERVACIONES
                                                               , E_OBSERVACIONES_MARCADO
                                                               , V_OBSERVACIONES_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE
                                                               , C_CODIGO_POSTAL
                                                               , NID_PAIS
                                                               , CID_ENTIDAD_FEDERATIVA
                                                               , CID_MUNICIPIO
                                                               , V_COLONIA
                                                               , NID_AMBITO_SECTOR
                                                               , NID_NIVEL_GOBIERNO
                                                               , NID_AMBITO_PUBLICO
                                                               , V_NOMBRE_ENTE
                                                               , V_AREA_ADSCRIPCION
                                                               , V_CARGO
                                                               , V_FUNCION_PRINCIPAL
                                                               , M_SALARIO_MENSUAL
                                                               , F_INGRESO
                                                               , V_NOMBRE
                                                               , V_RFC
                                                               , NID_SECTOR
                                                               , L_PROVEEDOR
                                                               , L_PAREJA);

            DECLARACION_DEPENDIENTESs.Add(oDECLARACION_DEPENDIENTES);
        }

        public Int32 FindIndex_DECLARACION_DEPENDIENTESs(Int32 NID_DEPENDIENTE)
        {
            return DECLARACION_DEPENDIENTESs.FindIndex(p =>
                              p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }


        //private void _Add_DECLARACION_PERSONALES(Int32 NID_DOMICILIO_LABORAL, Int32 NID_DOMICILIO_PARTICULAR, String V_TELEFONO_LABORAL, String V_TELEFONO_PARTICULAR, String V_CORREO, Int32 NID_PAIS)
        //{
        //    this._DECLARACION_PERSONALES = new blld_DECLARACION_PERSONALES (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DOMICILIO_LABORAL, NID_DOMICILIO_PARTICULAR, V_TELEFONO_LABORAL, V_TELEFONO_PARTICULAR, V_CORREO, NID_PAIS) ;
        //}
        private void _Add_MODIFICACION(Boolean L_PRESENTO_DEC)
        {
            this._MODIFICACION = new blld_MODIFICACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, L_PRESENTO_DEC);
        }

        #endregion

        public void Reload_DECLARACION_ESCOLARIDADs()
        {
            _Reload_DECLARACION_ESCOLARIDADs();
        }
        public void Add_DECLARACION_ESCOLARIDADs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES)
        {
            _Add_DECLARACION_ESCOLARIDADs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_ESCOLARIDAD, V_INSTITUCION_EDUCATIVA, V_CARRERA, NID_ESTADO_ESCOLARIDAD, NID_DOCUMENTO_OBTENIDO, F_OBTENCION, NID_PAIS, E_OBSERVACIONES);
        }

        public void Reload_DECLARACION_EGRESOSs()
        {
            _Reload_DECLARACION_EGRESOSs();
        }
        public void Add_DECLARACION_EGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
        {
            _Add_DECLARACION_EGRESOSs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL);
        }


        public void Reload_DECLARACION_INGRESOSs()
        {
            _Reload_DECLARACION_INGRESOSs();
        }
        public void Add_DECLARACION_INGRESOSs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
        {
            _Add_DECLARACION_INGRESOSs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL);
        }

        public void Reload_DECLARACION_EXPERIENCIA_LABORALs()
        {
            _Reload_DECLARACION_EXPERIENCIA_LABORALs();
        }
        public void Add_DECLARACION_EXPERIENCIA_LABORALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES)
        {
            _Add_DECLARACION_EXPERIENCIA_LABORALs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, V_NOMBRE, V_RFC, V_AREA_ADSCRIPCION, V_PUESTO, V_FUNCION_PRINCIPAL, NID_SECTOR, F_INGRESO, F_EGRESO, NID_PAIS, E_OBSERVACIONES);
        }


        public void Reload_DECLARACION_REGIMEN_MATRIMONIALs()
        {
            _Reload_DECLARACION_REGIMEN_MATRIMONIALs();
        }
        public void Add_DECLARACION_REGIMEN_MATRIMONIALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN_MATRIMONIAL)
        {
            _Add_DECLARACION_REGIMEN_MATRIMONIALs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN_MATRIMONIAL);
        }


        public void Add_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES)
        {
            try
            {
                this._Add_DECLARACION_CARGO_OTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, VID_NOMBRE_ENTE, V_AREA_ADSCRIPCION, V_CARGO, L_HONORARIOS, V_NIVEL_EMPLEO, V_FUNCION_PRINCIPAL, F_POSESION, V_TEL_LABORAL, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_OBSERVACIONES);
            }
            catch (Exception ex)
            {
                if (ex is ExistingPrimaryKeyException)
                    this.DECLARACION_CARGO_OTRO = new blld_DECLARACION_CARGO_OTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                else
                    throw ex;
            }
        }

        private void _Add_DECLARACION_REGIMEN_MATRIMONIALs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN_MATRIMONIAL)
        {
            blld_DECLARACION_REGIMEN_MATRIMONIAL oDECLARACION_REGIMEN_MATRIMONIAL = new blld_DECLARACION_REGIMEN_MATRIMONIAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN_MATRIMONIAL);
            Reload_DECLARACION_REGIMEN_MATRIMONIALs();
            //if (oDECLARACION_REGIMEN_MATRIMONIAL.lEsNuevoRegistro.Value) DECLARACION_REGIMEN_MATRIMONIALs.Add(oDECLARACION_REGIMEN_MATRIMONIAL);
            //DECLARACION_REGIMEN_MATRIMONIALs[FindIndex_DECLARACION_REGIMEN_MATRIMONIALs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN)] = oDECLARACION_REGIMEN_MATRIMONIAL;
        }

        #endregion

    }
}
