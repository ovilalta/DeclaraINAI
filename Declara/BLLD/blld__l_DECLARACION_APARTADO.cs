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
    public  class blld__l_DECLARACION_APARTADO : bll__l_DECLARACION_APARTADO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_APARTADO.PageSize;
            set => datos_DECLARACION_APARTADO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_APARTADO.PageNumber;
            set => datos_DECLARACION_APARTADO.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_APARTADO.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_APARTADO.TotalItems;

        private List<blld_DECLARACION_APARTADO> _DECLARACION_APARTADOs { get; set; }
        public List<blld_DECLARACION_APARTADO> DECLARACION_APARTADOs
        {
            get
            {
                if (_DECLARACION_APARTADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_APARTADOs = new List<blld_DECLARACION_APARTADO>();
                    foreach (MODELDeclara_V2.DECLARACION_APARTADO o in base_DECLARACION_APARTADOs)
                    {
                        _DECLARACION_APARTADOs.Add(new blld_DECLARACION_APARTADO(o));
                    }
                }
                return _DECLARACION_APARTADOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_APARTADO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_APARTADO.single_select();
        }

     #endregion

    }
}
