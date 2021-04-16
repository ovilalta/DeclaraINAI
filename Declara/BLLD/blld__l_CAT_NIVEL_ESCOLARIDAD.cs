using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_CAT_NIVEL_ESCOLARIDAD : bll__l_CAT_NIVEL_ESCOLARIDAD
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.PageSize;
            set => datos_CAT_NIVEL_ESCOLARIDAD.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.PageNumber;
            set => datos_CAT_NIVEL_ESCOLARIDAD.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_NIVEL_ESCOLARIDAD.TotalPages;
        public Int32 TotalItems => datos_CAT_NIVEL_ESCOLARIDAD.TotalItems;
        private List<blld_CAT_NIVEL_ESCOLARIDAD> _CAT_NIVEL_ESCOLARIDADs { get; set; }
        public List<blld_CAT_NIVEL_ESCOLARIDAD> CAT_NIVEL_ESCOLARIDADs
        {
            get
            {
                if (_CAT_NIVEL_ESCOLARIDADs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_NIVEL_ESCOLARIDADs = new List<blld_CAT_NIVEL_ESCOLARIDAD>();
                    foreach (MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD o in base_CAT_NIVEL_ESCOLARIDADs)
                    {
                        _CAT_NIVEL_ESCOLARIDADs.Add(new blld_CAT_NIVEL_ESCOLARIDAD(o));
                    }
                }
                return _CAT_NIVEL_ESCOLARIDADs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_NIVEL_ESCOLARIDAD() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_NIVEL_ESCOLARIDAD.single_select();
        }

        #endregion

    }
}
