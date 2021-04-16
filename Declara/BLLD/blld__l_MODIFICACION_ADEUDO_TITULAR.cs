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
    public  class blld__l_MODIFICACION_ADEUDO_TITULAR : bll__l_MODIFICACION_ADEUDO_TITULAR
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_ADEUDO_TITULAR.PageSize;
            set => datos_MODIFICACION_ADEUDO_TITULAR.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_ADEUDO_TITULAR.PageNumber;
            set => datos_MODIFICACION_ADEUDO_TITULAR.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_ADEUDO_TITULAR.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_ADEUDO_TITULAR.TotalItems;

        private List<blld_MODIFICACION_ADEUDO_TITULAR> _MODIFICACION_ADEUDO_TITULARs { get; set; }
        public List<blld_MODIFICACION_ADEUDO_TITULAR> MODIFICACION_ADEUDO_TITULARs
        {
            get
            {
                if (_MODIFICACION_ADEUDO_TITULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_ADEUDO_TITULARs = new List<blld_MODIFICACION_ADEUDO_TITULAR>();
                    foreach (MODELDeclara_V2.MODIFICACION_ADEUDO_TITULAR o in base_MODIFICACION_ADEUDO_TITULARs)
                    {
                        _MODIFICACION_ADEUDO_TITULARs.Add(new blld_MODIFICACION_ADEUDO_TITULAR(o));
                    }
                }
                return _MODIFICACION_ADEUDO_TITULARs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_ADEUDO_TITULAR() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_ADEUDO_TITULAR.single_select();
        }

     #endregion

    }
}
