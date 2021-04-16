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
    public  class blld__l_USUARIO_DOMICILIO : bll__l_USUARIO_DOMICILIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_USUARIO_DOMICILIO.PageSize;
            set => datos_USUARIO_DOMICILIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_USUARIO_DOMICILIO.PageNumber;
            set => datos_USUARIO_DOMICILIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_USUARIO_DOMICILIO.TotalPages;

        public Int32 TotalItems => datos_USUARIO_DOMICILIO.TotalItems;

        private List<blld_USUARIO_DOMICILIO> _USUARIO_DOMICILIOs { get; set; }
        public List<blld_USUARIO_DOMICILIO> USUARIO_DOMICILIOs
        {
            get
            {
                if (_USUARIO_DOMICILIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _USUARIO_DOMICILIOs = new List<blld_USUARIO_DOMICILIO>();
                    foreach (MODELDeclara_V2.USUARIO_DOMICILIO o in base_USUARIO_DOMICILIOs)
                    {
                        _USUARIO_DOMICILIOs.Add(new blld_USUARIO_DOMICILIO(o));
                    }
                }
                return _USUARIO_DOMICILIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_USUARIO_DOMICILIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_USUARIO_DOMICILIO.single_select();
        }

     #endregion

    }
}
