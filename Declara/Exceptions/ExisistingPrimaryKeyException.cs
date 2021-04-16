using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.Exceptions
{
    public class ExistingPrimaryKeyException : CustomException
    {
        public enum ExistingPrimaryKeyConditions
        {
            ThrowException,
            UseExisiting,
            UpdateExisiting,
        }
        private String _Message { get; set; }
        public override string Message => _Message;

        private Exception _InnerException { get; set; }
        new public Exception InnerException => _InnerException;

        public ExistingPrimaryKeyException(String tabla, String key)
            : base()
        {
            String vInnerException = "No se puede insertar una clave duplicada en el objeto '" + tabla + "' la clave duplicada es: (" + key + ") ; Boolean ExceptionName.Data.Contains(5000)";
            this._Message = "El registro que esta tratando de ingresar ya existe";
            this.Data.Add(5000, vInnerException);
            this._InnerException = new Exception(vInnerException);
        }
        private ExistingPrimaryKeyException() : base() { }

        private ExistingPrimaryKeyException(String message) : base(message) { }

        private ExistingPrimaryKeyException(String message, Exception innerException) : base(message, innerException) { }
    }
}
