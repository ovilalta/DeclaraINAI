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
    public  class blld__l_CONFLICTO_RESPUESTA : bll__l_CONFLICTO_RESPUESTA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CONFLICTO_RESPUESTA.PageSize;
            set => datos_CONFLICTO_RESPUESTA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CONFLICTO_RESPUESTA.PageNumber;
            set => datos_CONFLICTO_RESPUESTA.PageNumber = value;
        }

        public Int32 TotalPages => datos_CONFLICTO_RESPUESTA.TotalPages;

        public Int32 TotalItems => datos_CONFLICTO_RESPUESTA.TotalItems;

        private List<blld_CONFLICTO_RESPUESTA> _CONFLICTO_RESPUESTAs { get; set; }
        public List<blld_CONFLICTO_RESPUESTA> CONFLICTO_RESPUESTAs
        {
            get
            {
                if (_CONFLICTO_RESPUESTAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CONFLICTO_RESPUESTAs = new List<blld_CONFLICTO_RESPUESTA>();
                    foreach (MODELDeclara_V2.CONFLICTO_RESPUESTA o in base_CONFLICTO_RESPUESTAs)
                    {
                        _CONFLICTO_RESPUESTAs.Add(new blld_CONFLICTO_RESPUESTA(o));
                    }
                }
                return _CONFLICTO_RESPUESTAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CONFLICTO_RESPUESTA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CONFLICTO_RESPUESTA.single_select();
        }

     #endregion

    }
}
