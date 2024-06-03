﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class ItemGasto : System.Web.UI.UserControl
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

        public delegate void EliminarHandler(object sender, ItemEventArgs e);
        public event EliminarHandler Eliminar;


        public void Edita(Object Sender, EventArgs e)
        {
            ItemEventArgs ee = new ItemEventArgs
            {
                Id = this.Id,
            };

            OnEditar(this, ee);
        }
        public void Elimina(Object Sender, EventArgs e)
        {
            ItemEventArgs ee = new ItemEventArgs
            {
                Id = this.Id,
            };

            OnEliminar(this, ee);
        }


        protected virtual void OnEditar(Object Sender, ItemEventArgs e)
        {
            Editar?.Invoke(Sender, e);
        }
        protected virtual void OnEliminar(Object Sender, ItemEventArgs e)
        {
            Eliminar?.Invoke(Sender, e);
        }
    }


}