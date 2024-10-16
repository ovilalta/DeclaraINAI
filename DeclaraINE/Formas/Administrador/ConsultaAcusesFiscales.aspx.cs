using Declara_V2.BLLD;
using System;
using System.IO;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Spire.Xls;
using System.Windows.Forms;
using System.Linq;
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;
using Declara_V2.BLL;

namespace DeclaraINAI.Formas.Administrador
{
    public partial class ConsultaAcusesFiscales : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
        }


        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }


        protected void btnConsultaAcuse(object sender, EventArgs e)
        {
            if (txtRfc.Text.Length == 13)
            {
                try
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    string connString = db.Database.Connection.ConnectionString;
                    int existeUsuario = db.USUARIO.Where(p => p.VID_NOMBRE.Equals(txtRfc.Text.Substring(0, 4))
                    && p.VID_FECHA.Equals(txtRfc.Text.Substring(4, 6)) && p.VID_HOMOCLAVE.Equals(txtRfc.Text.Substring(10, 3))).Count();

                    if (existeUsuario != 0)
                    {
                        //Aqui buscar el nombre completo del usuario mediante el RFC capturado para buscar ahora por el nombre su archivo pdf
                        string rfcNombre = txtRfc.Text.Substring(0, 4);
                        string rfcFecha = txtRfc.Text.Substring(4, 6);
                        string rfcHomo = txtRfc.Text.Substring(10, 3);

                        string FileNameNombre = db.USUARIO
                            .Where(u => u.VID_NOMBRE == rfcNombre
                            && u.VID_FECHA == rfcFecha
                            && u.VID_HOMOCLAVE == rfcHomo)
                            .Select(u => u.V_NOMBRE ).First();     //txtRfc.Text;

                        string FileNamePAp = db.USUARIO
                            .Where(u => u.VID_NOMBRE == rfcNombre
                            && u.VID_FECHA == rfcFecha
                            && u.VID_HOMOCLAVE == rfcHomo)
                            .Select(u =>  u.V_PRIMER_A ).First();     //txtRfc.Text;

                        string FileNameSAp= db.USUARIO
                            .Where(u => u.VID_NOMBRE == rfcNombre
                            && u.VID_FECHA == rfcFecha
                            && u.VID_HOMOCLAVE == rfcHomo)
                            .Select(u =>  u.V_SEGUNDO_A).First();     //txtRfc.Text;

                        string FileName =  (FileNameNombre+FileNamePAp+FileNameSAp).Replace(" ","");

                        //Registra la búsqueda en bitácora
                        BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                            , "Búsqueda de acuse fiscal", "Se realiza la búsqueda del acuse fiscal del rfc: " + txtRfc.Text);

                        string anio = DateTime.Today.Year.ToString();
                        string rutaBase = HttpContext.Current.Server.MapPath("~") + "\\Formas\\DeclaracionFiscal\\";
                        string rutaDirectorio = "pdfFiscales\\" + anio;

                        string path = rutaDirectorio + "\\" + FileName + ".pdf";

                        bool existe = File.Exists(rutaBase + path);

                        if (existe)
                        {
                            pdfFiscal.Attributes["src"] = "../DeclaracionFiscal/" + rutaDirectorio + "\\" + FileName + ".pdf";
                        }
                        else
                        {
                            msgBox.ShowDanger("No se encontró el acuse fiscal con rfc" + txtRfc.Text.ToUpper());
                        }

                    }
                    else
                    {
                        msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc.Text.ToUpper());
                    }
                }
                catch (Exception ex)
                {
                    msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc.Text.ToUpper());
                }
            }
            else
            {
                msgBox.ShowDanger("El RFC no tiene 13 caracteres, por favor revise la información");
            }

        }

        protected void btnDarPermiso(object sender, EventArgs e)
        {
            if (txtRfc.Text.Length == 13)
            {
                int rpta = _bllSistema.InsertaRfcCambioAcuse(txtRfc.Text);
                if (rpta == -1)
                {
                    msgBox.ShowSuccess("Se agregó el RFC: " + txtRfc.Text.ToUpper() + " de manera correcta");
                    txtRfc.Text = "";
                }
                else
                {
                    msgBox.ShowWarning("Ya existe el RFC: " + txtRfc.Text.ToUpper() + " , favor de validar la información");
                    txtRfc.Text = "";
                }
            }
            else
            {
                msgBox.ShowDanger("El RFC no tiene 13 caracteres, por favor revise la información");
            }

        }

    }
}

