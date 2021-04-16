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
    public  class blld__l_CAT_ESTADO_CIVIL : bll__l_CAT_ESTADO_CIVIL
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_ESTADO_CIVIL.PageSize;
            set => datos_CAT_ESTADO_CIVIL.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_ESTADO_CIVIL.PageNumber;
            set => datos_CAT_ESTADO_CIVIL.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_ESTADO_CIVIL.TotalPages;

        public Int32 TotalItems => datos_CAT_ESTADO_CIVIL.TotalItems;

        private List<blld_CAT_ESTADO_CIVIL> _CAT_ESTADO_CIVILs { get; set; }
        public List<blld_CAT_ESTADO_CIVIL> CAT_ESTADO_CIVILs
        {
            get
            {
                if (_CAT_ESTADO_CIVILs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_ESTADO_CIVILs = new List<blld_CAT_ESTADO_CIVIL>();
                    foreach (MODELDeclara_V2.CAT_ESTADO_CIVIL o in base_CAT_ESTADO_CIVILs)
                    {
                        _CAT_ESTADO_CIVILs.Add(new blld_CAT_ESTADO_CIVIL(o));
                    }
                }
                return _CAT_ESTADO_CIVILs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_ESTADO_CIVIL() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_ESTADO_CIVIL.single_select();
        }

     #endregion

    }
}
