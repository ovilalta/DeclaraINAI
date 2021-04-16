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
    public  class blld__l_PATRIMONIO_TITULAR : bll__l_PATRIMONIO_TITULAR
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_TITULAR.PageSize;
            set => datos_PATRIMONIO_TITULAR.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_TITULAR.PageNumber;
            set => datos_PATRIMONIO_TITULAR.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_TITULAR.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_TITULAR.TotalItems;

        private List<blld_PATRIMONIO_TITULAR> _PATRIMONIO_TITULARs { get; set; }
        public List<blld_PATRIMONIO_TITULAR> PATRIMONIO_TITULARs
        {
            get
            {
                if (_PATRIMONIO_TITULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_TITULARs = new List<blld_PATRIMONIO_TITULAR>();
                    foreach (MODELDeclara_V2.PATRIMONIO_TITULAR o in base_PATRIMONIO_TITULARs)
                    {
                        _PATRIMONIO_TITULARs.Add(new blld_PATRIMONIO_TITULAR(o));
                    }
                }
                return _PATRIMONIO_TITULARs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_TITULAR() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_TITULAR.single_select();
        }

     #endregion

    }
}
