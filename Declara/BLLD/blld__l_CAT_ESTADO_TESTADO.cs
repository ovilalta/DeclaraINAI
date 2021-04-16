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
    public  class blld__l_CAT_ESTADO_TESTADO : bll__l_CAT_ESTADO_TESTADO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_ESTADO_TESTADO.PageSize;
            set => datos_CAT_ESTADO_TESTADO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_ESTADO_TESTADO.PageNumber;
            set => datos_CAT_ESTADO_TESTADO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_ESTADO_TESTADO.TotalPages;

        public Int32 TotalItems => datos_CAT_ESTADO_TESTADO.TotalItems;

        private List<blld_CAT_ESTADO_TESTADO> _CAT_ESTADO_TESTADOs { get; set; }
        public List<blld_CAT_ESTADO_TESTADO> CAT_ESTADO_TESTADOs
        {
            get
            {
                if (_CAT_ESTADO_TESTADOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_ESTADO_TESTADOs = new List<blld_CAT_ESTADO_TESTADO>();
                    foreach (MODELDeclara_V2.CAT_ESTADO_TESTADO o in base_CAT_ESTADO_TESTADOs)
                    {
                        _CAT_ESTADO_TESTADOs.Add(new blld_CAT_ESTADO_TESTADO(o));
                    }
                }
                return _CAT_ESTADO_TESTADOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_ESTADO_TESTADO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_ESTADO_TESTADO.single_select();
        }

     #endregion

    }
}
