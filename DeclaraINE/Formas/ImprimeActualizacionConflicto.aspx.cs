using Declara_V2.BLLD;
using DeclaraINE.Formas.DeclaracionInicial;
using DeclaraINE.Formas.DeclaracionModificacion;
using DeclaraINE.Formas.DeclaracionConclusion;
using DeclaraINE.Formas.DeclaracionConflicto;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINE.file;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

namespace DeclaraINE.Formas
{
    public partial class ImprimeActualizacionConflicto : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        blld_DECLARACION _oDeclaracionTemp
        {
            get => (blld_DECLARACION)Session["oDeclaracionTemp"];
            set => SessionAdd("oDeclaracionTemp", value);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (_oDeclaracionTemp == null)
            {
                _oDeclaracionTemp = _oDeclaracion;
                _oDeclaracion = null;
            }

            int nTipoDeclaracion = _oDeclaracionTemp.NID_TIPO;

            switch (nTipoDeclaracion)
            {
                
                
                default:
                    break;
            }

            lblIdentificacion.Text = string.Concat(_oDeclaracionTemp.VID_NOMBRE, _oDeclaracionTemp.VID_FECHA, _oDeclaracionTemp.VID_HOMOCLAVE, " - ", _oUsuario.V_NOMBRE_COMPLETO);
            lblEjercicio.Text = string.Concat("Ejercicio :", _oDeclaracionTemp.C_EJERCICIO);

            btnAcuseEnvio.CssClass = "big pdf";
           
        }

