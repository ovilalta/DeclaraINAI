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
    public  class blld__l_CAT_SEGUNDO_NIVEL : bll__l_CAT_SEGUNDO_NIVEL
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_SEGUNDO_NIVEL.PageSize;
            set => datos_CAT_SEGUNDO_NIVEL.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_SEGUNDO_NIVEL.PageNumber;
            set => datos_CAT_SEGUNDO_NIVEL.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_SEGUNDO_NIVEL.TotalPages;

        public Int32 TotalItems => datos_CAT_SEGUNDO_NIVEL.TotalItems;

        private List<blld_CAT_SEGUNDO_NIVEL> _CAT_SEGUNDO_NIVELs { get; set; }
        public List<blld_CAT_SEGUNDO_NIVEL> CAT_SEGUNDO_NIVELs
        {
            get
            {
                if (_CAT_SEGUNDO_NIVELs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_SEGUNDO_NIVELs = new List<blld_CAT_SEGUNDO_NIVEL>();
                    foreach (MODELDeclara_V2.CAT_SEGUNDO_NIVEL o in base_CAT_SEGUNDO_NIVELs)
                    {
                        _CAT_SEGUNDO_NIVELs.Add(new blld_CAT_SEGUNDO_NIVEL(o));
                    }
                }
                return _CAT_SEGUNDO_NIVELs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_SEGUNDO_NIVEL() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_SEGUNDO_NIVEL.single_select();
        }

     #endregion

    }
}
