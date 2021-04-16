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
    public  class blld__l_CONFLICTO_ENCABEZADO : bll__l_CONFLICTO_ENCABEZADO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CONFLICTO_ENCABEZADO.PageSize;
            set => datos_CONFLICTO_ENCABEZADO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CONFLICTO_ENCABEZADO.PageNumber;
            set => datos_CONFLICTO_ENCABEZADO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CONFLICTO_ENCABEZADO.TotalPages;

        public Int32 TotalItems => datos_CONFLICTO_ENCABEZADO.TotalItems;

        private List<blld_CONFLICTO_ENCABEZADO> _CONFLICTO_ENCABEZADOs { get; set; }
        public List<blld_CONFLICTO_ENCABEZADO> CONFLICTO_ENCABEZADOs
        {
            get
            {
                if (_CONFLICTO_ENCABEZADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CONFLICTO_ENCABEZADOs = new List<blld_CONFLICTO_ENCABEZADO>();
                    foreach (MODELDeclara_V2.CONFLICTO_ENCABEZADO o in base_CONFLICTO_ENCABEZADOs)
                    {
                        _CONFLICTO_ENCABEZADOs.Add(new blld_CONFLICTO_ENCABEZADO(o));
                    }
                }
                return _CONFLICTO_ENCABEZADOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CONFLICTO_ENCABEZADO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CONFLICTO_ENCABEZADO.single_select();
        }

     #endregion

    }
}
