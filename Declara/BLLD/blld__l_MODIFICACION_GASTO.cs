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
    public  class blld__l_MODIFICACION_GASTO : bll__l_MODIFICACION_GASTO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_GASTO.PageSize;
            set => datos_MODIFICACION_GASTO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_GASTO.PageNumber;
            set => datos_MODIFICACION_GASTO.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_GASTO.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_GASTO.TotalItems;

        private List<blld_MODIFICACION_GASTO> _MODIFICACION_GASTOs { get; set; }
        public List<blld_MODIFICACION_GASTO> MODIFICACION_GASTOs
        {
            get
            {
                if (_MODIFICACION_GASTOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_GASTOs = new List<blld_MODIFICACION_GASTO>();
                    foreach (MODELDeclara_V2.MODIFICACION_GASTO o in base_MODIFICACION_GASTOs)
                    {
                        _MODIFICACION_GASTOs.Add(new blld_MODIFICACION_GASTO(o));
                    }
                }
                return _MODIFICACION_GASTOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_GASTO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_GASTO.single_select();
        }

     #endregion

    }
}
