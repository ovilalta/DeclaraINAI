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
    public  class blld__l_MODIFICACION_INVERSION_TITU : bll__l_MODIFICACION_INVERSION_TITU
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_INVERSION_TITU.PageSize;
            set => datos_MODIFICACION_INVERSION_TITU.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_INVERSION_TITU.PageNumber;
            set => datos_MODIFICACION_INVERSION_TITU.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_INVERSION_TITU.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_INVERSION_TITU.TotalItems;

        private List<blld_MODIFICACION_INVERSION_TITU> _MODIFICACION_INVERSION_TITUs { get; set; }
        public List<blld_MODIFICACION_INVERSION_TITU> MODIFICACION_INVERSION_TITUs
        {
            get
            {
                if (_MODIFICACION_INVERSION_TITUs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_INVERSION_TITUs = new List<blld_MODIFICACION_INVERSION_TITU>();
                    foreach (MODELDeclara_V2.MODIFICACION_INVERSION_TITU o in base_MODIFICACION_INVERSION_TITUs)
                    {
                        _MODIFICACION_INVERSION_TITUs.Add(new blld_MODIFICACION_INVERSION_TITU(o));
                    }
                }
                return _MODIFICACION_INVERSION_TITUs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_INVERSION_TITU() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_INVERSION_TITU.single_select();
        }

     #endregion

    }
}