        protected void btnAcuseEnvio_Click(object sender, EventArgs e)
        {

            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                //blld_DECLARACION oDeclaracion = _oDeclaracion;
                //Recuperar numero de ultima declaracion
                int numeroDeclaracion = 0;
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;
                string sql = "SP_RecuperaUltimaDeclaracion";
                string ultimaDeclaracion = "";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand.Parameters.Add(new SqlParameter("@vid_nombre", oUsuario.VID_NOMBRE));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@vid_fecha", oUsuario.VID_FECHA));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@vid_homo", oUsuario.VID_HOMOCLAVE));
                            

                            DataTable dt = new DataTable();
                            dt.Clear();
                            da.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                ultimaDeclaracion = dt.Rows[i]["NID_DECLARACION"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

                numeroDeclaracion = Convert.ToInt32( ultimaDeclaracion);
                //
                String VersionDeclaracion = "DECLARACION_ACTUALIZA_CONFLICTO";

                file.fileSoapClient o = new file.fileSoapClient();

                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
                                                                               ,numeroDeclaracion
                                                                               ,"Preliminarx"}.ToArray());
                byte[] b1 = sf.FileBytes;
                FileStream fs1;
                String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                fs1 = new FileStream(File, FileMode.Create);
                fs1.Write(b1, 0, b1.Length);
                fs1.Close();
                fs1 = null;

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);

                HttpContext.Current.Response.WriteFile(File);
                HttpContext.Current.Response.Flush();
                System.IO.File.Delete(File);
                HttpContext.Current.Response.End();
                
            }
            catch (Exception ex)
            {
            }

            //try
            //{
            //    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            //    String HASH = null;
            //    HASH = db.DECLARACION.Find(_oDeclaracionTemp.VID_NOMBRE, _oDeclaracionTemp.VID_FECHA, _oDeclaracionTemp.VID_HOMOCLAVE, _oDeclaracionTemp.NID_DECLARACION).V_HASH;

            //    if (HASH == null)
            //    {
            //        String File = "";
            //        byte[] b1 = null;
            //        String VersionDeclaracion = string.Empty;
            //        MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

            //        int nTipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().NID_TIPO_DECLARACION;
            //        string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

            //        blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            //        oPuesto.select();
            //        var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(_oDeclaracionTemp.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

            //        switch (nTipoDeclaracion)
            //        {
            //            case 1:
            //                if (obligado.Equals(true))
            //                    VersionDeclaracion = "DECLARACION_INICIAL";
            //                else
            //                    VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI";
            //                break;
            //            case 2:
            //                if (obligado.Equals(true))
            //                    VersionDeclaracion = "DECLARACION_MODIFICACION";
            //                else
            //                    VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI";
            //                break;
            //            case 3:
            //                if (obligado.Equals(true))
            //                    VersionDeclaracion = "DECLARACION_CONCLUSION";
            //                else
            //                    VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI";
            //                break;
            //        }

            //        file.fileSoapClient o = new file.fileSoapClient();
            //        SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { _oDeclaracionTemp.VID_NOMBRE
            //                                                                   ,_oDeclaracionTemp.VID_FECHA
            //                                                                   ,_oDeclaracionTemp.VID_HOMOCLAVE
            //                                                                   ,_oDeclaracionTemp.NID_DECLARACION
            //                                                                   ,"Preliminarx"}.ToArray());
            //        registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
            //        registro.B_FILE_DECLARACION = sf.FileBytes;
            //        db.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

        }


        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        
        protected void btnAcuseDeclaracion_Click(object sender, EventArgs e)
        {
            try
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                byte[] b1 = null;
                String VersionDeclaracion = string.Empty;

                //registro = db.DECLARACION.Find(_oDeclaracionTemp.VID_NOMBRE, _oDeclaracionTemp.VID_FECHA, _oDeclaracionTemp.VID_HOMOCLAVE, _oDeclaracionTemp.NID_DECLARACION);
                b1 = registro.B_FILE_DECLARACION;

                int nTipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().NID_TIPO_DECLARACION;
                string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

                if (b1 == null)
                {
                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                    oPuesto.select();
                    var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(_oDeclaracionTemp.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

                    //var obligado = db.CAT_PUESTO.Where(p => p.NID_PUESTO.Equals(_oDeclaracionTemp.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

                    switch (nTipoDeclaracion)
                    {
                        case 1:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_INICIAL";
                            else
                                VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI";
                            break;
                        case 2:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_MODIFICACION";
                            else
                                VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI";
                            break;
                        case 3:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_CONCLUSION";
                            else
                                VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI";
                            break;
                    }

                    file.fileSoapClient o = new file.fileSoapClient();
                    SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { _oDeclaracionTemp.VID_NOMBRE
                                                                               ,_oDeclaracionTemp.VID_FECHA
                                                                               ,_oDeclaracionTemp.VID_HOMOCLAVE
                                                                               ,_oDeclaracionTemp.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges();

                }

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE + ".pdf");
                Response.OutputStream.Write(registro.B_FILE_DECLARACION, 0, registro.B_FILE_DECLARACION.Length);
                Response.OutputStream.Close();
                Response.Flush();
                Response.End();


            }
            catch (Exception ex)
            {

            }
        }





        protected void btnAcuseEtica_Click(object sender, EventArgs e)
        {
            try
            {
                string vTipoAcuse = string.Empty;
                switch (_oDeclaracionTemp.NID_TIPO_DECLARACION)
                {
                    case 1:
                        vTipoAcuse = "ACUSE_CONSTANCIA_ETICA_DI";
                        break;
                    case 2:
                        vTipoAcuse = "ACUSE_CONSTANCIA_ETICA_DM";
                        break;
                    default:
                        break;
                }

                file.fileSoapClient o = new file.fileSoapClient();
                FileStream fs1;
                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, vTipoAcuse, new List<object> { _oUsuario.VID_NOMBRE
                                                                               ,_oUsuario.VID_FECHA
                                                                               ,_oUsuario.VID_HOMOCLAVE
                                                                               ,_oDeclaracionTemp.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
                Response.OutputStream.Write(sf.FileBytes, 0, sf.FileBytes.Length);
                Response.OutputStream.Close();
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAcuseConducta_Click(object sender, EventArgs e)
        {
            try
            {
                string vTipoAcuse = string.Empty;
                if (_oDeclaracionTemp.NID_TIPO_DECLARACION == 1 || _oDeclaracionTemp.NID_TIPO_DECLARACION == 2)
                {

                    vTipoAcuse = "ACUSE_CONSTANCIA_CONDUCTA";
                }


                file.fileSoapClient o = new file.fileSoapClient();
                FileStream fs1;
                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, vTipoAcuse, new List<object> { _oUsuario.VID_NOMBRE
                                                                               ,_oUsuario.VID_FECHA
                                                                               ,_oUsuario.VID_HOMOCLAVE
                                                                               ,_oDeclaracionTemp.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
                Response.OutputStream.Write(sf.FileBytes, 0, sf.FileBytes.Length);
                Response.OutputStream.Close();
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }

        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }

    }
}