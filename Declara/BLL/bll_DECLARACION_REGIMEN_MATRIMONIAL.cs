using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_REGIMEN_MATRIMONIAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_REGIMEN_MATRIMONIAL datos_DECLARACION_REGIMEN_MATRIMONIAL { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION;
        public Int32 NID_REGIMEN => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN;
        public Int32 NID_REGIMEN_MATRIMONIAL
        {
            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_REGIMEN_MATRIMONIAL.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_REGIMEN_MATRIMONIAL() => datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL();
        public bll_DECLARACION_REGIMEN_MATRIMONIAL(MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL DECLARACION_REGIMEN_MATRIMONIAL) => datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL(DECLARACION_REGIMEN_MATRIMONIAL);
        public bll_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN) => datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN);

//        public bll_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN, Int32 NID_REGIMEN_MATRIMONIAL)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_REGIMEN = NID_REGIMEN; 
//            this.NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL;
//            datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_REGIMEN, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_REGIMEN, this.NID_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.update();
        }
        public void delete()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.delete();
        }
        public void reload()
        {
            datos_DECLARACION_REGIMEN_MATRIMONIAL.reload();
        }

        #endregion

    }
}
