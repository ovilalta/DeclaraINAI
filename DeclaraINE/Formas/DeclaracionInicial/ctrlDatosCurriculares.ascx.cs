using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionInicial
{
    public partial class ctrlDatosCurriculares : System.Web.UI.UserControl
    {
        public Int32 Id
        { 
            get => ViewState["id"] != null ? (Int32)ViewState["id"] : -1;
            set
            {
                if (ViewState["id"] == null)
                    ViewState.Add("id", value);
                else
                    ViewState["id"] = value;
            }
        }

        public String Keys
        {
            get => ViewState["Keys"] != null ? (String)ViewState["Keys"] : String.Empty;
            set
            {
                if (ViewState["Keys"] == null)
                    ViewState.Add("Keys", value);
                else
                    ViewState["Keys"] = value;
            }
        }

        public String ImageUrl
        {
            get => img.ImageUrl;
            set => img.ImageUrl = value;
        }

        public String TextoPrincipal
        {
            get => ltrPrincipal.Text;
            set => ltrPrincipal.Text = value;
        }

        public String TextoSecundario
        {
            get => ltrSecundario.Text;
            set => ltrSecundario.Text = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public delegate void EditarHandler(object sender, DatosCurricularesEventArgs e);
        public event EditarHandler Editar;

        public delegate void EliminarHandler(object sender, DatosCurricularesEventArgs e);
        public event EliminarHandler Eliminar;

        public void Edita(Object Sender, EventArgs e)
        {
            DatosCurricularesEventArgs ee = new DatosCurricularesEventArgs
            {
                Keys = this.Keys,
                Id = this.Id,
            };

            OnEditar(this, ee);
        }

        public void Elimina(Object Sender, EventArgs e)
        {
            DatosCurricularesEventArgs ee = new DatosCurricularesEventArgs
            {
                Keys = this.Keys,
                Id = this.Id,
            };

            OnEliminar(this, ee);
        }

        protected virtual void OnEditar(Object Sender, DatosCurricularesEventArgs e)
        {
            Editar?.Invoke(Sender, e);
        }

        protected virtual void OnEliminar(Object Sender, DatosCurricularesEventArgs e)
        {
            Eliminar?.Invoke(Sender, e);
        }
    }

    public class DatosCurricularesEventArgs : EventArgs
    {
        public string Keys { get; set; }
        public int Id { get; set; }
    }
}