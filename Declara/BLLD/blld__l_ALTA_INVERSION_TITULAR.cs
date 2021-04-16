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
    public  class blld__l_ALTA_INVERSION_TITULAR : bll__l_ALTA_INVERSION_TITULAR
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_INVERSION_TITULAR.PageSize;
            set => datos_ALTA_INVERSION_TITULAR.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_INVERSION_TITULAR.PageNumber;
            set => datos_ALTA_INVERSION_TITULAR.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_INVERSION_TITULAR.TotalPages;

        public Int32 TotalItems => datos_ALTA_INVERSION_TITULAR.TotalItems;

        private List<blld_ALTA_INVERSION_TITULAR> _ALTA_INVERSION_TITULARs { get; set; }
        public List<blld_ALTA_INVERSION_TITULAR> ALTA_INVERSION_TITULARs
        {
            get
            {
                if (_ALTA_INVERSION_TITULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_INVERSION_TITULARs = new List<blld_ALTA_INVERSION_TITULAR>();
                    foreach (MODELDeclara_V2.ALTA_INVERSION_TITULAR o in base_ALTA_INVERSION_TITULARs)
                    {
                        _ALTA_INVERSION_TITULARs.Add(new blld_ALTA_INVERSION_TITULAR(o));
                    }
                }
                return _ALTA_INVERSION_TITULARs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_INVERSION_TITULAR() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_INVERSION_TITULAR.single_select();
        }

     #endregion

    }
}
