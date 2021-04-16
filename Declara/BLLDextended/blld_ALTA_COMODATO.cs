using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_COMODATO : bll_ALTA_COMODATO
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_ALTA_COMODATO.VID_NOMBRE;
//    new public String VID_FECHA => datos_ALTA_COMODATO.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_ALTA_COMODATO.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_ALTA_COMODATO.NID_DECLARACION;
//    new public Int32 NID_COMODATO => datos_ALTA_COMODATO.NID_COMODATO;
//    new public String CID_TIPO_PERSONA
//        {
//            get => datos_ALTA_COMODATO.CID_TIPO_PERSONA;
//            set => datos_ALTA_COMODATO.CID_TIPO_PERSONA = value;
//        }
//    new public String E_TITULAR
//        {
//            get => datos_ALTA_COMODATO.E_TITULAR;
//            set => datos_ALTA_COMODATO.E_TITULAR = value;
//        }
//    new public String E_RFC
//        {
//            get => datos_ALTA_COMODATO.E_RFC;
//            set => datos_ALTA_COMODATO.E_RFC = value;
//        }
//    new public Int32 NID_TIPO_RELACION
//        {
//            get => datos_ALTA_COMODATO.NID_TIPO_RELACION;
//            set => datos_ALTA_COMODATO.NID_TIPO_RELACION = value;
//        }
//    new public String E_OBSERVACIONES
//        {
//            get => datos_ALTA_COMODATO.E_OBSERVACIONES;
//            set => datos_ALTA_COMODATO.E_OBSERVACIONES = value;
//        }
//    new public String E_OBSERVACIONES_MARCADO
//        {
//            get => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO;
//            set => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO = value;
//        }
//    new public String V_OBSERVACIONES_TESTADO
//        {
//            get => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO;
//            set => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO = value;
//        }
//    new public Int32 NID_ESTADO_TESTADO => datos_ALTA_COMODATO.NID_ESTADO_TESTADO;
        private Int32 NID_ESTADO_TESTADOInicial => 0;
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_COMODATO.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_COMODATO.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_COMODATO.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_COMODATO.E_OBSERVACIONES = Encripta(value);
            }
        }

        //new public String E_OBSERVACIONES_MARCADO
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO))
        //            return String.Empty;
        //        return DesEncripta(datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO);
        //    }
        //    set
        //    {
        //        ValidarEstadoTestado(NID_ESTADO_TESTADO);

        //        if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
        //        {
        //            datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO = String.Empty;
        //            datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO = String.Empty;
        //        }
        //        else
        //        {
        //            datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO = Encripta(value);
        //            datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO = Testa(value);

        //        }
        //    }
        //}
       // new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO) ? String.Empty : datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO.Replace("¦", "█");


        #endregion


        #region *** Constructores ***
        public blld_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_COMODATO = NID_COMODATO; 
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.E_TITULAR = E_TITULAR;
            this.E_RFC = E_RFC;
            this.NID_TIPO_RELACION = NID_TIPO_RELACION;
            this.E_OBSERVACIONES = E_OBSERVACIONES;
            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
            datos_ALTA_COMODATO.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
            datos_ALTA_COMODATO = new dald_ALTA_COMODATO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.CID_TIPO_PERSONA, this.E_TITULAR, this.E_RFC, this.NID_TIPO_RELACION, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        }
        public blld_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_COMODATO = dald_ALTA_COMODATO.nNuevo_NID_COMODATO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.E_TITULAR = E_TITULAR;
            this.E_RFC = E_RFC;
            this.NID_TIPO_RELACION = NID_TIPO_RELACION;
            if (!String.IsNullOrEmpty(E_OBSERVACIONES)) E_OBSERVACIONES = Encripta(E_OBSERVACIONES);
            this.E_OBSERVACIONES = E_OBSERVACIONES;
            this.E_OBSERVACIONES_MARCADO = null;
            this.V_OBSERVACIONES_TESTADO = null;
            datos_ALTA_COMODATO.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
            datos_ALTA_COMODATO = new dald_ALTA_COMODATO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.CID_TIPO_PERSONA, this.E_TITULAR, this.E_RFC, this.NID_TIPO_RELACION, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
