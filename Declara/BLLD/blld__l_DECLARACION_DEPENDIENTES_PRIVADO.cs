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
    public class blld__l_DECLARACION_DEPENDIENTES_PRIVADO : bll__l_DECLARACION_DEPENDIENTES_PRIVADO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.PageSize;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.PageNumber;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_DEPENDIENTES_PRIVADO.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_DEPENDIENTES_PRIVADO.TotalItems;
        private List<blld_DECLARACION_DEPENDIENTES_PRIVADO> _DECLARACION_DEPENDIENTES_PRIVADOs { get; set; }
        public List<blld_DECLARACION_DEPENDIENTES_PRIVADO> DECLARACION_DEPENDIENTES_PRIVADOs
        {
            get
            {
                if (_DECLARACION_DEPENDIENTES_PRIVADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_DEPENDIENTES_PRIVADOs = new List<blld_DECLARACION_DEPENDIENTES_PRIVADO>();
                    foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO o in base_DECLARACION_DEPENDIENTES_PRIVADOs)
                    {
                        _DECLARACION_DEPENDIENTES_PRIVADOs.Add(new blld_DECLARACION_DEPENDIENTES_PRIVADO(o));
                    }
                }
                return _DECLARACION_DEPENDIENTES_PRIVADOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_DEPENDIENTES_PRIVADO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_DEPENDIENTES_PRIVADO.single_select();
        }

        #endregion

    }
}
