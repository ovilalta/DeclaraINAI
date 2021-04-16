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
    public  class blld__l_CAT_TIPO_BAJA : bll__l_CAT_TIPO_BAJA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_BAJA.PageSize;
            set => datos_CAT_TIPO_BAJA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_BAJA.PageNumber;
            set => datos_CAT_TIPO_BAJA.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_BAJA.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_BAJA.TotalItems;

        private List<blld_CAT_TIPO_BAJA> _CAT_TIPO_BAJAs { get; set; }
        public List<blld_CAT_TIPO_BAJA> CAT_TIPO_BAJAs
        {
            get
            {
                if (_CAT_TIPO_BAJAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_BAJAs = new List<blld_CAT_TIPO_BAJA>();
                    foreach (MODELDeclara_V2.CAT_TIPO_BAJA o in base_CAT_TIPO_BAJAs)
                    {
                        _CAT_TIPO_BAJAs.Add(new blld_CAT_TIPO_BAJA(o));
                    }
                }
                return _CAT_TIPO_BAJAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_BAJA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_BAJA.single_select();
        }

     #endregion

    }
}
