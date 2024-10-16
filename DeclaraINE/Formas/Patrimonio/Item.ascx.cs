using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.Patrimonio
{
    public partial class Item : System.Web.UI.UserControl
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

        public delegate void EditarHandler(object sender, ItemEventArgs e);
        public event EditarHandler Editar;

        public void Edita(Object Sender, EventArgs e)
        {
            ItemEventArgs ee = new ItemEventArgs
            {
                Keys = this.Keys,
                Id = this.Id,
                //Type = this.Type,
            };

            OnEditar(this, ee);
        }


        protected virtual void OnEditar(Object Sender, ItemEventArgs e)
        {
            Editar?.Invoke(Sender, e);
        }

    }

    public class ItemEventArgs : EventArgs
    {
        public string Keys { get; set; }
        public int Id { get; set; }
        public String Type {get;set;}
    }
}