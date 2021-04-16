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
    public  class blld__l_CAT_APARTADO : bll__l_CAT_APARTADO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_APARTADO.PageSize;
            set => datos_CAT_APARTADO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_APARTADO.PageNumber;
            set => datos_CAT_APARTADO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_APARTADO.TotalPages;

        public Int32 TotalItems => datos_CAT_APARTADO.TotalItems;

        private List<blld_CAT_APARTADO> _CAT_APARTADOs { get; set; }
        public List<blld_CAT_APARTADO> CAT_APARTADOs
        {
            get
            {
                if (_CAT_APARTADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_APARTADOs = new List<blld_CAT_APARTADO>();
                    foreach (MODELDeclara_V2.CAT_APARTADO o in base_CAT_APARTADOs)
                    {
                        _CAT_APARTADOs.Add(new blld_CAT_APARTADO(o));
                    }
                }
                return _CAT_APARTADOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_APARTADO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_APARTADO.single_select();
        }

     #endregion

    }
}
