﻿using Declara_V2.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Declara_V2.BLL
{
    public class _bllSistema
    {
        public string Encripta(string Cadena)
        {
            if (String.IsNullOrEmpty(Cadena))
                return String.Empty;
            Cadena = Cadena.Replace("</", String.Empty)
                      .Replace("/>", String.Empty)
                      .Replace(">", String.Empty)
                      .Replace("<", String.Empty);
            Cadena = System.Net.WebUtility.HtmlEncode(Cadena);
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(AjaxControIToolkit.TextBox.Clave, AjaxControIToolkit.TextBox.IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return String.Concat('|', Convert.ToBase64String(encripted), '|');
        }
        public string DesEncripta(string Cadena)
        {
            if (String.IsNullOrEmpty(Cadena))
                return String.Empty;
            Cadena = Cadena.Trim('|');
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(AjaxControIToolkit.TextBox.Clave, AjaxControIToolkit.TextBox.IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return System.Net.WebUtility.HtmlDecode(textoLimpio);
        }
        public static string DesEncriptaStatic(string Cadena)
        {
            if (String.IsNullOrEmpty(Cadena))
                return String.Empty;
            Cadena = Cadena.Trim('|');
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(AjaxControIToolkit.TextBox.Clave, AjaxControIToolkit.TextBox.IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return System.Net.WebUtility.HtmlDecode(textoLimpio);
        }
        public string Encripta(String Cadena, Byte[] Key1, Byte[] Key2)
        {
            Cadena = System.Net.WebUtility.HtmlEncode(Cadena);
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Key1, Key2), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return String.Concat('|', Convert.ToBase64String(encripted), '|');
        }
        public string DesEncripta(string Cadena, Byte[] Key1, Byte[] Key2)
        {
            Cadena = Cadena.Trim('|');
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Key1, Key2), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return System.Net.WebUtility.HtmlDecode(textoLimpio);
        }

        //Validación de formato de correo electrónico
        //OEVM 20230606
        public static bool IsValidEmail(string email)
        {
            // Expresión regular para validar el formato del correo electrónico
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Validar el formato utilizando la expresión regular
            bool isValid = Regex.IsMatch(email, pattern);

            return isValid;
        }

        public static Boolean EnviarCorreo(String vCorreo, String vAsunto, String vContenido)
        {

            SmtpClient smtpClient = new SmtpClient(BLLD.clsSistema.ServidorCorreo, BLLD.clsSistema.PuertoCorreo);
            
            smtpClient.Credentials = new System.Net.NetworkCredential("oscar.vilalta@inai.mx", "M414valeria&");
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(BLLD.clsSistema.CorreoSalida, "DeclaraInai");
            mail.To.Add(new MailAddress(vCorreo));
            mail.To.Add(new MailAddress(BLLD.clsSistema.CorreoSalida));
            mail.Subject = vAsunto;
            mail.Body = vContenido;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
            //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string Base64_Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }

        public static string Base64_Decode(string str)
        {

            byte[] decbuff = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }

        public static int InsertaRfcCambioAcuse(string rfc)
        {
            #region Logica agregar a tabla el RFC  que se autorizara para actualizar acuse fiscal

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;
            string sql = "SP_InsertaRfcAcuseFiscal";
            int rpta = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rfc", rfc.ToUpper());

                        rpta = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    rpta = 0;
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            return rpta;
            #endregion

        }
        // SME-NF-I
        protected String Testa(String value)
        {

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
            return asing;
        }

        protected void ValidarEstadoTestado(int nID_ESTADO_TESTADO)
        {
            switch (nID_ESTADO_TESTADO)
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
        }
        // SME-NF-F


        public _bllSistema()
        { }

        

    }
}
