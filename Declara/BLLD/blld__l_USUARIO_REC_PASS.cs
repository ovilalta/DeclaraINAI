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
    public  class blld__l_USUARIO_REC_PASS : bll__l_USUARIO_REC_PASS
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_USUARIO_REC_PASS.PageSize;
            set => datos_USUARIO_REC_PASS.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_USUARIO_REC_PASS.PageNumber;
            set => datos_USUARIO_REC_PASS.PageNumber = value;
        }

        public Int32 TotalPages => datos_USUARIO_REC_PASS.TotalPages;

        public Int32 TotalItems => datos_USUARIO_REC_PASS.TotalItems;

        private List<blld_USUARIO_REC_PASS> _USUARIO_REC_PASSs { get; set; }
        public List<blld_USUARIO_REC_PASS> USUARIO_REC_PASSs
        {
            get
            {
                if (_USUARIO_REC_PASSs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _USUARIO_REC_PASSs = new List<blld_USUARIO_REC_PASS>();
                    foreach (MODELDeclara_V2.USUARIO_REC_PASS o in base_USUARIO_REC_PASSs)
                    {
                        _USUARIO_REC_PASSs.Add(new blld_USUARIO_REC_PASS(o));
                    }
                }
                return _USUARIO_REC_PASSs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_USUARIO_REC_PASS() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_USUARIO_REC_PASS.single_select();
        }

     #endregion

    }
}
