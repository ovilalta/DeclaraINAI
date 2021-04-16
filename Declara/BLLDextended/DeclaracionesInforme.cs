using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.BLLD
{
    [Serializable]
    public class DeclaracionesInforme
    {
        public String V_FECHA_CONSULTA { get;  set; }
        public String V_HORA_CONSULTA { get;  set; }
        public String V_RFC { get;  set; }
        public String V_CURP { get;  set; }
        public String V_NOMBRE { get;  set; }
        public String V_SELLO { get;  set; }
        public List<DeclaracionesInformeDetalle> DECLARACIONES { get; set; }

        public DeclaracionesInforme()
        {
        }
        public DeclaracionesInforme(String V_RFC, String V_CURP, String V_NOMBRE, List<DeclaracionesInformeDetalle> DECLARACIONES)
        {
            DateTime now = DateTime.Now;
            this.V_FECHA_CONSULTA = now.ToString("dd/MM/yyyy");
            this.V_HORA_CONSULTA = now.ToString("HH:mm:ss");
            this.V_RFC = V_RFC;
            this.V_CURP = V_CURP;
            this.V_NOMBRE = V_NOMBRE;
            this.DECLARACIONES = DECLARACIONES;
            this.V_SELLO = CreaSello(String.Concat(V_HORA_CONSULTA, V_RFC, V_FECHA_CONSULTA));
        }

        private String CreaSello(string str)
        {
            String strOverride = "87A580CCC9D62AC";
            String strEncodedUser = String.Empty;

            System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] stream = null;
            Byte[] byt = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(str, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            byt = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            strEncodedUser = Convert.ToBase64String(byt);

            sb = null;
            stream = null;
            sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(strEncodedUser, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            return sb.ToString().ToUpper();
        }
    }

    [Serializable]
    public class DeclaracionesInformeDetalle
    {
        public Int32 NID_ORIGEN { get; set; }
        public String C_EJERCICIO { get; set; }
        public Int32 NID_DECLARACION { get; set; }
        public Int32 NID_TIPO_DECLARACION { get; set; }
        public String V_TIPO_DECLARACION { get; set; }
        public String F_PRESENTACION  { get; set; }
        public Int32 NID_ESTADO { get; set; }
        public String V_ESTADO { get; set; }

        public DeclaracionesInformeDetalle() { }
        public DeclaracionesInformeDetalle(Int32 NID_ORIGEN,String C_EJERCICIO,Int32 NID_DECLARACION, Int32 NID_TIPO_DECLARACION, String F_PRESENTACION, System.Nullable<Int32> NID_ESTADO)
        {
            this.NID_ORIGEN = NID_ORIGEN;
            this.C_EJERCICIO = C_EJERCICIO;
            this.NID_DECLARACION = NID_DECLARACION;
            this.NID_TIPO_DECLARACION = NID_TIPO_DECLARACION;
            this.F_PRESENTACION = F_PRESENTACION;
            blld_CAT_TIPO_DECLARACION oCAT = new blld_CAT_TIPO_DECLARACION(NID_TIPO_DECLARACION);
            this.V_TIPO_DECLARACION = oCAT.V_TIPO_DECLARACION;
            if (NID_ESTADO.HasValue)
            {
                this.NID_ESTADO = NID_ESTADO.Value;
                blld_CAT_ESTADO_DECLARACION oCAT_EDO = new blld_CAT_ESTADO_DECLARACION(NID_ESTADO.Value);
                this.V_ESTADO = oCAT_EDO.V_ESTADO;
            }
            else
            {
                this.NID_ESTADO = 0;
                this.V_ESTADO = "Sin Información";
            }
        }
    }
}
