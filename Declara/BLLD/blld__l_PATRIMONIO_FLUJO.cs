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
    public  class blld__l_PATRIMONIO_FLUJO : bll__l_PATRIMONIO_FLUJO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_FLUJO.PageSize;
            set => datos_PATRIMONIO_FLUJO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_FLUJO.PageNumber;
            set => datos_PATRIMONIO_FLUJO.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_FLUJO.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_FLUJO.TotalItems;

        private List<blld_PATRIMONIO_FLUJO> _PATRIMONIO_FLUJOs { get; set; }
        public List<blld_PATRIMONIO_FLUJO> PATRIMONIO_FLUJOs
        {
            get
            {
                if (_PATRIMONIO_FLUJOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_FLUJOs = new List<blld_PATRIMONIO_FLUJO>();
                    foreach (MODELDeclara_V2.PATRIMONIO_FLUJO o in base_PATRIMONIO_FLUJOs)
                    {
                        _PATRIMONIO_FLUJOs.Add(new blld_PATRIMONIO_FLUJO(o));
                    }
                }
                return _PATRIMONIO_FLUJOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_FLUJO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_FLUJO.single_select();
        }

     #endregion

    }
}
