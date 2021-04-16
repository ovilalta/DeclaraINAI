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
    public  class blld__l_USUARIO : bll__l_USUARIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_USUARIO.PageSize;
            set => datos_USUARIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_USUARIO.PageNumber;
            set => datos_USUARIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_USUARIO.TotalPages;

        public Int32 TotalItems => datos_USUARIO.TotalItems;

        private List<blld_USUARIO> _USUARIOs { get; set; }
        public List<blld_USUARIO> USUARIOs
        {
            get
            {
                if (_USUARIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _USUARIOs = new List<blld_USUARIO>();
                    foreach (MODELDeclara_V2.USUARIO o in base_USUARIOs)
                    {
                        _USUARIOs.Add(new blld_USUARIO(o));
                    }
                }
                return _USUARIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_USUARIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_USUARIO.single_select();
        }

     #endregion

    }
}
