using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll_CAT_CODIGO_POSTAL : _bllSistema
    {

        internal dald_CAT_CODIGO_POSTAL datos_CAT_CODIGO_POSTAL;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS => datos_CAT_CODIGO_POSTAL.NID_PAIS;

        [Key]
        [StringLength(2)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA => datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_MUNICIPIO => datos_CAT_CODIGO_POSTAL.CID_MUNICIPIO;

        [Key]
        [StringLength(5)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_CODIGO_POSTAL => datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTAL;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_COLONIA => datos_CAT_CODIGO_POSTAL.NID_COLONIA;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_COLONIA
        {
          get => datos_CAT_CODIGO_POSTAL.V_COLONIA;
          set => datos_CAT_CODIGO_POSTAL.V_COLONIA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_CODIGO_POSTAL.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_CODIGO_POSTAL() => datos_CAT_CODIGO_POSTAL = new dald_CAT_CODIGO_POSTAL();

        public bll_CAT_CODIGO_POSTAL(MODELDeclara_V2.CAT_CODIGO_POSTAL CAT_CODIGO_POSTAL) => datos_CAT_CODIGO_POSTAL = new dald_CAT_CODIGO_POSTAL(CAT_CODIGO_POSTAL);

        public bll_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA) => datos_CAT_CODIGO_POSTAL = new dald_CAT_CODIGO_POSTAL(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA);

        public bll_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA, String V_COLONIA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_CODIGO_POSTAL = new dald_CAT_CODIGO_POSTAL(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA, V_COLONIA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_CODIGO_POSTAL.update();
        }

        public void delete()
        {
            datos_CAT_CODIGO_POSTAL.delete();
        }

        public void reload()
        {
            datos_CAT_CODIGO_POSTAL.reload();
        }

     #endregion

    }
}
