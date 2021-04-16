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
    public  class blld__l_USUARIO_SESION : bll__l_USUARIO_SESION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_USUARIO_SESION.PageSize;
            set => datos_USUARIO_SESION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_USUARIO_SESION.PageNumber;
            set => datos_USUARIO_SESION.PageNumber = value;
        }

        public Int32 TotalPages => datos_USUARIO_SESION.TotalPages;

        public Int32 TotalItems => datos_USUARIO_SESION.TotalItems;

        private List<blld_USUARIO_SESION> _USUARIO_SESIONs { get; set; }
        public List<blld_USUARIO_SESION> USUARIO_SESIONs
        {
            get
            {
                if (_USUARIO_SESIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _USUARIO_SESIONs = new List<blld_USUARIO_SESION>();
                    foreach (MODELDeclara_V2.USUARIO_SESION o in base_USUARIO_SESIONs)
                    {
                        _USUARIO_SESIONs.Add(new blld_USUARIO_SESION(o));
                    }
                }
                return _USUARIO_SESIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_USUARIO_SESION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_USUARIO_SESION.single_select();
        }

     #endregion

    }
}
