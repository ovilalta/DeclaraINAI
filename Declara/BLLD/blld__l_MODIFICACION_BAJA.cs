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
    public  class blld__l_MODIFICACION_BAJA : bll__l_MODIFICACION_BAJA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_BAJA.PageSize;
            set => datos_MODIFICACION_BAJA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_BAJA.PageNumber;
            set => datos_MODIFICACION_BAJA.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_BAJA.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_BAJA.TotalItems;

        private List<blld_MODIFICACION_BAJA> _MODIFICACION_BAJAs { get; set; }
        public List<blld_MODIFICACION_BAJA> MODIFICACION_BAJAs
        {
            get
            {
                if (_MODIFICACION_BAJAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_BAJAs = new List<blld_MODIFICACION_BAJA>();
                    foreach (MODELDeclara_V2.MODIFICACION_BAJA o in base_MODIFICACION_BAJAs)
                    {
                        _MODIFICACION_BAJAs.Add(new blld_MODIFICACION_BAJA(o));
                    }
                }
                return _MODIFICACION_BAJAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_BAJA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_BAJA.single_select();
        }

     #endregion

    }
}
