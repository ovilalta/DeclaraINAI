using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_DIARIA
    {

        #region *** Atributos extendidos ***


        public String V_RFC { get; set; }
        public String V_NOMBRE_COMPLETO { get; set; }

        public String V_NOMBRE_COMPLETO_ESTILO2 { get; set; }

        public String VID_NOMBRE { get; set; }
        public String VID_FECHA { get; set; }
        public String VID_HOMOCLAVE { get; set; }

        public Int32 NID_DECLARACION { get; set; }


        public String V_TIPO_DECLARACION { get; internal set; }
        public Int32 NID_TIPO_DECLARACION { get; internal set; }
        public String V_PRIMER_A { get; internal set; }
        public String V_SEGUNDO_A { get; internal set; }
        public String V_NOMBRE { get; internal set; }
        public bool L_AUTORIZA_PUBLICAR { get; internal set; }
        public String V_AUTORIZA_PUBLICAR => L_AUTORIZA_PUBLICAR ? "Si" : "No";
        public String V_PRIMER_NIVEL { get; internal set; }
        public String V_SEGUNDO_NIVEL { get; internal set; }
        public String V_PUESTO { get; internal set; }
        public String VID_PUESTO { get; internal set; }
        public String VID_NIVEL { get; internal set; }
        public String C_EJERCICIO { get; internal set; }

        public Int32 NID_ESTADO { get; internal set; }
        public String V_ESTADO { get; internal set; }

        public DateTime F_POSESION { get; internal set; }
        public DateTime F_REGISTRO { get; internal set; }


        public DateTime F_ENVIO { get; set; }
        public Int32 N_ENVIO_DIA { get; set; }
        public Int32 N_ENVIO_MES { get; set; }
        public Int32 N_ENVIO_ANIO { get; set; }
        public String V_ENVIO_MES => F_ENVIO.Date.ToString("MMMM");
        public Int32 NID_ESTADO_TESTADO { get; set; }
        public String V_ESTADO_TESTADO { get; set; }

        public enum Properties
        {



            V_RFC,
            V_NOMBRE_COMPLETO,

            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            V_ESTADO,

            F_POSESION,
            F_REGISTRO,
            F_ENVIO,
            V_PRIMER_A,
            V_SEGUNDO_A,
            V_NOMBRE,

            L_AUTORIZA_PUBLICAR,
            V_AUTORIZA_PUBLICAR,
            V_PRIMER_NIVEL,
            V_SEGUNDO_NIVEL,
            V_PUESTO,
            VID_PUESTO,
            VID_NIVEL,
            C_EJERCICIO,
            NID_TIPO_DECLARACION,
            NID_ESTADO,
            N_ENVIO_DIA,
            N_ENVIO_MES,
            N_ENVIO_ANIO,
            NID_ESTADO_TESTADO,
            V_ESTADO_TESTADO,
            V_TIPO_DECLARACION,
        }
        #endregion

    }
}
