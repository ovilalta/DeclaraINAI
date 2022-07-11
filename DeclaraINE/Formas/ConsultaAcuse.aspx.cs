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

namespace DeclaraINE.Formas
{
    public partial class ConsultaAcuse : Pagina
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
                case 1:
                    pnlAcuseEtica.Visible = true;
                    pnlAcuseConducta.Visible = true;
                    break;
                case 2:
                    pnlAcuseEtica.Visible = true;
                    pnlAcuseConducta.Visible = true;
                    break;
                case 3:
                    pnlAcuseEtica.Visible = false;
                    pnlAcuseConducta.Visible = false;
                    break;
                default:
                    break;
            }

            lblIdentificacion.Text = string.Concat(_oDeclaracionTemp.VID_NOMBRE, _oDeclaracionTemp.VID_FECHA, _oDeclaracionTemp.VID_HOMOCLAVE, " - ", _oUsuario.V_NOMBRE_COMPLETO);
            lblEjercicio.Text = string.Concat("Ejercicio :", _oDeclaracionTemp.C_EJERCICIO);

            btnAcuseEnvio.CssClass = "big pdf";
            btnAcuseDeclaracion.CssClass = "big pdf";
            btnAcuseEtica.CssClass = "big pdf";
            btnAcuseConducta.CssClass = "big pdf";
        }

        protected void btnAcuseEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                String HASH = null;
                HASH = db.DECLARACION.Find(_oDeclaracionTemp.VID_NOMBRE, _oDeclaracionTemp.VID_FECHA, _oDeclaracionTemp.VID_HOMOCLAVE, _oDeclaracionTemp.NID_DECLARACION).V_HASH;

                if (HASH == null)
                {
                    String File = "";
                    byte[] b1 = null;
                    String VersionDeclaracion = string.Empty;
                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                    int nTipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().NID_TIPO_DECLARACION;
                    string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == _oDeclaracionTemp.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                    oPuesto.select();
                    var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(_oDeclaracionTemp.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

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
            }
            catch (Exception ex)
            {
            }
            lbMensaje.Text = "Mensaje generado";
            if (_oDeclaracionTemp.NID_TIPO == 1)
                _Inicial.ImprimirAcuseInicial(_oDeclaracionTemp, _oUsuario);

            if (_oDeclaracionTemp.NID_TIPO == 2)
                _Modificacion.ImprimirAcuseModificacion(_oDeclaracionTemp, _oUsuario);

            if (_oDeclaracionTemp.NID_TIPO == 3)
                _Conclusion.ImprimirAcuseConclusion(_oDeclaracionTemp, _oUsuario);

            lbMensaje.Text = "Mensaje generado";
        }


        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnConcluirDeclaracion_Click(object sender, EventArgs e)
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