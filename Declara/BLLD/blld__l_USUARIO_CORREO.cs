using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public  class blld__l_USUARIO_CORREO : bll__l_USUARIO_CORREO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_USUARIO_CORREO.PageSize;
            set => datos_USUARIO_CORREO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_USUARIO_CORREO.PageNumber;
            set => datos_USUARIO_CORREO.PageNumber = value;
        }

        public Int32 TotalPages => datos_USUARIO_CORREO.TotalPages;

        public Int32 TotalItems => datos_USUARIO_CORREO.TotalItems;

        private List<blld_USUARIO_CORREO> _USUARIO_CORREOs { get; set; }
        public List<blld_USUARIO_CORREO> USUARIO_CORREOs
        {
            get
            {
                if (_USUARIO_CORREOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _USUARIO_CORREOs = new List<blld_USUARIO_CORREO>();
                    foreach (MODELDeclara_V2.USUARIO_CORREO o in base_USUARIO_CORREOs)
                    {
                        _USUARIO_CORREOs.Add(new blld_USUARIO_CORREO(o));
                    }
                }
                return _USUARIO_CORREOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_USUARIO_CORREO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_USUARIO_CORREO.single_select();
        }

     #endregion

    }
}
